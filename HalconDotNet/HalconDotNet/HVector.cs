// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HVector
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HalconDotNet
{
    /// <summary>
    ///   The HALCON vector classes are intended to support the export of
    ///   HDevelop code that uses vectors, and to pass vector arguments to
    ///   procedures that use vector parameters. They are not intended to be
    ///   used as generic container classes in user code. For this purpose,
    ///   consider using standard container classes such as List&lt;T&gt;.
    /// 
    ///   Also note HVector is abstract, you can only create instances
    ///   of HTupleVector or HObjectVector.
    /// </summary>
    public abstract class HVector : ICloneable, IDisposable
    {
        internal int mDimension;
        protected List<HVector> mVector;

        protected HVector(int dimension)
        {
            if (dimension < 0)
                throw new HVectorAccessException("Invalid vector dimension " + (object)dimension);
            this.mDimension = dimension;
            this.mVector = dimension > 0 ? new List<HVector>() : (List<HVector>)null;
        }

        protected HVector(HVector vector)
          : this(vector.Dimension)
        {
            if (this.mDimension <= 0)
                return;
            this.mVector.Capacity = vector.Length;
            for (int index = 0; index < vector.Length; ++index)
                this.mVector.Add(vector[index].Clone());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TransferOwnership(HVector source)
        {
            if (source == this)
                return;
            if (source != null && source.Dimension != this.Dimension)
                throw new HVectorAccessException("Vector dimension mismatch");
            this.Dispose();
            if (source == null)
                return;
            if (this.mDimension <= 0)
                throw new HVectorAccessException("TransferOwnership not implemented for leaf");
            this.mVector = source.mVector;
            source.mVector = new List<HVector>();
            if (!this.IsDisposable())
                return;
            GC.ReRegisterForFinalize((object)this);
        }

        public int Dimension
        {
            get
            {
                return this.mDimension;
            }
        }

        public int Length
        {
            get
            {
                if (this.mDimension <= 0)
                    return 0;
                lock (this.mVector)
                    return this.mVector.Count;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AssertDimension(int dimension)
        {
            if (this.mDimension != dimension)
                throw new HVectorAccessException("Expected vector dimension " + (object)dimension);
        }

        private void AssertSize(int index)
        {
            if (this.mVector == null)
                return;
            lock (this.mVector)
            {
                int count = this.mVector.Count;
                if (index < count)
                    return;
                this.mVector.Capacity = index + 1;
                for (int index1 = count; index1 <= index; ++index1)
                    this.mVector.Add(this.GetDefaultElement());
            }
        }

        protected abstract HVector GetDefaultElement();

        /// <summary>
        ///   Access to subvector at specified index. The vector will be
        ///   enlarged to accomodate index, even in read access. For read
        ///   access without enlargement use the member function At(index).
        ///   A reference to the internal subvector is returned and needs
        ///   to be cloned for independent manipulation.
        /// </summary>
        public HVector this[int index]
        {
            get
            {
                if (this.mDimension < 1 || index < 0)
                    throw new HVectorAccessException("Index out of range");
                this.AssertSize(index);
                lock (this.mVector)
                    return this.mVector[index];
            }
            set
            {
                if (this.mDimension < 1 || index < 0)
                    throw new HVectorAccessException("Index out of range");
                if (value.Dimension != this.mDimension - 1)
                    throw new HVectorAccessException("Vector dimension mismatch");
                this.AssertSize(index);
                HVector hvector;
                lock (this.mVector)
                {
                    hvector = this.mVector[index];
                    this.mVector[index] = value.Clone();
                }
                if (!this.IsDisposable())
                    return;
                hvector.Dispose();
            }
        }

        /// <summary>
        ///   Read access to subvector at specified index. In contrast
        ///   to the index operator, an exception will be raised if index
        ///   is out of range. A reference to the internal subvector is
        ///   returned and needs to be cloned for independent manipulation.
        /// </summary>
        public HVector At(int index)
        {
            if (this.mDimension < 1 || index < 0 || index >= this.Length)
                throw new HVectorAccessException("Index out of range");
            lock (this.mVector)
                return this.mVector[index];
        }

        protected virtual bool EqualsImpl(HVector vector)
        {
            if (vector.Dimension != this.Dimension || vector.Length != this.Length)
                return false;
            if (this.mDimension > 0)
            {
                for (int index = 0; index < this.Length; ++index)
                {
                    if (!this[index].VectorEqual(vector[index]))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        ///   Returns true if vector has same dimension, lengths, and elements
        /// </summary>
        public bool VectorEqual(HVector vector)
        {
            if (vector.GetType() != this.GetType())
                return false;
            return this.EqualsImpl(vector);
        }

        protected HVector ConcatImpl(HVector vector, bool append, bool clone)
        {
            if (this.mDimension < 1 || vector.Dimension != this.mDimension)
                throw new HVectorAccessException("Vector dimension mismatch");
            HVector hvector = append ? this : this.Clone();
            hvector.mVector.Capacity = this.Length + vector.Length;
            for (int index = 0; index < vector.Length; ++index)
                hvector.mVector.Add(clone ? vector[index].Clone() : vector[index]);
            return hvector;
        }

        /// <summary>Concatenate two vectors, creating new vector</summary>
        public HVector Concat(HVector vector)
        {
            return this.ConcatImpl(vector, false, true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVector Concat(HVector vector, bool clone)
        {
            return this.ConcatImpl(vector, false, clone);
        }

        /// <summary>Append vector to this vector</summary>
        public HVector Append(HVector vector)
        {
            return this.ConcatImpl(vector, true, true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVector Append(HVector vector, bool clone)
        {
            return this.ConcatImpl(vector, true, clone);
        }

        protected void InsertImpl(int index, HVector vector, bool clone)
        {
            if (this.mDimension < 1 || vector.Dimension != this.mDimension - 1)
                throw new HVectorAccessException("Vector dimension mismatch");
            if (index < 0)
                throw new HVectorAccessException("Index out of range");
            this.AssertSize(index - 1);
            lock (this.mVector)
                this.mVector.Insert(index, clone ? vector.Clone() : vector);
        }

        /// <summary>Insert vector at specified index</summary>
        public HVector Insert(int index, HVector vector)
        {
            this.InsertImpl(index, vector, true);
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HVector Insert(int index, HVector vector, bool clone)
        {
            this.InsertImpl(index, vector, clone);
            return this;
        }

        protected void RemoveImpl(int index)
        {
            if (this.mDimension < 1)
                throw new HVectorAccessException("Vector dimension mismatch");
            if (index < 0 || index >= this.Length)
                throw new HVectorAccessException("Index out of range");
            lock (this.mVector)
            {
                if (this.IsDisposable())
                    this.mVector[index].Dispose();
                this.mVector.RemoveAt(index);
            }
        }

        /// <summary>Remove element at specified index from this vector</summary>
        public HVector Remove(int index)
        {
            this.RemoveImpl(index);
            return this;
        }

        protected virtual void ClearImpl()
        {
            if (this.mDimension < 1)
                throw new HVectorAccessException("Vector dimension mismatch");
            lock (this.mVector)
            {
                if (this.IsDisposable())
                {
                    for (int index = 0; index < this.Length; ++index)
                        this.mVector[index].Dispose();
                }
                this.mVector.Clear();
            }
        }

        /// <summary>Remove all elements from this vector</summary>
        public HVector Clear()
        {
            this.ClearImpl();
            return this;
        }

        protected abstract HVector CloneImpl();

        object ICloneable.Clone()
        {
            return (object)this.CloneImpl();
        }

        /// <summary>Create an independent copy of this vector</summary>
        public HVector Clone()
        {
            return this.CloneImpl();
        }

        protected virtual bool IsDisposable()
        {
            return false;
        }

        protected virtual void DisposeLeafObject()
        {
        }

        protected void Dispose(bool disposing)
        {
            if (!disposing || !this.IsDisposable())
                return;
            GC.SuppressFinalize((object)this);
            if (this.mDimension > 0)
                this.Clear();
            else
                this.DisposeLeafObject();
        }

        /// <summary>
        ///   Clear vector and dispose elements (if necessary). When called
        ///   on vector with dimension &gt; 0 the effect is identical to clear
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        ///   Provides a simple string representation of the vector,
        ///   which is mainly useful for debug outputs.
        /// </summary>
        public override string ToString()
        {
            if (this.mDimension <= 0)
                return "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            for (int index = 0; index < this.Length; ++index)
            {
                if (index != 0)
                    stringBuilder.Append(", ");
                stringBuilder.Append(this[index].ToString());
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
