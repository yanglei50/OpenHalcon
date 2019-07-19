using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
namespace HalconDotNet
{
    public abstract class HTupleImplementation
    {
        protected System.Type typeI = typeof(int);
        protected System.Type typeL = typeof(long);
        protected System.Type typeD = typeof(double);
        protected System.Type typeS = typeof(string);
        protected System.Type typeO = typeof(object);
        protected System.Type typeF = typeof(float);
        protected System.Type typeIP = typeof(IntPtr);
        public const int INTEGER = 1;
        public const int DOUBLE = 2;
        public const int STRING = 4;
        public const int ANY_ELEM = 7;
        public const int MIXED = 8;
        public const int ANY_TUPLE = 15;
        public const int LONG = 129;
        public const int FLOAT = 32898;
        public const int INTPTR = 32900;
        public const int BAN_IN_MIXED = 32768;
        protected Array data;
        protected int iLength;
        internal GCHandle pinHandle;
        internal int pinCount;

        public static int GetObjectType(object o)
        {
            if (o is int)
                return 1;
            if (o is long)
                return 129;
            if (o is double)
                return 2;
            if (o is float)
                return 32898;
            if (o is string)
                return 4;
            return o is IntPtr ? 32900 : 15;
        }

        public static int GetObjectsType(object[] o)
        {
            if (o == null)
                return 15;
            int num1 = 15;
            int num2 = 15;
            for (int index = 0; index < o.Length; ++index)
            {
                if (o[index] is int)
                    num1 = 1;
                if (o[index] is long)
                    num1 = 129;
                if (o[index] is double)
                    num1 = 2;
                if (o[index] is float)
                    num1 = 32898;
                if (o[index] is string)
                    num1 = 4;
                if (o[index] is IntPtr)
                    num1 = 32900;
                if (index == 0)
                    num2 = num1;
                else if (num1 != num2)
                    return 8;
            }
            return num2;
        }

        internal virtual void PinTuple()
        {
        }

        internal void UnpinTuple()
        {
            Monitor.Enter((object)this);
            if (this.pinCount > 0)
            {
                --this.pinCount;
                if (this.pinCount == 0)
                    this.pinHandle.Free();
            }
            Monitor.Exit((object)this);
        }

        protected abstract Array CreateArray(int size);

        protected void SetArray(Array source, bool copy)
        {
            if (source == null)
                source = this.CreateArray(0);
            if (copy)
            {
                this.data = this.CreateArray(source.Length);
                Array.Copy(source, this.data, source.Length);
            }
            else
                this.data = source;
            this.iLength = this.data.Length;
            this.NotifyArrayUpdate();
        }

        protected virtual void NotifyArrayUpdate()
        {
        }

        protected int Capacity
        {
            get
            {
                return this.data.Length;
            }
        }

        public int Length
        {
            get
            {
                return this.iLength;
            }
        }

        public virtual void AssertSize(int index)
        {
            if (index < this.iLength)
                return;
            if (index >= this.data.Length)
            {
                Array data = this.data;
                this.data = this.CreateArray(Math.Max(10, 2 * index));
                Array.Copy(data, this.data, this.iLength);
                this.NotifyArrayUpdate();
            }
            this.iLength = index + 1;
        }

        public virtual void AssertSize(int[] indices)
        {
            int index1;
            if (indices.Length == 0)
            {
                index1 = 0;
            }
            else
            {
                index1 = indices[0];
                foreach (int index2 in indices)
                {
                    if (index2 > index1)
                        index1 = index2;
                }
            }
            this.AssertSize(index1);
        }

        public virtual HTupleType Type
        {
            get
            {
                throw new HTupleAccessException();
            }
        }

        public virtual int[] IArr
        {
            get
            {
                throw new HTupleAccessException(this);
            }
            set
            {
                throw new HTupleAccessException(this);
            }
        }

        public virtual long[] LArr
        {
            get
            {
                throw new HTupleAccessException(this);
            }
            set
            {
                throw new HTupleAccessException(this);
            }
        }

        public virtual double[] DArr
        {
            get
            {
                throw new HTupleAccessException(this);
            }
            set
            {
                throw new HTupleAccessException(this);
            }
        }

