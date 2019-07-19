// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSheetOfLightModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of the data structure required to perform 3D measurements with the sheet-of-light technique.</summary>
    [Serializable]
    public class HSheetOfLightModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSheetOfLightModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSheetOfLightModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSheetOfLightModel obj)
        {
            obj = new HSheetOfLightModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSheetOfLightModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSheetOfLightModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSheetOfLightModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a sheet-of-light model from a file and create a new model.
        ///   Modified instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="fileName">Name of the sheet-of-light model file. Default: "sheet_of_light_model.solm"</param>
        public HSheetOfLightModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(374);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Modified instance represents: Handle for using and accessing the sheet-of-light model.
        /// </summary>
        /// <param name="profileRegion">Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        public HSheetOfLightModel(HRegion profileRegion, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(391);
            HalconAPI.Store(proc, 1, (HObjectBase)profileRegion);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileRegion);
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Modified instance represents: Handle for using and accessing the sheet-of-light model.
        /// </summary>
        /// <param name="profileRegion">Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        public HSheetOfLightModel(HRegion profileRegion, string genParamName, int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(391);
            HalconAPI.Store(proc, 1, (HObjectBase)profileRegion);
            HalconAPI.StoreS(proc, 0, genParamName);
            HalconAPI.StoreI(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileRegion);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeSheetOfLightModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSheetOfLightModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeSheetOfLightModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeSheetOfLightModel().Serialize(stream);
        }

        public static HSheetOfLightModel Deserialize(Stream stream)
        {
            HSheetOfLightModel hsheetOfLightModel = new HSheetOfLightModel();
            hsheetOfLightModel.DeserializeSheetOfLightModel(HSerializedItem.Deserialize(stream));
            return hsheetOfLightModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HSheetOfLightModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeSheetOfLightModel();
            HSheetOfLightModel hsheetOfLightModel = new HSheetOfLightModel();
            hsheetOfLightModel.DeserializeSheetOfLightModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hsheetOfLightModel;
        }

        /// <summary>
        ///   Read a sheet-of-light model from a file and create a new model.
        ///   Modified instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="fileName">Name of the sheet-of-light model file. Default: "sheet_of_light_model.solm"</param>
        public void ReadSheetOfLightModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(374);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a sheet-of-light model to a file.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="fileName">Name of the sheet-of-light model file. Default: "sheet_of_light_model.solm"</param>
        public void WriteSheetOfLightModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(375);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a sheet-of-light model.
        ///   Modified instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeSheetOfLightModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(376);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeSheetOfLightModel()
        {
            IntPtr proc = HalconAPI.PreCall(377);
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
        ///   Calibrate a sheet-of-light setup with a 3D calibration object.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <returns>Average back projection error of the optimization.</returns>
        public double CalibrateSheetOfLight()
        {
            IntPtr proc = HalconAPI.PreCall(379);
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
        ///   Get the result of a calibrated measurement performed with the  sheet-of-light technique as a 3D object model.
        ///   Instance represents: Handle for accessing the sheet-of-light model.
        /// </summary>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public HObjectModel3D GetSheetOfLightResultObjectModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(380);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Get the iconic results of a measurement performed with the sheet-of light technique.
        ///   Instance represents: Handle of the sheet-of-light model to be used.
        /// </summary>
        /// <param name="resultName">Specify which result of the measurement shall be provided. Default: "disparity"</param>
        /// <returns>Desired measurement result.</returns>
        public HImage GetSheetOfLightResult(HTuple resultName)
        {
            IntPtr proc = HalconAPI.PreCall(381);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, resultName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(resultName);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Get the iconic results of a measurement performed with the sheet-of light technique.
        ///   Instance represents: Handle of the sheet-of-light model to be used.
        /// </summary>
        /// <param name="resultName">Specify which result of the measurement shall be provided. Default: "disparity"</param>
        /// <returns>Desired measurement result.</returns>
        public HImage GetSheetOfLightResult(string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(381);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, resultName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Apply the calibration transformations to the input disparity image.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="disparity">Height or range image to be calibrated.</param>
        public void ApplySheetOfLightCalibration(HImage disparity)
        {
            IntPtr proc = HalconAPI.PreCall(382);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)disparity);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)disparity);
        }

        /// <summary>
        ///   Set sheet of light profiles by measured disparities.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="profileDisparityImage">Disparity image that contains several profiles.</param>
        /// <param name="movementPoses">Poses describing the movement of the scene under measurement between the previously processed profile image and the current profile image.</param>
        public void SetProfileSheetOfLight(HImage profileDisparityImage, HTuple movementPoses)
        {
            IntPtr proc = HalconAPI.PreCall(383);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)profileDisparityImage);
            HalconAPI.Store(proc, 1, movementPoses);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(movementPoses);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileDisparityImage);
        }

        /// <summary>
        ///   Process the profile image provided as input and store the resulting disparity to the sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="profileImage">Input image.</param>
        /// <param name="movementPose">Pose describing the movement of the scene under measurement between the previously processed profile image and the current profile image.</param>
        public void MeasureProfileSheetOfLight(HImage profileImage, HTuple movementPose)
        {
            IntPtr proc = HalconAPI.PreCall(384);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)profileImage);
            HalconAPI.Store(proc, 1, movementPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(movementPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileImage);
        }

        /// <summary>
        ///   Set selected parameters of the sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that shall be adjusted for the sheet-of-light model. Default: "method"</param>
        /// <param name="genParamValue">Value of the model parameter that shall be adjusted for the sheet-of-light model. Default: "center_of_gravity"</param>
        public void SetSheetOfLightParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(385);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of the sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that shall be adjusted for the sheet-of-light model. Default: "method"</param>
        /// <param name="genParamValue">Value of the model parameter that shall be adjusted for the sheet-of-light model. Default: "center_of_gravity"</param>
        public void SetSheetOfLightParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(385);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the value of a parameter, which has been set in a sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter that shall be queried. Default: "method"</param>
        /// <returns>Value of the model parameter that shall be queried.</returns>
        public HTuple GetSheetOfLightParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(386);
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
        ///   For a given sheet-of-light model get the names of the generic iconic or control parameters that can be used in the different sheet-of-light operators.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        /// <param name="queryName">Name of the parameter group. Default: "create_model_params"</param>
        /// <returns>List containing the names of the supported generic parameters.</returns>
        public HTuple QuerySheetOfLightParams(string queryName)
        {
            IntPtr proc = HalconAPI.PreCall(387);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, queryName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Reset a sheet-of-light model.
        ///   Instance represents: Handle of the sheet-of-light model.
        /// </summary>
        public void ResetSheetOfLightModel()
        {
            IntPtr proc = HalconAPI.PreCall(388);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Modified instance represents: Handle for using and accessing the sheet-of-light model.
        /// </summary>
        /// <param name="profileRegion">Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        public void CreateSheetOfLightModel(
          HRegion profileRegion,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(391);
            HalconAPI.Store(proc, 1, (HObjectBase)profileRegion);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileRegion);
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Modified instance represents: Handle for using and accessing the sheet-of-light model.
        /// </summary>
        /// <param name="profileRegion">Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        public void CreateSheetOfLightModel(
          HRegion profileRegion,
          string genParamName,
          int genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(391);
            HalconAPI.Store(proc, 1, (HObjectBase)profileRegion);
            HalconAPI.StoreS(proc, 0, genParamName);
            HalconAPI.StoreI(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)profileRegion);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(390);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
