// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HBeadInspectionModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of the data structure used to inspect beads.</summary>
    public class HBeadInspectionModel : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBeadInspectionModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBeadInspectionModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBeadInspectionModel obj)
        {
            obj = new HBeadInspectionModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HBeadInspectionModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HBeadInspectionModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HBeadInspectionModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a model to inspect beads or adhesive in images.
        ///   Modified instance represents: Handle for using and accessing the bead inspection  model.
        /// </summary>
        /// <param name="beadContour">XLD contour specifying the expected bead's shape and  position.</param>
        /// <param name="targetThickness">Optimal bead thickness. Default: 50</param>
        /// <param name="thicknessTolerance">Tolerance of bead's thickness with respect to  TargetThickness. Default: 15</param>
        /// <param name="positionTolerance">Tolerance of the bead's center position. Default: 15</param>
        /// <param name="polarity">The bead's polarity. Default: "light"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        public HBeadInspectionModel(
          HXLD beadContour,
          HTuple targetThickness,
          HTuple thicknessTolerance,
          HTuple positionTolerance,
          string polarity,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1985);
            HalconAPI.Store(proc, 1, (HObjectBase)beadContour);
            HalconAPI.Store(proc, 0, targetThickness);
            HalconAPI.Store(proc, 1, thicknessTolerance);
            HalconAPI.Store(proc, 2, positionTolerance);
            HalconAPI.StoreS(proc, 3, polarity);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(targetThickness);
            HalconAPI.UnpinTuple(thicknessTolerance);
            HalconAPI.UnpinTuple(positionTolerance);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)beadContour);
        }

        /// <summary>
        ///   Create a model to inspect beads or adhesive in images.
        ///   Modified instance represents: Handle for using and accessing the bead inspection  model.
        /// </summary>
        /// <param name="beadContour">XLD contour specifying the expected bead's shape and  position.</param>
        /// <param name="targetThickness">Optimal bead thickness. Default: 50</param>
        /// <param name="thicknessTolerance">Tolerance of bead's thickness with respect to  TargetThickness. Default: 15</param>
        /// <param name="positionTolerance">Tolerance of the bead's center position. Default: 15</param>
        /// <param name="polarity">The bead's polarity. Default: "light"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        public HBeadInspectionModel(
          HXLD beadContour,
          int targetThickness,
          int thicknessTolerance,
          int positionTolerance,
          string polarity,
          string genParamName,
          int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1985);
            HalconAPI.Store(proc, 1, (HObjectBase)beadContour);
            HalconAPI.StoreI(proc, 0, targetThickness);
            HalconAPI.StoreI(proc, 1, thicknessTolerance);
            HalconAPI.StoreI(proc, 2, positionTolerance);
            HalconAPI.StoreS(proc, 3, polarity);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreI(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)beadContour);
        }

        /// <summary>
        ///   Get the value of a parameter in a specific bead inspection model.
        ///   Instance represents: Handle of the bead inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that is queried. Default: "target_thickness"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetBeadInspectionParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1981);
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
        ///   Get the value of a parameter in a specific bead inspection model.
        ///   Instance represents: Handle of the bead inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that is queried. Default: "target_thickness"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetBeadInspectionParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1981);
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
        ///   Set parameters of the bead inspection model.
        ///   Instance represents: Handle of the bead inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that shall be adjusted for the specified bead inspection model. Default: "target_thickness"</param>
        /// <param name="genParamValue">Value of the model parameter that shall be adjusted for the specified bead inspection model. Default: 40</param>
        public void SetBeadInspectionParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1982);
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
        ///   Set parameters of the bead inspection model.
        ///   Instance represents: Handle of the bead inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter that shall be adjusted for the specified bead inspection model. Default: "target_thickness"</param>
        /// <param name="genParamValue">Value of the model parameter that shall be adjusted for the specified bead inspection model. Default: 40</param>
        public void SetBeadInspectionParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1982);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Inspect beads in an image, as defined by the bead inspection model.
        ///   Instance represents: Handle of the bead inspection model to be used.
        /// </summary>
        /// <param name="image">Image to apply bead inspection on.</param>
        /// <param name="rightContour">The detected right contour of the beads.</param>
        /// <param name="errorSegment">Detected error segments</param>
        /// <param name="errorType">Types of detected errors.</param>
        /// <returns>The detected left contour of the beads.</returns>
        public HXLD ApplyBeadInspectionModel(
          HImage image,
          out HXLD rightContour,
          out HXLD errorSegment,
          out HTuple errorType)
        {
            IntPtr proc = HalconAPI.PreCall(1983);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int err2 = HXLD.LoadNew(proc, 1, err1, out hxld);
            int err3 = HXLD.LoadNew(proc, 2, err2, out rightContour);
            int err4 = HXLD.LoadNew(proc, 3, err3, out errorSegment);
            int procResult = HTuple.LoadNew(proc, 0, err4, out errorType);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxld;
        }

        /// <summary>
        ///   Create a model to inspect beads or adhesive in images.
        ///   Modified instance represents: Handle for using and accessing the bead inspection  model.
        /// </summary>
        /// <param name="beadContour">XLD contour specifying the expected bead's shape and  position.</param>
        /// <param name="targetThickness">Optimal bead thickness. Default: 50</param>
        /// <param name="thicknessTolerance">Tolerance of bead's thickness with respect to  TargetThickness. Default: 15</param>
        /// <param name="positionTolerance">Tolerance of the bead's center position. Default: 15</param>
        /// <param name="polarity">The bead's polarity. Default: "light"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        public void CreateBeadInspectionModel(
          HXLD beadContour,
          HTuple targetThickness,
          HTuple thicknessTolerance,
          HTuple positionTolerance,
          string polarity,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1985);
            HalconAPI.Store(proc, 1, (HObjectBase)beadContour);
            HalconAPI.Store(proc, 0, targetThickness);
            HalconAPI.Store(proc, 1, thicknessTolerance);
            HalconAPI.Store(proc, 2, positionTolerance);
            HalconAPI.StoreS(proc, 3, polarity);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(targetThickness);
            HalconAPI.UnpinTuple(thicknessTolerance);
            HalconAPI.UnpinTuple(positionTolerance);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)beadContour);
        }

        /// <summary>
        ///   Create a model to inspect beads or adhesive in images.
        ///   Modified instance represents: Handle for using and accessing the bead inspection  model.
        /// </summary>
        /// <param name="beadContour">XLD contour specifying the expected bead's shape and  position.</param>
        /// <param name="targetThickness">Optimal bead thickness. Default: 50</param>
        /// <param name="thicknessTolerance">Tolerance of bead's thickness with respect to  TargetThickness. Default: 15</param>
        /// <param name="positionTolerance">Tolerance of the bead's center position. Default: 15</param>
        /// <param name="polarity">The bead's polarity. Default: "light"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bead inspection model. Default: []</param>
        public void CreateBeadInspectionModel(
          HXLD beadContour,
          int targetThickness,
          int thicknessTolerance,
          int positionTolerance,
          string polarity,
          string genParamName,
          int genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1985);
            HalconAPI.Store(proc, 1, (HObjectBase)beadContour);
            HalconAPI.StoreI(proc, 0, targetThickness);
            HalconAPI.StoreI(proc, 1, thicknessTolerance);
            HalconAPI.StoreI(proc, 2, positionTolerance);
            HalconAPI.StoreS(proc, 3, polarity);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreI(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)beadContour);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1984);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
