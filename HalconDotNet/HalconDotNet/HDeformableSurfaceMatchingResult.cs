// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDeformableSurfaceMatchingResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a deformable surface matching result.</summary>
    public class HDeformableSurfaceMatchingResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableSurfaceMatchingResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableSurfaceMatchingResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDeformableSurfaceMatchingResult obj)
        {
            obj = new HDeformableSurfaceMatchingResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDeformableSurfaceMatchingResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDeformableSurfaceMatchingResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDeformableSurfaceMatchingResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Get details of a result from deformable surface based matching.
        ///   Instance represents: Handle of the deformable surface matching result.
        /// </summary>
        /// <param name="resultName">Name of the result property. Default: "sampled_scene"</param>
        /// <param name="resultIndex">Index of the result property. Default: 0</param>
        /// <returns>Value of the result property.</returns>
        public HTuple GetDeformableSurfaceMatchingResult(HTuple resultName, HTuple resultIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1019);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, resultName);
            HalconAPI.Store(proc, 2, resultIndex);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(resultName);
            HalconAPI.UnpinTuple(resultIndex);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get details of a result from deformable surface based matching.
        ///   Instance represents: Handle of the deformable surface matching result.
        /// </summary>
        /// <param name="resultName">Name of the result property. Default: "sampled_scene"</param>
        /// <param name="resultIndex">Index of the result property. Default: 0</param>
        /// <returns>Value of the result property.</returns>
        public HTuple GetDeformableSurfaceMatchingResult(string resultName, int resultIndex)
        {
            IntPtr proc = HalconAPI.PreCall(1019);
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

        /// <summary>Refine the position and deformation of a deformable surface model in a 3D scene.</summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the refined model.</returns>
        public static HTuple RefineDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1026);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)objectModel3D);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Refine the position and deformation of a deformable surface model in a 3D scene.
        ///   Modified instance represents: Handle of the matching result.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Score of the refined model.</returns>
        public double RefineDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          string genParamName,
          string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1026);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreS(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 1, err1);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err2, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)objectModel3D);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return doubleValue;
        }

        /// <summary>Find the best match of a deformable surface model in a 3D scene.</summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public static HTuple FindDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple minScore,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1027);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Find the best match of a deformable surface model in a 3D scene.
        ///   Modified instance represents: Handle of the matching result.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public double FindDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double minScore,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1027);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 1, err1);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err2, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)objectModel3D);
            return doubleValue;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1020);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
