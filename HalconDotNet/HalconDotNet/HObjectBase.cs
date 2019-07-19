// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HObjectBase
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    public class HObjectBase : IDisposable
    {
        /// <summary>Represents an uninitialized HALCON object key</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly IntPtr UNDEF = IntPtr.Zero;
        internal static readonly IntPtr UNDEF2 = new IntPtr(1);
        internal IntPtr key = HObjectBase.UNDEF;
        private bool suppressedFinalization;

        internal HObjectBase()
          : this(HObjectBase.UNDEF, false)
        {
        }

        internal HObjectBase(IntPtr key, bool copy)
        {
            if (copy && key != HObjectBase.UNDEF && key != HObjectBase.UNDEF2)
                this.key = HalconAPI.CopyObject(key);
            else
                this.key = key == HObjectBase.UNDEF2 ? HObjectBase.UNDEF : key;
        }

        internal HObjectBase(HObjectBase obj)
          : this(obj.key, true)
        {
            GC.KeepAlive((object)obj);
        }

        /// <summary>Returns the HALCON ID for this iconic object</summary>
        /// <remarks>Caller must ensure that object is kept alive</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr Key
        {
            get
            {
                return this.key;
            }
        }

        /// <summary>
        ///   Returns true if the iconic object has been initialized.
        /// </summary>
        /// <remarks>
        ///   An object will be uninitialized when creating it with a
        ///   no-argument constructor or after calling Dispose();
        /// </remarks>
        public bool IsInitialized()
        {
            return this.key != HObjectBase.UNDEF;
        }

        /// <summary>
        ///   Returns a new HALCON ID referencing this iconic object, which will
        ///   remain valid even after this object is disposed (and vice versa).
        ///   This is only useful if the ID shall be used in another language
        ///   interface (in fact, the key needs to be externally disposed,
        ///   a feature not even offered by the .NET language interface).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr CopyKey()
        {
            IntPtr num = HalconAPI.CopyObject(this.key);
            GC.KeepAlive((object)this);
            return num;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TransferOwnership(HObjectBase source)
        {
            if (source == this)
                return;
            this.Dispose();
            if (source == null)
                return;
            this.key = source.key;
            source.key = HObjectBase.UNDEF;
            this.suppressedFinalization = false;
            GC.ReRegisterForFinalize((object)this);
        }

        ~HObjectBase()
        {
            try
            {
                this.Dispose(false);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // ISSUE: explicit finalizer call
               // base.Finalize();
            }
        }

        private void Dispose(bool disposing)
        {
            if (this.key != HObjectBase.UNDEF)
            {
                HalconAPI.ClearObject(this.key);
                this.key = HObjectBase.UNDEF;
            }
            if (disposing)
            {
                GC.SuppressFinalize((object)this);
                this.suppressedFinalization = true;
            }
            GC.KeepAlive((object)this);
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>Releases the resources used by this tool object</summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
        }

        internal void Store(IntPtr proc, int parIndex)
        {
            HalconAPI.HCkP(proc, HalconAPI.SetInputObject(proc, parIndex, this.key));
        }

        internal int Load(IntPtr proc, int parIndex, int err)
        {
            if (this.key != HObjectBase.UNDEF)
                throw new HalconException("Undisposed object instance when loading output parameter");
            if (HalconAPI.IsFailure(err))
                return err;
            err = HalconAPI.GetOutputObject(proc, parIndex, out this.key);
            if (this.suppressedFinalization)
            {
                this.suppressedFinalization = false;
                GC.ReRegisterForFinalize((object)this);
            }
            return err;
        }
    }
}
