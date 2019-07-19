// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HGnuplot
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a connection to a gnuplot process.</summary>
    public class HGnuplot : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HGnuplot()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HGnuplot(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HGnuplot obj)
        {
            obj = new HGnuplot(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HGnuplot[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HGnuplot[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HGnuplot(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Plot a function using gnuplot.
        ///   Instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        /// <param name="function">Function to be plotted.</param>
        public void GnuplotPlotFunct1d(HFunction1D function)
        {
            IntPtr proc = HalconAPI.PreCall(1295);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)function);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)function));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Plot control values using gnuplot.
        ///   Instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        /// <param name="values">Control values to be plotted (y-values).</param>
        public void GnuplotPlotCtrl(HTuple values)
        {
            IntPtr proc = HalconAPI.PreCall(1296);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, values);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(values);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Visualize images using gnuplot.
        ///   Instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        /// <param name="image">Image to be plotted.</param>
        /// <param name="samplesX">Number of samples in the x-direction. Default: 64</param>
        /// <param name="samplesY">Number of samples in the y-direction. Default: 64</param>
        /// <param name="viewRotX">Rotation of the plot about the x-axis. Default: 60</param>
        /// <param name="viewRotZ">Rotation of the plot about the z-axis. Default: 30</param>
        /// <param name="hidden3D">Plot the image with hidden surfaces removed. Default: "hidden3d"</param>
        public void GnuplotPlotImage(
          HImage image,
          int samplesX,
          int samplesY,
          HTuple viewRotX,
          HTuple viewRotZ,
          string hidden3D)
        {
            IntPtr proc = HalconAPI.PreCall(1297);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, samplesX);
            HalconAPI.StoreI(proc, 2, samplesY);
            HalconAPI.Store(proc, 3, viewRotX);
            HalconAPI.Store(proc, 4, viewRotZ);
            HalconAPI.StoreS(proc, 5, hidden3D);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(viewRotX);
            HalconAPI.UnpinTuple(viewRotZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Visualize images using gnuplot.
        ///   Instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        /// <param name="image">Image to be plotted.</param>
        /// <param name="samplesX">Number of samples in the x-direction. Default: 64</param>
        /// <param name="samplesY">Number of samples in the y-direction. Default: 64</param>
        /// <param name="viewRotX">Rotation of the plot about the x-axis. Default: 60</param>
        /// <param name="viewRotZ">Rotation of the plot about the z-axis. Default: 30</param>
        /// <param name="hidden3D">Plot the image with hidden surfaces removed. Default: "hidden3d"</param>
        public void GnuplotPlotImage(
          HImage image,
          int samplesX,
          int samplesY,
          double viewRotX,
          double viewRotZ,
          string hidden3D)
        {
            IntPtr proc = HalconAPI.PreCall(1297);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, samplesX);
            HalconAPI.StoreI(proc, 2, samplesY);
            HalconAPI.StoreD(proc, 3, viewRotX);
            HalconAPI.StoreD(proc, 4, viewRotZ);
            HalconAPI.StoreS(proc, 5, hidden3D);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Open a gnuplot file for visualization of images and control values.
        ///   Modified instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        /// <param name="fileName">Base name for control and data files.</param>
        public void GnuplotOpenFile(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1299);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a pipe to a gnuplot process for visualization of images and control values.
        ///   Modified instance represents: Identifier for the gnuplot output stream.
        /// </summary>
        public void GnuplotOpenPipe()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1300);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1298);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
