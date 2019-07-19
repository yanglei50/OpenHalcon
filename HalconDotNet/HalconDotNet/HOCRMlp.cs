// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCRMlp
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a MLP OCR classifier.</summary>
    [Serializable]
    public class HOCRMlp : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRMlp()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRMlp(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRMlp obj)
        {
            obj = new HOCRMlp(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRMlp[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HOCRMlp[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HOCRMlp(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read an OCR classifier from a file.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HOCRMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(694);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a multilayer perceptron.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 80</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "none"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public HOCRMlp(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          int numHidden,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            IntPtr proc = HalconAPI.PreCall(708);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreI(proc, 5, numHidden);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.StoreI(proc, 8, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a multilayer perceptron.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 80</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "none"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public HOCRMlp(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          int numHidden,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            IntPtr proc = HalconAPI.PreCall(708);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreI(proc, 5, numHidden);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.StoreI(proc, 8, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeOcrClassMlp();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRMlp(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeOcrClassMlp(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeOcrClassMlp().Serialize(stream);
        }

        public static HOCRMlp Deserialize(Stream stream)
        {
            HOCRMlp hocrMlp = new HOCRMlp();
            hocrMlp.DeserializeOcrClassMlp(HSerializedItem.Deserialize(stream));
            return hocrMlp;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HOCRMlp Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeOcrClassMlp();
            HOCRMlp hocrMlp = new HOCRMlp();
            hocrMlp.DeserializeOcrClassMlp(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hocrMlp;
        }

        /// <summary>
        ///   Select an optimal combination of features to classify OCR data from a (protected) training file.
        ///   Modified instance represents: Trained OCR-MLP classifier.
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
        public HTuple SelectFeatureSetTrainfMlpProtected(
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
            IntPtr proc = HalconAPI.PreCall(661);
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
        ///   Modified instance represents: Trained OCR-MLP classifier.
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
        public HTuple SelectFeatureSetTrainfMlpProtected(
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
            IntPtr proc = HalconAPI.PreCall(661);
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
        ///   Selects an optimal combination of features to classify OCR data.
        ///   Modified instance represents: Trained OCR-MLP classifier.
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
        public HTuple SelectFeatureSetTrainfMlp(
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
            IntPtr proc = HalconAPI.PreCall(662);
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
        ///   Selects an optimal combination of features to classify OCR data.
        ///   Modified instance represents: Trained OCR-MLP classifier.
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
        public HTuple SelectFeatureSetTrainfMlp(
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
            IntPtr proc = HalconAPI.PreCall(662);
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
        ///   Deserialize a serialized MLP-based OCR classifier.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeOcrClassMlp(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(692);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a MLP-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeOcrClassMlp()
        {
            IntPtr proc = HalconAPI.PreCall(693);
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
        ///   Read an OCR classifier from a file.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadOcrClassMlp(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(694);
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
        public void WriteOcrClassMlp(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(695);
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
        public HTuple GetFeaturesOcrClassMlp(HImage character, string transform)
        {
            IntPtr proc = HalconAPI.PreCall(696);
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
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public HTuple DoOcrWordMlp(
          HRegion character,
          HImage image,
          string expression,
          int numAlternatives,
          int numCorrections,
          out HTuple confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(697);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
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
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public string DoOcrWordMlp(
          HRegion character,
          HImage image,
          string expression,
          int numAlternatives,
          int numCorrections,
          out double confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(697);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return stringValue;
        }

        /// <summary>
        ///   Classify multiple characters with an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public HTuple DoOcrMultiClassMlp(HRegion character, HImage image, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(698);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public string DoOcrMultiClassMlp(HRegion character, HImage image, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(698);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return stringValue;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the MLP.</returns>
        public HTuple DoOcrSingleClassMlp(
          HRegion character,
          HImage image,
          HTuple num,
          out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(699);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the MLP.</returns>
        public string DoOcrSingleClassMlp(
          HRegion character,
          HImage image,
          HTuple num,
          out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(699);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return stringValue;
        }

        /// <summary>
        ///   Train an OCR classifier with data from a (protected) training file.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="maxIterations">Maximum number of iterations of the optimization algorithm. Default: 200</param>
        /// <param name="weightTolerance">Threshold for the difference of the weights of the MLP between two iterations of the optimization algorithm. Default: 1.0</param>
        /// <param name="errorTolerance">Threshold for the difference of the mean error of the MLP on the training data between two iterations of the optimization algorithm. Default: 0.01</param>
        /// <param name="errorLog">Mean error of the MLP on the training data as a function of the number of iterations of the optimization algorithm.</param>
        /// <returns>Mean error of the MLP on the training data.</returns>
        public double TrainfOcrClassMlpProtected(
          HTuple trainingFile,
          HTuple password,
          int maxIterations,
          double weightTolerance,
          double errorTolerance,
          out HTuple errorLog)
        {
            IntPtr proc = HalconAPI.PreCall(700);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.Store(proc, 2, password);
            HalconAPI.StoreI(proc, 3, maxIterations);
            HalconAPI.StoreD(proc, 4, weightTolerance);
            HalconAPI.StoreD(proc, 5, errorTolerance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(password);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out errorLog);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier with data from a (protected) training file.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="maxIterations">Maximum number of iterations of the optimization algorithm. Default: 200</param>
        /// <param name="weightTolerance">Threshold for the difference of the weights of the MLP between two iterations of the optimization algorithm. Default: 1.0</param>
        /// <param name="errorTolerance">Threshold for the difference of the mean error of the MLP on the training data between two iterations of the optimization algorithm. Default: 0.01</param>
        /// <param name="errorLog">Mean error of the MLP on the training data as a function of the number of iterations of the optimization algorithm.</param>
        /// <returns>Mean error of the MLP on the training data.</returns>
        public double TrainfOcrClassMlpProtected(
          string trainingFile,
          string password,
          int maxIterations,
          double weightTolerance,
          double errorTolerance,
          out HTuple errorLog)
        {
            IntPtr proc = HalconAPI.PreCall(700);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.StoreS(proc, 2, password);
            HalconAPI.StoreI(proc, 3, maxIterations);
            HalconAPI.StoreD(proc, 4, weightTolerance);
            HalconAPI.StoreD(proc, 5, errorTolerance);
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
        ///   Train an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="maxIterations">Maximum number of iterations of the optimization algorithm. Default: 200</param>
        /// <param name="weightTolerance">Threshold for the difference of the weights of the MLP between two iterations of the optimization algorithm. Default: 1.0</param>
        /// <param name="errorTolerance">Threshold for the difference of the mean error of the MLP on the training data between two iterations of the optimization algorithm. Default: 0.01</param>
        /// <param name="errorLog">Mean error of the MLP on the training data as a function of the number of iterations of the optimization algorithm.</param>
        /// <returns>Mean error of the MLP on the training data.</returns>
        public double TrainfOcrClassMlp(
          HTuple trainingFile,
          int maxIterations,
          double weightTolerance,
          double errorTolerance,
          out HTuple errorLog)
        {
            IntPtr proc = HalconAPI.PreCall(701);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.StoreI(proc, 2, maxIterations);
            HalconAPI.StoreD(proc, 3, weightTolerance);
            HalconAPI.StoreD(proc, 4, errorTolerance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out errorLog);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="maxIterations">Maximum number of iterations of the optimization algorithm. Default: 200</param>
        /// <param name="weightTolerance">Threshold for the difference of the weights of the MLP between two iterations of the optimization algorithm. Default: 1.0</param>
        /// <param name="errorTolerance">Threshold for the difference of the mean error of the MLP on the training data between two iterations of the optimization algorithm. Default: 0.01</param>
        /// <param name="errorLog">Mean error of the MLP on the training data as a function of the number of iterations of the optimization algorithm.</param>
        /// <returns>Mean error of the MLP on the training data.</returns>
        public double TrainfOcrClassMlp(
          string trainingFile,
          int maxIterations,
          double weightTolerance,
          double errorTolerance,
          out HTuple errorLog)
        {
            IntPtr proc = HalconAPI.PreCall(701);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.StoreI(proc, 2, maxIterations);
            HalconAPI.StoreD(proc, 3, weightTolerance);
            HalconAPI.StoreD(proc, 4, errorTolerance);
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
        ///   Compute the information content of the preprocessed feature vectors of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoOcrClassMlp(
          HTuple trainingFile,
          string preprocessing,
          out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(702);
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
        ///   Compute the information content of the preprocessed feature vectors of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "principal_components"</param>
        /// <param name="cumInformationCont">Cumulative information content of the transformed feature vectors.</param>
        /// <returns>Relative information content of the transformed feature vectors.</returns>
        public HTuple GetPrepInfoOcrClassMlp(
          string trainingFile,
          string preprocessing,
          out HTuple cumInformationCont)
        {
            IntPtr proc = HalconAPI.PreCall(702);
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
        ///   Return the rejection class parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the general parameter. Default: "sampling_strategy"</param>
        /// <returns>Value of the general parameter.</returns>
        public HTuple GetRejectionParamsOcrClassMlp(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(703);
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
        ///   Return the rejection class parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the general parameter. Default: "sampling_strategy"</param>
        /// <returns>Value of the general parameter.</returns>
        public string GetRejectionParamsOcrClassMlp(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(703);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Set the rejection class parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the general parameter. Default: "sampling_strategy"</param>
        /// <param name="genParamValue">Value of the general parameter. Default: "hyperbox_around_all_classes"</param>
        public void SetRejectionParamsOcrClassMlp(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(704);
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
        ///   Set the rejection class parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the general parameter. Default: "sampling_strategy"</param>
        /// <param name="genParamValue">Value of the general parameter. Default: "hyperbox_around_all_classes"</param>
        public void SetRejectionParamsOcrClassMlp(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(704);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the regularization parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to return. Default: "weight_prior"</param>
        /// <returns>Value of the regularization parameter.</returns>
        public HTuple GetRegularizationParamsOcrClassMlp(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(705);
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
        ///   Set the regularization parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to return. Default: "weight_prior"</param>
        /// <param name="genParamValue">Value of the regularization parameter. Default: 1.0</param>
        public void SetRegularizationParamsOcrClassMlp(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(706);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the regularization parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="genParamName">Name of the regularization parameter to return. Default: "weight_prior"</param>
        /// <param name="genParamValue">Value of the regularization parameter. Default: 1.0</param>
        public void SetRegularizationParamsOcrClassMlp(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(706);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
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
        /// <param name="numHidden">Number of hidden units of the MLP.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features.</param>
        public void GetParamsOcrClassMlp(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out HTuple features,
          out HTuple characters,
          out int numHidden,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(707);
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
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HTuple.LoadNew(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadI(proc, 5, err6, out numHidden);
            int err8 = HalconAPI.LoadS(proc, 6, err7, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 7, err8, out numComponents);
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
        /// <param name="numHidden">Number of hidden units of the MLP.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features.</param>
        public void GetParamsOcrClassMlp(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out string features,
          out HTuple characters,
          out int numHidden,
          out string preprocessing,
          out int numComponents)
        {
            IntPtr proc = HalconAPI.PreCall(707);
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
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HalconAPI.LoadS(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadI(proc, 5, err6, out numHidden);
            int err8 = HalconAPI.LoadS(proc, 6, err7, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 7, err8, out numComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a multilayer perceptron.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 80</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "none"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public void CreateOcrClassMlp(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          int numHidden,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(708);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreI(proc, 5, numHidden);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.StoreI(proc, 8, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a multilayer perceptron.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="numHidden">Number of hidden units of the MLP. Default: 80</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors. Default: "none"</param>
        /// <param name="numComponents">Preprocessing parameter: Number of transformed features (ignored for Preprocessing $=$ 'none' and Preprocessing $=$ 'normalization'). Default: 10</param>
        /// <param name="randSeed">Seed value of the random number generator that is used to initialize the MLP with random values. Default: 42</param>
        public void CreateOcrClassMlp(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          int numHidden,
          string preprocessing,
          int numComponents,
          int randSeed)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(708);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.StoreI(proc, 5, numHidden);
            HalconAPI.StoreS(proc, 6, preprocessing);
            HalconAPI.StoreI(proc, 7, numComponents);
            HalconAPI.StoreI(proc, 8, randSeed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(691);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
