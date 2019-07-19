// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleVector
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>
    ///   The HALCON vector classes are intended to support the export of
    ///   HDevelop code that uses vectors, and to pass vector arguments to
    ///   procedures that use vector parameters. They are not intended to be
    ///   used as generic container classes in user code. For this purpose,
    ///   consider using standard container classes such as List&lt;T&gt;.
    /// </summary>
    public class HTupleVector : HVector
    {
        private HTuple mTuple;

        /// <summary>
        ///   Create empty vector of specified dimension. In case of dimension
        ///   0 a leaf vector for an empty tuple is created
        /// </summary>
        public HTupleVector(int dimension)
          : base(dimension)
        {
            this.mTuple = dimension <= 0 ? new HTuple() : (HTuple)null;
        }

        /// <summary>
        ///   Create leaf vector of dimension 0 for the specified tuple
        /// </summary>
        public HTupleVector(HTuple tuple)
          : base(0)
        {
            if (tuple == null)
                throw new HVectorAccessException("Null tuple not allowed in vector");
            this.mTuple = tuple.Clone();
        }

        /// <summary>
        ///   Create 1-dimensional vector by splitting input tuple into
        ///   blocks of fixed size (except possibly for the last block).
        ///   This corresponds to convert_tuple_to_vector_1d in HDevelop.
        /// </summary>
        public HTupleVector(HTuple tuple, int blockSize)
          : base(1)
        {
            if (blockSize <= 0)
                throw new HVectorAccessException("Invalid block size in vector constructor");
            for (int index = 0; (double)index < Math.Ceiling((double)tuple.Length / (double)blockSize); ++index)
            {
                int num1 = index * blockSize;
                int num2 = Math.Min((index + 1) * blockSize, tuple.Length) - 1;
                this[index] = new HTupleVector(tuple.TupleSelectRange((HTuple)num1, (HTuple)num2));
            }
        }

        /// <summary>Create copy of tuple vector</summary>
        public HTupleVector(HTupleVector vector)
          : base((HVector)vector)
        {
            if (this.mDimension > 0)
                return;
            this.mTuple = vector.mTuple.Clone();
        }

        protected override HVector GetDefaultElement()
        {
            return (HVector)new HTupleVector(this.mDimension - 1);
        }

        /// <summary>
        ///   Access to the tuple value for leaf vectors (dimension 0)
        /// </summary>
        public HTuple T
        {
            get
            {
                this.AssertDimension(0);
                return this.mTuple;
            }
            set
            {
                this.AssertDimension(0);
                if (value == null)
                    throw new HVectorAccessException("Null tuple not allowed in vector");
                this.mTuple = value.Clone();
            }
        }

        /// <summary>
        ///   Access to subvector at specified index. The vector will be
        ///   enlarged to accomodate index, even in read access. The internal
        ///   reference is returned to allow modifications of vector state. For
        ///   read access, preferrably use the member function At(index).
        /// </summary>
        public HTupleVector this[int index]
        {
            get
            {
                return (HTupleVector)base[index];
            }
            set
            {
                this[index] = value;
            }
        }

        /// <summary>
        ///   Read access to subvector at specified index. An exception
        ///   will be raised if index is out of range. The returned data
        ///   is a copy and may be stored safely.
        /// </summary>
        public HTupleVector At(int index)
        {
            return (HTupleVector)base.At(index);
        }

        protected override bool EqualsImpl(HVector vector)
        {
            if (this.mDimension >= 1)
                return base.EqualsImpl(vector);
            return (bool)((HTupleVector)vector).T.TupleEqual(this.T);
        }

        /// <summary>
        ///   Returns true if vector has same dimension, lengths, and elements
        /// </summary>
        public bool VectorEqual(HTupleVector vector)
        {
            return this.EqualsImpl((HVector)vector);
        }

        /// <summary>Concatenate two vectors, creating new vector</summary>
        public HTupleVector Concat(HTupleVector vector)
        {
            return (HTupleVector)this.ConcatImpl((HVector)vector, false, true);
        }

        /// <summary>Append vector to this vector</summary>
        public HTupleVector Append(HTupleVector vector)
        {
            return (HTupleVector)this.ConcatImpl((HVector)vector, true, true);
        }

        /// <summary>Insert vector at specified index</summary>
        public HTupleVector Insert(int index, HTupleVector vector)
        {
            this.InsertImpl(index, (HVector)vector, true);
            return this;
        }

        /// <summary>Remove element at specified index from this vector</summary>
        public HTupleVector Remove(int index)
        {
            this.RemoveImpl(index);
            return this;
        }

        /// <summary>Remove all elements from this vector</summary>
        public HTupleVector Clear()
        {
            this.ClearImpl();
            return this;
        }

        /// <summary>Create an independent copy of this vector</summary>
        public HTupleVector Clone()
        {
            return (HTupleVector)this.CloneImpl();
        }

        protected override HVector CloneImpl()
        {
            return (HVector)new HTupleVector(this);
        }

        /// <summary>Concatenates all tuples stored in the vector</summary>
        public HTuple ConvertVectorToTuple()
        {
            if (this.mDimension <= 0)
                return this.mTuple;
            HTuple htuple = new HTuple();
            for (int index = 0; index < this.Length; ++index)
                htuple.Append(this[index].ConvertVectorToTuple());
            return htuple;
        }

        /// <summary>
        ///   Provides a simple string representation of the vector,
        ///   which is mainly useful for debug outputs.
        /// </summary>
        public override string ToString()
        {
            if (this.mDimension <= 0)
                return this.mTuple.ToString();
            return base.ToString();
        }
    }
}
