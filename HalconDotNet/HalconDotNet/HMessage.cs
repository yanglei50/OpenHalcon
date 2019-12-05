// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMessage
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a data container to be sent via message queues.</summary>
    public class HMessage : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMessage(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessage obj)
        {
            obj = new HMessage(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessage[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMessage[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMessage(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a new empty message.
        ///   Modified instance represents: Handle of the newly created message.
        /// </summary>
        public HMessage()
        {
            IntPtr proc = HalconAPI.PreCall(541);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query message parameters or information about the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="genParamName">Names of the message parameters or info queries. Default: "message_keys"</param>
        /// <param name="key">Message keys the parameter/query should be applied to.</param>
        /// <returns>Values of the message parameters or info queries.</returns>
        public HTuple GetMessageParam(string genParamName, HTuple key)
        {
            IntPtr proc = HalconAPI.PreCall(534);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, key);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(key);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query message parameters or information about the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="genParamName">Names of the message parameters or info queries. Default: "message_keys"</param>
        /// <param name="key">Message keys the parameter/query should be applied to.</param>
        /// <returns>Values of the message parameters or info queries.</returns>
        public HTuple GetMessageParam(string genParamName, string key)
        {
            IntPtr proc = HalconAPI.PreCall(534);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, key);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set message parameter or invoke commands on the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="genParamName">Names of the message parameters or action commands. Default: "remove_key"</param>
        /// <param name="key">Message keys the parameter/command should be applied to.</param>
        /// <param name="genParamValue">Values of the message parameters or action commands.</param>
        public void SetMessageParam(string genParamName, HTuple key, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(535);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, key);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(key);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set message parameter or invoke commands on the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="genParamName">Names of the message parameters or action commands. Default: "remove_key"</param>
        /// <param name="key">Message keys the parameter/command should be applied to.</param>
        /// <param name="genParamValue">Values of the message parameters or action commands.</param>
        public void SetMessageParam(string genParamName, string key, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(535);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, key);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Retrieve an object associated with the key from the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="key">Key string.</param>
        /// <returns>Tuple value retrieved from the message.</returns>
        public HObject GetMessageObj(string key)
        {
            IntPtr proc = HalconAPI.PreCall(536);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, key);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Add a key/object pair to the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="objectData">Object to be associated with the key.</param>
        /// <param name="key">Key string.</param>
        public void SetMessageObj(HObject objectData, string key)
        {
            IntPtr proc = HalconAPI.PreCall(537);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)objectData);
            HalconAPI.StoreS(proc, 1, key);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectData);
        }

        /// <summary>
        ///   Retrieve a tuple associated with the key from the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="key">Key string.</param>
        /// <returns>Tuple value retrieved from the message.</returns>
        public HTuple GetMessageTuple(string key)
        {
            IntPtr proc = HalconAPI.PreCall(538);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, key);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Add a key/tuple pair to the message.
        ///   Instance represents: Message handle.
        /// </summary>
        /// <param name="key">Key string.</param>
        /// <param name="tupleData">Tuple value to be associated with the key.</param>
        public void SetMessageTuple(string key, HTuple tupleData)
        {
            IntPtr proc = HalconAPI.PreCall(539);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, key);
            HalconAPI.Store(proc, 2, tupleData);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(tupleData);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a new empty message.
        ///   Modified instance represents: Handle of the newly created message.
        /// </summary>
        public void CreateMessage()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(541);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(540);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
