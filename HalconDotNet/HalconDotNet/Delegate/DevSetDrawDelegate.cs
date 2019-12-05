using System;

namespace HalconDotNet
{
    internal class DevSetDrawDelegate
    {
        private Func<IntPtr, int> devSetDraw;

        public DevSetDrawDelegate(Func<IntPtr, int> devSetDraw)
        {
            this.devSetDraw = devSetDraw;
        }
    }
}