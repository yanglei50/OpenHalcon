// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTextureInspectionModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a texture model for texture inspection.</summary>
    [Serializable]
    public class HTextureInspectionModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextureInspectionModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextureInspectionModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HTextureInspectionModel obj)
        {
            obj = new HTextureInspectionModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HTextureInspectionModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HTextureInspectionModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HTextureInspectionModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a texture inspection model.
        ///   Modified instance represents: Handle for using and accessing the texture inspection model.
        /// </summary>
        /// <param name="modelType">The type of the created texture inspection model. Default: "basic"</param>
        public HTextureInspectionModel(string modelType)
        {
            IntPtr proc = HalconAPI.PreCall(2051);
            HalconAPI.StoreS(proc, 0, modelType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeTextureInspectionModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTextureInspectionModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeTextureInspectionModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeTextureInspectionModel().Serialize(stream);
        }

        public static HTextureInspectionModel Deserialize(Stream stream)
        {
            HTextureInspectionModel htextureInspectionModel = new HTextureInspectionModel();
            htextureInspectionModel.DeserializeTextureInspectionModel(HSerializedItem.Deserialize(stream));
            return htextureInspectionModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HTextureInspectionModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeTextureInspectionModel();
            HTextureInspectionModel htextureInspectionModel = new HTextureInspectionModel();
            htextureInspectionModel.DeserializeTextureInspectionModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return htextureInspectionModel;
        }

        /// <summary>
        ///   Add training images to the texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="image">Image of flawless texture.</param>
        /// <returns>Indices of the images that have been added to the texture inspection model.</returns>
        public HTuple AddTextureInspectionModelImage(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(2043);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Inspection of the texture within an image.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="image">Image of the texture to be inspected.</param>
        /// <param name="textureInspectionResultID">Handle of the inspection results.</param>
        /// <returns>Novelty regions.</returns>
        public HRegion ApplyTextureInspectionModel(
          HImage image,
          out HTextureInspectionResult textureInspectionResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2044);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HTextureInspectionResult.LoadNew(proc, 0, err2, out textureInspectionResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Create a texture inspection model.
        ///   Modified instance represents: Handle for using and accessing the texture inspection model.
        /// </summary>
        /// <param name="modelType">The type of the created texture inspection model. Default: "basic"</param>
        public void CreateTextureInspectionModel(string modelType)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2051);
            HalconAPI.StoreS(proc, 0, modelType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized texture inspection model.
        ///   Modified instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeTextureInspectionModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2054);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Get the training images contained in a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <returns>Training images contained in the texture inspection model.</returns>
        public HImage GetTextureInspectionModelImage()
        {
            IntPtr proc = HalconAPI.PreCall(2075);
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
        ///   Query parameters of a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the queried model parameter. Default: "novelty_threshold"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetTextureInspectionModelParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2076);
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
        ///   Query parameters of a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the queried model parameter. Default: "novelty_threshold"</param>
        /// <returns>Value of the queried model parameter.</returns>
        public HTuple GetTextureInspectionModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2076);
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
        ///   Read a texture inspection model from a file.
        ///   Modified instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadTextureInspectionModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2083);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Clear all or a user-defined subset of the images of a texture inspection model.</summary>
        /// <param name="textureInspectionModel">Handle of the texture inspection model.</param>
        /// <param name="indices">Indices of the images to be deleted from the texture inspection model.</param>
        /// <returns>Indices of the images that remain in the texture inspection model.</returns>
        public static HTuple RemoveTextureInspectionModelImage(
          HTextureInspectionModel[] textureInspectionModel,
          HTuple indices)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])textureInspectionModel);
            IntPtr proc = HalconAPI.PreCall(2085);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, indices);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(indices);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)textureInspectionModel);
            return tuple;
        }

        /// <summary>
        ///   Clear all or a user-defined subset of the images of a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="indices">Indices of the images to be deleted from the texture inspection model.</param>
        /// <returns>Indices of the images that remain in the texture inspection model.</returns>
        public HTuple RemoveTextureInspectionModelImage(HTuple indices)
        {
            IntPtr proc = HalconAPI.PreCall(2085);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, indices);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(indices);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Serialize a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeTextureInspectionModel()
        {
            IntPtr proc = HalconAPI.PreCall(2094);
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
        ///   Set parameters of a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter to be adjusted. Default: "gen_result_handle"</param>
        /// <param name="genParamValue">New value of the model parameter. Default: "true"</param>
        public void SetTextureInspectionModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2098);
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
        ///   Set parameters of a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="genParamName">Name of the model parameter to be adjusted. Default: "gen_result_handle"</param>
        /// <param name="genParamValue">New value of the model parameter. Default: "true"</param>
        public void SetTextureInspectionModelParam(string genParamName, int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2098);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreI(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train a texture inspection model.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        public void TrainTextureInspectionModel()
        {
            IntPtr proc = HalconAPI.PreCall(2099);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a texture inspection model to a file.
        ///   Instance represents: Handle of the texture inspection model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteTextureInspectionModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(2100);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2047);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
