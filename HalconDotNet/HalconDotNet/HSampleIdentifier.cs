// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSampleIdentifier
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a sample identifier.</summary>
    [Serializable]
    public class HSampleIdentifier : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSampleIdentifier()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSampleIdentifier(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSampleIdentifier obj)
        {
            obj = new HSampleIdentifier(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSampleIdentifier[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSampleIdentifier[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSampleIdentifier(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a sample identifier from a file.
        ///   Modified instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HSampleIdentifier(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(901);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new sample identifier.
        ///   Modified instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: []</param>
        /// <param name="genParamValue">Parameter value. Default: []</param>
        public HSampleIdentifier(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(915);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeSampleIdentifier();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSampleIdentifier(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeSampleIdentifier(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeSampleIdentifier().Serialize(stream);
        }

        public static HSampleIdentifier Deserialize(Stream stream)
        {
            HSampleIdentifier hsampleIdentifier = new HSampleIdentifier();
            hsampleIdentifier.DeserializeSampleIdentifier(HSerializedItem.Deserialize(stream));
            return hsampleIdentifier;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HSampleIdentifier Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeSampleIdentifier();
            HSampleIdentifier hsampleIdentifier = new HSampleIdentifier();
            hsampleIdentifier.DeserializeSampleIdentifier(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hsampleIdentifier;
        }

        /// <summary>
        ///   Deserialize a serialized sample identifier.
        ///   Modified instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeSampleIdentifier(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(900);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Read a sample identifier from a file.
        ///   Modified instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadSampleIdentifier(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(901);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Serialize a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeSampleIdentifier()
        {
            IntPtr proc = HalconAPI.PreCall(902);
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
        ///   Write a sample identifier to a file.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteSampleIdentifier(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(903);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Identify objects with a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="image">Image showing the object to be identified.</param>
        /// <param name="numResults">Number of suggested object indices. Default: 1</param>
        /// <param name="ratingThreshold">Rating threshold. Default: 0.0</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <param name="rating">Rating value of the identified object.</param>
        /// <returns>Index of the identified object.</returns>
        public HTuple ApplySampleIdentifier(
          HImage image,
          int numResults,
          double ratingThreshold,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple rating)
        {
            IntPtr proc = HalconAPI.PreCall(904);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, numResults);
            HalconAPI.StoreD(proc, 2, ratingThreshold);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rating);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Identify objects with a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="image">Image showing the object to be identified.</param>
        /// <param name="numResults">Number of suggested object indices. Default: 1</param>
        /// <param name="ratingThreshold">Rating threshold. Default: 0.0</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <param name="rating">Rating value of the identified object.</param>
        /// <returns>Index of the identified object.</returns>
        public int ApplySampleIdentifier(
          HImage image,
          int numResults,
          double ratingThreshold,
          HTuple genParamName,
          HTuple genParamValue,
          out double rating)
        {
            IntPtr proc = HalconAPI.PreCall(904);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, numResults);
            HalconAPI.StoreD(proc, 2, ratingThreshold);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out rating);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return intValue;
        }

        /// <summary>
        ///   Get selected parameters of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: "rating_method"</param>
        /// <returns>Parameter value.</returns>
        public HTuple GetSampleIdentifierParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(905);
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
        ///   Set selected parameters of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: "rating_method"</param>
        /// <param name="genParamValue">Parameter value. Default: "score_single"</param>
        public void SetSampleIdentifierParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(906);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: "rating_method"</param>
        /// <param name="genParamValue">Parameter value. Default: "score_single"</param>
        public void SetSampleIdentifierParam(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(906);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Retrieve information about an object of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the object for which information is retrieved.</param>
        /// <param name="infoName">Define, for which kind of object information is retrieved. Default: "num_training_objects"</param>
        /// <returns>Information about the object.</returns>
        public HTuple GetSampleIdentifierObjectInfo(HTuple objectIdx, HTuple infoName)
        {
            IntPtr proc = HalconAPI.PreCall(907);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, infoName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(infoName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Retrieve information about an object of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the object for which information is retrieved.</param>
        /// <param name="infoName">Define, for which kind of object information is retrieved. Default: "num_training_objects"</param>
        /// <returns>Information about the object.</returns>
        public HTuple GetSampleIdentifierObjectInfo(int objectIdx, string infoName)
        {
            IntPtr proc = HalconAPI.PreCall(907);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.StoreS(proc, 2, infoName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Define a name or a description for an object of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the object for which information is set.</param>
        /// <param name="infoName">Define, for which kind of object information is set. Default: "training_object_name"</param>
        /// <param name="infoValue">Information about the object.</param>
        public void SetSampleIdentifierObjectInfo(HTuple objectIdx, string infoName, HTuple infoValue)
        {
            IntPtr proc = HalconAPI.PreCall(908);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.StoreS(proc, 2, infoName);
            HalconAPI.Store(proc, 3, infoValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(infoValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define a name or a description for an object of a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the object for which information is set.</param>
        /// <param name="infoName">Define, for which kind of object information is set. Default: "training_object_name"</param>
        /// <param name="infoValue">Information about the object.</param>
        public void SetSampleIdentifierObjectInfo(int objectIdx, string infoName, string infoValue)
        {
            IntPtr proc = HalconAPI.PreCall(908);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.StoreS(proc, 2, infoName);
            HalconAPI.StoreS(proc, 3, infoValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove training data from a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the training object, from which samples should be removed.</param>
        /// <param name="objectSampleIdx">Index of the training sample that should be removed.</param>
        public void RemoveSampleIdentifierTrainingData(HTuple objectIdx, HTuple objectSampleIdx)
        {
            IntPtr proc = HalconAPI.PreCall(909);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, objectSampleIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(objectSampleIdx);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove training data from a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the training object, from which samples should be removed.</param>
        /// <param name="objectSampleIdx">Index of the training sample that should be removed.</param>
        public void RemoveSampleIdentifierTrainingData(int objectIdx, int objectSampleIdx)
        {
            IntPtr proc = HalconAPI.PreCall(909);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.StoreI(proc, 2, objectSampleIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove preparation data from a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the preparation object, of which samples should be removed.</param>
        /// <param name="objectSampleIdx">Index of the preparation sample that should be removed.</param>
        public void RemoveSampleIdentifierPreparationData(HTuple objectIdx, HTuple objectSampleIdx)
        {
            IntPtr proc = HalconAPI.PreCall(910);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, objectSampleIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(objectSampleIdx);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Remove preparation data from a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="objectIdx">Index of the preparation object, of which samples should be removed.</param>
        /// <param name="objectSampleIdx">Index of the preparation sample that should be removed.</param>
        public void RemoveSampleIdentifierPreparationData(int objectIdx, int objectSampleIdx)
        {
            IntPtr proc = HalconAPI.PreCall(910);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.StoreI(proc, 2, objectSampleIdx);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train a sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: []</param>
        /// <param name="genParamValue">Parameter value. Default: []</param>
        public void TrainSampleIdentifier(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(911);
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
        ///   Add training data to an existing sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="sampleImage">Image that shows an object.</param>
        /// <param name="objectIdx">Index of the object visible in the SampleImage.</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <returns>Index of the object sample.</returns>
        public int AddSampleIdentifierTrainingData(
          HImage sampleImage,
          HTuple objectIdx,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(912);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sampleImage);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampleImage);
            return intValue;
        }

        /// <summary>
        ///   Add training data to an existing sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="sampleImage">Image that shows an object.</param>
        /// <param name="objectIdx">Index of the object visible in the SampleImage.</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <returns>Index of the object sample.</returns>
        public int AddSampleIdentifierTrainingData(
          HImage sampleImage,
          int objectIdx,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(912);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sampleImage);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampleImage);
            return intValue;
        }

        /// <summary>
        ///   Adapt the internal data structure of a sample identifier to the objects to be identified.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="removePreparationData">Indicates if the preparation data should be removed. Default: "true"</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        public void PrepareSampleIdentifier(
          string removePreparationData,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(913);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, removePreparationData);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add preparation data to an existing sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="sampleImage">Image that shows an object.</param>
        /// <param name="objectIdx">Index of the object visible in the SampleImage. Default: "unknown"</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <returns>Index of the object sample.</returns>
        public int AddSampleIdentifierPreparationData(
          HImage sampleImage,
          HTuple objectIdx,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(914);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sampleImage);
            HalconAPI.Store(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectIdx);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampleImage);
            return intValue;
        }

        /// <summary>
        ///   Add preparation data to an existing sample identifier.
        ///   Instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="sampleImage">Image that shows an object.</param>
        /// <param name="objectIdx">Index of the object visible in the SampleImage. Default: "unknown"</param>
        /// <param name="genParamName">Generic parameter name. Default: []</param>
        /// <param name="genParamValue">Generic parameter value. Default: []</param>
        /// <returns>Index of the object sample.</returns>
        public int AddSampleIdentifierPreparationData(
          HImage sampleImage,
          int objectIdx,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(914);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)sampleImage);
            HalconAPI.StoreI(proc, 1, objectIdx);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampleImage);
            return intValue;
        }

        /// <summary>
        ///   Create a new sample identifier.
        ///   Modified instance represents: Handle of the sample identifier.
        /// </summary>
        /// <param name="genParamName">Parameter name. Default: []</param>
        /// <param name="genParamValue">Parameter value. Default: []</param>
        public void CreateSampleIdentifier(HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(915);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(899);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
