// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCRBox
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an OCR box classifier.</summary>
    [Serializable]
    public class HOCRBox : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRBox()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRBox(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRBox obj)
        {
            obj = new HOCRBox(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRBox[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HOCRBox[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HOCRBox(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read an OCR classifier from a file.
        ///   Modified instance represents: ID of the read OCR classifier.
        /// </summary>
        /// <param name="fileName">Name of the OCR classifier file. Default: "testnet"</param>
        public HOCRBox(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(712);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCR-classifier.
        ///   Modified instance represents: ID of the created OCR classifier.
        /// </summary>
        /// <param name="widthPattern">Width of the input layer of the network. Default: 8</param>
        /// <param name="heightPattern">Height of the input layer of the network. Default: 10</param>
        /// <param name="interpolation">Interpolation mode concerning scaling of characters. Default: 1</param>
        /// <param name="features">Additional features. Default: "default"</param>
        /// <param name="character">All characters of a set. Default: ["a","b","c"]</param>
        public HOCRBox(
          int widthPattern,
          int heightPattern,
          int interpolation,
          HTuple features,
          HTuple character)
        {
            IntPtr proc = HalconAPI.PreCall(716);
            HalconAPI.StoreI(proc, 0, widthPattern);
            HalconAPI.StoreI(proc, 1, heightPattern);
            HalconAPI.StoreI(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, character);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(character);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCR-classifier.
        ///   Modified instance represents: ID of the created OCR classifier.
        /// </summary>
        /// <param name="widthPattern">Width of the input layer of the network. Default: 8</param>
        /// <param name="heightPattern">Height of the input layer of the network. Default: 10</param>
        /// <param name="interpolation">Interpolation mode concerning scaling of characters. Default: 1</param>
        /// <param name="features">Additional features. Default: "default"</param>
        /// <param name="character">All characters of a set. Default: ["a","b","c"]</param>
        public HOCRBox(
          int widthPattern,
          int heightPattern,
          int interpolation,
          string features,
          HTuple character)
        {
            IntPtr proc = HalconAPI.PreCall(716);
            HalconAPI.StoreI(proc, 0, widthPattern);
            HalconAPI.StoreI(proc, 1, heightPattern);
            HalconAPI.StoreI(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, character);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(character);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeOcr();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCRBox(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeOcr(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeOcr().Serialize(stream);
        }

        public static HOCRBox Deserialize(Stream stream)
        {
            HOCRBox hocrBox = new HOCRBox();
            hocrBox.DeserializeOcr(HSerializedItem.Deserialize(stream));
            return hocrBox;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HOCRBox Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeOcr();
            HOCRBox hocrBox = new HOCRBox();
            hocrBox.DeserializeOcr(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hocrBox;
        }

        /// <summary>
        ///   Serialize an OCR classifier.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeOcr()
        {
            IntPtr proc = HalconAPI.PreCall(709);
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
        ///   Deserialize a serialized OCR classifier.
        ///   Modified instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeOcr(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(710);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Writing an OCR classifier into a file.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="fileName">Name of the file for the OCR classifier (without extension). Default: "my_ocr"</param>
        public void WriteOcr(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(711);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read an OCR classifier from a file.
        ///   Modified instance represents: ID of the read OCR classifier.
        /// </summary>
        /// <param name="fileName">Name of the OCR classifier file. Default: "testnet"</param>
        public void ReadOcr(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(712);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Classify one character.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="character">Character to be recognized.</param>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="confidences">Confidence values of the characters.</param>
        /// <returns>Classes (names) of the characters.</returns>
        public HTuple DoOcrSingle(HRegion character, HImage image, out HTuple confidences)
        {
            IntPtr proc = HalconAPI.PreCall(713);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidences);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Classify characters.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="confidence">Confidence values of the characters.</param>
        /// <returns>Class (name) of the characters.</returns>
        public HTuple DoOcrMulti(HRegion character, HImage image, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(714);
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
        ///   Classify characters.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="character">Characters to be recognized.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="confidence">Confidence values of the characters.</param>
        /// <returns>Class (name) of the characters.</returns>
        public string DoOcrMulti(HRegion character, HImage image, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(714);
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
        ///   Get information about an OCR classifier.
        ///   Instance represents: ID of the OCR classifier.
        /// </summary>
        /// <param name="widthPattern">Width of the scaled characters.</param>
        /// <param name="heightPattern">Height of the scaled characters.</param>
        /// <param name="interpolation">Interpolation mode for scaling the characters.</param>
        /// <param name="widthMaxChar">Width of the largest trained character.</param>
        /// <param name="heightMaxChar">Height of the largest trained character.</param>
        /// <param name="features">Used features.</param>
        /// <param name="characters">All characters of the set.</param>
        public void InfoOcrClassBox(
          out int widthPattern,
          out int heightPattern,
          out int interpolation,
          out int widthMaxChar,
          out int heightMaxChar,
          out HTuple features,
          out HTuple characters)
        {
            IntPtr proc = HalconAPI.PreCall(715);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out widthPattern);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out heightPattern);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out interpolation);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out widthMaxChar);
            int err6 = HalconAPI.LoadI(proc, 4, err5, out heightMaxChar);
            int err7 = HTuple.LoadNew(proc, 5, err6, out features);
            int procResult = HTuple.LoadNew(proc, 6, err7, out characters);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCR-classifier.
        ///   Modified instance represents: ID of the created OCR classifier.
        /// </summary>
        /// <param name="widthPattern">Width of the input layer of the network. Default: 8</param>
        /// <param name="heightPattern">Height of the input layer of the network. Default: 10</param>
        /// <param name="interpolation">Interpolation mode concerning scaling of characters. Default: 1</param>
        /// <param name="features">Additional features. Default: "default"</param>
        /// <param name="character">All characters of a set. Default: ["a","b","c"]</param>
        public void CreateOcrClassBox(
          int widthPattern,
          int heightPattern,
          int interpolation,
          HTuple features,
          HTuple character)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(716);
            HalconAPI.StoreI(proc, 0, widthPattern);
            HalconAPI.StoreI(proc, 1, heightPattern);
            HalconAPI.StoreI(proc, 2, interpolation);
            HalconAPI.Store(proc, 3, features);
            HalconAPI.Store(proc, 4, character);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(character);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCR-classifier.
        ///   Modified instance represents: ID of the created OCR classifier.
        /// </summary>
        /// <param name="widthPattern">Width of the input layer of the network. Default: 8</param>
        /// <param name="heightPattern">Height of the input layer of the network. Default: 10</param>
        /// <param name="interpolation">Interpolation mode concerning scaling of characters. Default: 1</param>
        /// <param name="features">Additional features. Default: "default"</param>
        /// <param name="character">All characters of a set. Default: ["a","b","c"]</param>
        public void CreateOcrClassBox(
          int widthPattern,
          int heightPattern,
          int interpolation,
          string features,
          HTuple character)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(716);
            HalconAPI.StoreI(proc, 0, widthPattern);
            HalconAPI.StoreI(proc, 1, heightPattern);
            HalconAPI.StoreI(proc, 2, interpolation);
            HalconAPI.StoreS(proc, 3, features);
            HalconAPI.Store(proc, 4, character);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(character);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train an OCR classifier by the input of regions.
        ///   Instance represents: ID of the desired OCR-classifier.
        /// </summary>
        /// <param name="character">Characters to be trained.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TraindOcrClassBox(HRegion character, HImage image, HTuple classVal)
        {
            IntPtr proc = HalconAPI.PreCall(717);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier by the input of regions.
        ///   Instance represents: ID of the desired OCR-classifier.
        /// </summary>
        /// <param name="character">Characters to be trained.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TraindOcrClassBox(HRegion character, HImage image, string classVal)
        {
            IntPtr proc = HalconAPI.PreCall(717);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier with the help of a training file.
        ///   Instance represents: ID of the desired OCR-network.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "train_ocr"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TrainfOcrClassBox(HTuple trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(718);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, trainingFile);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier with the help of a training file.
        ///   Instance represents: ID of the desired OCR-network.
        /// </summary>
        /// <param name="trainingFile">Names of the training files. Default: "train_ocr"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TrainfOcrClassBox(string trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(718);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, trainingFile);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Define a new conversion table for the characters.
        ///   Instance represents: ID of the OCR-network to be changed.
        /// </summary>
        /// <param name="character">New assign of characters. Default: ["a","b","c"]</param>
        public void OcrChangeChar(HTuple character)
        {
            IntPtr proc = HalconAPI.PreCall(721);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, character);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(character);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Test an OCR classifier.
        ///   Instance represents: ID of the desired OCR-classifier.
        /// </summary>
        /// <param name="character">Characters to be tested.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Confidence for the character to belong to the class.</returns>
        public HTuple TestdOcrClassBox(HRegion character, HImage image, HTuple classVal)
        {
            IntPtr proc = HalconAPI.PreCall(725);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Test an OCR classifier.
        ///   Instance represents: ID of the desired OCR-classifier.
        /// </summary>
        /// <param name="character">Characters to be tested.</param>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Confidence for the character to belong to the class.</returns>
        public double TestdOcrClassBox(HRegion character, HImage image, string classVal)
        {
            IntPtr proc = HalconAPI.PreCall(725);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Access the features which correspond to a character.
        ///   Instance represents: ID of the desired OCR-classifier.
        /// </summary>
        /// <param name="character">Characters to be trained.</param>
        /// <returns>Feature vector.</returns>
        public HTuple OcrGetFeatures(HImage character)
        {
            IntPtr proc = HalconAPI.PreCall(727);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)character);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)character);
            return tuple;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(722);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
