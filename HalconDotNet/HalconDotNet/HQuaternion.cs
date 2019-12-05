// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HQuaternion
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents a quaternion.</summary>
    [Serializable]
    public class HQuaternion : HData, ISerializable, ICloneable
    {
        private const int FIXEDSIZE = 4;

        /// <summary>Create an uninitialized instance.</summary>
        public HQuaternion()
        {
        }

        public HQuaternion(HTuple tuple)
          : base(tuple)
        {
        }

        internal HQuaternion(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HQuaternion obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HQuaternion(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HQuaternion obj)
        {
            return HQuaternion.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        internal static HQuaternion[] SplitArray(HTuple data)
        {
            int length = data.Length / 4;
            HQuaternion[] hquaternionArray = new HQuaternion[length];
            for (int index = 0; index < length; ++index)
                hquaternionArray[index] = new HQuaternion(new HData(data.TupleSelectRange((HTuple)(index * 4), (HTuple)((index + 1) * 4 - 1))));
            return hquaternionArray;
        }

        /// <summary>
        ///   Create a rotation quaternion.
        ///   Modified instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="axisX">X component of the rotation axis.</param>
        /// <param name="axisY">Y component of the rotation axis.</param>
        /// <param name="axisZ">Z component of the rotation axis.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        public HQuaternion(HTuple axisX, HTuple axisY, HTuple axisZ, HTuple angle)
        {
            IntPtr proc = HalconAPI.PreCall(225);
            HalconAPI.Store(proc, 0, axisX);
            HalconAPI.Store(proc, 1, axisY);
            HalconAPI.Store(proc, 2, axisZ);
            HalconAPI.Store(proc, 3, angle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(axisX);
            HalconAPI.UnpinTuple(axisY);
            HalconAPI.UnpinTuple(axisZ);
            HalconAPI.UnpinTuple(angle);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rotation quaternion.
        ///   Modified instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="axisX">X component of the rotation axis.</param>
        /// <param name="axisY">Y component of the rotation axis.</param>
        /// <param name="axisZ">Z component of the rotation axis.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        public HQuaternion(double axisX, double axisY, double axisZ, double angle)
        {
            IntPtr proc = HalconAPI.PreCall(225);
            HalconAPI.StoreD(proc, 0, axisX);
            HalconAPI.StoreD(proc, 1, axisY);
            HalconAPI.StoreD(proc, 2, axisZ);
            HalconAPI.StoreD(proc, 3, angle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeQuat();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HQuaternion(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeQuat(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeQuat().Serialize(stream);
        }

        public static HQuaternion Deserialize(Stream stream)
        {
            HQuaternion hquaternion = new HQuaternion();
            hquaternion.DeserializeQuat(HSerializedItem.Deserialize(stream));
            return hquaternion;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HQuaternion Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeQuat();
            HQuaternion hquaternion = new HQuaternion();
            hquaternion.DeserializeQuat(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hquaternion;
        }

        /// <summary>Composes two quaternions</summary>
        public static HQuaternion operator *(HQuaternion left, HQuaternion right)
        {
            return left.QuatCompose(right);
        }

        /// <summary>Convert to pose</summary>
        public static implicit operator HPose(HQuaternion quaternion)
        {
            return quaternion.QuatToPose();
        }

        /// <summary>Convert to matrix</summary>
        public static implicit operator HHomMat3D(HQuaternion quaternion)
        {
            return quaternion.QuatToHomMat3d();
        }

        /// <summary>Conjugate a quaternion</summary>
        public static HQuaternion operator ~(HQuaternion quaternion)
        {
            return quaternion.QuatConjugate();
        }

        /// <summary>
        ///   Perform a rotation by a unit quaternion.
        ///   Instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="px">X coordinate of the point to be rotated.</param>
        /// <param name="py">Y coordinate of the point to be rotated.</param>
        /// <param name="pz">Z coordinate of the point to be rotated.</param>
        /// <param name="qy">Y coordinate of the rotated point.</param>
        /// <param name="qz">Z coordinate of the rotated point.</param>
        /// <returns>X coordinate of the rotated point.</returns>
        public double QuatRotatePoint3d(
          double px,
          double py,
          double pz,
          out double qy,
          out double qz)
        {
            IntPtr proc = HalconAPI.PreCall(222);
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
        ///   Generate the conjugation of a quaternion.
        ///   Instance represents: Input quaternion.
        /// </summary>
        /// <returns>Conjugated quaternion.</returns>
        public HQuaternion QuatConjugate()
        {
            IntPtr proc = HalconAPI.PreCall(223);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HQuaternion hquaternion;
            int procResult = HQuaternion.LoadNew(proc, 0, err, out hquaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hquaternion;
        }

        /// <summary>
        ///   Normalize a quaternion.
        ///   Instance represents: Input quaternion.
        /// </summary>
        /// <returns>Normalized quaternion.</returns>
        public HQuaternion QuatNormalize()
        {
            IntPtr proc = HalconAPI.PreCall(224);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HQuaternion hquaternion;
            int procResult = HQuaternion.LoadNew(proc, 0, err, out hquaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hquaternion;
        }

        /// <summary>
        ///   Create a rotation quaternion.
        ///   Modified instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="axisX">X component of the rotation axis.</param>
        /// <param name="axisY">Y component of the rotation axis.</param>
        /// <param name="axisZ">Z component of the rotation axis.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        public void AxisAngleToQuat(HTuple axisX, HTuple axisY, HTuple axisZ, HTuple angle)
        {
            IntPtr proc = HalconAPI.PreCall(225);
            HalconAPI.Store(proc, 0, axisX);
            HalconAPI.Store(proc, 1, axisY);
            HalconAPI.Store(proc, 2, axisZ);
            HalconAPI.Store(proc, 3, angle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(axisX);
            HalconAPI.UnpinTuple(axisY);
            HalconAPI.UnpinTuple(axisZ);
            HalconAPI.UnpinTuple(angle);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rotation quaternion.
        ///   Modified instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="axisX">X component of the rotation axis.</param>
        /// <param name="axisY">Y component of the rotation axis.</param>
        /// <param name="axisZ">Z component of the rotation axis.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        public void AxisAngleToQuat(double axisX, double axisY, double axisZ, double angle)
        {
            IntPtr proc = HalconAPI.PreCall(225);
            HalconAPI.StoreD(proc, 0, axisX);
            HalconAPI.StoreD(proc, 1, axisY);
            HalconAPI.StoreD(proc, 2, axisZ);
            HalconAPI.StoreD(proc, 3, angle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert a quaternion into the corresponding 3D pose.
        ///   Instance represents: Rotation quaternion.
        /// </summary>
        /// <returns>3D Pose.</returns>
        public HPose QuatToPose()
        {
            IntPtr proc = HalconAPI.PreCall(226);
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

        /// <summary>
        ///   Convert a quaternion into the corresponding rotation matrix.
        ///   Instance represents: Rotation quaternion.
        /// </summary>
        /// <returns>Rotation matrix.</returns>
        public HHomMat3D QuatToHomMat3d()
        {
            IntPtr proc = HalconAPI.PreCall(229);
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

        /// <summary>Convert the rotational part of a 3D pose to a quaternion.</summary>
        /// <param name="pose">3D Pose.</param>
        /// <returns>Rotation quaternion.</returns>
        public static HQuaternion[] PoseToQuat(HPose[] pose)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(230);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HQuaternion.SplitArray(tuple);
        }

        /// <summary>
        ///   Convert the rotational part of a 3D pose to a quaternion.
        ///   Modified instance represents: Rotation quaternion.
        /// </summary>
        /// <param name="pose">3D Pose.</param>
        public void PoseToQuat(HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(230);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Interpolation of two quaternions.
        ///   Instance represents: Start quaternion.
        /// </summary>
        /// <param name="quaternionEnd">End quaternion.</param>
        /// <param name="interpPos">Interpolation parameter. Default: 0.5</param>
        /// <returns>Interpolated quaternion.</returns>
        public HQuaternion QuatInterpolate(HQuaternion quaternionEnd, HTuple interpPos)
        {
            IntPtr proc = HalconAPI.PreCall(231);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)quaternionEnd);
            HalconAPI.Store(proc, 2, interpPos);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)quaternionEnd));
            HalconAPI.UnpinTuple(interpPos);
            HQuaternion hquaternion;
            int procResult = HQuaternion.LoadNew(proc, 0, err, out hquaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hquaternion;
        }

        /// <summary>
        ///   Multiply two quaternions.
        ///   Instance represents: Left quaternion.
        /// </summary>
        /// <param name="quaternionRight">Right quaternion.</param>
        /// <returns>Product of the input quaternions.</returns>
        public HQuaternion QuatCompose(HQuaternion quaternionRight)
        {
            IntPtr proc = HalconAPI.PreCall(232);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)quaternionRight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)quaternionRight));
            HQuaternion hquaternion;
            int procResult = HQuaternion.LoadNew(proc, 0, err, out hquaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hquaternion;
        }

        /// <summary>
        ///   Deserialize a serialized quaternion.
        ///   Modified instance represents: Quaternion.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeQuat(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(237);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a quaternion.
        ///   Instance represents: Quaternion.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeQuat()
        {
            IntPtr proc = HalconAPI.PreCall(238);
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
    }
}
