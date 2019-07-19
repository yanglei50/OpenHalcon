// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOperatorException
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    public class HOperatorException : HalconException
    {
        public HOperatorException(int err, string sInfo, Exception inner)
          : base(err, sInfo == "" ? HalconAPI.GetErrorMessage(err) : sInfo, inner)
        {
        }

        public HOperatorException(int err, string sInfo)
          : this(err, sInfo, (Exception)null)
        {
        }

        public HOperatorException(int err)
          : this(err, "")
        {
        }

        [Obsolete("GetErrorText is deprecated, please use GetErrorMessage instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string GetErrorText()
        {
            return HalconAPI.GetErrorMessage(this.GetErrorCode());
        }

        public new string GetErrorMessage()
        {
            return HalconAPI.GetErrorMessage(this.GetErrorCode());
        }

        public long GetExtendedErrorCode()
        {
            HTuple operatorName;
            HTuple errorCode;
            HTuple errorMessage;
            HOperatorSet.GetExtendedErrorInfo(out operatorName, out errorCode, out errorMessage);
            if (errorCode.Length > 0)
                return errorCode[0].L;
            return 0;
        }

        public string GetExtendedErrorMessage()
        {
            HTuple operatorName;
            HTuple errorCode;
            HTuple errorMessage;
            HOperatorSet.GetExtendedErrorInfo(out operatorName, out errorCode, out errorMessage);
            if (errorMessage.Length > 0)
                return (string)errorMessage[0];
            return "";
        }

        public static void throwOperator(int err, string logicalName)
        {
            if (HalconAPI.IsFailure(err))
                throw new HOperatorException(err, HalconAPI.GetErrorMessage(err) + " in operator " + logicalName);
        }

        internal static void throwOperator(int err, int procIndex)
        {
            if (HalconAPI.IsFailure(err))
            {
                string logicalName = HalconAPI.GetLogicalName(procIndex);
                throw new HOperatorException(err, HalconAPI.GetErrorMessage(err) + " in operator " + logicalName);
            }
        }

        public static void throwInfo(int err, string sInfo)
        {
            throw new HOperatorException(err, sInfo + ":\n" + HalconAPI.GetErrorMessage(err) + "\n");
        }
    }
}
