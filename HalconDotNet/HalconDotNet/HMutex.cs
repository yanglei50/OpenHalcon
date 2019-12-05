// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMutex
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a mutex synchronization object.</summary>
    public class HMutex : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMutex()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMutex(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMutex obj)
        {
            obj = new HMutex(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMutex[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMutex[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMutex(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a mutual exclusion synchronization object.
        ///   Modified instance represents: Mutex synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute class. Default: []</param>
        /// <param name="attribValue">Mutex attribute kind. Default: []</param>
        public HMutex(HTuple attribName, HTuple attribValue)
        {
            IntPtr proc = HalconAPI.PreCall(564);
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
        ///   Create a mutual exclusion synchronization object.
        ///   Modified instance represents: Mutex synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute class. Default: []</param>
        /// <param name="attribValue">Mutex attribute kind. Default: []</param>
        public HMutex(string attribName, string attribValue)
        {
            IntPtr proc = HalconAPI.PreCall(564);
            HalconAPI.StoreS(proc, 0, attribName);
            HalconAPI.StoreS(proc, 1, attribValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Unlock a mutex synchronization object.
        ///   Instance represents: Mutex synchronization object.
        /// </summary>
        public void UnlockMutex()
        {
            IntPtr proc = HalconAPI.PreCall(561);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Lock a mutex synchronization object.
        ///   Instance represents: Mutex synchronization object.
        /// </summary>
        /// <returns>Mutex already locked?</returns>
        public int TryLockMutex()
        {
            IntPtr proc = HalconAPI.PreCall(562);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Lock a mutex synchronization object.
        ///   Instance represents: Mutex synchronization object.
        /// </summary>
        public void LockMutex()
        {
            IntPtr proc = HalconAPI.PreCall(563);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a mutual exclusion synchronization object.
        ///   Modified instance represents: Mutex synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute class. Default: []</param>
        /// <param name="attribValue">Mutex attribute kind. Default: []</param>
        public void CreateMutex(HTuple attribName, HTuple attribValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(564);
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
        ///   Create a mutual exclusion synchronization object.
        ///   Modified instance represents: Mutex synchronization object.
        /// </summary>
        /// <param name="attribName">Mutex attribute class. Default: []</param>
        /// <param name="attribValue">Mutex attribute kind. Default: []</param>
        public void CreateMutex(string attribName, string attribValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(564);
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
            IntPtr proc = HalconAPI.PreCall(560);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
