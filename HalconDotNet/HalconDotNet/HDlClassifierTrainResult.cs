// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDlClassifierTrainResult
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a Deep Neural Network training step result.</summary>
    public class HDlClassifierTrainResult : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifierTrainResult()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifierTrainResult(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDlClassifierTrainResult obj)
        {
            obj = new HDlClassifierTrainResult(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDlClassifierTrainResult[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDlClassifierTrainResult[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDlClassifierTrainResult(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Perform a training step of a deep-learning-based classifier on a batch of  images.
        ///   Modified instance represents: Handle of the training results from the  deep-learning-based classifier.
        /// </summary>
        /// <param name="batchImages">Images comprising the batch.</param>
        /// <param name="DLClassifierHandle">Handle of the deep-learning-based classifier.</param>
        /// <param name="batchLabels">Corresponding labels for each of the images. Default: []</param>
        public HDlClassifierTrainResult(
          HImage batchImages,
          HDlClassifier DLClassifierHandle,
          HTuple batchLabels)
        {
            IntPtr proc = HalconAPI.PreCall(2131);
            HalconAPI.Store(proc, 1, (HObjectBase)batchImages);
            HalconAPI.Store(proc, 0, (HTool)DLClassifierHandle);
            HalconAPI.Store(proc, 1, batchLabels);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(batchLabels);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)batchImages);
            GC.KeepAlive((object)DLClassifierHandle);
        }

        /// <summary>
        ///   Return the results for the single training step of a deep-learning-based  classifier.
        ///   Instance represents: Handle of the training results from the  deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "loss"</param>
        /// <returns>Value of the generic parameter.</returns>
        public HTuple GetDlClassifierTrainResult(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2116);
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
        ///   Return the results for the single training step of a deep-learning-based  classifier.
        ///   Instance represents: Handle of the training results from the  deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "loss"</param>
        /// <returns>Value of the generic parameter.</returns>
        public HTuple GetDlClassifierTrainResult(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2116);
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
        ///   Perform a training step of a deep-learning-based classifier on a batch of  images.
        ///   Modified instance represents: Handle of the training results from the  deep-learning-based classifier.
        /// </summary>
        /// <param name="batchImages">Images comprising the batch.</param>
        /// <param name="DLClassifierHandle">Handle of the deep-learning-based classifier.</param>
        /// <param name="batchLabels">Corresponding labels for each of the images. Default: []</param>
        public void TrainDlClassifierBatch(
          HImage batchImages,
          HDlClassifier DLClassifierHandle,
          HTuple batchLabels)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2131);
            HalconAPI.Store(proc, 1, (HObjectBase)batchImages);
            HalconAPI.Store(proc, 0, (HTool)DLClassifierHandle);
            HalconAPI.Store(proc, 1, batchLabels);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(batchLabels);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)batchImages);
            GC.KeepAlive((object)DLClassifierHandle);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2105);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
