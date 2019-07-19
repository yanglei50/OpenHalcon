// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HBarrier
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a barrier synchronization object.</summary>
    public class HBarrier : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBarrier()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBarrier(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarrier obj)
        {
            obj = new HBarrier(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarrier[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HBarrier[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HBarrier(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a barrier synchronization object.
        ///   Modified instance represents: Barrier synchronization object.
        /// </summary>
        /// <param name="attribName">Barrier attribute. Default: []</param>
        /// <param name="attribValue">Barrier attribute value. Default: []</param>
        /// <param name="teamSize">Barrier team size. Default: 1</param>
        public HBarrier(HTuple attribName, HTuple attribValue, int teamSize)
        {
            IntPtr proc = HalconAPI.PreCall(552);
            HalconAPI.Store(proc, 0, attribName);
            HalconAPI.Store(proc, 1, attribValue);
            HalconAPI.StoreI(proc, 2, teamSize);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a barrier synchronization object.
        ///   Modified instance represents: Barrier synchronization object.
        /// </summary>
        /// <param name="attribName">Barrier attribute. Default: []</param>
        /// <param name="attribValue">Barrier attribute value. Default: []</param>
        /// <param name="teamSize">Barrier team size. Default: 1</param>
        public HBarrier(string attribName, string attribValue, int teamSize)
        {
            IntPtr proc = HalconAPI.PreCall(552);
            HalconAPI.StoreS(proc, 0, attribName);
            HalconAPI.StoreS(proc, 1, attribValue);
            HalconAPI.StoreI(proc, 2, teamSize);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Wait on the release of a barrier synchronization object.
        ///   Instance represents: Barrier synchronization object.
        /// </summary>
        public void WaitBarrier()
        {
            IntPtr proc = HalconAPI.PreCall(551);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a barrier synchronization object.
        ///   Modified instance represents: Barrier synchronization object.
        /// </summary>
        /// <param name="attribName">Barrier attribute. Default: []</param>
        /// <param name="attribValue">Barrier attribute value. Default: []</param>
        /// <param name="teamSize">Barrier team size. Default: 1</param>
        public void CreateBarrier(HTuple attribName, HTuple attribValue, int teamSize)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(552);
            HalconAPI.Store(proc, 0, attribName);
            HalconAPI.Store(proc, 1, attribValue);
            HalconAPI.StoreI(proc, 2, teamSize);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a barrier synchronization object.
        ///   Modified instance represents: Barrier synchronization object.
        /// </summary>
        /// <param name="attribName">Barrier attribute. Default: []</param>
        /// <param name="attribValue">Barrier attribute value. Default: []</param>
        /// <param name="teamSize">Barrier team size. Default: 1</param>
        public void CreateBarrier(string attribName, string attribValue, int teamSize)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(552);
            HalconAPI.StoreS(proc, 0, attribName);
            HalconAPI.StoreS(proc, 1, attribValue);
            HalconAPI.StoreI(proc, 2, teamSize);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(550);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
