using System;

namespace HalconDotNet
{
    internal class DevSetLineWidthDelegate
    {
        private Func<IntPtr, int> devSetLineWidth;

        public DevSetLineWidthDelegate(Func<IntPtr, int> devSetLineWidth)
        {
            this.devSetLineWidth = devSetLineWidth;
        }
    }
}