// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDualQuaternion
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents a dual quaternion.</summary>
    [Serializable]
    public class HDualQuaternion : HData, ISerializable, ICloneable
    {
        private const int FIXEDSIZE = 8;

        /// <summary>Create an uninitialized instance.</summary>
        public HDualQuaternion()
        {
        }

        public HDualQuaternion(HTuple tuple)
          : base(tuple)
        {
        }

        internal HDualQuaternion(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HDualQuaternion obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDualQuaternion(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDualQuaternion obj)
        {
            return HDualQuaternion.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        internal static HDualQuaternion[] SplitArray(HTuple data)
        {
            int length = data.Length / 8;
            HDualQuaternion[] hdualQuaternionArray = new HDualQuaternion[length];
            for (int index = 0; index < length; ++index)
                hdualQuaternionArray[index] = new HDualQuaternion(new HData(data.TupleSelectRange((HTuple)(index * 8), (HTuple)((index + 1) * 8 - 1))));
            return hdualQuaternionArray;
        }

        /// <summary>
        ///   Convert a 3D pose to a unit dual quaternion.
        ///   Modified instance represents: Unit dual quaternion.
        /// </summary>
        /// <param name="pose">3D pose.</param>
        public HDualQuaternion(HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(2080);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert a screw into a dual quaternion.
        ///   Modified instance represents: Dual quaternion.
        /// </summary>
        /// <param name="screwFormat">Format of the screw parameters. Default: "moment"</param>
        /// <param name="axisDirectionX">X component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionY">Y component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionZ">Z component of the direction vector of the screw axis.</param>
        /// <param name="axisMomentOrPointX">X component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointY">Y component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointZ">Z component of the moment vector or a point on the screw axis.</param>
        /// <param name="rotation">Rotation angle in radians.</param>
        /// <param name="translation">Translation.</param>
        public HDualQuaternion(
          string screwFormat,
          HTuple axisDirectionX,
          HTuple axisDirectionY,
          HTuple axisDirectionZ,
          HTuple axisMomentOrPointX,
          HTuple axisMomentOrPointY,
          HTuple axisMomentOrPointZ,
          HTuple rotation,
          HTuple translation)
        {
            IntPtr proc = HalconAPI.PreCall(2086);
            HalconAPI.StoreS(proc, 0, screwFormat);
            HalconAPI.Store(proc, 1, axisDirectionX);
            HalconAPI.Store(proc, 2, axisDirectionY);
            HalconAPI.Store(proc, 3, axisDirectionZ);
            HalconAPI.Store(proc, 4, axisMomentOrPointX);
            HalconAPI.Store(proc, 5, axisMomentOrPointY);
            HalconAPI.Store(proc, 6, axisMomentOrPointZ);
            HalconAPI.Store(proc, 7, rotation);
            HalconAPI.Store(proc, 8, translation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(axisDirectionX);
            HalconAPI.UnpinTuple(axisDirectionY);
            HalconAPI.UnpinTuple(axisDirectionZ);
            HalconAPI.UnpinTuple(axisMomentOrPointX);
            HalconAPI.UnpinTuple(axisMomentOrPointY);
            HalconAPI.UnpinTuple(axisMomentOrPointZ);
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(translation);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert a screw into a dual quaternion.
        ///   Modified instance represents: Dual quaternion.
        /// </summary>
        /// <param name="screwFormat">Format of the screw parameters. Default: "moment"</param>
        /// <param name="axisDirectionX">X component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionY">Y component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionZ">Z component of the direction vector of the screw axis.</param>
        /// <param name="axisMomentOrPointX">X component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointY">Y component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointZ">Z component of the moment vector or a point on the screw axis.</param>
        /// <param name="rotation">Rotation angle in radians.</param>
        /// <param name="translation">Translation.</param>
        public HDualQuaternion(
          string screwFormat,
          double axisDirectionX,
          double axisDirectionY,
          double axisDirectionZ,
          double axisMomentOrPointX,
          double axisMomentOrPointY,
          double axisMomentOrPointZ,
          double rotation,
          double translation)
        {
            IntPtr proc = HalconAPI.PreCall(2086);
            HalconAPI.StoreS(proc, 0, screwFormat);
            HalconAPI.StoreD(proc, 1, axisDirectionX);
            HalconAPI.StoreD(proc, 2, axisDirectionY);
            HalconAPI.StoreD(proc, 3, axisDirectionZ);
            HalconAPI.StoreD(proc, 4, axisMomentOrPointX);
            HalconAPI.StoreD(proc, 5, axisMomentOrPointY);
            HalconAPI.StoreD(proc, 6, axisMomentOrPointZ);
            HalconAPI.StoreD(proc, 7, rotation);
            HalconAPI.StoreD(proc, 8, translation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDualQuat();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDualQuaternion(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDualQuat(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDualQuat().Serialize(stream);
        }

        public static HDualQuaternion Deserialize(Stream stream)
        {
            HDualQuaternion hdualQuaternion = new HDualQuaternion();
            hdualQuaternion.DeserializeDualQuat(HSerializedItem.Deserialize(stream));
            return hdualQuaternion;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDualQuaternion Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDualQuat();
            HDualQuaternion hdualQuaternion = new HDualQuaternion();
            hdualQuaternion.DeserializeDualQuat(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdualQuaternion;
        }

        /// <summary>Composes two dual quaternions</summary>
        public static HDualQuaternion operator *(
          HDualQuaternion left,
          HDualQuaternion right)
        {
            return left.DualQuatCompose(right);
        }

        /// <summary>Convert to pose</summary>
        public static implicit operator HPose(HDualQuaternion dualQuaternion)
        {
            return dualQuaternion.DualQuatToPose();
        }

        /// <summary>Convert to matrix</summary>
        public static implicit operator HHomMat3D(HDualQuaternion dualQuaternion)
        {
            return dualQuaternion.DualQuatToHomMat3d();
        }

        /// <summary>Conjugate a dual quaternion</summary>
        public static HDualQuaternion operator ~(HDualQuaternion dualQuaternion)
        {
            return dualQuaternion.DualQuatConjugate();
        }

        /// <summary>Create a dual quaternion from eight double values </summary>
        public HDualQuaternion(
          double realW,
          double realX,
          double realY,
          double realZ,
          double dualW,
          double dualX,
          double dualY,
          double dualZ)
          : base(new HTuple(new double[8]
          {
        realW,
        realX,
        realY,
        realZ,
        dualW,
        dualX,
        dualY,
        dualZ
          }))
        {
        }

        /// <summary>Create a dual quaternion from two quaternions </summary>
        public HDualQuaternion(HQuaternion quat1, HQuaternion quat2)
          : base(quat1.RawData.TupleConcat(quat2.RawData))
        {
        }

        /// <summary>
        ///   Deserialize a serialized dual quaternion.
        ///   Modified instance represents: Dual quaternion.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDualQuat(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(2052);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>Multiply two dual quaternions.</summary>
        /// <param name="dualQuaternionLeft">Left dual quaternion.</param>
        /// <param name="dualQuaternionRight">Right dual quaternion.</param>
        /// <returns>Product of the dual quaternions.</returns>
        public static HDualQuaternion[] DualQuatCompose(
          HDualQuaternion[] dualQuaternionLeft,
          HDualQuaternion[] dualQuaternionRight)
        {
            HTuple htuple1 = HData.ConcatArray((HData[])dualQuaternionLeft);
            HTuple htuple2 = HData.ConcatArray((HData[])dualQuaternionRight);
            IntPtr proc = HalconAPI.PreCall(2059);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HDualQuaternion.SplitArray(tuple);
        }

        /// <summary>
        ///   Multiply two dual quaternions.
        ///   Instance represents: Left dual quaternion.
        /// </summary>
        /// <param name="dualQuaternionRight">Right dual quaternion.</param>
        /// <returns>Product of the dual quaternions.</returns>
        public HDualQuaternion DualQuatCompose(HDualQuaternion dualQuaternionRight)
        {
            IntPtr proc = HalconAPI.PreCall(2059);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)dualQuaternionRight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)dualQuaternionRight));
            HDualQuaternion hdualQuaternion;
            int procResult = HDualQuaternion.LoadNew(proc, 0, err, out hdualQuaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdualQuaternion;
        }

        /// <summary>Conjugate a dual quaternion.</summary>
        /// <param name="dualQuaternion">Dual quaternion.</param>
        /// <returns>Conjugate of the dual quaternion.</returns>
        public static HDualQuaternion[] DualQuatConjugate(
          HDualQuaternion[] dualQuaternion)
        {
            HTuple htuple = HData.ConcatArray((HData[])dualQuaternion);
            IntPtr proc = HalconAPI.PreCall(2060);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HDualQuaternion.SplitArray(tuple);
        }

        /// <summary>
        ///   Conjugate a dual quaternion.
        ///   Instance represents: Dual quaternion.
        /// </summary>
        /// <returns>Conjugate of the dual quaternion.</returns>
        public HDualQuaternion DualQuatConjugate()
        {
            IntPtr proc = HalconAPI.PreCall(2060);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HDualQuaternion hdualQuaternion;
            int procResult = HDualQuaternion.LoadNew(proc, 0, err, out hdualQuaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdualQuaternion;
        }

        /// <summary>
        ///   Interpolate two dual quaternions.
        ///   Instance represents: Dual quaternion as the start point of the interpolation.
        /// </summary>
        /// <param name="dualQuaternionEnd">Dual quaternion as the end point of the interpolation.</param>
        /// <param name="interpPos">Interpolation parameter. Default: 0.5</param>
        /// <returns>Interpolated dual quaternion.</returns>
        public HDualQuaternion[] DualQuatInterpolate(
          HDualQuaternion dualQuaternionEnd,
          HTuple interpPos)
        {
            IntPtr proc = HalconAPI.PreCall(2061);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)dualQuaternionEnd);
            HalconAPI.Store(proc, 2, interpPos);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)dualQuaternionEnd));
            HalconAPI.UnpinTuple(interpPos);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            HDualQuaternion[] hdualQuaternionArray = HDualQuaternion.SplitArray(tuple);
            GC.KeepAlive((object)this);
            return hdualQuaternionArray;
        }

        /// <summary>
        ///   Interpolate two dual quaternions.
        ///   Instance represents: Dual quaternion as the start point of the interpolation.
        /// </summary>
        /// <param name="dualQuaternionEnd">Dual quaternion as the end point of the interpolation.</param>
        /// <param name="interpPos">Interpolation parameter. Default: 0.5</param>
        /// <returns>Interpolated dual quaternion.</returns>
        public HDualQuaternion DualQuatInterpolate(
          HDualQuaternion dualQuaternionEnd,
          double interpPos)
        {
            IntPtr proc = HalconAPI.PreCall(2061);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)dualQuaternionEnd);
            HalconAPI.StoreD(proc, 2, interpPos);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)dualQuaternionEnd));
            HDualQuaternion hdualQuaternion;
            int procResult = HDualQuaternion.LoadNew(proc, 0, err, out hdualQuaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdualQuaternion;
        }

        /// <summary>Normalize a dual quaternion.</summary>
        /// <param name="dualQuaternion">Unit dual quaternion.</param>
        /// <returns>Normalized dual quaternion.</returns>
        public static HDualQuaternion[] DualQuatNormalize(
          HDualQuaternion[] dualQuaternion)
        {
            HTuple htuple = HData.ConcatArray((HData[])dualQuaternion);
            IntPtr proc = HalconAPI.PreCall(2062);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HDualQuaternion.SplitArray(tuple);
        }

        /// <summary>
        ///   Normalize a dual quaternion.
        ///   Instance represents: Unit dual quaternion.
        /// </summary>
        /// <returns>Normalized dual quaternion.</returns>
        public HDualQuaternion DualQuatNormalize()
        {
            IntPtr proc = HalconAPI.PreCall(2062);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HDualQuaternion hdualQuaternion;
            int procResult = HDualQuaternion.LoadNew(proc, 0, err, out hdualQuaternion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdualQuaternion;
        }

        /// <summary>
        ///   Convert a unit dual quaternion into a homogeneous transformation matrix.
        ///   Instance represents: Unit dual quaternion.
        /// </summary>
        /// <returns>Transformation matrix.</returns>
        public HHomMat3D DualQuatToHomMat3d()
        {
            IntPtr proc = HalconAPI.PreCall(2063);
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

        /// <summary>Convert a dual quaternion to a 3D pose.</summary>
        /// <param name="dualQuaternion">Unit dual quaternion.</param>
        /// <returns>3D pose.</returns>
        public static HPose[] DualQuatToPose(HDualQuaternion[] dualQuaternion)
        {
            HTuple htuple = HData.ConcatArray((HData[])dualQuaternion);
            IntPtr proc = HalconAPI.PreCall(2064);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HPose.SplitArray(tuple);
        }

        /// <summary>
        ///   Convert a dual quaternion to a 3D pose.
        ///   Instance represents: Unit dual quaternion.
        /// </summary>
        /// <returns>3D pose.</returns>
        public HPose DualQuatToPose()
        {
            IntPtr proc = HalconAPI.PreCall(2064);
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
        ///   Convert a unit dual quaternion into a screw.
        ///   Instance represents: Unit dual quaternion.
        /// </summary>
        /// <param name="screwFormat">Format of the screw parameters. Default: "moment"</param>
        /// <param name="axisDirectionX">X component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionY">Y component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionZ">Z component of the direction vector of the screw axis.</param>
        /// <param name="axisMomentOrPointX">X component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointY">Y component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointZ">Z component of the moment vector or a point on the screw axis.</param>
        /// <param name="rotation">Rotation angle in radians.</param>
        /// <param name="translation">Translation.</param>
        public void DualQuatToScrew(
          string screwFormat,
          out double axisDirectionX,
          out double axisDirectionY,
          out double axisDirectionZ,
          out double axisMomentOrPointX,
          out double axisMomentOrPointY,
          out double axisMomentOrPointZ,
          out double rotation,
          out double translation)
        {
            IntPtr proc = HalconAPI.PreCall(2065);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, screwFormat);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out axisDirectionX);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out axisDirectionY);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out axisDirectionZ);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out axisMomentOrPointX);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out axisMomentOrPointY);
            int err7 = HalconAPI.LoadD(proc, 5, err6, out axisMomentOrPointZ);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out rotation);
            int procResult = HalconAPI.LoadD(proc, 7, err8, out translation);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a 3D line with a unit dual quaternion.
        ///   Instance represents: Unit dual quaternion representing the transformation.
        /// </summary>
        /// <param name="lineFormat">Format of the line parameters. Default: "moment"</param>
        /// <param name="lineDirectionX">X component of the direction vector of the line.</param>
        /// <param name="lineDirectionY">Y component of the direction vector of the line.</param>
        /// <param name="lineDirectionZ">Z component of the direction vector of the line.</param>
        /// <param name="lineMomentOrPointX">X component of the moment vector or a point on the line.</param>
        /// <param name="lineMomentOrPointY">Y component of the moment vector or a point on the line.</param>
        /// <param name="lineMomentOrPointZ">Z component of the moment vector or a point on the line.</param>
        /// <param name="transLineDirectionX">X component of the direction vector of the transformed line.</param>
        /// <param name="transLineDirectionY">Y component of the direction vector of the transformed line.</param>
        /// <param name="transLineDirectionZ">Z component of the direction vector of the transformed line.</param>
        /// <param name="transLineMomentOrPointX">X component of the moment vector or a point on the transformed line.</param>
        /// <param name="transLineMomentOrPointY">Y component of the moment vector or a point on the transformed line.</param>
        /// <param name="transLineMomentOrPointZ">Z component of the moment vector or a point on the transformed line.</param>
        public void DualQuatTransLine3d(
          string lineFormat,
          HTuple lineDirectionX,
          HTuple lineDirectionY,
          HTuple lineDirectionZ,
          HTuple lineMomentOrPointX,
          HTuple lineMomentOrPointY,
          HTuple lineMomentOrPointZ,
          out HTuple transLineDirectionX,
          out HTuple transLineDirectionY,
          out HTuple transLineDirectionZ,
          out HTuple transLineMomentOrPointX,
          out HTuple transLineMomentOrPointY,
          out HTuple transLineMomentOrPointZ)
        {
            IntPtr proc = HalconAPI.PreCall(2066);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, lineFormat);
            HalconAPI.Store(proc, 2, lineDirectionX);
            HalconAPI.Store(proc, 3, lineDirectionY);
            HalconAPI.Store(proc, 4, lineDirectionZ);
            HalconAPI.Store(proc, 5, lineMomentOrPointX);
            HalconAPI.Store(proc, 6, lineMomentOrPointY);
            HalconAPI.Store(proc, 7, lineMomentOrPointZ);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(lineDirectionX);
            HalconAPI.UnpinTuple(lineDirectionY);
            HalconAPI.UnpinTuple(lineDirectionZ);
            HalconAPI.UnpinTuple(lineMomentOrPointX);
            HalconAPI.UnpinTuple(lineMomentOrPointY);
            HalconAPI.UnpinTuple(lineMomentOrPointZ);
            int err2 = HTuple.LoadNew(proc, 0, err1, out transLineDirectionX);
            int err3 = HTuple.LoadNew(proc, 1, err2, out transLineDirectionY);
            int err4 = HTuple.LoadNew(proc, 2, err3, out transLineDirectionZ);
            int err5 = HTuple.LoadNew(proc, 3, err4, out transLineMomentOrPointX);
            int err6 = HTuple.LoadNew(proc, 4, err5, out transLineMomentOrPointY);
            int procResult = HTuple.LoadNew(proc, 5, err6, out transLineMomentOrPointZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a 3D line with a unit dual quaternion.
        ///   Instance represents: Unit dual quaternion representing the transformation.
        /// </summary>
        /// <param name="lineFormat">Format of the line parameters. Default: "moment"</param>
        /// <param name="lineDirectionX">X component of the direction vector of the line.</param>
        /// <param name="lineDirectionY">Y component of the direction vector of the line.</param>
        /// <param name="lineDirectionZ">Z component of the direction vector of the line.</param>
        /// <param name="lineMomentOrPointX">X component of the moment vector or a point on the line.</param>
        /// <param name="lineMomentOrPointY">Y component of the moment vector or a point on the line.</param>
        /// <param name="lineMomentOrPointZ">Z component of the moment vector or a point on the line.</param>
        /// <param name="transLineDirectionX">X component of the direction vector of the transformed line.</param>
        /// <param name="transLineDirectionY">Y component of the direction vector of the transformed line.</param>
        /// <param name="transLineDirectionZ">Z component of the direction vector of the transformed line.</param>
        /// <param name="transLineMomentOrPointX">X component of the moment vector or a point on the transformed line.</param>
        /// <param name="transLineMomentOrPointY">Y component of the moment vector or a point on the transformed line.</param>
        /// <param name="transLineMomentOrPointZ">Z component of the moment vector or a point on the transformed line.</param>
        public void DualQuatTransLine3d(
          string lineFormat,
          double lineDirectionX,
          double lineDirectionY,
          double lineDirectionZ,
          double lineMomentOrPointX,
          double lineMomentOrPointY,
          double lineMomentOrPointZ,
          out double transLineDirectionX,
          out double transLineDirectionY,
          out double transLineDirectionZ,
          out double transLineMomentOrPointX,
          out double transLineMomentOrPointY,
          out double transLineMomentOrPointZ)
        {
            IntPtr proc = HalconAPI.PreCall(2066);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, lineFormat);
            HalconAPI.StoreD(proc, 2, lineDirectionX);
            HalconAPI.StoreD(proc, 3, lineDirectionY);
            HalconAPI.StoreD(proc, 4, lineDirectionZ);
            HalconAPI.StoreD(proc, 5, lineMomentOrPointX);
            HalconAPI.StoreD(proc, 6, lineMomentOrPointY);
            HalconAPI.StoreD(proc, 7, lineMomentOrPointZ);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out transLineDirectionX);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out transLineDirectionY);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out transLineDirectionZ);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out transLineMomentOrPointX);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out transLineMomentOrPointY);
            int procResult = HalconAPI.LoadD(proc, 5, err6, out transLineMomentOrPointZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Convert a 3D pose to a unit dual quaternion.</summary>
        /// <param name="pose">3D pose.</param>
        /// <returns>Unit dual quaternion.</returns>
        public static HDualQuaternion[] PoseToDualQuat(HPose[] pose)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(2080);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HDualQuaternion.SplitArray(tuple);
        }

        /// <summary>
        ///   Convert a 3D pose to a unit dual quaternion.
        ///   Modified instance represents: Unit dual quaternion.
        /// </summary>
        /// <param name="pose">3D pose.</param>
        public void PoseToDualQuat(HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(2080);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert a screw into a dual quaternion.
        ///   Modified instance represents: Dual quaternion.
        /// </summary>
        /// <param name="screwFormat">Format of the screw parameters. Default: "moment"</param>
        /// <param name="axisDirectionX">X component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionY">Y component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionZ">Z component of the direction vector of the screw axis.</param>
        /// <param name="axisMomentOrPointX">X component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointY">Y component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointZ">Z component of the moment vector or a point on the screw axis.</param>
        /// <param name="rotation">Rotation angle in radians.</param>
        /// <param name="translation">Translation.</param>
        public void ScrewToDualQuat(
          string screwFormat,
          HTuple axisDirectionX,
          HTuple axisDirectionY,
          HTuple axisDirectionZ,
          HTuple axisMomentOrPointX,
          HTuple axisMomentOrPointY,
          HTuple axisMomentOrPointZ,
          HTuple rotation,
          HTuple translation)
        {
            IntPtr proc = HalconAPI.PreCall(2086);
            HalconAPI.StoreS(proc, 0, screwFormat);
            HalconAPI.Store(proc, 1, axisDirectionX);
            HalconAPI.Store(proc, 2, axisDirectionY);
            HalconAPI.Store(proc, 3, axisDirectionZ);
            HalconAPI.Store(proc, 4, axisMomentOrPointX);
            HalconAPI.Store(proc, 5, axisMomentOrPointY);
            HalconAPI.Store(proc, 6, axisMomentOrPointZ);
            HalconAPI.Store(proc, 7, rotation);
            HalconAPI.Store(proc, 8, translation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(axisDirectionX);
            HalconAPI.UnpinTuple(axisDirectionY);
            HalconAPI.UnpinTuple(axisDirectionZ);
            HalconAPI.UnpinTuple(axisMomentOrPointX);
            HalconAPI.UnpinTuple(axisMomentOrPointY);
            HalconAPI.UnpinTuple(axisMomentOrPointZ);
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(translation);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert a screw into a dual quaternion.
        ///   Modified instance represents: Dual quaternion.
        /// </summary>
        /// <param name="screwFormat">Format of the screw parameters. Default: "moment"</param>
        /// <param name="axisDirectionX">X component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionY">Y component of the direction vector of the screw axis.</param>
        /// <param name="axisDirectionZ">Z component of the direction vector of the screw axis.</param>
        /// <param name="axisMomentOrPointX">X component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointY">Y component of the moment vector or a point on the screw axis.</param>
        /// <param name="axisMomentOrPointZ">Z component of the moment vector or a point on the screw axis.</param>
        /// <param name="rotation">Rotation angle in radians.</param>
        /// <param name="translation">Translation.</param>
        public void ScrewToDualQuat(
          string screwFormat,
          double axisDirectionX,
          double axisDirectionY,
          double axisDirectionZ,
          double axisMomentOrPointX,
          double axisMomentOrPointY,
          double axisMomentOrPointZ,
          double rotation,
          double translation)
        {
            IntPtr proc = HalconAPI.PreCall(2086);
            HalconAPI.StoreS(proc, 0, screwFormat);
            HalconAPI.StoreD(proc, 1, axisDirectionX);
            HalconAPI.StoreD(proc, 2, axisDirectionY);
            HalconAPI.StoreD(proc, 3, axisDirectionZ);
            HalconAPI.StoreD(proc, 4, axisMomentOrPointX);
            HalconAPI.StoreD(proc, 5, axisMomentOrPointY);
            HalconAPI.StoreD(proc, 6, axisMomentOrPointZ);
            HalconAPI.StoreD(proc, 7, rotation);
            HalconAPI.StoreD(proc, 8, translation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Serialize a dual quaternion.
        ///   Instance represents: Dual quaternion.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDualQuat()
        {
            IntPtr proc = HalconAPI.PreCall(2092);
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
