// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HStructuredLightModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a structured light model.</summary>
    [Serializable]
    public class HStructuredLightModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HStructuredLightModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HStructuredLightModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HStructuredLightModel obj)
        {
            obj = new HStructuredLightModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HStructuredLightModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HStructuredLightModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HStructuredLightModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a structured light model.
        ///   Modified instance represents: Handle for using and accessing the structured light model.
        /// </summary>
        /// <param name="modelType">The type of the created structured light model. Default: "deflectometry"</param>
        public HStructuredLightModel(string modelType)
        {
            IntPtr proc = HalconAPI.PreCall(2107);
            HalconAPI.StoreS(proc, 0, modelType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeStructuredLightModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HStructuredLightModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeStructuredLightModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeStructuredLightModel().Serialize(stream);
        }

        public static HStructuredLightModel Deserialize(Stream stream)
        {
            HStructuredLightModel hstructuredLightModel = new HStructuredLightModel();
            hstructuredLightModel.DeserializeStructuredLightModel(HSerializedItem.Deserialize(stream));
            return hstructuredLightModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HStructuredLightModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeStructuredLightModel();
            HStructuredLightModel hstructuredLightModel = new HStructuredLightModel();
            hstructuredLightModel.DeserializeStructuredLightModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hstructuredLightModel;
        }

        /// <summary>
        ///   Create a structured light model.
        ///   Modified instance represents: Handle for using and accessing the structured light model.
        /// </summary>
        /// <param name="modelType">The type of the created structured light model. Default: "deflectometry"</param>
        public void CreateStructuredLightModel(string modelType)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2107);
            HalconAPI.StoreS(proc, 0, modelType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Decode the camera images acquired with a structured light setup.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="cameraImages">Acquired camera images.</param>
        public void DecodeStructuredLightPattern(HImage cameraImages)
        {
            IntPtr proc = HalconAPI.PreCall(2108);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)cameraImages);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraImages);
        }

        /// <summary>
        ///   Deserialize a structured light model.
        ///   Modified instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeStructuredLightModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2110);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Generate the pattern images to be displayed in a structured light setup.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <returns>Generated pattern images.</returns>
        public HImage GenStructuredLightPattern()
        {
            IntPtr proc = HalconAPI.PreCall(2113);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Query parameters of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="genParamName">Name of the queried model parameter. Default: "min_stripe_width"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetStructuredLightModelParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2117);
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
        ///   Query parameters of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="genParamName">Name of the queried model parameter. Default: "min_stripe_width"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetStructuredLightModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2117);
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
        ///   Get (intermediate) iconic results of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="objectName">Name of the iconic result to be returned.</param>
        /// <returns>Iconic result.</returns>
        public HObject GetStructuredLightObject(HTuple objectName)
        {
            IntPtr proc = HalconAPI.PreCall(2118);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(objectName);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Get (intermediate) iconic results of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="objectName">Name of the iconic result to be returned.</param>
        /// <returns>Iconic result.</returns>
        public HObject GetStructuredLightObject(string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(2118);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Read a structured light model from a file.
        ///   Modified instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadStructuredLightModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2123);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Serialize a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeStructuredLightModel()
        {
            IntPtr proc = HalconAPI.PreCall(2127);
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
        ///   Set parameters of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter to be adjusted. Default: "min_stripe_width"</param>
        /// <param name="genParamValue">New value of the model parameter. Default: 32</param>
        public void SetStructuredLightModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2130);
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
        ///   Set parameters of a structured light model.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter to be adjusted. Default: "min_stripe_width"</param>
        /// <param name="genParamValue">New value of the model parameter. Default: 32</param>
        public void SetStructuredLightModelParam(string genParamName, int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2130);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreI(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a structured light model to a file.
        ///   Instance represents: Handle of the structured light model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteStructuredLightModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(2133);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2106);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
