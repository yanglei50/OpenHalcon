// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSurfaceModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a surface model.</summary>
    [Serializable]
    public class HSurfaceModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSurfaceModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSurfaceModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceModel obj)
        {
            obj = new HSurfaceModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSurfaceModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSurfaceModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a surface model from a file.
        ///   Modified instance represents: Handle of the read surface model.
        /// </summary>
        /// <param name="fileName">Name of the SFM file.</param>
        public HSurfaceModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1039);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create the data structure needed to perform surface-based matching.
        ///   Modified instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public HSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1044);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Create the data structure needed to perform surface-based matching.
        ///   Modified instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public HSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1044);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeSurfaceModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSurfaceModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeSurfaceModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeSurfaceModel().Serialize(stream);
        }

        public static HSurfaceModel Deserialize(Stream stream)
        {
            HSurfaceModel hsurfaceModel = new HSurfaceModel();
            hsurfaceModel.DeserializeSurfaceModel(HSerializedItem.Deserialize(stream));
            return hsurfaceModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HSurfaceModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeSurfaceModel();
            HSurfaceModel hsurfaceModel = new HSurfaceModel();
            hsurfaceModel.DeserializeSurfaceModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hsurfaceModel;
        }

        /// <summary>
        ///   Deserialize a surface model.
        ///   Modified instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeSurfaceModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1037);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a surface_model.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeSurfaceModel()
        {
            IntPtr proc = HalconAPI.PreCall(1038);
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
        ///   Read a surface model from a file.
        ///   Modified instance represents: Handle of the read surface model.
        /// </summary>
        /// <param name="fileName">Name of the SFM file.</param>
        public void ReadSurfaceModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1039);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a surface model to a file.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteSurfaceModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1040);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] RefineSurfaceModelPose(
          HObjectModel3D objectModel3D,
          HPose[] initialPose,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            HTuple htuple = HData.ConcatArray((HData[])initialPose);
            IntPtr proc = HalconAPI.PreCall(1041);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, htuple);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPose(
          HObjectModel3D objectModel3D,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1041);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] FindSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1042);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.Store(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1042);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>
        ///   Return the parameters and properties of a surface model.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "diameter"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetSurfaceModelParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1043);
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
        ///   Return the parameters and properties of a surface model.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "diameter"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetSurfaceModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1043);
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
        ///   Create the data structure needed to perform surface-based matching.
        ///   Modified instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1044);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Create the data structure needed to perform surface-based matching.
        ///   Modified instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1044);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene and images.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] FindSurfaceModelImage(
          HImage image,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2069);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.Store(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene and images.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModelImage(
          HImage image,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2069);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene and in images.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] RefineSurfaceModelPoseImage(
          HImage image,
          HObjectModel3D objectModel3D,
          HPose[] initialPose,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            HTuple htuple = HData.ConcatArray((HData[])initialPose);
            IntPtr proc = HalconAPI.PreCall(2084);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, htuple);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene and in images.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPoseImage(
          HImage image,
          HObjectModel3D objectModel3D,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2084);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>
        ///   Set parameters and properties of a surface model.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "camera_parameter"</param>
        /// <param name="genParamValue">Value of the parameter.</param>
        public void SetSurfaceModelParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2097);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters and properties of a surface model.
        ///   Instance represents: Handle of the surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "camera_parameter"</param>
        /// <param name="genParamValue">Value of the parameter.</param>
        public void SetSurfaceModelParam(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2097);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1036);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
