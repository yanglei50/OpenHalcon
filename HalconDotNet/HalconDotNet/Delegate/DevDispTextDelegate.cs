using System;

namespace HalconDotNet
{
    internal class DevDispTextDelegate
    {
        private Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int> devDispText;

        public DevDispTextDelegate(Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int> devDispText)
        {
            this.devDispText = devDispText;
        }
    }
}