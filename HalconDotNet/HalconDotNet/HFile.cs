using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a file.</summary>
    public class HFile : HTool
    {
        public HFile()
          : base(HTool.UNDEF)
        {
        }

        public HFile(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFile obj)
        {
            obj = new HFile(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFile[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HFile[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HFile(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open a file in ASCII or a binary format.
        ///   Modified instance represents: File handle.
        /// </summary>
        /// <param name="fileName">Name of file to be opened. Default: "standard"</param>
        /// <param name="fileType">Type of file. Default: "output"</param>
        public HFile(string fileName, string fileType)
        {
            IntPtr proc = HalconAPI.PreCall(1659);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, fileType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open a file in ASCII or a binary format.
        ///   Modified instance represents: File handle.
        /// </summary>
        /// <param name="fileName">Name of file to be opened. Default: "standard"</param>
        /// <param name="fileType">Type of file. Default: "output"</param>
        public void OpenFile(string fileName, string fileType)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1659);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, fileType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write values in a file.
        ///   Instance represents: File handle.
        /// </summary>
        /// <param name="stringVal">Values to be put out on the file. Default: "hallo"</param>
        public void FwriteString(HTuple stringVal)
        {
            IntPtr proc = HalconAPI.PreCall(1660);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, stringVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(stringVal);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write values in a file.
        ///   Instance represents: File handle.
        /// </summary>
        /// <param name="stringVal">Values to be put out on the file. Default: "hallo"</param>
        public void FwriteString(string stringVal)
        {
            IntPtr proc = HalconAPI.PreCall(1660);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, stringVal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a line from a file.
        ///   Instance represents: File handle.
        /// </summary>
        /// <param name="isEOF">Reached end of file.</param>
        /// <returns>Read line.</returns>
        public string FreadLine(out int isEOF)
        {
            IntPtr proc = HalconAPI.PreCall(1661);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out isEOF);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Read strings from a file.
        ///   Instance represents: File handle.
        /// </summary>
        /// <param name="isEOF">Reached end of file.</param>
        /// <returns>Read character sequence.</returns>
        public string FreadString(out int isEOF)
        {
            IntPtr proc = HalconAPI.PreCall(1662);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out isEOF);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Read a character from a file.
        ///   Instance represents: File handle.
        /// </summary>
        /// <returns>Read character or control string ('eof').</returns>
        public string FreadChar()
        {
            IntPtr proc = HalconAPI.PreCall(1663);
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
        ///   Create a line feed.
        ///   Instance represents: File handle.
        /// </summary>
        public void FnewLine()
        {
            IntPtr proc = HalconAPI.PreCall(1664);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1665);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
