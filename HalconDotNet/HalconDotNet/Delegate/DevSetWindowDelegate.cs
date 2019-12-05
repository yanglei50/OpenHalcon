using System;

namespace HalconDotNet
{
    internal class DevSetWindowDelegate
    {
        private Func<IntPtr, int> devSetWindow;

        public DevSetWindowDelegate(Func<IntPtr, int> devSetWindow)
        {
            this.devSetWindow = devSetWindow;
        }
    }
}