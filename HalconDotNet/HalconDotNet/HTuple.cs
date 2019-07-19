using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>
    ///   The class HTuple represents HALCON tuples (control parameter values)
    /// </summary>
    [Serializable]
    public class HTuple : ISerializable, ICloneable
    {
        private static HTuple.NativeInt2To1 addInt = new HTuple.NativeInt2To1(HTuple.NativeIntAdd);
        private static HTuple.NativeLong2To1 addLong = new HTuple.NativeLong2To1(HTuple.NativeLongAdd);
        private static HTuple.NativeDouble2To1 addDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleAdd);
        private static HTuple.NativeInt2To1 subInt = new HTuple.NativeInt2To1(HTuple.NativeIntSub);
        private static HTuple.NativeLong2To1 subLong = new HTuple.NativeLong2To1(HTuple.NativeLongSub);
        private static HTuple.NativeDouble2To1 subDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleSub);
        private static HTuple.NativeInt2To1 multInt = new HTuple.NativeInt2To1(HTuple.NativeIntMult);
        private static HTuple.NativeLong2To1 multLong = new HTuple.NativeLong2To1(HTuple.NativeLongMult);
        private static HTuple.NativeDouble2To1 multDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleMult);
        private static HTuple.NativeInt2To1 concatInt = new HTuple.NativeInt2To1(HTuple.NativeIntConcat);
        private static HTuple.NativeLong2To1 concatLong = new HTuple.NativeLong2To1(HTuple.NativeLongConcat);
        private static HTuple.NativeDouble2To1 concatDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleConcat);
        internal HTupleImplementation data;

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeTuple();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTuple(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue(nameof(data), typeof(byte[])));
            HTuple htuple = HTuple.DeserializeTuple(serializedItemHandle);
            serializedItemHandle.Dispose();
            this.data = htuple.data;
        }

        public void Serialize(Stream stream)
        {
            this.SerializeTuple().Serialize(stream);
        }

        public static HTuple Deserialize(Stream stream)
        {
            return HTuple.DeserializeTuple(HSerializedItem.Deserialize(stream));
        }

        /// <summary>Create an empty tuple</summary>
        public HTuple()
        {
            this.data = (HTupleImplementation)HTupleVoid.EMPTY;
        }

        /// <summary>Create tuple containing integer value 0 (false) or 1 (true)</summary>
        public HTuple(bool b)
          : this(new IntPtr(b ? 1 : 0))
        {
        }

        /// <summary>Create a tuple containing a single 32-bit integer value</summary>
        public HTuple(int i)
        {
            this.data = (HTupleImplementation)new HTupleInt32(i);
        }

        /// <summary>Create a tuple containing 32-bit integer values</summary>
        public HTuple(params int[] i)
        {
            this.data = new HTupleInt32(i, true);
        }

        /// <summary>Create a tuple containing a single 64-bit integer value</summary>
        public HTuple(long l)
        {
            this.data = (HTupleImplementation)new HTupleInt64(l);
        }

        /// <summary>Create a tuple containing 64-bit integer values</summary>
        public HTuple(params long[] l)
        {
            this.data = (HTupleImplementation)new HTupleInt64(l, true);
        }

        /// <summary>
        ///   Create an integer tuple representing a pointer value.
        ///   The used integer size depends on the executing platform.
        /// </summary>
        public HTuple(IntPtr ip)
          : this(new IntPtr[1] { ip })
        {
        }

        /// <summary>
        ///   Create an integer tuple representing pointer values.
        ///   The used integer size depends on the executing platform.
        /// </summary>
        public HTuple(params IntPtr[] ip)
        {
            if (HalconAPI.isPlatform64)
            {
                long[] l = new long[ip.Length];
                for (int index = 0; index < ip.Length; ++index)
                    l[index] = ip[index].ToInt64();
                this.data = (HTupleImplementation)new HTupleInt64(l, false);
            }
            else
            {
                int[] i = new int[ip.Length];
                for (int index = 0; index < ip.Length; ++index)
                    i[index] = ip[index].ToInt32();
                this.data = new HTupleInt32(i, false);
            }
        }

        internal HTuple(int i, bool platformSize)
        {
            if (platformSize && HalconAPI.isPlatform64)
                this.data = (HTupleImplementation)new HTupleInt64((long)i);
            else
                this.data = (HTupleImplementation)new HTupleInt32(i);
        }

        /// <summary>Create a tuple containing a single double value</summary>
        public HTuple(double d)
        {
            this.data = (HTupleImplementation)new HTupleDouble(d);
        }

        /// <summary>Create a tuple containing double values</summary>
        public HTuple(params double[] d)
        {
            this.data = (HTupleImplementation)new HTupleDouble(d, true);
        }

        /// <summary>Create a tuple containing a single double value</summary>
        public HTuple(float f)
        {
            this.data = (HTupleImplementation)new HTupleDouble((double)f);
        }

        /// <summary>Create a tuple containing double values</summary>
        public HTuple(params float[] f)
        {
            this.data = (HTupleImplementation)new HTupleDouble(f);
        }

        /// <summary>Create a tuple containing a single string value</summary>
        public HTuple(string s)
        {
            this.data = (HTupleImplementation)new HTupleString(s);
        }

        /// <summary>Create a tuple containing string values</summary>
        public HTuple(params string[] s)
        {
            this.data = (HTupleImplementation)new HTupleString(s, true);
        }

        internal HTuple(object o)
        {
            this.data = (HTupleImplementation)new HTupleMixed(o);
        }

        /// <summary>
        ///   Create a tuple containing mixed values.
        ///   Only integer, double and string values are valid.
        /// </summary>
        public HTuple(params object[] o)
        {
            this.data = (HTupleImplementation)new HTupleMixed(o, true);
        }

        /// <summary>Create a copy of an existing tuple</summary>
        public HTuple(HTuple t)
        {
            switch (t.Type)
            {
                case HTupleType.INTEGER:
                    this.data = (HTupleImplementation)new HTupleInt32(t.ToIArr(), false);
                    break;
                case HTupleType.DOUBLE:
                    this.data = (HTupleImplementation)new HTupleDouble(t.ToDArr(), false);
                    break;
                case HTupleType.STRING:
                    this.data = (HTupleImplementation)new HTupleString(t.ToSArr(), false);
                    break;
                case HTupleType.MIXED:
                    this.data = (HTupleImplementation)new HTupleMixed(t.ToOArr(), false);
                    break;
                case HTupleType.EMPTY:
                    this.data = (HTupleImplementation)HTupleVoid.EMPTY;
                    break;
                case HTupleType.LONG:
                    this.data = (HTupleImplementation)new HTupleInt64(t.ToLArr(), false);
                    break;
                default:
                    throw new HTupleAccessException("Inconsistent tuple state encountered");
            }
        }

        /// <summary>Create a concatenation of existing tuples</summary>
        public HTuple(params HTuple[] t)
          : this(new HTuple().TupleConcat(t))
        {
        }

        internal HTuple(HTupleImplementation data)
        {
            this.data = data;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TransferOwnership(HTuple source)
        {
            if (object.ReferenceEquals((object)source, (object)this))
                return;
            if (source == null)
            {
                this.data = (HTupleImplementation)HTupleVoid.EMPTY;
            }
            else
            {
                this.data = source.data;
                source.data = (HTupleImplementation)HTupleVoid.EMPTY;
            }
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HTuple Clone()
        {
            return new HTuple(this);
        }

        /// <summary>Get the data type of this tuple</summary>
        public HTupleType Type
        {
            get
            {
                return this.data.Type;
            }
        }

        /// <summary>Get the length of this tuple</summary>
        public int Length
        {
            get
            {
                return this.data.Length;
            }
        }

        /// <summary>
        ///   Unpins the tuple's data. Notice that PinTuple happens in Store(..).
        /// </summary>
        public void UnpinTuple()
        {
            this.data.UnpinTuple();
        }

        /// <summary>
        ///   Provides access to tuple elements at the specified indices
        /// </summary>
        public HTupleElements this[int[] indices]
        {
            get
            {
                foreach (int index in indices)
                {
                    if (index < 0 || index >= this.data.Length)
                        throw new HTupleAccessException("Index out of range");
                }
                return this.data.GetElements(indices, this);
            }
            set
            {
                if (indices.Length == 0)
                {
                    if (value.Length > 1)
                        throw new HTupleAccessException("Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                }
                else
                {
                    foreach (int index in indices)
                    {
                        if (index < 0)
                            throw new HTupleAccessException("Index out of range");
                    }
                    if (this.data.Type == HTupleType.EMPTY)
                    {
                        switch (value.Type)
                        {
                            case HTupleType.INTEGER:
                                this.data = (HTupleImplementation)new HTupleInt32(0);
                                break;
                            case HTupleType.DOUBLE:
                                this.data = (HTupleImplementation)new HTupleDouble(0.0);
                                break;
                            case HTupleType.STRING:
                                this.data = (HTupleImplementation)new HTupleString("");
                                break;
                            case HTupleType.MIXED:
                                this.data = (HTupleImplementation)new HTupleMixed((object)0);
                                break;
                            case HTupleType.LONG:
                                this.data = (HTupleImplementation)new HTupleInt64(0L);
                                break;
                            default:
                                throw new HTupleAccessException("Inconsistent tuple state encountered");
                        }
                    }
                    this.data.AssertSize(indices);
                    if (value.Type != this.data.Type)
                        this.ConvertToMixed();
                    try
                    {
                        this.data.SetElements(indices, value);
                    }
                    catch (HTupleAccessException ex)
                    {
                        this.ConvertToMixed();
                        this.data.SetElements(indices, value);
                    }
                }
            }
        }

        /// <summary>
        ///   Provides access to the tuple element at the specified index
        /// </summary>
        public HTupleElements this[int index]
        {
            get
            {
                if (index < 0 || index >= this.data.Length)
                    throw new HTupleAccessException("Index out of range");
                return this.data.GetElement(index, this);
            }
            set
            {
                if (index < 0)
                    throw new HTupleAccessException("Index out of range");
                if (this.data.Type == HTupleType.EMPTY)
                {
                    switch (value.Type)
                    {
                        case HTupleType.INTEGER:
                            this.data = (HTupleImplementation)new HTupleInt32(0);
                            break;
                        case HTupleType.DOUBLE:
                            this.data = (HTupleImplementation)new HTupleDouble(0.0);
                            break;
                        case HTupleType.STRING:
                            this.data = (HTupleImplementation)new HTupleString("");
                            break;
                        case HTupleType.LONG:
                            this.data = (HTupleImplementation)new HTupleInt64(0L);
                            break;
                        default:
                            throw new HTupleAccessException("Inconsistent tuple state encountered");
                    }
                }
                this.data.AssertSize(index);
                if (value.Type != this.data.Type)
                    this.ConvertToMixed();
                try
                {
                    this.data.SetElements(new int[1] { index }, value);
                }
                catch (HTupleAccessException ex)
                {
                    this.ConvertToMixed();
                    this.data.SetElements(new int[1] { index }, value);
                }
            }
        }

        internal static int[] GetIndicesFromTuple(HTuple indices)
        {
            if (indices.Type == HTupleType.LONG || indices.Type == HTupleType.INTEGER)
                return indices.ToIArr();
            int[] numArray = new int[indices.Length];
            for (int index = 0; index < indices.Length; ++index)
            {
                if (indices[index].Type == HTupleType.INTEGER)
                    numArray[index] = indices[index].I;
                else if (indices[index].Type == HTupleType.LONG)
                {
                    numArray[index] = indices[index].I;
                }
                else
                {
                    if (indices[index].Type != HTupleType.DOUBLE)
                        throw new HTupleAccessException("Invalid index type");
                    double d = indices[index].D;
                    int num = (int)d;
                    if ((double)num != d)
                        throw new HTupleAccessException("Index has fractional part");
                    numArray[index] = num;
                }
            }
            return numArray;
        }

        /// <summary>
        ///   Provides access to the tuple element at the specified index
        /// </summary>
        public HTupleElements this[HTuple indices]
        {
            get
            {
                return this[HTuple.GetIndicesFromTuple(indices)];
            }
            set
            {
                this[HTuple.GetIndicesFromTuple(indices)] = value;
            }
        }

        private void ConvertToMixed()
        {
            if (this.data is HTupleMixed)
                return;
            this.data = (HTupleImplementation)new HTupleMixed(this.data);
        }

        internal HTupleElementsMixed ConvertToMixed(int[] indices)
        {
            this.ConvertToMixed();
            return new HTupleElementsMixed((HTupleMixed)this.data, indices);
        }

        /// <summary>
        ///   Exposes the internal array representation to allow most efficient
        ///   (but not safest) access. Tuple type must be HTupleType.INTEGER.
        ///   The array length may be greater than the used tuple length.
        /// </summary>
        public int[] IArr
        {
            get
            {
                return this.data.IArr;
            }
            set
            {
                if (this.Type == HTupleType.INTEGER)
                    this.data.IArr = value;
                else
                    this.data = (HTupleImplementation)new HTupleInt32(value, false);
            }
        }

        /// <summary>
        ///   Exposes the internal array representation to allow most efficient
        ///   (but not safest) access. Tuple type must be HTupleType.LONG.
        ///   The array length may be greater than the used tuple length.
        /// </summary>
        public long[] LArr
        {
            get
            {
                return this.data.LArr;
            }
            set
            {
                if (this.Type == HTupleType.LONG)
                    this.data.LArr = value;
                else
                    this.data = (HTupleImplementation)new HTupleInt64(value, false);
            }
        }

        /// <summary>
        ///   Exposes the internal array representation to allow most efficient
        ///   (but not safest) access. Tuple type must be HTupleType.DOUBLE.
        ///   The array length may be greater than the used tuple length.
        /// </summary>
        public double[] DArr
        {
            get
            {
                return this.data.DArr;
            }
            set
            {
                if (this.Type == HTupleType.DOUBLE)
                    this.data.DArr = value;
                else
                    this.data = (HTupleImplementation)new HTupleDouble(value, false);
            }
        }

        /// <summary>
        ///   Exposes the internal array representation to allow most efficient
        ///   (but not safest) access. Tuple type must be HTupleType.STRING.
        ///   The array length may be greater than the used tuple length.
        /// </summary>
        public string[] SArr
        {
            get
            {
                return this.data.SArr;
            }
            set
            {
                if (this.Type == HTupleType.STRING)
                    this.data.SArr = value;
                else
                    this.data = (HTupleImplementation)new HTupleString(value, false);
            }
        }

        /// <summary>
        ///   Get the data of this tuple as a 32-bit integer array.
        ///   The tuple may only contain integer data (32-bit or 64-bit).
        /// </summary>
        public int[] ToIArr()
        {
            return this.data.ToIArr();
        }

        /// <summary>
        ///   Get the data of this tuple as a 64-bit integer array.
        ///   The tuple may only contain integer data (32-bit or 64-bit).
        /// </summary>
        public long[] ToLArr()
        {
            return this.data.ToLArr();
        }

        /// <summary>
        ///   Get the data of this tuple as a double array.
        ///   The tuple may only contain numeric data.
        /// </summary>
        public double[] ToDArr()
        {
            return this.data.ToDArr();
        }

        /// <summary>
        ///   Get the data of this tuple as a string array.
        ///   The tuple may only contain string values.
        /// </summary>
        public string[] ToSArr()
        {
            return this.data.ToSArr();
        }

        /// <summary>
        ///   Get the data of this tuple as an object array.
        ///   The tuple may contain arbitrary values.
        /// </summary>
        public object[] ToOArr()
        {
            return this.data.ToOArr();
        }

        /// <summary>
        ///   Get the data of this tuple as a float array.
        ///   The tuple may only contain numeric data.
        /// </summary>
        public float[] ToFArr()
        {
            return this.data.ToFArr();
        }

        /// <summary>
        ///   Get the data of this tuple as an IntPtr array.
        ///   The tuple may only contain integer data matching IntPtr.Size.
        /// </summary>
        public IntPtr[] ToIPArr()
        {
            return this.data.ToIPArr();
        }

        /// <summary>Convenience accessor for tuple[0].I</summary>
        public int I
        {
            get
            {
                return this[0].I;
            }
            set
            {
                this[0].I = value;
            }
        }

        /// <summary>Convenience accessor for tuple[0].L</summary>
        public long L
        {
            get
            {
                return this[0].L;
            }
            set
            {
                this[0].L = value;
            }
        }

        /// <summary>Convenience accessor for tuple[0].D</summary>
        public double D
        {
            get
            {
                return this[0].D;
            }
            set
            {
                this[0].D = value;
            }
        }

        /// <summary>Convenience accessor for tuple[0].S</summary>
        public string S
        {
            get
            {
                return this[0].S;
            }
            set
            {
                this[0].S = value;
            }
        }

        /// <summary>Convenience accessor for tuple[0].O</summary>
        public object O
        {
            get
            {
                return this[0].O;
            }
            set
            {
                this[0].O = value;
            }
        }

        /// <summary>Convenience accessor for tuple[0].IP</summary>
        public IntPtr IP
        {
            get
            {
                return this[0].IP;
            }
            set
            {
                this[0].IP = value;
            }
        }

        public static implicit operator HTupleElements(HTuple t)
        {
            if (t.Length == 1)
                return t[0];
            int[] index1 = new int[t.Length];
            for (int index2 = 0; index2 < t.Length; ++index2)
                index1[index2] = index2;
            return t[index1];
        }

        /// <summary>Convert first element of a tuple to bool</summary>
        public static implicit operator bool(HTuple t)
        {
            return (bool)t[0];
        }

        /// <summary>Convert first element of a tuple to int</summary>
        public static implicit operator int(HTuple t)
        {
            return (int)t[0];
        }

        /// <summary>Convert first element of a tuple to long</summary>
        public static implicit operator long(HTuple t)
        {
            return (long)t[0];
        }

        /// <summary>Convert first element of a tuple to double</summary>
        public static implicit operator double(HTuple t)
        {
            return (double)t[0];
        }

        /// <summary>Convert first element of a tuple to string</summary>
        public static implicit operator string(HTuple t)
        {
            return (string)t[0];
        }

        /// <summary>Convert first element of a tuple to IntPtr</summary>
        public static implicit operator IntPtr(HTuple t)
        {
            return (IntPtr)t[0];
        }

        /// <summary>Convert all elements of a tuple to int[]</summary>
        public static implicit operator int[] (HTuple t)
        {
            return t.ToIArr();
        }

        /// <summary>Convert all elements of a tuple to long[]</summary>
        public static implicit operator long[] (HTuple t)
        {
            return t.ToLArr();
        }

        /// <summary>Convert all elements of a tuple to double[]</summary>
        public static implicit operator double[] (HTuple t)
        {
            return t.ToDArr();
        }

        /// <summary>Convert all elements of a tuple to string[]</summary>
        public static implicit operator string[] (HTuple t)
        {
            return t.ToSArr();
        }

        /// <summary>Convert all elements of a tuple to IntPtr[]</summary>
        public static implicit operator IntPtr[] (HTuple t)
        {
            return t.ToIPArr();
        }

        public static implicit operator HTuple(HTupleElements e)
        {
            switch (e.Type)
            {
                case HTupleType.INTEGER:
                    return new HTuple(e.IArr);
                case HTupleType.DOUBLE:
                    return new HTuple(e.DArr);
                case HTupleType.STRING:
                    return new HTuple(e.SArr);
                case HTupleType.MIXED:
                    return new HTuple(e.OArr);
                case HTupleType.EMPTY:
                    return new HTuple();
                case HTupleType.LONG:
                    return new HTuple(e.LArr);
                default:
                    throw new HTupleAccessException("Inconsistent tuple state encountered");
            }
        }

        public static implicit operator HTuple(int i)
        {
            return new HTuple(i);
        }

        public static implicit operator HTuple(int[] i)
        {
            return new HTuple(i);
        }

        public static implicit operator HTuple(long l)
        {
            return new HTuple(l);
        }

        public static implicit operator HTuple(long[] l)
        {
            return new HTuple(l);
        }

        public static implicit operator HTuple(double d)
        {
            return new HTuple(d);
        }

        public static implicit operator HTuple(double[] d)
        {
            return new HTuple(d);
        }

        public static implicit operator HTuple(string s)
        {
            return new HTuple(s);
        }

        public static implicit operator HTuple(string[] s)
        {
            return new HTuple(s);
        }

        public static implicit operator HTuple(object[] o)
        {
            return new HTuple(o);
        }

        public static implicit operator HTuple(IntPtr ip)
        {
            return new HTuple(ip);
        }

        public static implicit operator HTuple(IntPtr[] ip)
        {
            return new HTuple(ip);
        }

        internal void Store(IntPtr proc, int parIndex)
        {
            this.data.Store(proc, parIndex);
        }

        internal int Load(IntPtr proc, int parIndex, HTupleType type, int err)
        {
            if (!HalconAPI.IsFailure(err))
                return HTupleImplementation.Load(proc, parIndex, type, out this.data);
            this.data = (HTupleImplementation)HTupleVoid.EMPTY;
            return err;
        }

        internal int Load(IntPtr proc, int parIndex, int err)
        {
            return this.Load(proc, parIndex, HTupleType.MIXED, err);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HTuple tuple)
        {
            tuple = new HTuple();
            return tuple.Load(proc, parIndex, type, err);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HTuple tuple)
        {
            tuple = new HTuple();
            return tuple.Load(proc, parIndex, HTupleType.MIXED, err);
        }

        /// <summary>
        ///   Provides a simple string representation of the tuple,
        ///   which is mainly useful for debug outputs.
        /// </summary>
        /// <remarks>
        ///   Casting a HTuple to a string does *not* invoke ToString(), as the
        ///   former represents an implicit access to tuple.S == tuple[0].S, which
        ///   is only legal if the first tuple element is a string.
        /// </remarks>
        public override string ToString()
        {
            object[] oarr = this.ToOArr();
            string str1 = "";
            if (this.Length != 1)
                str1 += "[";
            for (int index = 0; index < oarr.Length; ++index)
            {
                string str2 = str1 + (index > 0 ? ", " : "");
                str1 = this[index].Type != HTupleType.STRING ? str2 + oarr[index].ToString() : str2 + "\"" + oarr[index].ToString() + "\"";
            }
            if (this.Length != 1)
                str1 += "]";
            return str1;
        }

        public static HTuple operator +(HTuple t1, HTuple t2)
        {
            return t1.TupleAdd(t2);
        }

        public static HTuple operator +(HTuple t1, int t2)
        {
            return t1 + (HTuple)t2;
        }

        public static HTuple operator +(HTuple t1, long t2)
        {
            return t1 + (HTuple)t2;
        }

        public static HTuple operator +(HTuple t1, float t2)
        {
            return t1 + (HTuple)((double)t2);
        }

        public static HTuple operator +(HTuple t1, double t2)
        {
            return t1 + (HTuple)t2;
        }

        public static HTuple operator +(HTuple t1, string t2)
        {
            return t1 + (HTuple)t2;
        }

        public static HTuple operator +(HTuple t1, HTupleElements t2)
        {
            return t1 + (HTuple)t2;
        }

        public static HTuple operator -(HTuple t1, HTuple t2)
        {
            return t1.TupleSub(t2);
        }

        public static HTuple operator -(HTuple t1, int t2)
        {
            return t1 - (HTuple)t2;
        }

        public static HTuple operator -(HTuple t1, long t2)
        {
            return t1 - (HTuple)t2;
        }

        public static HTuple operator -(HTuple t1, float t2)
        {
            return t1 - (HTuple)((double)t2);
        }

        public static HTuple operator -(HTuple t1, double t2)
        {
            return t1 - (HTuple)t2;
        }

        public static HTuple operator -(HTuple t1, string t2)
        {
            return t1 - (HTuple)t2;
        }

        public static HTuple operator -(HTuple t1, HTupleElements t2)
        {
            return t1 - (HTuple)t2;
        }

        public static HTuple operator *(HTuple t1, HTuple t2)
        {
            return t1.TupleMult(t2);
        }

        public static HTuple operator *(HTuple t1, int t2)
        {
            return t1 * (HTuple)t2;
        }

        public static HTuple operator *(HTuple t1, long t2)
        {
            return t1 * (HTuple)t2;
        }

        public static HTuple operator *(HTuple t1, float t2)
        {
            return t1 * (HTuple)((double)t2);
        }

        public static HTuple operator *(HTuple t1, double t2)
        {
            return t1 * (HTuple)t2;
        }

        public static HTuple operator *(HTuple t1, string t2)
        {
            return t1 * (HTuple)t2;
        }

        public static HTuple operator *(HTuple t1, HTupleElements t2)
        {
            return t1 * (HTuple)t2;
        }

        public static HTuple operator /(HTuple t1, HTuple t2)
        {
            return t1.TupleDiv(t2);
        }

        public static HTuple operator /(HTuple t1, int t2)
        {
            return t1 / (HTuple)t2;
        }

        public static HTuple operator /(HTuple t1, long t2)
        {
            return t1 / (HTuple)t2;
        }

        public static HTuple operator /(HTuple t1, float t2)
        {
            return t1 / (HTuple)((double)t2);
        }

        public static HTuple operator /(HTuple t1, double t2)
        {
            return t1 / (HTuple)t2;
        }

        public static HTuple operator /(HTuple t1, string t2)
        {
            return t1 / (HTuple)t2;
        }

        public static HTuple operator /(HTuple t1, HTupleElements t2)
        {
            return t1 / (HTuple)t2;
        }

        public static HTuple operator %(HTuple t1, HTuple t2)
        {
            return t1.TupleMod(t2);
        }

        public static HTuple operator %(HTuple t1, int t2)
        {
            return t1 % (HTuple)t2;
        }

        public static HTuple operator %(HTuple t1, long t2)
        {
            return t1 % (HTuple)t2;
        }

        public static HTuple operator %(HTuple t1, float t2)
        {
            return t1 % (HTuple)((double)t2);
        }

        public static HTuple operator %(HTuple t1, double t2)
        {
            return t1 % (HTuple)t2;
        }

        public static HTuple operator %(HTuple t1, string t2)
        {
            return t1 % (HTuple)t2;
        }

        public static HTuple operator %(HTuple t1, HTupleElements t2)
        {
            return t1 % (HTuple)t2;
        }

        public static HTuple operator &(HTuple t1, HTuple t2)
        {
            return t1.TupleAnd(t2);
        }

        public static HTuple operator &(HTuple t1, int t2)
        {
            return t1 & (HTuple)t2;
        }

        public static HTuple operator &(HTuple t1, long t2)
        {
            return t1 & (HTuple)t2;
        }

        public static HTuple operator &(HTuple t1, float t2)
        {
            return t1 & (HTuple)((double)t2);
        }

        public static HTuple operator &(HTuple t1, double t2)
        {
            return t1 & (HTuple)t2;
        }

        public static HTuple operator &(HTuple t1, string t2)
        {
            return t1 & (HTuple)t2;
        }

        public static HTuple operator &(HTuple t1, HTupleElements t2)
        {
            return t1 & (HTuple)t2;
        }

        public static HTuple operator |(HTuple t1, HTuple t2)
        {
            return t1.TupleOr(t2);
        }

        public static HTuple operator |(HTuple t1, int t2)
        {
            return t1 | (HTuple)t2;
        }

        public static HTuple operator |(HTuple t1, long t2)
        {
            return t1 | (HTuple)t2;
        }

        public static HTuple operator |(HTuple t1, float t2)
        {
            return t1 | (HTuple)((double)t2);
        }

        public static HTuple operator |(HTuple t1, double t2)
        {
            return t1 | (HTuple)t2;
        }

        public static HTuple operator |(HTuple t1, string t2)
        {
            return t1 | (HTuple)t2;
        }

        public static HTuple operator |(HTuple t1, HTupleElements t2)
        {
            return t1 | (HTuple)t2;
        }

        public static HTuple operator ^(HTuple t1, HTuple t2)
        {
            return t1.TupleXor(t2);
        }

        public static HTuple operator ^(HTuple t1, int t2)
        {
            return t1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTuple t1, long t2)
        {
            return t1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTuple t1, float t2)
        {
            return t1 ^ (HTuple)((double)t2);
        }

        public static HTuple operator ^(HTuple t1, double t2)
        {
            return t1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTuple t1, string t2)
        {
            return t1 ^ (HTuple)t2;
        }

        public static HTuple operator ^(HTuple t1, HTupleElements t2)
        {
            return t1 ^ (HTuple)t2;
        }

        public static bool operator false(HTuple t)
        {
            return !(bool)t;
        }

        public static bool operator true(HTuple t)
        {
            return (bool)t;
        }

        public static HTuple operator <<(HTuple t1, int shift)
        {
            return t1.TupleLsh((HTuple)shift);
        }

        public static HTuple operator >>(HTuple t1, int shift)
        {
            return t1.TupleRsh((HTuple)shift);
        }

        public static bool operator <(HTuple t1, HTuple t2)
        {
            return (int)t1.TupleLess(t2) != 0;
        }

        public static bool operator <(HTuple t1, int t2)
        {
            return t1 < (HTuple)t2;
        }

        public static bool operator <(HTuple t1, long t2)
        {
            return t1 < (HTuple)t2;
        }

        public static bool operator <(HTuple t1, float t2)
        {
            return t1 < (HTuple)((double)t2);
        }

        public static bool operator <(HTuple t1, double t2)
        {
            return t1 < (HTuple)t2;
        }

        public static bool operator <(HTuple t1, string t2)
        {
            return t1 < (HTuple)t2;
        }

        public static bool operator <(HTuple t1, HTupleElements t2)
        {
            return t1 < (HTuple)t2;
        }

        public static bool operator >(HTuple t1, HTuple t2)
        {
            return (int)t1.TupleGreater(t2) != 0;
        }

        public static bool operator >(HTuple t1, int t2)
        {
            return t1 > (HTuple)t2;
        }

        public static bool operator >(HTuple t1, long t2)
        {
            return t1 > (HTuple)t2;
        }

        public static bool operator >(HTuple t1, float t2)
        {
            return t1 > (HTuple)((double)t2);
        }

        public static bool operator >(HTuple t1, double t2)
        {
            return t1 > (HTuple)t2;
        }

        public static bool operator >(HTuple t1, string t2)
        {
            return t1 > (HTuple)t2;
        }

        public static bool operator >(HTuple t1, HTupleElements t2)
        {
            return t1 > (HTuple)t2;
        }

        public static bool operator >=(HTuple t1, HTuple t2)
        {
            return !(t1 < t2);
        }

        public static bool operator >=(HTuple t1, int t2)
        {
            return t1 >= (HTuple)t2;
        }

        public static bool operator >=(HTuple t1, long t2)
        {
            return t1 >= (HTuple)t2;
        }

        public static bool operator >=(HTuple t1, float t2)
        {
            return t1 >= (HTuple)((double)t2);
        }

        public static bool operator >=(HTuple t1, double t2)
        {
            return t1 >= (HTuple)t2;
        }

        public static bool operator >=(HTuple t1, string t2)
        {
            return t1 >= (HTuple)t2;
        }

        public static bool operator >=(HTuple t1, HTupleElements t2)
        {
            return t1 >= (HTuple)t2;
        }

        public static bool operator <=(HTuple t1, HTuple t2)
        {
            return !(t1 > t2);
        }

        public static bool operator <=(HTuple t1, int t2)
        {
            return t1 <= (HTuple)t2;
        }

        public static bool operator <=(HTuple t1, long t2)
        {
            return t1 <= (HTuple)t2;
        }

        public static bool operator <=(HTuple t1, float t2)
        {
            return t1 <= (HTuple)((double)t2);
        }

        public static bool operator <=(HTuple t1, double t2)
        {
            return t1 <= (HTuple)t2;
        }

        public static bool operator <=(HTuple t1, string t2)
        {
            return t1 <= (HTuple)t2;
        }

        public static bool operator <=(HTuple t1, HTupleElements t2)
        {
            return t1 <= (HTuple)t2;
        }

        public static HTuple operator -(HTuple t)
        {
            return t.TupleNeg();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Continue(HTuple final_value, HTuple increment)
        {
            if (increment[0] < 0.0)
                return this[0].D >= final_value[0].D;
            return this[0].D <= final_value[0].D;
        }

        /// <summary>
        ///   Concatenate multiple tuples to a new one.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="tuples">Further input tuples.</param>
        /// <returns>Concatenation of input tuples.</returns>
        public HTuple TupleConcat(params HTuple[] tuples)
        {
            HTuple htuple = this;
            for (int index = 0; index < tuples.Length; ++index)
                htuple = htuple.TupleConcat(tuples[index]);
            return htuple;
        }

        /// <summary>Append tuple to this tuple</summary>
        /// <param name="tuple">Data to append.</param>
        public void Append(HTuple tuple)
        {
            this.data = this.TupleConcat(tuple).data;
        }

        private bool ProcessNative2To1(
          HTuple t2,
          HTuple.ResultSize type,
          out HTuple result,
          HTuple.NativeInt2To1 opInt,
          HTuple.NativeLong2To1 opLong,
          HTuple.NativeDouble2To1 opDouble)
        {
            int length = type == HTuple.ResultSize.EQUAL ? this.Length : this.Length + t2.Length;
            if (length == 0)
            {
                result = new HTuple();
                return true;
            }
            if (this.Type == t2.Type && (this.Length == t2.Length || type == HTuple.ResultSize.SUM))
            {
                if (this.Type == HTupleType.DOUBLE && opDouble != null)
                {
                    double[] darr1 = this.DArr;
                    double[] darr2 = t2.DArr;
                    double[] numArray = new double[length];
                    numArray[0] = (double)this.Length;
                    opDouble(darr1, darr2, numArray);
                    result = new HTuple((HTupleImplementation)new HTupleDouble(numArray, false));
                    return true;
                }
                if (this.Type == HTupleType.INTEGER && opInt != null)
                {
                    int[] iarr1 = this.IArr;
                    int[] iarr2 = t2.IArr;
                    int[] numArray = new int[length];
                    numArray[0] = this.Length;
                    opInt(iarr1, iarr2, numArray);
                    result = new HTuple((HTupleImplementation)new HTupleInt32(numArray, false));
                    return true;
                }
                if (this.Type == HTupleType.LONG && opLong != null)
                {
                    long[] larr1 = this.LArr;
                    long[] larr2 = t2.LArr;
                    long[] numArray = new long[length];
                    numArray[0] = (long)this.Length;
                    opLong(larr1, larr2, numArray);
                    result = new HTuple((HTupleImplementation)new HTupleInt64(numArray, false));
                    return true;
                }
            }
            result = (HTuple)null;
            return false;
        }

        private static void NativeIntAdd(int[] in1, int[] in2, int[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] + in2[index];
        }

        private static void NativeLongAdd(long[] in1, long[] in2, long[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] + in2[index];
        }

        private static void NativeDoubleAdd(double[] in1, double[] in2, double[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] + in2[index];
        }

        private static void NativeIntSub(int[] in1, int[] in2, int[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] - in2[index];
        }

        private static void NativeLongSub(long[] in1, long[] in2, long[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] - in2[index];
        }

        private static void NativeDoubleSub(double[] in1, double[] in2, double[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] - in2[index];
        }

        private static void NativeIntMult(int[] in1, int[] in2, int[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] * in2[index];
        }

        private static void NativeLongMult(long[] in1, long[] in2, long[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] * in2[index];
        }

        private static void NativeDoubleMult(double[] in1, double[] in2, double[] buffer)
        {
            for (int index = 0; index < buffer.Length; ++index)
                buffer[index] = in1[index] * in2[index];
        }

        private static void NativeIntConcat(int[] in1, int[] in2, int[] buffer)
        {
            int num = buffer[0];
            int length = buffer.Length - num;
            Array.Copy((Array)in1, 0, (Array)buffer, 0, num);
            Array.Copy((Array)in2, 0, (Array)buffer, num, length);
        }

        private static void NativeLongConcat(long[] in1, long[] in2, long[] buffer)
        {
            int num = (int)buffer[0];
            int length = buffer.Length - num;
            Array.Copy((Array)in1, 0, (Array)buffer, 0, num);
            Array.Copy((Array)in2, 0, (Array)buffer, num, length);
        }

        private static void NativeDoubleConcat(double[] in1, double[] in2, double[] buffer)
        {
            int num = (int)buffer[0];
            int length = buffer.Length - num;
            Array.Copy((Array)in1, 0, (Array)buffer, 0, num);
            Array.Copy((Array)in2, 0, (Array)buffer, num, length);
        }

        /// <summary>
        ///   Returns the number of elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Number of elements of input tuple.</returns>
        public int TupleLength()
        {
            return this.Length;
        }

        /// <summary>
        ///   Add two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="s2">Input tuple 2.</param>
        /// <returns>Sum of the input tuples.</returns>
        public HTuple TupleAdd(HTuple s2)
        {
            HTuple result;
            if (!this.ProcessNative2To1(s2, HTuple.ResultSize.EQUAL, out result, HTuple.addInt, HTuple.addLong, HTuple.addDouble))
                result = this.TupleAddOp(s2);
            return result;
        }

        /// <summary>
        ///   Subtract two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="d2">Input tuple 2.</param>
        /// <returns>Difference of the input tuples.</returns>
        public HTuple TupleSub(HTuple d2)
        {
            HTuple result;
            if (!this.ProcessNative2To1(d2, HTuple.ResultSize.EQUAL, out result, HTuple.subInt, HTuple.subLong, HTuple.subDouble))
                result = this.TupleSubOp(d2);
            return result;
        }

        /// <summary>
        ///   Multiply two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="p2">Input tuple 2.</param>
        /// <returns>Product of the input tuples.</returns>
        public HTuple TupleMult(HTuple p2)
        {
            HTuple result;
            if (!this.ProcessNative2To1(p2, HTuple.ResultSize.EQUAL, out result, HTuple.multInt, HTuple.multLong, HTuple.multDouble))
                result = this.TupleMultOp(p2);
            return result;
        }

        /// <summary>
        ///   Concatenate two tuple to a new one.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Concatentaion of input tuples.</returns>
        public HTuple TupleConcat(HTuple t2)
        {
            HTuple result;
            if (!this.ProcessNative2To1(t2, HTuple.ResultSize.SUM, out result, HTuple.concatInt, HTuple.concatLong, HTuple.concatDouble))
                result = this.TupleConcatOp(t2);
            return result;
        }

        /// <summary>
        ///   Compute the union set of two input tuples.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="set2">Input tuple.</param>
        /// <returns>The union set of two input tuples.</returns>
        public HTuple TupleUnion(HTuple set2)
        {
            IntPtr proc = HalconAPI.PreCall(96);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, set2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(set2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the intersection set of two input tuples.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="set2">Input tuple.</param>
        /// <returns>The intersection set of two input tuples.</returns>
        public HTuple TupleIntersection(HTuple set2)
        {
            IntPtr proc = HalconAPI.PreCall(97);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, set2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(set2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the difference set of two input tuples.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="set2">Input tuple.</param>
        /// <returns>The difference set of two input tuples.</returns>
        public HTuple TupleDifference(HTuple set2)
        {
            IntPtr proc = HalconAPI.PreCall(98);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, set2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(set2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the symmetric difference set of two input tuples.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="set2">Input tuple.</param>
        /// <returns>The symmetric difference set of two input tuples.</returns>
        public HTuple TupleSymmdiff(HTuple set2)
        {
            IntPtr proc = HalconAPI.PreCall(99);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, set2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(set2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether the types of the elements of a tuple are of type string.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Are the elements of the input tuple of type string?</returns>
        public HTuple TupleIsStringElem()
        {
            IntPtr proc = HalconAPI.PreCall(100);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether the types of the elements of a tuple are of type real.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Are the elements of the input tuple of type real?</returns>
        public HTuple TupleIsRealElem()
        {
            IntPtr proc = HalconAPI.PreCall(101);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether the types of the elements of a tuple are of type integer.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Are the elements of the input tuple of type integer?</returns>
        public HTuple TupleIsIntElem()
        {
            IntPtr proc = HalconAPI.PreCall(102);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the types of the elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Types of the elements of the input tuple as integer values.</returns>
        public HTuple TupleTypeElem()
        {
            IntPtr proc = HalconAPI.PreCall(103);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is of type mixed.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Is the input tuple of type mixed?</returns>
        public HTuple TupleIsMixed()
        {
            IntPtr proc = HalconAPI.PreCall(104);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is of type string.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Is the input tuple of type string?</returns>
        public HTuple TupleIsString()
        {
            IntPtr proc = HalconAPI.PreCall(105);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether the types of the elements of a tuple are of type real.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Is the input tuple of type real?</returns>
        public HTuple TupleIsReal()
        {
            IntPtr proc = HalconAPI.PreCall(106);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is of type integer.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Is the input tuple of type integer?</returns>
        public HTuple TupleIsInt()
        {
            IntPtr proc = HalconAPI.PreCall(107);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the type of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Type of the input tuple as an integer number.</returns>
        public HTuple TupleType()
        {
            IntPtr proc = HalconAPI.PreCall(108);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the value distribution of a tuple within a certain value range.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="numBins">Number of bins.</param>
        /// <param name="binSize">Bin size.</param>
        /// <returns>Histogram to be calculated.</returns>
        public HTuple TupleHistoRange(
          HTuple min,
          HTuple max,
          HTuple numBins,
          out HTuple binSize)
        {
            IntPtr proc = HalconAPI.PreCall(109);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, min);
            HalconAPI.Store(proc, 2, max);
            HalconAPI.Store(proc, 3, numBins);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HalconAPI.UnpinTuple(numBins);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out binSize);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select tuple elements matching a regular expression.
        ///   Instance represents: Input strings to match.
        /// </summary>
        /// <param name="expression">Regular expression. Default: ".*"</param>
        /// <returns>Matching strings</returns>
        public HTuple TupleRegexpSelect(HTuple expression)
        {
            IntPtr proc = HalconAPI.PreCall(110);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, expression);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(expression);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test if a string matches a regular expression.
        ///   Instance represents: Input strings to match.
        /// </summary>
        /// <param name="expression">Regular expression. Default: ".*"</param>
        /// <returns>Number of matching strings</returns>
        public HTuple TupleRegexpTest(HTuple expression)
        {
            IntPtr proc = HalconAPI.PreCall(111);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, expression);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(expression);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Replace a substring using regular expressions.
        ///   Instance represents: Input strings to process.
        /// </summary>
        /// <param name="expression">Regular expression. Default: ".*"</param>
        /// <param name="replace">Replacement expression.</param>
        /// <returns>Processed strings.</returns>
        public HTuple TupleRegexpReplace(HTuple expression, HTuple replace)
        {
            IntPtr proc = HalconAPI.PreCall(112);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, expression);
            HalconAPI.Store(proc, 2, replace);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(expression);
            HalconAPI.UnpinTuple(replace);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Extract substrings using regular expressions.
        ///   Instance represents: Input strings to match.
        /// </summary>
        /// <param name="expression">Regular expression. Default: ".*"</param>
        /// <returns>Found matches.</returns>
        public HTuple TupleRegexpMatch(HTuple expression)
        {
            IntPtr proc = HalconAPI.PreCall(113);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, expression);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(expression);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Return a tuple of random numbers between 0 and 1.</summary>
        /// <param name="length">Length of tuple to generate.</param>
        /// <returns>Tuple of random numbers.</returns>
        public static HTuple TupleRand(HTuple length)
        {
            IntPtr proc = HalconAPI.PreCall(114);
            HalconAPI.Store(proc, 0, length);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(length);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>
        ///   Calculate the sign of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Signs of the input tuple as integer numbers.</returns>
        public HTuple TupleSgn()
        {
            IntPtr proc = HalconAPI.PreCall(116);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the elementwise maximum of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Elementwise maximum of the input tuples.</returns>
        public HTuple TupleMax2(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(117);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the elementwise minimum of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Elementwise minimum of the input tuples.</returns>
        public HTuple TupleMin2(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(118);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the maximal element of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Maximal element of the input tuple elements.</returns>
        public HTuple TupleMax()
        {
            IntPtr proc = HalconAPI.PreCall(119);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the minimal element of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Minimal element of the input tuple elements.</returns>
        public HTuple TupleMin()
        {
            IntPtr proc = HalconAPI.PreCall(120);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the cumulative sums of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Cumulative sum of the corresponding tuple elements.</returns>
        public HTuple TupleCumul()
        {
            IntPtr proc = HalconAPI.PreCall(121);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select the element of rank n of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="rankIndex">Rank of the element to select.</param>
        /// <returns>Selected tuple element.</returns>
        public HTuple TupleSelectRank(HTuple rankIndex)
        {
            IntPtr proc = HalconAPI.PreCall(122);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, rankIndex);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rankIndex);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the median of the elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Median of the tuple elements.</returns>
        public HTuple TupleMedian()
        {
            IntPtr proc = HalconAPI.PreCall(123);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the sum of all elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Sum of tuple elements.</returns>
        public HTuple TupleSum()
        {
            IntPtr proc = HalconAPI.PreCall(124);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the mean value of a tuple of numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Mean value of tuple elements.</returns>
        public HTuple TupleMean()
        {
            IntPtr proc = HalconAPI.PreCall(125);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the standard deviation of the elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Standard deviation of tuple elements.</returns>
        public HTuple TupleDeviation()
        {
            IntPtr proc = HalconAPI.PreCall(126);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Discard all but one of successive identical elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Tuple without successive identical elements.</returns>
        public HTuple TupleUniq()
        {
            IntPtr proc = HalconAPI.PreCall((int)sbyte.MaxValue);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the index of the last occurence of a tuple within another tuple.
        ///   Instance represents: Input tuple to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with values to find.</param>
        /// <returns>Index of the last occurrence of the values to find.</returns>
        public HTuple TupleFindLast(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(128);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the index of the first occurrence of a tuple within another tuple.
        ///   Instance represents: Input tuple to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with values to find.</param>
        /// <returns>Index of the first occurrence of the values to find.</returns>
        public HTuple TupleFindFirst(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(129);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the indices of all occurrences of a tuple within another tuple.
        ///   Instance represents: Input tuple to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with values to find.</param>
        /// <returns>Indices of the occurrences of the values to find in the  tuple to examine.</returns>
        public HTuple TupleFind(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(130);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Sort the elements of a tuple and return the indices of the sorted tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Sorted tuple.</returns>
        public HTuple TupleSortIndex()
        {
            IntPtr proc = HalconAPI.PreCall(131);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Sort the elements of a tuple in ascending order.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Sorted tuple.</returns>
        public HTuple TupleSort()
        {
            IntPtr proc = HalconAPI.PreCall(132);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Invert a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Inverted input tuple.</returns>
        public HTuple TupleInverse()
        {
            IntPtr proc = HalconAPI.PreCall(133);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Concatenate two tuples to a new one.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Concatenation of input tuples.</returns>
        private HTuple TupleConcatOp(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(134);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select several elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="leftindex">Index of first element to select.</param>
        /// <param name="rightindex">Index of last element to select.</param>
        /// <returns>Selected tuple elements.</returns>
        public HTuple TupleSelectRange(HTuple leftindex, HTuple rightindex)
        {
            IntPtr proc = HalconAPI.PreCall(135);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, leftindex);
            HalconAPI.Store(proc, 2, rightindex);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(leftindex);
            HalconAPI.UnpinTuple(rightindex);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select all elements from index "n" to the end of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Index of the first element to select.</param>
        /// <returns>Selected tuple elements.</returns>
        public HTuple TupleLastN(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(136);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select the first elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Index of the last element to select.</param>
        /// <returns>Selected tuple elements.</returns>
        public HTuple TupleFirstN(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(137);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Inserts one or more elements into a tuple at index.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Start index of elements to be inserted.</param>
        /// <param name="insertTuple">Element(s) to insert at index.</param>
        /// <returns>Tuple with inserted elements.</returns>
        public HTuple TupleInsert(HTuple index, HTuple insertTuple)
        {
            IntPtr proc = HalconAPI.PreCall(138);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, insertTuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(insertTuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Replaces one or more elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <param name="replaceTuple">Element(s) to replace.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HTuple TupleReplace(HTuple index, HTuple replaceTuple)
        {
            IntPtr proc = HalconAPI.PreCall(139);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, replaceTuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(replaceTuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Remove elements from a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Indices of the elements to remove.</param>
        /// <returns>Reduced tuple.</returns>
        public HTuple TupleRemove(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(140);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select in mask specified elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="mask"> greater than  0 specifies the elements to select.</param>
        /// <returns>Selected tuple elements.</returns>
        public HTuple TupleSelectMask(HTuple mask)
        {
            IntPtr proc = HalconAPI.PreCall(141);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, mask);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(mask);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select single elements of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Indices of the elements to select.</param>
        /// <returns>Selected tuple element.</returns>
        public HTuple TupleSelect(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(142);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Select single character or bit from a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="index">Position of character or bit to select.</param>
        /// <returns>Tuple containing the selected characters and bits.</returns>
        public HTuple TupleStrBitSelect(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(143);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Generate a tuple with a sequence of equidistant values.</summary>
        /// <param name="start">Start value of the tuple.</param>
        /// <param name="end">Maximum value for the last entry.</param>
        /// <param name="step">Increment value.</param>
        /// <returns>The resulting sequence.</returns>
        public static HTuple TupleGenSequence(HTuple start, HTuple end, HTuple step)
        {
            IntPtr proc = HalconAPI.PreCall(144);
            HalconAPI.Store(proc, 0, start);
            HalconAPI.Store(proc, 1, end);
            HalconAPI.Store(proc, 2, step);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(start);
            HalconAPI.UnpinTuple(end);
            HalconAPI.UnpinTuple(step);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Generate a tuple of a specific length and initialize its elements.</summary>
        /// <param name="length">Length of tuple to generate.</param>
        /// <param name="constVal">Constant for initializing the tuple elements.</param>
        /// <returns>New Tuple.</returns>
        public static HTuple TupleGenConst(HTuple length, HTuple constVal)
        {
            IntPtr proc = HalconAPI.PreCall(145);
            HalconAPI.Store(proc, 0, length);
            HalconAPI.Store(proc, 1, constVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(length);
            HalconAPI.UnpinTuple(constVal);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>
        ///   Read one or more environment variables.
        ///   Instance represents: Tuple containing name(s) of the environment variable(s).
        /// </summary>
        /// <returns>Content of the environment variable(s).</returns>
        public HTuple TupleEnvironment()
        {
            IntPtr proc = HalconAPI.PreCall(146);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Split strings into substrings between predefined separator symbol(s).
        ///   Instance represents: Input tuple with string(s) to split.
        /// </summary>
        /// <param name="separator">Input tuple with separator symbol(s).</param>
        /// <returns>Substrings after splitting the input strings.</returns>
        public HTuple TupleSplit(HTuple separator)
        {
            IntPtr proc = HalconAPI.PreCall(147);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, separator);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(separator);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Cut characters from position "n1" through "n2" out of a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="position1">Input tuple with start position(s) "n1".</param>
        /// <param name="position2">Input tuple with end position(s) "n2".</param>
        /// <returns>Characters of the string(s) from position "n1" to "n2".</returns>
        public HTuple TupleSubstr(HTuple position1, HTuple position2)
        {
            IntPtr proc = HalconAPI.PreCall(148);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, position1);
            HalconAPI.Store(proc, 2, position2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(position1);
            HalconAPI.UnpinTuple(position2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Cut all characters starting at position "n" out of a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="position">Input tuple with position(s) "n".</param>
        /// <returns>The last characters of the string(s) starting at position "n".</returns>
        public HTuple TupleStrLastN(HTuple position)
        {
            IntPtr proc = HalconAPI.PreCall(149);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, position);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(position);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Cut the first characters up to position "n" out of a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="position">Input tuple with position(s) "n".</param>
        /// <returns>The first characters of the string(s) up to position "n".</returns>
        public HTuple TupleStrFirstN(HTuple position)
        {
            IntPtr proc = HalconAPI.PreCall(150);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, position);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(position);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Backward search for characters within a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with character(s) to search.</param>
        /// <returns>Position of searched character(s) within the string(s).</returns>
        public HTuple TupleStrrchr(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(151);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Forward search for characters within a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with character(s) to search.</param>
        /// <returns>Position of searched character(s) within the string(s).</returns>
        public HTuple TupleStrchr(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(152);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Backward search for strings within a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with string(s) to search.</param>
        /// <returns>Position of searched string(s) within the examined string(s).</returns>
        public HTuple TupleStrrstr(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(153);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Forward search for strings within a string tuple.
        ///   Instance represents: Input tuple with string(s) to examine.
        /// </summary>
        /// <param name="toFind">Input tuple with string(s) to search.</param>
        /// <returns>Position of searched string(s) within the examined string(s).</returns>
        public HTuple TupleStrstr(HTuple toFind)
        {
            IntPtr proc = HalconAPI.PreCall(154);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, toFind);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(toFind);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Determine the length of every string within a tuple of strings.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Lengths of the single strings of the input tuple.</returns>
        public HTuple TupleStrlen()
        {
            IntPtr proc = HalconAPI.PreCall(155);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether a tuple is elementwise less or equal to another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleLessEqualElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(156);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether a tuple is elementwise less than another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleLessElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(157);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether a tuple is elementwise greater or equal to another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleGreaterEqualElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(158);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether a tuple is elementwise greater than another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleGreaterElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(159);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether two tuples are elementwise not equal.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleNotEqualElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(160);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test, whether two tuples are elementwise equal.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleEqualElem(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(161);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is less or equal to another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleLessEqual(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(162);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is less than another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleLess(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(163);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is greater or equal to another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleGreaterEqual(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(164);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether a tuple is greater than another tuple.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleGreater(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(165);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether two tuples are not equal.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleNotEqual(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(166);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Test whether two tuples are equal.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Result of the comparison of the input tuples.</returns>
        public HTuple TupleEqual(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(167);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the logical not of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Binary not of the input tuple.</returns>
        public HTuple TupleNot()
        {
            IntPtr proc = HalconAPI.PreCall(168);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the logical exclusive or of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Binary exclusive or of the input tuples.</returns>
        public HTuple TupleXor(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(169);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the logical or of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Logical or of the input tuples.</returns>
        public HTuple TupleOr(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(170);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the logical and of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Logical and of the input tuples.</returns>
        public HTuple TupleAnd(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(171);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the bitwise not of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Binary not of the input tuple.</returns>
        public HTuple TupleBnot()
        {
            IntPtr proc = HalconAPI.PreCall(172);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the bitwise exclusive or of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Binary exclusive or of the input tuples.</returns>
        public HTuple TupleBxor(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(173);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the bitwise or of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Binary or of the input tuples.</returns>
        public HTuple TupleBor(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(174);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the bitwise and of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Binary and of the input tuples.</returns>
        public HTuple TupleBand(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(175);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shift a tuple bitwise to the right.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="shift">Number of places to shift the input tuple.</param>
        /// <returns>Shifted input tuple.</returns>
        public HTuple TupleRsh(HTuple shift)
        {
            IntPtr proc = HalconAPI.PreCall(176);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, shift);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(shift);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shift a tuple bitwise to the left.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="shift">Number of places to shift the input tuple.</param>
        /// <returns>Shifted input tuple.</returns>
        public HTuple TupleLsh(HTuple shift)
        {
            IntPtr proc = HalconAPI.PreCall(177);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, shift);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(shift);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple of integers into strings with the corresponding ASCII codes.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Strings corresponding to the ASCII code of the input tuple.</returns>
        public HTuple TupleChrt()
        {
            IntPtr proc = HalconAPI.PreCall(178);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple of strings into a tuple of their ASCII codes.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>ASCII code of the input tuple.</returns>
        public HTuple TupleOrds()
        {
            IntPtr proc = HalconAPI.PreCall(179);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple of integers into strings with the corresponding ASCII codes.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Strings corresponding to the ASCII code of the input tuple.</returns>
        public HTuple TupleChr()
        {
            IntPtr proc = HalconAPI.PreCall(180);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple of strings of length 1 into a tuple of their ASCII codes.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>ASCII code of the input tuple.</returns>
        public HTuple TupleOrd()
        {
            IntPtr proc = HalconAPI.PreCall(181);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple into a tuple of strings.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <returns>Input tuple converted to strings.</returns>
        public HTuple TupleString(HTuple format)
        {
            IntPtr proc = HalconAPI.PreCall(182);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, format);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(format);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Check a tuple (of strings) whether it represents numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Tuple with boolean numbers.</returns>
        public HTuple TupleIsNumber()
        {
            IntPtr proc = HalconAPI.PreCall(183);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple (of strings) into a tuple of numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Input tuple as numbers.</returns>
        public HTuple TupleNumber()
        {
            IntPtr proc = HalconAPI.PreCall(184);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple into a tuple of integer numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Result of the rounding.</returns>
        public HTuple TupleRound()
        {
            IntPtr proc = HalconAPI.PreCall(185);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple into a tuple of integer numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Result of the conversion into integer numbers.</returns>
        public HTuple TupleInt()
        {
            IntPtr proc = HalconAPI.PreCall(186);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple into a tuple of floating point numbers.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Input tuple as floating point numbers.</returns>
        public HTuple TupleReal()
        {
            IntPtr proc = HalconAPI.PreCall(187);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the ldexp function of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Ldexp function of the input tuples.</returns>
        public HTuple TupleLdexp(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(188);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the remainder of the floating point division of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Remainder of the division of the input tuples.</returns>
        public HTuple TupleFmod(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(189);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the remainder of the integer division of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Remainder of the division of the input tuples.</returns>
        public HTuple TupleMod(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(190);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the ceiling function of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Ceiling function of the input tuple.</returns>
        public HTuple TupleCeil()
        {
            IntPtr proc = HalconAPI.PreCall(191);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the floor function of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Floor function of the input tuple.</returns>
        public HTuple TupleFloor()
        {
            IntPtr proc = HalconAPI.PreCall(192);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the power function of two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="t2">Input tuple 2.</param>
        /// <returns>Power function of the input tuples.</returns>
        public HTuple TuplePow(HTuple t2)
        {
            IntPtr proc = HalconAPI.PreCall(193);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, t2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(t2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the base 10 logarithm of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Base 10 logarithm of the input tuple.</returns>
        public HTuple TupleLog10()
        {
            IntPtr proc = HalconAPI.PreCall(194);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the natural logarithm of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Natural logarithm of the input tuple.</returns>
        public HTuple TupleLog()
        {
            IntPtr proc = HalconAPI.PreCall(195);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the exponential of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Exponential of the input tuple.</returns>
        public HTuple TupleExp()
        {
            IntPtr proc = HalconAPI.PreCall(196);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the hyperbolic tangent of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Hyperbolic tangent of the input tuple.</returns>
        public HTuple TupleTanh()
        {
            IntPtr proc = HalconAPI.PreCall(197);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the hyperbolic cosine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Hyperbolic cosine of the input tuple.</returns>
        public HTuple TupleCosh()
        {
            IntPtr proc = HalconAPI.PreCall(198);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the hyperbolic sine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Hyperbolic sine of the input tuple.</returns>
        public HTuple TupleSinh()
        {
            IntPtr proc = HalconAPI.PreCall(199);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple from degrees to radians.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Input tuple in radians.</returns>
        public HTuple TupleRad()
        {
            IntPtr proc = HalconAPI.PreCall(200);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Convert a tuple from radians to degrees.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Input tuple in degrees.</returns>
        public HTuple TupleDeg()
        {
            IntPtr proc = HalconAPI.PreCall(201);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the arctangent of a tuple for all four quadrants.
        ///   Instance represents: Input tuple of the y-values.
        /// </summary>
        /// <param name="x">Input tuple of the x-values.</param>
        /// <returns>Arctangent of the input tuple.</returns>
        public HTuple TupleAtan2(HTuple x)
        {
            IntPtr proc = HalconAPI.PreCall(202);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, x);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(x);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the arctangent of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Arctangent of the input tuple.</returns>
        public HTuple TupleAtan()
        {
            IntPtr proc = HalconAPI.PreCall(203);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the arccosine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Arccosine of the input tuple.</returns>
        public HTuple TupleAcos()
        {
            IntPtr proc = HalconAPI.PreCall(204);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the arcsine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Arcsine of the input tuple.</returns>
        public HTuple TupleAsin()
        {
            IntPtr proc = HalconAPI.PreCall(205);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the tangent of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Tangent of the input tuple.</returns>
        public HTuple TupleTan()
        {
            IntPtr proc = HalconAPI.PreCall(206);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the cosine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Cosine of the input tuple.</returns>
        public HTuple TupleCos()
        {
            IntPtr proc = HalconAPI.PreCall(207);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the sine of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Sine of the input tuple.</returns>
        public HTuple TupleSin()
        {
            IntPtr proc = HalconAPI.PreCall(208);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the absolute value of a tuple (as floating point numbers).
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Absolute value of the input tuple.</returns>
        public HTuple TupleFabs()
        {
            IntPtr proc = HalconAPI.PreCall(209);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the square root of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Square root of the input tuple.</returns>
        public HTuple TupleSqrt()
        {
            IntPtr proc = HalconAPI.PreCall(210);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the absolute value of a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Absolute value of the input tuple.</returns>
        public HTuple TupleAbs()
        {
            IntPtr proc = HalconAPI.PreCall(211);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Negate a tuple.
        ///   Instance represents: Input tuple.
        /// </summary>
        /// <returns>Negation of the input tuple.</returns>
        public HTuple TupleNeg()
        {
            IntPtr proc = HalconAPI.PreCall(212);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Divide two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="q2">Input tuple 2.</param>
        /// <returns>Quotient of the input tuples.</returns>
        public HTuple TupleDiv(HTuple q2)
        {
            IntPtr proc = HalconAPI.PreCall(213);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, q2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(q2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Multiply two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="p2">Input tuple 2.</param>
        /// <returns>Product of the input tuples.</returns>
        private HTuple TupleMultOp(HTuple p2)
        {
            IntPtr proc = HalconAPI.PreCall(214);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, p2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(p2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Subtract two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="d2">Input tuple 2.</param>
        /// <returns>Difference of the input tuples.</returns>
        private HTuple TupleSubOp(HTuple d2)
        {
            IntPtr proc = HalconAPI.PreCall(215);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, d2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(d2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Add two tuples.
        ///   Instance represents: Input tuple 1.
        /// </summary>
        /// <param name="s2">Input tuple 2.</param>
        /// <returns>Sum of the input tuples.</returns>
        private HTuple TupleAddOp(HTuple s2)
        {
            IntPtr proc = HalconAPI.PreCall(216);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, s2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(s2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Deserialize a serialized tuple.</summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        /// <returns>Tuple.</returns>
        public static HTuple DeserializeTuple(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(217);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)serializedItemHandle);
            return tuple;
        }

        /// <summary>
        ///   Serialize a tuple.
        ///   Instance represents: Tuple.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeTuple()
        {
            IntPtr proc = HalconAPI.PreCall(218);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Write a tuple to a file.
        ///   Instance represents: Tuple with any kind of data.
        /// </summary>
        /// <param name="fileName">Name of the file to be written.</param>
        public void WriteTuple(HTuple fileName)
        {
            IntPtr proc = HalconAPI.PreCall(219);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(fileName);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Read a tuple from a file.</summary>
        /// <param name="fileName">Name of the file to be read.</param>
        /// <returns>Tuple with any kind of data.</returns>
        public static HTuple ReadTuple(HTuple fileName)
        {
            IntPtr proc = HalconAPI.PreCall(220);
            HalconAPI.Store(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(fileName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        private delegate void NativeInt2To1(int[] in1, int[] in2, int[] buffer);

        private delegate void NativeLong2To1(long[] in1, long[] in2, long[] buffer);

        private delegate void NativeDouble2To1(double[] in1, double[] in2, double[] buffer);

        private enum ResultSize
        {
            EQUAL,
            SUM,
        }
    }
}
