using System;

namespace HalconDotNet
{
    internal class DevSetWindowExtentsDelegate
    {
        private Func<IntPtr, IntPtr, IntPtr, IntPtr, int> devSetWindowExtents;

        public DevSetWindowExtentsDelegate(Func<IntPtr, IntPtr, IntPtr, IntPtr, int> devSetWindowExtents)
        {
            this.devSetWindowExtents = devSetWindowExtents;
        }
    }
}