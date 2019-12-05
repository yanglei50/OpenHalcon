// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HIOChannel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a channel of an I/O device.</summary>
    public class HIOChannel : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HIOChannel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HIOChannel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIOChannel obj)
        {
            obj = new HIOChannel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIOChannel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HIOChannel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HIOChannel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open and configure I/O channels.
        ///   Modified instance represents: Handles of the opened I/O channel.
        /// </summary>
        /// <param name="IODeviceHandle">Handle of the opened I/O device.</param>
        /// <param name="IOChannelName">HALCON I/O channel names of the specified device.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values. Default: []</param>
        public HIOChannel(
          HIODevice IODeviceHandle,
          string IOChannelName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2016);
            HalconAPI.Store(proc, 0, (HTool)IODeviceHandle);
            HalconAPI.StoreS(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)IODeviceHandle);
        }

        /// <summary>Perform an action on I/O channels.</summary>
        /// <param name="IOChannelHandle">Handles of the opened I/O channels.</param>
        /// <param name="paramAction">Name of the action to perform.</param>
        /// <param name="paramArgument">List of arguments for the action. Default: []</param>
        /// <returns>List of values returned by the action.</returns>
        public static HTuple ControlIoChannel(
          HIOChannel[] IOChannelHandle,
          string paramAction,
          HTuple paramArgument)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])IOChannelHandle);
            IntPtr proc = HalconAPI.PreCall(2010);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, paramAction);
            HalconAPI.Store(proc, 2, paramArgument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(paramArgument);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)IOChannelHandle);
            return tuple;
        }

        /// <summary>
        ///   Perform an action on I/O channels.
        ///   Instance represents: Handles of the opened I/O channels.
        /// </summary>
        /// <param name="paramAction">Name of the action to perform.</param>
        /// <param name="paramArgument">List of arguments for the action. Default: []</param>
        /// <returns>List of values returned by the action.</returns>
        public HTuple ControlIoChannel(string paramAction, HTuple paramArgument)
        {
            IntPtr proc = HalconAPI.PreCall(2010);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, paramAction);
            HalconAPI.Store(proc, 2, paramArgument);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(paramArgument);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Write a value to the specified I/O channels.</summary>
        /// <param name="IOChannelHandle">Handles of the opened I/O channels.</param>
        /// <param name="value">Write values.</param>
        /// <returns>Status of written values.</returns>
        public static HTuple WriteIoChannel(HIOChannel[] IOChannelHandle, HTuple value)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])IOChannelHandle);
            IntPtr proc = HalconAPI.PreCall(2011);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(value);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)IOChannelHandle);
            return tuple;
        }

        /// <summary>
        ///   Write a value to the specified I/O channels.
        ///   Instance represents: Handles of the opened I/O channels.
        /// </summary>
        /// <param name="value">Write values.</param>
        /// <returns>Status of written values.</returns>
        public HTuple WriteIoChannel(HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(2011);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Read a value from the specified I/O channels.</summary>
        /// <param name="IOChannelHandle">Handles of the opened I/O channels.</param>
        /// <param name="status">Status of read value.</param>
        /// <returns>Read value.</returns>
        public static HTuple ReadIoChannel(HIOChannel[] IOChannelHandle, out HTuple status)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])IOChannelHandle);
            IntPtr proc = HalconAPI.PreCall(2012);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out status);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)IOChannelHandle);
            return tuple;
        }

        /// <summary>
        ///   Read a value from the specified I/O channels.
        ///   Instance represents: Handles of the opened I/O channels.
        /// </summary>
        /// <param name="status">Status of read value.</param>
        /// <returns>Read value.</returns>
        public HTuple ReadIoChannel(out HTuple status)
        {
            IntPtr proc = HalconAPI.PreCall(2012);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out status);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Set specific parameters of I/O channels.</summary>
        /// <param name="IOChannelHandle">Handles of the opened I/O channels.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values to set. Default: []</param>
        public static void SetIoChannelParam(
          HIOChannel[] IOChannelHandle,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])IOChannelHandle);
            IntPtr proc = HalconAPI.PreCall(2013);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)IOChannelHandle);
        }

        /// <summary>
        ///   Set specific parameters of I/O channels.
        ///   Instance represents: Handles of the opened I/O channels.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values to set. Default: []</param>
        public void SetIoChannelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2013);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Query specific parameters of I/O channels.</summary>
        /// <param name="IOChannelHandle">Handles of the opened I/O channels.</param>
        /// <param name="genParamName">Parameter names. Default: "param_name"</param>
        /// <returns>Parameter values.</returns>
        public static HTuple GetIoChannelParam(HIOChannel[] IOChannelHandle, HTuple genParamName)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])IOChannelHandle);
            IntPtr proc = HalconAPI.PreCall(2014);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)IOChannelHandle);
            return tuple;
        }

        /// <summary>
        ///   Query specific parameters of I/O channels.
        ///   Instance represents: Handles of the opened I/O channels.
        /// </summary>
        /// <param name="genParamName">Parameter names. Default: "param_name"</param>
        /// <returns>Parameter values.</returns>
        public HTuple GetIoChannelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2014);
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

        /// <summary>Open and configure I/O channels.</summary>
        /// <param name="IODeviceHandle">Handle of the opened I/O device.</param>
        /// <param name="IOChannelName">HALCON I/O channel names of the specified device.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values. Default: []</param>
        /// <returns>Handles of the opened I/O channel.</returns>
        public static HIOChannel[] OpenIoChannel(
          HIODevice IODeviceHandle,
          HTuple IOChannelName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2016);
            HalconAPI.Store(proc, 0, (HTool)IODeviceHandle);
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
            GC.KeepAlive((object)IODeviceHandle);
            return hioChannelArray;
        }

        /// <summary>
        ///   Open and configure I/O channels.
        ///   Modified instance represents: Handles of the opened I/O channel.
        /// </summary>
        /// <param name="IODeviceHandle">Handle of the opened I/O device.</param>
        /// <param name="IOChannelName">HALCON I/O channel names of the specified device.</param>
        /// <param name="genParamName">Parameter names. Default: []</param>
        /// <param name="genParamValue">Parameter values. Default: []</param>
        public void OpenIoChannel(
          HIODevice IODeviceHandle,
          string IOChannelName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2016);
            HalconAPI.Store(proc, 0, (HTool)IODeviceHandle);
            HalconAPI.StoreS(proc, 1, IOChannelName);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)IODeviceHandle);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2015);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
