// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HColorTransLUT
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a color space transformation lookup table</summary>
    public class HColorTransLUT : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HColorTransLUT()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HColorTransLUT(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HColorTransLUT obj)
        {
            obj = new HColorTransLUT(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HColorTransLUT[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HColorTransLUT[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HColorTransLUT(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Creates the look-up-table for transformation of an image from the RGB color space to an arbitrary color space.
        ///   Modified instance represents: Handle of the look-up-table for color space transformation.
        /// </summary>
        /// <param name="colorSpace">Color space of the output image. Default: "hsv"</param>
        /// <param name="transDirection">Direction of color space transformation. Default: "from_rgb"</param>
        /// <param name="numBits">Number of bits of the input image. Default: 8</param>
        public HColorTransLUT(string colorSpace, string transDirection, int numBits)
        {
            IntPtr proc = HalconAPI.PreCall(1579);
            HalconAPI.StoreS(proc, 0, colorSpace);
            HalconAPI.StoreS(proc, 1, transDirection);
            HalconAPI.StoreI(proc, 2, numBits);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Color space transformation using pre-generated look-up-table.
        ///   Instance represents: Handle of the look-up-table for the color space transformation.
        /// </summary>
        /// <param name="image1">Input image (channel 2).</param>
        /// <param name="image2">Input image (channel 2).</param>
        /// <param name="image3">Input image (channel 3).</param>
        /// <param name="imageResult2">Color-transformed output image (channel 2).</param>
        /// <param name="imageResult3">Color-transformed output image (channel 3).</param>
        /// <returns>Color-transformed output image (channel 1).</returns>
        public HImage ApplyColorTransLut(
          HImage image1,
          HImage image2,
          HImage image3,
          out HImage imageResult2,
          out HImage imageResult3)
        {
            IntPtr proc = HalconAPI.PreCall(1578);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 3, (HObjectBase)image3);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out imageResult2);
            int procResult = HImage.LoadNew(proc, 3, err3, out imageResult3);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            GC.KeepAlive((object)image3);
            return himage;
        }

        /// <summary>
        ///   Creates the look-up-table for transformation of an image from the RGB color space to an arbitrary color space.
        ///   Modified instance represents: Handle of the look-up-table for color space transformation.
        /// </summary>
        /// <param name="colorSpace">Color space of the output image. Default: "hsv"</param>
        /// <param name="transDirection">Direction of color space transformation. Default: "from_rgb"</param>
        /// <param name="numBits">Number of bits of the input image. Default: 8</param>
        public void CreateColorTransLut(string colorSpace, string transDirection, int numBits)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1579);
            HalconAPI.StoreS(proc, 0, colorSpace);
            HalconAPI.StoreS(proc, 1, transDirection);
            HalconAPI.StoreI(proc, 2, numBits);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1577);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
