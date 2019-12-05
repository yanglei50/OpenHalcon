using System;

namespace HalconDotNet
{
    internal class DevSetPartDelegate
    {
        private Func<IntPtr, IntPtr, IntPtr, IntPtr, int> devSetPart;

        public DevSetPartDelegate(Func<IntPtr, IntPtr, IntPtr, IntPtr, int> devSetPart)
        {
            this.devSetPart = devSetPart;
        }
    }
}