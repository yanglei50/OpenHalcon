// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HHomMat3D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents a homogeneous 3D transformation matrix.</summary>
    [Serializable]
    public class HHomMat3D : HData, ISerializable, ICloneable
    {
        private const int FIXEDSIZE = 12;

        public HHomMat3D(HTuple tuple)
          : base(tuple)
        {
        }

        internal HHomMat3D(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HHomMat3D obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HHomMat3D(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HHomMat3D obj)
        {
            return HHomMat3D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        internal static HHomMat3D[] SplitArray(HTuple data)
        {
            int length = data.Length / 12;
            HHomMat3D[] hhomMat3DArray = new HHomMat3D[length];
            for (int index = 0; index < length; ++index)
                hhomMat3DArray[index] = new HHomMat3D(new HData(data.TupleSelectRange((HTuple)(index * 12), (HTuple)((index + 1) * 12 - 1))));
            return hhomMat3DArray;
        }

        /// <summary>
        ///   Generate the homogeneous transformation matrix of the identical 3D transformation.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        public HHomMat3D()
        {
            IntPtr proc = HalconAPI.PreCall(253);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeHomMat3d();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HHomMat3D(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeHomMat3d(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeHomMat3d().Serialize(stream);
        }

        public static HHomMat3D Deserialize(Stream stream)
        {
            HHomMat3D hhomMat3D = new HHomMat3D();
            hhomMat3D.DeserializeHomMat3d(HSerializedItem.Deserialize(stream));
            return hhomMat3D;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HHomMat3D Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeHomMat3d();
            HHomMat3D hhomMat3D = new HHomMat3D();
            hhomMat3D.DeserializeHomMat3d(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hhomMat3D;
        }

        /// <summary>
        ///   Deserialize a serialized homogeneous 3D transformation matrix.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeHomMat3d(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(233);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a homogeneous 3D transformation matrix.
        ///   Instance represents: Transformation matrix.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeHomMat3d()
        {
            IntPtr proc = HalconAPI.PreCall(234);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Project a homogeneous 3D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qz">Output point (z coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public HTuple ProjectiveTransHomPoint3d(
          HTuple px,
          HTuple py,
          HTuple pz,
          HTuple pw,
          out HTuple qy,
          out HTuple qz,
          out HTuple qw)
        {
            IntPtr proc = HalconAPI.PreCall(239);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.Store(proc, 4, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HalconAPI.UnpinTuple(pw);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out qz);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Project a homogeneous 3D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qz">Output point (z coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public double ProjectiveTransHomPoint3d(
          double px,
          double py,
          double pz,
          double pw,
          out double qy,
          out double qz,
          out double qw)
        {
            IntPtr proc = HalconAPI.PreCall(239);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pz);
            HalconAPI.StoreD(proc, 4, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qy);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out qz);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Project a 3D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qz">Output point (z coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public HTuple ProjectiveTransPoint3d(
          HTuple px,
          HTuple py,
          HTuple pz,
          out HTuple qy,
          out HTuple qz)
        {
            IntPtr proc = HalconAPI.PreCall(240);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out qz);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Project a 3D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qz">Output point (z coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public double ProjectiveTransPoint3d(
          double px,
          double py,
          double pz,
          out double qy,
          out double qz)
        {
            IntPtr proc = HalconAPI.PreCall(240);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qy);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out qz);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Apply an arbitrary affine 3D transformation to points.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Input point(s) (x coordinate). Default: 64</param>
        /// <param name="py">Input point(s) (y coordinate). Default: 64</param>
        /// <param name="pz">Input point(s) (z coordinate). Default: 64</param>
        /// <param name="qy">Output point(s) (y coordinate).</param>
        /// <param name="qz">Output point(s) (z coordinate).</param>
        /// <returns>Output point(s) (x coordinate).</returns>
        public HTuple AffineTransPoint3d(
          HTuple px,
          HTuple py,
          HTuple pz,
          out HTuple qy,
          out HTuple qz)
        {
            IntPtr proc = HalconAPI.PreCall(241);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out qz);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Apply an arbitrary affine 3D transformation to points.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Input point(s) (x coordinate). Default: 64</param>
        /// <param name="py">Input point(s) (y coordinate). Default: 64</param>
        /// <param name="pz">Input point(s) (z coordinate). Default: 64</param>
        /// <param name="qy">Output point(s) (y coordinate).</param>
        /// <param name="qz">Output point(s) (z coordinate).</param>
        /// <returns>Output point(s) (x coordinate).</returns>
        public double AffineTransPoint3d(
          double px,
          double py,
          double pz,
          out double qy,
          out double qz)
        {
            IntPtr proc = HalconAPI.PreCall(241);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qy);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out qz);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Approximate a 3D transformation from point correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="transformationType">Type of the transformation to compute. Default: "rigid"</param>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="pz">Z coordinates of the original points.</param>
        /// <param name="qx">X coordinates of the transformed points.</param>
        /// <param name="qy">Y coordinates of the transformed points.</param>
        /// <param name="qz">Z coordinates of the transformed points.</param>
        public void VectorToHomMat3d(
          string transformationType,
          HTuple px,
          HTuple py,
          HTuple pz,
          HTuple qx,
          HTuple qy,
          HTuple qz)
        {
            IntPtr proc = HalconAPI.PreCall(242);
            HalconAPI.StoreS(proc, 0, transformationType);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.Store(proc, 4, qx);
            HalconAPI.Store(proc, 5, qy);
            HalconAPI.Store(proc, 6, qz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            HalconAPI.UnpinTuple(qz);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the determinant of a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Determinant of the input matrix.</returns>
        public double HomMat3dDeterminant()
        {
            IntPtr proc = HalconAPI.PreCall(243);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Transpose a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dTranspose()
        {
            IntPtr proc = HalconAPI.PreCall(244);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Invert a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dInvert()
        {
            IntPtr proc = HalconAPI.PreCall(245);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Multiply two homogeneous 3D transformation matrices.
        ///   Instance represents: Left input transformation matrix.
        /// </summary>
        /// <param name="homMat3DRight">Right input transformation matrix.</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dCompose(HHomMat3D homMat3DRight)
        {
            IntPtr proc = HalconAPI.PreCall(246);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)homMat3DRight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)homMat3DRight));
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="axis">Axis, to be rotated around. Default: "x"</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dRotateLocal(HTuple phi, HTuple axis)
        {
            IntPtr proc = HalconAPI.PreCall(247);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, phi);
            HalconAPI.Store(proc, 2, axis);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(axis);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="axis">Axis, to be rotated around. Default: "x"</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dRotateLocal(double phi, string axis)
        {
            IntPtr proc = HalconAPI.PreCall(247);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, phi);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="axis">Axis, to be rotated around. Default: "x"</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <param name="pz">Fixed point of the transformation (z coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dRotate(
          HTuple phi,
          HTuple axis,
          HTuple px,
          HTuple py,
          HTuple pz)
        {
            IntPtr proc = HalconAPI.PreCall(248);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, phi);
            HalconAPI.Store(proc, 2, axis);
            HalconAPI.Store(proc, 3, px);
            HalconAPI.Store(proc, 4, py);
            HalconAPI.Store(proc, 5, pz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(axis);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="axis">Axis, to be rotated around. Default: "x"</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <param name="pz">Fixed point of the transformation (z coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dRotate(
          double phi,
          string axis,
          double px,
          double py,
          double pz)
        {
            IntPtr proc = HalconAPI.PreCall(248);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, phi);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.StoreD(proc, 3, px);
            HalconAPI.StoreD(proc, 4, py);
            HalconAPI.StoreD(proc, 5, pz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="sz">Scale factor along the z-axis. Default: 2</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dScaleLocal(HTuple sx, HTuple sy, HTuple sz)
        {
            IntPtr proc = HalconAPI.PreCall(249);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, sx);
            HalconAPI.Store(proc, 2, sy);
            HalconAPI.Store(proc, 3, sz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(sx);
            HalconAPI.UnpinTuple(sy);
            HalconAPI.UnpinTuple(sz);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="sz">Scale factor along the z-axis. Default: 2</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dScaleLocal(double sx, double sy, double sz)
        {
            IntPtr proc = HalconAPI.PreCall(249);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, sx);
            HalconAPI.StoreD(proc, 2, sy);
            HalconAPI.StoreD(proc, 3, sz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="sz">Scale factor along the z-axis. Default: 2</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <param name="pz">Fixed point of the transformation (z coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dScale(
          HTuple sx,
          HTuple sy,
          HTuple sz,
          HTuple px,
          HTuple py,
          HTuple pz)
        {
            IntPtr proc = HalconAPI.PreCall(250);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, sx);
            HalconAPI.Store(proc, 2, sy);
            HalconAPI.Store(proc, 3, sz);
            HalconAPI.Store(proc, 4, px);
            HalconAPI.Store(proc, 5, py);
            HalconAPI.Store(proc, 6, pz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(sx);
            HalconAPI.UnpinTuple(sy);
            HalconAPI.UnpinTuple(sz);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="sz">Scale factor along the z-axis. Default: 2</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <param name="pz">Fixed point of the transformation (z coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dScale(
          double sx,
          double sy,
          double sz,
          double px,
          double py,
          double pz)
        {
            IntPtr proc = HalconAPI.PreCall(250);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, sx);
            HalconAPI.StoreD(proc, 2, sy);
            HalconAPI.StoreD(proc, 3, sz);
            HalconAPI.StoreD(proc, 4, px);
            HalconAPI.StoreD(proc, 5, py);
            HalconAPI.StoreD(proc, 6, pz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <param name="tz">Translation along the z-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dTranslateLocal(HTuple tx, HTuple ty, HTuple tz)
        {
            IntPtr proc = HalconAPI.PreCall(251);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, tx);
            HalconAPI.Store(proc, 2, ty);
            HalconAPI.Store(proc, 3, tz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(tx);
            HalconAPI.UnpinTuple(ty);
            HalconAPI.UnpinTuple(tz);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <param name="tz">Translation along the z-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dTranslateLocal(double tx, double ty, double tz)
        {
            IntPtr proc = HalconAPI.PreCall(251);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, tx);
            HalconAPI.StoreD(proc, 2, ty);
            HalconAPI.StoreD(proc, 3, tz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <param name="tz">Translation along the z-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dTranslate(HTuple tx, HTuple ty, HTuple tz)
        {
            IntPtr proc = HalconAPI.PreCall(252);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, tx);
            HalconAPI.Store(proc, 2, ty);
            HalconAPI.Store(proc, 3, tz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(tx);
            HalconAPI.UnpinTuple(ty);
            HalconAPI.UnpinTuple(tz);
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 3D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <param name="tz">Translation along the z-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat3D HomMat3dTranslate(double tx, double ty, double tz)
        {
            IntPtr proc = HalconAPI.PreCall(252);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, tx);
            HalconAPI.StoreD(proc, 2, ty);
            HalconAPI.StoreD(proc, 3, tz);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Generate the homogeneous transformation matrix of the identical 3D transformation.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        public void HomMat3dIdentity()
        {
            IntPtr proc = HalconAPI.PreCall(253);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Project an affine 3D transformation matrix to a 2D projective transformation matrix.
        ///   Instance represents: 3x4 3D transformation matrix.
        /// </summary>
        /// <param name="principalPointRow">Row coordinate of the principal point. Default: 256</param>
        /// <param name="principalPointCol">Column coordinate of the principal point. Default: 256</param>
        /// <param name="focus">Focal length in pixels. Default: 256</param>
        /// <returns>Homogeneous projective transformation matrix.</returns>
        public HHomMat2D HomMat3dProject(
          HTuple principalPointRow,
          HTuple principalPointCol,
          HTuple focus)
        {
            IntPtr proc = HalconAPI.PreCall(254);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, principalPointRow);
            HalconAPI.Store(proc, 2, principalPointCol);
            HalconAPI.Store(proc, 3, focus);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(principalPointRow);
            HalconAPI.UnpinTuple(principalPointCol);
            HalconAPI.UnpinTuple(focus);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Project an affine 3D transformation matrix to a 2D projective transformation matrix.
        ///   Instance represents: 3x4 3D transformation matrix.
        /// </summary>
        /// <param name="principalPointRow">Row coordinate of the principal point. Default: 256</param>
        /// <param name="principalPointCol">Column coordinate of the principal point. Default: 256</param>
        /// <param name="focus">Focal length in pixels. Default: 256</param>
        /// <returns>Homogeneous projective transformation matrix.</returns>
        public HHomMat2D HomMat3dProject(
          double principalPointRow,
          double principalPointCol,
          double focus)
        {
            IntPtr proc = HalconAPI.PreCall(254);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, principalPointRow);
            HalconAPI.StoreD(proc, 2, principalPointCol);
            HalconAPI.StoreD(proc, 3, focus);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Project a homogeneous 3D point using a 3x4 projection matrix.
        ///   Instance represents: 3x4 projection matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public HTuple ProjectHomPointHomMat3d(
          HTuple px,
          HTuple py,
          HTuple pz,
          HTuple pw,
          out HTuple qy,
          out HTuple qw)
        {
            IntPtr proc = HalconAPI.PreCall(1930);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.Store(proc, 4, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HalconAPI.UnpinTuple(pw);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Project a homogeneous 3D point using a 3x4 projection matrix.
        ///   Instance represents: 3x4 projection matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public double ProjectHomPointHomMat3d(
          double px,
          double py,
          double pz,
          double pw,
          out double qy,
          out double qw)
        {
            IntPtr proc = HalconAPI.PreCall(1930);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pz);
            HalconAPI.StoreD(proc, 4, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qy);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Project a 3D point using a 3x4 projection matrix.
        ///   Instance represents: 3x4 projection matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public HTuple ProjectPointHomMat3d(HTuple px, HTuple py, HTuple pz, out HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(1931);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pz);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Project a 3D point using a 3x4 projection matrix.
        ///   Instance represents: 3x4 projection matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pz">Input point (z coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public double ProjectPointHomMat3d(double px, double py, double pz, out double qy)
        {
            IntPtr proc = HalconAPI.PreCall(1931);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pz);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out qy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Convert a homogeneous transformation matrix into a 3D pose.
        ///   Instance represents: Homogeneous transformation matrix.
        /// </summary>
        /// <returns>Equivalent 3D pose.</returns>
        public HPose HomMat3dToPose()
        {
            IntPtr proc = HalconAPI.PreCall(1934);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }
    }
}
