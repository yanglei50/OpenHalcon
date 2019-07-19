// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassBox
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a classifier.</summary>
    [Serializable]
    public class HClassBox : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassBox(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassBox obj)
        {
            obj = new HClassBox(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassBox[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassBox[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassBox(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a new classifier.
        ///   Modified instance represents: Handle of the classifier.
        /// </summary>
        public HClassBox()
        {
            IntPtr proc = HalconAPI.PreCall(1895);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeClassBox();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassBox(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassBox(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassBox().Serialize(stream);
        }

        public static HClassBox Deserialize(Stream stream)
        {
            HClassBox hclassBox = new HClassBox();
            hclassBox.DeserializeClassBox(HSerializedItem.Deserialize(stream));
            return hclassBox;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassBox Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassBox();
            HClassBox hclassBox = new HClassBox();
            hclassBox.DeserializeClassBox(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassBox;
        }

        /// <summary>
        ///   Train a classificator using a multi-channel image.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="foreground">Foreground pixels to be trained.</param>
        /// <param name="background">Background pixels to be trained (rejection class).</param>
        /// <param name="multiChannelImage">Multi-channel training image.</param>
        public void LearnNdimBox(HRegion foreground, HRegion background, HImage multiChannelImage)
        {
            IntPtr proc = HalconAPI.PreCall(438);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)foreground);
            HalconAPI.Store(proc, 2, (HObjectBase)background);
            HalconAPI.Store(proc, 3, (HObjectBase)multiChannelImage);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)foreground);
            GC.KeepAlive((object)background);
            GC.KeepAlive((object)multiChannelImage);
        }

        /// <summary>
        ///   Classify pixels using hyper-cuboids.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="multiChannelImage">Multi channel input image.</param>
        /// <returns>Classification result.</returns>
        public HRegion ClassNdimBox(HImage multiChannelImage)
        {
            IntPtr proc = HalconAPI.PreCall(439);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)multiChannelImage);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)multiChannelImage);
            return hregion;
        }

        /// <summary>
        ///   Deserialize a serialized classifier.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassBox(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1884);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)serializedItemHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a classifier.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassBox()
        {
            IntPtr proc = HalconAPI.PreCall(1885);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Save a classifier in a file.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="fileName">Name of the file which contains the written data.</param>
        public void WriteClassBox(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1886);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set system parameters for classification.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="flag">Name of the wanted parameter. Default: "split_error"</param>
        /// <param name="value">Value of the parameter. Default: 0.1</param>
        public void SetClassBoxParam(string flag, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(1887);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, flag);
            HalconAPI.Store(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set system parameters for classification.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="flag">Name of the wanted parameter. Default: "split_error"</param>
        /// <param name="value">Value of the parameter. Default: 0.1</param>
        public void SetClassBoxParam(string flag, double value)
        {
            IntPtr proc = HalconAPI.PreCall(1887);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, flag);
            HalconAPI.StoreD(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a classifier from a file.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="fileName">Filename of the classifier.</param>
        public void ReadClassBox(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1889);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train the classifier with one data set.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="sampKey">Number of the data set to train.</param>
        /// <param name="outfile">Name of the protocol file. Default: "training_prot"</param>
        /// <param name="NSamples">Number of arrays of attributes to learn. Default: 500</param>
        /// <param name="stopError">Classification error for termination. Default: 0.05</param>
        /// <param name="errorN">Error during the assignment. Default: 100</param>
        public void LearnSampsetBox(
          HFeatureSet sampKey,
          string outfile,
          int NSamples,
          double stopError,
          int errorN)
        {
            IntPtr proc = HalconAPI.PreCall(1890);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)sampKey);
            HalconAPI.StoreS(proc, 2, outfile);
            HalconAPI.StoreI(proc, 3, NSamples);
            HalconAPI.StoreD(proc, 4, stopError);
            HalconAPI.StoreI(proc, 5, errorN);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampKey);
        }

        /// <summary>
        ///   Train the classifier.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="features">Array of attributes to learn. Default: [1.0,1.5,2.0]</param>
        /// <param name="classVal">Class to which the array has to be assigned. Default: 1</param>
        public void LearnClassBox(HTuple features, int classVal)
        {
            IntPtr proc = HalconAPI.PreCall(1891);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.StoreI(proc, 2, classVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get information about the current parameter.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="flag">Name of the system parameter. Default: "split_error"</param>
        /// <returns>Value of the system parameter.</returns>
        public HTuple GetClassBoxParam(string flag)
        {
            IntPtr proc = HalconAPI.PreCall(1892);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, flag);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Create a new classifier.
        ///   Modified instance represents: Handle of the classifier.
        /// </summary>
        public void CreateClassBox()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1895);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Describe the classes of a box classifier.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="dimensions">Highest dimension for output. Default: 3</param>
        /// <param name="boxIdx">Indices of the boxes.</param>
        /// <param name="boxLowerBound">Lower bounds of the boxes (for each dimension).</param>
        /// <param name="boxHigherBound">Higher bounds of the boxes (for each dimension).</param>
        /// <param name="boxNumSamplesTrain">Number of training samples that were used to define this box (for each dimension).</param>
        /// <param name="boxNumSamplesWrong">Number of training samples that were assigned incorrectly to the box.</param>
        /// <returns>Indices of the classes.</returns>
        public HTuple DescriptClassBox(
          int dimensions,
          out HTuple boxIdx,
          out HTuple boxLowerBound,
          out HTuple boxHigherBound,
          out HTuple boxNumSamplesTrain,
          out HTuple boxNumSamplesWrong)
        {
            IntPtr proc = HalconAPI.PreCall(1896);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, dimensions);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out boxIdx);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out boxLowerBound);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out boxHigherBound);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out boxNumSamplesTrain);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out boxNumSamplesWrong);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Describe the classes of a box classifier.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="dimensions">Highest dimension for output. Default: 3</param>
        /// <param name="boxIdx">Indices of the boxes.</param>
        /// <param name="boxLowerBound">Lower bounds of the boxes (for each dimension).</param>
        /// <param name="boxHigherBound">Higher bounds of the boxes (for each dimension).</param>
        /// <param name="boxNumSamplesTrain">Number of training samples that were used to define this box (for each dimension).</param>
        /// <param name="boxNumSamplesWrong">Number of training samples that were assigned incorrectly to the box.</param>
        /// <returns>Indices of the classes.</returns>
        public int DescriptClassBox(
          int dimensions,
          out int boxIdx,
          out int boxLowerBound,
          out int boxHigherBound,
          out int boxNumSamplesTrain,
          out int boxNumSamplesWrong)
        {
            IntPtr proc = HalconAPI.PreCall(1896);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, dimensions);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out boxIdx);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out boxLowerBound);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out boxHigherBound);
            int err6 = HalconAPI.LoadI(proc, 4, err5, out boxNumSamplesTrain);
            int procResult = HalconAPI.LoadI(proc, 5, err6, out boxNumSamplesWrong);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Classify a set of arrays.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="sampKey">Key of the test data.</param>
        /// <returns>Error during the assignment.</returns>
        public double TestSampsetBox(HFeatureSet sampKey)
        {
            IntPtr proc = HalconAPI.PreCall(1897);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)sampKey);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sampKey);
            return doubleValue;
        }

        /// <summary>
        ///   Classify a tuple of attributes with rejection class.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="featureList">Array of attributes which has to be classified. Default: 1.0</param>
        /// <returns>Number of the class, to which the array of attributes had been assigned or -1 for the rejection class.</returns>
        public int EnquireRejectClassBox(HTuple featureList)
        {
            IntPtr proc = HalconAPI.PreCall(1898);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, featureList);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(featureList);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Classify a tuple of attributes.
        ///   Instance represents: Handle of the classifier.
        /// </summary>
        /// <param name="featureList">Array of attributes which has to be classified. Default: 1.0</param>
        /// <returns>Number of the class to which the array of attributes had been assigned.</returns>
        public int EnquireClassBox(HTuple featureList)
        {
            IntPtr proc = HalconAPI.PreCall(1899);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, featureList);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(featureList);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1894);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
