// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HCalibData
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a camera calibration model.</summary>
    [Serializable]
    public class HCalibData : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCalibData()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCalibData(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCalibData obj)
        {
            obj = new HCalibData(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCalibData[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HCalibData[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HCalibData(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Restore a calibration data model from a file.
        ///   Modified instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="fileName">The path and file name of the model file.</param>
        public HCalibData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1963);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a HALCON calibration data model.
        ///   Modified instance represents: Handle of the created calibration data model.
        /// </summary>
        /// <param name="calibSetup">Type of the calibration setup. Default: "calibration_object"</param>
        /// <param name="numCameras">Number of cameras in the calibration setup. Default: 1</param>
        /// <param name="numCalibObjects">Number of calibration objects. Default: 1</param>
        public HCalibData(string calibSetup, int numCameras, int numCalibObjects)
        {
            IntPtr proc = HalconAPI.PreCall(1980);
            HalconAPI.StoreS(proc, 0, calibSetup);
            HalconAPI.StoreI(proc, 1, numCameras);
            HalconAPI.StoreI(proc, 2, numCalibObjects);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeCalibData();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCalibData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeCalibData(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeCalibData().Serialize(stream);
        }

        public static HCalibData Deserialize(Stream stream)
        {
            HCalibData hcalibData = new HCalibData();
            hcalibData.DeserializeCalibData(HSerializedItem.Deserialize(stream));
            return hcalibData;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HCalibData Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeCalibData();
            HCalibData hcalibData = new HCalibData();
            hcalibData.DeserializeCalibData(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hcalibData;
        }

        /// <summary>
        ///   Deserialize a serialized calibration data model.
        ///   Modified instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeCalibData(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1961);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeCalibData()
        {
            IntPtr proc = HalconAPI.PreCall(1962);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Restore a calibration data model from a file.
        ///   Modified instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="fileName">The path and file name of the model file.</param>
        public void ReadCalibData(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1963);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store a calibration data model into a file.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="fileName">The file name of the model to be saved.</param>
        public void WriteCalibData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1964);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Perform a hand-eye calibration.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <returns>Average residual error of the optimization.</returns>
        public HTuple CalibrateHandEye()
        {
            IntPtr proc = HalconAPI.PreCall(1965);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Determine all camera parameters by a simultaneous minimization process.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <returns>Back projection root mean square error (RMSE) of the optimization.</returns>
        public double CalibrateCameras()
        {
            IntPtr proc = HalconAPI.PreCall(1966);
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
        ///   Remove a data set from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of the calibration data item. Default: "tool"</param>
        /// <param name="itemIdx">Index of the affected item. Default: 0</param>
        public void RemoveCalibData(string itemType, HTuple itemIdx)
        {
            IntPtr proc = HalconAPI.PreCall(1967);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.Store(proc, 2, itemIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(itemIdx);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove a data set from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of the calibration data item. Default: "tool"</param>
        /// <param name="itemIdx">Index of the affected item. Default: 0</param>
        public void RemoveCalibData(string itemType, int itemIdx)
        {
            IntPtr proc = HalconAPI.PreCall(1967);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.StoreI(proc, 2, itemIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set data in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of calibration data item. Default: "model"</param>
        /// <param name="itemIdx">Index of the affected item (depending on the selected ItemType). Default: "general"</param>
        /// <param name="dataName">Parameter(s) to set. Default: "reference_camera"</param>
        /// <param name="dataValue">New value(s). Default: 0</param>
        public void SetCalibData(string itemType, HTuple itemIdx, string dataName, HTuple dataValue)
        {
            IntPtr proc = HalconAPI.PreCall(1968);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.Store(proc, 2, itemIdx);
            HalconAPI.StoreS(proc, 3, dataName);
            HalconAPI.Store(proc, 4, dataValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(itemIdx);
            HalconAPI.UnpinTuple(dataValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set data in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of calibration data item. Default: "model"</param>
        /// <param name="itemIdx">Index of the affected item (depending on the selected ItemType). Default: "general"</param>
        /// <param name="dataName">Parameter(s) to set. Default: "reference_camera"</param>
        /// <param name="dataValue">New value(s). Default: 0</param>
        public void SetCalibData(string itemType, int itemIdx, string dataName, string dataValue)
        {
            IntPtr proc = HalconAPI.PreCall(1968);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.StoreI(proc, 2, itemIdx);
            HalconAPI.StoreS(proc, 3, dataName);
            HalconAPI.StoreS(proc, 4, dataValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find the HALCON calibration plate and set the extracted points and contours in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters to be set. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters to be set. Default: []</param>
        public void FindCalibObject(
          HImage image,
          int cameraIdx,
          int calibObjIdx,
          int calibObjPoseIdx,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1969);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Remove observation data from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object pose. Default: 0</param>
        public void RemoveCalibDataObserv(int cameraIdx, int calibObjIdx, int calibObjPoseIdx)
        {
            IntPtr proc = HalconAPI.PreCall(1970);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get contour-based observation data from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="contourName">Name of contour objects to be returned. Default: "marks"</param>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object pose. Default: 0</param>
        /// <returns>Contour-based result(s).</returns>
        public HXLDCont GetCalibDataObservContours(
          string contourName,
          int cameraIdx,
          int calibObjIdx,
          int calibObjPoseIdx)
        {
            IntPtr proc = HalconAPI.PreCall(1971);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, contourName);
            HalconAPI.StoreI(proc, 2, cameraIdx);
            HalconAPI.StoreI(proc, 3, calibObjIdx);
            HalconAPI.StoreI(proc, 4, calibObjPoseIdx);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Get observed calibration object poses from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object pose. Default: 0</param>
        /// <returns>Stored observed calibration object pose relative to the observing camera.</returns>
        public HPose GetCalibDataObservPose(int cameraIdx, int calibObjIdx, int calibObjPoseIdx)
        {
            IntPtr proc = HalconAPI.PreCall(1972);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Set observed calibration object poses in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="objInCameraPose">Pose of the observed calibration object relative to the observing camera.</param>
        public void SetCalibDataObservPose(
          int cameraIdx,
          int calibObjIdx,
          int calibObjPoseIdx,
          HPose objInCameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1973);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            HalconAPI.Store(proc, 4, (HData)objInCameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)objInCameraPose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get point-based observation data from a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object pose. Default: 0</param>
        /// <param name="row">Row coordinates of the detected points.</param>
        /// <param name="column">Column coordinates of the detected points.</param>
        /// <param name="index">Correspondence of the detected points to the points of the observed calibration object.</param>
        /// <param name="pose">Roughly estimated pose of the observed calibration object relative to the observing camera.</param>
        public void GetCalibDataObservPoints(
          int cameraIdx,
          int calibObjIdx,
          int calibObjPoseIdx,
          out HTuple row,
          out HTuple column,
          out HTuple index,
          out HTuple pose)
        {
            IntPtr proc = HalconAPI.PreCall(1974);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, err3, out index);
            int procResult = HTuple.LoadNew(proc, 3, err4, out pose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set point-based observation data in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Index of the observing camera. Default: 0</param>
        /// <param name="calibObjIdx">Index of the calibration object. Default: 0</param>
        /// <param name="calibObjPoseIdx">Index of the observed calibration object. Default: 0</param>
        /// <param name="row">Row coordinates of the extracted points.</param>
        /// <param name="column">Column coordinates of the extracted points.</param>
        /// <param name="index">Correspondence of the extracted points to the calibration marks of the observed calibration object. Default: "all"</param>
        /// <param name="pose">Roughly estimated pose of the observed calibration object relative to the observing camera.</param>
        public void SetCalibDataObservPoints(
          int cameraIdx,
          int calibObjIdx,
          int calibObjPoseIdx,
          HTuple row,
          HTuple column,
          HTuple index,
          HTuple pose)
        {
            IntPtr proc = HalconAPI.PreCall(1975);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreI(proc, 2, calibObjIdx);
            HalconAPI.StoreI(proc, 3, calibObjPoseIdx);
            HalconAPI.Store(proc, 4, row);
            HalconAPI.Store(proc, 5, column);
            HalconAPI.Store(proc, 6, index);
            HalconAPI.Store(proc, 7, pose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(pose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query information about the relations between cameras, calibration objects, and calibration object poses.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Kind of referred object. Default: "camera"</param>
        /// <param name="itemIdx">Camera index or calibration object index (depending on the selected ItemType). Default: 0</param>
        /// <param name="index2">Calibration object numbers.</param>
        /// <returns>List of calibration object indices or list of camera indices (depending on ItemType).</returns>
        public HTuple QueryCalibDataObservIndices(
          string itemType,
          int itemIdx,
          out HTuple index2)
        {
            IntPtr proc = HalconAPI.PreCall(1976);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.StoreI(proc, 2, itemIdx);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out index2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query data stored or computed in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of calibration data item. Default: "camera"</param>
        /// <param name="itemIdx">Index of the affected item (depending on the selected ItemType). Default: 0</param>
        /// <param name="dataName">The name of the inspected data. Default: "params"</param>
        /// <returns>Requested data.</returns>
        public HTuple GetCalibData(string itemType, HTuple itemIdx, HTuple dataName)
        {
            IntPtr proc = HalconAPI.PreCall(1977);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.Store(proc, 2, itemIdx);
            HalconAPI.Store(proc, 3, dataName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(itemIdx);
            HalconAPI.UnpinTuple(dataName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query data stored or computed in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="itemType">Type of calibration data item. Default: "camera"</param>
        /// <param name="itemIdx">Index of the affected item (depending on the selected ItemType). Default: 0</param>
        /// <param name="dataName">The name of the inspected data. Default: "params"</param>
        /// <returns>Requested data.</returns>
        public HTuple GetCalibData(string itemType, int itemIdx, string dataName)
        {
            IntPtr proc = HalconAPI.PreCall(1977);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, itemType);
            HalconAPI.StoreI(proc, 2, itemIdx);
            HalconAPI.StoreS(proc, 3, dataName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Define a calibration object in a calibration model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="calibObjIdx">Calibration object index. Default: 0</param>
        /// <param name="calibObjDescr">3D point coordinates or a description file name.</param>
        public void SetCalibDataCalibObject(int calibObjIdx, HTuple calibObjDescr)
        {
            IntPtr proc = HalconAPI.PreCall(1978);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, calibObjIdx);
            HalconAPI.Store(proc, 2, calibObjDescr);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(calibObjDescr);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define a calibration object in a calibration model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="calibObjIdx">Calibration object index. Default: 0</param>
        /// <param name="calibObjDescr">3D point coordinates or a description file name.</param>
        public void SetCalibDataCalibObject(int calibObjIdx, double calibObjDescr)
        {
            IntPtr proc = HalconAPI.PreCall(1978);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, calibObjIdx);
            HalconAPI.StoreD(proc, 2, calibObjDescr);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set type and initial parameters of a camera in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Camera index. Default: 0</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Initial camera internal parameters.</param>
        public void SetCalibDataCamParam(HTuple cameraIdx, HTuple cameraType, HCamPar cameraParam)
        {
            IntPtr proc = HalconAPI.PreCall(1979);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.Store(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set type and initial parameters of a camera in a calibration data model.
        ///   Instance represents: Handle of a calibration data model.
        /// </summary>
        /// <param name="cameraIdx">Camera index. Default: 0</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Initial camera internal parameters.</param>
        public void SetCalibDataCamParam(HTuple cameraIdx, string cameraType, HCamPar cameraParam)
        {
            IntPtr proc = HalconAPI.PreCall(1979);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a HALCON calibration data model.
        ///   Modified instance represents: Handle of the created calibration data model.
        /// </summary>
        /// <param name="calibSetup">Type of the calibration setup. Default: "calibration_object"</param>
        /// <param name="numCameras">Number of cameras in the calibration setup. Default: 1</param>
        /// <param name="numCalibObjects">Number of calibration objects. Default: 1</param>
        public void CreateCalibData(string calibSetup, int numCameras, int numCalibObjects)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1980);
            HalconAPI.StoreS(proc, 0, calibSetup);
            HalconAPI.StoreI(proc, 1, numCameras);
            HalconAPI.StoreI(proc, 2, numCalibObjects);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1960);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
