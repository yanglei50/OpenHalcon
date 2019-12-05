using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>
    /// Convenience implementation of HDevOperators for a single window
    /// </summary>
    public class HDevOpFixedWindowImpl : IHDevOperators
    {
        /// <summary>
        /// Dev* operators will be rerouted to this window ID
        /// </summary>
        protected HTuple activeID;

        /// <summary>
        /// Creates an instance of the fixed window implementation
        /// </summary>
        /// <param name="windowID">The window ID of an existing HALCON window</param>
        public HDevOpFixedWindowImpl(HTuple windowID)
        {
            if (windowID.Length != 1)
                HDevEngineException.ThrowGeneric("Please specify exactly one window ID");
            this.activeID = windowID.Clone();
        }

        /// <summary>
        /// Creates an instance of the fixed window implementation
        /// </summary>
        /// <param name="window">An existing HALCON window</param>
        public HDevOpFixedWindowImpl(HWindow window)
          : this((HTuple)window.Handle)
        {
        }

        /// <summary>
        /// Does nothing except return the existing window ID
        /// </summary>
        public virtual void DevOpenWindow(HTuple row, HTuple column, HTuple width, HTuple height, HTuple background, out HTuple windowID)
        {
            windowID = this.activeID.Clone();
        }

        /// <summary>
        /// No action
        /// </summary>
        public virtual void DevSetWindow(HTuple windowHandle)
        {
        }

        /// <summary>
        /// Does nothing except return the existing window ID
        /// </summary>
        public virtual void DevGetWindow(out HTuple windowHandle)
        {
            windowHandle = this.activeID.Clone();
        }

        /// <summary>
        /// No action
        /// </summary>
        public virtual void DevCloseWindow()
        {
        }

        /// <summary>
        /// No action
        /// </summary>
        public virtual void DevSetWindowExtents(HTuple row, HTuple column, HTuple width, HTuple height)
        {
        }

        public virtual void DevSetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            HOperatorSet.SetPart(this.activeID, row1, column1, row2, column2);
        }

        public virtual void DevClearWindow()
        {
            HOperatorSet.ClearWindow(this.activeID);
        }

        public virtual void DevDisplay(HObject obj)
        {
            HOperatorSet.DispObj(obj, this.activeID);
        }

        public virtual void DevDispText(HTuple text, HTuple coordSystem, HTuple row, HTuple column, HTuple color, HTuple genParamName, HTuple genParamValue)
        {
            HOperatorSet.DispText(this.activeID, text, coordSystem, row, column, color, genParamName, genParamValue);
        }

        public virtual void DevSetDraw(HTuple drawMode)
        {
            HOperatorSet.SetDraw(this.activeID, drawMode);
        }

        public virtual void DevSetShape(HTuple shape)
        {
            HOperatorSet.SetShape(this.activeID, shape);
        }

        public virtual void DevSetColored(HTuple numColors)
        {
            HOperatorSet.SetColored(this.activeID, numColors);
        }

        public virtual void DevSetColor(HTuple colorName)
        {
            HOperatorSet.SetColor(this.activeID, colorName);
        }

        public virtual void DevSetLut(HTuple lutName)
        {
            HOperatorSet.SetLut(this.activeID, lutName);
        }

        public virtual void DevSetPaint(HTuple mode)
        {
            HOperatorSet.SetPaint(this.activeID, mode);
        }

        public virtual void DevSetLineWidth(HTuple lineWidth)
        {
            HOperatorSet.SetLineWidth(this.activeID, lineWidth);
        }
    }
}
