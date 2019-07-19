// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HFeatureSet
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a training used for the classifier.</summary>
    public class HFeatureSet : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HFeatureSet()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HFeatureSet(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFeatureSet obj)
        {
            obj = new HFeatureSet(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFeatureSet[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HFeatureSet[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HFeatureSet(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a training data set from a file.
        ///   Modified instance represents: Identification of the data set to train.
        /// </summary>
        /// <param name="fileName">Filename of the data set to train. Default: "sampset1"</param>
        public HFeatureSet(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1888);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a training data set from a file.
        ///   Modified instance represents: Identification of the data set to train.
        /// </summary>
        /// <param name="fileName">Filename of the data set to train. Default: "sampset1"</param>
        public void ReadSampset(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1888);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train the classifier with one data set.
        ///   Instance represents: Number of the data set to train.
        /// </summary>
        /// <param name="classifHandle">Handle of the classifier.</param>
        /// <param name="outfile">Name of the protocol file. Default: "training_prot"</param>
        /// <param name="NSamples">Number of arrays of attributes to learn. Default: 500</param>
        /// <param name="stopError">Classification error for termination. Default: 0.05</param>
        /// <param name="errorN">Error during the assignment. Default: 100</param>
        public void LearnSampsetBox(
          HClassBox classifHandle,
          string outfile,
          int NSamples,
          double stopError,
          int errorN)
        {
            IntPtr proc = HalconAPI.PreCall(1890);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)classifHandle);
            HalconAPI.StoreS(proc, 2, outfile);
            HalconAPI.StoreI(proc, 3, NSamples);
            HalconAPI.StoreD(proc, 4, stopError);
            HalconAPI.StoreI(proc, 5, errorN);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classifHandle);
        }

        /// <summary>
        ///   Classify a set of arrays.
        ///   Instance represents: Key of the test data.
        /// </summary>
        /// <param name="classifHandle">Handle of the classifier.</param>
        /// <returns>Error during the assignment.</returns>
        public double TestSampsetBox(HClassBox classifHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1897);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)classifHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classifHandle);
            return doubleValue;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1893);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
