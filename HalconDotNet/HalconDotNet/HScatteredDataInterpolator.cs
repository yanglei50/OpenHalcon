// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HScatteredDataInterpolator
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a scattered data interpolator.</summary>
    public class HScatteredDataInterpolator : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HScatteredDataInterpolator()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HScatteredDataInterpolator(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HScatteredDataInterpolator obj)
        {
            obj = new HScatteredDataInterpolator(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HScatteredDataInterpolator[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HScatteredDataInterpolator[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HScatteredDataInterpolator(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Creates an interpolator for the interpolation of scattered data.
        ///   Modified instance represents: Handle of the scattered data interpolator
        /// </summary>
        /// <param name="method">Method for the interpolation Default: "thin_plate_splines"</param>
        /// <param name="rows">Row coordinates of the points used  for the interpolation</param>
        /// <param name="columns">Column coordinates of the points used  for the interpolation</param>
        /// <param name="values">Values of the points used  for the interpolation</param>
        /// <param name="genParamName">Names of the generic parameters  that can be adjusted Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted Default: []</param>
        public HScatteredDataInterpolator(
          string method,
          HTuple rows,
          HTuple columns,
          HTuple values,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(292);
            HalconAPI.StoreS(proc, 0, method);
            HalconAPI.Store(proc, 1, rows);
            HalconAPI.Store(proc, 2, columns);
            HalconAPI.Store(proc, 3, values);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(columns);
            HalconAPI.UnpinTuple(values);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interpolation of scattered data using a scattered data interpolator.
        ///   Instance represents: Handle of the scattered data interpolator
        /// </summary>
        /// <param name="row">Row coordinates of points  to be interpolated</param>
        /// <param name="column">Column coordinates of points  to be interpolated</param>
        /// <returns>Values of interpolated points</returns>
        public HTuple InterpolateScatteredData(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(291);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Interpolation of scattered data using a scattered data interpolator.
        ///   Instance represents: Handle of the scattered data interpolator
        /// </summary>
        /// <param name="row">Row coordinates of points  to be interpolated</param>
        /// <param name="column">Column coordinates of points  to be interpolated</param>
        /// <returns>Values of interpolated points</returns>
        public double InterpolateScatteredData(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(291);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Creates an interpolator for the interpolation of scattered data.
        ///   Modified instance represents: Handle of the scattered data interpolator
        /// </summary>
        /// <param name="method">Method for the interpolation Default: "thin_plate_splines"</param>
        /// <param name="rows">Row coordinates of the points used  for the interpolation</param>
        /// <param name="columns">Column coordinates of the points used  for the interpolation</param>
        /// <param name="values">Values of the points used  for the interpolation</param>
        /// <param name="genParamName">Names of the generic parameters  that can be adjusted Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted Default: []</param>
        public void CreateScatteredDataInterpolator(
          string method,
          HTuple rows,
          HTuple columns,
          HTuple values,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(292);
            HalconAPI.StoreS(proc, 0, method);
            HalconAPI.Store(proc, 1, rows);
            HalconAPI.Store(proc, 2, columns);
            HalconAPI.Store(proc, 3, values);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(columns);
            HalconAPI.UnpinTuple(values);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(290);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
