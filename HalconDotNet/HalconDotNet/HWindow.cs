using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HalconDotNet
{
    public class HWindow : HTool
    {
        private HWindow.ContentUpdateCallback _callback;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HWindow()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HWindow(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HWindow obj)
        {
            obj = new HWindow(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HWindow[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HWindow[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HWindow(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open a graphics window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        /// <param name="fatherWindow">Logical number of the father window. To specify the display as father you may enter 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Name of the computer on which you want to open the window. Otherwise the empty string. Default: ""</param>
        public HWindow(
          int row,
          int column,
          int width,
          int height,
          HTuple fatherWindow,
          string mode,
          string machine)
        {
            IntPtr proc = HalconAPI.PreCall(1178);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.Store(proc, 4, fatherWindow);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(fatherWindow);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a graphics window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        /// <param name="fatherWindow">Logical number of the father window. To specify the display as father you may enter 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Name of the computer on which you want to open the window. Otherwise the empty string. Default: ""</param>
        public HWindow(
          int row,
          int column,
          int width,
          int height,
          IntPtr fatherWindow,
          string mode,
          string machine)
        {
            IntPtr proc = HalconAPI.PreCall(1178);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreIP(proc, 4, fatherWindow);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Closes the window.</summary>
        public void CloseWindow()
        {
            this.Dispose();
        }

        [DllImport("X11", EntryPoint = "XInitThreads")]
        private static extern int _XInitThreads();

        public static int XInitThreads()
        {
            try
            {
                return HWindow._XInitThreads();
            }
            catch (DllNotFoundException ex)
            {
                return 0;
            }
        }

        public void OnContentUpdate(HWindow.ContentUpdateCallback f)
        {
            this._callback = f;
            this.SetContentUpdateCallback(Marshal.GetFunctionPointerForDelegate(this._callback), new IntPtr(0));
        }

        /// <summary>
        ///   Display an XLD object.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="XLDObject">XLD object to display.</param>
        public void DispXld(HXLD XLDObject)
        {
            IntPtr proc = HalconAPI.PreCall(74);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)XLDObject);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)XLDObject);
        }

        /// <summary>
        ///   Gets a copy of the background image of the HALCON window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Copy of the background image.</returns>
        public HImage GetWindowBackgroundImage()
        {
            IntPtr proc = HalconAPI.PreCall(1161);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Detach the background image from a HALCON window.
        ///   Instance represents: Window handle.
        /// </summary>
        public void DetachBackgroundFromWindow()
        {
            IntPtr proc = HalconAPI.PreCall(1163);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Attach a background image to a HALCON window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="image">Background image.</param>
        public void AttachBackgroundToWindow(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1164);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Detach an existing drawing object from a HALCON window.
        ///   Instance represents: Window Handle.
        /// </summary>
        /// <param name="drawID">Handle of the drawing object.</param>
        public void DetachDrawingObjectFromWindow(HDrawingObject drawID)
        {
            IntPtr proc = HalconAPI.PreCall(1165);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)drawID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)drawID);
        }

        /// <summary>
        ///   Attach an existing drawing object to a HALCON window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="drawID">Handle of the drawing object.</param>
        public void AttachDrawingObjectToWindow(HDrawingObject drawID)
        {
            IntPtr proc = HalconAPI.PreCall(1166);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)drawID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)drawID);
        }

        /// <summary>
        ///   Modify the pose of a 3D plot.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="lastRow">Row coordinate of the first point.</param>
        /// <param name="lastCol">Column coordinate of the first point.</param>
        /// <param name="currentRow">Row coordinate of the second point.</param>
        /// <param name="currentCol">Column coordinate of the second point.</param>
        /// <param name="mode">Navigation mode. Default: "rotate"</param>
        public void UpdateWindowPose(
          HTuple lastRow,
          HTuple lastCol,
          HTuple currentRow,
          HTuple currentCol,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1167);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, lastRow);
            HalconAPI.Store(proc, 2, lastCol);
            HalconAPI.Store(proc, 3, currentRow);
            HalconAPI.Store(proc, 4, currentCol);
            HalconAPI.StoreS(proc, 5, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(lastRow);
            HalconAPI.UnpinTuple(lastCol);
            HalconAPI.UnpinTuple(currentRow);
            HalconAPI.UnpinTuple(currentCol);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Modify the pose of a 3D plot.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="lastRow">Row coordinate of the first point.</param>
        /// <param name="lastCol">Column coordinate of the first point.</param>
        /// <param name="currentRow">Row coordinate of the second point.</param>
        /// <param name="currentCol">Column coordinate of the second point.</param>
        /// <param name="mode">Navigation mode. Default: "rotate"</param>
        public void UpdateWindowPose(
          double lastRow,
          double lastCol,
          double currentRow,
          double currentCol,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1167);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, lastRow);
            HalconAPI.StoreD(proc, 2, lastCol);
            HalconAPI.StoreD(proc, 3, currentRow);
            HalconAPI.StoreD(proc, 4, currentCol);
            HalconAPI.StoreS(proc, 5, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculates image coordinates for a point in a 3D plot window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="image">Displayed image.</param>
        /// <param name="row">Row coordinate in the window.</param>
        /// <param name="column">Column coordinate in the window.</param>
        /// <param name="imageRow">Row coordinate in the image.</param>
        /// <param name="imageColumn">Column coordinate in the image.</param>
        /// <param name="height">Height value.</param>
        public void UnprojectCoordinates(
          HImage image,
          HTuple row,
          HTuple column,
          out int imageRow,
          out int imageColumn,
          out HTuple height)
        {
            IntPtr proc = HalconAPI.PreCall(1168);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out imageRow);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out imageColumn);
            int procResult = HTuple.LoadNew(proc, 2, err3, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Calculates image coordinates for a point in a 3D plot window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="image">Displayed image.</param>
        /// <param name="row">Row coordinate in the window.</param>
        /// <param name="column">Column coordinate in the window.</param>
        /// <param name="imageRow">Row coordinate in the image.</param>
        /// <param name="imageColumn">Column coordinate in the image.</param>
        /// <param name="height">Height value.</param>
        public void UnprojectCoordinates(
          HImage image,
          double row,
          double column,
          out int imageRow,
          out int imageColumn,
          out int height)
        {
            IntPtr proc = HalconAPI.PreCall(1168);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out imageRow);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out imageColumn);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Get the operating system window handle.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="OSDisplayHandle">Operating system display handle (under Unix-like systems only).</param>
        /// <returns>Operating system window handle.</returns>
        public IntPtr GetOsWindowHandle(out IntPtr OSDisplayHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1169);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            IntPtr intPtrValue;
            int err2 = HalconAPI.LoadIP(proc, 0, err1, out intPtrValue);
            int procResult = HalconAPI.LoadIP(proc, 1, err2, out OSDisplayHandle);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intPtrValue;
        }

        /// <summary>
        ///   Set the device context of a virtual graphics window (Windows NT).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="WINHDC">device context of WINHWnd.</param>
        public void SetWindowDc(IntPtr WINHDC)
        {
            IntPtr proc = HalconAPI.PreCall(1170);
            this.Store(proc, 0);
            HalconAPI.StoreIP(proc, 1, WINHDC);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a virtual graphics window under Windows.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="WINHWnd">Windows window handle of a previously created window.</param>
        /// <param name="row">Row coordinate of upper left corner. Default: 0</param>
        /// <param name="column">Column coordinate of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 512</param>
        /// <param name="height">Height of the window. Default: 512</param>
        public void NewExternWindow(IntPtr WINHWnd, int row, int column, int width, int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1171);
            HalconAPI.StoreIP(proc, 0, WINHWnd);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive output from two window buffers.
        ///   Instance represents: Source window handle of the "`upper window"'.
        /// </summary>
        /// <param name="windowHandleSource2">Source window handle of the "`lower window"'.</param>
        /// <param name="windowHandle">Output window handle.</param>
        public void SlideImage(HWindow windowHandleSource2, HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1172);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)windowHandleSource2);
            HalconAPI.Store(proc, 2, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandleSource2);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Modify position and size of a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner in target position. Default: 0</param>
        /// <param name="column">Column index of upper left corner in target position. Default: 0</param>
        /// <param name="width">Width of the window. Default: 512</param>
        /// <param name="height">Height of the window. Default: 512</param>
        public void SetWindowExtents(int row, int column, int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(1174);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a graphics window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        /// <param name="fatherWindow">Logical number of the father window. To specify the display as father you may enter 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Name of the computer on which you want to open the window. Otherwise the empty string. Default: ""</param>
        public void OpenWindow(
          int row,
          int column,
          int width,
          int height,
          HTuple fatherWindow,
          string mode,
          string machine)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1178);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.Store(proc, 4, fatherWindow);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(fatherWindow);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a graphics window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        /// <param name="fatherWindow">Logical number of the father window. To specify the display as father you may enter 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Name of the computer on which you want to open the window. Otherwise the empty string. Default: ""</param>
        public void OpenWindow(
          int row,
          int column,
          int width,
          int height,
          IntPtr fatherWindow,
          string mode,
          string machine)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1178);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreIP(proc, 4, fatherWindow);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a textual window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Window's width. Default: 256</param>
        /// <param name="height">Window's height. Default: 256</param>
        /// <param name="borderWidth">Window border's width. Default: 2</param>
        /// <param name="borderColor">Window border's color. Default: "white"</param>
        /// <param name="backgroundColor">Background color. Default: "black"</param>
        /// <param name="fatherWindow">Logical number of the father window. For the display as father you may specify 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Computer name, where the window has to be opened or empty string. Default: ""</param>
        public void OpenTextwindow(
          int row,
          int column,
          int width,
          int height,
          int borderWidth,
          string borderColor,
          string backgroundColor,
          HTuple fatherWindow,
          string mode,
          string machine)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1179);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreI(proc, 4, borderWidth);
            HalconAPI.StoreS(proc, 5, borderColor);
            HalconAPI.StoreS(proc, 6, backgroundColor);
            HalconAPI.Store(proc, 7, fatherWindow);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(fatherWindow);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a textual window.
        ///   Modified instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Window's width. Default: 256</param>
        /// <param name="height">Window's height. Default: 256</param>
        /// <param name="borderWidth">Window border's width. Default: 2</param>
        /// <param name="borderColor">Window border's color. Default: "white"</param>
        /// <param name="backgroundColor">Background color. Default: "black"</param>
        /// <param name="fatherWindow">Logical number of the father window. For the display as father you may specify 'root' or 0. Default: 0</param>
        /// <param name="mode">Window mode. Default: "visible"</param>
        /// <param name="machine">Computer name, where the window has to be opened or empty string. Default: ""</param>
        public void OpenTextwindow(
          int row,
          int column,
          int width,
          int height,
          int borderWidth,
          string borderColor,
          string backgroundColor,
          IntPtr fatherWindow,
          string mode,
          string machine)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1179);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreI(proc, 4, borderWidth);
            HalconAPI.StoreS(proc, 5, borderColor);
            HalconAPI.StoreS(proc, 6, backgroundColor);
            HalconAPI.StoreIP(proc, 7, fatherWindow);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, machine);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Copy inside an output window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of upper left corner of the source rectangle. Default: 0</param>
        /// <param name="column1">Column index of upper left corner of the source rectangle. Default: 0</param>
        /// <param name="row2">Row index of lower right corner of the source rectangle. Default: 64</param>
        /// <param name="column2">Column index of lower right corner of the source rectangle. Default: 64</param>
        /// <param name="destRow">Row index of upper left corner of the target position. Default: 64</param>
        /// <param name="destColumn">Column index of upper left corner of the target position. Default: 64</param>
        public void MoveRectangle(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          HTuple destRow,
          HTuple destColumn)
        {
            IntPtr proc = HalconAPI.PreCall(1180);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            HalconAPI.Store(proc, 5, destRow);
            HalconAPI.Store(proc, 6, destColumn);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.UnpinTuple(destRow);
            HalconAPI.UnpinTuple(destColumn);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Copy inside an output window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of upper left corner of the source rectangle. Default: 0</param>
        /// <param name="column1">Column index of upper left corner of the source rectangle. Default: 0</param>
        /// <param name="row2">Row index of lower right corner of the source rectangle. Default: 64</param>
        /// <param name="column2">Column index of lower right corner of the source rectangle. Default: 64</param>
        /// <param name="destRow">Row index of upper left corner of the target position. Default: 64</param>
        /// <param name="destColumn">Column index of upper left corner of the target position. Default: 64</param>
        public void MoveRectangle(
          int row1,
          int column1,
          int row2,
          int column2,
          int destRow,
          int destColumn)
        {
            IntPtr proc = HalconAPI.PreCall(1180);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row1);
            HalconAPI.StoreI(proc, 2, column1);
            HalconAPI.StoreI(proc, 3, row2);
            HalconAPI.StoreI(proc, 4, column2);
            HalconAPI.StoreI(proc, 5, destRow);
            HalconAPI.StoreI(proc, 6, destColumn);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the window type.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Window type</returns>
        public string GetWindowType()
        {
            IntPtr proc = HalconAPI.PreCall(1181);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Access to a window's pixel data.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="imageRed">Pointer on red channel of pixel data.</param>
        /// <param name="imageGreen">Pointer on green channel of pixel data.</param>
        /// <param name="imageBlue">Pointer on blue channel of pixel data.</param>
        /// <param name="width">Length of an image line.</param>
        /// <param name="height">Number of image lines.</param>
        public void GetWindowPointer3(
          out int imageRed,
          out int imageGreen,
          out int imageBlue,
          out int width,
          out int height)
        {
            IntPtr proc = HalconAPI.PreCall(1182);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out imageRed);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out imageGreen);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out imageBlue);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out width);
            int procResult = HalconAPI.LoadI(proc, 4, err5, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Information about a window's size and position.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of upper left corner of the window.</param>
        /// <param name="column">Column index of upper left corner of the window.</param>
        /// <param name="width">Window width.</param>
        /// <param name="height">Window height.</param>
        public void GetWindowExtents(out int row, out int column, out int width, out int height)
        {
            IntPtr proc = HalconAPI.PreCall(1183);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out width);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write the window content in an image object.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Saved image.</returns>
        public HImage DumpWindowImage()
        {
            IntPtr proc = HalconAPI.PreCall(1184);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Write the window content to a file.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="device">Name of the target device or of the graphic format. Default: "postscript"</param>
        /// <param name="fileName">File name (without extension). Default: "halcon_dump"</param>
        public void DumpWindow(HTuple device, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1185);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, device);
            HalconAPI.StoreS(proc, 2, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(device);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write the window content to a file.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="device">Name of the target device or of the graphic format. Default: "postscript"</param>
        /// <param name="fileName">File name (without extension). Default: "halcon_dump"</param>
        public void DumpWindow(string device, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1185);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, device);
            HalconAPI.StoreS(proc, 2, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Copy all pixels within rectangles between output windows.
        ///   Instance represents: Source window handle.
        /// </summary>
        /// <param name="windowHandleDestination">Destination window handle.</param>
        /// <param name="row1">Row index of upper left corner in the source window. Default: 0</param>
        /// <param name="column1">Column index of upper left corner in the source window. Default: 0</param>
        /// <param name="row2">Row index of lower right corner in the source window. Default: 128</param>
        /// <param name="column2">Column index of lower right corner in the source window. Default: 128</param>
        /// <param name="destRow">Row index of upper left corner in the target window. Default: 0</param>
        /// <param name="destColumn">Column index of upper left corner in the target window. Default: 0</param>
        public void CopyRectangle(
          HWindow windowHandleDestination,
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          HTuple destRow,
          HTuple destColumn)
        {
            IntPtr proc = HalconAPI.PreCall(1186);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)windowHandleDestination);
            HalconAPI.Store(proc, 2, row1);
            HalconAPI.Store(proc, 3, column1);
            HalconAPI.Store(proc, 4, row2);
            HalconAPI.Store(proc, 5, column2);
            HalconAPI.Store(proc, 6, destRow);
            HalconAPI.Store(proc, 7, destColumn);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.UnpinTuple(destRow);
            HalconAPI.UnpinTuple(destColumn);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandleDestination);
        }

        /// <summary>
        ///   Copy all pixels within rectangles between output windows.
        ///   Instance represents: Source window handle.
        /// </summary>
        /// <param name="windowHandleDestination">Destination window handle.</param>
        /// <param name="row1">Row index of upper left corner in the source window. Default: 0</param>
        /// <param name="column1">Column index of upper left corner in the source window. Default: 0</param>
        /// <param name="row2">Row index of lower right corner in the source window. Default: 128</param>
        /// <param name="column2">Column index of lower right corner in the source window. Default: 128</param>
        /// <param name="destRow">Row index of upper left corner in the target window. Default: 0</param>
        /// <param name="destColumn">Column index of upper left corner in the target window. Default: 0</param>
        public void CopyRectangle(
          HWindow windowHandleDestination,
          int row1,
          int column1,
          int row2,
          int column2,
          int destRow,
          int destColumn)
        {
            IntPtr proc = HalconAPI.PreCall(1186);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)windowHandleDestination);
            HalconAPI.StoreI(proc, 2, row1);
            HalconAPI.StoreI(proc, 3, column1);
            HalconAPI.StoreI(proc, 4, row2);
            HalconAPI.StoreI(proc, 5, column2);
            HalconAPI.StoreI(proc, 6, destRow);
            HalconAPI.StoreI(proc, 7, destColumn);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandleDestination);
        }

        /// <summary>
        ///   Delete the contents of an output window.
        ///   Instance represents: Window handle.
        /// </summary>
        public void ClearWindow()
        {
            IntPtr proc = HalconAPI.PreCall(1188);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Delete a rectangle on the output window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Line index of upper left corner. Default: 10</param>
        /// <param name="column1">Column index of upper left corner. Default: 10</param>
        /// <param name="row2">Row index of lower right corner. Default: 118</param>
        /// <param name="column2">Column index of lower right corner. Default: 118</param>
        public void ClearRectangle(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1189);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Delete a rectangle on the output window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Line index of upper left corner. Default: 10</param>
        /// <param name="column1">Column index of upper left corner. Default: 10</param>
        /// <param name="row2">Row index of lower right corner. Default: 118</param>
        /// <param name="column2">Column index of lower right corner. Default: 118</param>
        public void ClearRectangle(int row1, int column1, int row2, int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1189);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row1);
            HalconAPI.StoreI(proc, 2, column1);
            HalconAPI.StoreI(proc, 3, row2);
            HalconAPI.StoreI(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Print text in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="stringVal">Tuple of output values (all types). Default: "hello"</param>
        public void WriteString(HTuple stringVal)
        {
            IntPtr proc = HalconAPI.PreCall(1190);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, stringVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(stringVal);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Print text in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="stringVal">Tuple of output values (all types). Default: "hello"</param>
        public void WriteString(string stringVal)
        {
            IntPtr proc = HalconAPI.PreCall(1190);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, stringVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the shape of the text cursor.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="textCursor">Name of cursor shape. Default: "invisible"</param>
        public void SetTshape(string textCursor)
        {
            IntPtr proc = HalconAPI.PreCall(1191);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, textCursor);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the position of the text cursor.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of text cursor position. Default: 24</param>
        /// <param name="column">Column index of text cursor position. Default: 12</param>
        public void SetTposition(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1192);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a string in a text window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="inString">Default string (visible before input). Default: ""</param>
        /// <param name="length">Maximum number of characters. Default: 32</param>
        /// <returns>Read string.</returns>
        public string ReadString(string inString, int length)
        {
            IntPtr proc = HalconAPI.PreCall(1193);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, inString);
            HalconAPI.StoreI(proc, 2, length);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Read a character from a text window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="code">Code for input character.</param>
        /// <returns>Input character (if it is not a control character).</returns>
        public string ReadChar(out string code)
        {
            IntPtr proc = HalconAPI.PreCall(1194);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadS(proc, 1, err2, out code);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Set the position of the text cursor to the beginning of the next line.
        ///   Instance represents: Window handle.
        /// </summary>
        public void NewLine()
        {
            IntPtr proc = HalconAPI.PreCall(1195);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the shape of the text cursor.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Name of the current text cursor.</returns>
        public string GetTshape()
        {
            IntPtr proc = HalconAPI.PreCall(1196);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Get cursor position.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of text cursor position.</param>
        /// <param name="column">Column index of text cursor position.</param>
        public void GetTposition(out int row, out int column)
        {
            IntPtr proc = HalconAPI.PreCall(1197);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the maximum size of all characters of a font.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="maxDescent">Maximum extension below baseline.</param>
        /// <param name="maxWidth">Maximum character width.</param>
        /// <param name="maxHeight">Maximum character height.</param>
        /// <returns>Maximum height above baseline.</returns>
        public HTuple GetFontExtents(
          out HTuple maxDescent,
          out HTuple maxWidth,
          out HTuple maxHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1198);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, err2, out maxDescent);
            int err4 = HTuple.LoadNew(proc, 2, err3, out maxWidth);
            int procResult = HTuple.LoadNew(proc, 3, err4, out maxHeight);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the maximum size of all characters of a font.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="maxDescent">Maximum extension below baseline.</param>
        /// <param name="maxWidth">Maximum character width.</param>
        /// <param name="maxHeight">Maximum character height.</param>
        /// <returns>Maximum height above baseline.</returns>
        public int GetFontExtents(out int maxDescent, out int maxWidth, out int maxHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1198);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out maxDescent);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out maxWidth);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out maxHeight);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Get the spatial size of a string.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="values">Values to consider. Default: "test_string"</param>
        /// <param name="descent">Maximum extension below baseline.</param>
        /// <param name="width">Text width.</param>
        /// <param name="height">Text height.</param>
        /// <returns>Maximum height above baseline.</returns>
        public HTuple GetStringExtents(
          HTuple values,
          out HTuple descent,
          out HTuple width,
          out HTuple height)
        {
            IntPtr proc = HalconAPI.PreCall(1199);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, values);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(values);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, err2, out descent);
            int err4 = HTuple.LoadNew(proc, 2, err3, out width);
            int procResult = HTuple.LoadNew(proc, 3, err4, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the spatial size of a string.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="values">Values to consider. Default: "test_string"</param>
        /// <param name="descent">Maximum extension below baseline.</param>
        /// <param name="width">Text width.</param>
        /// <param name="height">Text height.</param>
        /// <returns>Maximum height above baseline.</returns>
        public int GetStringExtents(string values, out int descent, out int width, out int height)
        {
            IntPtr proc = HalconAPI.PreCall(1199);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, values);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out descent);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out width);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out height);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Query the available fonts.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Tuple with available font names.</returns>
        public HTuple QueryFont()
        {
            IntPtr proc = HalconAPI.PreCall(1200);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query all shapes available for text cursors.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Names of the available text cursors.</returns>
        public HTuple QueryTshape()
        {
            IntPtr proc = HalconAPI.PreCall(1201);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set the font used for text output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="font">Name of new font.</param>
        public void SetFont(string font)
        {
            IntPtr proc = HalconAPI.PreCall(1202);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, font);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the current font.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Name of the current font.</returns>
        public string GetFont()
        {
            IntPtr proc = HalconAPI.PreCall(1203);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Get window parameters.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="param">Name of the parameter. Default: "flush"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetWindowParam(string param)
        {
            IntPtr proc = HalconAPI.PreCall(1221);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, param);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set window parameters.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="param">Name of the parameter. Default: "flush"</param>
        /// <param name="value">Value to be set. Default: "false"</param>
        public void SetWindowParam(string param, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(1222);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, param);
            HalconAPI.Store(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set window parameters.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="param">Name of the parameter. Default: "flush"</param>
        /// <param name="value">Value to be set. Default: "false"</param>
        public void SetWindowParam(string param, string value)
        {
            IntPtr proc = HalconAPI.PreCall(1222);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, param);
            HalconAPI.StoreS(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the region output shape.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="shape">Region output mode. Default: "original"</param>
        public void SetShape(string shape)
        {
            IntPtr proc = HalconAPI.PreCall(1223);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, shape);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the color definition via RGB values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">Red component of the color. Default: 255</param>
        /// <param name="green">Green component of the color. Default: 0</param>
        /// <param name="blue">Blue component of the color. Default: 0</param>
        public void SetRgb(HTuple red, HTuple green, HTuple blue)
        {
            IntPtr proc = HalconAPI.PreCall(1224);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, red);
            HalconAPI.Store(proc, 2, green);
            HalconAPI.Store(proc, 3, blue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(red);
            HalconAPI.UnpinTuple(green);
            HalconAPI.UnpinTuple(blue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the color definition via RGB values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">Red component of the color. Default: 255</param>
        /// <param name="green">Green component of the color. Default: 0</param>
        /// <param name="blue">Blue component of the color. Default: 0</param>
        public void SetRgb(int red, int green, int blue)
        {
            IntPtr proc = HalconAPI.PreCall(1224);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, red);
            HalconAPI.StoreI(proc, 2, green);
            HalconAPI.StoreI(proc, 3, blue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define a color lookup table index.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="pixel">Color lookup table index. Default: 128</param>
        public void SetPixel(HTuple pixel)
        {
            IntPtr proc = HalconAPI.PreCall(1225);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, pixel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(pixel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define a color lookup table index.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="pixel">Color lookup table index. Default: 128</param>
        public void SetPixel(int pixel)
        {
            IntPtr proc = HalconAPI.PreCall(1225);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, pixel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define an interpolation method for gray value output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="style">Interpolation method for image output: 0 (fast, low quality) to 2 (slow, high quality). Default: 0</param>
        public void SetPartStyle(int style)
        {
            IntPtr proc = HalconAPI.PreCall(1226);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, style);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Modify the displayed image part.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="column1">Column of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="row2">Row of the lower right corner of the chosen image part. Default: -1</param>
        /// <param name="column2">Column of the lower right corner of the chosen image part. Default: -1</param>
        public void SetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1227);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Modify the displayed image part.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="column1">Column of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="row2">Row of the lower right corner of the chosen image part. Default: -1</param>
        /// <param name="column2">Column of the lower right corner of the chosen image part. Default: -1</param>
        public void SetPart(int row1, int column1, int row2, int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1227);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row1);
            HalconAPI.StoreI(proc, 2, column1);
            HalconAPI.StoreI(proc, 3, row2);
            HalconAPI.StoreI(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the gray value output mode.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Output mode. Additional parameters possible. Default: "default"</param>
        public void SetPaint(HTuple mode)
        {
            IntPtr proc = HalconAPI.PreCall(1228);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(mode);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the line width for region contour output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="width">Line width for region output in contour mode. Default: 1.0</param>
        public void SetLineWidth(double width)
        {
            IntPtr proc = HalconAPI.PreCall(1229);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, width);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define a contour output pattern.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="style">Contour pattern. Default: []</param>
        public void SetLineStyle(HTuple style)
        {
            IntPtr proc = HalconAPI.PreCall(1230);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, style);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(style);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the approximation error for contour display.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="approximation">Maximum deviation from the original contour. Default: 0</param>
        public void SetLineApprox(int approximation)
        {
            IntPtr proc = HalconAPI.PreCall(1231);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, approximation);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the pixel output function.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Name of the display function. Default: "copy"</param>
        public void SetInsert(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1232);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define output colors (HSI-coded).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="hue">Hue for region output. Default: 30</param>
        /// <param name="saturation">Saturation for region output. Default: 255</param>
        /// <param name="intensity">Intensity for region output. Default: 84</param>
        public void SetHsi(HTuple hue, HTuple saturation, HTuple intensity)
        {
            IntPtr proc = HalconAPI.PreCall(1233);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, hue);
            HalconAPI.Store(proc, 2, saturation);
            HalconAPI.Store(proc, 3, intensity);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(hue);
            HalconAPI.UnpinTuple(saturation);
            HalconAPI.UnpinTuple(intensity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define output colors (HSI-coded).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="hue">Hue for region output. Default: 30</param>
        /// <param name="saturation">Saturation for region output. Default: 255</param>
        /// <param name="intensity">Intensity for region output. Default: 84</param>
        public void SetHsi(int hue, int saturation, int intensity)
        {
            IntPtr proc = HalconAPI.PreCall(1233);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, hue);
            HalconAPI.StoreI(proc, 2, saturation);
            HalconAPI.StoreI(proc, 3, intensity);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define gray values for region output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="grayValues">Gray values for region output. Default: 255</param>
        public void SetGray(HTuple grayValues)
        {
            IntPtr proc = HalconAPI.PreCall(1234);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, grayValues);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(grayValues);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define gray values for region output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="grayValues">Gray values for region output. Default: 255</param>
        public void SetGray(int grayValues)
        {
            IntPtr proc = HalconAPI.PreCall(1234);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, grayValues);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the region fill mode.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Fill mode for region output. Default: "fill"</param>
        public void SetDraw(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1235);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define the image matrix output clipping.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Clipping mode for gray value output. Default: "object"</param>
        public void SetComprise(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1236);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set multiple output colors.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="numberOfColors">Number of output colors. Default: 12</param>
        public void SetColored(int numberOfColors)
        {
            IntPtr proc = HalconAPI.PreCall(1237);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, numberOfColors);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set output color.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="color">Output color names. Default: "white"</param>
        public void SetColor(HTuple color)
        {
            IntPtr proc = HalconAPI.PreCall(1238);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, color);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(color);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set output color.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="color">Output color names. Default: "white"</param>
        public void SetColor(string color)
        {
            IntPtr proc = HalconAPI.PreCall(1238);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, color);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the current region output shape.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Current region output shape.</returns>
        public string GetShape()
        {
            IntPtr proc = HalconAPI.PreCall(1239);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Get the current color in RGB-coding.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">The current color's red value.</param>
        /// <param name="green">The current color's green value.</param>
        /// <param name="blue">The current color's blue value.</param>
        public void GetRgb(out HTuple red, out HTuple green, out HTuple blue)
        {
            IntPtr proc = HalconAPI.PreCall(1240);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out red);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out green);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out blue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the current color lookup table index.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Index of the current color look-up table.</returns>
        public HTuple GetPixel()
        {
            IntPtr proc = HalconAPI.PreCall(1241);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the current interpolation mode for gray value display.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Interpolation mode for image display: 0 (fast, low quality) to 2 (slow, high quality).</returns>
        public int GetPartStyle()
        {
            IntPtr proc = HalconAPI.PreCall(1242);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Get the image part.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the image part's upper left corner.</param>
        /// <param name="column1">Column index of the image part's upper left corner.</param>
        /// <param name="row2">Row index of the image part's lower right corner.</param>
        /// <param name="column2">Column index of the image part's lower right corner.</param>
        public void GetPart(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1243);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, err3, out row2);
            int procResult = HTuple.LoadNew(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the image part.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the image part's upper left corner.</param>
        /// <param name="column1">Column index of the image part's upper left corner.</param>
        /// <param name="row2">Row index of the image part's lower right corner.</param>
        /// <param name="column2">Column index of the image part's lower right corner.</param>
        public void GetPart(out int row1, out int column1, out int row2, out int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1243);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the current display mode for gray values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Name and parameter values of the current display mode.</returns>
        public HTuple GetPaint()
        {
            IntPtr proc = HalconAPI.PreCall(1244);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the current line width for contour display.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Current line width for contour display.</returns>
        public double GetLineWidth()
        {
            IntPtr proc = HalconAPI.PreCall(1245);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Get the current graphic mode for contours.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Template for contour display.</returns>
        public HTuple GetLineStyle()
        {
            IntPtr proc = HalconAPI.PreCall(1246);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the current approximation error for contour display.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Current approximation error for contour display.</returns>
        public int GetLineApprox()
        {
            IntPtr proc = HalconAPI.PreCall(1247);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Get the current display mode.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Display mode.</returns>
        public string GetInsert()
        {
            IntPtr proc = HalconAPI.PreCall(1248);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Get the HSI coding of the current color.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="saturation">Saturation of the current color.</param>
        /// <param name="intensity">Intensity of the current color.</param>
        /// <returns>Hue (color value) of the current color.</returns>
        public HTuple GetHsi(out HTuple saturation, out HTuple intensity)
        {
            IntPtr proc = HalconAPI.PreCall(1249);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out saturation);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out intensity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the current region fill mode.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Current region fill mode.</returns>
        public string GetDraw()
        {
            IntPtr proc = HalconAPI.PreCall(1250);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Query the gray value display modes.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Gray value display mode names.</returns>
        public HTuple QueryPaint()
        {
            IntPtr proc = HalconAPI.PreCall(1253);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query the possible graphic modes.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Display function name.</returns>
        public HTuple QueryInsert()
        {
            IntPtr proc = HalconAPI.PreCall(1255);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query the displayable gray values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Tuple of all displayable gray values.</returns>
        public HTuple QueryGray()
        {
            IntPtr proc = HalconAPI.PreCall(1256);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query all color names.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Color names.</returns>
        public HTuple QueryAllColors()
        {
            IntPtr proc = HalconAPI.PreCall(1258);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query all color names displayable in the window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Color names.</returns>
        public HTuple QueryColor()
        {
            IntPtr proc = HalconAPI.PreCall(1259);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query the icon for region output
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Icon for the regions center of gravity.</returns>
        public HRegion GetIcon()
        {
            IntPtr proc = HalconAPI.PreCall(1260);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Icon definition for region output.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="icon">Icon for center of gravity.</param>
        public void SetIcon(HRegion icon)
        {
            IntPtr proc = HalconAPI.PreCall(1261);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)icon);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)icon);
        }

        /// <summary>
        ///   Displays regions in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="dispRegions">Regions to display.</param>
        public void DispRegion(HRegion dispRegions)
        {
            IntPtr proc = HalconAPI.PreCall(1262);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)dispRegions);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)dispRegions);
        }

        /// <summary>
        ///   Displays arbitrarily oriented rectangles.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row index of the center. Default: 48</param>
        /// <param name="centerCol">Column index of the center. Default: 64</param>
        /// <param name="phi">Orientation of rectangle in radians. Default: 0.0</param>
        /// <param name="length1">Half of the length of the longer side. Default: 48</param>
        /// <param name="length2">Half of the length of the shorter side. Default: 32</param>
        public void DispRectangle2(
          HTuple centerRow,
          HTuple centerCol,
          HTuple phi,
          HTuple length1,
          HTuple length2)
        {
            IntPtr proc = HalconAPI.PreCall(1263);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, centerRow);
            HalconAPI.Store(proc, 2, centerCol);
            HalconAPI.Store(proc, 3, phi);
            HalconAPI.Store(proc, 4, length1);
            HalconAPI.Store(proc, 5, length2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays arbitrarily oriented rectangles.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row index of the center. Default: 48</param>
        /// <param name="centerCol">Column index of the center. Default: 64</param>
        /// <param name="phi">Orientation of rectangle in radians. Default: 0.0</param>
        /// <param name="length1">Half of the length of the longer side. Default: 48</param>
        /// <param name="length2">Half of the length of the shorter side. Default: 32</param>
        public void DispRectangle2(
          double centerRow,
          double centerCol,
          double phi,
          double length1,
          double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1263);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, centerRow);
            HalconAPI.StoreD(proc, 2, centerCol);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, length1);
            HalconAPI.StoreD(proc, 5, length2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display of rectangles aligned to the coordinate axes.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the upper left corner. Default: 16</param>
        /// <param name="column1">Column index of the upper left corner. Default: 16</param>
        /// <param name="row2">Row index of the lower right corner. Default: 48</param>
        /// <param name="column2">Column index of the lower right corner. Default: 80</param>
        public void DispRectangle1(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1264);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display of rectangles aligned to the coordinate axes.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the upper left corner. Default: 16</param>
        /// <param name="column1">Column index of the upper left corner. Default: 16</param>
        /// <param name="row2">Row index of the lower right corner. Default: 48</param>
        /// <param name="column2">Column index of the lower right corner. Default: 80</param>
        public void DispRectangle1(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1264);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row1);
            HalconAPI.StoreD(proc, 2, column1);
            HalconAPI.StoreD(proc, 3, row2);
            HalconAPI.StoreD(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays a polyline.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index Default: [16,80,80]</param>
        /// <param name="column">Column index Default: [48,16,80]</param>
        public void DispPolygon(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1265);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draws lines in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the start. Default: 32.0</param>
        /// <param name="column1">Column index of the start. Default: 32.0</param>
        /// <param name="row2">Row index of end. Default: 64.0</param>
        /// <param name="column2">Column index of end. Default: 64.0</param>
        public void DispLine(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1266);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draws lines in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the start. Default: 32.0</param>
        /// <param name="column1">Column index of the start. Default: 32.0</param>
        /// <param name="row2">Row index of end. Default: 64.0</param>
        /// <param name="column2">Column index of end. Default: 64.0</param>
        public void DispLine(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1266);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row1);
            HalconAPI.StoreD(proc, 2, column1);
            HalconAPI.StoreD(proc, 3, row2);
            HalconAPI.StoreD(proc, 4, column2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays crosses in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 32.0</param>
        /// <param name="column">Column coordinate of the center. Default: 32.0</param>
        /// <param name="size">Length of the bars. Default: 6.0</param>
        /// <param name="angle">Orientation. Default: 0.0</param>
        public void DispCross(HTuple row, HTuple column, double size, double angle)
        {
            IntPtr proc = HalconAPI.PreCall(1267);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreD(proc, 3, size);
            HalconAPI.StoreD(proc, 4, angle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays crosses in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center. Default: 32.0</param>
        /// <param name="column">Column coordinate of the center. Default: 32.0</param>
        /// <param name="size">Length of the bars. Default: 6.0</param>
        /// <param name="angle">Orientation. Default: 0.0</param>
        public void DispCross(double row, double column, double size, double angle)
        {
            IntPtr proc = HalconAPI.PreCall(1267);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, size);
            HalconAPI.StoreD(proc, 4, angle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays gray value images.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="image">Gray value image to display.</param>
        public void DispImage(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1268);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Displays images with several channels.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="multichannelImage">Multichannel images to be displayed.</param>
        /// <param name="channel">Number of channel or the numbers of the RGB-channels Default: 1</param>
        public void DispChannel(HImage multichannelImage, HTuple channel)
        {
            IntPtr proc = HalconAPI.PreCall(1269);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)multichannelImage);
            HalconAPI.Store(proc, 1, channel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(channel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)multichannelImage);
        }

        /// <summary>
        ///   Displays images with several channels.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="multichannelImage">Multichannel images to be displayed.</param>
        /// <param name="channel">Number of channel or the numbers of the RGB-channels Default: 1</param>
        public void DispChannel(HImage multichannelImage, int channel)
        {
            IntPtr proc = HalconAPI.PreCall(1269);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)multichannelImage);
            HalconAPI.StoreI(proc, 1, channel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)multichannelImage);
        }

        /// <summary>
        ///   Displays a color (RGB) image
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="colorImage">Color image to display.</param>
        public void DispColor(HImage colorImage)
        {
            IntPtr proc = HalconAPI.PreCall(1270);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)colorImage);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)colorImage);
        }

        /// <summary>
        ///   Displays ellipses.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row index of center. Default: 64</param>
        /// <param name="centerCol">Column index of center. Default: 64</param>
        /// <param name="phi">Orientation of the ellipse in radians Default: 0.0</param>
        /// <param name="radius1">Radius of major axis. Default: 24.0</param>
        /// <param name="radius2">Radius of minor axis. Default: 14.0</param>
        public void DispEllipse(
          HTuple centerRow,
          HTuple centerCol,
          HTuple phi,
          HTuple radius1,
          HTuple radius2)
        {
            IntPtr proc = HalconAPI.PreCall(1271);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, centerRow);
            HalconAPI.Store(proc, 2, centerCol);
            HalconAPI.Store(proc, 3, phi);
            HalconAPI.Store(proc, 4, radius1);
            HalconAPI.Store(proc, 5, radius2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays ellipses.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row index of center. Default: 64</param>
        /// <param name="centerCol">Column index of center. Default: 64</param>
        /// <param name="phi">Orientation of the ellipse in radians Default: 0.0</param>
        /// <param name="radius1">Radius of major axis. Default: 24.0</param>
        /// <param name="radius2">Radius of minor axis. Default: 14.0</param>
        public void DispEllipse(
          int centerRow,
          int centerCol,
          double phi,
          double radius1,
          double radius2)
        {
            IntPtr proc = HalconAPI.PreCall(1271);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, centerRow);
            HalconAPI.StoreI(proc, 2, centerCol);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, radius1);
            HalconAPI.StoreD(proc, 5, radius2);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays a noise distribution.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="distribution">Gray value distribution (513 values).</param>
        /// <param name="row">Row index of center. Default: 256</param>
        /// <param name="column">Column index of center. Default: 256</param>
        /// <param name="scale">Size of display. Default: 1</param>
        public void DispDistribution(HTuple distribution, int row, int column, int scale)
        {
            IntPtr proc = HalconAPI.PreCall(1272);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, distribution);
            HalconAPI.StoreI(proc, 2, row);
            HalconAPI.StoreI(proc, 3, column);
            HalconAPI.StoreI(proc, 4, scale);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(distribution);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays circles in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of the center. Default: 64</param>
        /// <param name="column">Column index of the center. Default: 64</param>
        /// <param name="radius">Radius of the circle. Default: 64</param>
        public void DispCircle(HTuple row, HTuple column, HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1273);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, radius);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays circles in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of the center. Default: 64</param>
        /// <param name="column">Column index of the center. Default: 64</param>
        /// <param name="radius">Radius of the circle. Default: 64</param>
        public void DispCircle(double row, double column, double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1273);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, radius);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays arrows in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the start. Default: 10.0</param>
        /// <param name="column1">Column index of the start. Default: 10.0</param>
        /// <param name="row2">Row index of the end. Default: 118.0</param>
        /// <param name="column2">Column index of the end. Default: 118.0</param>
        /// <param name="size">Size of the arrowhead. Default: 1.0</param>
        public void DispArrow(HTuple row1, HTuple column1, HTuple row2, HTuple column2, HTuple size)
        {
            IntPtr proc = HalconAPI.PreCall(1274);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row1);
            HalconAPI.Store(proc, 2, column1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            HalconAPI.Store(proc, 5, size);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.UnpinTuple(size);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays arrows in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the start. Default: 10.0</param>
        /// <param name="column1">Column index of the start. Default: 10.0</param>
        /// <param name="row2">Row index of the end. Default: 118.0</param>
        /// <param name="column2">Column index of the end. Default: 118.0</param>
        /// <param name="size">Size of the arrowhead. Default: 1.0</param>
        public void DispArrow(double row1, double column1, double row2, double column2, double size)
        {
            IntPtr proc = HalconAPI.PreCall(1274);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row1);
            HalconAPI.StoreD(proc, 2, column1);
            HalconAPI.StoreD(proc, 3, row2);
            HalconAPI.StoreD(proc, 4, column2);
            HalconAPI.StoreD(proc, 5, size);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays circular arcs in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of center point. Default: 64</param>
        /// <param name="centerCol">Column coordinate of center point. Default: 64</param>
        /// <param name="angle">Angle between start and end of the arc (in radians). Default: 3.1415926</param>
        /// <param name="beginRow">Row coordinate of the start of the arc. Default: 32</param>
        /// <param name="beginCol">Column coordinate of the start of the arc. Default: 32</param>
        public void DispArc(
          HTuple centerRow,
          HTuple centerCol,
          HTuple angle,
          HTuple beginRow,
          HTuple beginCol)
        {
            IntPtr proc = HalconAPI.PreCall(1275);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, centerRow);
            HalconAPI.Store(proc, 2, centerCol);
            HalconAPI.Store(proc, 3, angle);
            HalconAPI.Store(proc, 4, beginRow);
            HalconAPI.Store(proc, 5, beginCol);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(angle);
            HalconAPI.UnpinTuple(beginRow);
            HalconAPI.UnpinTuple(beginCol);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays circular arcs in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of center point. Default: 64</param>
        /// <param name="centerCol">Column coordinate of center point. Default: 64</param>
        /// <param name="angle">Angle between start and end of the arc (in radians). Default: 3.1415926</param>
        /// <param name="beginRow">Row coordinate of the start of the arc. Default: 32</param>
        /// <param name="beginCol">Column coordinate of the start of the arc. Default: 32</param>
        public void DispArc(
          double centerRow,
          double centerCol,
          double angle,
          int beginRow,
          int beginCol)
        {
            IntPtr proc = HalconAPI.PreCall(1275);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, centerRow);
            HalconAPI.StoreD(proc, 2, centerCol);
            HalconAPI.StoreD(proc, 3, angle);
            HalconAPI.StoreI(proc, 4, beginRow);
            HalconAPI.StoreI(proc, 5, beginCol);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays image objects (image, region, XLD).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="objectVal">Image object to be displayed.</param>
        public void DispObj(HObject objectVal)
        {
            IntPtr proc = HalconAPI.PreCall(1276);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)objectVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectVal);
        }

        /// <summary>
        ///   Set the current mouse pointer shape.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="cursor">Mouse pointer name. Default: "arrow"</param>
        public void SetMshape(string cursor)
        {
            IntPtr proc = HalconAPI.PreCall(1277);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, cursor);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query the current mouse pointer shape.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Mouse pointer name.</returns>
        public string GetMshape()
        {
            IntPtr proc = HalconAPI.PreCall(1278);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Query all available mouse pointer shapes.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Available mouse pointer names.</returns>
        public HTuple QueryMshape()
        {
            IntPtr proc = HalconAPI.PreCall(1279);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query the subpixel mouse position.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse position in the window.</param>
        /// <param name="column">Column coordinate of the mouse position in the window.</param>
        /// <param name="button">Mouse button(s) pressed or 0.</param>
        public void GetMpositionSubPix(out double row, out double column, out int button)
        {
            IntPtr proc = HalconAPI.PreCall(1280);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out button);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query the mouse position.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse position in the window.</param>
        /// <param name="column">Column coordinate of the mouse position in the window.</param>
        /// <param name="button">Mouse button(s) pressed or 0.</param>
        public void GetMposition(out int row, out int column, out int button)
        {
            IntPtr proc = HalconAPI.PreCall(1281);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out button);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Wait until a mouse button is pressed and get the subpixel mouse position.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse position in the window.</param>
        /// <param name="column">Column coordinate of the mouse position in the window.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        public void GetMbuttonSubPix(out double row, out double column, out int button)
        {
            IntPtr proc = HalconAPI.PreCall(1282);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out button);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Wait until a mouse button is pressed.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse position in the window.</param>
        /// <param name="column">Column coordinate of the mouse position in the window.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        public void GetMbutton(out int row, out int column, out int button)
        {
            IntPtr proc = HalconAPI.PreCall(1283);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out button);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write look-up-table (lut) as file.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="fileName">File name (of file containing the look-up-table). Default: "/tmp/lut"</param>
        public void WriteLut(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1284);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Graphical view of the look-up-table (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row of centre of the graphic. Default: 128</param>
        /// <param name="column">Column of centre of the graphic. Default: 128</param>
        /// <param name="scale">Scaling of the graphic. Default: 1</param>
        public void DispLut(int row, int column, int scale)
        {
            IntPtr proc = HalconAPI.PreCall(1285);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, scale);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query all available look-up-tables (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Names of look-up-tables.</returns>
        public HTuple QueryLut()
        {
            IntPtr proc = HalconAPI.PreCall(1286);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get modification parameters of look-up-table (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="saturation">Modification of saturation.</param>
        /// <param name="intensity">Modification of intensity.</param>
        /// <returns>Modification of color value.</returns>
        public double GetLutStyle(out double saturation, out double intensity)
        {
            IntPtr proc = HalconAPI.PreCall(1287);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out saturation);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out intensity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Changing the look-up-table (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="hue">Modification of color value. Default: 0.0</param>
        /// <param name="saturation">Modification of saturation. Default: 1.5</param>
        /// <param name="intensity">Modification of intensity. Default: 1.5</param>
        public void SetLutStyle(double hue, double saturation, double intensity)
        {
            IntPtr proc = HalconAPI.PreCall(1288);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, hue);
            HalconAPI.StoreD(proc, 2, saturation);
            HalconAPI.StoreD(proc, 3, intensity);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get current look-up-table (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Name of look-up-table or tuple of RGB-values.</returns>
        public HTuple GetLut()
        {
            IntPtr proc = HalconAPI.PreCall(1289);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set "`look-up-table"' (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="lookUpTable">Name of look-up-table, values of look-up-table (RGB) or file name. Default: "default"</param>
        public void SetLut(HTuple lookUpTable)
        {
            IntPtr proc = HalconAPI.PreCall(1290);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, lookUpTable);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(lookUpTable);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set "`look-up-table"' (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="lookUpTable">Name of look-up-table, values of look-up-table (RGB) or file name. Default: "default"</param>
        public void SetLut(string lookUpTable)
        {
            IntPtr proc = HalconAPI.PreCall(1290);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, lookUpTable);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get mode of fixing of current look-up-table (lut).
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Current Mode of fixing.</returns>
        public string GetFix()
        {
            IntPtr proc = HalconAPI.PreCall(1291);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Set fixing of "`look-up-table"' (lut)
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Mode of fixing. Default: "true"</param>
        public void SetFix(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1292);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get fixing of "`look-up-table"' (lut) for "`real color images"'
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Mode of fixing.</returns>
        public string GetFixedLut()
        {
            IntPtr proc = HalconAPI.PreCall(1293);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Fix "`look-up-table"' (lut) for "`real color images"'.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="mode">Mode of fixing. Default: "true"</param>
        public void SetFixedLut(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1294);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive movement of a region with restriction of positions.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="sourceRegion">Regions to move.</param>
        /// <param name="maskRegion">Points on which it is allowed for a region to move.</param>
        /// <param name="row">Row index of the reference point. Default: 100</param>
        /// <param name="column">Column index of the reference point. Default: 100</param>
        /// <returns>Moved regions.</returns>
        public HRegion DragRegion3(
          HRegion sourceRegion,
          HRegion maskRegion,
          int row,
          int column)
        {
            IntPtr proc = HalconAPI.PreCall(1315);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sourceRegion);
            HalconAPI.Store(proc, 2, (HObjectBase)maskRegion);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sourceRegion);
            GC.KeepAlive((object)maskRegion);
            return hregion;
        }

        /// <summary>
        ///   Interactive movement of a region with fixpoint specification.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="sourceRegion">Regions to move.</param>
        /// <param name="row">Row index of the reference point. Default: 100</param>
        /// <param name="column">Column index of the reference point. Default: 100</param>
        /// <returns>Moved regions.</returns>
        public HRegion DragRegion2(HRegion sourceRegion, int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1316);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sourceRegion);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sourceRegion);
            return hregion;
        }

        /// <summary>
        ///   Interactive moving of a region.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="sourceRegion">Regions to move.</param>
        /// <returns>Moved Regions.</returns>
        public HRegion DragRegion1(HRegion sourceRegion)
        {
            IntPtr proc = HalconAPI.PreCall(1317);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sourceRegion);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sourceRegion);
            return hregion;
        }

        /// <summary>
        ///   Interactive modification of a NURBS curve using interpolation.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 5. Default: 3</param>
        /// <param name="rowsIn">Row coordinates of the input interpolation points.</param>
        /// <param name="colsIn">Column coordinates of the input interpolation points.</param>
        /// <param name="tangentsIn">Input tangents.</param>
        /// <param name="controlRows">Row coordinates of the control polygon.</param>
        /// <param name="controlCols">Column coordinates of the control polygon.</param>
        /// <param name="knots">Knot vector.</param>
        /// <param name="rows">Row coordinates of the points specified by the user.</param>
        /// <param name="cols">Column coordinates of the points specified by the user.</param>
        /// <param name="tangents">Tangents specified by the user.</param>
        /// <returns>Contour of the modified curve.</returns>
        public HXLDCont DrawNurbsInterpMod(
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit,
          int degree,
          HTuple rowsIn,
          HTuple colsIn,
          HTuple tangentsIn,
          out HTuple controlRows,
          out HTuple controlCols,
          out HTuple knots,
          out HTuple rows,
          out HTuple cols,
          out HTuple tangents)
        {
            IntPtr proc = HalconAPI.PreCall(1318);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.StoreI(proc, 6, degree);
            HalconAPI.Store(proc, 7, rowsIn);
            HalconAPI.Store(proc, 8, colsIn);
            HalconAPI.Store(proc, 9, tangentsIn);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowsIn);
            HalconAPI.UnpinTuple(colsIn);
            HalconAPI.UnpinTuple(tangentsIn);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out controlRows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out controlCols);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out knots);
            int err6 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out rows);
            int err7 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err6, out cols);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err7, out tangents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive drawing of a NURBS curve using interpolation.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 5. Default: 3</param>
        /// <param name="controlRows">Row coordinates of the control polygon.</param>
        /// <param name="controlCols">Column coordinates of the control polygon.</param>
        /// <param name="knots">Knot vector.</param>
        /// <param name="rows">Row coordinates of the points specified by the user.</param>
        /// <param name="cols">Column coordinates of the points specified by the user.</param>
        /// <param name="tangents">Tangents specified by the user.</param>
        /// <returns>Contour of the curve.</returns>
        public HXLDCont DrawNurbsInterp(
          string rotate,
          string move,
          string scale,
          string keepRatio,
          int degree,
          out HTuple controlRows,
          out HTuple controlCols,
          out HTuple knots,
          out HTuple rows,
          out HTuple cols,
          out HTuple tangents)
        {
            IntPtr proc = HalconAPI.PreCall(1319);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreI(proc, 5, degree);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out controlRows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out controlCols);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out knots);
            int err6 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out rows);
            int err7 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err6, out cols);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err7, out tangents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive modification of a NURBS curve.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 25. Default: 3</param>
        /// <param name="rowsIn">Row coordinates of the input control polygon.</param>
        /// <param name="colsIn">Column coordinates of the input control polygon.</param>
        /// <param name="weightsIn">Input weight vector.</param>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Columns coordinates of the control polygon.</param>
        /// <param name="weights">Weight vector.</param>
        /// <returns>Contour of the modified curve.</returns>
        public HXLDCont DrawNurbsMod(
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit,
          int degree,
          HTuple rowsIn,
          HTuple colsIn,
          HTuple weightsIn,
          out HTuple rows,
          out HTuple cols,
          out HTuple weights)
        {
            IntPtr proc = HalconAPI.PreCall(1320);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.StoreI(proc, 6, degree);
            HalconAPI.Store(proc, 7, rowsIn);
            HalconAPI.Store(proc, 8, colsIn);
            HalconAPI.Store(proc, 9, weightsIn);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowsIn);
            HalconAPI.UnpinTuple(colsIn);
            HalconAPI.UnpinTuple(weightsIn);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out cols);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out weights);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive drawing of a NURBS curve.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 25. Default: 3</param>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Columns coordinates of the control polygon.</param>
        /// <param name="weights">Weight vector.</param>
        /// <returns>Contour approximating the NURBS curve.</returns>
        public HXLDCont DrawNurbs(
          string rotate,
          string move,
          string scale,
          string keepRatio,
          int degree,
          out HTuple rows,
          out HTuple cols,
          out HTuple weights)
        {
            IntPtr proc = HalconAPI.PreCall(1321);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreI(proc, 5, degree);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out cols);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out weights);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive modification of a contour.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="contIn">Input contour.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <returns>Modified contour.</returns>
        public HXLDCont DrawXldMod(
          HXLDCont contIn,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit)
        {
            IntPtr proc = HalconAPI.PreCall(1322);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contIn);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contIn);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive drawing of a contour.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <returns>Modified contour.</returns>
        public HXLDCont DrawXld(string rotate, string move, string scale, string keepRatio)
        {
            IntPtr proc = HalconAPI.PreCall(1323);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive drawing of any orientated rectangle.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowIn">Row index of the center.</param>
        /// <param name="columnIn">Column index of the center.</param>
        /// <param name="phiIn">Orientation of the bigger half axis in radians.</param>
        /// <param name="length1In">Bigger half axis.</param>
        /// <param name="length2In">Smaller half axis.</param>
        /// <param name="row">Row index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the bigger half axis in radians.</param>
        /// <param name="length1">Bigger half axis.</param>
        /// <param name="length2">Smaller half axis.</param>
        public void DrawRectangle2Mod(
          double rowIn,
          double columnIn,
          double phiIn,
          double length1In,
          double length2In,
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1324);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowIn);
            HalconAPI.StoreD(proc, 2, columnIn);
            HalconAPI.StoreD(proc, 3, phiIn);
            HalconAPI.StoreD(proc, 4, length1In);
            HalconAPI.StoreD(proc, 5, length2In);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out length1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of any orientated rectangle.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the bigger half axis in radians.</param>
        /// <param name="length1">Bigger half axis.</param>
        /// <param name="length2">Smaller half axis.</param>
        public void DrawRectangle2(
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1325);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out length1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a rectangle parallel to the coordinate axis.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1In">Row index of the left upper corner.</param>
        /// <param name="column1In">Column index of the left upper corner.</param>
        /// <param name="row2In">Row index of the right lower corner.</param>
        /// <param name="column2In">Column index of the right lower corner.</param>
        /// <param name="row1">Row index of the left upper corner.</param>
        /// <param name="column1">Column index of the left upper corner.</param>
        /// <param name="row2">Row index of the right lower corner.</param>
        /// <param name="column2">Column index of the right lower corner.</param>
        public void DrawRectangle1Mod(
          double row1In,
          double column1In,
          double row2In,
          double column2In,
          out double row1,
          out double column1,
          out double row2,
          out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1326);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row1In);
            HalconAPI.StoreD(proc, 2, column1In);
            HalconAPI.StoreD(proc, 3, row2In);
            HalconAPI.StoreD(proc, 4, column2In);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a rectangle parallel to the coordinate axis.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the left upper corner.</param>
        /// <param name="column1">Column index of the left upper corner.</param>
        /// <param name="row2">Row index of the right lower corner.</param>
        /// <param name="column2">Column index of the right lower corner.</param>
        public void DrawRectangle1(
          out double row1,
          out double column1,
          out double row2,
          out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1327);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a point.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowIn">Row index of the point.</param>
        /// <param name="columnIn">Column index of the point.</param>
        /// <param name="row">Row index of the point.</param>
        /// <param name="column">Column index of the point.</param>
        public void DrawPointMod(double rowIn, double columnIn, out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(1328);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowIn);
            HalconAPI.StoreD(proc, 2, columnIn);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a point.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of the point.</param>
        /// <param name="column">Column index of the point.</param>
        public void DrawPoint(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(1329);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a line.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1In">Row index of the first point of the line.</param>
        /// <param name="column1In">Column index of the first point of the line.</param>
        /// <param name="row2In">Row index of the second point of the line.</param>
        /// <param name="column2In">Column index of the second point of the line.</param>
        /// <param name="row1">Row index of the first point of the line.</param>
        /// <param name="column1">Column index of the first point of the line.</param>
        /// <param name="row2">Row index of the second point of the line.</param>
        /// <param name="column2">Column index of the second point of the line.</param>
        public void DrawLineMod(
          double row1In,
          double column1In,
          double row2In,
          double column2In,
          out double row1,
          out double column1,
          out double row2,
          out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1330);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row1In);
            HalconAPI.StoreD(proc, 2, column1In);
            HalconAPI.StoreD(proc, 3, row2In);
            HalconAPI.StoreD(proc, 4, column2In);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Draw a line.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row1">Row index of the first point of the line.</param>
        /// <param name="column1">Column index of the first point of the line.</param>
        /// <param name="row2">Row index of the second point of the line.</param>
        /// <param name="column2">Column index of the second point of the line.</param>
        public void DrawLine(out double row1, out double column1, out double row2, out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1331);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of an ellipse.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowIn">Row index of the center.</param>
        /// <param name="columnIn">Column index of the center.</param>
        /// <param name="phiIn">Orientation of the bigger half axis in radians.</param>
        /// <param name="radius1In">Bigger half axis.</param>
        /// <param name="radius2In">Smaller half axis.</param>
        /// <param name="row">Row index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the first half axis in radians.</param>
        /// <param name="radius1">First half axis.</param>
        /// <param name="radius2">Second half axis.</param>
        public void DrawEllipseMod(
          double rowIn,
          double columnIn,
          double phiIn,
          double radius1In,
          double radius2In,
          out double row,
          out double column,
          out double phi,
          out double radius1,
          out double radius2)
        {
            IntPtr proc = HalconAPI.PreCall(1332);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowIn);
            HalconAPI.StoreD(proc, 2, columnIn);
            HalconAPI.StoreD(proc, 3, phiIn);
            HalconAPI.StoreD(proc, 4, radius1In);
            HalconAPI.StoreD(proc, 5, radius2In);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out radius1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out radius2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of an ellipse.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Row index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the first half axis in radians.</param>
        /// <param name="radius1">First half axis.</param>
        /// <param name="radius2">Second half axis.</param>
        public void DrawEllipse(
          out double row,
          out double column,
          out double phi,
          out double radius1,
          out double radius2)
        {
            IntPtr proc = HalconAPI.PreCall(1333);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out radius1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out radius2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of a circle.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowIn">Row index of the center.</param>
        /// <param name="columnIn">Column index of the center.</param>
        /// <param name="radiusIn">Radius of the circle.</param>
        /// <param name="row">Row index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="radius">Circle's radius.</param>
        public void DrawCircleMod(
          double rowIn,
          double columnIn,
          double radiusIn,
          out double row,
          out double column,
          out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1334);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowIn);
            HalconAPI.StoreD(proc, 2, columnIn);
            HalconAPI.StoreD(proc, 3, radiusIn);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of a circle.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="row">Barycenter's row index.</param>
        /// <param name="column">Barycenter's column index.</param>
        /// <param name="radius">Circle's radius.</param>
        public void DrawCircle(out double row, out double column, out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1335);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interactive drawing of a closed region.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Interactive created region.</returns>
        public HRegion DrawRegion()
        {
            IntPtr proc = HalconAPI.PreCall(1336);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Interactive drawing of a polygon row.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <returns>Region, which encompasses all painted points.</returns>
        public HRegion DrawPolygon()
        {
            IntPtr proc = HalconAPI.PreCall(1337);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Project and visualize the 3D model of the calibration plate in the image.
        ///   Instance represents: Window in which the calibration plate should be visualized.
        /// </summary>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="calPlatePose">External camera parameters (3D pose of the calibration plate in camera coordinates).</param>
        /// <param name="scaleFac">Scaling factor for the visualization. Default: 1.0</param>
        public void DispCaltab(
          string calPlateDescr,
          HCamPar cameraParam,
          HPose calPlatePose,
          double scaleFac)
        {
            IntPtr proc = HalconAPI.PreCall(1945);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, calPlateDescr);
            HalconAPI.Store(proc, 2, (HData)cameraParam);
            HalconAPI.Store(proc, 3, (HData)calPlatePose);
            HalconAPI.StoreD(proc, 4, scaleFac);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple((HTuple)((HData)calPlatePose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert image coordinates to window coordinates
        ///   Instance represents: Window handle
        /// </summary>
        /// <param name="rowImage">Row in image coordinates.</param>
        /// <param name="columnImage">Column in image coordinates.</param>
        /// <param name="rowWindow">Row (Y) in window coordinates.</param>
        /// <param name="columnWindow">Column (X) in window coordinates.</param>
        public void ConvertCoordinatesImageToWindow(
          HTuple rowImage,
          HTuple columnImage,
          out HTuple rowWindow,
          out HTuple columnWindow)
        {
            IntPtr proc = HalconAPI.PreCall(2049);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, rowImage);
            HalconAPI.Store(proc, 2, columnImage);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowImage);
            HalconAPI.UnpinTuple(columnImage);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowWindow);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnWindow);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert image coordinates to window coordinates
        ///   Instance represents: Window handle
        /// </summary>
        /// <param name="rowImage">Row in image coordinates.</param>
        /// <param name="columnImage">Column in image coordinates.</param>
        /// <param name="rowWindow">Row (Y) in window coordinates.</param>
        /// <param name="columnWindow">Column (X) in window coordinates.</param>
        public void ConvertCoordinatesImageToWindow(
          double rowImage,
          double columnImage,
          out double rowWindow,
          out double columnWindow)
        {
            IntPtr proc = HalconAPI.PreCall(2049);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowImage);
            HalconAPI.StoreD(proc, 2, columnImage);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowWindow);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out columnWindow);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert window coordinates to image coordinates
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowWindow">Row (Y) in window coordinates.</param>
        /// <param name="columnWindow">Column (X) in window coordinates.</param>
        /// <param name="rowImage">Row in image coordinates.</param>
        /// <param name="columnImage">Column in image coordinates.</param>
        public void ConvertCoordinatesWindowToImage(
          HTuple rowWindow,
          HTuple columnWindow,
          out HTuple rowImage,
          out HTuple columnImage)
        {
            IntPtr proc = HalconAPI.PreCall(2050);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, rowWindow);
            HalconAPI.Store(proc, 2, columnWindow);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowWindow);
            HalconAPI.UnpinTuple(columnWindow);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowImage);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnImage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert window coordinates to image coordinates
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="rowWindow">Row (Y) in window coordinates.</param>
        /// <param name="columnWindow">Column (X) in window coordinates.</param>
        /// <param name="rowImage">Row in image coordinates.</param>
        /// <param name="columnImage">Column in image coordinates.</param>
        public void ConvertCoordinatesWindowToImage(
          double rowWindow,
          double columnWindow,
          out double rowImage,
          out double columnImage)
        {
            IntPtr proc = HalconAPI.PreCall(2050);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowWindow);
            HalconAPI.StoreD(proc, 2, columnWindow);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowImage);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out columnImage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display text in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="stringVal">A tuple of strings containing the text message to be displayed. Each value of the tuple will be displayed in a single line. Default: "hello"</param>
        /// <param name="coordSystem">If set to 'window', the text position is given with respect to the window coordinate system. If set to 'image', image coordinates are used (this may be useful in zoomed images). Default: "window"</param>
        /// <param name="row">The vertical text alignment or the row coordinate of the desired text position. Default: 12</param>
        /// <param name="column">The horizontal text alignment or the column coordinate of  the desired text position. Default: 12</param>
        /// <param name="color">A tuple of strings defining the colors of the texts. Default: "black"</param>
        /// <param name="genParamName">Generic parameter names. Default: []</param>
        /// <param name="genParamValue">Generic parameter values. Default: []</param>
        public void DispText(
          HTuple stringVal,
          string coordSystem,
          HTuple row,
          HTuple column,
          HTuple color,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2055);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, stringVal);
            HalconAPI.StoreS(proc, 2, coordSystem);
            HalconAPI.Store(proc, 3, row);
            HalconAPI.Store(proc, 4, column);
            HalconAPI.Store(proc, 5, color);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(stringVal);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(color);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display text in a window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="stringVal">A tuple of strings containing the text message to be displayed. Each value of the tuple will be displayed in a single line. Default: "hello"</param>
        /// <param name="coordSystem">If set to 'window', the text position is given with respect to the window coordinate system. If set to 'image', image coordinates are used (this may be useful in zoomed images). Default: "window"</param>
        /// <param name="row">The vertical text alignment or the row coordinate of the desired text position. Default: 12</param>
        /// <param name="column">The horizontal text alignment or the column coordinate of  the desired text position. Default: 12</param>
        /// <param name="color">A tuple of strings defining the colors of the texts. Default: "black"</param>
        /// <param name="genParamName">Generic parameter names. Default: []</param>
        /// <param name="genParamValue">Generic parameter values. Default: []</param>
        public void DispText(
          string stringVal,
          string coordSystem,
          int row,
          int column,
          string color,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2055);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, stringVal);
            HalconAPI.StoreS(proc, 2, coordSystem);
            HalconAPI.StoreI(proc, 3, row);
            HalconAPI.StoreI(proc, 4, column);
            HalconAPI.StoreS(proc, 5, color);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Flush the contents of a window.
        ///   Instance represents: Window handle.
        /// </summary>
        public void FlushBuffer()
        {
            IntPtr proc = HalconAPI.PreCall(2070);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the current color in RGBA-coding.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">The current color's red value.</param>
        /// <param name="green">The current color's green value.</param>
        /// <param name="blue">The current color's blue value.</param>
        /// <param name="alpha">The current color's alpha value.</param>
        public void GetRgba(out HTuple red, out HTuple green, out HTuple blue, out HTuple alpha)
        {
            IntPtr proc = HalconAPI.PreCall(2073);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out red);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out green);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out blue);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out alpha);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse double click event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDoubleClickEvent(HTuple row, HTuple column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2088);
            this.Store(proc, 0);
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
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse double click event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDoubleClickEvent(int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2088);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a window buffer signaling a mouse down event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDownEvent(HTuple row, HTuple column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2089);
            this.Store(proc, 0);
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
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a window buffer signaling a mouse down event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDownEvent(int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2089);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse drag event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDragEvent(HTuple row, HTuple column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2090);
            this.Store(proc, 0);
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
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse drag event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseDragEvent(int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2090);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse up event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseUpEvent(HTuple row, HTuple column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2091);
            this.Store(proc, 0);
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
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Send an event to a buffer window signaling a mouse up event.
        ///   Instance represents: Window handle of the buffer window.
        /// </summary>
        /// <param name="row">Row coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="column">Column coordinate of the mouse cursor in the image coordinate system.</param>
        /// <param name="button">Mouse button(s) pressed.</param>
        /// <returns>'true', if HALCON processed the event.</returns>
        public string SendMouseUpEvent(int row, int column, int button)
        {
            IntPtr proc = HalconAPI.PreCall(2091);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, button);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Sets the callback for content updates in buffer window.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="callbackFunction">Callback for content updates.</param>
        /// <param name="callbackContext">Parameter to CallbackFunction.</param>
        public void SetContentUpdateCallback(IntPtr callbackFunction, IntPtr callbackContext)
        {
            IntPtr proc = HalconAPI.PreCall(2095);
            this.Store(proc, 0);
            HalconAPI.StoreIP(proc, 1, callbackFunction);
            HalconAPI.StoreIP(proc, 2, callbackContext);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the color definition via RGBA values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">Red component of the color. Default: 255</param>
        /// <param name="green">Green component of the color. Default: 0</param>
        /// <param name="blue">Blue component of the color. Default: 0</param>
        /// <param name="alpha">Alpha component of the color. Default: 255</param>
        public void SetRgba(HTuple red, HTuple green, HTuple blue, HTuple alpha)
        {
            IntPtr proc = HalconAPI.PreCall(2096);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, red);
            HalconAPI.Store(proc, 2, green);
            HalconAPI.Store(proc, 3, blue);
            HalconAPI.Store(proc, 4, alpha);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(red);
            HalconAPI.UnpinTuple(green);
            HalconAPI.UnpinTuple(blue);
            HalconAPI.UnpinTuple(alpha);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the color definition via RGBA values.
        ///   Instance represents: Window handle.
        /// </summary>
        /// <param name="red">Red component of the color. Default: 255</param>
        /// <param name="green">Green component of the color. Default: 0</param>
        /// <param name="blue">Blue component of the color. Default: 0</param>
        /// <param name="alpha">Alpha component of the color. Default: 255</param>
        public void SetRgba(int red, int green, int blue, int alpha)
        {
            IntPtr proc = HalconAPI.PreCall(2096);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, red);
            HalconAPI.StoreI(proc, 2, green);
            HalconAPI.StoreI(proc, 3, blue);
            HalconAPI.StoreI(proc, 4, alpha);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1187);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        public delegate void ContentUpdateCallback(IntPtr context);
    }
}
