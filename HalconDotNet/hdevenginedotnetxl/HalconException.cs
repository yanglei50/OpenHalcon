// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HalconException
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    public class HalconException : ApplicationException
    {
        private int err = 2;
        private const int ErrCodeUserException = 30000;
        private HTuple user_data;

        public HalconException(int err, string sInfo, Exception inner)
          : this(sInfo, inner)
        {
            this.err = err;
        }

        public HalconException(int err, string sInfo)
          : this(err, sInfo, (Exception)null)
        {
        }

        public HalconException(string sInfo, Exception inner)
          : base(sInfo, inner)
        {
            this.err = -1;
        }

        public HalconException(string sInfo)
          : base(sInfo)
        {
            this.err = -1;
        }

        public HalconException()
        {
            this.err = -1;
        }

        public HalconException(HTuple tuple)
          : this((int)tuple[0], tuple[1].O.ToString())
        {
            int num = 2;
            if (this.err >= 30000)
                num = 1;
            if (num > tuple.TupleLength() - 1)
                return;
            this.user_data = tuple.TupleSelectRange((HTuple)num, (HTuple)(tuple.TupleLength() - 1));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetErrorNumber is deprecated, please use GetErrorCode instead.")]
        public int GetErrorNumber()
        {
            return this.err;
        }

        public int GetErrorCode()
        {
            return this.err;
        }

        public void ToHTuple(out HTuple exception)
        {
            exception = new HTuple();
            exception[0] = (HTupleElements)this.GetErrorCode();
            if (this.GetErrorCode() < 30000)
                exception[1] = (HTupleElements)this.GetErrorMessage();
            if (this.user_data == null)
                return;
            exception = exception.TupleConcat(this.user_data);
        }

        public static void GetExceptionData(HTuple exception, HTuple name, out HTuple value)
        {
            value = new HTuple();
            bool flag = exception.TupleLength() > 0 && exception[0].Type == HTupleType.INTEGER && exception[0].I >= 30000;
            int num1 = name.TupleLength();
            for (int index1 = 0; index1 < num1; ++index1)
            {
                if (name[index1].Type != HTupleType.STRING)
                    throw new HOperatorException(0, "HOperatorException.GetExceptionData(): wrong type of input parameter 'name'.");
                string s = name[index1].S;
                int index2;
                if (s == "error_code")
                    index2 = 0;
                else if (s == "add_error_code")
                {
                    index2 = -1;
                }
                else
                {
                    if (s == "user_data")
                    {
                        if (num1 != 1)
                        {
                            value = new HTuple();
                            throw new HOperatorException(0, "HOperatorException.GetExceptionData(): slot 'user_data' onparameter 'Name' cannot be requested together with other slots.");
                        }
                        int num2 = !flag ? 2 : 1;
                        if (num2 > exception.TupleLength() - 1)
                            break;
                        value = value.TupleConcat(exception.TupleSelectRange((HTuple)num2, (HTuple)(exception.TupleLength() - 1)));
                        break;
                    }
                    if (s == "error_msg" || s == "error_message")
                        index2 = 1;
                    else if (s == "add_error_msg" || s == "add_error_message")
                        index2 = -1;
                    else if (s == "proc_line" || s == "program_line")
                        index2 = -1;
                    else if (s == "operator")
                        index2 = -1;
                    else if (s == "call_stack_depth")
                        index2 = -1;
                    else if (s == "procedure")
                    {
                        index2 = -1;
                    }
                    else
                    {
                        value = new HTuple();
                        throw new HOperatorException(0, "HOperatorException.GetExceptionData(): wrong value of input parameter 'name'.");
                    }
                }
                value = index2 != -1 ? (!flag || index2 == 0 ? value.TupleConcat((HTuple)exception[index2]) : value.TupleConcat((HTuple)"User defined exception")) : value.TupleConcat((HTuple)"");
            }
        }

        [Obsolete("GetErrorText is deprecated, please use GetErrorMessage instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetErrorText()
        {
            return this.Message;
        }

        public string GetErrorMessage()
        {
            return this.Message;
        }
    }
}
