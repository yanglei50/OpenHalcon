using System;

namespace HalconDotNet
{
    internal class DevClearWindowDelegate
    {
        private Func<int> devClearWindow;

        public DevClearWindowDelegate(Func<int> devClearWindow)
        {
            this.devClearWindow = devClearWindow;
        }
    }
}