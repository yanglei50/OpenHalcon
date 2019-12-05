// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDlClassifierResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a Deep Neural Network inference step result.</summary>
    public class HDlClassifierResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifierResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifierResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierResult obj)
        {
            obj = new HDlClassifierResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDlClassifierResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDlClassifierResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Infer the class affiliations for a set of images using the  deep-learning-based classifier.
        ///   Modified instance represents: Handle of the deep learning classification  results.
        /// </summary>
        /// <param name="images">Tuple of input images.</param>
        /// <param name="DLClassifierHandle">Handle of the deep-learning-based classifier.</param>
        public HDlClassifierResult(HImage images, HDlClassifier DLClassifierHandle)
        {
            IntPtr proc = HalconAPI.PreCall(2102);
            HalconAPI.Store(proc, 1, (HObjectBase)images);
            HalconAPI.Store(proc, 0, (HTool)DLClassifierHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)images);
            GC.KeepAlive((object)DLClassifierHandle);
        }

        /// <summary>
        ///   Retrieve classification results inferred by a deep-learning-based  classifier.
        ///   Instance represents: Handle of the deep learning classification  results.
        /// </summary>
        /// <param name="index">Index of the image in the batch. Default: "all"</param>
        /// <param name="genResultName">Name of the generic parameter. Default: "predicted_classes"</param>
        /// <returns>Value of the generic parameter, either the confidence  values, the class names or class indices.</returns>
        public HTuple GetDlClassifierResult(HTuple index, HTuple genResultName)
        {
            IntPtr proc = HalconAPI.PreCall(2115);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, genResultName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(genResultName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Retrieve classification results inferred by a deep-learning-based  classifier.
        ///   Instance represents: Handle of the deep learning classification  results.
        /// </summary>
        /// <param name="index">Index of the image in the batch. Default: "all"</param>
        /// <param name="genResultName">Name of the generic parameter. Default: "predicted_classes"</param>
        /// <returns>Value of the generic parameter, either the confidence  values, the class names or class indices.</returns>
        public HTuple GetDlClassifierResult(string index, string genResultName)
        {
            IntPtr proc = HalconAPI.PreCall(2115);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.StoreS(proc, 2, genResultName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2104);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
