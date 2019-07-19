// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HCameraSetupModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a camera setup model.</summary>
    [Serializable]
    public class HCameraSetupModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCameraSetupModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCameraSetupModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCameraSetupModel obj)
        {
            obj = new HCameraSetupModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCameraSetupModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HCameraSetupModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HCameraSetupModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Restore a camera setup model from a file.
        ///   Modified instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="fileName">The path and file name of the model file.</param>
        public HCameraSetupModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1954);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model for a setup of calibrated cameras.
        ///   Modified instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="numCameras">Number of cameras in the setup. Default: 2</param>
        public HCameraSetupModel(int numCameras)
        {
            IntPtr proc = HalconAPI.PreCall(1958);
            HalconAPI.StoreI(proc, 0, numCameras);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeCameraSetupModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCameraSetupModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeCameraSetupModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeCameraSetupModel().Serialize(stream);
        }

        public static HCameraSetupModel Deserialize(Stream stream)
        {
            HCameraSetupModel hcameraSetupModel = new HCameraSetupModel();
            hcameraSetupModel.DeserializeCameraSetupModel(HSerializedItem.Deserialize(stream));
            return hcameraSetupModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HCameraSetupModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeCameraSetupModel();
            HCameraSetupModel hcameraSetupModel = new HCameraSetupModel();
            hcameraSetupModel.DeserializeCameraSetupModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hcameraSetupModel;
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        /// <returns>Handle of the stereo model.</returns>
        public HStereoModel CreateStereoModel(
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(527);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HStereoModel hstereoModel;
            int procResult = HStereoModel.LoadNew(proc, 0, err, out hstereoModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hstereoModel;
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        /// <returns>Handle of the stereo model.</returns>
        public HStereoModel CreateStereoModel(
          string method,
          string genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(527);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HStereoModel hstereoModel;
            int procResult = HStereoModel.LoadNew(proc, 0, err, out hstereoModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hstereoModel;
        }

        /// <summary>
        ///   Serialize a camera setup model.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeCameraSetupModel()
        {
            IntPtr proc = HalconAPI.PreCall(1951);
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
        ///   Deserialize a serialized camera setup model.
        ///   Modified instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeCameraSetupModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1952);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Store a camera setup model into a file.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="fileName">The file name of the model to be saved.</param>
        public void WriteCameraSetupModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1953);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Restore a camera setup model from a file.
        ///   Modified instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="fileName">The path and file name of the model file.</param>
        public void ReadCameraSetupModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1954);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get generic camera setup model parameters.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Index of the camera in the setup. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters to be queried.</param>
        /// <returns>Values of the generic parameters to be queried.</returns>
        public HTuple GetCameraSetupParam(HTuple cameraIdx, string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1955);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get generic camera setup model parameters.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Index of the camera in the setup. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters to be queried.</param>
        /// <returns>Values of the generic parameters to be queried.</returns>
        public HTuple GetCameraSetupParam(int cameraIdx, string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1955);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set generic camera setup model parameters.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Unique index of the camera in the setup. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters to be set.</param>
        /// <param name="genParamValue">Values of the generic parameters to be set.</param>
        public void SetCameraSetupParam(HTuple cameraIdx, string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1956);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set generic camera setup model parameters.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Unique index of the camera in the setup. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters to be set.</param>
        /// <param name="genParamValue">Values of the generic parameters to be set.</param>
        public void SetCameraSetupParam(int cameraIdx, string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1956);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define type, parameters, and relative pose of a camera in a camera setup model.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public void SetCameraSetupCamParam(
          HTuple cameraIdx,
          HTuple cameraType,
          HCamPar cameraParam,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.Store(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define type, parameters, and relative pose of a camera in a camera setup model.
        ///   Instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public void SetCameraSetupCamParam(
          HTuple cameraIdx,
          string cameraType,
          HCamPar cameraParam,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model for a setup of calibrated cameras.
        ///   Modified instance represents: Handle to the camera setup model.
        /// </summary>
        /// <param name="numCameras">Number of cameras in the setup. Default: 2</param>
        public void CreateCameraSetupModel(int numCameras)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1958);
            HalconAPI.StoreI(proc, 0, numCameras);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1950);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
