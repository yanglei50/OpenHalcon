// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HCondition
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a condition synchronization object.</summary>
    public class HCondition : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCondition()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCondition(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCondition obj)
        {
            obj = new HCondition(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCondition[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HCondition[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HCondition(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a condition variable synchronization object.
        ///   Modified instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute. Default: []</param>
        /// <param name="attribValue">Mutex attribute value. Default: []</param>
        public HCondition(HTuple attribName, HTuple attribValue)
        {
            IntPtr proc = HalconAPI.PreCall(548);
            HalconAPI.Store(proc, 0, attribName);
            HalconAPI.Store(proc, 1, attribValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a condition variable synchronization object.
        ///   Modified instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute. Default: []</param>
        /// <param name="attribValue">Mutex attribute value. Default: []</param>
        public HCondition(string attribName, string attribValue)
        {
            IntPtr proc = HalconAPI.PreCall(548);
            HalconAPI.StoreS(proc, 0, attribName);
            HalconAPI.StoreS(proc, 1, attribValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Signal a condition synchronization object.
        ///   Instance represents: Condition synchronization object.
        /// </summary>
        public void BroadcastCondition()
        {
            IntPtr proc = HalconAPI.PreCall(544);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Signal a condition synchronization object.
        ///   Instance represents: Condition synchronization object.
        /// </summary>
        public void SignalCondition()
        {
            IntPtr proc = HalconAPI.PreCall(545);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Bounded wait on the signal of a condition synchronization object.
        ///   Instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="mutexHandle">Mutex synchronization object.</param>
        /// <param name="timeout">Timeout in micro seconds.</param>
        public void TimedWaitCondition(HMutex mutexHandle, int timeout)
        {
            IntPtr proc = HalconAPI.PreCall(546);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)mutexHandle);
            HalconAPI.StoreI(proc, 2, timeout);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)mutexHandle);
        }

        /// <summary>
        ///   wait on the signal of a condition synchronization object.
        ///   Instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="mutexHandle">Mutex synchronization object.</param>
        public void WaitCondition(HMutex mutexHandle)
        {
            IntPtr proc = HalconAPI.PreCall(547);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)mutexHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)mutexHandle);
        }

        /// <summary>
        ///   Create a condition variable synchronization object.
        ///   Modified instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute. Default: []</param>
        /// <param name="attribValue">Mutex attribute value. Default: []</param>
        public void CreateCondition(HTuple attribName, HTuple attribValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(548);
            HalconAPI.Store(proc, 0, attribName);
            HalconAPI.Store(proc, 1, attribValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a condition variable synchronization object.
        ///   Modified instance represents: Condition synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute. Default: []</param>
        /// <param name="attribValue">Mutex attribute value. Default: []</param>
        public void CreateCondition(string attribName, string attribValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(548);
            HalconAPI.StoreS(proc, 0, attribName);
            HalconAPI.StoreS(proc, 1, attribValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(543);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
