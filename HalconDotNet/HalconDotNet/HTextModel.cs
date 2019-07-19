// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTextModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a text model for text segmentations.</summary>
    public class HTextModel : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextModel obj)
        {
            obj = new HTextModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HTextModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HTextModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        /// <param name="mode">The Mode of the text model. Default: "auto"</param>
        /// <param name="OCRClassifier">OCR Classifier. Default: "Universal_Rej.occ"</param>
        public HTextModel(string mode, HTuple OCRClassifier)
        {
            IntPtr proc = HalconAPI.PreCall(422);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, OCRClassifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(OCRClassifier);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        /// <param name="mode">The Mode of the text model. Default: "auto"</param>
        /// <param name="OCRClassifier">OCR Classifier. Default: "Universal_Rej.occ"</param>
        public HTextModel(string mode, string OCRClassifier)
        {
            IntPtr proc = HalconAPI.PreCall(422);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreS(proc, 1, OCRClassifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        public HTextModel()
        {
            IntPtr proc = HalconAPI.PreCall(423);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find text in an image.
        ///   Instance represents: Text model specifying the text to be segmented.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <returns>Result of the segmentation.</returns>
        public HTextResult FindText(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(417);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTextResult htextResult;
            int procResult = HTextResult.LoadNew(proc, 0, err, out htextResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return htextResult;
        }

        /// <summary>
        ///   Query parameters of a text model.
        ///   Instance represents: Text model.
        /// </summary>
        /// <param name="genParamName">Parameters to be queried. Default: "min_contrast"</param>
        /// <returns>Values of Parameters.</returns>
        public HTuple GetTextModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(418);
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
        ///   Set parameters of a text model.
        ///   Instance represents: Text model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set. Default: "min_contrast"</param>
        /// <param name="genParamValue">Values of the parameters to be set. Default: 10</param>
        public void SetTextModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(419);
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
        ///   Set parameters of a text model.
        ///   Instance represents: Text model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set. Default: "min_contrast"</param>
        /// <param name="genParamValue">Values of the parameters to be set. Default: 10</param>
        public void SetTextModelParam(string genParamName, int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(419);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreI(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        /// <param name="mode">The Mode of the text model. Default: "auto"</param>
        /// <param name="OCRClassifier">OCR Classifier. Default: "Universal_Rej.occ"</param>
        public void CreateTextModelReader(string mode, HTuple OCRClassifier)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(422);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, OCRClassifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(OCRClassifier);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        /// <param name="mode">The Mode of the text model. Default: "auto"</param>
        /// <param name="OCRClassifier">OCR Classifier. Default: "Universal_Rej.occ"</param>
        public void CreateTextModelReader(string mode, string OCRClassifier)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(422);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreS(proc, 1, OCRClassifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a text model.
        ///   Modified instance represents: New text model.
        /// </summary>
        public void CreateTextModel()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(423);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(421);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
