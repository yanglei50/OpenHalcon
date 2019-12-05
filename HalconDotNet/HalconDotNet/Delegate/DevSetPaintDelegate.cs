using System;

namespace HalconDotNet
{
    internal class DevSetPaintDelegate
    {
        private Func<IntPtr, int> devSetPaint;

        public DevSetPaintDelegate(Func<IntPtr, int> devSetPaint)
        {
            this.devSetPaint = devSetPaint;
        }
    }
}