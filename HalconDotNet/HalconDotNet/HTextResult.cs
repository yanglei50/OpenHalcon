// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTextResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a text segmentations result.</summary>
    public class HTextResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextResult obj)
        {
            obj = new HTextResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HTextResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HTextResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Find text in an image.
        ///   Modified instance represents: Result of the segmentation.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="textModel">Text model specifying the text to be segmented.</param>
        public HTextResult(HImage image, HTextModel textModel)
        {
            IntPtr proc = HalconAPI.PreCall(417);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)textModel);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)textModel);
        }

        /// <summary>
        ///   Query an iconic value of a text segmentation result.
        ///   Instance represents: Text result.
        /// </summary>
        /// <param name="resultName">Name of the result to be returned. Default: "all_lines"</param>
        /// <returns>Returned result.</returns>
        public HObject GetTextObject(HTuple resultName)
        {
            IntPtr proc = HalconAPI.PreCall(415);
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
        ///   Query an iconic value of a text segmentation result.
        ///   Instance represents: Text result.
        /// </summary>
        /// <param name="resultName">Name of the result to be returned. Default: "all_lines"</param>
        /// <returns>Returned result.</returns>
        public HObject GetTextObject(string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(415);
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

        /// <summary>
        ///   Query a control value of a text segmentation result.
        ///   Instance represents: Text result.
        /// </summary>
        /// <param name="resultName">Name of the result to be returned. Default: "class"</param>
        /// <returns>Value of ResultName.</returns>
        public HTuple GetTextResult(HTuple resultName)
        {
            IntPtr proc = HalconAPI.PreCall(416);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, resultName);
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
        ///   Query a control value of a text segmentation result.
        ///   Instance represents: Text result.
        /// </summary>
        /// <param name="resultName">Name of the result to be returned. Default: "class"</param>
        /// <returns>Value of ResultName.</returns>
        public HTuple GetTextResult(string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(416);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, resultName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Find text in an image.
        ///   Modified instance represents: Result of the segmentation.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="textModel">Text model specifying the text to be segmented.</param>
        public void FindText(HImage image, HTextModel textModel)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(417);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)textModel);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)textModel);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(414);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
