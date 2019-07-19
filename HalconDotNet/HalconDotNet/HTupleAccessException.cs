using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>
    ///   This exception is thrown whenever an error occurs during tuple access.
    /// </summary>
    public class HTupleAccessException : HalconException
    {
        private static string BuildMessage(HTupleImplementation sender, string sInfo)
        {
            string str = sInfo;
            if (sender != null)
                str = "'" + str + "' when accessing '" + sender.ToString() + "'";
            return str;
        }

        internal HTupleAccessException(HTupleImplementation sender, string sInfo, Exception inner)
            : base(HTupleAccessException.BuildMessage(sender, sInfo), (Exception)null)
        {
        }

        internal HTupleAccessException(HTupleImplementation sender, string sInfo)
            : this(sender, sInfo, (Exception)null)
        {
        }

        internal HTupleAccessException(HTupleImplementation sender)
            : this(sender, "Illegal operation on Tuple")
        {
        }

        internal HTupleAccessException(string sInfo, Exception inner)
            : this((HTupleImplementation)null, sInfo, inner)
        {
        }

        internal HTupleAccessException(string sInfo)
            : this((HTupleImplementation)null, sInfo)
        {
        }

        internal HTupleAccessException()
            : this((HTupleImplementation)null)
        {
        }
    }
}
