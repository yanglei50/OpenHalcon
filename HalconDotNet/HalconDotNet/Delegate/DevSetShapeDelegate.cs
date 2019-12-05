using System;

namespace HalconDotNet
{
    internal class DevSetShapeDelegate
    {
        private Func<IntPtr, int> devSetShape;

        public DevSetShapeDelegate(Func<IntPtr, int> devSetShape)
        {
            this.devSetShape = devSetShape;
        }
    }
}