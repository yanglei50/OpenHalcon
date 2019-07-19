// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCRKnn
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a k-NearestNeighbor OCR classifier.</summary>
    [Serializable]
    public class HOCRKnn : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRKnn()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRKnn(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRKnn obj)
        {
            obj = new HOCRKnn(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRKnn[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HOCRKnn[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HOCRKnn(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read an OCR classifier from a file.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HOCRKnn(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(650);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a k-Nearest Neighbor (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="genParamName">This parameter is not yet supported. Default: []</param>
        /// <param name="genParamValue">This parameter is not yet supported. Default: []</param>
        public HOCRKnn(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(654);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a k-Nearest Neighbor (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="genParamName">This parameter is not yet supported. Default: []</param>
        /// <param name="genParamValue">This parameter is not yet supported. Default: []</param>
        public HOCRKnn(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(654);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeOcrClassKnn();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRKnn(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeOcrClassKnn(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeOcrClassKnn().Serialize(stream);
        }

        public static HOCRKnn Deserialize(Stream stream)
        {
            HOCRKnn hocrKnn = new HOCRKnn();
            hocrKnn.DeserializeOcrClassKnn(HSerializedItem.Deserialize(stream));
            return hocrKnn;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HOCRKnn Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeOcrClassKnn();
            HOCRKnn hocrKnn = new HOCRKnn();
            hocrKnn.DeserializeOcrClassKnn(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hocrKnn;
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
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public HTuple DoOcrWordKnn(
          HRegion character,
          HImage image,
          string expression,
          int numAlternatives,
          int numCorrections,
          out HTuple confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(647);
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
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public string DoOcrWordKnn(
          HRegion character,
          HImage image,
          string expression,
          int numAlternatives,
          int numCorrections,
          out double confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(647);
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
        ///   Deserialize a serialized k-NN-based OCR classifier.
        ///   Modified instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeOcrClassKnn(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(648);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a k-NN-based OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeOcrClassKnn()
        {
            IntPtr proc = HalconAPI.PreCall(649);
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
        public void ReadOcrClassKnn(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(650);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a k-NN classifier for an OCR task to a file.
        ///   Instance represents: Handle of the k-NN classifier for an OCR task.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteOcrClassKnn(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(651);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a k-Nearest Neighbor (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="genParamName">This parameter is not yet supported. Default: []</param>
        /// <param name="genParamValue">This parameter is not yet supported. Default: []</param>
        public void CreateOcrClassKnn(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          HTuple features,
          HTuple characters,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(654);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(characters);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an OCR classifier using a k-Nearest Neighbor (k-NN) classifier.
        ///   Modified instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed. Default: 8</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed. Default: 10</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters. Default: "constant"</param>
        /// <param name="features">Features to be used for classification. Default: "default"</param>
        /// <param name="characters">All characters of the character set to be read. Default: ["0","1","2","3","4","5","6","7","8","9"]</param>
        /// <param name="genParamName">This parameter is not yet supported. Default: []</param>
        /// <param name="genParamValue">This parameter is not yet supported. Default: []</param>
        public void CreateOcrClassKnn(
          int widthCharacter,
          int heightCharacter,
          string interpolation,
          string features,
          HTuple characters,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(654);
            HalconAPI.StoreI(proc, 0, widthCharacter);
            HalconAPI.StoreI(proc, 1, heightCharacter);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, characters);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(characters);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Trains an k-NN classifier for an OCR task.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        public void TrainfOcrClassKnn(HTuple trainingFile, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(655);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Trains an k-NN classifier for an OCR task.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "ocr.trf"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the k-NN classifier creation. Default: []</param>
        public void TrainfOcrClassKnn(string trainingFile, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(655);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the features of a character.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="character">Input character.</param>
        /// <param name="transform">Should the feature vector be transformed with the preprocessing? Default: "true"</param>
        /// <returns>Feature vector of the character.</returns>
        public HTuple GetFeaturesOcrClassKnn(HImage character, string transform)
        {
            IntPtr proc = HalconAPI.PreCall(656);
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
        ///   Return the parameters of an OCR classifier.
        ///   Instance represents: Handle of the OCR classifier.
        /// </summary>
        /// <param name="widthCharacter">Width of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="heightCharacter">Height of the rectangle to which the gray values of the segmented character are zoomed.</param>
        /// <param name="interpolation">Interpolation mode for the zooming of the characters.</param>
        /// <param name="features">Features to be used for classification.</param>
        /// <param name="characters">Characters of the character set to be read.</param>
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numTrees">Number of different trees used during the classifcation.</param>
        public void GetParamsOcrClassKnn(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out HTuple features,
          out HTuple characters,
          out string preprocessing,
          out int numTrees)
        {
            IntPtr proc = HalconAPI.PreCall(657);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HTuple.LoadNew(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 6, err7, out numTrees);
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
        /// <param name="preprocessing">Type of preprocessing used to transform the feature vectors.</param>
        /// <param name="numTrees">Number of different trees used during the classifcation.</param>
        public void GetParamsOcrClassKnn(
          out int widthCharacter,
          out int heightCharacter,
          out string interpolation,
          out string features,
          out HTuple characters,
          out string preprocessing,
          out int numTrees)
        {
            IntPtr proc = HalconAPI.PreCall(657);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthCharacter);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightCharacter);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out interpolation);
            int err5 = HalconAPI.LoadS(proc, 3, err4, out features);
            int err6 = HTuple.LoadNew(proc, 4, err5, out characters);
            int err7 = HalconAPI.LoadS(proc, 5, err6, out preprocessing);
            int procResult = HalconAPI.LoadI(proc, 6, err7, out numTrees);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Classify multiple characters with an k-NN classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public HTuple DoOcrMultiClassKnn(HRegion character, HImage image, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(658);
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
        ///   Classify multiple characters with an k-NN classifier.
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public string DoOcrMultiClassKnn(HRegion character, HImage image, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(658);
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
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="numClasses">Number of maximal classes to determine. Default: 1</param>
        /// <param name="numNeighbors">Number of neighbors to consider. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Results of classifying the character with the k-NN.</returns>
        public HTuple DoOcrSingleClassKnn(
          HRegion character,
          HImage image,
          HTuple numClasses,
          HTuple numNeighbors,
          out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(659);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numNeighbors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numClasses);
            HalconAPI.UnpinTuple(numNeighbors);
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
        ///   Instance represents: Handle of the k-NN classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="numClasses">Number of maximal classes to determine. Default: 1</param>
        /// <param name="numNeighbors">Number of neighbors to consider. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Results of classifying the character with the k-NN.</returns>
        public string DoOcrSingleClassKnn(
          HRegion character,
          HImage image,
          HTuple numClasses,
          HTuple numNeighbors,
          out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(659);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numNeighbors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numClasses);
            HalconAPI.UnpinTuple(numNeighbors);
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
        ///   Select an optimal combination of features to classify OCR data.
        ///   Modified instance represents: Trained OCR-k-NN classifier.
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
        public HTuple SelectFeatureSetTrainfKnn(
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
            IntPtr proc = HalconAPI.PreCall(660);
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
        ///   Select an optimal combination of features to classify OCR data.
        ///   Modified instance represents: Trained OCR-k-NN classifier.
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
        public HTuple SelectFeatureSetTrainfKnn(
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
            IntPtr proc = HalconAPI.PreCall(660);
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

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(653);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
