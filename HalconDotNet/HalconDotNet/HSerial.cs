// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSerial
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a connection via a serial port.</summary>
    public class HSerial : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSerial()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HSerial(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerial obj)
        {
            obj = new HSerial(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerial[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSerial[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSerial(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open a serial device.
        ///   Modified instance represents: Serial interface handle.
        /// </summary>
        /// <param name="portName">Name of the serial port. Default: "COM1"</param>
        public HSerial(string portName)
        {
            IntPtr proc = HalconAPI.PreCall(314);
            HalconAPI.StoreS(proc, 0, portName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Clear the buffer of a serial connection.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="channel">Buffer to be cleared. Default: "input"</param>
        public void ClearSerial(string channel)
        {
            IntPtr proc = HalconAPI.PreCall(307);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, channel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write to a serial connection.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="data">Characters to write (as tuple of integers).</param>
        public void WriteSerial(HTuple data)
        {
            IntPtr proc = HalconAPI.PreCall(308);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, data);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write to a serial connection.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="data">Characters to write (as tuple of integers).</param>
        public void WriteSerial(int data)
        {
            IntPtr proc = HalconAPI.PreCall(308);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, data);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read from a serial device.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="numCharacters">Number of characters to read. Default: 1</param>
        /// <returns>Read characters (as tuple of integers).</returns>
        public HTuple ReadSerial(int numCharacters)
        {
            IntPtr proc = HalconAPI.PreCall(309);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, numCharacters);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the parameters of a serial device.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="dataBits">Number of data bits of the serial interface.</param>
        /// <param name="flowControl">Type of flow control of the serial interface.</param>
        /// <param name="parity">Parity of the serial interface.</param>
        /// <param name="stopBits">Number of stop bits of the serial interface.</param>
        /// <param name="totalTimeOut">Total timeout of the serial interface in ms.</param>
        /// <param name="interCharTimeOut">Inter-character timeout of the serial interface in ms.</param>
        /// <returns>Speed of the serial interface.</returns>
        public int GetSerialParam(
          out int dataBits,
          out string flowControl,
          out string parity,
          out int stopBits,
          out int totalTimeOut,
          out int interCharTimeOut)
        {
            IntPtr proc = HalconAPI.PreCall(310);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out dataBits);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out flowControl);
            int err5 = HalconAPI.LoadS(proc, 3, err4, out parity);
            int err6 = HalconAPI.LoadI(proc, 4, err5, out stopBits);
            int err7 = HalconAPI.LoadI(proc, 5, err6, out totalTimeOut);
            int procResult = HalconAPI.LoadI(proc, 6, err7, out interCharTimeOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Set the parameters of a serial device.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="baudRate">Speed of the serial interface. Default: "unchanged"</param>
        /// <param name="dataBits">Number of data bits of the serial interface. Default: "unchanged"</param>
        /// <param name="flowControl">Type of flow control of the serial interface. Default: "unchanged"</param>
        /// <param name="parity">Parity of the serial interface. Default: "unchanged"</param>
        /// <param name="stopBits">Number of stop bits of the serial interface. Default: "unchanged"</param>
        /// <param name="totalTimeOut">Total timeout of the serial interface in ms. Default: "unchanged"</param>
        /// <param name="interCharTimeOut">Inter-character timeout of the serial interface in ms. Default: "unchanged"</param>
        public void SetSerialParam(
          HTuple baudRate,
          HTuple dataBits,
          string flowControl,
          string parity,
          HTuple stopBits,
          HTuple totalTimeOut,
          HTuple interCharTimeOut)
        {
            IntPtr proc = HalconAPI.PreCall(311);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, baudRate);
            HalconAPI.Store(proc, 2, dataBits);
            HalconAPI.StoreS(proc, 3, flowControl);
            HalconAPI.StoreS(proc, 4, parity);
            HalconAPI.Store(proc, 5, stopBits);
            HalconAPI.Store(proc, 6, totalTimeOut);
            HalconAPI.Store(proc, 7, interCharTimeOut);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(baudRate);
            HalconAPI.UnpinTuple(dataBits);
            HalconAPI.UnpinTuple(stopBits);
            HalconAPI.UnpinTuple(totalTimeOut);
            HalconAPI.UnpinTuple(interCharTimeOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the parameters of a serial device.
        ///   Instance represents: Serial interface handle.
        /// </summary>
        /// <param name="baudRate">Speed of the serial interface. Default: "unchanged"</param>
        /// <param name="dataBits">Number of data bits of the serial interface. Default: "unchanged"</param>
        /// <param name="flowControl">Type of flow control of the serial interface. Default: "unchanged"</param>
        /// <param name="parity">Parity of the serial interface. Default: "unchanged"</param>
        /// <param name="stopBits">Number of stop bits of the serial interface. Default: "unchanged"</param>
        /// <param name="totalTimeOut">Total timeout of the serial interface in ms. Default: "unchanged"</param>
        /// <param name="interCharTimeOut">Inter-character timeout of the serial interface in ms. Default: "unchanged"</param>
        public void SetSerialParam(
          int baudRate,
          int dataBits,
          string flowControl,
          string parity,
          int stopBits,
          int totalTimeOut,
          int interCharTimeOut)
        {
            IntPtr proc = HalconAPI.PreCall(311);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, baudRate);
            HalconAPI.StoreI(proc, 2, dataBits);
            HalconAPI.StoreS(proc, 3, flowControl);
            HalconAPI.StoreS(proc, 4, parity);
            HalconAPI.StoreI(proc, 5, stopBits);
            HalconAPI.StoreI(proc, 6, totalTimeOut);
            HalconAPI.StoreI(proc, 7, interCharTimeOut);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a serial device.
        ///   Modified instance represents: Serial interface handle.
        /// </summary>
        /// <param name="portName">Name of the serial port. Default: "COM1"</param>
        public void OpenSerial(string portName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(314);
            HalconAPI.StoreS(proc, 0, portName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(313);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
