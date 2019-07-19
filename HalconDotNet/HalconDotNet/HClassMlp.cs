// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassMlp
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a multilayer perceptron.</summary>
    [Serializable]
    public class HClassMlp : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassMlp()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassMlp(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassMlp obj)
        {
            obj = new HClassMlp(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassMlp[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassMlp[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassMlp(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a multilayer perceptron from a file.
        ///   Modified instance represents: MLP handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HClassMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1867);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a multilayer perceptron for classification or regression.
        ///   Modified instance represents: MLP handle.
        /// </summary>
        /// <param name="numInput">Number of input variables (features) of the MLP. Default: 20</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 10</param>
        /// <param name="numOutput">Number of output variables (classes) of the MLP. Default: 5</param>
        /// <param name="outputFunction">Type of the activation function in the output layer of the MLP. Default: "softmax"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public HClassMlp(
          int numInput,
          int numHidden,
          int numOutput,
          string outputFunction,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            IntPtr proc = HalconAPI.PreCall(1883);
            HalconAPI.StoreI(proc, 0, numInput);
            HalconAPI.StoreI(proc, 1, numHidden);
            HalconAPI.StoreI(proc, 2, numOutput);
            HalconAPI.StoreS(proc, 3, outputFunction);
            HalconAPI.StoreS(proc, 4, preprocessing);
            HalconAPI.StoreI(proc, 5, numComponents);
            HalconAPI.StoreI(proc, 6, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeClassMlp();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassMlp(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassMlp(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassMlp().Serialize(stream);
        }

        public static HClassMlp Deserialize(Stream stream)
        {
            HClassMlp hclassMlp = new HClassMlp();
            hclassMlp.DeserializeClassMlp(HSerializedItem.Deserialize(stream));
            return hclassMlp;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassMlp Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassMlp();
            HClassMlp hclassMlp = new HClassMlp();
            hclassMlp.DeserializeClassMlp(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassMlp;
        }

        /// <summary>
        ///   Classify an image with a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="rejectionThreshold">Threshold for the rejection of the classification. Default: 0.5</param>
        /// <returns>Segmented classes.</returns>
        public HRegion ClassifyImageClassMlp(HImage image, double rejectionThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(435);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, rejectionThreshold);
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
        ///   Add training samples from an image to the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="image">Training image.</param>
        /// <param name="classRegions">Regions of the classes to be trained.</param>
        public void AddSamplesImageClassMlp(HImage image, HRegion classRegions)
        {
            IntPtr proc = HalconAPI.PreCall(436);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)classRegions);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)classRegions);
        }

        /// <summary>
        ///   Get the training data of a multilayer perceptron (MLP).
        ///   Instance represents: Handle of a MLP that contains training data.
        /// </summary>
        /// <returns>Handle of the training data of the classifier.</returns>
        public HClassTrainData GetClassTrainDataMlp()
        {
            IntPtr proc = HalconAPI.PreCall(1787);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HClassTrainData hclassTrainData;
            int procResult = HClassTrainData.LoadNew(proc, 0, err, out hclassTrainData);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassTrainData;
        }

        /// <summary>
        ///   Add training data to a multilayer perceptron (MLP).
        ///   Instance represents: MLP handle which receives the training data.
        /// </summary>
        /// <param name="classTrainDataHandle">Training data for a classifier.</param>
        public void AddClassTrainDataMlp(HClassTrainData classTrainDataHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1788);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)classTrainDataHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Modified instance represents: A trained MLP classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices referring.</returns>
        public HTuple SelectFeatureSetMlp(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1799);
            HalconAPI.Store(proc, 0, (HTool)classTrainDataHandle);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
            return tuple;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Modified instance represents: A trained MLP classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices referring.</returns>
        public HTuple SelectFeatureSetMlp(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1799);
            HalconAPI.Store(proc, 0, (HTool)classTrainDataHandle);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
            return tuple;
        }

        /// <summary>
        ///   Create a look-up table using a multi-layer perceptron to classify byte images.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <returns>Handle of the LUT classifier.</returns>
        public HClassLUT CreateClassLutMlp(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1822);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HClassLUT hclassLut;
            int procResult = HClassLUT.LoadNew(proc, 0, err, out hclassLut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassLut;
        }

        /// <summary>Clear the training data of a multilayer perceptron.</summary>
        /// <param name="MLPHandle">MLP handle.</param>
        public static void ClearSamplesClassMlp(HClassMlp[] MLPHandle)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])MLPHandle);
            IntPtr proc = HalconAPI.PreCall(1864);
            HalconAPI.Store(proc, 0, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)MLPHandle);
        }

        /// <summary>
        ///   Clear the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        public void ClearSamplesClassMlp()
        {
            IntPtr proc = HalconAPI.PreCall(1864);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized multilayer perceptron.
        ///   Modified instance represents: MLP handle.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassMlp(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1865);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a multilayer perceptron (MLP).
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassMlp()
        {
            IntPtr proc = HalconAPI.PreCall(1866);
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
        ///   Read a multilayer perceptron from a file.
        ///   Modified instance represents: MLP handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadClassMlp(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1867);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a multilayer perceptron to a file.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteClassMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1868);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read the training data of a multilayer perceptron from a file.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadSamplesClassMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1869);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write the training data of a multilayer perceptron to a file.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteSamplesClassMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1870);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the class of a feature vector by a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the feature vector.</param>
        /// <returns>Result of classifying the feature vector with the MLP.</returns>
        public HTuple ClassifyClassMlp(HTuple features, HTuple num, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(1871);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the class of a feature vector by a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the feature vector.</param>
        /// <returns>Result of classifying the feature vector with the MLP.</returns>
        public int ClassifyClassMlp(HTuple features, HTuple num, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(1871);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(num);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Calculate the evaluation of a feature vector by a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <returns>Result of evaluating the feature vector with the MLP.</returns>
        public HTuple EvaluateClassMlp(HTuple features)
        {
            IntPtr proc = HalconAPI.PreCall(1872);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Train a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="maxIterations">Maximum number of iterations of the optimization algorithm. Default: 200</param>
        /// <param name="weightTolerance">Threshold for the difference of the weights of the MLP between two iterations of the optimization algorithm. Default: 1.0</param>
        /// <param name="errorTolerance">Threshold for the difference of the mean error of the MLP on the training data between two iterations of the optimization algorithm. Default: 0.01</param>
        /// <param name="errorLog">Mean error of the MLP on the training data as a function of the number of iterations of the optimization algorithm.</param>
        /// <returns>Mean error of the MLP on the training data.</returns>
        public double TrainClassMlp(
          int maxIterations,
          double weightTolerance,
          double errorTolerance,
          out HTuple errorLog)
        {
            IntPtr proc = HalconAPI.PreCall(1873);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, maxIterations);
            HalconAPI.StoreD(proc, 2, weightTolerance);
            HalconAPI.StoreD(proc, 3, errorTolerance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out errorLog);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the information content of the preprocessed feature vectors of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoClassMlp(string preprocessing, out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(1874);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, preprocessing);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out cumInformationCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the number of training samples stored in the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <returns>Number of stored training samples.</returns>
        public int GetSampleNumClassMlp()
        {
            IntPtr proc = HalconAPI.PreCall(1875);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Return a training sample from the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="indexSample">Number of stored training sample.</param>
        /// <param name="target">Target vector of the training sample.</param>
        /// <returns>Feature vector of the training sample.</returns>
        public HTuple GetSampleClassMlp(int indexSample, out HTuple target)
        {
            IntPtr proc = HalconAPI.PreCall(1876);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, indexSample);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out target);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the parameters of a rejection class.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters to return. Default: "sampling_strategy"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetRejectionParamsClassMlp(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1877);
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
        ///   Get the parameters of a rejection class.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters to return. Default: "sampling_strategy"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetRejectionParamsClassMlp(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1877);
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
        ///   Set the parameters of a rejection class.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "sampling_strategy"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "hyperbox_around_all_classes"</param>
        public void SetRejectionParamsClassMlp(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1878);
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
        ///   Set the parameters of a rejection class.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "sampling_strategy"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "hyperbox_around_all_classes"</param>
        public void SetRejectionParamsClassMlp(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1878);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a training sample to the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="features">Feature vector of the training sample to be stored.</param>
        /// <param name="target">Class or target vector of the training sample to be stored.</param>
        public void AddSampleClassMlp(HTuple features, HTuple target)
        {
            IntPtr proc = HalconAPI.PreCall(1879);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, target);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(target);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a training sample to the training data of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="features">Feature vector of the training sample to be stored.</param>
        /// <param name="target">Class or target vector of the training sample to be stored.</param>
        public void AddSampleClassMlp(HTuple features, int target)
        {
            IntPtr proc = HalconAPI.PreCall(1879);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.StoreI(proc, 2, target);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the regularization parameters of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to return. Default: "weight_prior"</param>
        /// <returns>Value of the regularization parameter.</returns>
        public HTuple GetRegularizationParamsClassMlp(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1880);
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
        ///   Set the regularization parameters of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to set. Default: "weight_prior"</param>
        /// <param name="genParamValue">Value of the regularization parameter. Default: 1.0</param>
        public void SetRegularizationParamsClassMlp(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1881);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the regularization parameters of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to set. Default: "weight_prior"</param>
        /// <param name="genParamValue">Value of the regularization parameter. Default: 1.0</param>
        public void SetRegularizationParamsClassMlp(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1881);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the parameters of a multilayer perceptron.
        ///   Instance represents: MLP handle.
        /// </summary>
        /// <param name="numHidden">Number of hidden units of the MLP.</param>
        /// <param name="numOutput">Number of output variables (classes) of the MLP.</param>
        /// <param name="outputFunction">Type of the activation function in the output layer of the MLP.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features.</param>
        /// <returns>Number of input variables (features) of the MLP.</returns>
        public int GetParamsClassMlp(
          out int numHidden,
          out int numOutput,
          out string outputFunction,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(1882);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out numHidden);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out numOutput);
            int err5 = HalconAPI.LoadS(proc, 3, err4, out outputFunction);
            int err6 = HalconAPI.LoadS(proc, 4, err5, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 5, err6, out numComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Create a multilayer perceptron for classification or regression.
        ///   Modified instance represents: MLP handle.
        /// </summary>
        /// <param name="numInput">Number of input variables (features) of the MLP. Default: 20</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 10</param>
        /// <param name="numOutput">Number of output variables (classes) of the MLP. Default: 5</param>
        /// <param name="outputFunction">Type of the activation function in the output layer of the MLP. Default: "softmax"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public void CreateClassMlp(
          int numInput,
          int numHidden,
          int numOutput,
          string outputFunction,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1883);
            HalconAPI.StoreI(proc, 0, numInput);
            HalconAPI.StoreI(proc, 1, numHidden);
            HalconAPI.StoreI(proc, 2, numOutput);
            HalconAPI.StoreS(proc, 3, outputFunction);
            HalconAPI.StoreS(proc, 4, preprocessing);
            HalconAPI.StoreI(proc, 5, numComponents);
            HalconAPI.StoreI(proc, 6, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1863);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
