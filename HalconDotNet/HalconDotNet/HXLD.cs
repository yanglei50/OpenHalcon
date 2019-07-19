using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an XLD object-(array).</summary>
    [Serializable]
    public class HXLD : HObject, ISerializable, ICloneable
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HXLD()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLD(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLD(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLD(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "xld");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HXLD this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLD obj)
        {
            obj = new HXLD(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeXld();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLD(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeXld(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public new void Serialize(Stream stream)
        {
            this.SerializeXld().Serialize(stream);
        }

        public static HXLD Deserialize(Stream stream)
        {
            HXLD hxld = new HXLD();
            hxld.DeserializeXld(HSerializedItem.Deserialize(stream));
            return hxld;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HXLD Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeXld();
            HXLD hxld = new HXLD();
            hxld.DeserializeXld(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hxld;
        }

        /// <summary>
        ///   Return an XLD parallel's data (as lines).
        ///   Instance represents: Input XLD parallels.
        /// </summary>
        /// <param name="row1">Row coordinates of the points on polygon P1.</param>
        /// <param name="col1">Column coordinates of the points on polygon P1.</param>
        /// <param name="length1">Lengths of the line segments on polygon P1.</param>
        /// <param name="phi1">Angles of the line segments on polygon P1.</param>
        /// <param name="row2">Row coordinates of the points on polygon P2.</param>
        /// <param name="col2">Column coordinates of the points on polygon P2.</param>
        /// <param name="length2">Lengths of the line segments on polygon P2.</param>
        /// <param name="phi2">Angles of the line segments on polygon P2.</param>
        public void GetParallelsXld(
          out HTuple row1,
          out HTuple col1,
          out HTuple length1,
          out HTuple phi1,
          out HTuple row2,
          out HTuple col2,
          out HTuple length2,
          out HTuple phi2)
        {
            IntPtr proc = HalconAPI.PreCall(41);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out col1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out length1);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out phi1);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out row2);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out col2);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out length2);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out phi2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Display an XLD object.
        ///   Instance represents: XLD object to display.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void DispXld(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(74);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Receive an XLD object over a socket connection.
        ///   Modified instance represents: Received XLD object.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void ReceiveXld(HSocket socket)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(329);
            HalconAPI.Store(proc, 0, (HTool)socket);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Send an XLD object over a socket connection.
        ///   Instance represents: XLD object to be sent.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void SendXld(HSocket socket)
        {
            IntPtr proc = HalconAPI.PreCall(330);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)socket);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HXLD ObjDiff(HXLD objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hxld;
        }

        /// <summary>
        ///   Paint XLD objects into an image.
        ///   Instance represents: XLD objects to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the xld objects are to be painted.</param>
        /// <param name="grayval">Desired gray value of the xld object. Default: 255.0</param>
        /// <returns>Image containing the result.</returns>
        public HImage PaintXld(HImage image, HTuple grayval)
        {
            IntPtr proc = HalconAPI.PreCall(575);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, grayval);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(grayval);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Paint XLD objects into an image.
        ///   Instance represents: XLD objects to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the xld objects are to be painted.</param>
        /// <param name="grayval">Desired gray value of the xld object. Default: 255.0</param>
        /// <returns>Image containing the result.</returns>
        public HImage PaintXld(HImage image, double grayval)
        {
            IntPtr proc = HalconAPI.PreCall(575);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, grayval);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HXLD CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HXLD ConcatObj(HXLD objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hxld;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLD SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLD SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLD objects2, HTuple epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.Store(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(epsilon);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLD objects2, double epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.StoreD(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compare image objects regarding equality.
        ///   Instance represents: Test objects.
        /// </summary>
        /// <param name="objects2">Comparative objects.</param>
        /// <returns>boolean result value.</returns>
        public int TestEqualObj(HXLD objects2)
        {
            IntPtr proc = HalconAPI.PreCall(591);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compute the mapping between the distorted image and the rectified image based upon the points of a regular grid.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="meshes">Output contours.</param>
        /// <param name="gridSpacing">Distance of the grid points in the rectified image.</param>
        /// <param name="rotation">Rotation to be applied to the point grid. Default: "auto"</param>
        /// <param name="row">Row coordinates of the grid points.</param>
        /// <param name="column">Column coordinates of the grid points.</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenGridRectificationMap(
          HImage image,
          out HXLD meshes,
          int gridSpacing,
          HTuple rotation,
          HTuple row,
          HTuple column,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1159);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, gridSpacing);
            HalconAPI.Store(proc, 1, rotation);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.StoreS(proc, 4, mapType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HXLD.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Compute the mapping between the distorted image and the rectified image based upon the points of a regular grid.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="meshes">Output contours.</param>
        /// <param name="gridSpacing">Distance of the grid points in the rectified image.</param>
        /// <param name="rotation">Rotation to be applied to the point grid. Default: "auto"</param>
        /// <param name="row">Row coordinates of the grid points.</param>
        /// <param name="column">Column coordinates of the grid points.</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenGridRectificationMap(
          HImage image,
          out HXLD meshes,
          int gridSpacing,
          string rotation,
          HTuple row,
          HTuple column,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1159);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, gridSpacing);
            HalconAPI.StoreS(proc, 1, rotation);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.StoreS(proc, 4, mapType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HXLD.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Deserialize a serialized XLD object.
        ///   Modified instance represents: XLD object.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeXld(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1632);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize an XLD object.
        ///   Instance represents: XLD object.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeXld()
        {
            IntPtr proc = HalconAPI.PreCall(1633);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Test whether contours or polygons are closed.
        ///   Instance represents: Contours or polygons to be tested.
        /// </summary>
        /// <returns>Tuple with boolean numbers.</returns>
        public HTuple TestClosedXld()
        {
            IntPtr proc = HalconAPI.PreCall(1667);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Arbitrary geometric moments of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="mode">Computation mode. Default: "unnormalized"</param>
        /// <param name="area">Area enclosed by the contour or polygon.</param>
        /// <param name="centerRow">Row coordinate of the centroid.</param>
        /// <param name="centerCol">Column coordinate of the centroid.</param>
        /// <param name="p">First index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <param name="q">Second index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <returns>The computed moments.</returns>
        public HTuple MomentsAnyPointsXld(
          string mode,
          HTuple area,
          HTuple centerRow,
          HTuple centerCol,
          HTuple p,
          HTuple q)
        {
            IntPtr proc = HalconAPI.PreCall(1669);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, area);
            HalconAPI.Store(proc, 2, centerRow);
            HalconAPI.Store(proc, 3, centerCol);
            HalconAPI.Store(proc, 4, p);
            HalconAPI.Store(proc, 5, q);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(area);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(p);
            HalconAPI.UnpinTuple(q);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Arbitrary geometric moments of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="mode">Computation mode. Default: "unnormalized"</param>
        /// <param name="area">Area enclosed by the contour or polygon.</param>
        /// <param name="centerRow">Row coordinate of the centroid.</param>
        /// <param name="centerCol">Column coordinate of the centroid.</param>
        /// <param name="p">First index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <param name="q">Second index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <returns>The computed moments.</returns>
        public double MomentsAnyPointsXld(
          string mode,
          double area,
          double centerRow,
          double centerCol,
          int p,
          int q)
        {
            IntPtr proc = HalconAPI.PreCall(1669);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 1, area);
            HalconAPI.StoreD(proc, 2, centerRow);
            HalconAPI.StoreD(proc, 3, centerCol);
            HalconAPI.StoreI(proc, 4, p);
            HalconAPI.StoreI(proc, 5, q);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Anisometry of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Anisometry of the contours or polygons.</returns>
        public HTuple EccentricityPointsXld()
        {
            IntPtr proc = HalconAPI.PreCall(1670);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Parameters of the equivalent ellipse of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="rb">Minor radius.</param>
        /// <param name="phi">Angle between the major axis and the column axis (radians).</param>
        /// <returns>Major radius.</returns>
        public HTuple EllipticAxisPointsXld(out HTuple rb, out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(1671);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rb);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Parameters of the equivalent ellipse of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="rb">Minor radius.</param>
        /// <param name="phi">Angle between the major axis and the column axis (radians).</param>
        /// <returns>Major radius.</returns>
        public double EllipticAxisPointsXld(out double rb, out double phi)
        {
            IntPtr proc = HalconAPI.PreCall(1671);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out rb);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Orientation of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Orientation of the contours or polygons (radians).</returns>
        public HTuple OrientationPointsXld()
        {
            IntPtr proc = HalconAPI.PreCall(1672);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments M20@f$M_{20}$, M02@f$M_{02}$, and M11@f$M_{11}$ of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="m20">Second order moment along the row axis.</param>
        /// <param name="m02">Second order moment along the column axis.</param>
        /// <returns>Mixed second order moment.</returns>
        public HTuple MomentsPointsXld(out HTuple m20, out HTuple m02)
        {
            IntPtr proc = HalconAPI.PreCall(1673);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m20);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments M20@f$M_{20}$, M02@f$M_{02}$, and M11@f$M_{11}$ of contours or polygons treated as point clouds.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="m20">Second order moment along the row axis.</param>
        /// <param name="m02">Second order moment along the column axis.</param>
        /// <returns>Mixed second order moment.</returns>
        public double MomentsPointsXld(out double m20, out double m02)
        {
            IntPtr proc = HalconAPI.PreCall(1673);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m20);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Area and center of gravity (centroid) of contours and polygons treated as point clouds.
        ///   Instance represents: Point clouds to be examined in form of contours or polygons.
        /// </summary>
        /// <param name="row">Row coordinate of the centroid.</param>
        /// <param name="column">Column coordinate of the centroid.</param>
        /// <returns>Area of the point cloud.</returns>
        public HTuple AreaCenterPointsXld(out HTuple row, out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1674);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out row);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Area and center of gravity (centroid) of contours and polygons treated as point clouds.
        ///   Instance represents: Point clouds to be examined in form of contours or polygons.
        /// </summary>
        /// <param name="row">Row coordinate of the centroid.</param>
        /// <param name="column">Column coordinate of the centroid.</param>
        /// <returns>Area of the point cloud.</returns>
        public double AreaCenterPointsXld(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(1674);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out row);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Test XLD contours or polygons for self intersection.
        ///   Instance represents: Input contours or polygons.
        /// </summary>
        /// <param name="closeXLD">Should the input contours or polygons be closed first? Default: "true"</param>
        /// <returns>1 for contours or polygons with self intersection and 0 otherwise.</returns>
        public HTuple TestSelfIntersectionXld(string closeXLD)
        {
            IntPtr proc = HalconAPI.PreCall(1675);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, closeXLD);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLD SelectXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLD SelectXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Test whether one or more contours or polygons enclose the given point(s).
        ///   Instance represents: Contours or polygons to be tested.
        /// </summary>
        /// <param name="row">Row coordinates of the points to be tested.</param>
        /// <param name="column">Column coordinates of the points to be tested.</param>
        /// <returns>Tuple with boolean numbers.</returns>
        public HTuple TestXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1677);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether one or more contours or polygons enclose the given point(s).
        ///   Instance represents: Contours or polygons to be tested.
        /// </summary>
        /// <param name="row">Row coordinates of the points to be tested.</param>
        /// <param name="column">Column coordinates of the points to be tested.</param>
        /// <returns>Tuple with boolean numbers.</returns>
        public int TestXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1677);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Select contours or polygons using shape features.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Operation type between the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Contours or polygons fulfilling the condition(s).</returns>
        public HXLD SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1678);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.Store(proc, 2, min);
            HalconAPI.Store(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Select contours or polygons using shape features.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Operation type between the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Contours or polygons fulfilling the condition(s).</returns>
        public HXLD SelectShapeXld(string features, string operation, double min, double max)
        {
            IntPtr proc = HalconAPI.PreCall(1678);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.StoreD(proc, 2, min);
            HalconAPI.StoreD(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Orientation of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Orientation of the contours or polygons (radians).</returns>
        public HTuple OrientationXld()
        {
            IntPtr proc = HalconAPI.PreCall(1679);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape features derived from the ellipse parameters of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="bulkiness">Bulkiness of the contours or polygons.</param>
        /// <param name="structureFactor">Structure factor of the contours or polygons.</param>
        /// <returns>Anisometry of the contours or polygons.</returns>
        public HTuple EccentricityXld(out HTuple bulkiness, out HTuple structureFactor)
        {
            IntPtr proc = HalconAPI.PreCall(1680);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out bulkiness);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out structureFactor);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape features derived from the ellipse parameters of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="bulkiness">Bulkiness of the contours or polygons.</param>
        /// <param name="structureFactor">Structure factor of the contours or polygons.</param>
        /// <returns>Anisometry of the contours or polygons.</returns>
        public double EccentricityXld(out double bulkiness, out double structureFactor)
        {
            IntPtr proc = HalconAPI.PreCall(1680);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out bulkiness);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out structureFactor);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Shape factor for the compactness of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Compactness of the input contours or polygons.</returns>
        public HTuple CompactnessXld()
        {
            IntPtr proc = HalconAPI.PreCall(1681);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Maximum distance between two contour or polygon points.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of the first extreme point of the contours or polygons.</param>
        /// <param name="column1">Column coordinate of the first extreme point of the contours or polygons.</param>
        /// <param name="row2">Row coordinate of the second extreme point of the contour or polygons.</param>
        /// <param name="column2">Column coordinate of the second extreme point of the contours or polygons.</param>
        /// <param name="diameter">Distance of the two extreme points of the contours or polygons.</param>
        public void DiameterXld(
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2,
          out HTuple diameter)
        {
            IntPtr proc = HalconAPI.PreCall(1682);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out row2);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out column2);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out diameter);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Maximum distance between two contour or polygon points.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of the first extreme point of the contours or polygons.</param>
        /// <param name="column1">Column coordinate of the first extreme point of the contours or polygons.</param>
        /// <param name="row2">Row coordinate of the second extreme point of the contour or polygons.</param>
        /// <param name="column2">Column coordinate of the second extreme point of the contours or polygons.</param>
        /// <param name="diameter">Distance of the two extreme points of the contours or polygons.</param>
        public void DiameterXld(
          out double row1,
          out double column1,
          out double row2,
          out double column2,
          out double diameter)
        {
            IntPtr proc = HalconAPI.PreCall(1682);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out column2);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out diameter);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Shape factor for the convexity of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Convexity of the input contours or polygons.</returns>
        public HTuple ConvexityXld()
        {
            IntPtr proc = HalconAPI.PreCall(1683);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape factor for the circularity (similarity to a circle) of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Roundness of the input contours or polygons.</returns>
        public HTuple CircularityXld()
        {
            IntPtr proc = HalconAPI.PreCall(1684);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Parameters of the equivalent ellipse of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="rb">Minor radius.</param>
        /// <param name="phi">Angle between the major axis and the x axis (radians).</param>
        /// <returns>Major radius.</returns>
        public HTuple EllipticAxisXld(out HTuple rb, out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(1685);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rb);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Parameters of the equivalent ellipse of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="rb">Minor radius.</param>
        /// <param name="phi">Angle between the major axis and the x axis (radians).</param>
        /// <returns>Major radius.</returns>
        public double EllipticAxisXld(out double rb, out double phi)
        {
            IntPtr proc = HalconAPI.PreCall(1685);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out rb);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Smallest enclosing rectangle with arbitrary orientation of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the center point of the enclosing rectangle.</param>
        /// <param name="column">Column coordinate of the center point of the enclosing rectangle.</param>
        /// <param name="phi">Orientation of the enclosing rectangle (arc measure)</param>
        /// <param name="length1">First radius (half length) of the enclosing rectangle.</param>
        /// <param name="length2">Second radius (half width) of the enclosing rectangle.</param>
        public void SmallestRectangle2Xld(
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple length1,
          out HTuple length2)
        {
            IntPtr proc = HalconAPI.PreCall(1686);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out length1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest enclosing rectangle with arbitrary orientation of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the center point of the enclosing rectangle.</param>
        /// <param name="column">Column coordinate of the center point of the enclosing rectangle.</param>
        /// <param name="phi">Orientation of the enclosing rectangle (arc measure)</param>
        /// <param name="length1">First radius (half length) of the enclosing rectangle.</param>
        /// <param name="length2">Second radius (half width) of the enclosing rectangle.</param>
        public void SmallestRectangle2Xld(
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1686);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out length1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Enclosing rectangle parallel to the coordinate axes of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of upper left corner point of the enclosing rectangle.</param>
        /// <param name="column1">Column coordinate of upper left corner point of the enclosing rectangle.</param>
        /// <param name="row2">Row coordinate of lower right corner point of the enclosing rectangle.</param>
        /// <param name="column2">Column coordinate of lower right corner point of the enclosing rectangle.</param>
        public void SmallestRectangle1Xld(
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1687);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out row2);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Enclosing rectangle parallel to the coordinate axes of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of upper left corner point of the enclosing rectangle.</param>
        /// <param name="column1">Column coordinate of upper left corner point of the enclosing rectangle.</param>
        /// <param name="row2">Row coordinate of lower right corner point of the enclosing rectangle.</param>
        /// <param name="column2">Column coordinate of lower right corner point of the enclosing rectangle.</param>
        public void SmallestRectangle1Xld(
          out double row1,
          out double column1,
          out double row2,
          out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1687);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest enclosing circle of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the enclosing circle.</param>
        /// <param name="column">Column coordinate of the center of the enclosing circle.</param>
        /// <param name="radius">Radius of the enclosing circle.</param>
        public void SmallestCircleXld(out HTuple row, out HTuple column, out HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1688);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest enclosing circle of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the enclosing circle.</param>
        /// <param name="column">Column coordinate of the center of the enclosing circle.</param>
        /// <param name="radius">Radius of the enclosing circle.</param>
        public void SmallestCircleXld(out double row, out double column, out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1688);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform the shape of contours or polygons.
        ///   Instance represents: Contours or polygons to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed contours respectively polygons.</returns>
        public HXLD ShapeTransXld(string type)
        {
            IntPtr proc = HalconAPI.PreCall(1689);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Length of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <returns>Length of the contour or polygon.</returns>
        public HTuple LengthXld()
        {
            IntPtr proc = HalconAPI.PreCall(1690);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Arbitrary geometric moments of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="mode">Computation mode. Default: "unnormalized"</param>
        /// <param name="pointOrder">Point order along the boundary. Default: "positive"</param>
        /// <param name="area">Area enclosed by the contour or polygon.</param>
        /// <param name="centerRow">Row coordinate of the centroid.</param>
        /// <param name="centerCol">Column coordinate of the centroid.</param>
        /// <param name="p">First index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <param name="q">Second index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <returns>The computed moments.</returns>
        public HTuple MomentsAnyXld(
          string mode,
          HTuple pointOrder,
          HTuple area,
          HTuple centerRow,
          HTuple centerCol,
          HTuple p,
          HTuple q)
        {
            IntPtr proc = HalconAPI.PreCall(1691);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, pointOrder);
            HalconAPI.Store(proc, 2, area);
            HalconAPI.Store(proc, 3, centerRow);
            HalconAPI.Store(proc, 4, centerCol);
            HalconAPI.Store(proc, 5, p);
            HalconAPI.Store(proc, 6, q);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(pointOrder);
            HalconAPI.UnpinTuple(area);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(p);
            HalconAPI.UnpinTuple(q);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Arbitrary geometric moments of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="mode">Computation mode. Default: "unnormalized"</param>
        /// <param name="pointOrder">Point order along the boundary. Default: "positive"</param>
        /// <param name="area">Area enclosed by the contour or polygon.</param>
        /// <param name="centerRow">Row coordinate of the centroid.</param>
        /// <param name="centerCol">Column coordinate of the centroid.</param>
        /// <param name="p">First index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <param name="q">Second index of the desired moments M[P,Q]@f$M_{p,q}$. Default: 1</param>
        /// <returns>The computed moments.</returns>
        public double MomentsAnyXld(
          string mode,
          string pointOrder,
          double area,
          double centerRow,
          double centerCol,
          int p,
          int q)
        {
            IntPtr proc = HalconAPI.PreCall(1691);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreS(proc, 1, pointOrder);
            HalconAPI.StoreD(proc, 2, area);
            HalconAPI.StoreD(proc, 3, centerRow);
            HalconAPI.StoreD(proc, 4, centerCol);
            HalconAPI.StoreI(proc, 5, p);
            HalconAPI.StoreI(proc, 6, q);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Geometric moments M20@f$M_{20}$, M02@f$M_{02}$, and M11@f$M_{11}$ of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="m20">Second order moment along the row axis.</param>
        /// <param name="m02">Second order moment along the column axis.</param>
        /// <returns>Mixed second order moment.</returns>
        public HTuple MomentsXld(out HTuple m20, out HTuple m02)
        {
            IntPtr proc = HalconAPI.PreCall(1692);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m20);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments M20@f$M_{20}$, M02@f$M_{02}$, and M11@f$M_{11}$ of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="m20">Second order moment along the row axis.</param>
        /// <param name="m02">Second order moment along the column axis.</param>
        /// <returns>Mixed second order moment.</returns>
        public double MomentsXld(out double m20, out double m02)
        {
            IntPtr proc = HalconAPI.PreCall(1692);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m20);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Area and center of gravity (centroid) of contours and polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the centroid.</param>
        /// <param name="column">Column coordinate of the centroid.</param>
        /// <param name="pointOrder">point order along the boundary ('positive'/'negative').</param>
        /// <returns>Area enclosed by the contour or polygon.</returns>
        public HTuple AreaCenterXld(out HTuple row, out HTuple column, out HTuple pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(1693);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out row);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out column);
            int procResult = HTuple.LoadNew(proc, 3, err4, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Area and center of gravity (centroid) of contours and polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Row coordinate of the centroid.</param>
        /// <param name="column">Column coordinate of the centroid.</param>
        /// <param name="pointOrder">point order along the boundary ('positive'/'negative').</param>
        /// <returns>Area enclosed by the contour or polygon.</returns>
        public double AreaCenterXld(out double row, out double column, out string pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(1693);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out row);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out column);
            int procResult = HalconAPI.LoadS(proc, 3, err4, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Determine the 3D pose of a rectangle from its perspective 2D projection
        ///   Instance represents: Contour(s) to be examined.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="width">Width of the rectangle in meters.</param>
        /// <param name="height">Height of the rectangle in meters.</param>
        /// <param name="weightingMode">Weighting mode for the optimization phase. Default: "nonweighted"</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 3.0 for 'tukey'). Default: 2.0</param>
        /// <param name="covPose">Covariances of the pose values.</param>
        /// <param name="error">Root-mean-square value of the final residual error.</param>
        /// <returns>3D pose of the rectangle.</returns>
        public HPose[] GetRectanglePose(
          HCamPar cameraParam,
          HTuple width,
          HTuple height,
          string weightingMode,
          double clippingFactor,
          out HTuple covPose,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1908);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.Store(proc, 1, width);
            HalconAPI.Store(proc, 2, height);
            HalconAPI.StoreS(proc, 3, weightingMode);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(width);
            HalconAPI.UnpinTuple(height);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            return hposeArray;
        }

        /// <summary>
        ///   Determine the 3D pose of a rectangle from its perspective 2D projection
        ///   Instance represents: Contour(s) to be examined.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="width">Width of the rectangle in meters.</param>
        /// <param name="height">Height of the rectangle in meters.</param>
        /// <param name="weightingMode">Weighting mode for the optimization phase. Default: "nonweighted"</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 3.0 for 'tukey'). Default: 2.0</param>
        /// <param name="covPose">Covariances of the pose values.</param>
        /// <param name="error">Root-mean-square value of the final residual error.</param>
        /// <returns>3D pose of the rectangle.</returns>
        public HPose GetRectanglePose(
          HCamPar cameraParam,
          double width,
          double height,
          string weightingMode,
          double clippingFactor,
          out HTuple covPose,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1908);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreD(proc, 1, width);
            HalconAPI.StoreD(proc, 2, height);
            HalconAPI.StoreS(proc, 3, weightingMode);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Determine the 3D pose of a circle from its perspective 2D projection.
        ///   Instance represents: Contours to be examined.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="radius">Radius of the circle in object space.</param>
        /// <param name="outputType">Type of output parameters. Default: "pose"</param>
        /// <param name="pose2">3D pose of the second circle.</param>
        /// <returns>3D pose of the first circle.</returns>
        public HTuple GetCirclePose(
          HCamPar cameraParam,
          HTuple radius,
          string outputType,
          out HTuple pose2)
        {
            IntPtr proc = HalconAPI.PreCall(1909);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.Store(proc, 1, radius);
            HalconAPI.StoreS(proc, 2, outputType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(radius);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out pose2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Determine the 3D pose of a circle from its perspective 2D projection.
        ///   Instance represents: Contours to be examined.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="radius">Radius of the circle in object space.</param>
        /// <param name="outputType">Type of output parameters. Default: "pose"</param>
        /// <param name="pose2">3D pose of the second circle.</param>
        /// <returns>3D pose of the first circle.</returns>
        public HTuple GetCirclePose(
          HCamPar cameraParam,
          double radius,
          string outputType,
          out HTuple pose2)
        {
            IntPtr proc = HalconAPI.PreCall(1909);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreD(proc, 1, radius);
            HalconAPI.StoreS(proc, 2, outputType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out pose2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the width, height, and aspect ratio of the enclosing rectangle parallel to the coordinate axes of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="width">Width of the enclosing rectangle.</param>
        /// <param name="ratio">Aspect ratio of the enclosing rectangle.</param>
        /// <returns>Height of the enclosing rectangle.</returns>
        public HTuple HeightWidthRatioXld(out HTuple width, out HTuple ratio)
        {
            IntPtr proc = HalconAPI.PreCall(2120);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out width);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out ratio);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the width, height, and aspect ratio of the enclosing rectangle parallel to the coordinate axes of contours or polygons.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="width">Width of the enclosing rectangle.</param>
        /// <param name="ratio">Aspect ratio of the enclosing rectangle.</param>
        /// <returns>Height of the enclosing rectangle.</returns>
        public double HeightWidthRatioXld(out double width, out double ratio)
        {
            IntPtr proc = HalconAPI.PreCall(2120);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out width);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out ratio);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HXLD InsertObj(HXLD objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hxld;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLD RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLD RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLD ReplaceObj(HXLD objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxld;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLD ReplaceObj(HXLD objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxld;
        }
    }
}
