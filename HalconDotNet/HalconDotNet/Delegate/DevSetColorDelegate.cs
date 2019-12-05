using System;

namespace HalconDotNet
{
    internal class DevSetColorDelegate
    {
        private Func<IntPtr, int> devSetColor;

        public DevSetColorDelegate(Func<IntPtr, int> devSetColor)
        {
            this.devSetColor = devSetColor;
        }
    }
}