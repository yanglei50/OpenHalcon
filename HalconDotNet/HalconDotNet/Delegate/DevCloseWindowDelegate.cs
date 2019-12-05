using System;

namespace HalconDotNet
{
    internal class DevCloseWindowDelegate
    {
        private Func<int> devCloseWindow;

        public DevCloseWindowDelegate(Func<int> devCloseWindow)
        {
            this.devCloseWindow = devCloseWindow;
        }
    }
}