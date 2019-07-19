// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HVectorAccessException
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>
    ///   This exception is thrown whenever an error occurs during
    ///   vector operations
    /// </summary>
    public class HVectorAccessException : HalconException
    {
        private static string BuildMessage(HVector sender, string sInfo)
        {
            string str = sInfo;
            if (sender != null)
                str = "'" + str + "' when accessing '" + sender.ToString() + "'";
            return str;
        }

        internal HVectorAccessException(HVector sender, string sInfo, Exception inner)
            : base(HVectorAccessException.BuildMessage(sender, sInfo), (Exception)null)
        {
        }

        internal HVectorAccessException(HVector sender, string sInfo)
            : this(sender, sInfo, (Exception)null)
        {
        }

        internal HVectorAccessException(HVector sender)
            : this(sender, "Illegal operation on vector")
        {
        }

        internal HVectorAccessException(string sInfo, Exception inner)
            : this((HVector)null, sInfo, inner)
        {
        }

        internal HVectorAccessException(string sInfo)
            : this((HVector)null, sInfo)
        {
        }

        internal HVectorAccessException()
            : this((HVector)null)
        {
        }
    }
}