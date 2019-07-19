// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDescriptorModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a descriptor model.</summary>
    [Serializable]
    public class HDescriptorModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDescriptorModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDescriptorModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDescriptorModel obj)
        {
            obj = new HDescriptorModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDescriptorModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDescriptorModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDescriptorModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a descriptor model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HDescriptorModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(946);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a descriptor model for calibrated perspective matching.
        ///   Modified instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        public HDescriptorModel(
          HImage template,
          HCamPar camParam,
          HPose referencePose,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            IntPtr proc = HalconAPI.PreCall(952);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, (HData)camParam);
            HalconAPI.Store(proc, 1, (HData)referencePose);
            HalconAPI.StoreS(proc, 2, detectorType);
            HalconAPI.Store(proc, 3, detectorParamName);
            HalconAPI.Store(proc, 4, detectorParamValue);
            HalconAPI.Store(proc, 5, descriptorParamName);
            HalconAPI.Store(proc, 6, descriptorParamValue);
            HalconAPI.StoreI(proc, 7, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a descriptor model for interest point matching.
        ///   Modified instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        public HDescriptorModel(
          HImage template,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            IntPtr proc = HalconAPI.PreCall(953);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreS(proc, 0, detectorType);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreI(proc, 5, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDescriptorModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDescriptorModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDescriptorModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDescriptorModel().Serialize(stream);
        }

        public static HDescriptorModel Deserialize(Stream stream)
        {
            HDescriptorModel hdescriptorModel = new HDescriptorModel();
            hdescriptorModel.DeserializeDescriptorModel(HSerializedItem.Deserialize(stream));
            return hdescriptorModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDescriptorModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDescriptorModel();
            HDescriptorModel hdescriptorModel = new HDescriptorModel();
            hdescriptorModel.DeserializeDescriptorModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdescriptorModel;
        }

        /// <summary>
        ///   Deserialize a descriptor model.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDescriptorModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(944);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a descriptor model.
        ///   Instance represents: Handle of a model to be saved.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDescriptorModel()
        {
            IntPtr proc = HalconAPI.PreCall(945);
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
        ///   Read a descriptor model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadDescriptorModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(946);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a descriptor model to a file.
        ///   Instance represents: Handle of a model to be saved.
        /// </summary>
        /// <param name="fileName">The path and filename of the model to be saved.</param>
        public void WriteDescriptorModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(947);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find the best matches of a calibrated descriptor model in an image and return their 3D pose.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="camParam">Camera parameter (inner orientation) obtained from camera calibration.</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>3D pose of the object.</returns>
        public HPose[] FindCalibDescriptorModel(
          HImage image,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          HTuple minScore,
          int numMatches,
          HCamPar camParam,
          HTuple scoreType,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.Store(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, (HData)camParam);
            HalconAPI.Store(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(scoreType);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a calibrated descriptor model in an image and return their 3D pose.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="camParam">Camera parameter (inner orientation) obtained from camera calibration.</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>3D pose of the object.</returns>
        public HPose FindCalibDescriptorModel(
          HImage image,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          double minScore,
          int numMatches,
          HCamPar camParam,
          string scoreType,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, (HData)camParam);
            HalconAPI.StoreS(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hpose;
        }

        /// <summary>
        ///   Find the best matches of a descriptor model in an image.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>Homography between model and found instance.</returns>
        public HHomMat2D[] FindUncalibDescriptorModel(
          HImage image,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          HTuple minScore,
          int numMatches,
          HTuple scoreType,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(949);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.Store(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(scoreType);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            HHomMat2D[] hhomMat2DArray = HHomMat2D.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hhomMat2DArray;
        }

        /// <summary>
        ///   Find the best matches of a descriptor model in an image.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>Homography between model and found instance.</returns>
        public HHomMat2D FindUncalibDescriptorModel(
          HImage image,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          double minScore,
          int numMatches,
          string scoreType,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(949);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.StoreS(proc, 7, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hhomMat2D;
        }

        /// <summary>
        ///   Query the interest points of the descriptor model or the last processed search image.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="set">Set of interest points. Default: "model"</param>
        /// <param name="subset">Subset of interest points. Default: "all"</param>
        /// <param name="row">Row coordinates of interest points.</param>
        /// <param name="column">Column coordinates of interest points.</param>
        public void GetDescriptorModelPoints(
          string set,
          HTuple subset,
          out HTuple row,
          out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(950);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, set);
            HalconAPI.Store(proc, 2, subset);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subset);
            int err2 = HTuple.LoadNew(proc, 0, err1, out row);
            int procResult = HTuple.LoadNew(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query the interest points of the descriptor model or the last processed search image.
        ///   Instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="set">Set of interest points. Default: "model"</param>
        /// <param name="subset">Subset of interest points. Default: "all"</param>
        /// <param name="row">Row coordinates of interest points.</param>
        /// <param name="column">Column coordinates of interest points.</param>
        public void GetDescriptorModelPoints(
          string set,
          int subset,
          out HTuple row,
          out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(950);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, set);
            HalconAPI.StoreI(proc, 2, subset);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, err1, out row);
            int procResult = HTuple.LoadNew(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the parameters of a descriptor model.
        ///   Instance represents: The object handle to the descriptor model.
        /// </summary>
        /// <param name="detectorParamName">The detectors parameter names.</param>
        /// <param name="detectorParamValue">Values of the detectors parameters.</param>
        /// <param name="descriptorParamName">The descriptors parameter names.</param>
        /// <param name="descriptorParamValue">Values of the descriptors parameters.</param>
        /// <returns>The type of the detector.</returns>
        public string GetDescriptorModelParams(
          out HTuple detectorParamName,
          out HTuple detectorParamValue,
          out HTuple descriptorParamName,
          out HTuple descriptorParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(951);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HTuple.LoadNew(proc, 1, err2, out detectorParamName);
            int err4 = HTuple.LoadNew(proc, 2, err3, out detectorParamValue);
            int err5 = HTuple.LoadNew(proc, 3, err4, out descriptorParamName);
            int procResult = HTuple.LoadNew(proc, 4, err5, out descriptorParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Create a descriptor model for calibrated perspective matching.
        ///   Modified instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        public void CreateCalibDescriptorModel(
          HImage template,
          HCamPar camParam,
          HPose referencePose,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(952);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, (HData)camParam);
            HalconAPI.Store(proc, 1, (HData)referencePose);
            HalconAPI.StoreS(proc, 2, detectorType);
            HalconAPI.Store(proc, 3, detectorParamName);
            HalconAPI.Store(proc, 4, detectorParamValue);
            HalconAPI.Store(proc, 5, descriptorParamName);
            HalconAPI.Store(proc, 6, descriptorParamValue);
            HalconAPI.StoreI(proc, 7, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a descriptor model for interest point matching.
        ///   Modified instance represents: The handle to the descriptor model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        public void CreateUncalibDescriptorModel(
          HImage template,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(953);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreS(proc, 0, detectorType);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreI(proc, 5, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Query alphanumerical results that were accumulated during descriptor-based matching.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="objectID">Handle of the object for which the results are queried. Default: "all"</param>
        /// <param name="resultNames">Name of the results to be queried. Default: "num_points"</param>
        /// <returns>Returned results.</returns>
        public HTuple GetDescriptorModelResults(HTuple objectID, string resultNames)
        {
            IntPtr proc = HalconAPI.PreCall(954);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectID);
            HalconAPI.StoreS(proc, 2, resultNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectID);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query alphanumerical results that were accumulated during descriptor-based matching.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="objectID">Handle of the object for which the results are queried. Default: "all"</param>
        /// <param name="resultNames">Name of the results to be queried. Default: "num_points"</param>
        /// <returns>Returned results.</returns>
        public HTuple GetDescriptorModelResults(int objectID, string resultNames)
        {
            IntPtr proc = HalconAPI.PreCall(954);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, objectID);
            HalconAPI.StoreS(proc, 2, resultNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the origin of a descriptor model.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="row">Position of origin in row direction.</param>
        /// <param name="column">Position of origin in column direction.</param>
        public void GetDescriptorModelOrigin(out HTuple row, out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(955);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, err1, out row);
            int procResult = HTuple.LoadNew(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the origin of a descriptor model.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="row">Position of origin in row direction.</param>
        /// <param name="column">Position of origin in column direction.</param>
        public void GetDescriptorModelOrigin(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(955);
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
        ///   Sets the origin of a descriptor model.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="row">Translation of origin in row direction. Default: 0</param>
        /// <param name="column">Translation of origin in column direction. Default: 0</param>
        public void SetDescriptorModelOrigin(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(956);
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
        ///   Sets the origin of a descriptor model.
        ///   Instance represents: Handle of a descriptor model.
        /// </summary>
        /// <param name="row">Translation of origin in row direction. Default: 0</param>
        /// <param name="column">Translation of origin in column direction. Default: 0</param>
        public void SetDescriptorModelOrigin(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(956);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(943);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
