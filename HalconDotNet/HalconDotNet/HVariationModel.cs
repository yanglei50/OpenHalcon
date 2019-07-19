// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HVariationModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a variation model.</summary>
    [Serializable]
    public class HVariationModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVariationModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVariationModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HVariationModel obj)
        {
            obj = new HVariationModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HVariationModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HVariationModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HVariationModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a variation model from a file.
        ///   Modified instance represents: ID of the variation model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HVariationModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(83);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a variation model for image comparison.
        ///   Modified instance represents: ID of the variation model.
        /// </summary>
        /// <param name="width">Width of the images to be compared. Default: 640</param>
        /// <param name="height">Height of the images to be compared. Default: 480</param>
        /// <param name="type">Type of the images to be compared. Default: "byte"</param>
        /// <param name="mode">Method used for computing the variation model. Default: "standard"</param>
        public HVariationModel(int width, int height, string type, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(95);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreS(proc, 2, type);
            HalconAPI.StoreS(proc, 3, mode);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeVariationModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVariationModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeVariationModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeVariationModel().Serialize(stream);
        }

        public static HVariationModel Deserialize(Stream stream)
        {
            HVariationModel hvariationModel = new HVariationModel();
            hvariationModel.DeserializeVariationModel(HSerializedItem.Deserialize(stream));
            return hvariationModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HVariationModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeVariationModel();
            HVariationModel hvariationModel = new HVariationModel();
            hvariationModel.DeserializeVariationModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hvariationModel;
        }

        /// <summary>
        ///   Deserialize a variation model.
        ///   Modified instance represents: ID of the variation model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeVariationModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(81);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeVariationModel()
        {
            IntPtr proc = HalconAPI.PreCall(82);
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
        ///   Read a variation model from a file.
        ///   Modified instance represents: ID of the variation model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadVariationModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(83);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a variation model to a file.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteVariationModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(84);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the threshold images used for image comparison by a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="maxImage">Threshold image for the upper threshold.</param>
        /// <returns>Threshold image for the lower threshold.</returns>
        public HImage GetThreshImagesVariationModel(out HImage maxImage)
        {
            IntPtr proc = HalconAPI.PreCall(85);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out maxImage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Return the images used for image comparison by a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="varImage">Variation image of the trained object.</param>
        /// <returns>Image of the trained object.</returns>
        public HImage GetVariationModel(out HImage varImage)
        {
            IntPtr proc = HalconAPI.PreCall(86);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out varImage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Compare an image to a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="image">Image of the object to be compared.</param>
        /// <param name="mode">Method used for comparing the variation model. Default: "absolute"</param>
        /// <returns>Region containing the points that differ substantially from the model.</returns>
        public HRegion CompareExtVariationModel(HImage image, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(87);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, mode);
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
        ///   Compare an image to a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="image">Image of the object to be compared.</param>
        /// <returns>Region containing the points that differ substantially from the model.</returns>
        public HRegion CompareVariationModel(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(88);
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
        ///   Prepare a variation model for comparison with an image.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="refImage">Reference image of the object.</param>
        /// <param name="varImage">Variation image of the object.</param>
        /// <param name="absThreshold">Absolute minimum threshold for the differences between the image and the variation model. Default: 10</param>
        /// <param name="varThreshold">Threshold for the differences based on the variation of the variation model. Default: 2</param>
        public void PrepareDirectVariationModel(
          HImage refImage,
          HImage varImage,
          HTuple absThreshold,
          HTuple varThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(89);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)refImage);
            HalconAPI.Store(proc, 2, (HObjectBase)varImage);
            HalconAPI.Store(proc, 1, absThreshold);
            HalconAPI.Store(proc, 2, varThreshold);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(absThreshold);
            HalconAPI.UnpinTuple(varThreshold);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)refImage);
            GC.KeepAlive((object)varImage);
        }

        /// <summary>
        ///   Prepare a variation model for comparison with an image.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="refImage">Reference image of the object.</param>
        /// <param name="varImage">Variation image of the object.</param>
        /// <param name="absThreshold">Absolute minimum threshold for the differences between the image and the variation model. Default: 10</param>
        /// <param name="varThreshold">Threshold for the differences based on the variation of the variation model. Default: 2</param>
        public void PrepareDirectVariationModel(
          HImage refImage,
          HImage varImage,
          double absThreshold,
          double varThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(89);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)refImage);
            HalconAPI.Store(proc, 2, (HObjectBase)varImage);
            HalconAPI.StoreD(proc, 1, absThreshold);
            HalconAPI.StoreD(proc, 2, varThreshold);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)refImage);
            GC.KeepAlive((object)varImage);
        }

        /// <summary>
        ///   Prepare a variation model for comparison with an image.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="absThreshold">Absolute minimum threshold for the differences between the image and the variation model. Default: 10</param>
        /// <param name="varThreshold">Threshold for the differences based on the variation of the variation model. Default: 2</param>
        public void PrepareVariationModel(HTuple absThreshold, HTuple varThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(90);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, absThreshold);
            HalconAPI.Store(proc, 2, varThreshold);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(absThreshold);
            HalconAPI.UnpinTuple(varThreshold);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare a variation model for comparison with an image.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="absThreshold">Absolute minimum threshold for the differences between the image and the variation model. Default: 10</param>
        /// <param name="varThreshold">Threshold for the differences based on the variation of the variation model. Default: 2</param>
        public void PrepareVariationModel(double absThreshold, double varThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(90);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, absThreshold);
            HalconAPI.StoreD(proc, 2, varThreshold);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Train a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        /// <param name="images">Images of the object to be trained.</param>
        public void TrainVariationModel(HImage images)
        {
            IntPtr proc = HalconAPI.PreCall(91);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)images);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)images);
        }

        /// <summary>
        ///   Free the memory of the training data of a variation model.
        ///   Instance represents: ID of the variation model.
        /// </summary>
        public void ClearTrainDataVariationModel()
        {
            IntPtr proc = HalconAPI.PreCall(94);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a variation model for image comparison.
        ///   Modified instance represents: ID of the variation model.
        /// </summary>
        /// <param name="width">Width of the images to be compared. Default: 640</param>
        /// <param name="height">Height of the images to be compared. Default: 480</param>
        /// <param name="type">Type of the images to be compared. Default: "byte"</param>
        /// <param name="mode">Method used for computing the variation model. Default: "standard"</param>
        public void CreateVariationModel(int width, int height, string type, string mode)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(95);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreS(proc, 2, type);
            HalconAPI.StoreS(proc, 3, mode);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(93);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
