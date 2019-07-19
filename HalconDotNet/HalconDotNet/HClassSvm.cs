// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HClassSvm
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a support vector machine.</summary>
    [Serializable]
    public class HClassSvm : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassSvm()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassSvm(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassSvm obj)
        {
            obj = new HClassSvm(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassSvm[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HClassSvm[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HClassSvm(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a support vector machine from a file.
        ///   Modified instance represents: SVM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HClassSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1846);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a support vector machine for pattern classification.
        ///   Modified instance represents: SVM handle.
        /// </summary>
        /// <param name="numFeatures">Number of input variables (features) of the SVM. Default: 10</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. In case of RBF kernel the value for gamma@f$  Default: 0.02</param>
        /// <param name="nu">Regularisation constant of the SVM. Default: 0.05</param>
        /// <param name="numClasses">Number of classes. Default: 5</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public HClassSvm(
          int numFeatures,
          string kernelType,
          double kernelParam,
          double nu,
          int numClasses,
          string mode,
          string preprocessing,
          int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(1861);
            HalconAPI.StoreI(proc, 0, numFeatures);
            HalconAPI.StoreS(proc, 1, kernelType);
            HalconAPI.StoreD(proc, 2, kernelParam);
            HalconAPI.StoreD(proc, 3, nu);
            HalconAPI.StoreI(proc, 4, numClasses);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeClassSvm();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HClassSvm(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeClassSvm(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeClassSvm().Serialize(stream);
        }

        public static HClassSvm Deserialize(Stream stream)
        {
            HClassSvm hclassSvm = new HClassSvm();
            hclassSvm.DeserializeClassSvm(HSerializedItem.Deserialize(stream));
            return hclassSvm;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HClassSvm Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeClassSvm();
            HClassSvm hclassSvm = new HClassSvm();
            hclassSvm.DeserializeClassSvm(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hclassSvm;
        }

        /// <summary>
        ///   Classify an image with a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <returns>Segmented classes.</returns>
        public HRegion ClassifyImageClassSvm(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(433);
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
        ///   Add training samples from an image to the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="image">Training image.</param>
        /// <param name="classRegions">Regions of the classes to be trained.</param>
        public void AddSamplesImageClassSvm(HImage image, HRegion classRegions)
        {
            IntPtr proc = HalconAPI.PreCall(434);
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
        ///   Get the training data of a support vector machine (SVM).
        ///   Instance represents: Handle of a SVM that contains training data.
        /// </summary>
        /// <returns>Handle of the training data of the classifier.</returns>
        public HClassTrainData GetClassTrainDataSvm()
        {
            IntPtr proc = HalconAPI.PreCall(1791);
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
        ///   Add training data to a support vector machine (SVM).
        ///   Instance represents: Handle of a SVM which receives the training data.
        /// </summary>
        /// <param name="classTrainDataHandle">Training data for a classifier.</param>
        public void AddClassTrainDataSvm(HClassTrainData classTrainDataHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1792);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)classTrainDataHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)classTrainDataHandle);
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify the provided data.
        ///   Modified instance represents: A trained SVM classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices.</returns>
        public HTuple SelectFeatureSetSvm(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1800);
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
        ///   Modified instance represents: A trained SVM classifier using only the selected  features.
        /// </summary>
        /// <param name="classTrainDataHandle">Handle of the training data.</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="genParamName">Names of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the  selection process and the classifier. Default: []</param>
        /// <param name="score">The achieved score using two-fold cross-validation.</param>
        /// <returns>The selected feature set, contains  indices.</returns>
        public HTuple SelectFeatureSetSvm(
          HClassTrainData classTrainDataHandle,
          string selectionMethod,
          string genParamName,
          double genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1800);
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
        ///   Create a look-up table using a Support-Vector-Machine to classify byte images.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the LUT classifier creation. Default: []</param>
        /// <returns>Handle of the LUT classifier.</returns>
        public HClassLUT CreateClassLutSvm(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1821);
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

        /// <summary>Clear the training data of a support vector machine.</summary>
        /// <param name="SVMHandle">SVM handle.</param>
        public static void ClearSamplesClassSvm(HClassSvm[] SVMHandle)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])SVMHandle);
            IntPtr proc = HalconAPI.PreCall(1843);
            HalconAPI.Store(proc, 0, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)SVMHandle);
        }

        /// <summary>
        ///   Clear the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        public void ClearSamplesClassSvm()
        {
            IntPtr proc = HalconAPI.PreCall(1843);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized support vector machine (SVM).
        ///   Modified instance represents: SVM handle.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeClassSvm(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1844);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a support vector machine (SVM).
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeClassSvm()
        {
            IntPtr proc = HalconAPI.PreCall(1845);
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
        ///   Read a support vector machine from a file.
        ///   Modified instance represents: SVM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadClassSvm(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1846);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a support vector machine to a file.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteClassSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1847);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read the training data of a support vector machine from a file.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadSamplesClassSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1848);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write the training data of a support vector machine to a file.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteSamplesClassSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1849);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Evaluate a feature vector by a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <returns>Result of evaluating the feature vector with the SVM.</returns>
        public HTuple EvaluateClassSvm(HTuple features)
        {
            IntPtr proc = HalconAPI.PreCall(1850);
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
        ///   Classify a feature vector by a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="features">Feature vector.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <returns>Result of classifying the feature vector with the SVM.</returns>
        public HTuple ClassifyClassSvm(HTuple features, HTuple num)
        {
            IntPtr proc = HalconAPI.PreCall(1851);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, num);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Approximate a trained support vector machine by a reduced support vector machine for faster classification.
        ///   Instance represents: Original SVM handle.
        /// </summary>
        /// <param name="method">Type of postprocessing to reduce number of SV. Default: "bottom_up"</param>
        /// <param name="minRemainingSV">Minimum number of remaining SVs. Default: 2</param>
        /// <param name="maxError">Maximum allowed error of reduction. Default: 0.001</param>
        /// <returns>SVMHandle of reduced SVM.</returns>
        public HClassSvm ReduceClassSvm(string method, int minRemainingSV, double maxError)
        {
            IntPtr proc = HalconAPI.PreCall(1852);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreI(proc, 2, minRemainingSV);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HClassSvm hclassSvm;
            int procResult = HClassSvm.LoadNew(proc, 0, err, out hclassSvm);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hclassSvm;
        }

        /// <summary>
        ///   Train a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. For normal operation: 'default'. If SVs already included in the SVM should be used for training: 'add_sv_to_train_set'. For alpha seeding: the respective SVM handle. Default: "default"</param>
        public void TrainClassSvm(double epsilon, HTuple trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(1853);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, epsilon);
            HalconAPI.Store(proc, 2, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainMode);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. For normal operation: 'default'. If SVs already included in the SVM should be used for training: 'add_sv_to_train_set'. For alpha seeding: the respective SVM handle. Default: "default"</param>
        public void TrainClassSvm(double epsilon, string trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(1853);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, epsilon);
            HalconAPI.StoreS(proc, 2, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the information content of the preprocessed feature vectors of a support vector machine
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoClassSvm(string preprocessing, out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(1854);
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
        ///   Return the number of support vectors of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="numSVPerSVM">Number of SV of each sub-SVM.</param>
        /// <returns>Total number of support vectors.</returns>
        public int GetSupportVectorNumClassSvm(out HTuple numSVPerSVM)
        {
            IntPtr proc = HalconAPI.PreCall(1855);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out numSVPerSVM);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Return the index of a support vector from a trained support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="indexSupportVector">Number of stored support vectors.</param>
        /// <returns>Index of the support vector in the training set.</returns>
        public double GetSupportVectorClassSvm(HTuple indexSupportVector)
        {
            IntPtr proc = HalconAPI.PreCall(1856);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, indexSupportVector);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(indexSupportVector);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Return the number of training samples stored in the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <returns>Number of stored training samples.</returns>
        public int GetSampleNumClassSvm()
        {
            IntPtr proc = HalconAPI.PreCall(1857);
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
        ///   Return a training sample from the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="indexSample">Number of the stored training sample.</param>
        /// <param name="target">Target vector of the training sample.</param>
        /// <returns>Feature vector of the training sample.</returns>
        public HTuple GetSampleClassSvm(int indexSample, out int target)
        {
            IntPtr proc = HalconAPI.PreCall(1858);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, indexSample);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out target);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Add a training sample to the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="features">Feature vector of the training sample to be stored.</param>
        /// <param name="classVal">Class of the training sample to be stored.</param>
        public void AddSampleClassSvm(HTuple features, HTuple classVal)
        {
            IntPtr proc = HalconAPI.PreCall(1859);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.Store(proc, 2, classVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(classVal);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a training sample to the training data of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="features">Feature vector of the training sample to be stored.</param>
        /// <param name="classVal">Class of the training sample to be stored.</param>
        public void AddSampleClassSvm(HTuple features, int classVal)
        {
            IntPtr proc = HalconAPI.PreCall(1859);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, features);
            HalconAPI.StoreI(proc, 2, classVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the parameters of a support vector machine.
        ///   Instance represents: SVM handle.
        /// </summary>
        /// <param name="kernelType">The kernel type.</param>
        /// <param name="kernelParam">Additional parameter for the kernel.</param>
        /// <param name="nu">Regularization constant of the SVM.</param>
        /// <param name="numClasses">Number of classes of the test data.</param>
        /// <param name="mode">The mode of the SVM.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization').</param>
        /// <returns>Number of input variables (features) of the SVM.</returns>
        public int GetParamsClassSvm(
          out string kernelType,
          out double kernelParam,
          out double nu,
          out int numClasses,
          out string mode,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(1860);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadS(proc, 1, err2, out kernelType);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out kernelParam);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out nu);
            int err6 = HalconAPI.LoadI(proc, 4, err5, out numClasses);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out mode);
            int err8 = HalconAPI.LoadS(proc, 6, err7, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 7, err8, out numComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Create a support vector machine for pattern classification.
        ///   Modified instance represents: SVM handle.
        /// </summary>
        /// <param name="numFeatures">Number of input variables (features) of the SVM. Default: 10</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. In case of RBF kernel the value for gamma@f$  Default: 0.02</param>
        /// <param name="nu">Regularisation constant of the SVM. Default: 0.05</param>
        /// <param name="numClasses">Number of classes. Default: 5</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public void CreateClassSvm(
          int numFeatures,
          string kernelType,
          double kernelParam,
          double nu,
          int numClasses,
          string mode,
          string preprocessing,
          int numComponents)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1861);
            HalconAPI.StoreI(proc, 0, numFeatures);
            HalconAPI.StoreS(proc, 1, kernelType);
            HalconAPI.StoreD(proc, 2, kernelParam);
            HalconAPI.StoreD(proc, 3, nu);
            HalconAPI.StoreI(proc, 4, numClasses);
            HalconAPI.StoreS(proc, 5, mode);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1842);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
