using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet.Delegate
{
    /// <summary>
    /// Represents the method that will handle the HMouseDown, HMouseUp,
    /// or HMouseMove event of a HWindowControl.
    /// </summary>
    public delegate void HMouseEventHandler(object sender, HMouseEventArgs e);
}
