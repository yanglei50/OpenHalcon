using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdevenginedotnetxl
{
    public class HDevEngineException : HalconException
    {
        private int halconError;
        private HDevEngineException.ExceptionCategory category;
        private string procedureName;
        private string lineText;
        private int lineNumber;
        private HTuple userData;

        /// <summary>The internal HALCON error code</summary>
        public int HalconError
        {
            get
            {
                return this.halconError;
            }
        }

        /// <summary>Type of exception</summary>
        public HDevEngineException.ExceptionCategory Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>Name of the originating HDevelop procedure</summary>
        public string ProcedureName
        {
            get
            {
                return this.procedureName;
            }
        }

        /// <summary>Script line in which the error occured</summary>
        public string LineText
        {
            get
            {
                return this.lineText;
            }
        }

        /// <summary>Script line number at which the error occured</summary>
        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }

        /// <summary>User data which was added to the exception</summary>
        public HTuple UserData
        {
            get
            {
                return this.userData;
            }
        }

        internal static void ThrowGeneric(string message)
        {
            HDevEngineException.ThrowGeneric(message, "");
        }

        internal static void ThrowGeneric(string message, string procedureName)
        {
            throw new HDevEngineException(2, HDevEngineException.ExceptionCategory.Generic, message, procedureName, "", 0, new HTuple());
        }

        internal static void ThrowLastException(int err)
        {
            int category;
            string message;
            string procedureName;
            string lineText;
            int lineNumber;
            HTuple userData;
            int lastException = EngineAPI.GetLastException(out category, out message, out procedureName, out lineText, out lineNumber, out userData);
            if (err != -1 && lastException == 2)
                throw new HOperatorException(err);
            throw new HDevEngineException(lastException, (HDevEngineException.ExceptionCategory)category, message, procedureName, lineText, lineNumber, userData);
        }

        internal HDevEngineException(
          int halconError,
          HDevEngineException.ExceptionCategory category,
          string message,
          string procedureName,
          string lineText,
          int lineNumber,
          HTuple userData)
          : base(message)
        {
            this.halconError = halconError;
            this.category = category;
            this.procedureName = procedureName;
            this.lineText = lineText;
            this.lineNumber = lineNumber;
            this.userData = userData;
        }

        public override string ToString()
        {
            string str = "HDevEngine: " + this.Message;
            if (this.procedureName != "")
                str = str + " in " + this.procedureName;
            if (this.lineNumber > 0)
                str = str + " at line " + (object)this.lineNumber + " (" + this.lineText + ")";
            return str;
        }

        /// <summary>Different types of errors when using HDevEngine</summary>
        public enum ExceptionCategory
        {
            /// <summary>No special type</summary>
            Generic,
            /// <summary>Unintialized input parameters for procedure call</summary>
            Input,
            /// <summary>HALCON error while executing an operator</summary>
            Operator,
            /// <summary>Problems loading scripts or procedures files</summary>
            File,
        }
    }
}
