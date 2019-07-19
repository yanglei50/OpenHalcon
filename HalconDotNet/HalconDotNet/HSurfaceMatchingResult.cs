// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSurfaceMatchingResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a surface matching result.</summary>
    public class HSurfaceMatchingResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSurfaceMatchingResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSurfaceMatchingResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HSurfaceMatchingResult obj)
        {
            obj = new HSurfaceMatchingResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HSurfaceMatchingResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSurfaceMatchingResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSurfaceMatchingResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Get details of a result from surface based matching.
        ///   Instance represents: Handle of the surface matching result.
        /// </summary>
        /// <param name="resultName">Name of the result property. Default: "pose"</param>
        /// <param name="resultIndex">Index of the matching result, starting with 0. Default: 0</param>
        /// <returns>Value of the result property.</returns>
        public HTuple GetSurfaceMatchingResult(HTuple resultName, int resultIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1032);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, resultName);
            HalconAPI.StoreI(proc, 2, resultIndex);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(resultName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get details of a result from surface based matching.
        ///   Instance represents: Handle of the surface matching result.
        /// </summary>
        /// <param name="resultName">Name of the result property. Default: "pose"</param>
        /// <param name="resultIndex">Index of the matching result, starting with 0. Default: 0</param>
        /// <returns>Value of the result property.</returns>
        public HTuple GetSurfaceMatchingResult(string resultName, int resultIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1032);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, resultName);
            HalconAPI.StoreI(proc, 2, resultIndex);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Refine the pose of a surface model in a 3D scene.</summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public static HPose[] RefineSurfaceModelPose(
          HSurfaceModel surfaceModelID,
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
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
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
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene.
        ///   Modified instance represents: Handle of the matching result, if enabled in ReturnResultHandle.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPose(
          HSurfaceModel surfaceModelID,
          HObjectModel3D objectModel3D,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1041);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 2, err1);
            HPose hpose;
            int err3 = HPose.LoadNew(proc, 0, err2, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>Find the best matches of a surface model in a 3D scene.</summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
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
        public static HPose[] FindSurfaceModel(
          HSurfaceModel surfaceModelID,
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
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
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
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene.
        ///   Modified instance represents: Handle of the matching result, if enabled in ReturnResultHandle.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModel(
          HSurfaceModel surfaceModelID,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1042);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 2, err1);
            HPose hpose;
            int err3 = HPose.LoadNew(proc, 0, err2, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>Find the best matches of a surface model in a 3D scene and images.</summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
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
        public static HPose[] FindSurfaceModelImage(
          HImage image,
          HSurfaceModel surfaceModelID,
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
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
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
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene and images.
        ///   Modified instance represents: Handle of the matching result, if enabled in ReturnResultHandle.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModelImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2069);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 2, err1);
            HPose hpose;
            int err3 = HPose.LoadNew(proc, 0, err2, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        /// <summary>Refine the pose of a surface model in a 3D scene and in images.</summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public static HPose[] RefineSurfaceModelPoseImage(
          HImage image,
          HSurfaceModel surfaceModelID,
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
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
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
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene and in images.
        ///   Modified instance represents: Handle of the matching result, if enabled in ReturnResultHandle.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPoseImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          HObjectModel3D objectModel3D,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2084);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 2, err1);
            HPose hpose;
            int err3 = HPose.LoadNew(proc, 0, err2, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            GC.KeepAlive((object)objectModel3D);
            return hpose;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1034);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
