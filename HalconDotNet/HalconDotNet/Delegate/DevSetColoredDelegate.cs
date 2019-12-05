using System;

namespace HalconDotNet
{
    internal class DevSetColoredDelegate
    {
        private Func<IntPtr, int> devSetColored;

        public DevSetColoredDelegate(Func<IntPtr, int> devSetColored)
        {
            this.devSetColored = devSetColored;
        }
    }
}