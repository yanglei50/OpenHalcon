using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    public abstract class HTool : IDisposable
    {
        /// <summary>Represents an uninitialized tool instance</summary>
       // [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly IntPtr UNDEF = new IntPtr(-1);
        private IntPtr handle;
        private bool attached;
        private bool suppressedFinalization;

        internal HTool()
          : this(HTool.UNDEF)
        {
        }

        internal HTool(IntPtr handle)
        {
            this.handle = handle;
            this.attached = true;
        }

        /// <summary>Returns the HALCON ID for this tool object</summary>
        /// <remarks>Caller must ensure that input object is kept alive</remarks>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr Handle
        {
            get
            {
                return this.handle;
            }
        }

        /// <summary>Relinquish ownership of managed HALCON ID</summary>
        /// <remarks>
        ///   Caller must ensure that handle is destroyed at some time
        ///   after this instance is no longer used.
        /// </remarks>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public void Detach()
        {
            this.attached = false;
            GC.SuppressFinalize((object)this);
            this.suppressedFinalization = true;
        }

        /// <summary>Returns true if the tool has been initialized.</summary>
        /// <remarks>
        ///   A tool will be uninitialized when creating it with a
        ///   no-argument constructor or after calling Dispose();
        /// </remarks>
        public bool IsInitialized()
        {
            return this.handle != HTool.UNDEF;
        }

        ~HTool()
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
                //base.Finalize();
            }
        }

        private void Dispose(bool disposing)
        {
            if (this.handle != HTool.UNDEF)
            {
                if (this.attached)
                    this.ClearHandleResource();
                this.handle = HTool.UNDEF;
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

        /// <summary>
        ///   Invalidates the tool object but keeps the HALCON handle alive, which
        ///   only makes sense if the handle is used externally and cleared later,
        ///   e.g. by an HOperatorSet based module or another language interface.
        /// </summary>
       // [EditorBrowsable(EditorBrowsableState.Never)]
        public void InvalidateWithoutDispose()
        {
            this.handle = HTool.UNDEF;
            this.attached = false;
            GC.SuppressFinalize((object)this);
            this.suppressedFinalization = true;
            GC.KeepAlive((object)this);
        }

        internal void Store(IntPtr proc, int parIndex)
        {
            HalconAPI.StoreIP(proc, parIndex, this.handle);
        }

        internal int Load(IntPtr proc, int parIndex, int err)
        {
            if (this.handle != HTool.UNDEF)
                throw new HalconException("Undisposed tool instance when loading output parameter");
            if (HalconAPI.IsFailure(err))
                return err;
            err = HalconAPI.LoadIP(proc, parIndex, err, out this.handle);
            this.attached = true;
            if (this.suppressedFinalization)
            {
                this.suppressedFinalization = false;
                GC.ReRegisterForFinalize((object)this);
            }
            return err;
        }

        protected abstract void ClearHandleResource();

       // [EditorBrowsable(EditorBrowsableState.Never)]
        public static HTuple ConcatArray(HTool[] tools)
        {
            IntPtr[] numArray = new IntPtr[tools.Length];
            for (int index = 0; index < tools.Length; ++index)
                numArray[index] = tools[index].handle;
            return new HTuple(numArray);
        }

        /// <summary>Cast to IntPtr returns HALCON ID of tool resources</summary>
        /// <remarks>Caller must ensure that input object is kept alive</remarks>
        public static implicit operator IntPtr(HTool tool)
        {
            return tool.handle;
        }

        /// <summary>Cast to HTuple returns HALCON ID of tool resources</summary>
        /// <remarks>Caller must ensure that input object is kept alive</remarks>
        public static implicit operator HTuple(HTool tool)
        {
            return new HTuple(tool.handle);
        }
    }
}
