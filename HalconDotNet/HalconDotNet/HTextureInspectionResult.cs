// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTextureInspectionResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a texture inspection result.</summary>
    public class HTextureInspectionResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextureInspectionResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextureInspectionResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HTextureInspectionResult obj)
        {
            obj = new HTextureInspectionResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HTextureInspectionResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HTextureInspectionResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HTextureInspectionResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Inspection of the texture within an image.
        ///   Modified instance represents: Handle of the inspection results.
        /// </summary>
        /// <param name="image">Image of the texture to be inspected.</param>
        /// <param name="noveltyRegion">Novelty regions.</param>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        public HTextureInspectionResult(
          HImage image,
          out HRegion noveltyRegion,
          HTextureInspectionModel textureInspectionModel)
        {
            IntPtr proc = HalconAPI.PreCall(2044);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)textureInspectionModel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HRegion.LoadNew(proc, 1, err2, out noveltyRegion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)textureInspectionModel);
        }

        /// <summary>Add training images to the texture inspection model.</summary>
        /// <param name="image">Image of flawless texture.</param>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        /// <returns>Indices of the images that have been added to the texture inspection model.</returns>
        public static HTuple AddTextureInspectionModelImage(
          HImage image,
          HTextureInspectionModel textureInspectionModel)
        {
            IntPtr proc = HalconAPI.PreCall(2043);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)textureInspectionModel);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)textureInspectionModel);
            return tuple;
        }

        /// <summary>
        ///   Inspection of the texture within an image.
        ///   Modified instance represents: Handle of the inspection results.
        /// </summary>
        /// <param name="image">Image of the texture to be inspected.</param>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        /// <returns>Novelty regions.</returns>
        public HRegion ApplyTextureInspectionModel(
          HImage image,
          HTextureInspectionModel textureInspectionModel)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2044);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)textureInspectionModel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err2, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)textureInspectionModel);
            return hregion;
        }

        /// <summary>Get the training images contained in a texture inspection model.</summary>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        /// <returns>Training images contained in the texture inspection model.</returns>
        public static HImage GetTextureInspectionModelImage(
          HTextureInspectionModel textureInspectionModel)
        {
            IntPtr proc = HalconAPI.PreCall(2075);
            HalconAPI.Store(proc, 0, (HTool)textureInspectionModel);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)textureInspectionModel);
            return himage;
        }

        /// <summary>
        ///   Query iconic results of a texture inspection.
        ///   Instance represents: Handle of the texture inspection result.
        /// </summary>
        /// <param name="resultName">Name of the iconic object to be returned. Default: "novelty_region"</param>
        /// <returns>Returned iconic object.</returns>
        public HObject GetTextureInspectionResultObject(HTuple resultName)
        {
            IntPtr proc = HalconAPI.PreCall(2077);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, resultName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(resultName);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Query iconic results of a texture inspection.
        ///   Instance represents: Handle of the texture inspection result.
        /// </summary>
        /// <param name="resultName">Name of the iconic object to be returned. Default: "novelty_region"</param>
        /// <returns>Returned iconic object.</returns>
        public HObject GetTextureInspectionResultObject(string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(2077);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, resultName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>Train a texture inspection model.</summary>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        public static void TrainTextureInspectionModel(HTextureInspectionModel textureInspectionModel)
        {
            IntPtr proc = HalconAPI.PreCall(2099);
            HalconAPI.Store(proc, 0, (HTool)textureInspectionModel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)textureInspectionModel);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2048);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
