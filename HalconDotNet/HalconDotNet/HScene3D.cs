// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HScene3D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a 3D graphic scene.</summary>
    public class HScene3D : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HScene3D(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScene3D obj)
        {
            obj = new HScene3D(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScene3D[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HScene3D[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HScene3D(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create the data structure that is needed to visualize collections of 3D objects.
        ///   Modified instance represents: Handle of the 3D scene.
        /// </summary>
        public HScene3D()
        {
            IntPtr proc = HalconAPI.PreCall(1220);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the depth or the index of instances in a displayed 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row coordinates.</param>
        /// <param name="column">Column coordinates.</param>
        /// <param name="information">Information. Default: "depth"</param>
        /// <returns>Indices or the depth of the objects at (Row,Column).</returns>
        public HTuple GetDisplayScene3dInfo(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          HTuple information)
        {
            IntPtr proc = HalconAPI.PreCall(1204);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.Store(proc, 4, information);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(information);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            return tuple;
        }

        /// <summary>
        ///   Get the depth or the index of instances in a displayed 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row coordinates.</param>
        /// <param name="column">Column coordinates.</param>
        /// <param name="information">Information. Default: "depth"</param>
        /// <returns>Indices or the depth of the objects at (Row,Column).</returns>
        public int GetDisplayScene3dInfo(
          HWindow windowHandle,
          double row,
          double column,
          string information)
        {
            IntPtr proc = HalconAPI.PreCall(1204);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreD(proc, 2, row);
            HalconAPI.StoreD(proc, 3, column);
            HalconAPI.StoreS(proc, 4, information);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            return intValue;
        }

        /// <summary>
        ///   Set the pose of a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="toWorldPose">New pose of the 3D scene.</param>
        public void SetScene3dToWorldPose(HPose toWorldPose)
        {
            IntPtr proc = HalconAPI.PreCall(1205);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)toWorldPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)toWorldPose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "quality"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "high"</param>
        public void SetScene3dParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1206);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "quality"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "high"</param>
        public void SetScene3dParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1206);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a light in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="lightIndex">Index of the light source.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "ambient"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: [0.2,0.2,0.2]</param>
        public void SetScene3dLightParam(int lightIndex, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1207);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, lightIndex);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a light in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="lightIndex">Index of the light source.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "ambient"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: [0.2,0.2,0.2]</param>
        public void SetScene3dLightParam(int lightIndex, string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1207);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, lightIndex);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the pose of an instance in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance.</param>
        /// <param name="pose">New pose of the instance.</param>
        public void SetScene3dInstancePose(HTuple instanceIndex, HPose[] pose)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1208);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, instanceIndex);
            HalconAPI.Store(proc, 2, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(instanceIndex);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the pose of an instance in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance.</param>
        /// <param name="pose">New pose of the instance.</param>
        public void SetScene3dInstancePose(int instanceIndex, HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1208);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, instanceIndex);
            HalconAPI.Store(proc, 2, (HData)pose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of an instance in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "color"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "green"</param>
        public void SetScene3dInstanceParam(
          HTuple instanceIndex,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1209);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, instanceIndex);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(instanceIndex);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of an instance in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "color"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "green"</param>
        public void SetScene3dInstanceParam(
          int instanceIndex,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1209);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, instanceIndex);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the pose of a camera in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="cameraIndex">Index of the camera.</param>
        /// <param name="pose">New pose of the camera.</param>
        public void SetScene3dCameraPose(int cameraIndex, HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1210);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIndex);
            HalconAPI.Store(proc, 2, (HData)pose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Render an image of a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="cameraIndex">Index of the camera used to display the scene.</param>
        /// <returns>Rendered 3D scene.</returns>
        public HImage RenderScene3d(int cameraIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1211);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIndex);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Remove a light from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="lightIndex">Light to remove.</param>
        public void RemoveScene3dLight(int lightIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1212);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, lightIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove an object instance from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance to remove.</param>
        public void RemoveScene3dInstance(HTuple instanceIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1213);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, instanceIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(instanceIndex);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove an object instance from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="instanceIndex">Index of the instance to remove.</param>
        public void RemoveScene3dInstance(int instanceIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1213);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, instanceIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove a camera from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="cameraIndex">Index of the camera to remove.</param>
        public void RemoveScene3dCamera(int cameraIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1214);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="cameraIndex">Index of the camera used to display the scene.</param>
        public void DisplayScene3d(HWindow windowHandle, HTuple cameraIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1215);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 2, cameraIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIndex);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Display a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="cameraIndex">Index of the camera used to display the scene.</param>
        public void DisplayScene3d(HWindow windowHandle, string cameraIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1215);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 2, cameraIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Add a light source to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="lightPosition">Position of the new light source. Default: [-100.0,-100.0,0.0]</param>
        /// <param name="lightKind">Type of the new light source. Default: "point_light"</param>
        /// <returns>Index of the new light source in the 3D scene.</returns>
        public int AddScene3dLight(HTuple lightPosition, string lightKind)
        {
            IntPtr proc = HalconAPI.PreCall(1216);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, lightPosition);
            HalconAPI.StoreS(proc, 2, lightKind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(lightPosition);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add an instance of a 3D object model to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">Pose of the 3D object model.</param>
        /// <returns>Index of the new instance in the 3D scene.</returns>
        public int AddScene3dInstance(HObjectModel3D[] objectModel3D, HPose[] pose)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1217);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, htuple1);
            HalconAPI.Store(proc, 2, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return intValue;
        }

        /// <summary>
        ///   Add an instance of a 3D object model to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">Pose of the 3D object model.</param>
        /// <returns>Index of the new instance in the 3D scene.</returns>
        public int AddScene3dInstance(HObjectModel3D objectModel3D, HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1217);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return intValue;
        }

        /// <summary>
        ///   Add a camera to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="cameraParam">Parameters of the new camera.</param>
        /// <returns>Index of the new camera in the 3D scene.</returns>
        public int AddScene3dCamera(HCamPar cameraParam)
        {
            IntPtr proc = HalconAPI.PreCall(1218);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)cameraParam);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Create the data structure that is needed to visualize collections of 3D objects.
        ///   Modified instance represents: Handle of the 3D scene.
        /// </summary>
        public void CreateScene3d()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1220);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a text label to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="text">Text of the label. Default: "label"</param>
        /// <param name="referencePoint">Point of reference of the label.</param>
        /// <param name="position">Position of the label. Default: "top"</param>
        /// <param name="relatesTo">Indicates fixed or relative positioning. Default: "point"</param>
        /// <returns>Index of the new label in the 3D scene.</returns>
        public int AddScene3dLabel(
          HTuple text,
          HTuple referencePoint,
          HTuple position,
          HTuple relatesTo)
        {
            IntPtr proc = HalconAPI.PreCall(2040);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, text);
            HalconAPI.Store(proc, 2, referencePoint);
            HalconAPI.Store(proc, 3, position);
            HalconAPI.Store(proc, 4, relatesTo);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(text);
            HalconAPI.UnpinTuple(referencePoint);
            HalconAPI.UnpinTuple(position);
            HalconAPI.UnpinTuple(relatesTo);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a text label to a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="text">Text of the label. Default: "label"</param>
        /// <param name="referencePoint">Point of reference of the label.</param>
        /// <param name="position">Position of the label. Default: "top"</param>
        /// <param name="relatesTo">Indicates fixed or relative positioning. Default: "point"</param>
        /// <returns>Index of the new label in the 3D scene.</returns>
        public int AddScene3dLabel(
          string text,
          HTuple referencePoint,
          HTuple position,
          HTuple relatesTo)
        {
            IntPtr proc = HalconAPI.PreCall(2040);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, text);
            HalconAPI.Store(proc, 2, referencePoint);
            HalconAPI.Store(proc, 3, position);
            HalconAPI.Store(proc, 4, relatesTo);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(referencePoint);
            HalconAPI.UnpinTuple(position);
            HalconAPI.UnpinTuple(relatesTo);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Remove a text label from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="labelIndex">Index of the text label to remove.</param>
        public void RemoveScene3dLabel(HTuple labelIndex)
        {
            IntPtr proc = HalconAPI.PreCall(2041);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, labelIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(labelIndex);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove a text label from a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="labelIndex">Index of the text label to remove.</param>
        public void RemoveScene3dLabel(int labelIndex)
        {
            IntPtr proc = HalconAPI.PreCall(2041);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, labelIndex);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a text label in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="labelIndex">Index of the text label.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "color"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "red"</param>
        public void SetScene3dLabelParam(HTuple labelIndex, string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2042);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, labelIndex);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(labelIndex);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of a text label in a 3D scene.
        ///   Instance represents: Handle of the 3D scene.
        /// </summary>
        /// <param name="labelIndex">Index of the text label.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "color"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "red"</param>
        public void SetScene3dLabelParam(int labelIndex, string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2042);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, labelIndex);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1219);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
