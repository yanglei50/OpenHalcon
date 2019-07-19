using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a socket connection.</summary>
    public class HSocket : HTool
    {
       // [EditorBrowsable(EditorBrowsableState.Never)]
        public HSocket()
          : base(HTool.UNDEF)
        {
        }

       // [EditorBrowsable(EditorBrowsableState.Never)]
        public HSocket(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSocket obj)
        {
            obj = new HSocket(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSocket[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HSocket[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HSocket(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open a socket and connect it to an accepting socket.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="hostName">Hostname of the computer to connect to. Default: "localhost"</param>
        /// <param name="port">Port number.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public HSocket(string hostName, int port, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(342);
            HalconAPI.StoreS(proc, 0, hostName);
            HalconAPI.StoreI(proc, 1, port);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket and connect it to an accepting socket.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="hostName">Hostname of the computer to connect to. Default: "localhost"</param>
        /// <param name="port">Port number.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public HSocket(string hostName, int port, string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(342);
            HalconAPI.StoreS(proc, 0, hostName);
            HalconAPI.StoreI(proc, 1, port);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket that accepts connection requests.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="port">Port number. Default: 3000</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public HSocket(int port, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(343);
            HalconAPI.StoreI(proc, 0, port);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket that accepts connection requests.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="port">Port number. Default: 3000</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public HSocket(int port, string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(343);
            HalconAPI.StoreI(proc, 0, port);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Receive an image over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Received image.</returns>
        public HImage ReceiveImage()
        {
            IntPtr proc = HalconAPI.PreCall(325);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Send an image over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="image">Image to be sent.</param>
        public void SendImage(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(326);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Receive regions over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Received regions.</returns>
        public HRegion ReceiveRegion()
        {
            IntPtr proc = HalconAPI.PreCall(327);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Send regions over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="region">Regions to be sent.</param>
        public void SendRegion(HRegion region)
        {
            IntPtr proc = HalconAPI.PreCall(328);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
        }

        /// <summary>
        ///   Receive an XLD object over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Received XLD object.</returns>
        public HXLD ReceiveXld()
        {
            IntPtr proc = HalconAPI.PreCall(329);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLD hxld;
            int procResult = HXLD.LoadNew(proc, 1, err, out hxld);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxld;
        }

        /// <summary>
        ///   Send an XLD object over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="XLD">XLD object to be sent.</param>
        public void SendXld(HXLD XLD)
        {
            IntPtr proc = HalconAPI.PreCall(330);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)XLD);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)XLD);
        }

        /// <summary>
        ///   Receive a tuple over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Received tuple.</returns>
        public HTuple ReceiveTuple()
        {
            IntPtr proc = HalconAPI.PreCall(331);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Send a tuple over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="tuple">Tuple to be sent.</param>
        public void SendTuple(HTuple tuple)
        {
            IntPtr proc = HalconAPI.PreCall(332);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, tuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Send a tuple over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="tuple">Tuple to be sent.</param>
        public void SendTuple(string tuple)
        {
            IntPtr proc = HalconAPI.PreCall(332);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, tuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Receive arbitrary data from external devices or applications using a generic socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="format">Specification how to convert the data to tuples. Default: "z"</param>
        /// <param name="from">IP address or hostname and network port of the communication partner.</param>
        /// <returns>Value (or tuple of values) holding the received and converted data.</returns>
        public HTuple ReceiveData(HTuple format, out HTuple from)
        {
            IntPtr proc = HalconAPI.PreCall(333);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, format);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(format);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out from);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Receive arbitrary data from external devices or applications using a generic socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="format">Specification how to convert the data to tuples. Default: "z"</param>
        /// <param name="from">IP address or hostname and network port of the communication partner.</param>
        /// <returns>Value (or tuple of values) holding the received and converted data.</returns>
        public HTuple ReceiveData(string format, out string from)
        {
            IntPtr proc = HalconAPI.PreCall(333);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, format);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HalconAPI.LoadS(proc, 1, err2, out from);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Send arbitrary data to external devices or applications using a generic socket communication.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="format">Specification how to convert the data. Default: "z"</param>
        /// <param name="data">Value (or tuple of values) holding the data to send.</param>
        /// <param name="to">IP address or hostname and network port of the communication partner. Default: []</param>
        public void SendData(string format, HTuple data, HTuple to)
        {
            IntPtr proc = HalconAPI.PreCall(334);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, format);
            HalconAPI.Store(proc, 2, data);
            HalconAPI.Store(proc, 3, to);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(data);
            HalconAPI.UnpinTuple(to);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Send arbitrary data to external devices or applications using a generic socket communication.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="format">Specification how to convert the data. Default: "z"</param>
        /// <param name="data">Value (or tuple of values) holding the data to send.</param>
        /// <param name="to">IP address or hostname and network port of the communication partner. Default: []</param>
        public void SendData(string format, string data, string to)
        {
            IntPtr proc = HalconAPI.PreCall(334);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, format);
            HalconAPI.StoreS(proc, 2, data);
            HalconAPI.StoreS(proc, 3, to);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get the value of a socket parameter.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="genParamName">Name of the socket parameter.</param>
        /// <returns>Value of the socket parameter.</returns>
        public HTuple GetSocketParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(335);
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
        ///   Get the value of a socket parameter.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="genParamName">Name of the socket parameter.</param>
        /// <returns>Value of the socket parameter.</returns>
        public HTuple GetSocketParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(335);
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
        ///   Set a socket parameter.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="genParamName">Name of the socket parameter.</param>
        /// <param name="genParamValue">Value of the socket parameter. Default: "on"</param>
        public void SetSocketParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(336);
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
        ///   Set a socket parameter.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="genParamName">Name of the socket parameter.</param>
        /// <param name="genParamValue">Value of the socket parameter. Default: "on"</param>
        public void SetSocketParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(336);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Determine the HALCON data type of the next socket data.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Data type of next HALCON data.</returns>
        public string GetNextSocketDataType()
        {
            IntPtr proc = HalconAPI.PreCall(337);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Get the socket descriptor of a socket used by the operating system.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Socket descriptor used by the operating system.</returns>
        public int GetSocketDescriptor()
        {
            IntPtr proc = HalconAPI.PreCall(338);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>Close all opened sockets.</summary>
        public static void CloseAllSockets()
        {
            IntPtr proc = HalconAPI.PreCall(339);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>
        ///   Accept a connection request on a listening socket of the protocol type 'HALCON' or 'TCP'/'TCP4'/'TCP6'.
        ///   Instance represents: Socket number of the accepting socket.
        /// </summary>
        /// <param name="wait">Should the operator wait until a connection request arrives? Default: "auto"</param>
        /// <returns>Socket number.</returns>
        public HSocket SocketAcceptConnect(string wait)
        {
            IntPtr proc = HalconAPI.PreCall(341);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, wait);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSocket hsocket;
            int procResult = HSocket.LoadNew(proc, 0, err, out hsocket);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hsocket;
        }

        /// <summary>
        ///   Open a socket and connect it to an accepting socket.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="hostName">Hostname of the computer to connect to. Default: "localhost"</param>
        /// <param name="port">Port number.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public void OpenSocketConnect(
          string hostName,
          int port,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(342);
            HalconAPI.StoreS(proc, 0, hostName);
            HalconAPI.StoreI(proc, 1, port);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket and connect it to an accepting socket.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="hostName">Hostname of the computer to connect to. Default: "localhost"</param>
        /// <param name="port">Port number.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public void OpenSocketConnect(
          string hostName,
          int port,
          string genParamName,
          string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(342);
            HalconAPI.StoreS(proc, 0, hostName);
            HalconAPI.StoreI(proc, 1, port);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket that accepts connection requests.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="port">Port number. Default: 3000</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public void OpenSocketAccept(int port, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(343);
            HalconAPI.StoreI(proc, 0, port);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a socket that accepts connection requests.
        ///   Modified instance represents: Socket number.
        /// </summary>
        /// <param name="port">Port number. Default: 3000</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the socket. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the socket. Default: []</param>
        public void OpenSocketAccept(int port, string genParamName, string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(343);
            HalconAPI.StoreI(proc, 0, port);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Receive a serialized item over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem ReceiveSerializedItem()
        {
            IntPtr proc = HalconAPI.PreCall(403);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Send a serialized item over a socket connection.
        ///   Instance represents: Socket number.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void SendSerializedItem(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(404);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)serializedItemHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(340);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
