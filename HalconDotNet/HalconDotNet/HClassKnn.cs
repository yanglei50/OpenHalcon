// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassKnn
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a k-NearestNeighbor classifier.</summary>
    [Serializable]
    public class HClassKnn : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassKnn()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassKnn(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassKnn obj)
        {
            obj = new HClassKnn(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassKnn[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassKnn[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassKnn(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read the k-NN classifier from a file.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="fileName">File name of the classifier.</param>
        public HClassKnn(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1809);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a k-nearest neighbors (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature. Default: 10</param>
        public HClassKnn(HTuple numDim)
        {
            IntPtr proc = HalconAPI.PreCall(1816);
            HalconAPI.Store(proc, 0, numDim);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numDim);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeClassKnn();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassKnn(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassKnn(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassKnn().Serialize(stream);
        }

        public static HClassKnn Deserialize(Stream stream)
        {
            HClassKnn hclassKnn = new HClassKnn();
            hclassKnn.DeserializeClassKnn(HSerializedItem.Deserialize(stream));
            return hclassKnn;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassKnn Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassKnn();
            HClassKnn hclassKnn = new HClassKnn();
            hclassKnn.DeserializeClassKnn(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassKnn;
        }

        /// <summary>
        ///   Classify an image with a k-Nearest-Neighbor classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="distanceImage">Distance of the pixel's nearest neighbor.</param>
        /// <param name="rejectionThreshold">Threshold for the rejection of the classification. Default: 0.5</param>
        /// <returns>Segmented classes.</returns>
        public HRegion ClassifyImageClassKnn(
          HImage image,
          out HImage distanceImage,
          double rejectionThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(429);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, rejectionThreshold);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HImage.LoadNew(proc, 2, err2, out distanceImage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Add training samples from an image to the training data of a k-Nearest-Neighbor classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="image">Training image.</param>
        /// <param name="classRegions">Regions of the classes to be trained.</param>
        public void AddSamplesImageClassKnn(HImage image, HRegion classRegions)
        {
            IntPtr proc = HalconAPI.PreCall(430);
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
        ///   Get the training data of a k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Handle of the k-NN classifier  that contains training data.
        /// </summary>
        /// <returns>Handle of the training data of the classifier.</returns>
        public HClassTrainData GetClassTrainDataKnn()
        {
            IntPtr proc = HalconAPI.PreCall(1789);
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
        ///   Add training data to a k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Handle of a k-NN which receives the  training data.
        /// </summary>
        /// <param name="classTrainDataHandle">Training data for a classifier.</param>
        public void AddClassTrainDataKnn(HClassTrainData classTrainDataHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1790);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)classTrainDataHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
        }

        /// <summary>
        ///   Selects an optimal subset from a set of features to solve a certain  classification problem.
        ///   Modified instance represents: A trained k-NN classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices or names.</returns>
        public HTuple SelectFeatureSetKnn(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1802);
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
        ///   Selects an optimal subset from a set of features to solve a certain  classification problem.
        ///   Modified instance represents: A trained k-NN classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices or names.</returns>
        public HTuple SelectFeatureSetKnn(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1802);
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
        ///   Return the number of training samples stored in the training data of a k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <returns>Number of stored training samples.</returns>
        public int GetSampleNumClassKnn()
        {
            IntPtr proc = HalconAPI.PreCall(1805);
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
        ///   Return a training sample from the training data of a k-nearest neighbors  (k-NN) classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="indexSample">Index of the training sample.</param>
        /// <param name="classID">Class of the training sample.</param>
        /// <returns>Feature vector of the training sample.</returns>
        public HTuple GetSampleClassKnn(int indexSample, out HTuple classID)
        {
            IntPtr proc = HalconAPI.PreCall(1806);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, indexSample);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out classID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Deserialize a serialized k-NN classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassKnn(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1807);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a k-NN classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassKnn()
        {
            IntPtr proc = HalconAPI.PreCall(1808);
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
        ///   Read the k-NN classifier from a file.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="fileName">File name of the classifier.</param>
        public void ReadClassKnn(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1809);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Save the k-NN classifier in a file.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="fileName">Name of the file in which the classifier will be written.</param>
        public void WriteClassKnn(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1810);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get parameters of a k-NN classification.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="genParamName">Names of the parameters that can be read from the k-NN classifier. Default: ["method","k"]</param>
        /// <returns>Values of the selected parameters.</returns>
        public HTuple GetParamsClassKnn(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1811);
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
        ///   Set parameters for k-NN classification.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the k-NN classifier. Default: ["method","k","max_num_classes"]</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the k-NN classifier. Default: ["classes_distance",5,1]</param>
        public void SetParamsClassKnn(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1812);
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
        ///   Search for the next neighbors for a given feature vector.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="features">Features that should be classified.</param>
        /// <param name="rating">A rating for the results. This value contains either a  distance, a frequency or a weighted frequency.</param>
        /// <returns>The classification result, either class IDs or sample  indices.</returns>
        public HTuple ClassifyClassKnn(HTuple features, out HTuple rating)
        {
            IntPtr proc = HalconAPI.PreCall(1813);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rating);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Creates the search trees for a k-NN classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        public void TrainClassKnn(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1814);
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
        ///   Add a sample to a  k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="features">List of features to add.</param>
        /// <param name="classID">Class IDs of the features.</param>
        public void AddSampleClassKnn(HTuple features, HTuple classID)
        {
            IntPtr proc = HalconAPI.PreCall(1815);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, classID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(classID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a sample to a  k-nearest neighbors (k-NN) classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="features">List of features to add.</param>
        /// <param name="classID">Class IDs of the features.</param>
        public void AddSampleClassKnn(double features, int classID)
        {
            IntPtr proc = HalconAPI.PreCall(1815);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, features);
            HalconAPI.StoreI(proc, 2, classID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a k-nearest neighbors (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature. Default: 10</param>
        public void CreateClassKnn(HTuple numDim)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1816);
            HalconAPI.Store(proc, 0, numDim);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numDim);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a look-up table using a k-nearest neighbors classifier (k-NN) to classify byte images.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <returns>Handle of the LUT classifier.</returns>
        public HClassLUT CreateClassLutKnn(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1819);
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

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1804);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
