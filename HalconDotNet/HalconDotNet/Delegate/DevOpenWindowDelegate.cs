using System;

namespace HalconDotNet
{
    internal class DevOpenWindowDelegate
    {
        private Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int> devOpenWindow;

        public DevOpenWindowDelegate(Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int> devOpenWindow)
        {
            this.devOpenWindow = devOpenWindow;
        }
    }
}