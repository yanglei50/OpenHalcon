using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    public class HTupleElements
    {
        private HTuple parent;
        private HTupleElementsImplementation elements;

        internal HTupleElements()
        {
            this.parent = (HTuple)null;
            this.elements = new HTupleElementsImplementation();
        }

        internal HTupleElements(HTuple parent, HTupleInt32 source, int index)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsInt32(source, index);
        }

        internal HTupleElements(HTuple parent, HTupleInt32 source, int[] indices)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsInt32(source, indices);
        }

        internal HTupleElements(HTuple parent, HTupleInt64 tupleImp, int index)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsInt64(tupleImp, index);
        }

        internal HTupleElements(HTuple parent, HTupleInt64 tupleImp, int[] indices)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsInt64(tupleImp, indices);
        }

        internal HTupleElements(HTuple parent, HTupleDouble tupleImp, int index)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsDouble(tupleImp, index);
        }

        internal HTupleElements(HTuple parent, HTupleDouble tupleImp, int[] indices)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsDouble(tupleImp, indices);
        }

        internal HTupleElements(HTuple parent, HTupleString tupleImp, int index)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsString(tupleImp, index);
        }

        internal HTupleElements(HTuple parent, HTupleString tupleImp, int[] indices)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsString(tupleImp, indices);
        }

        internal HTupleElements(HTuple parent, HTupleMixed tupleImp, int index)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsMixed(tupleImp, index);
        }

        internal HTupleElements(HTuple parent, HTupleMixed tupleImp, int[] indices)
        {
            this.parent = parent;
            this.elements = (HTupleElementsImplementation)new HTupleElementsMixed(tupleImp, indices);
        }

        /// <summary>
        ///   Get the value of this element as a 32-bit integer.
        ///   The element must represent integer data (32-bit or 64-bit).
        /// </summary>
        public int I
        {
            get
            {
                return this.elements.I[0];
            }
            set
            {
                int[] numArray = new int[1] { value };
                try
                {
                    this.elements.I = numArray;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.I = numArray;
                }
            }
        }

        /// <summary>
        ///   Get the value of these elements as a 32-bit integer.
        ///   The elements must represent integer data (32-bit or 64-bit).
        /// </summary>
        public int[] IArr
        {
            get
            {
                return this.elements.I;
            }
            set
            {
                try
                {
                    this.elements.I = value;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.I = value;
                }
            }
        }

        /// <summary>
        ///   Get the value of this element as a 64-bit integer.
        ///   The elements must represent integer data (32-bit or 64-bit).
        /// </summary>
        public long L
        {
            get
            {
                return this.elements.L[0];
            }
            set
            {
                long[] numArray = new long[1] { value };
                try
                {
                    this.elements.L = numArray;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.L = numArray;
                }
            }
        }

        /// <summary>
        ///   Get the value of these elements as a 64-bit integer.
        ///   The elements must represent integer data (32-bit or 64-bit).
        /// </summary>
        public long[] LArr
        {
            get
            {
                return this.elements.L;
            }
            set
            {
                try
                {
                    this.elements.L = value;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.L = value;
                }
            }
        }

        /// <summary>
        ///   Get the value of this element as a double.
        ///   The element must represent numeric data.
        /// </summary>
        public double D
        {
            get
            {
                return this.elements.D[0];
            }
            set
            {
                double[] numArray = new double[1] { value };
                try
                {
                    this.elements.D = numArray;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.D = numArray;
                }
            }
        }

        /// <summary>
        ///   Get the value of these elements as doubles.
        ///   The elements must represent numeric data.
        /// </summary>
        public double[] DArr
        {
            get
            {
                return this.elements.D;
            }
            set
            {
                try
                {
                    this.elements.D = value;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.D = value;
                }
            }
        }

        /// <summary>
        ///   Get the value of this element as a string.
        ///   The element must represent a string value.
        /// </summary>
        public string S
        {
            get
            {
                return this.elements.S[0];
            }
            set
            {
                string[] strArray = new string[1] { value };
                try
                {
                    this.elements.S = strArray;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.S = strArray;
                }
            }
        }

        /// <summary>
        ///   Get the value of these elements as strings.
        ///   The elements must represent string values.
        /// </summary>
        public string[] SArr
        {
            get
            {
                return this.elements.S;
            }
            set
            {
                try
                {
                    this.elements.S = value;
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.elements.S = value;
                }
            }
        }

        /// <summary>
        ///   Get the value of this element as an object.
        ///   The element may be of any type. Numeric data will be boxed.
        /// </summary>
        public object O
        {
            get
            {
                return this.elements.O[0];
            }
            set
            {
                if (this.elements is HTupleElementsMixed)
                {
                    this.elements.O[0] = value;
                }
                else
                {
                    switch (HTupleImplementation.GetObjectType(value))
                    {
                        case 1:
                            this.I = (int)value;
                            break;
                        case 2:
                            this.D = (double)value;
                            break;
                        case 4:
                            this.S = (string)value;
                            break;
                        case 129:
                            this.L = (long)value;
                            break;
                        case 32898:
                            this.F = (float)value;
                            break;
                        case 32900:
                            this.IP = (IntPtr)value;
                            break;
                        default:
                            throw new HTupleAccessException("Attempting to assign object containing invalid type");
                    }
                }
            }
        }

        /// <summary>
        ///   Get the value of these elements as objects.
        ///   The elements may be of any type. Numeric data will be boxed.
        /// </summary>
        public object[] OArr
        {
            get
            {
                return this.elements.O;
            }
            set
            {
                if (this.elements is HTupleElementsMixed)
                {
                    this.elements.O = value;
                }
                else
                {
                    switch (HTupleImplementation.GetObjectsType(value))
                    {
                        case 1:
                            this.IArr = Array.ConvertAll<object, int>(value, new Converter<object, int>(HTupleElements.ObjectToInt));
                            break;
                        case 2:
                            this.DArr = Array.ConvertAll<object, double>(value, new Converter<object, double>(HTupleElements.ObjectToDouble));
                            break;
                        case 4:
                            this.SArr = Array.ConvertAll<object, string>(value, new Converter<object, string>(HTupleElements.ObjectToString));
                            break;
                        case 129:
                            this.LArr = Array.ConvertAll<object, long>(value, new Converter<object, long>(HTupleElements.ObjectToLong));
                            break;
                        case 32898:
                            this.FArr = Array.ConvertAll<object, float>(value, new Converter<object, float>(HTupleElements.ObjectToFloat));
                            break;
                        case 32900:
                            this.IPArr = Array.ConvertAll<object, IntPtr>(value, new Converter<object, IntPtr>(HTupleElements.ObjectToIntPtr));
                            break;
                        default:
                            throw new HTupleAccessException("Attempting to assign object containing invalid type");
                    }
                }
            }
        }

        public static int ObjectToInt(object o)
        {
            return (int)o;
        }

        public static long ObjectToLong(object o)
        {
            return (long)o;
        }

        public static double ObjectToDouble(object o)
        {
            return (double)o;
        }

        public static float ObjectToFloat(object o)
        {
            return (float)o;
        }

        public static string ObjectToString(object o)
        {
            return (string)o;
        }

        public static IntPtr ObjectToIntPtr(object o)
        {
            return (IntPtr)o;
        }

        /// <summary>
        ///   Get the value of this element as a float.
        ///   The element must represent numeric data.
        /// </summary>
        public float F
        {
            get
            {
                return (float)this.D;
            }
            set
            {
                this.D = (double)value;
            }
        }

        /// <summary>
        ///   Get the value of these elements as a float.
        ///   The elements must represent numeric data.
        /// </summary>
        public float[] FArr
        {
            get
            {
                double[] darr = this.DArr;
                float[] numArray = new float[darr.Length];
                for (int index = 0; index < darr.Length; ++index)
                    numArray[index] = (float)darr[index];
                return numArray;
            }
            set
            {
                double[] numArray = new double[value.Length];
                for (int index = 0; index < value.Length; ++index)
                    numArray[index] = (double)value[index];
                this.DArr = numArray;
            }
        }

        /// <summary>
        ///   Get the value of this element as an IntPtr.
        ///   The element must represent an integer matching IntPtr.Size.
        /// </summary>
        public IntPtr IP
        {
            get
            {
                if (HalconAPI.isPlatform64 && this.Type == HTupleType.LONG)
                    return new IntPtr(this.L);
                if (this.Type == HTupleType.INTEGER)
                    return new IntPtr(this.I);
                throw new HTupleAccessException("Value does not represent a pointer on this platform");
            }
            set
            {
                if (HalconAPI.isPlatform64)
                    this.L = value.ToInt64();
                else
                    this.I = value.ToInt32();
            }
        }

        /// <summary>
        ///   Get the value of these elements as IntPtrs.
        ///   The elements must represent integers matching IntPtr.Size.
        /// </summary>
        public IntPtr[] IPArr
        {
            get
            {
                if (HalconAPI.isPlatform64 && this.Type == HTupleType.LONG)
                {
                    IntPtr[] numArray = new IntPtr[this.LArr.Length];
                    for (int index = 0; index < this.LArr.Length; ++index)
                        numArray[index] = new IntPtr(this.LArr[index]);
                    return numArray;
                }
                if (this.Type != HTupleType.INTEGER)
                    throw new HTupleAccessException("Value does not represent a pointer on this platform");
                IntPtr[] numArray1 = new IntPtr[this.IArr.Length];
                for (int index = 0; index < this.IArr.Length; ++index)
                    numArray1[index] = new IntPtr(this.IArr[index]);
                return numArray1;
            }
            set
            {
                if (HalconAPI.isPlatform64)
                {
                    long[] numArray = new long[value.Length];
                    for (int index = 0; index < value.Length; ++index)
                        numArray[index] = value[index].ToInt64();
                    this.LArr = numArray;
                }
                else
                {
                    int[] numArray = new int[value.Length];
                    for (int index = 0; index < value.Length; ++index)
                        numArray[index] = value[index].ToInt32();
                    this.IArr = numArray;
                }
            }
        }

        /// <summary>Get the data type of this element</summary>
        public HTupleType Type
        {
            get
            {
                return this.elements.Type;
            }
        }

        /// <summary>Get the length of this element</summary>
        internal int Length
        {
            get
            {
                return this.elements.Length;
            }
        }

        internal void ConvertToMixed()
        {
            if (this.elements is HTupleElementsMixed)
                throw new HTupleAccessException();
            this.elements = (HTupleElementsImplementation)this.parent.ConvertToMixed(this.elements.getIndices());
        }

        public static HTuple operator +(HTupleElements e1, int t2)
        {
            return (HTuple)e1 + (HTuple)t2;
        }

        public static HTuple operator +(HTupleElements e1, long t2)
        {
            return (HTuple)e1 + (HTuple)t2;
        }

        public static HTuple operator +(HTupleElements e1, float t2)
        {
            return (HTuple)e1 + (HTuple)((double)t2);
        }

        public static HTuple operator +(HTupleElements e1, double t2)
        {
            return (HTuple)e1 + (HTuple)t2;
        }

        public static HTuple operator +(HTupleElements e1, string t2)
        {
            return (HTuple)e1 + (HTuple)t2;
        }

        public static HTuple operator +(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 + (HTuple)t2;
        }

        public static HTuple operator +(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 + t2;
        }

        public static HTuple operator -(HTupleElements e1, int t2)
        {
            return (HTuple)e1 - (HTuple)t2;
        }

        public static HTuple operator -(HTupleElements e1, long t2)
        {
            return (HTuple)e1 - (HTuple)t2;
        }

        public static HTuple operator -(HTupleElements e1, float t2)
        {
            return (HTuple)e1 - (HTuple)((double)t2);
        }

        public static HTuple operator -(HTupleElements e1, double t2)
        {
            return (HTuple)e1 - (HTuple)t2;
        }

        public static HTuple operator -(HTupleElements e1, string t2)
        {
            return (HTuple)e1 - (HTuple)t2;
        }

        public static HTuple operator -(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 - (HTuple)t2;
        }

        public static HTuple operator -(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 - t2;
        }

        public static HTuple operator *(HTupleElements e1, int t2)
        {
            return (HTuple)e1 * (HTuple)t2;
        }

        public static HTuple operator *(HTupleElements e1, long t2)
        {
            return (HTuple)e1 * (HTuple)t2;
        }

        public static HTuple operator *(HTupleElements e1, float t2)
        {
            return (HTuple)e1 * (HTuple)((double)t2);
        }

        public static HTuple operator *(HTupleElements e1, double t2)
        {
            return (HTuple)e1 * (HTuple)t2;
        }

        public static HTuple operator *(HTupleElements e1, string t2)
        {
            return (HTuple)e1 * (HTuple)t2;
        }

        public static HTuple operator *(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 * (HTuple)t2;
        }

        public static HTuple operator *(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 * t2;
        }

        public static HTuple operator /(HTupleElements e1, int t2)
        {
            return (HTuple)e1 / (HTuple)t2;
        }

        public static HTuple operator /(HTupleElements e1, long t2)
        {
            return (HTuple)e1 / (HTuple)t2;
        }

        public static HTuple operator /(HTupleElements e1, float t2)
        {
            return (HTuple)e1 / (HTuple)((double)t2);
        }

        public static HTuple operator /(HTupleElements e1, double t2)
        {
            return (HTuple)e1 / (HTuple)t2;
        }

        public static HTuple operator /(HTupleElements e1, string t2)
        {
            return (HTuple)e1 / (HTuple)t2;
        }

        public static HTuple operator /(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 / (HTuple)t2;
        }

        public static HTuple operator /(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 / t2;
        }

        public static HTuple operator %(HTupleElements e1, int t2)
        {
            return (HTuple)e1 % (HTuple)t2;
        }

        public static HTuple operator %(HTupleElements e1, long t2)
        {
            return (HTuple)e1 % (HTuple)t2;
        }

        public static HTuple operator %(HTupleElements e1, float t2)
        {
            return (HTuple)e1 % (HTuple)((double)t2);
        }

        public static HTuple operator %(HTupleElements e1, double t2)
        {
            return (HTuple)e1 % (HTuple)t2;
        }

        public static HTuple operator %(HTupleElements e1, string t2)
        {
            return (HTuple)e1 % (HTuple)t2;
        }

        public static HTuple operator %(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 % (HTuple)t2;
        }

        public static HTuple operator %(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 % t2;
        }

        public static HTuple operator &(HTupleElements e1, int t2)
        {
            return (HTuple)e1 & (HTuple)t2;
        }

        public static HTuple operator &(HTupleElements e1, long t2)
        {
            return (HTuple)e1 & (HTuple)t2;
        }

        public static HTuple operator &(HTupleElements e1, float t2)
        {
            return (HTuple)e1 & (HTuple)((double)t2);
        }

        public static HTuple operator &(HTupleElements e1, double t2)
        {
            return (HTuple)e1 & (HTuple)t2;
        }

        public static HTuple operator &(HTupleElements e1, string t2)
        {
            return (HTuple)e1 & (HTuple)t2;
        }

        public static HTuple operator &(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 & (HTuple)t2;
        }

        public static HTuple operator &(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 & t2;
        }

        public static HTuple operator |(HTupleElements e1, int t2)
        {
            return (HTuple)e1 | (HTuple)t2;
        }

        public static HTuple operator |(HTupleElements e1, long t2)
        {
            return (HTuple)e1 | (HTuple)t2;
        }

        public static HTuple operator |(HTupleElements e1, float t2)
        {
            return (HTuple)e1 | (HTuple)((double)t2);
        }

        public static HTuple operator |(HTupleElements e1, double t2)
        {
            return (HTuple)e1 | (HTuple)t2;
        }

        public static HTuple operator |(HTupleElements e1, string t2)
        {
            return (HTuple)e1 | (HTuple)t2;
        }

        public static HTuple operator |(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 | (HTuple)t2;
        }

        public static HTuple operator |(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 | t2;
        }

        public static HTuple operator ^(HTupleElements e1, int t2)
        {
            return (HTuple)e1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTupleElements e1, long t2)
        {
            return (HTuple)e1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTupleElements e1, float t2)
        {
            return (HTuple)e1 ^ (HTuple)((double)t2);
        }

        public static HTuple operator ^(HTupleElements e1, double t2)
        {
            return (HTuple)e1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTupleElements e1, string t2)
        {
            return (HTuple)e1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 ^ t2;
        }

        public static bool operator <(HTupleElements e1, int t2)
        {
            return (HTuple)e1 < (HTuple)t2;
        }

        public static bool operator <(HTupleElements e1, long t2)
        {
            return (HTuple)e1 < (HTuple)t2;
        }

        public static bool operator <(HTupleElements e1, float t2)
        {
            return (HTuple)e1 < (HTuple)((double)t2);
        }

        public static bool operator <(HTupleElements e1, double t2)
        {
            return (HTuple)e1 < (HTuple)t2;
        }

        public static bool operator <(HTupleElements e1, string t2)
        {
            return (HTuple)e1 < (HTuple)t2;
        }

        public static bool operator <(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 < (HTuple)t2;
        }

        public static bool operator <(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 < t2;
        }

        public static bool operator >(HTupleElements e1, int t2)
        {
            return (HTuple)e1 > (HTuple)t2;
        }

        public static bool operator >(HTupleElements e1, long t2)
        {
            return (HTuple)e1 > (HTuple)t2;
        }

        public static bool operator >(HTupleElements e1, float t2)
        {
            return (HTuple)e1 > (HTuple)((double)t2);
        }

        public static bool operator >(HTupleElements e1, double t2)
        {
            return (HTuple)e1 > (HTuple)t2;
        }

        public static bool operator >(HTupleElements e1, string t2)
        {
            return (HTuple)e1 > (HTuple)t2;
        }

        public static bool operator >(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 > (HTuple)t2;
        }

        public static bool operator >(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 > t2;
        }

        public static bool operator <=(HTupleElements e1, int t2)
        {
            return (HTuple)e1 <= (HTuple)t2;
        }

        public static bool operator <=(HTupleElements e1, long t2)
        {
            return (HTuple)e1 <= (HTuple)t2;
        }

        public static bool operator <=(HTupleElements e1, float t2)
        {
            return (HTuple)e1 <= (HTuple)((double)t2);
        }

        public static bool operator <=(HTupleElements e1, double t2)
        {
            return (HTuple)e1 <= (HTuple)t2;
        }

        public static bool operator <=(HTupleElements e1, string t2)
        {
            return (HTuple)e1 <= (HTuple)t2;
        }

        public static bool operator <=(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 <= (HTuple)t2;
        }

        public static bool operator <=(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 <= t2;
        }

        public static bool operator >=(HTupleElements e1, int t2)
        {
            return (HTuple)e1 >= (HTuple)t2;
        }

        public static bool operator >=(HTupleElements e1, long t2)
        {
            return (HTuple)e1 >= (HTuple)t2;
        }

        public static bool operator >=(HTupleElements e1, float t2)
        {
            return (HTuple)e1 >= (HTuple)((double)t2);
        }

        public static bool operator >=(HTupleElements e1, double t2)
        {
            return (HTuple)e1 >= (HTuple)t2;
        }

        public static bool operator >=(HTupleElements e1, string t2)
        {
            return (HTuple)e1 >= (HTuple)t2;
        }

        public static bool operator >=(HTupleElements e1, HTupleElements t2)
        {
            return (HTuple)e1 >= (HTuple)t2;
        }

        public static bool operator >=(HTupleElements e1, HTuple t2)
        {
            return (HTuple)e1 >= t2;
        }

        public static implicit operator bool(HTupleElements hte)
        {
            return hte.I != 0;
        }

        public static implicit operator int(HTupleElements hte)
        {
            return hte.I;
        }

        public static implicit operator long(HTupleElements hte)
        {
            return hte.L;
        }

        public static implicit operator IntPtr(HTupleElements hte)
        {
            return hte.IP;
        }

        public static implicit operator double(HTupleElements hte)
        {
            return hte.D;
        }

        public static implicit operator string(HTupleElements hte)
        {
            return hte.S;
        }

        public static implicit operator HTupleElements(int i)
        {
            return new HTuple(i)[0];
        }

        public static implicit operator HTupleElements(long l)
        {
            return new HTuple(l)[0];
        }

        public static implicit operator HTupleElements(IntPtr ip)
        {
            return new HTuple(ip)[0];
        }

        public static implicit operator HTupleElements(double d)
        {
            return new HTuple(d)[0];
        }

        public static implicit operator HTupleElements(string s)
        {
            return new HTuple(s)[0];
        }
    }
}
