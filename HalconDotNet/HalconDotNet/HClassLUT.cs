// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassLUT
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a classification lookup table</summary>
    public class HClassLUT : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassLUT()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassLUT(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassLUT obj)
        {
            obj = new HClassLUT(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassLUT[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassLUT[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassLUT(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a look-up table using a k-nearest neighbors classifier (k-NN) to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="KNNHandle">Handle of the k-NN classifier.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public HClassLUT(HClassKnn KNNHandle, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1819);
            HalconAPI.Store(proc, 0, (HTool)KNNHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)KNNHandle);
        }

        /// <summary>
        ///   Create a look-up table using a gaussian mixture model to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="GMMHandle">GMM handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public HClassLUT(HClassGmm GMMHandle, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1820);
            HalconAPI.Store(proc, 0, (HTool)GMMHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)GMMHandle);
        }

        /// <summary>
        ///   Create a look-up table using a Support-Vector-Machine to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="SVMHandle">SVM handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public HClassLUT(HClassSvm SVMHandle, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1821);
            HalconAPI.Store(proc, 0, (HTool)SVMHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)SVMHandle);
        }

        /// <summary>
        ///   Create a look-up table using a multi-layer perceptron to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="MLPHandle">MLP handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public HClassLUT(HClassMlp MLPHandle, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1822);
            HalconAPI.Store(proc, 0, (HTool)MLPHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)MLPHandle);
        }

        /// <summary>
        ///   Classify a byte image using a look-up table.
        ///   Instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <returns>Segmented classes.</returns>
        public HRegion ClassifyImageClassLut(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(428);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Create a look-up table using a k-nearest neighbors classifier (k-NN) to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="KNNHandle">Handle of the k-NN classifier.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public void CreateClassLutKnn(HClassKnn KNNHandle, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1819);
            HalconAPI.Store(proc, 0, (HTool)KNNHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)KNNHandle);
        }

        /// <summary>
        ///   Create a look-up table using a gaussian mixture model to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="GMMHandle">GMM handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public void CreateClassLutGmm(HClassGmm GMMHandle, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1820);
            HalconAPI.Store(proc, 0, (HTool)GMMHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)GMMHandle);
        }

        /// <summary>
        ///   Create a look-up table using a Support-Vector-Machine to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="SVMHandle">SVM handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public void CreateClassLutSvm(HClassSvm SVMHandle, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1821);
            HalconAPI.Store(proc, 0, (HTool)SVMHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)SVMHandle);
        }

        /// <summary>
        ///   Create a look-up table using a multi-layer perceptron to classify byte images.
        ///   Modified instance represents: Handle of the LUT classifier.
        /// </summary>
        /// <param name="MLPHandle">MLP handle.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        public void CreateClassLutMlp(HClassMlp MLPHandle, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1822);
            HalconAPI.Store(proc, 0, (HTool)MLPHandle);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)MLPHandle);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1818);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
