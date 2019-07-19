// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HObjectVector
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>
    ///   The HALCON vector classes are intended to support the export of
    ///   HDevelop code that uses vectors, and to pass vector arguments to
    ///   procedures that use vector parameters. They are not intended to be
    ///   used as generic container classes in user code. For this purpose,
    ///   consider using standard container classes such as List&lt;T&gt;.
    /// </summary>
    public class HObjectVector : HVector
    {
        private HObject mObject;

        /// <summary>
        ///   Create empty vector of specified dimension. In case of dimension
        ///   0 a leaf vector for an empty object is created
        /// </summary>
        public HObjectVector(int dimension)
          : base(dimension)
        {
            this.mObject = dimension <= 0 ? HObjectVector.GenEmptyObj() : (HObject)null;
        }

        /// <summary>
        ///   Create leaf vector of dimension 0 for the specified object
        /// </summary>
        public HObjectVector(HObject obj)
          : base(0)
        {
            if (obj == null || !obj.IsInitialized())
                throw new HVectorAccessException("Uninitialized object not allowed in vector");
            this.mObject = obj.CopyObj(1, -1);
        }

        /// <summary>Create copy of object vector</summary>
        public HObjectVector(HObjectVector vector)
          : base((HVector)vector)
        {
            if (this.mDimension > 0)
                return;
            this.mObject = vector.mObject.CopyObj(1, -1);
        }

        private static HObject GenEmptyObj()
        {
            HObject hobject = new HObject();
            hobject.GenEmptyObj();
            return hobject;
        }

        protected override HVector GetDefaultElement()
        {
            return (HVector)new HObjectVector(this.mDimension - 1);
        }

        /// <summary>
        ///   Access to the object value for leaf vectors (dimension 0).
        ///   Ownership of object resides with object vector and it will
        ///   be disposed when the vector is disposed. Use O.CopyObj(1,-1)
        ///   to create an object that will survive a vector dispose.
        ///   When storing an object in the vector, it will be
        ///   copied automatically.
        /// </summary>
        public HObject O
        {
            get
            {
                this.AssertDimension(0);
                return this.mObject;
            }
            set
            {
                this.AssertDimension(0);
                if (value == null || !value.IsInitialized())
                    throw new HVectorAccessException("Uninitialized object not allowed in vector");
                this.mObject.Dispose();
                this.mObject = value.CopyObj(1, -1);
            }
        }

        /// <summary>
        ///   Access to subvector at specified index. The vector will be
        ///   enlarged to accomodate index, even in read access. The internal
        ///   reference is returned to allow modifications of vector state. For
        ///   read access, preferrably use the member function At(index).
        /// </summary>
        public HObjectVector this[int index]
        {
            get
            {
                return (HObjectVector)base[index];
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
        public HObjectVector At(int index)
        {
            return (HObjectVector)base.At(index);
        }

        protected override bool EqualsImpl(HVector vector)
        {
            if (this.mDimension >= 1)
                return base.EqualsImpl(vector);
            return ((HObjectVector)vector).O.TestEqualObj(this.O) != 0;
        }

        /// <summary>
        ///   Returns true if vector has same dimension, lengths, and elements
        /// </summary>
        public bool VectorEqual(HObjectVector vector)
        {
            return this.EqualsImpl((HVector)vector);
        }

        /// <summary>Concatenate two vectors, creating new vector</summary>
        public HObjectVector Concat(HObjectVector vector)
        {
            return (HObjectVector)this.ConcatImpl((HVector)vector, false, true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObjectVector Concat(HObjectVector vector, bool clone)
        {
            return (HObjectVector)this.ConcatImpl((HVector)vector, false, clone);
        }

        /// <summary>Append vector to this vector</summary>
        public HObjectVector Append(HObjectVector vector)
        {
            return (HObjectVector)this.ConcatImpl((HVector)vector, true, true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObjectVector Append(HObjectVector vector, bool clone)
        {
            return (HObjectVector)this.ConcatImpl((HVector)vector, true, clone);
        }

        /// <summary>Insert vector at specified index</summary>
        public HObjectVector Insert(int index, HObjectVector vector)
        {
            this.InsertImpl(index, (HVector)vector, true);
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObjectVector Insert(int index, HObjectVector vector, bool clone)
        {
            this.InsertImpl(index, (HVector)vector, clone);
            return this;
        }

        /// <summary>Remove element at specified index from this vector</summary>
        public HObjectVector Remove(int index)
        {
            this.RemoveImpl(index);
            return this;
        }

        /// <summary>Remove all elements from this vector</summary>
        public HObjectVector Clear()
        {
            this.ClearImpl();
            return this;
        }

        /// <summary>Create an independent copy of this vector</summary>
        public HObjectVector Clone()
        {
            return (HObjectVector)this.CloneImpl();
        }

        protected override HVector CloneImpl()
        {
            return (HVector)new HObjectVector(this);
        }

        protected override bool IsDisposable()
        {
            return true;
        }

        protected override void DisposeLeafObject()
        {
            if (this.mDimension > 0)
                return;
            this.mObject.Dispose();
        }

        /// <summary>
        ///   Provides a simple string representation of the vector,
        ///   which is mainly useful for debug outputs.
        /// </summary>
        public override string ToString()
        {
            if (this.mDimension <= 0)
                return this.mObject.Key.ToString();
            return base.ToString();
        }
    }
}
