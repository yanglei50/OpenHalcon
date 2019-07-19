// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HNCCModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an NCC model for matching.</summary>
    [Serializable]
    public class HNCCModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HNCCModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HNCCModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HNCCModel obj)
        {
            obj = new HNCCModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HNCCModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HNCCModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HNCCModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read an NCC model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HNCCModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(985);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare an NCC model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public HNCCModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          string metric)
        {
            IntPtr proc = HalconAPI.PreCall(993);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, metric);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an NCC model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public HNCCModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string metric)
        {
            IntPtr proc = HalconAPI.PreCall(993);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, metric);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeNccModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HNCCModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeNccModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeNccModel().Serialize(stream);
        }

        public static HNCCModel Deserialize(Stream stream)
        {
            HNCCModel hnccModel = new HNCCModel();
            hnccModel.DeserializeNccModel(HSerializedItem.Deserialize(stream));
            return hnccModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HNCCModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeNccModel();
            HNCCModel hnccModel = new HNCCModel();
            hnccModel.DeserializeNccModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hnccModel;
        }

        /// <summary>
        ///   Deserialize an NCC model.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeNccModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(983);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize an NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeNccModel()
        {
            IntPtr proc = HalconAPI.PreCall(984);
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
        ///   Read an NCC model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadNccModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(985);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write an NCC model to a file.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteNccModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(986);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Determine the parameters of an NCC model.</summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="parameters">Parameters to be determined automatically. Default: "all"</param>
        /// <param name="parameterValue">Value of the automatically determined parameter.</param>
        /// <returns>Name of the automatically determined parameter.</returns>
        public static HTuple DetermineNccModelParams(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          string metric,
          HTuple parameters,
          out HTuple parameterValue)
        {
            IntPtr proc = HalconAPI.PreCall(987);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreS(proc, 3, metric);
            HalconAPI.Store(proc, 4, parameters);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(parameters);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out parameterValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)template);
            return tuple;
        }

        /// <summary>Determine the parameters of an NCC model.</summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="parameters">Parameters to be determined automatically. Default: "all"</param>
        /// <param name="parameterValue">Value of the automatically determined parameter.</param>
        /// <returns>Name of the automatically determined parameter.</returns>
        public static HTuple DetermineNccModelParams(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          string metric,
          string parameters,
          out HTuple parameterValue)
        {
            IntPtr proc = HalconAPI.PreCall(987);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreS(proc, 3, metric);
            HalconAPI.StoreS(proc, 4, parameters);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out parameterValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)template);
            return tuple;
        }

        /// <summary>
        ///   Return the parameters of an NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="angleStart">Smallest rotation of the pattern.</param>
        /// <param name="angleExtent">Extent of the rotation angles.</param>
        /// <param name="angleStep">Step length of the angles (resolution).</param>
        /// <param name="metric">Match metric.</param>
        /// <returns>Number of pyramid levels.</returns>
        public int GetNccModelParams(
          out double angleStart,
          out double angleExtent,
          out double angleStep,
          out string metric)
        {
            IntPtr proc = HalconAPI.PreCall(988);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out angleStart);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out angleExtent);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out angleStep);
            int procResult = HalconAPI.LoadS(proc, 4, err5, out metric);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Return the origin (reference point) of an NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the NCC model.</param>
        /// <param name="column">Column coordinate of the origin of the NCC model.</param>
        public void GetNccModelOrigin(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(989);
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
        ///   Set the origin (reference point) of an NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the NCC model.</param>
        /// <param name="column">Column coordinate of the origin of the NCC model.</param>
        public void SetNccModelOrigin(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(990);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find the best matches of an NCC model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.8</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy. Default: "true"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindNccModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          HTuple numLevels,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(991);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, subPixel);
            HalconAPI.Store(proc, 7, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of an NCC model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.8</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy. Default: "true"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindNccModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(991);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, subPixel);
            HalconAPI.StoreI(proc, 7, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Set selected parameters of the NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="genParamName">Parameter names.</param>
        /// <param name="genParamValue">Parameter values.</param>
        public void SetNccModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(992);
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
        ///   Prepare an NCC model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void CreateNccModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          string metric)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(993);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, metric);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an NCC model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void CreateNccModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string metric)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(993);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, metric);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>Find the best matches of multiple NCC models.</summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="modelIDs">Handle of the models.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.8</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "true"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public static void FindNccModels(
          HImage image,
          HNCCModel[] modelIDs,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple minScore,
          HTuple numMatches,
          HTuple maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score,
          out HTuple model)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])modelIDs);
            IntPtr proc = HalconAPI.PreCall(2068);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, numMatches);
            HalconAPI.Store(proc, 5, maxOverlap);
            HalconAPI.Store(proc, 6, subPixel);
            HalconAPI.Store(proc, 7, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(numMatches);
            HalconAPI.UnpinTuple(maxOverlap);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelIDs);
        }

        /// <summary>
        ///   Find the best matches of multiple NCC models.
        ///   Instance represents: Handle of the models.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.8</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "true"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public void FindNccModels(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score,
          out HTuple model)
        {
            IntPtr proc = HalconAPI.PreCall(2068);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, subPixel);
            HalconAPI.StoreI(proc, 7, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Return the region used to create an NCC model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <returns>Model region of the NCC model.</returns>
        public HRegion GetNccModelRegion()
        {
            IntPtr proc = HalconAPI.PreCall(2071);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(982);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
