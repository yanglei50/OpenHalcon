// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCV
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a tool for optical character verification.</summary>
    [Serializable]
    public class HOCV : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCV()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCV(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCV obj)
        {
            obj = new HOCV(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCV[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HOCV[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HOCV(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Reading an OCV tool from file.
        ///   Modified instance represents: Handle of read OCV tool.
        /// </summary>
        /// <param name="fileName">Name of the file which has to be read. Default: "test_ocv"</param>
        public HOCV(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(642);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCV tool based on gray value projections.
        ///   Modified instance represents: Handle of the created OCV tool.
        /// </summary>
        /// <param name="patternNames">List of names for patterns to be trained. Default: "a"</param>
        public HOCV(HTuple patternNames)
        {
            IntPtr proc = HalconAPI.PreCall(646);
            HalconAPI.Store(proc, 0, patternNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(patternNames);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeOcv();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HOCV(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeOcv(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeOcv().Serialize(stream);
        }

        public static HOCV Deserialize(Stream stream)
        {
            HOCV hocv = new HOCV();
            hocv.DeserializeOcv(HSerializedItem.Deserialize(stream));
            return hocv;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HOCV Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeOcv();
            HOCV hocv = new HOCV();
            hocv.DeserializeOcv(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hocv;
        }

        /// <summary>
        ///   Verification of a pattern using an OCV tool.
        ///   Instance represents: Handle of the OCV tool.
        /// </summary>
        /// <param name="pattern">Characters to be verified.</param>
        /// <param name="patternName">Name of the character. Default: "a"</param>
        /// <param name="adaptPos">Adaption to vertical and horizontal translation. Default: "true"</param>
        /// <param name="adaptSize">Adaption to vertical and horizontal scaling of the size. Default: "true"</param>
        /// <param name="adaptAngle">Adaption to changes of the orientation (not implemented). Default: "false"</param>
        /// <param name="adaptGray">Adaption to additive and scaling gray value changes. Default: "true"</param>
        /// <param name="threshold">Minimum difference between objects. Default: 10</param>
        /// <returns>Evaluation of the character.</returns>
        public HTuple DoOcvSimple(
          HImage pattern,
          HTuple patternName,
          string adaptPos,
          string adaptSize,
          string adaptAngle,
          string adaptGray,
          double threshold)
        {
            IntPtr proc = HalconAPI.PreCall(638);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)pattern);
            HalconAPI.Store(proc, 1, patternName);
            HalconAPI.StoreS(proc, 2, adaptPos);
            HalconAPI.StoreS(proc, 3, adaptSize);
            HalconAPI.StoreS(proc, 4, adaptAngle);
            HalconAPI.StoreS(proc, 5, adaptGray);
            HalconAPI.StoreD(proc, 6, threshold);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(patternName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
            return tuple;
        }

        /// <summary>
        ///   Verification of a pattern using an OCV tool.
        ///   Instance represents: Handle of the OCV tool.
        /// </summary>
        /// <param name="pattern">Characters to be verified.</param>
        /// <param name="patternName">Name of the character. Default: "a"</param>
        /// <param name="adaptPos">Adaption to vertical and horizontal translation. Default: "true"</param>
        /// <param name="adaptSize">Adaption to vertical and horizontal scaling of the size. Default: "true"</param>
        /// <param name="adaptAngle">Adaption to changes of the orientation (not implemented). Default: "false"</param>
        /// <param name="adaptGray">Adaption to additive and scaling gray value changes. Default: "true"</param>
        /// <param name="threshold">Minimum difference between objects. Default: 10</param>
        /// <returns>Evaluation of the character.</returns>
        public double DoOcvSimple(
          HImage pattern,
          string patternName,
          string adaptPos,
          string adaptSize,
          string adaptAngle,
          string adaptGray,
          double threshold)
        {
            IntPtr proc = HalconAPI.PreCall(638);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)pattern);
            HalconAPI.StoreS(proc, 1, patternName);
            HalconAPI.StoreS(proc, 2, adaptPos);
            HalconAPI.StoreS(proc, 3, adaptSize);
            HalconAPI.StoreS(proc, 4, adaptAngle);
            HalconAPI.StoreS(proc, 5, adaptGray);
            HalconAPI.StoreD(proc, 6, threshold);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
            return doubleValue;
        }

        /// <summary>
        ///   Training of an OCV tool.
        ///   Instance represents: Handle of the OCV tool to be trained.
        /// </summary>
        /// <param name="pattern">Pattern to be trained.</param>
        /// <param name="name">Name(s) of the object(s) to analyse. Default: "a"</param>
        /// <param name="mode">Mode for training (only one mode implemented). Default: "single"</param>
        public void TraindOcvProj(HImage pattern, HTuple name, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(639);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)pattern);
            HalconAPI.Store(proc, 1, name);
            HalconAPI.StoreS(proc, 2, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(name);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
        }

        /// <summary>
        ///   Training of an OCV tool.
        ///   Instance represents: Handle of the OCV tool to be trained.
        /// </summary>
        /// <param name="pattern">Pattern to be trained.</param>
        /// <param name="name">Name(s) of the object(s) to analyse. Default: "a"</param>
        /// <param name="mode">Mode for training (only one mode implemented). Default: "single"</param>
        public void TraindOcvProj(HImage pattern, string name, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(639);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)pattern);
            HalconAPI.StoreS(proc, 1, name);
            HalconAPI.StoreS(proc, 2, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
        }

        /// <summary>
        ///   Deserialize a serialized OCV tool.
        ///   Modified instance represents: Handle of the OCV tool.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeOcv(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(640);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize an OCV tool.
        ///   Instance represents: Handle of the OCV tool.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeOcv()
        {
            IntPtr proc = HalconAPI.PreCall(641);
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
        ///   Reading an OCV tool from file.
        ///   Modified instance represents: Handle of read OCV tool.
        /// </summary>
        /// <param name="fileName">Name of the file which has to be read. Default: "test_ocv"</param>
        public void ReadOcv(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(642);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Saving an OCV tool to file.
        ///   Instance represents: Handle of the OCV tool to be written.
        /// </summary>
        /// <param name="fileName">Name of the file where the tool has to be saved. Default: "test_ocv"</param>
        public void WriteOcv(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(643);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCV tool based on gray value projections.
        ///   Modified instance represents: Handle of the created OCV tool.
        /// </summary>
        /// <param name="patternNames">List of names for patterns to be trained. Default: "a"</param>
        public void CreateOcvProj(HTuple patternNames)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(646);
            HalconAPI.Store(proc, 0, patternNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(patternNames);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new OCV tool based on gray value projections.
        ///   Modified instance represents: Handle of the created OCV tool.
        /// </summary>
        /// <param name="patternNames">List of names for patterns to be trained. Default: "a"</param>
        public void CreateOcvProj(string patternNames)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(646);
            HalconAPI.StoreS(proc, 0, patternNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(645);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
