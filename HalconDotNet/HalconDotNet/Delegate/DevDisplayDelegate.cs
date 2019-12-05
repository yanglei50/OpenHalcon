using System;

namespace HalconDotNet
{
    internal class DevDisplayDelegate
    {
        private Func<IntPtr, int> devDisplay;

        public DevDisplayDelegate(Func<IntPtr, int> devDisplay)
        {
            this.devDisplay = devDisplay;
        }
    }
}