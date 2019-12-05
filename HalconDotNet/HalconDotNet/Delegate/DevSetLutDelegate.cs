using System;

namespace HalconDotNet
{
    internal class DevSetLutDelegate
    {
        private Func<IntPtr, int> devSetLut;

        public DevSetLutDelegate(Func<IntPtr, int> devSetLut)
        {
            this.devSetLut = devSetLut;
        }
    }
}