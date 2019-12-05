using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HalconDotNet
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HDevWindowStack : IDisposable
    {
        ~HDevWindowStack()
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
            if (disposing)
                GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases the resources used by this tool object
        /// </summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
        }

        public static void Push(HTuple win_handle)
        {
            int err = HalconAPI.HWindowStackPush((long)win_handle);
            if (err != 2)
                throw new HalconException(err, "HDevWindowStack::Push");
        }

        public static HTuple Pop()
        {
            long win_handle;
            int err = HalconAPI.HWindowStackPop(out win_handle);
            if (err != 2)
                throw new HalconException(err, "HDevWindowStack::Pop");
            return (HTuple)win_handle;
        }

        public static HTuple GetActive()
        {
            long win_handle;
            int active = HalconAPI.HWindowStackGetActive(out win_handle);
            if (active != 2)
                throw new HalconException(active, "HDevWindowStack::GetActive");
            return (HTuple)win_handle;
        }

        public static void SetActive(HTuple win_handle)
        {
            int err = HalconAPI.HWindowStackSetActive((long)win_handle);
            if (err != 2)
                throw new HalconException(err, "HDevWindowStack::SetActive");
        }

        public static bool IsOpen()
        {
            bool is_open;
            int err = HalconAPI.HWindowStackIsOpen(out is_open);
            if (err != 2)
                throw new HalconException(err, "HDevWindowStack::IsOpen");
            return is_open;
        }

        public static void CloseAll()
        {
            int err = HalconAPI.HWindowStackCloseAll();
            if (err != 2)
                throw new HalconException(err, "HDevWindowStack::CloseAll");
        }
    }
}
