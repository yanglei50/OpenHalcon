// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassGmm
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a Gaussian mixture model.</summary>
    [Serializable]
    public class HClassGmm : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassGmm()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassGmm(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassGmm obj)
        {
            obj = new HClassGmm(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassGmm[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassGmm[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassGmm(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a Gaussian Mixture Model from a file.
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HClassGmm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1828);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a Gaussian Mixture Model for classification
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature space. Default: 3</param>
        /// <param name="numClasses">Number of classes of the GMM. Default: 5</param>
        /// <param name="numCenters">Number of centers per class. Default: 1</param>
        /// <param name="covarType">Type of the covariance matrices. Default: "spherical"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the GMM with random values. Default: 42</param>
        public HClassGmm(
          int numDim,
          int numClasses,
          HTuple numCenters,
          string covarType,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            IntPtr proc = HalconAPI.PreCall(1840);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.StoreI(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numCenters);
            HalconAPI.StoreS(proc, 3, covarType);
            HalconAPI.StoreS(proc, 4, preprocessing);
            HalconAPI.StoreI(proc, 5, numComponents);
            HalconAPI.StoreI(proc, 6, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numCenters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a Gaussian Mixture Model for classification
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature space. Default: 3</param>
        /// <param name="numClasses">Number of classes of the GMM. Default: 5</param>
        /// <param name="numCenters">Number of centers per class. Default: 1</param>
        /// <param name="covarType">Type of the covariance matrices. Default: "spherical"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the GMM with random values. Default: 42</param>
        public HClassGmm(
          int numDim,
          int numClasses,
          int numCenters,
          string covarType,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            IntPtr proc = HalconAPI.PreCall(1840);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.StoreI(proc, 1, numClasses);
            HalconAPI.StoreI(proc, 2, numCenters);
            HalconAPI.StoreS(proc, 3, covarType);
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
            HSerializedItem hserializedItem = this.SerializeClassGmm();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassGmm(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassGmm(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassGmm().Serialize(stream);
        }

        public static HClassGmm Deserialize(Stream stream)
        {
            HClassGmm hclassGmm = new HClassGmm();
            hclassGmm.DeserializeClassGmm(HSerializedItem.Deserialize(stream));
            return hclassGmm;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassGmm Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassGmm();
            HClassGmm hclassGmm = new HClassGmm();
            hclassGmm.DeserializeClassGmm(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassGmm;
        }

        /// <summary>
        ///   Classify an image with a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="rejectionThreshold">Threshold for the rejection of the classification. Default: 0.5</param>
        /// <returns>Segmented classes.</returns>
        public HRegion ClassifyImageClassGmm(HImage image, double rejectionThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(431);
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
        ///   Add training samples from an image to the training data of a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="image">Training image.</param>
        /// <param name="classRegions">Regions of the classes to be trained.</param>
        /// <param name="randomize">Standard deviation of the Gaussian noise added to the training data. Default: 0.0</param>
        public void AddSamplesImageClassGmm(HImage image, HRegion classRegions, double randomize)
        {
            IntPtr proc = HalconAPI.PreCall(432);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)classRegions);
            HalconAPI.StoreD(proc, 1, randomize);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)classRegions);
        }

        /// <summary>
        ///   Get the training data of a Gaussian Mixture Model (GMM).
        ///   Instance represents: Handle of a GMM that contains training data.
        /// </summary>
        /// <returns>Handle of the training data of the classifier.</returns>
        public HClassTrainData GetClassTrainDataGmm()
        {
            IntPtr proc = HalconAPI.PreCall(1785);
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
        ///   Add training data to a Gaussian Mixture Model (GMM).
        ///   Instance represents: Handle of a GMM which receives the training data.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of training data for a classifier.</param>
        public void AddClassTrainDataGmm(HClassTrainData classTrainDataHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1786);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)classTrainDataHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
        }

        /// <summary>
        ///   Selects an optimal combination from a set of features to classify the  provided data.
        ///   Modified instance represents: A trained GMM classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains indices or names.</returns>
        public HTuple SelectFeatureSetGmm(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1801);
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
        ///   Selects an optimal combination from a set of features to classify the  provided data.
        ///   Modified instance represents: A trained GMM classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure  the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains indices or names.</returns>
        public HTuple SelectFeatureSetGmm(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1801);
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
        ///   Create a look-up table using a gaussian mixture model to classify byte images.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <returns>Handle of the LUT classifier.</returns>
        public HClassLUT CreateClassLutGmm(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1820);
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

        /// <summary>Clear the training data of a Gaussian Mixture Model.</summary>
        /// <param name="GMMHandle">GMM handle.</param>
        public static void ClearSamplesClassGmm(HClassGmm[] GMMHandle)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])GMMHandle);
            IntPtr proc = HalconAPI.PreCall(1825);
            HalconAPI.Store(proc, 0, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)GMMHandle);
        }

        /// <summary>
        ///   Clear the training data of a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        public void ClearSamplesClassGmm()
        {
            IntPtr proc = HalconAPI.PreCall(1825);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized Gaussian Mixture Model.
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassGmm(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1826);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a Gaussian Mixture Model (GMM).
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassGmm()
        {
            IntPtr proc = HalconAPI.PreCall(1827);
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
        ///   Read a Gaussian Mixture Model from a file.
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadClassGmm(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1828);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a Gaussian Mixture Model to a file.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteClassGmm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1829);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read the training data of a Gaussian Mixture Model from a file.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadSamplesClassGmm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1830);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write the training data of a Gaussian Mixture Model to a file.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteSamplesClassGmm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1831);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the class of a feature vector by a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="classProb">A-posteriori probability of the classes.</param>
        /// <param name="density">Probability density of the feature vector.</param>
        /// <param name="KSigmaProb">Normalized k-sigma-probability for the feature vector.</param>
        /// <returns>Result of classifying the feature vector with the GMM.</returns>
        public HTuple ClassifyClassGmm(
          HTuple features,
          int num,
          out HTuple classProb,
          out HTuple density,
          out HTuple KSigmaProb)
        {
            IntPtr proc = HalconAPI.PreCall(1832);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.StoreI(proc, 2, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out classProb);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out density);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out KSigmaProb);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Evaluate a feature vector by a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <param name="density">Probability density of the feature vector.</param>
        /// <param name="KSigmaProb">Normalized k-sigma-probability for the feature vector.</param>
        /// <returns>A-posteriori probability of the classes.</returns>
        public HTuple EvaluateClassGmm(
          HTuple features,
          out double density,
          out double KSigmaProb)
        {
            IntPtr proc = HalconAPI.PreCall(1833);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out density);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out KSigmaProb);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Train a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="maxIter">Maximum number of iterations of the expectation maximization algorithm Default: 100</param>
        /// <param name="threshold">Threshold for relative change of the error for the expectation maximization algorithm to terminate. Default: 0.001</param>
        /// <param name="classPriors">Mode to determine the a-priori probabilities of the classes Default: "training"</param>
        /// <param name="regularize">Regularization value for preventing covariance matrix singularity. Default: 0.0001</param>
        /// <param name="iter">Number of executed iterations per class</param>
        /// <returns>Number of found centers per class</returns>
        public HTuple TrainClassGmm(
          int maxIter,
          double threshold,
          string classPriors,
          double regularize,
          out HTuple iter)
        {
            IntPtr proc = HalconAPI.PreCall(1834);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, maxIter);
            HalconAPI.StoreD(proc, 2, threshold);
            HalconAPI.StoreS(proc, 3, classPriors);
            HalconAPI.StoreD(proc, 4, regularize);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out iter);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the information content of the preprocessed feature vectors of a GMM.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoClassGmm(string preprocessing, out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(1835);
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
        ///   Return the number of training samples stored in the training data of a Gaussian Mixture Model (GMM).
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <returns>Number of stored training samples.</returns>
        public int GetSampleNumClassGmm()
        {
            IntPtr proc = HalconAPI.PreCall(1836);
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
        ///   Return a training sample from the training data of a Gaussian Mixture Models (GMM).
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="numSample">Index of the stored training sample.</param>
        /// <param name="classID">Class of the training sample.</param>
        /// <returns>Feature vector of the training sample.</returns>
        public HTuple GetSampleClassGmm(int numSample, out int classID)
        {
            IntPtr proc = HalconAPI.PreCall(1837);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, numSample);
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
        ///   Add a training sample to the training data of a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="features">Feature vector of the training sample to be stored.</param>
        /// <param name="classID">Class of the training sample to be stored.</param>
        /// <param name="randomize">Standard deviation of the Gaussian noise added to the training data. Default: 0.0</param>
        public void AddSampleClassGmm(HTuple features, int classID, double randomize)
        {
            IntPtr proc = HalconAPI.PreCall(1838);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.StoreI(proc, 2, classID);
            HalconAPI.StoreD(proc, 3, randomize);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the parameters of a Gaussian Mixture Model.
        ///   Instance represents: GMM handle.
        /// </summary>
        /// <param name="numClasses">Number of classes of the GMM.</param>
        /// <param name="minCenters">Minimum number of centers per GMM class.</param>
        /// <param name="maxCenters">Maximum number of centers per GMM class.</param>
        /// <param name="covarType">Type of the covariance matrices.</param>
        /// <returns>Number of dimensions of the feature space.</returns>
        public int GetParamsClassGmm(
          out int numClasses,
          out HTuple minCenters,
          out HTuple maxCenters,
          out string covarType)
        {
            IntPtr proc = HalconAPI.PreCall(1839);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out numClasses);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out minCenters);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out maxCenters);
            int procResult = HalconAPI.LoadS(proc, 4, err5, out covarType);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Create a Gaussian Mixture Model for classification
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature space. Default: 3</param>
        /// <param name="numClasses">Number of classes of the GMM. Default: 5</param>
        /// <param name="numCenters">Number of centers per class. Default: 1</param>
        /// <param name="covarType">Type of the covariance matrices. Default: "spherical"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the GMM with random values. Default: 42</param>
        public void CreateClassGmm(
          int numDim,
          int numClasses,
          HTuple numCenters,
          string covarType,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1840);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.StoreI(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numCenters);
            HalconAPI.StoreS(proc, 3, covarType);
            HalconAPI.StoreS(proc, 4, preprocessing);
            HalconAPI.StoreI(proc, 5, numComponents);
            HalconAPI.StoreI(proc, 6, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numCenters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a Gaussian Mixture Model for classification
        ///   Modified instance represents: GMM handle.
        /// </summary>
        /// <param name="numDim">Number of dimensions of the feature space. Default: 3</param>
        /// <param name="numClasses">Number of classes of the GMM. Default: 5</param>
        /// <param name="numCenters">Number of centers per class. Default: 1</param>
        /// <param name="covarType">Type of the covariance matrices. Default: "spherical"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the GMM with random values. Default: 42</param>
        public void CreateClassGmm(
          int numDim,
          int numClasses,
          int numCenters,
          string covarType,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1840);
            HalconAPI.StoreI(proc, 0, numDim);
            HalconAPI.StoreI(proc, 1, numClasses);
            HalconAPI.StoreI(proc, 2, numCenters);
            HalconAPI.StoreS(proc, 3, covarType);
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
            IntPtr proc = HalconAPI.PreCall(1824);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
