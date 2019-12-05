// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HIODevice
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an I/O device.</summary>
    public class HIODevice : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HIODevice()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HIODevice(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIODevice obj)
        {
            obj = new HIODevice(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIODevice[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HIODevice[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HIODevice(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open and configure an I/O device.
        ///   Modified instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="IODeviceName">I/O device name. Default: []</param>
        /// <param name="genParamName">Dynamic parameter names. Default: []</param>
        /// <param name="genParamValue">Dynamic parameter values. Default: []</param>
        public HIODevice(
          string IOInterfaceName,
          HTuple IODeviceName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2022);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.Store(proc, 1, IODeviceName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(IODeviceName);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open and configure I/O channels.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOChannelName">HALCON I/O channel names of the specified device.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values. Default: []</param>
        /// <returns>Handles of the opened I/O channel.</returns>
        public HIOChannel[] OpenIoChannel(
          HTuple IOChannelName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2016);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(IOChannelName);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HIOChannel[] hioChannelArray;
            int procResult = HIOChannel.LoadNew(proc, 0, err, out hioChannelArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hioChannelArray;
        }

        /// <summary>
        ///   Open and configure I/O channels.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOChannelName">HALCON I/O channel names of the specified device.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values. Default: []</param>
        /// <returns>Handles of the opened I/O channel.</returns>
        public HIOChannel OpenIoChannel(
          string IOChannelName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2016);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HIOChannel hioChannel;
            int procResult = HIOChannel.LoadNew(proc, 0, err, out hioChannel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hioChannel;
        }

        /// <summary>
        ///   Query information about channels of the specified I/O device.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOChannelName">Channel names to query.</param>
        /// <param name="query">Name of the query. Default: "param_name"</param>
        /// <returns>List of values (according to Query).</returns>
        public HTuple QueryIoDevice(HTuple IOChannelName, HTuple query)
        {
            IntPtr proc = HalconAPI.PreCall(2017);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(IOChannelName);
            HalconAPI.UnpinTuple(query);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query information about channels of the specified I/O device.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOChannelName">Channel names to query.</param>
        /// <param name="query">Name of the query. Default: "param_name"</param>
        /// <returns>List of values (according to Query).</returns>
        public HTuple QueryIoDevice(string IOChannelName, HTuple query)
        {
            IntPtr proc = HalconAPI.PreCall(2017);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(query);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Perform an action on the I/O device.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="action">Name of the action to perform.</param>
        /// <param name="argument">List of arguments for the action. Default: []</param>
        /// <returns>List of result values returned by the action.</returns>
        public HTuple ControlIoDevice(string action, HTuple argument)
        {
            IntPtr proc = HalconAPI.PreCall(2018);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, action);
            HalconAPI.Store(proc, 2, argument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(argument);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Perform an action on the I/O device.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="action">Name of the action to perform.</param>
        /// <param name="argument">List of arguments for the action. Default: []</param>
        /// <returns>List of result values returned by the action.</returns>
        public HTuple ControlIoDevice(string action, string argument)
        {
            IntPtr proc = HalconAPI.PreCall(2018);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, action);
            HalconAPI.StoreS(proc, 2, argument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Configure a specific I/O device instance.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values to set. Default: []</param>
        public void SetIoDeviceParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2019);
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
        ///   Configure a specific I/O device instance.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values to set. Default: []</param>
        public void SetIoDeviceParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2019);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query settings of an I/O device instance.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: "param_name"</param>
        /// <returns>Parameter values.</returns>
        public HTuple GetIoDeviceParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2020);
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
        ///   Query settings of an I/O device instance.
        ///   Instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: "param_name"</param>
        /// <returns>Parameter values.</returns>
        public HTuple GetIoDeviceParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2020);
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
        ///   Open and configure an I/O device.
        ///   Modified instance represents: Handle of the opened I/O device.
        /// </summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="IODeviceName">I/O device name. Default: []</param>
        /// <param name="genParamName">Dynamic parameter names. Default: []</param>
        /// <param name="genParamValue">Dynamic parameter values. Default: []</param>
        public void OpenIoDevice(
          string IOInterfaceName,
          HTuple IODeviceName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2022);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.Store(proc, 1, IODeviceName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(IODeviceName);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Perform an action on the I/O interface.</summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="action">Name of the action to perform.</param>
        /// <param name="argument">List of arguments for the action. Default: []</param>
        /// <returns>List of results returned by the action.</returns>
        public static HTuple ControlIoInterface(
          string IOInterfaceName,
          string action,
          HTuple argument)
        {
            IntPtr proc = HalconAPI.PreCall(2023);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.StoreS(proc, 1, action);
            HalconAPI.Store(proc, 2, argument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(argument);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Perform an action on the I/O interface.</summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="action">Name of the action to perform.</param>
        /// <param name="argument">List of arguments for the action. Default: []</param>
        /// <returns>List of results returned by the action.</returns>
        public static HTuple ControlIoInterface(
          string IOInterfaceName,
          string action,
          string argument)
        {
            IntPtr proc = HalconAPI.PreCall(2023);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.StoreS(proc, 1, action);
            HalconAPI.StoreS(proc, 2, argument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query information about the specified I/O device interface.</summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="query">Parameter name of the query. Default: "io_device_names"</param>
        /// <returns>List of result values (according to Query).</returns>
        public static HTuple QueryIoInterface(string IOInterfaceName, HTuple query)
        {
            IntPtr proc = HalconAPI.PreCall(2024);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.Store(proc, 1, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(query);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query information about the specified I/O device interface.</summary>
        /// <param name="IOInterfaceName">HALCON I/O interface name. Default: []</param>
        /// <param name="query">Parameter name of the query. Default: "io_device_names"</param>
        /// <returns>List of result values (according to Query).</returns>
        public static HTuple QueryIoInterface(string IOInterfaceName, string query)
        {
            IntPtr proc = HalconAPI.PreCall(2024);
            HalconAPI.StoreS(proc, 0, IOInterfaceName);
            HalconAPI.StoreS(proc, 1, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2021);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
