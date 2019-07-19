// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDrawingObject
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a drawing object.</summary>
    public class HDrawingObject : HTool
    {
        private HDrawingObject.HDrawingObjectCallback onresize;
        private HDrawingObject.HDrawingObjectCallback onattach;
        private HDrawingObject.HDrawingObjectCallback ondetach;
        private HDrawingObject.HDrawingObjectCallback ondrag;
        private HDrawingObject.HDrawingObjectCallback onselect;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDrawingObject()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDrawingObject(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDrawingObject obj)
        {
            obj = new HDrawingObject(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDrawingObject[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDrawingObject[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDrawingObject(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a circle which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 100</param>
        /// <param name="column">Column coordinate of the center. Default: 100</param>
        /// <param name="radius">Radius of the circle. Default: 80</param>
        public HDrawingObject(double row, double column, double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1311);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle of any orientation which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 150</param>
        /// <param name="column">Column coordinate of the center. Default: 150</param>
        /// <param name="phi">Orientation of the first half axis in radians. Default: 0</param>
        /// <param name="length1">First half axis. Default: 100</param>
        /// <param name="length2">Second half axis. Default: 100</param>
        public HDrawingObject(double row, double column, double phi, double length1, double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1313);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, length1);
            HalconAPI.StoreD(proc, 4, length2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axis which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner. Default: 100</param>
        /// <param name="column1">Column coordinate of the upper left corner. Default: 100</param>
        /// <param name="row2">Row coordinate of the lower right corner. Default: 200</param>
        /// <param name="column2">Column coordinate of the lower right corner. Default: 200</param>
        public HDrawingObject(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1314);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Returns the corresponding HALCON id.</summary>
        public long ID
        {
            get
            {
                return this.Handle.ToInt64();
            }
        }

        protected IntPtr DelegateToCallbackPointer(HDrawingObject.HDrawingObjectCallback c)
        {
            return Marshal.GetFunctionPointerForDelegate((Delegate)c);
        }

        protected IntPtr DelegateToCallbackPointer(
          HDrawingObject.HDrawingObjectCallbackClass c,
          string evt)
        {
            HDrawingObject.HDrawingObjectCallback hdrawingObjectCallback = (HDrawingObject.HDrawingObjectCallback)((drawid, window, type) =>
            {
                HDrawingObject drawid1 = new HDrawingObject(drawid);
                HWindow window1 = new HWindow(window);
                drawid1.Detach();
                window1.Detach();
                c(drawid1, window1, type);
            });
            GC.KeepAlive((object)hdrawingObjectCallback);
            GC.SuppressFinalize((object)hdrawingObjectCallback);
            switch (evt)
            {
                case "on_resize":
                    this.onresize = hdrawingObjectCallback;
                    break;
                case "on_attach":
                    this.onattach = hdrawingObjectCallback;
                    break;
                case "on_detach":
                    this.ondetach = hdrawingObjectCallback;
                    break;
                case "on_drag":
                    this.ondrag = hdrawingObjectCallback;
                    break;
                case "on_select":
                    this.onselect = hdrawingObjectCallback;
                    break;
            }
            return Marshal.GetFunctionPointerForDelegate((Delegate)hdrawingObjectCallback);
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the user changes any of the dimensions of the draw
        /// object.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnResize(HDrawingObject.HDrawingObjectCallback f)
        {
            this.SetDrawingObjectCallback("on_resize", Marshal.GetFunctionPointerForDelegate((Delegate)f));
        }

        /// <summary>Adds a callback for the attach event, that is, this callback is
        /// executed when a drawing object is attached to the window.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnAttach(HDrawingObject.HDrawingObjectCallback f)
        {
            this.SetDrawingObjectCallback("on_attach", Marshal.GetFunctionPointerForDelegate((Delegate)f));
        }

        /// <summary>Adds a callback for the detach event, that is, this callback is
        /// executed when a drawing object is detached from the window.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnDetach(HDrawingObject.HDrawingObjectCallback f)
        {
            this.SetDrawingObjectCallback("on_detach", Marshal.GetFunctionPointerForDelegate((Delegate)f));
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the drawing object's position changes.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnDrag(HDrawingObject.HDrawingObjectCallback f)
        {
            this.SetDrawingObjectCallback("on_drag", Marshal.GetFunctionPointerForDelegate((Delegate)f));
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the drawing object is selected.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnSelect(HDrawingObject.HDrawingObjectCallback f)
        {
            this.SetDrawingObjectCallback("on_select", Marshal.GetFunctionPointerForDelegate((Delegate)f));
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the user changes any of the dimensions of the draw
        /// object.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnResize(HDrawingObject.HDrawingObjectCallbackClass f)
        {
            this.SetDrawingObjectCallback("on_resize", this.DelegateToCallbackPointer(f, "on_resize"));
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the drawing object's position changes.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnDrag(HDrawingObject.HDrawingObjectCallbackClass f)
        {
            this.SetDrawingObjectCallback("on_drag", this.DelegateToCallbackPointer(f, "on_drag"));
        }

        /// <summary>Adds a callback for the resize event, that is, this callback is
        /// executed whenever the drawing object is selected.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnSelect(HDrawingObject.HDrawingObjectCallbackClass f)
        {
            this.SetDrawingObjectCallback("on_select", this.DelegateToCallbackPointer(f, "on_select"));
        }

        /// <summary>Adds a callback for the attach event, that is, this callback is
        /// executed when a drawing object is attached to the window.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnAttach(HDrawingObject.HDrawingObjectCallbackClass f)
        {
            this.SetDrawingObjectCallback("on_attach", this.DelegateToCallbackPointer(f, "on_attach"));
        }

        /// <summary>Adds a callback for the detach event, that is, this callback is
        /// executed when a drawing object is detached from the window.</summary>
        /// <param name="f">Callback function with the signature defined by
        /// HDrawingObjectCallback</param>
        public void OnDetach(HDrawingObject.HDrawingObjectCallbackClass f)
        {
            this.SetDrawingObjectCallback("on_detach", this.DelegateToCallbackPointer(f, "on_detach"));
        }

        /// <summary>Method to create drawing objects by explicitly specifying the type.</summary>
        /// <param name="type">Type of the drawing object. Can be any of the specified by
        /// the enum type HDrawingObjectType.</param>
        /// <param name="values"> List of parameters for the corresponding drawing object.
        /// See the constructors listed in HOperatorSet for more details.</param>
        public static HDrawingObject CreateDrawingObject(
          HDrawingObject.HDrawingObjectType type,
          params HTuple[] values)
        {
            HTuple drawID = (HTuple)null;
            switch (type)
            {
                case HDrawingObject.HDrawingObjectType.RECTANGLE1:
                    HOperatorSet.CreateDrawingObjectRectangle1(values[0], values[1], values[2], values[3], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.RECTANGLE2:
                    HOperatorSet.CreateDrawingObjectRectangle2(values[0], values[1], values[2], values[3], values[4], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.CIRCLE:
                    HOperatorSet.CreateDrawingObjectCircle(values[0], values[1], values[2], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.ELLIPSE:
                    HOperatorSet.CreateDrawingObjectEllipse(values[0], values[1], values[2], values[3], values[4], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.CIRCLE_SECTOR:
                    HOperatorSet.CreateDrawingObjectCircleSector(values[0], values[1], values[2], values[3], values[4], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.ELLIPSE_SECTOR:
                    HOperatorSet.CreateDrawingObjectEllipseSector(values[0], values[1], values[2], values[3], values[4], values[5], values[6], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.LINE:
                    HOperatorSet.CreateDrawingObjectLine(values[0], values[1], values[2], values[3], out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.XLD_CONTOUR:
                    if (values.Length != 2)
                        throw new HalconException("Invalid number of parameters");
                    if (values[0].Length != values[1].Length)
                        throw new HalconException("The length of the input tuples must be identical");
                    HOperatorSet.CreateDrawingObjectXld((HTuple)values[0].DArr, (HTuple)values[1].DArr, out drawID);
                    break;
                case HDrawingObject.HDrawingObjectType.TEXT:
                    HOperatorSet.CreateDrawingObjectText(values[0], values[1], values[2], out drawID);
                    break;
            }
            return new HDrawingObject(new IntPtr(drawID.L));
        }

        /// <summary>
        ///   Add a callback function to a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="drawObjectEvent">Events to be captured.</param>
        /// <param name="callbackFunction">Callback functions.</param>
        public void SetDrawingObjectCallback(HTuple drawObjectEvent, HTuple callbackFunction)
        {
            IntPtr proc = HalconAPI.PreCall(1162);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, drawObjectEvent);
            HalconAPI.Store(proc, 2, callbackFunction);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(drawObjectEvent);
            HalconAPI.UnpinTuple(callbackFunction);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a callback function to a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="drawObjectEvent">Events to be captured.</param>
        /// <param name="callbackFunction">Callback functions.</param>
        public void SetDrawingObjectCallback(string drawObjectEvent, IntPtr callbackFunction)
        {
            IntPtr proc = HalconAPI.PreCall(1162);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, drawObjectEvent);
            HalconAPI.StoreIP(proc, 2, callbackFunction);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Detach the background image from a HALCON window.</summary>
        /// <param name="windowHandle">Window handle.</param>
        public static void DetachBackgroundFromWindow(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1163);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>Attach a background image to a HALCON window.</summary>
        /// <param name="image">Background image.</param>
        /// <param name="windowHandle">Window handle.</param>
        public static void AttachBackgroundToWindow(HImage image, HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1164);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Create a text object which can be moved interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the text position. Default: 12</param>
        /// <param name="column">Column coordinate of the text position. Default: 12</param>
        /// <param name="stringVal">Character string to be displayed. Default: "Text"</param>
        public void CreateDrawingObjectText(int row, int column, string stringVal)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1301);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreS(proc, 2, stringVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the iconic object of a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <returns>Copy of the iconic object represented by the drawing object.</returns>
        public HObject GetDrawingObjectIconic()
        {
            IntPtr proc = HalconAPI.PreCall(1302);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Set the parameters of a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="genParamName">Parameter names of the drawing object.</param>
        /// <param name="genParamValue">Parameter values.</param>
        public void SetDrawingObjectParams(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1304);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the parameters of a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="genParamName">Parameter names of the drawing object.</param>
        /// <param name="genParamValue">Parameter values.</param>
        public void SetDrawingObjectParams(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1304);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the parameters of a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="genParamName">Parameter names of the drawing object.</param>
        /// <returns>Parameter values.</returns>
        public HTuple GetDrawingObjectParams(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1305);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the parameters of a drawing object.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="genParamName">Parameter names of the drawing object.</param>
        /// <returns>Parameter values.</returns>
        public HTuple GetDrawingObjectParams(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1305);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set the contour of an interactive draw XLD.
        ///   Instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="contour">XLD contour.</param>
        public void SetDrawingObjectXld(HXLDCont contour)
        {
            IntPtr proc = HalconAPI.PreCall(1306);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
        }

        /// <summary>
        ///   Create a XLD contour which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinates of the polygon. Default: [100,200,200,100]</param>
        /// <param name="column">Column coordinates of the polygon. Default: [100,100,200,200]</param>
        public void CreateDrawingObjectXld(HTuple row, HTuple column)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1307);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle sector which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 100</param>
        /// <param name="column">Column coordinate of the center. Default: 100</param>
        /// <param name="radius">Radius of the circle. Default: 80</param>
        /// <param name="startAngle">Start angle of the arc. Default: 0</param>
        /// <param name="endAngle">End angle of the arc. Default: 3.14159</param>
        public void CreateDrawingObjectCircleSector(
          double row,
          double column,
          double radius,
          double startAngle,
          double endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1308);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, startAngle);
            HalconAPI.StoreD(proc, 4, endAngle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an elliptic sector which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row index of the center. Default: 200</param>
        /// <param name="column">Column index of the center. Default: 200</param>
        /// <param name="phi">Orientation of the first half axis in radians. Default: 0</param>
        /// <param name="radius1">First half axis. Default: 100</param>
        /// <param name="radius2">Second half axis. Default: 60</param>
        /// <param name="startAngle">Start angle of the arc. Default: 0</param>
        /// <param name="endAngle">End angle of the arc. Default: 3.14159</param>
        public void CreateDrawingObjectEllipseSector(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          double startAngle,
          double endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1309);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.StoreD(proc, 5, startAngle);
            HalconAPI.StoreD(proc, 6, endAngle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a line which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row1">Row index of the first line point. Default: 100</param>
        /// <param name="column1">Column index of the first line point. Default: 100</param>
        /// <param name="row2">Row index of the second line point. Default: 200</param>
        /// <param name="column2">Column index of the second line point. Default: 200</param>
        public void CreateDrawingObjectLine(double row1, double column1, double row2, double column2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1310);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 100</param>
        /// <param name="column">Column coordinate of the center. Default: 100</param>
        /// <param name="radius">Radius of the circle. Default: 80</param>
        public void CreateDrawingObjectCircle(double row, double column, double radius)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1311);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row index of the center. Default: 200</param>
        /// <param name="column">Column index of the center. Default: 200</param>
        /// <param name="phi">Orientation of the first half axis in radians. Default: 0</param>
        /// <param name="radius1">First half axis. Default: 100</param>
        /// <param name="radius2">Second half axis. Default: 60</param>
        public void CreateDrawingObjectEllipse(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1312);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle of any orientation which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 150</param>
        /// <param name="column">Column coordinate of the center. Default: 150</param>
        /// <param name="phi">Orientation of the first half axis in radians. Default: 0</param>
        /// <param name="length1">First half axis. Default: 100</param>
        /// <param name="length2">Second half axis. Default: 100</param>
        public void CreateDrawingObjectRectangle2(
          double row,
          double column,
          double phi,
          double length1,
          double length2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1313);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, length1);
            HalconAPI.StoreD(proc, 4, length2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axis which can be modified interactively.
        ///   Modified instance represents: Handle of the drawing object.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner. Default: 100</param>
        /// <param name="column1">Column coordinate of the upper left corner. Default: 100</param>
        /// <param name="row2">Row coordinate of the lower right corner. Default: 200</param>
        /// <param name="column2">Column coordinate of the lower right corner. Default: 200</param>
        public void CreateDrawingObjectRectangle1(
          double row1,
          double column1,
          double row2,
          double column2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1314);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Send an event to a buffer window signaling a mouse double click event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDoubleClickEvent(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          int button)
        {
            IntPtr proc = HalconAPI.PreCall(2088);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a buffer window signaling a mouse double click event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDoubleClickEvent(
          HWindow windowHandle,
          int row,
          int column,
          int button)
        {
            IntPtr proc = HalconAPI.PreCall(2088);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a window buffer signaling a mouse down event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDownEvent(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          int button)
        {
            IntPtr proc = HalconAPI.PreCall(2089);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a window buffer signaling a mouse down event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDownEvent(HWindow windowHandle, int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2089);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a buffer window signaling a mouse drag event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDragEvent(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          int button)
        {
            IntPtr proc = HalconAPI.PreCall(2090);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a buffer window signaling a mouse drag event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseDragEvent(HWindow windowHandle, int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2090);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a buffer window signaling a mouse up event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseUpEvent(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          int button)
        {
            IntPtr proc = HalconAPI.PreCall(2091);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Send an event to a buffer window signaling a mouse up event.</summary>
        /// <param name="windowHandle">Window handle of the buffer window.</param>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public static string SendMouseUpEvent(HWindow windowHandle, int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2091);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1303);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Signature for the drawing object callbacks in managed code.</summary>
        public delegate void HDrawingObjectCallback(IntPtr drawid, IntPtr windowHandle, string type);

        /// <summary>Signature for the drawing object callbacks in managed code.</summary>
        public delegate void HDrawingObjectCallbackClass(
          HDrawingObject drawid,
          HWindow window,
          string type);

        public enum HDrawingObjectType
        {
            RECTANGLE1,
            RECTANGLE2,
            CIRCLE,
            ELLIPSE,
            CIRCLE_SECTOR,
            ELLIPSE_SECTOR,
            LINE,
            XLD_CONTOUR,
            TEXT,
        }
    }
}