        public virtual string[] SArr
        {
            get
            {
                throw new HTupleAccessException(this);
            }
            set
            {
                throw new HTupleAccessException(this);
            }
        }

        public virtual object[] OArr
        {
            get
            {
                throw new HTupleAccessException(this);
            }
            set
            {
                throw new HTupleAccessException(this);
            }
        }

        public virtual HTupleElements GetElement(int index, HTuple parent)
        {
            throw new HTupleAccessException(this);
        }

        public virtual HTupleElements GetElements(int[] indices, HTuple parent)
        {
            if (indices == null || indices.Length == 0)
                return new HTupleElements();
            throw new HTupleAccessException(this);
        }

        public virtual void SetElements(int[] indices, HTupleElements elements)
        {
            if (indices != null && indices.Length != 0)
                throw new HTupleAccessException(this);
        }

        protected Array ToArray(System.Type t)
        {
            Array instance = Array.CreateInstance(t, this.iLength);
            Array.Copy(this.data, instance, this.iLength);
            return instance;
        }

        public virtual int[] ToIArr()
        {
            throw new HTupleAccessException(this, "Cannot convert to int array");
        }

        public virtual long[] ToLArr()
        {
            throw new HTupleAccessException(this, "Cannot convert to long array");
        }

        public virtual double[] ToDArr()
        {
            throw new HTupleAccessException(this, "Cannot convert to double array");
        }

        public virtual string[] ToSArr()
        {
            string[] strArray = new string[this.iLength];
            for (int index = 0; index < this.iLength; ++index)
                strArray[index] = this.data.GetValue(index).ToString();
            return strArray;
        }

        public virtual object[] ToOArr()
        {
            return (object[])this.ToArray(this.typeO);
        }

        public virtual float[] ToFArr()
        {
            throw new HTupleAccessException(this, "Cannot convert to float array");
        }

        public virtual IntPtr[] ToIPArr()
        {
            throw new HTupleAccessException(this, "Values in tuple do not represent pointers on this platform");
        }

        public virtual void Store(IntPtr proc, int parIndex)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, this.iLength, out tuple));
            this.StoreData(proc, tuple);
        }

        protected abstract void StoreData(IntPtr proc, IntPtr tuple);

        public static int Load(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          out HTupleImplementation data)
        {
            IntPtr tuple;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            return HTupleImplementation.LoadData(tuple, type, out data);
        }

        public static int LoadData(IntPtr tuple, HTupleType type, out HTupleImplementation data)
        {
            int num = 2;
            if (tuple == IntPtr.Zero)
            {
                data = (HTupleImplementation)HTupleVoid.EMPTY;
                return num;
            }
            int type1;
            HalconAPI.GetTupleTypeScanElem(tuple, out type1);
            switch (type1)
            {
                case 1:
                    if (HalconAPI.isPlatform64)
                    {
                        HTupleInt64 data1;
                        num = HTupleInt64.Load(tuple, out data1);
                        data = (HTupleImplementation)data1;
                    }
                    else
                    {
                        HTupleInt32 data1;
                        num = HTupleInt32.Load(tuple, out data1);
                        data = (HTupleImplementation)data1;
                    }
                    type = HTupleType.INTEGER;
                    break;
                case 2:
                    HTupleDouble data2;
                    num = HTupleDouble.Load(tuple, out data2);
                    data = (HTupleImplementation)data2;
                    type = HTupleType.DOUBLE;
                    break;
                case 4:
                    HTupleString data3;
                    num = HTupleString.Load(tuple, out data3);
                    data = (HTupleImplementation)data3;
                    type = HTupleType.STRING;
                    break;
                case 7:
                    HTupleMixed data4;
                    num = HTupleMixed.Load(tuple, out data4);
                    data = (HTupleImplementation)data4;
                    type = HTupleType.MIXED;
                    break;
                case 15:
                    data = (HTupleImplementation)HTupleVoid.EMPTY;
                    type = HTupleType.EMPTY;
                    break;
                default:
                    data = (HTupleImplementation)HTupleVoid.EMPTY;
                    num = 7002;
                    break;
            }
            return num;
        }
    }
}
