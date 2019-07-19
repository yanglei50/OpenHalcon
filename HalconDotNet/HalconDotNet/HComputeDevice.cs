// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HComputeDevice
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Class representing a compute device handle.</summary>
    public class HComputeDevice : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComputeDevice()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComputeDevice(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComputeDevice obj)
        {
            obj = new HComputeDevice(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComputeDevice[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HComputeDevice[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HComputeDevice(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open a compute device.
        ///   Modified instance represents: Compute device handle.
        /// </summary>
        /// <param name="deviceIdentifier">Compute device Identifier.</param>
        public HComputeDevice(int deviceIdentifier)
        {
            IntPtr proc = HalconAPI.PreCall(304);
            HalconAPI.StoreI(proc, 0, deviceIdentifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query compute device parameters.
        ///   Instance represents: Compute device handle.
        /// </summary>
        /// <param name="genParamName">Name of the parameter to query. Default: "buffer_cache_capacity"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetComputeDeviceParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(296);
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
        ///   Set parameters of an compute device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        /// <param name="genParamName">Name of the parameter to set. Default: "buffer_cache_capacity"</param>
        /// <param name="genParamValue">New parameter value.</param>
        public void SetComputeDeviceParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(297);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters of an compute device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        /// <param name="genParamName">Name of the parameter to set. Default: "buffer_cache_capacity"</param>
        /// <param name="genParamValue">New parameter value.</param>
        public void SetComputeDeviceParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(297);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Close all compute devices.</summary>
        public static void ReleaseAllComputeDevices()
        {
            IntPtr proc = HalconAPI.PreCall(298);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>
        ///   Close a compute_device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        public void ReleaseComputeDevice()
        {
            IntPtr proc = HalconAPI.PreCall(299);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Deactivate all compute devices.</summary>
        public static void DeactivateAllComputeDevices()
        {
            IntPtr proc = HalconAPI.PreCall(300);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>
        ///   Deactivate a compute device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        public void DeactivateComputeDevice()
        {
            IntPtr proc = HalconAPI.PreCall(301);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Activate a compute device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        public void ActivateComputeDevice()
        {
            IntPtr proc = HalconAPI.PreCall(302);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Initialize a compute device.
        ///   Instance represents: Compute device handle.
        /// </summary>
        /// <param name="operators">List of operators to prepare. Default: "all"</param>
        public void InitComputeDevice(HTuple operators)
        {
            IntPtr proc = HalconAPI.PreCall(303);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, operators);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(operators);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a compute device.
        ///   Modified instance represents: Compute device handle.
        /// </summary>
        /// <param name="deviceIdentifier">Compute device Identifier.</param>
        public void OpenComputeDevice(int deviceIdentifier)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(304);
            HalconAPI.StoreI(proc, 0, deviceIdentifier);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Get information on a compute device.</summary>
        /// <param name="deviceIdentifier">Compute device handle.</param>
        /// <param name="infoName">Name of Information to query. Default: "name"</param>
        /// <returns>Returned information.</returns>
        public static HTuple GetComputeDeviceInfo(int deviceIdentifier, string infoName)
        {
            IntPtr proc = HalconAPI.PreCall(305);
            HalconAPI.StoreI(proc, 0, deviceIdentifier);
            HalconAPI.StoreS(proc, 1, infoName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get the list of available compute devices.</summary>
        /// <returns>List of available compute devices.</returns>
        public static HTuple QueryAvailableComputeDevices()
        {
            IntPtr proc = HalconAPI.PreCall(306);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(301);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
