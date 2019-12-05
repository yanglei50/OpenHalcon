// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMouseEventArgs
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Windows.Forms;

namespace HalconDotNet
{
    /// <summary>
    /// Provides data for the HMouseUp, HMouseDown, and HMouseMove  events.
    /// </summary>
    public class HMouseEventArgs : EventArgs
    {
        private readonly MouseButtons button;
        private readonly int clicks;
        private readonly double x;
        private readonly double y;
        private readonly int delta;

        internal HMouseEventArgs(MouseButtons button, int clicks, double x, double y, int delta)
        {
            this.button = button;
            this.clicks = clicks;
            this.x = x;
            this.y = y;
            this.delta = delta;
        }

        /// <summary>Gets which mouse button was pressed.</summary>
        public MouseButtons Button
        {
            get
            {
                return this.button;
            }
        }

        /// <summary>
        ///   Gets the number of times the mouse button was pressed and released.
        /// </summary>
        public int Clicks
        {
            get
            {
                return this.clicks;
            }
        }

        /// <summary>Gets the column coordinate of a mouse click.</summary>
        public double X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>Gets the row coordinate of a mouse click.</summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        ///   Gets a signed count of the number of detents the mouse wheel
        ///   has rotated. A detent is one notch of the mouse wheel.
        /// </summary>
        public int Delta
        {
            get
            {
                return this.delta;
            }
        }
    }
}