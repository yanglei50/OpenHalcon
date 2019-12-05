// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMouseEventArgsWPF
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Windows.Input;

namespace HalconDotNet
{
    /// <summary>Provides data for the HMouse* events.</summary>
    public class HMouseEventArgsWPF : EventArgs
    {
        private readonly double x;
        private readonly double y;
        private readonly double row;
        private readonly double column;
        private readonly int delta;
        private readonly System.Windows.Input.ICommand button;

        internal HMouseEventArgsWPF(
          double x,
          double y,
          double row,
          double column,
          int delta,
          System.Windows.Input.ICommand button)
        {
            this.x = x;
            this.y = y;
            this.row = row;
            this.column = column;
            this.delta = delta;
            this.button = button;
        }

        /// <summary>Gets the window x coordinate of the mouse event.</summary>
        public double X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>Gets the window y coordinate of the mouse event.</summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>Gets the row image coordinate of the mouse event.</summary>
        public double Row
        {
            get
            {
                return this.row;
            }
        }

        /// <summary>Gets the column image coordinate of the mouse event.</summary>
        public double Column
        {
            get
            {
                return this.column;
            }
        }

        /// <summary>Gets the increment for the mouse wheel change.</summary>
        public int Delta
        {
            get
            {
                return this.delta;
            }
        }

        /// <summary>Gets which mouse button was pressed.</summary>
        public System.Windows.Input.ICommand Button
        {
            get
            {
                return this.button;
            }
        }
    }
}
