// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDlClassifier
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a Deep Neural Network.</summary>
    [Serializable]
    public class HDlClassifier : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifier()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifier(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifier obj)
        {
            obj = new HDlClassifier(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifier[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDlClassifier[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDlClassifier(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a deep-learning-based classifier from a file.
        ///   Modified instance represents: Handle of the deep learning classifier.
        /// </summary>
        /// <param name="fileName">File name. Default: "pretrained_dl_classifier_compact.hdl"</param>
        public HDlClassifier(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(2122);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDlClassifier();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDlClassifier(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDlClassifier(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDlClassifier().Serialize(stream);
        }

        public static HDlClassifier Deserialize(Stream stream)
        {
            HDlClassifier hdlClassifier = new HDlClassifier();
            hdlClassifier.DeserializeDlClassifier(HSerializedItem.Deserialize(stream));
            return hdlClassifier;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDlClassifier Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDlClassifier();
            HDlClassifier hdlClassifier = new HDlClassifier();
            hdlClassifier.DeserializeDlClassifier(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdlClassifier;
        }

        /// <summary>
        ///   Infer the class affiliations for a set of images using the  deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="images">Tuple of input images.</param>
        /// <returns>Handle of the deep learning classification  results.</returns>
        public HDlClassifierResult ApplyDlClassifier(HImage images)
        {
            IntPtr proc = HalconAPI.PreCall(2102);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)images);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HDlClassifierResult classifierResult;
            int procResult = HDlClassifierResult.LoadNew(proc, 0, err, out classifierResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)images);
            return classifierResult;
        }

        /// <summary>
        ///   Deserialize a deep-learning-based classifier.
        ///   Modified instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDlClassifier(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2109);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Return the parameters the deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "gpu"</param>
        /// <returns>Value of the generic parameter.</returns>
        public HTuple GetDlClassifierParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2114);
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
        ///   Return the parameters the deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "gpu"</param>
        /// <returns>Value of the generic parameter.</returns>
        public HTuple GetDlClassifierParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2114);
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
        ///   Read a deep-learning-based classifier from a file.
        ///   Modified instance represents: Handle of the deep learning classifier.
        /// </summary>
        /// <param name="fileName">File name. Default: "pretrained_dl_classifier_compact.hdl"</param>
        public void ReadDlClassifier(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2122);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Serialize a deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDlClassifier()
        {
            IntPtr proc = HalconAPI.PreCall(2126);
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
        ///   Set the parameters of the deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "classes"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: ["class_1","class_2","class_3"]</param>
        public void SetDlClassifierParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2128);
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
        ///   Set the parameters of the deep-learning-based classifier.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "classes"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: ["class_1","class_2","class_3"]</param>
        public void SetDlClassifierParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2128);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a deep-learning-based classifier in a file.
        ///   Instance represents: Handle of the deep-learning-based classifier.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteDlClassifier(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(2132);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2103);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
