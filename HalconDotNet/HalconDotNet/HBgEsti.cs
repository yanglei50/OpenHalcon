// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HBgEsti
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a background estimator.</summary>
    public class HBgEsti : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBgEsti()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBgEsti(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBgEsti obj)
        {
            obj = new HBgEsti(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBgEsti[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HBgEsti[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HBgEsti(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Generate and initialize a data set for the background estimation.
        ///   Modified instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="initializeImage">initialization image.</param>
        /// <param name="syspar1">1. system matrix parameter. Default: 0.7</param>
        /// <param name="syspar2">2. system matrix parameter. Default: 0.7</param>
        /// <param name="gainMode">Gain type. Default: "fixed"</param>
        /// <param name="gain1">Kalman gain / foreground adaptation time. Default: 0.002</param>
        /// <param name="gain2">Kalman gain / background adaptation time. Default: 0.02</param>
        /// <param name="adaptMode">Threshold adaptation. Default: "on"</param>
        /// <param name="minDiff">Foreground/background threshold. Default: 7.0</param>
        /// <param name="statNum">Number of statistic data sets. Default: 10</param>
        /// <param name="confidenceC">Confidence constant. Default: 3.25</param>
        /// <param name="timeC">Constant for decay time. Default: 15.0</param>
        public HBgEsti(
          HImage initializeImage,
          double syspar1,
          double syspar2,
          string gainMode,
          double gain1,
          double gain2,
          string adaptMode,
          double minDiff,
          int statNum,
          double confidenceC,
          double timeC)
        {
            IntPtr proc = HalconAPI.PreCall(2008);
            HalconAPI.Store(proc, 1, (HObjectBase)initializeImage);
            HalconAPI.StoreD(proc, 0, syspar1);
            HalconAPI.StoreD(proc, 1, syspar2);
            HalconAPI.StoreS(proc, 2, gainMode);
            HalconAPI.StoreD(proc, 3, gain1);
            HalconAPI.StoreD(proc, 4, gain2);
            HalconAPI.StoreS(proc, 5, adaptMode);
            HalconAPI.StoreD(proc, 6, minDiff);
            HalconAPI.StoreI(proc, 7, statNum);
            HalconAPI.StoreD(proc, 8, confidenceC);
            HalconAPI.StoreD(proc, 9, timeC);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)initializeImage);
        }

        /// <summary>
        ///   Return the estimated background image.
        ///   Instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <returns>Estimated background image of the current data set.</returns>
        public HImage GiveBgEsti()
        {
            IntPtr proc = HalconAPI.PreCall(2003);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Change the estimated background image.
        ///   Instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="presentImage">Current image.</param>
        /// <param name="upDateRegion">Region describing areas to change.</param>
        public void UpdateBgEsti(HImage presentImage, HRegion upDateRegion)
        {
            IntPtr proc = HalconAPI.PreCall(2004);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)presentImage);
            HalconAPI.Store(proc, 2, (HObjectBase)upDateRegion);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)presentImage);
            GC.KeepAlive((object)upDateRegion);
        }

        /// <summary>
        ///   Estimate the background and return the foreground region.
        ///   Instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="presentImage">Current image.</param>
        /// <returns>Region of the detected foreground.</returns>
        public HRegion RunBgEsti(HImage presentImage)
        {
            IntPtr proc = HalconAPI.PreCall(2005);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)presentImage);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)presentImage);
            return hregion;
        }

        /// <summary>
        ///   Return the parameters of the data set.
        ///   Instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="syspar2">2. system matrix parameter.</param>
        /// <param name="gainMode">Gain type.</param>
        /// <param name="gain1">Kalman gain / foreground adaptation time.</param>
        /// <param name="gain2">Kalman gain / background adaptation time.</param>
        /// <param name="adaptMode">Threshold adaptation.</param>
        /// <param name="minDiff">Foreground / background threshold.</param>
        /// <param name="statNum">Number of statistic data sets.</param>
        /// <param name="confidenceC">Confidence constant.</param>
        /// <param name="timeC">Constant for decay time.</param>
        /// <returns>1. system matrix parameter.</returns>
        public double GetBgEstiParams(
          out double syspar2,
          out string gainMode,
          out double gain1,
          out double gain2,
          out string adaptMode,
          out double minDiff,
          out int statNum,
          out double confidenceC,
          out double timeC)
        {
            IntPtr proc = HalconAPI.PreCall(2006);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out syspar2);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out gainMode);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out gain1);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out gain2);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out adaptMode);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out minDiff);
            int err9 = HalconAPI.LoadI(proc, 7, err8, out statNum);
            int err10 = HalconAPI.LoadD(proc, 8, err9, out confidenceC);
            int procResult = HalconAPI.LoadD(proc, 9, err10, out timeC);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Change the parameters of the data set.
        ///   Instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="syspar1">1. system matrix parameter. Default: 0.7</param>
        /// <param name="syspar2">2. system matrix parameter. Default: 0.7</param>
        /// <param name="gainMode">Gain type. Default: "fixed"</param>
        /// <param name="gain1">Kalman gain / foreground adaptation time. Default: 0.002</param>
        /// <param name="gain2">Kalman gain / background adaptation time. Default: 0.02</param>
        /// <param name="adaptMode">Threshold adaptation. Default: "on"</param>
        /// <param name="minDiff">Foreground/background threshold. Default: 7.0</param>
        /// <param name="statNum">Number of statistic data sets. Default: 10</param>
        /// <param name="confidenceC">Confidence constant. Default: 3.25</param>
        /// <param name="timeC">Constant for decay time. Default: 15.0</param>
        public void SetBgEstiParams(
          double syspar1,
          double syspar2,
          string gainMode,
          double gain1,
          double gain2,
          string adaptMode,
          double minDiff,
          int statNum,
          double confidenceC,
          double timeC)
        {
            IntPtr proc = HalconAPI.PreCall(2007);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, syspar1);
            HalconAPI.StoreD(proc, 2, syspar2);
            HalconAPI.StoreS(proc, 3, gainMode);
            HalconAPI.StoreD(proc, 4, gain1);
            HalconAPI.StoreD(proc, 5, gain2);
            HalconAPI.StoreS(proc, 6, adaptMode);
            HalconAPI.StoreD(proc, 7, minDiff);
            HalconAPI.StoreI(proc, 8, statNum);
            HalconAPI.StoreD(proc, 9, confidenceC);
            HalconAPI.StoreD(proc, 10, timeC);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Generate and initialize a data set for the background estimation.
        ///   Modified instance represents: ID of the BgEsti data set.
        /// </summary>
        /// <param name="initializeImage">initialization image.</param>
        /// <param name="syspar1">1. system matrix parameter. Default: 0.7</param>
        /// <param name="syspar2">2. system matrix parameter. Default: 0.7</param>
        /// <param name="gainMode">Gain type. Default: "fixed"</param>
        /// <param name="gain1">Kalman gain / foreground adaptation time. Default: 0.002</param>
        /// <param name="gain2">Kalman gain / background adaptation time. Default: 0.02</param>
        /// <param name="adaptMode">Threshold adaptation. Default: "on"</param>
        /// <param name="minDiff">Foreground/background threshold. Default: 7.0</param>
        /// <param name="statNum">Number of statistic data sets. Default: 10</param>
        /// <param name="confidenceC">Confidence constant. Default: 3.25</param>
        /// <param name="timeC">Constant for decay time. Default: 15.0</param>
        public void CreateBgEsti(
          HImage initializeImage,
          double syspar1,
          double syspar2,
          string gainMode,
          double gain1,
          double gain2,
          string adaptMode,
          double minDiff,
          int statNum,
          double confidenceC,
          double timeC)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2008);
            HalconAPI.Store(proc, 1, (HObjectBase)initializeImage);
            HalconAPI.StoreD(proc, 0, syspar1);
            HalconAPI.StoreD(proc, 1, syspar2);
            HalconAPI.StoreS(proc, 2, gainMode);
            HalconAPI.StoreD(proc, 3, gain1);
            HalconAPI.StoreD(proc, 4, gain2);
            HalconAPI.StoreS(proc, 5, adaptMode);
            HalconAPI.StoreD(proc, 6, minDiff);
            HalconAPI.StoreI(proc, 7, statNum);
            HalconAPI.StoreD(proc, 8, confidenceC);
            HalconAPI.StoreD(proc, 9, timeC);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)initializeImage);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2002);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
