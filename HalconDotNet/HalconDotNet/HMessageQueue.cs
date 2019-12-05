// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMessageQueue
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a message queue for inter-thread communication.</summary>
    public class HMessageQueue : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMessageQueue(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessageQueue obj)
        {
            obj = new HMessageQueue(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessageQueue[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMessageQueue[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMessageQueue(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a new empty message queue.
        ///   Modified instance represents: Handle of the newly created message queue.
        /// </summary>
        public HMessageQueue()
        {
            IntPtr proc = HalconAPI.PreCall(533);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query message queue parameters or information about the queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of the queue parameters or info queries. Default: "max_message_num"</param>
        /// <returns>Values of the queue parameters or info queries.</returns>
        public HTuple GetMessageQueueParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(528);
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
        ///   Query message queue parameters or information about the queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of the queue parameters or info queries. Default: "max_message_num"</param>
        /// <returns>Values of the queue parameters or info queries.</returns>
        public HTuple GetMessageQueueParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(528);
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
        ///   Set message queue parameters or invoke commands on the queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of the queue parameters or action commands. Default: "max_message_num"</param>
        /// <param name="genParamValue">Values of the queue parameters or action commands. Default: 1</param>
        public void SetMessageQueueParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(529);
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
        ///   Set message queue parameters or invoke commands on the queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of the queue parameters or action commands. Default: "max_message_num"</param>
        /// <param name="genParamValue">Values of the queue parameters or action commands. Default: 1</param>
        public void SetMessageQueueParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(529);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Receive one or more messages from the message queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of optional generic parameters Default: "timeout"</param>
        /// <param name="genParamValue">Values of optional generic parameters Default: "infinite"</param>
        /// <returns>Handle(s) of the dequeued message(s).</returns>
        public HMessage[] DequeueMessage(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(530);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HMessage[] hmessageArray;
            int procResult = HMessage.LoadNew(proc, 0, err, out hmessageArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmessageArray;
        }

        /// <summary>
        ///   Receive one or more messages from the message queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="genParamName">Names of optional generic parameters Default: "timeout"</param>
        /// <param name="genParamValue">Values of optional generic parameters Default: "infinite"</param>
        /// <returns>Handle(s) of the dequeued message(s).</returns>
        public HMessage DequeueMessage(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(530);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HMessage hmessage;
            int procResult = HMessage.LoadNew(proc, 0, err, out hmessage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmessage;
        }

        /// <summary>
        ///   Enqueue one or more messages to the message queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="messageHandle">Handle(s) of message(s) to be enqueued.</param>
        /// <param name="genParamName">Names of optional generic parameters.</param>
        /// <param name="genParamValue">Values of optional generic parameters.</param>
        public void EnqueueMessage(HMessage[] messageHandle, HTuple genParamName, HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])messageHandle);
            IntPtr proc = HalconAPI.PreCall(531);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, htuple);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)messageHandle);
        }

        /// <summary>
        ///   Enqueue one or more messages to the message queue.
        ///   Instance represents: Message queue handle.
        /// </summary>
        /// <param name="messageHandle">Handle(s) of message(s) to be enqueued.</param>
        /// <param name="genParamName">Names of optional generic parameters.</param>
        /// <param name="genParamValue">Values of optional generic parameters.</param>
        public void EnqueueMessage(HMessage messageHandle, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(531);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)messageHandle);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)messageHandle);
        }

        /// <summary>
        ///   Create a new empty message queue.
        ///   Modified instance represents: Handle of the newly created message queue.
        /// </summary>
        public void CreateMessageQueue()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(533);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(532);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
