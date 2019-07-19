// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCRSvm
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a SVM OCR classifier.</summary>
    [Serializable]
    public class HOCRSvm : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRSvm()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRSvm(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRSvm obj)
        {
            obj = new HOCRSvm(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRSvm[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HOCRSvm[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HOCRSvm(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a SVM-based OCR classifier from a file.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HOCRSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(676);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a support vector machine.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. Default: 0.02</param>
        /// <param name="nu">Regularization constant of the SVM. Default: 0.05</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public HOCRSvm(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          string kernelType,
          double kernelParam,
          double nu,
          string mode,
          string preprocessing,
          int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(689);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreS(proc, 5, kernelType);
            HalconAPI.StoreD(proc, 6, kernelParam);
            HalconAPI.StoreD(proc, 7, nu);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, preprocessing);
            HalconAPI.StoreI(proc, 10, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a support vector machine.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. Default: 0.02</param>
        /// <param name="nu">Regularization constant of the SVM. Default: 0.05</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public HOCRSvm(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          string kernelType,
          double kernelParam,
          double nu,
          string mode,
          string preprocessing,
          int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(689);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreS(proc, 5, kernelType);
            HalconAPI.StoreD(proc, 6, kernelParam);
            HalconAPI.StoreD(proc, 7, nu);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, preprocessing);
            HalconAPI.StoreI(proc, 10, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeOcrClassSvm();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRSvm(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeOcrClassSvm(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeOcrClassSvm().Serialize(stream);
        }

        public static HOCRSvm Deserialize(Stream stream)
        {
            HOCRSvm hocrSvm = new HOCRSvm();
            hocrSvm.DeserializeOcrClassSvm(HSerializedItem.Deserialize(stream));
            return hocrSvm;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HOCRSvm Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeOcrClassSvm();
            HOCRSvm hocrSvm = new HOCRSvm();
            hocrSvm.DeserializeOcrClassSvm(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hocrSvm;
        }

        /// <summary>
        ///   Select an optimal combination of features to classify OCR data from a (protected) training file.
        ///   Modified instance represents: Trained OCR-SVM Classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="featureList">List of features that should be considered for selection. Default: ["zoom_factor","ratio","width","height","foreground","foreground_grid_9","foreground_grid_16","anisometry","compactness","convexity","moments_region_2nd_invar","moments_region_2nd_rel_invar","moments_region_3rd_invar","moments_central","phi","num_connect","num_holes","projection_horizontal","projection_vertical","projection_horizontal_invar","projection_vertical_invar","chord_histo","num_runs","pixel","pixel_invar","pixel_binary","gradient_8dir","cooc","moments_gray_plane"]</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="width">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 15</param>
        /// <param name="height">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 16</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="score">Achieved score using tow-fold cross-validation.</param>
        /// <returns>Selected feature set, contains only entries from FeatureList.</returns>
        public HTuple SelectFeatureSetTrainfSvmProtected(
          HTuple trainingFile,
          HTuple password,
          HTuple featureList,
          string selectionMethod,
          int width,
          int height,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(663);
            HalconAPI.Store(proc, 0, trainingFile);
            HalconAPI.Store(proc, 1, password);
            HalconAPI.Store(proc, 2, featureList);
            HalconAPI.StoreS(proc, 3, selectionMethod);
            HalconAPI.StoreI(proc, 4, width);
            HalconAPI.StoreI(proc, 5, height);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(password);
            HalconAPI.UnpinTuple(featureList);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select an optimal combination of features to classify OCR data from a (protected) training file.
        ///   Modified instance represents: Trained OCR-SVM Classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="featureList">List of features that should be considered for selection. Default: ["zoom_factor","ratio","width","height","foreground","foreground_grid_9","foreground_grid_16","anisometry","compactness","convexity","moments_region_2nd_invar","moments_region_2nd_rel_invar","moments_region_3rd_invar","moments_central","phi","num_connect","num_holes","projection_horizontal","projection_vertical","projection_horizontal_invar","projection_vertical_invar","chord_histo","num_runs","pixel","pixel_invar","pixel_binary","gradient_8dir","cooc","moments_gray_plane"]</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="width">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 15</param>
        /// <param name="height">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 16</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="score">Achieved score using tow-fold cross-validation.</param>
        /// <returns>Selected feature set, contains only entries from FeatureList.</returns>
        public HTuple SelectFeatureSetTrainfSvmProtected(
          string trainingFile,
          string password,
          string featureList,
          string selectionMethod,
          int width,
          int height,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(663);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.StoreS(proc, 1, password);
            HalconAPI.StoreS(proc, 2, featureList);
            HalconAPI.StoreS(proc, 3, selectionMethod);
            HalconAPI.StoreI(proc, 4, width);
            HalconAPI.StoreI(proc, 5, height);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
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
            return tuple;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify OCR  data.
        ///   Modified instance represents: Trained OCR-SVM Classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="featureList">List of features that should be considered for selection. Default: ["zoom_factor","ratio","width","height","foreground","foreground_grid_9","foreground_grid_16","anisometry","compactness","convexity","moments_region_2nd_invar","moments_region_2nd_rel_invar","moments_region_3rd_invar","moments_central","phi","num_connect","num_holes","projection_horizontal","projection_vertical","projection_horizontal_invar","projection_vertical_invar","chord_histo","num_runs","pixel","pixel_invar","pixel_binary","gradient_8dir","cooc","moments_gray_plane"]</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="width">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 15</param>
        /// <param name="height">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 16</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="score">Achieved score using tow-fold cross-validation.</param>
        /// <returns>Selected feature set, contains only entries from FeatureList.</returns>
        public HTuple SelectFeatureSetTrainfSvm(
          HTuple trainingFile,
          HTuple featureList,
          string selectionMethod,
          int width,
          int height,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(664);
            HalconAPI.Store(proc, 0, trainingFile);
            HalconAPI.Store(proc, 1, featureList);
            HalconAPI.StoreS(proc, 2, selectionMethod);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(featureList);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Selects an optimal combination of features to classify OCR  data.
        ///   Modified instance represents: Trained OCR-SVM Classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="featureList">List of features that should be considered for selection. Default: ["zoom_factor","ratio","width","height","foreground","foreground_grid_9","foreground_grid_16","anisometry","compactness","convexity","moments_region_2nd_invar","moments_region_2nd_rel_invar","moments_region_3rd_invar","moments_central","phi","num_connect","num_holes","projection_horizontal","projection_vertical","projection_horizontal_invar","projection_vertical_invar","chord_histo","num_runs","pixel","pixel_invar","pixel_binary","gradient_8dir","cooc","moments_gray_plane"]</param>
        /// <param name="selectionMethod">Method to perform the selection. Default: "greedy"</param>
        /// <param name="width">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 15</param>
        /// <param name="height">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 16</param>
        /// <param name="genParamName">Names of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="genParamValue">Values of generic parameters to configure the selection process and the classifier. Default: []</param>
        /// <param name="score">Achieved score using tow-fold cross-validation.</param>
        /// <returns>Selected feature set, contains only entries from FeatureList.</returns>
        public HTuple SelectFeatureSetTrainfSvm(
          string trainingFile,
          string featureList,
          string selectionMethod,
          int width,
          int height,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(664);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.StoreS(proc, 1, featureList);
            HalconAPI.StoreS(proc, 2, selectionMethod);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
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
            return tuple;
        }

        /// <summary>
        ///   Deserialize a serialized SVM-based OCR classifier.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeOcrClassSvm(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(674);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a SVM-based OCR classifier
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeOcrClassSvm()
        {
            IntPtr proc = HalconAPI.PreCall(675);
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
        ///   Read a SVM-based OCR classifier from a file.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadOcrClassSvm(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(676);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write an OCR classifier to a file.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteOcrClassSvm(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(677);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the features of a character.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Input character.</param>
        /// <param name="transform">Should the feature vector be transformed with the preprocessing? Default: "true"</param>
        /// <returns>Feature vector of the character.</returns>
        public HTuple GetFeaturesOcrClassSvm(HImage character, string transform)
        {
            IntPtr proc = HalconAPI.PreCall(678);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.StoreS(proc, 1, transform);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            return tuple;
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the SVM.</returns>
        public HTuple DoOcrWordSvm(
          HRegion character,
          HImage image,
          string expression,
          int numAlternatives,
          int numCorrections,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(679);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HalconAPI.LoadS(proc, 1, err2, out word);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an SVM-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <returns>Result of classifying the characters with the SVM.</returns>
        public HTuple DoOcrMultiClassSvm(HRegion character, HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(680);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an SVM-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <returns>Result of classifying the character with the SVM.</returns>
        public HTuple DoOcrSingleClassSvm(HRegion character, HImage image, HTuple num)
        {
            IntPtr proc = HalconAPI.PreCall(681);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Approximate a trained SVM-based OCR classifier by a reduced SVM.
        ///   Instance represents: Original handle of SVM-based OCR-classifier.
        /// </summary>
        /// <param name="method">Type of postprocessing to reduce number of SVs. Default: "bottom_up"</param>
        /// <param name="minRemainingSV">Minimum number of remaining SVs. Default: 2</param>
        /// <param name="maxError">Maximum allowed error of reduction. Default: 0.001</param>
        /// <returns>SVMHandle of reduced OCR classifier.</returns>
        public HOCRSvm ReduceOcrClassSvm(string method, int minRemainingSV, double maxError)
        {
            IntPtr proc = HalconAPI.PreCall(682);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreI(proc, 2, minRemainingSV);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HOCRSvm hocrSvm;
            int procResult = HOCRSvm.LoadNew(proc, 0, err, out hocrSvm);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hocrSvm;
        }

        /// <summary>
        ///   Train an OCR classifier with data from a (protected) training file.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. Default: "default"</param>
        public void TrainfOcrClassSvmProtected(
          HTuple trainingFile,
          HTuple password,
          double epsilon,
          HTuple trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(683);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.Store(proc, 2, password);
            HalconAPI.StoreD(proc, 3, epsilon);
            HalconAPI.Store(proc, 4, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(password);
            HalconAPI.UnpinTuple(trainMode);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train an OCR classifier with data from a (protected) training file.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. Default: "default"</param>
        public void TrainfOcrClassSvmProtected(
          string trainingFile,
          string password,
          double epsilon,
          string trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(683);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.StoreS(proc, 2, password);
            HalconAPI.StoreD(proc, 3, epsilon);
            HalconAPI.StoreS(proc, 4, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. Default: "default"</param>
        public void TrainfOcrClassSvm(HTuple trainingFile, double epsilon, HTuple trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(684);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.StoreD(proc, 2, epsilon);
            HalconAPI.Store(proc, 3, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(trainMode);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="epsilon">Stop parameter for training. Default: 0.001</param>
        /// <param name="trainMode">Mode of training. Default: "default"</param>
        public void TrainfOcrClassSvm(string trainingFile, double epsilon, string trainMode)
        {
            IntPtr proc = HalconAPI.PreCall(684);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.StoreD(proc, 2, epsilon);
            HalconAPI.StoreS(proc, 3, trainMode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the information content of the preprocessed feature vectors of an SVM-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoOcrClassSvm(
          HTuple trainingFile,
          string preprocessing,
          out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(685);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.StoreS(proc, 2, preprocessing);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out cumInformationCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the information content of the preprocessed feature vectors of an SVM-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoOcrClassSvm(
          string trainingFile,
          string preprocessing,
          out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(685);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.StoreS(proc, 2, preprocessing);
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
        ///   Return the number of support vectors of an OCR classifier.
        ///   Instance represents: OCR handle.
        /// </summary>
        /// <param name="numSVPerSVM">Number of SV of each sub-SVM.</param>
        /// <returns>Total number of support vectors.</returns>
        public int GetSupportVectorNumOcrClassSvm(out HTuple numSVPerSVM)
        {
            IntPtr proc = HalconAPI.PreCall(686);
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
        ///   Return the index of a support vector from a trained OCR classifier that is based on support vector machines.
        ///   Instance represents: OCR handle.
        /// </summary>
        /// <param name="indexSupportVector">Number of stored support vectors.</param>
        /// <returns>Index of the support vector in the training set.</returns>
        public double GetSupportVectorOcrClassSvm(HTuple indexSupportVector)
        {
            IntPtr proc = HalconAPI.PreCall(687);
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
        ///   Return the parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters.</param>
        /// <param name="features">Features to be used for classification.</param>
        /// <param name="characters">Characters of the character set to be read.</param>
        /// <param name="kernelType">The kernel type.</param>
        /// <param name="kernelParam">Additional parameters for the kernel function.</param>
        /// <param name="nu">Regularization constant of the SVM.</param>
        /// <param name="mode">The mode of the SVM.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization').</param>
        public void GetParamsOcrClassSvm(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out HTuple features,
          out HTuple characters,
          out string kernelType,
          out double kernelParam,
          out double nu,
          out string mode,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(688);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            HalconAPI.InitOCT(proc, 10);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HTuple.LoadNew(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out kernelType);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out kernelParam);
            int err9 = HalconAPI.LoadD(proc, 7, err8, out nu);
            int err10 = HalconAPI.LoadS(proc, 8, err9, out mode);
            int err11 = HalconAPI.LoadS(proc, 9, err10, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 10, err11, out numComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters.</param>
        /// <param name="features">Features to be used for classification.</param>
        /// <param name="characters">Characters of the character set to be read.</param>
        /// <param name="kernelType">The kernel type.</param>
        /// <param name="kernelParam">Additional parameters for the kernel function.</param>
        /// <param name="nu">Regularization constant of the SVM.</param>
        /// <param name="mode">The mode of the SVM.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization').</param>
        public void GetParamsOcrClassSvm(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out string features,
          out HTuple characters,
          out string kernelType,
          out double kernelParam,
          out double nu,
          out string mode,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(688);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            HalconAPI.InitOCT(proc, 10);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HalconAPI.LoadS(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out kernelType);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out kernelParam);
            int err9 = HalconAPI.LoadD(proc, 7, err8, out nu);
            int err10 = HalconAPI.LoadS(proc, 8, err9, out mode);
            int err11 = HalconAPI.LoadS(proc, 9, err10, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 10, err11, out numComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a support vector machine.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. Default: 0.02</param>
        /// <param name="nu">Regularization constant of the SVM. Default: 0.05</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public void CreateOcrClassSvm(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          string kernelType,
          double kernelParam,
          double nu,
          string mode,
          string preprocessing,
          int numComponents)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(689);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreS(proc, 5, kernelType);
            HalconAPI.StoreD(proc, 6, kernelParam);
            HalconAPI.StoreD(proc, 7, nu);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, preprocessing);
            HalconAPI.StoreI(proc, 10, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a support vector machine.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="kernelType">The kernel type. Default: "rbf"</param>
        /// <param name="kernelParam">Additional parameter for the kernel function. Default: 0.02</param>
        /// <param name="nu">Regularization constant of the SVM. Default: 0.05</param>
        /// <param name="mode">The mode of the SVM. Default: "one-versus-one"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "normalization"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        public void CreateOcrClassSvm(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          string kernelType,
          double kernelParam,
          double nu,
          string mode,
          string preprocessing,
          int numComponents)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(689);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreS(proc, 5, kernelType);
            HalconAPI.StoreD(proc, 6, kernelParam);
            HalconAPI.StoreD(proc, 7, nu);
            HalconAPI.StoreS(proc, 8, mode);
            HalconAPI.StoreS(proc, 9, preprocessing);
            HalconAPI.StoreI(proc, 10, numComponents);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(673);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
