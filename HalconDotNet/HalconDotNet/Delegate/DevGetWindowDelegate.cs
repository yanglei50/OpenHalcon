using System;

namespace HalconDotNet
{
    internal class DevGetWindowDelegate
    {
        private Func<IntPtr, int> devGetWindow;

        public DevGetWindowDelegate(Func<IntPtr, int> devGetWindow)
        {
            this.devGetWindow = devGetWindow;
        }
    }
}