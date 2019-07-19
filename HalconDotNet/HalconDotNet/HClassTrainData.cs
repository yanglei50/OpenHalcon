// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassTrainData
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a training data management class.</summary>
    [Serializable]
    public class HClassTrainData : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassTrainData()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassTrainData(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassTrainData obj)
        {
            obj = new HClassTrainData(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassTrainData[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassTrainData[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassTrainData(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read the training data for classifiers from a file.
        ///   Modified instance represents: Handle of the training data.
        /// </summary>
        /// <param name="fileName">File name of the training data.</param>
        public HClassTrainData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1781);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a handle for training data for classifiers.
        ///   Modified instance represents: Handle of the training data.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature vector. Default: 10</param>
        public HClassTrainData(int numDim)
        {
            IntPtr proc = HalconAPI.PreCall(1798);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeClassTrainData();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassTrainData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassTrainData(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassTrainData().Serialize(stream);
        }

        public static HClassTrainData Deserialize(Stream stream)
        {
            HClassTrainData hclassTrainData = new HClassTrainData();
            hclassTrainData.DeserializeClassTrainData(HSerializedItem.Deserialize(stream));
            return hclassTrainData;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassTrainData Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassTrainData();
            HClassTrainData hclassTrainData = new HClassTrainData();
            hclassTrainData.DeserializeClassTrainData(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassTrainData;
        }

        /// <summary>
        ///   Deserialize serialized training data for classifiers.
        ///   Modified instance represents: Handle of the training data.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassTrainData(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1779);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize training data for classifiers.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassTrainData()
        {
            IntPtr proc = HalconAPI.PreCall(1780);
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
        ///   Read the training data for classifiers from a file.
        ///   Modified instance represents: Handle of the training data.
        /// </summary>
        /// <param name="fileName">File name of the training data.</param>
        public void ReadClassTrainData(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1781);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Save the training data for classifiers in a file.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="fileName">Name of the file in which the training data will be written.</param>
        public void WriteClassTrainData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1782);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Select certain features from training data to create  training data containing less features.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="subFeatureIndices">Indices or names to select the subfeatures or columns.</param>
        /// <returns>Handle of the reduced training data.</returns>
        public HClassTrainData SelectSubFeatureClassTrainData(HTuple subFeatureIndices)
        {
            IntPtr proc = HalconAPI.PreCall(1783);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, subFeatureIndices);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subFeatureIndices);
            HClassTrainData hclassTrainData;
            int procResult = HClassTrainData.LoadNew(proc, 0, err, out hclassTrainData);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassTrainData;
        }

        /// <summary>
        ///   Define subfeatures in training data.
        ///   Instance represents: Handle of the training data that should be  partitioned into subfeatures.
        /// </summary>
        /// <param name="subFeatureLength">Length of the subfeatures.</param>
        /// <param name="names">Names of the subfeatures.</param>
        public void SetFeatureLengthsClassTrainData(HTuple subFeatureLength, HTuple names)
        {
            IntPtr proc = HalconAPI.PreCall(1784);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, subFeatureLength);
            HalconAPI.Store(proc, 2, names);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subFeatureLength);
            HalconAPI.UnpinTuple(names);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the training data of a Gaussian Mixture Model (GMM).
        ///   Modified instance represents: Handle of the training data of the classifier.
        /// </summary>
        /// <param name="GMMHandle">Handle of a GMM that contains training data.</param>
        public void GetClassTrainDataGmm(HClassGmm GMMHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1785);
            HalconAPI.Store(proc, 0, (HTool)GMMHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)GMMHandle);
        }

        /// <summary>
        ///   Add training data to a Gaussian Mixture Model (GMM).
        ///   Instance represents: Handle of training data for a classifier.
        /// </summary>
        /// <param name="GMMHandle">Handle of a GMM which receives the training data.</param>
        public void AddClassTrainDataGmm(HClassGmm GMMHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1786);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)GMMHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)GMMHandle);
        }

        /// <summary>
        ///   Get the training data of a multilayer perceptron (MLP).
        ///   Modified instance represents: Handle of the training data of the classifier.
        /// </summary>
        /// <param name="MLPHandle">Handle of a MLP that contains training data.</param>
        public void GetClassTrainDataMlp(HClassMlp MLPHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1787);
            HalconAPI.Store(proc, 0, (HTool)MLPHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)MLPHandle);
        }

        /// <summary>
        ///   Add training data to a multilayer perceptron (MLP).
        ///   Instance represents: Training data for a classifier.
        /// </summary>
        /// <param name="MLPHandle">MLP handle which receives the training data.</param>
        public void AddClassTrainDataMlp(HClassMlp MLPHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1788);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)MLPHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)MLPHandle);
        }

        /// <summary>
        ///   Get the training data of a k-nearest neighbors (k-NN) classifier.
        ///   Modified instance represents: Handle of the training data of the classifier.
        /// </summary>
        /// <param name="KNNHandle">Handle of the k-NN classifier  that contains training data.</param>
        public void GetClassTrainDataKnn(HClassKnn KNNHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1789);
            HalconAPI.Store(proc, 0, (HTool)KNNHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)KNNHandle);
        }

        /// <summary>
        ///   Add training data to a k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Training data for a classifier.
        /// </summary>
        /// <param name="KNNHandle">Handle of a k-NN which receives the  training data.</param>
        public void AddClassTrainDataKnn(HClassKnn KNNHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1790);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)KNNHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)KNNHandle);
        }

        /// <summary>
        ///   Get the training data of a support vector machine (SVM).
        ///   Modified instance represents: Handle of the training data of the classifier.
        /// </summary>
        /// <param name="SVMHandle">Handle of a SVM that contains training data.</param>
        public void GetClassTrainDataSvm(HClassSvm SVMHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1791);
            HalconAPI.Store(proc, 0, (HTool)SVMHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)SVMHandle);
        }

        /// <summary>
        ///   Add training data to a support vector machine (SVM).
        ///   Instance represents: Training data for a classifier.
        /// </summary>
        /// <param name="SVMHandle">Handle of a SVM which receives the training data.</param>
        public void AddClassTrainDataSvm(HClassSvm SVMHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1792);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)SVMHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)SVMHandle);
        }

        /// <summary>
        ///   Return the number of training samples stored in the training data.
        ///   Instance represents: Handle of training data.
        /// </summary>
        /// <returns>Number of stored training samples.</returns>
        public int GetSampleNumClassTrainData()
        {
            IntPtr proc = HalconAPI.PreCall(1793);
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
        ///   Return a training sample from training data.
        ///   Instance represents: Handle of training data for a classifier.
        /// </summary>
        /// <param name="indexSample">Number of stored training sample.</param>
        /// <param name="classID">Class of the training sample.</param>
        /// <returns>Feature vector of the training sample.</returns>
        public HTuple GetSampleClassTrainData(int indexSample, out int classID)
        {
            IntPtr proc = HalconAPI.PreCall(1794);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, indexSample);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out classID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Add a training sample to training data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="order">The order of the feature vector. Default: "row"</param>
        /// <param name="features">Feature vector of the training sample.</param>
        /// <param name="classID">Class of the training sample.</param>
        public void AddSampleClassTrainData(string order, HTuple features, HTuple classID)
        {
            IntPtr proc = HalconAPI.PreCall(1797);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, order);
            HalconAPI.Store(proc, 2, features);
            HalconAPI.Store(proc, 3, classID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(classID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a handle for training data for classifiers.
        ///   Modified instance represents: Handle of the training data.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature vector. Default: 10</param>
        public void CreateClassTrainData(int numDim)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1798);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices referring.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained MLP classifier using only the selected  features.</returns>
        public HClassMlp SelectFeatureSetMlp(
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1799);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HClassMlp hclassMlp;
            int err2 = HClassMlp.LoadNew(proc, 0, err1, out hclassMlp);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassMlp;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices referring.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained MLP classifier using only the selected  features.</returns>
        public HClassMlp SelectFeatureSetMlp(
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1799);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HClassMlp hclassMlp;
            int err2 = HClassMlp.LoadNew(proc, 0, err1, out hclassMlp);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassMlp;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained SVM classifier using only the selected  features.</returns>
        public HClassSvm SelectFeatureSetSvm(
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1800);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HClassSvm hclassSvm;
            int err2 = HClassSvm.LoadNew(proc, 0, err1, out hclassSvm);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassSvm;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained SVM classifier using only the selected  features.</returns>
        public HClassSvm SelectFeatureSetSvm(
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1800);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HClassSvm hclassSvm;
            int err2 = HClassSvm.LoadNew(proc, 0, err1, out hclassSvm);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassSvm;
        }

        /// <summary>
        ///   Selects an optimal combination from a set of features to classify the  provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains indices or names.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained GMM classifier using only the selected  features.</returns>
        public HClassGmm SelectFeatureSetGmm(
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1801);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HClassGmm hclassGmm;
            int err2 = HClassGmm.LoadNew(proc, 0, err1, out hclassGmm);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassGmm;
        }

        /// <summary>
        ///   Selects an optimal combination from a set of features to classify the  provided data.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains indices or names.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained GMM classifier using only the selected  features.</returns>
        public HClassGmm SelectFeatureSetGmm(
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1801);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HClassGmm hclassGmm;
            int err2 = HClassGmm.LoadNew(proc, 0, err1, out hclassGmm);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassGmm;
        }

        /// <summary>
        ///   Selects an optimal subset from a set of features to solve a certain  classification problem.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices or names.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained k-NN classifier using only the selected  features.</returns>
        public HClassKnn SelectFeatureSetKnn(
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1802);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HClassKnn hclassKnn;
            int err2 = HClassKnn.LoadNew(proc, 0, err1, out hclassKnn);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassKnn;
        }

        /// <summary>
        ///   Selects an optimal subset from a set of features to solve a certain  classification problem.
        ///   Instance represents: Handle of the training data.
        /// </summary>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="selectedFeatureIndices">The selected feature set, contains  indices or names.</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>A trained k-NN classifier using only the selected  features.</returns>
        public HClassKnn SelectFeatureSetKnn(
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple selectedFeatureIndices,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1802);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, selectionMethod);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HClassKnn hclassKnn;
            int err2 = HClassKnn.LoadNew(proc, 0, err1, out hclassKnn);
            int err3 = HTuple.LoadNew(proc, 1, err2, out selectedFeatureIndices);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassKnn;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1796);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
