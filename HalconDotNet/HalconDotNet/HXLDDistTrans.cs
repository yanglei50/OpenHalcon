// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HXLDDistTrans
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a XLD distance transformation.</summary>
    [Serializable]
    public class HXLDDistTrans : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDDistTrans()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDDistTrans(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDDistTrans obj)
        {
            obj = new HXLDDistTrans(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDDistTrans[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HXLDDistTrans[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HXLDDistTrans(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read an XLD distance transform from a file.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public HXLDDistTrans(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1353);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create the XLD distance transform.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="contour">Reference contour(s).</param>
        /// <param name="mode">Compute the distance to points ('point_to_point') or entire segments ('point_to_segment'). Default: "point_to_point"</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 20.0</param>
        public HXLDDistTrans(HXLDCont contour, string mode, HTuple maxDistance)
        {
            IntPtr proc = HalconAPI.PreCall(1360);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(maxDistance);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
        }

        /// <summary>
        ///   Create the XLD distance transform.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="contour">Reference contour(s).</param>
        /// <param name="mode">Compute the distance to points ('point_to_point') or entire segments ('point_to_segment'). Default: "point_to_point"</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 20.0</param>
        public HXLDDistTrans(HXLDCont contour, string mode, double maxDistance)
        {
            IntPtr proc = HalconAPI.PreCall(1360);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 1, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDistanceTransformXld();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDDistTrans(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDistanceTransformXld(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDistanceTransformXld().Serialize(stream);
        }

        public static HXLDDistTrans Deserialize(Stream stream)
        {
            HXLDDistTrans hxldDistTrans = new HXLDDistTrans();
            hxldDistTrans.DeserializeDistanceTransformXld(HSerializedItem.Deserialize(stream));
            return hxldDistTrans;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HXLDDistTrans Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDistanceTransformXld();
            HXLDDistTrans hxldDistTrans = new HXLDDistTrans();
            hxldDistTrans.DeserializeDistanceTransformXld(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hxldDistTrans;
        }

        /// <summary>
        ///   Determine the pointwise distance of two contours using an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform of the reference contour.
        /// </summary>
        /// <param name="contour">Contour(s) for whose points the distances are calculated.</param>
        /// <returns>Copy of Contour containing the distances as an attribute.</returns>
        public HXLDCont ApplyDistanceTransformXld(HXLDCont contour)
        {
            IntPtr proc = HalconAPI.PreCall(1352);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
            return hxldCont;
        }

        /// <summary>
        ///   Read an XLD distance transform from a file.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void ReadDistanceTransformXld(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1353);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize an XLD distance transform.
        ///   Modified instance represents: Handle of the deserialized XLD distance  transform.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized XLD distance  transform.</param>
        public void DeserializeDistanceTransformXld(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1354);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <returns>Handle of the serialized XLD distance  transform.</returns>
        public HSerializedItem SerializeDistanceTransformXld()
        {
            IntPtr proc = HalconAPI.PreCall(1355);
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
        ///   Write an XLD distance transform into a file.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void WriteDistanceTransformXld(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1356);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set new parameters for an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "mode"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "point_to_point"</param>
        public void SetDistanceTransformXldParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1357);
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
        ///   Set new parameters for an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "mode"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: "point_to_point"</param>
        public void SetDistanceTransformXldParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1357);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the parameters used to build an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "mode"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDistanceTransformXldParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1358);
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
        ///   Get the parameters used to build an XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters. Default: "mode"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDistanceTransformXldParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1358);
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
        ///   Get the reference contour used to build the XLD distance transform.
        ///   Instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <returns>Reference contour.</returns>
        public HXLDCont GetDistanceTransformXldContour()
        {
            IntPtr proc = HalconAPI.PreCall(1359);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Create the XLD distance transform.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="contour">Reference contour(s).</param>
        /// <param name="mode">Compute the distance to points ('point_to_point') or entire segments ('point_to_segment'). Default: "point_to_point"</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 20.0</param>
        public void CreateDistanceTransformXld(HXLDCont contour, string mode, HTuple maxDistance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1360);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(maxDistance);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
        }

        /// <summary>
        ///   Create the XLD distance transform.
        ///   Modified instance represents: Handle of the XLD distance transform.
        /// </summary>
        /// <param name="contour">Reference contour(s).</param>
        /// <param name="mode">Compute the distance to points ('point_to_point') or entire segments ('point_to_segment'). Default: "point_to_point"</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 20.0</param>
        public void CreateDistanceTransformXld(HXLDCont contour, string mode, double maxDistance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1360);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 1, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1351);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
