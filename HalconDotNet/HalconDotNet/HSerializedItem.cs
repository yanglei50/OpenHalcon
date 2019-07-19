using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a serializied item.</summary>
    public class HSerializedItem : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSerializedItem()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSerializedItem(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerializedItem obj)
        {
            obj = new HSerializedItem(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerializedItem[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSerializedItem[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSerializedItem(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a serialized item.
        ///   Modified instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="pointer">Data pointer of the serialized item.</param>
        /// <param name="size">Size of the serialized item.</param>
        /// <param name="copy">Copy mode of the serialized item. Default: "true"</param>
        public HSerializedItem(IntPtr pointer, int size, string copy)
        {
            IntPtr proc = HalconAPI.PreCall(410);
            HalconAPI.StoreIP(proc, 0, pointer);
            HalconAPI.StoreI(proc, 1, size);
            HalconAPI.StoreS(proc, 2, copy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Creates a new serialized item with data given in byte array</summary>
        /// <remarks>The array needs to be kept alive until block is disposed!</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSerializedItem(byte[] data)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)data, GCHandleType.Pinned);
            this.CreateSerializedItemPtr(gcHandle.AddrOfPinnedObject(), data.Length, "true");
            gcHandle.Free();
        }

        /// <summary>Copies a serialized item into a new byte array</summary>
        public static implicit operator byte[] (HSerializedItem item)
        {
            int size;
            IntPtr serializedItemPtr = item.GetSerializedItemPtr(out size);
            byte[] destination = new byte[size];
            Marshal.Copy(serializedItemPtr, destination, 0, size);
            return destination;
        }

        internal void Serialize(Stream stream)
        {
            byte[] buffer = (byte[])this;
            stream.Write(buffer, 0, buffer.Length);
        }

        internal static HSerializedItem Deserialize(Stream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream);
            byte[] header = binaryReader.ReadBytes(16);
            ulong size;
            if (header.Length < 16 || HalconAPI.IsFailure(HalconAPI.GetSerializedSize(header, out size)))
                throw new HalconException("Input stream is no serialized HALCON object");
            if (size > 2415918079UL)
                throw new HalconException("Input stream too large");
            byte[] numArray = binaryReader.ReadBytes((int)size);
            if (numArray.Length < (int)size || HalconAPI.IsFailure(HalconAPI.GetSerializedSize(header, out size)))
                throw new HalconException("Unexpected end of serialization data");
            byte[] data = new byte[(int)size + 16];
            header.CopyTo((Array)data, 0);
            numArray.CopyTo((Array)data, 16);
            return new HSerializedItem(data);
        }

        /// <summary>
        ///   Receive a serialized item over a socket connection.
        ///   Modified instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void ReceiveSerializedItem(HSocket socket)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(403);
            HalconAPI.Store(proc, 0, (HTool)socket);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Send a serialized item over a socket connection.
        ///   Instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void SendSerializedItem(HSocket socket)
        {
            IntPtr proc = HalconAPI.PreCall(404);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)socket);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Write a serialized item to a file.
        ///   Instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="fileHandle">File handle.</param>
        public void FwriteSerializedItem(HFile fileHandle)
        {
            IntPtr proc = HalconAPI.PreCall(405);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)fileHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)fileHandle);
        }

        /// <summary>
        ///   Read a serialized item from a file.
        ///   Modified instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="fileHandle">File handle.</param>
        public void FreadSerializedItem(HFile fileHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(406);
            HalconAPI.Store(proc, 0, (HTool)fileHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)fileHandle);
        }

        /// <summary>
        ///   Access the data pointer of a serialized item.
        ///   Instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="size">Size of the serialized item.</param>
        /// <returns>Data pointer of the serialized item.</returns>
        public IntPtr GetSerializedItemPtr(out int size)
        {
            IntPtr proc = HalconAPI.PreCall(409);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            IntPtr intPtrValue;
            int err2 = HalconAPI.LoadIP(proc, 0, err1, out intPtrValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out size);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intPtrValue;
        }

        /// <summary>
        ///   Create a serialized item.
        ///   Modified instance represents: Handle of the serialized item.
        /// </summary>
        /// <param name="pointer">Data pointer of the serialized item.</param>
        /// <param name="size">Size of the serialized item.</param>
        /// <param name="copy">Copy mode of the serialized item. Default: "true"</param>
        public void CreateSerializedItemPtr(IntPtr pointer, int size, string copy)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(410);
            HalconAPI.StoreIP(proc, 0, pointer);
            HalconAPI.StoreI(proc, 1, size);
            HalconAPI.StoreS(proc, 2, copy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(408);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
