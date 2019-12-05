// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSmartWindowControl
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using HalconDotNet.Delegate;

namespace HalconDotNet
{
    [ToolboxBitmap(typeof(HWindowControl))]
    public class HSmartWindowControl : UserControl
    {
        private Point _last_position = new Point(0, 0);
        private HObject _netimg = new HObject();
        private Size _prevsize = new Size();
        private Rectangle _part = new Rectangle(0, 0, 640, 480);
        private bool _automove = true;
        private bool _keepaspectratio = true;
        private HSmartWindowControl.ZoomContent _zooming = HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
        private bool _resetpart = true;
        private const string positionDescription = " The position is returned in the image coordinate system.";
        private HWindow _hwindow;
        private HTuple _dump_params;
        private bool _left_button_down;
        private HSmartWindowControl.DrawingObjectsModifier _drawingObjectsModifier;
        /// <summary>Required designer variable.</summary>
        private IContainer components;
        private PictureBox WindowFrame;

        /// <summary>
        ///   Occurs when the mouse is moved over the HALCON window. Note that
        ///   delta is meaningless here.
        /// </summary>
        [Description("Occurs when the mouse is moved over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        [Category("Mouse")]
        public event HMouseEventHandler HMouseMove;

        /// <summary>
        ///   Occurs when a button is pressed over the HALCON window. Note that
        ///   delta is meaningless here.
        /// </summary>
        [Description("Occurs when a button is pressed over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        [Category("Mouse")]
        public event HMouseEventHandler HMouseDown;

        /// <summary>
        ///   Occurs when a button is released over the HALCON window. Note that
        ///   delta is meaningless here.
        /// </summary>
        [Category("Mouse")]
        [Description("Occurs when a button is released over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        public event HMouseEventHandler HMouseUp;

        /// <summary>
        ///   Occurs when a button is double-clicked over a HALCON window. Note
        ///   that delta is meaningless here.
        /// </summary>
        [Category("Mouse")]
        [Description("Occurs when a button is double-clicked over a HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        public event HMouseEventHandler HMouseDoubleClick;

        /// <summary>
        ///   Occurs when the wheel is used over a HALCON window while it has
        ///   focus. Note that button is meaningless here.
        /// </summary>
        [Category("Mouse")]
        [Description("Occurs when the wheel is used over a HALCON window while it has focus. Note that button is meaningless here. The position is returned in the image coordinate system.")]
        public event HMouseEventHandler HMouseWheel;

        /// <summary>Occurs after the HALCON window has been initialized</summary>
        [Description("Occurs after the HALCON window has been initialized.")]
        [Category("Behavior")]
        public event HInitWindowEventHandler HInitWindow;

        /// <summary>
        /// Occurs when an internal error in the HSmartWindowControl happens.
        /// </summary>
        public event HSmartWindowControl.HErrorHandler HErrorNotify;

        protected override Size DefaultSize
        {
            get
            {
                return new Size(320, 240);
            }
        }

        public HSmartWindowControl()
        {
            this.InitializeComponent();
        }

        [Browsable(false)]
        public HWindow HalconWindow
        {
            get
            {
                if (this._hwindow == null && this.Width > 0 && this.Height > 0)
                    this.CreateHWindow();
                return this._hwindow;
            }
        }

        [Browsable(false)]
        public IntPtr HalconID
        {
            get
            {
                if (this._hwindow != null)
                    return this._hwindow.Handle;
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Reliable way to check whether we are in designer mode.
        /// </summary>
        private static bool RunningInDesignerMode
        {
            get
            {
                bool flag = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
                if (flag)
                    return flag;
                using (Process currentProcess = Process.GetCurrentProcess())
                {
                    string fileDescription = currentProcess.MainModule.FileVersionInfo.FileDescription;
                    return currentProcess.ProcessName.ToLowerInvariant().Contains("devenv") || currentProcess.ProcessName.ToLowerInvariant().Contains("express") && fileDescription.ToLowerInvariant().Contains("microsoft visual studio") || fileDescription.ToLowerInvariant().Contains("microsoft visual studio");
                }
            }
        }

        /// <summary>
        ///   Adapt ImagePart to show the full image. If HKeepAspectRatio is on,
        ///   the contents of the HALCON window are rescaled while keeping the aspect
        ///   ratio. Otherwise, the HALCON window contents are rescaled to fill up
        ///   the HSmartWindowControl.
        /// </summary>
        /// <param name="reference"></param>
        public void SetFullImagePart(HImage reference = null)
        {
            if (reference != null)
            {
                int width;
                int height;
                reference.GetImageSize(out width, out height);
                this._hwindow.SetPart(0, 0, width - 1, height - 1);
            }
            else if (this.HKeepAspectRatio)
                this._hwindow.SetPart(0, 0, -2, -2);
            else
                this._hwindow.SetPart(0, 0, -1, -1);
        }

        /// <summary>
        /// Force the Window Control to be repainted in a thread safe manner.
        /// </summary>
        /// <param name="context"></param>
        private void HWindowCallback(IntPtr context)
        {
            //if (this.InvokeRequired)
            //    this.BeginInvoke((Invalidate()));
            //    //this.BeginInvoke((() => this.Invalidate()));
            //else
            //    this.Invalidate();
        }

        /// <summary>
        /// Real pain in the ass. In WinForms events do not bubble, as it is the case
        /// for most frameworks.
        /// This means, we need to hand code the event chain.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick((Control)this, EventArgs.Empty);
        }

        /// <summary>Redirect relevant events up to the containing Form.</summary>
        /// <param name="e">Reference to the containing Control.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (HSmartWindowControl.RunningInDesignerMode)
                return;
            e.Control.Click += new EventHandler(this.ctrl_Click);
            e.Control.GotFocus += new EventHandler(this.Control_GotFocus);
            e.Control.LostFocus += new EventHandler(this.Control_LostFocus);
            e.Control.MouseEnter += new EventHandler(this.Control_MouseEnter);
            e.Control.MouseLeave += new EventHandler(this.Control_MouseLeave);
            e.Control.MouseHover += new EventHandler(this.Control_MouseHover);
            e.Control.SizeChanged += new EventHandler(this.Control_SizeChanged);
            e.Control.KeyDown += new KeyEventHandler(this.Control_KeyDown);
            e.Control.KeyPress += new KeyPressEventHandler(this.Control_KeyPress);
            e.Control.KeyUp += new KeyEventHandler(this.Control_KeyUp);
            e.Control.Resize += new EventHandler(this.Control_Resize);
        }

        private void Control_Resize(object sender, EventArgs e)
        {
            this.OnResize(e);
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            this.OnSizeChanged(e);
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Control_LostFocus(object sender, EventArgs e)
        {
            this.InvokeLostFocus((Control)this, EventArgs.Empty);
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            this.InvokeGotFocus((Control)this, EventArgs.Empty);
        }

        /// <summary>Clean up event processing.</summary>
        /// <param name="e"></param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (!HSmartWindowControl.RunningInDesignerMode)
            {
                e.Control.Click -= new EventHandler(this.ctrl_Click);
                e.Control.GotFocus -= new EventHandler(this.Control_GotFocus);
                e.Control.LostFocus -= new EventHandler(this.Control_LostFocus);
                e.Control.MouseEnter -= new EventHandler(this.Control_MouseEnter);
                e.Control.MouseLeave -= new EventHandler(this.Control_MouseLeave);
                e.Control.MouseHover -= new EventHandler(this.Control_MouseHover);
                e.Control.SizeChanged -= new EventHandler(this.Control_SizeChanged);
                e.Control.KeyDown -= new KeyEventHandler(this.Control_KeyDown);
                e.Control.KeyPress -= new KeyPressEventHandler(this.Control_KeyPress);
                e.Control.KeyUp -= new KeyEventHandler(this.Control_KeyUp);
                e.Control.Resize -= new EventHandler(this.Control_Resize);
            }
            base.OnControlRemoved(e);
        }

        private void CreateHWindow()
        {
            if (HSmartWindowControl.RunningInDesignerMode)
                return;
            this._hwindow = new HWindow(0, 0, this.Width, this.Height, (HTuple)"", "buffer", "");
            this._hwindow.SetPart(this._part.Top, this._part.Left, this._part.Top + this._part.Height - 1, this._part.Left + this._part.Right - 1);
            this._hwindow.SetWindowParam("graphics_stack", "true");
            this._prevsize.Width = this.Width;
            this._prevsize.Height = this.Height;
            this._dump_params = new HTuple(this.HalconID);
            this._dump_params = this._dump_params.TupleConcat((HTuple)"interleaved");
            this._hwindow.OnContentUpdate(new HWindow.ContentUpdateCallback(this.HWindowCallback));
            this.SizeChanged += new EventHandler(this.HSmartWindowControl_SizeChanged);
            if (this.HInitWindow == null)
                return;
            this.HInitWindow((object)this, new EventArgs());
        }

        private void HSmartWindowControl_SizeChanged(object sender, EventArgs e)
        {
            this.WindowFrame.Size = this.Size;
            if (!this.HKeepAspectRatio)
                return;
            this.calculate_part((HTuple)this.HalconID, (HTuple)this._prevsize.Width, (HTuple)this._prevsize.Height);
        }

        private void HSmartWindowControl_Load(object sender, EventArgs e)
        {
            if (this._hwindow != null)
                return;
            this.CreateHWindow();
        }

        /// <summary>Size of the HALCON window in pixels.</summary>
        [Description("Size of the HALCON window in pixels.")]
        [Category("Layout")]
        public Size WindowSize
        {
            get
            {
                if (HSmartWindowControl.RunningInDesignerMode || this._hwindow == null)
                    return this.Size;
                int row;
                int column;
                int width;
                int height;
                this._hwindow.GetWindowExtents(out row, out column, out width, out height);
                return new Size(width, height);
            }
            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                    return;
                this.Size = new Size(value.Width, value.Height);
            }
        }

        private void GetFloatPart(
          HWindow window,
          out double l1,
          out double c1,
          out double l2,
          out double c2)
        {
            HTuple row1;
            HTuple column1;
            HTuple row2;
            HTuple column2;
            window.GetPart(out row1, out column1, out row2, out column2);
            l1 = (double)row1;
            c1 = (double)column1;
            l2 = (double)row2;
            c2 = (double)column2;
        }

        /// <summary>Initial part of the HALCON window.</summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Layout")]
        [Description("Visible image part (Column, Row, Width, Height).")]
        public Rectangle HImagePart
        {
            get
            {
                if (this._hwindow == null)
                    return this._part;
                int row1;
                int column1;
                int row2;
                int column2;
                this._hwindow.GetPart(out row1, out column1, out row2, out column2);
                return new Rectangle(column1, row1, column2 - column1 + 1, row2 - row1 + 1);
            }
            set
            {
                if (HSmartWindowControl.RunningInDesignerMode)
                {
                    this._part = value;
                }
                else
                {
                    if (value.Right <= 0 || value.Width <= 0)
                        return;
                    if (this._hwindow != null)
                    {
                        try
                        {
                            this._hwindow.SetPart(value.Top, value.Left, value.Top + value.Height - 1, value.Left + value.Width - 1);
                            this._part = value;
                        }
                        catch (HalconException ex)
                        {
                        }
                    }
                    else
                        this._part = value;
                }
            }
        }

        [Description("Modifier key to interact with drawing objects. If a modifier key is selected, the user can only interact with drawing objects while keeping the modifier key pressed. This is especially useful when interacting with XLD drawing objects.")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Behavior")]
        public HSmartWindowControl.DrawingObjectsModifier HDrawingObjectsModifier
        {
            get
            {
                return this._drawingObjectsModifier;
            }
            set
            {
                this._drawingObjectsModifier = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Behavior")]
        [Description("If on, the content of the HSmartWindowControl is moved when the mouse pointer is dragged.")]
        public bool HMoveContent
        {
            get
            {
                return this._automove;
            }
            set
            {
                this._automove = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("If on, the content of the HSmartWindowControl keeps its aspect ratio when the control is resized or zoomed.")]
        [Category("Behavior")]
        public bool HKeepAspectRatio
        {
            get
            {
                return this._keepaspectratio;
            }
            set
            {
                this._keepaspectratio = value;
            }
        }

        [Description("Controls the behavior of the mouse wheel.")]
        [Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public HSmartWindowControl.ZoomContent HZoomContent
        {
            get
            {
                return this._zooming;
            }
            set
            {
                this._zooming = value;
            }
        }

        [Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("If on, double clicking resizes the content of the HSmartWindowControl to fit the size of the control. ")]
        public bool HDoubleClickToFitContent
        {
            get
            {
                return this._resetpart;
            }
            set
            {
                this._resetpart = value;
            }
        }

        /// <summary>
        /// Utility method that converts HALCON images into System.Drawing.Image used to
        /// display images in Window Controls.
        /// </summary>
        /// <param name="himage"></param>
        /// <returns></returns>
        public static Image HalconToWinFormsImage(HImage himage)
        {
            HImage himage1 = himage.InterleaveChannels("argb", "match", (int)byte.MaxValue);
            string type;
            int width;
            int height;
            IntPtr imagePointer1 = himage1.GetImagePointer1(out type, out width, out height);
            Bitmap bitmap = new Bitmap(width / 4, height, width, PixelFormat.Format32bppPArgb, imagePointer1);
            Image image;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save((Stream)memoryStream, ImageFormat.Bmp);
                memoryStream.Position = 0L;
                image = Image.FromStream((Stream)memoryStream);
            }
            himage1.Dispose();
            bitmap.Dispose();
            return image;
        }

        /// <summary>
        /// In order to allow interaction with drawing objects and being able to
        /// zoom and drag the contents of the window, we need a mechanism to let
        /// the user decide what to do. Currently, if the user keeps the left
        /// Shift key pressed, he will be able to interact with the drawing
        /// objects. Otherwise, he works in the default modus.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>True if the user is currently pressing the left shift key.</returns>
        private bool InteractingWithDrawingObjs()
        {
            switch (this.HDrawingObjectsModifier)
            {
                case HSmartWindowControl.DrawingObjectsModifier.Shift:
                    return Control.ModifierKeys == Keys.Shift;
                case HSmartWindowControl.DrawingObjectsModifier.Ctrl:
                    return Control.ModifierKeys == Keys.Control;
                case HSmartWindowControl.DrawingObjectsModifier.Alt:
                    return Control.ModifierKeys == Keys.Alt;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Translates native encoding of mouse buttons to HALCON encoding
        /// (see get_mposition).
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int MouseEventToInt(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return 1;
            if (e.Button == MouseButtons.Right)
                return 4;
            return e.Button == MouseButtons.Middle ? 2 : 0;
        }

        private HMouseEventArgs ToHMouse(MouseEventArgs e)
        {
            double rowImage;
            double columnImage;
            this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out rowImage, out columnImage);
            return new HMouseEventArgs(e.Button, e.Clicks, columnImage, rowImage, e.Delta);
        }

        private void WindowFrame_MouseDown(object sender, MouseEventArgs e)
        {
            HMouseEventArgs e1 = (HMouseEventArgs)null;
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    this._left_button_down = true;
                    this._last_position.X = e.X;
                    this._last_position.Y = e.Y;
                }
                if (this.InteractingWithDrawingObjs())
                {
                    double rowImage;
                    double columnImage;
                    this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out rowImage, out columnImage);
                    this._hwindow.SendMouseDownEvent((HTuple)rowImage, (HTuple)columnImage, this.MouseEventToInt(e));
                }
                e1 = this.ToHMouse(e);
            }
            catch (HalconException ex)
            {
                if (this.HErrorNotify != null)
                    this.HErrorNotify(ex);
            }
            if (this.HMouseDown == null)
                return;
            this.HMouseDown((object)this, e1);
        }

        /// <summary>Shifts the window contents by (dx, dy) pixels.</summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void HShiftWindowContents(double dx, double dy)
        {
            double l1;
            double c1;
            double l2;
            double c2;
            this.GetFloatPart(this._hwindow, out l1, out c1, out l2, out c2);
            int row;
            int column;
            int width;
            int height;
            this._hwindow.GetWindowExtents(out row, out column, out width, out height);
            double num1 = (c2 - c1 + 1.0) / (double)width;
            double num2 = (l2 - l1 + 1.0) / (double)height;
            try
            {
                this._hwindow.SetPart((HTuple)(l1 + dy * num2), (HTuple)(c1 + dx * num1), (HTuple)(l2 + dy * num2), (HTuple)(c2 + dx * num1));
            }
            catch (HalconException ex)
            {
            }
        }

        private void WindowFrame_MouseMove(object sender, MouseEventArgs e)
        {
            HMouseEventArgs e1 = (HMouseEventArgs)null;
            try
            {
                bool flag = false;
                if (this._left_button_down && this.InteractingWithDrawingObjs())
                {
                    double rowImage;
                    double columnImage;
                    this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out rowImage, out columnImage);
                    flag = (HTuple)this._hwindow.SendMouseDragEvent((HTuple)rowImage, (HTuple)columnImage, this.MouseEventToInt(e))==true;
                }
                if (!flag && this._left_button_down && this.HMoveContent)
                    this.HShiftWindowContents((double)(this._last_position.X - e.X), (double)(this._last_position.Y - e.Y));
                this._last_position.X = e.X;
                this._last_position.Y = e.Y;
                e1 = this.ToHMouse(e);
            }
            catch (HalconException ex)
            {
                if (this.HErrorNotify != null)
                    this.HErrorNotify(ex);
            }
            if (this.HMouseMove == null)
                return;
            this.HMouseMove((object)this, e1);
        }

        private void WindowFrame_MouseUp(object sender, MouseEventArgs e)
        {
            HMouseEventArgs e1 = (HMouseEventArgs)null;
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    double rowImage;
                    double columnImage;
                    this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out rowImage, out columnImage);
                    this._hwindow.SendMouseUpEvent((HTuple)rowImage, (HTuple)columnImage, this.MouseEventToInt(e));
                    this._left_button_down = false;
                }
                this._last_position.X = e.X;
                this._last_position.Y = e.Y;
                e1 = this.ToHMouse(e);
            }
            catch (HalconException ex)
            {
                if (this.HErrorNotify != null)
                    this.HErrorNotify(ex);
            }
            if (this.HMouseUp == null)
                return;
            this.HMouseUp((object)this, e1);
        }

        private void WindowFrame_DoubleClick(object sender, EventArgs e)
        {
            HMouseEventArgs e1 = (HMouseEventArgs)null;
            try
            {
                bool flag = false;
                MouseEventArgs e2 = (MouseEventArgs)e;
                this._last_position.X = e2.X;
                this._last_position.Y = e2.Y;
                if (e2.Button == MouseButtons.Left && this.InteractingWithDrawingObjs())
                {
                    double rowImage;
                    double columnImage;
                    this._hwindow.ConvertCoordinatesWindowToImage((double)this._last_position.Y, (double)this._last_position.X, out rowImage, out columnImage);
                    flag = (HTuple)this._hwindow.SendMouseDoubleClickEvent((HTuple)rowImage, (HTuple)columnImage, this.MouseEventToInt(e2))==true;
                }
                if (!flag && this.HDoubleClickToFitContent)
                    this.SetFullImagePart((HImage)null);
                e1 = this.ToHMouse(e2);
            }
            catch (HalconException ex)
            {
                if (this.HErrorNotify != null)
                    this.HErrorNotify(ex);
            }
            if (this.HMouseDoubleClick == null)
                return;
            this.HMouseDoubleClick((object)this, e1);
        }

        private void WindowFrame_MouseLeave(object sender, EventArgs e)
        {
            this._left_button_down = false;
        }

        /// <summary>
        /// UserControls under Windows Forms do not support the mouse wheel event.
        /// As a solution, the user can set his MouseWheel event in his form to
        /// call this method.
        /// Please notice that the Visual Studio Designer does not show this event.
        /// The reason is that UserControls do not support this type of event.
        /// Hence, you need to manually add it to the initialization code of your
        /// Windows Form, and set it to call the HSmartWindowControl_MouseWheel
        /// method of the HALCON Window Control.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HSmartWindowControl_MouseWheel(object sender, MouseEventArgs e)
        {
            HMouseEventArgs e1 = (HMouseEventArgs)null;
            try
            {
                if (this._zooming != HSmartWindowControl.ZoomContent.Off)
                {
                    HTuple homMat2DIdentity;
                    HOperatorSet.HomMat2dIdentity(out homMat2DIdentity);
                    Point client = this.PointToClient(Cursor.Position);
                    double rowImage;
                    double columnImage;
                    this._hwindow.ConvertCoordinatesWindowToImage((double)client.Y, (double)client.X, out rowImage, out columnImage);
                    double num = e.Delta < 0 ? Math.Sqrt(2.0) : 1.0 / Math.Sqrt(2.0);
                    if (this.HZoomContent == HSmartWindowControl.ZoomContent.WheelBackwardZoomsIn)
                        num = 1.0 / num;
                    for (int index = Math.Abs(e.Delta) / 120; index > 1; --index)
                        num *= e.Delta < 0 ? Math.Sqrt(2.0) : 1.0 / Math.Sqrt(2.0);
                    HTuple homMat2DScale;
                    HOperatorSet.HomMat2dScale(homMat2DIdentity, (HTuple)num, (HTuple)num, (HTuple)columnImage, (HTuple)rowImage, out homMat2DScale);
                    double l1;
                    double c1;
                    double l2;
                    double c2;
                    this.GetFloatPart(this._hwindow, out l1, out c1, out l2, out c2);
                    HTuple qx1;
                    HTuple qy1;
                    HOperatorSet.AffineTransPoint2d(homMat2DScale, (HTuple)c1, (HTuple)l1, out qx1, out qy1);
                    HTuple qx2;
                    HTuple qy2;
                    HOperatorSet.AffineTransPoint2d(homMat2DScale, (HTuple)c2, (HTuple)l2, out qx2, out qy2);
                    e1 = this.ToHMouse(e);
                    try
                    {
                        this._hwindow.SetPart((HTuple)qy1.D, (HTuple)qx1.D, (HTuple)qy2.D, (HTuple)qx2.D);
                    }
                    catch (Exception ex)
                    {
                        this._hwindow.SetPart((HTuple)l1, (HTuple)c1, (HTuple)l2, (HTuple)c2);
                    }
                }
            }
            catch (HalconException ex)
            {
                if (this.HErrorNotify != null)
                    this.HErrorNotify(ex);
            }
            if (this.HMouseWheel == null)
                return;
            this.HMouseWheel((object)this, e1);
        }

        private void HSmartWindowControl_Paint(object sender, PaintEventArgs e)
        {
            if (this._hwindow == null || HSmartWindowControl.RunningInDesignerMode)
                return;
            bool flag = false;
            int row1;
            int column1;
            int width1;
            int height1;
            this._hwindow.GetWindowExtents(out row1, out column1, out width1, out height1);
            if (this.Width > 0 && this.Height > 0 && (width1 != this.Width || height1 != this.Height))
            {
                this.WindowFrame.Width = this.Width;
                this.WindowFrame.Height = this.Height;
                int row2;
                int column2;
                int width2;
                int height2;
                this._hwindow.GetWindowExtents(out row2, out column2, out width2, out height2);
                try
                {
                    this._hwindow.SetWindowExtents(0, 0, this.Width, this.Height);
                    flag = true;
                }
                catch (HalconException ex)
                {
                    this._hwindow.SetWindowExtents(0, 0, width2, height2);
                }
            }
            if (this.HKeepAspectRatio && flag)
                this.calculate_part((HTuple)this.HalconID, (HTuple)this._prevsize.Width, (HTuple)this._prevsize.Height);
            this._prevsize.Width = this.WindowFrame.Width;
            this._prevsize.Height = this.WindowFrame.Height;
            this._netimg.Dispose();
            HOperatorSet.DumpWindowImage(out this._netimg, this._dump_params);
            HTuple pointer;
            HTuple type;
            HTuple width3;
            HTuple height3;
            HOperatorSet.GetImagePointer1(this._netimg, out pointer, out type, out width3, out height3);
            this.WindowFrame.Image = (Image)new Bitmap((int)(width3 / 4), (int)height3, (int)width3, PixelFormat.Format32bppPArgb, (IntPtr)pointer.L);
        }

        private bool calculate_part(
          HTuple hv_WindowHandle,
          HTuple hv_WindowWidth,
          HTuple hv_WindowHeight)
        {
            HTuple row1 = (HTuple)null;
            HTuple column1 = (HTuple)null;
            HTuple row2 = (HTuple)null;
            HTuple column2 = (HTuple)null;
            HTuple row = (HTuple)null;
            HTuple column = (HTuple)null;
            HTuple width = (HTuple)null;
            HTuple height = (HTuple)null;
            HTuple homMat2DIdentity = (HTuple)null;
            HTuple homMat2DScale = (HTuple)null;
            HTuple qx = (HTuple)null;
            HTuple qy = (HTuple)null;
            bool flag = true;
            HOperatorSet.GetPart(hv_WindowHandle, out row1, out column1, out row2, out column2);
            try
            {
                HTuple htuple1 = (column2 - column1 + 1) / (row2 - row1 + 1).TupleReal();
                HOperatorSet.GetWindowExtents(hv_WindowHandle, out row, out column, out width, out height);
                HTuple sx = width / hv_WindowWidth.TupleReal();
                HTuple sy = height / hv_WindowHeight.TupleReal();
                HTuple htuple2 = new HTuple().TupleConcat((row1 + row2) * 0.5).TupleConcat((column1 + column2) * 0.5);
                HOperatorSet.HomMat2dIdentity(out homMat2DIdentity);
                HOperatorSet.HomMat2dScale(homMat2DIdentity, sx, sy, htuple2.TupleSelect((HTuple)1), htuple2.TupleSelect((HTuple)0), out homMat2DScale);
                HOperatorSet.AffineTransPoint2d(homMat2DScale, column1.TupleConcat(column2), row1.TupleConcat(row2), out qx, out qy);
                HOperatorSet.SetPart(hv_WindowHandle, qy.TupleSelect((HTuple)0), qx.TupleSelect((HTuple)0), qy.TupleSelect((HTuple)1), qx.TupleSelect((HTuple)1));
            }
            catch (HalconException ex)
            {
                HOperatorSet.SetPart(hv_WindowHandle, row1, column1, row2, column2);
                flag = false;
            }
            return flag;
        }

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WindowFrame = new PictureBox();
            ((ISupportInitialize)this.WindowFrame).BeginInit();
            this.SuspendLayout();
            this.WindowFrame.BackColor = SystemColors.Desktop;
            this.WindowFrame.Dock = DockStyle.Fill;
            this.WindowFrame.Location = new Point(0, 0);
            this.WindowFrame.Margin = new Padding(0);
            this.WindowFrame.Name = "WindowFrame";
            this.WindowFrame.Size = new Size(512, 512);
            this.WindowFrame.TabIndex = 0;
            this.WindowFrame.TabStop = false;
            this.WindowFrame.MouseDoubleClick += new MouseEventHandler(this.WindowFrame_DoubleClick);
            this.WindowFrame.MouseDown += new MouseEventHandler(this.WindowFrame_MouseDown);
            this.WindowFrame.MouseMove += new MouseEventHandler(this.WindowFrame_MouseMove);
            this.WindowFrame.MouseUp += new MouseEventHandler(this.WindowFrame_MouseUp);
            this.WindowFrame.MouseLeave += new EventHandler(this.WindowFrame_MouseLeave);
            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            this.Controls.Add((Control)this.WindowFrame);
            this.Margin = new Padding(0);
            this.Name = nameof(HSmartWindowControl);
            this.Size = new Size(512, 512);
            this.Load += new EventHandler(this.HSmartWindowControl_Load);
            this.Paint += new PaintEventHandler(this.HSmartWindowControl_Paint);
            ((ISupportInitialize)this.WindowFrame).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// In some situations (like a missing license in runtime), it can be the case that
        /// internal exceptions are thrown, and the user has no way of capturing them.
        /// This callback allows the user to react to such runtime errors.
        /// </summary>
        /// <param name="he"></param>
        public delegate void HErrorHandler(HalconException he);

        /// <summary>Modifier to manipulate drawing objects</summary>
        public enum DrawingObjectsModifier
        {
            /// <summary>Manipulate drawing objects without a modifier</summary>
            None,
            /// <summary>Shift key must be pressed to modify drawing objects</summary>
            Shift,
            /// <summary>Ctrl key must be pressed to modify drawing objects</summary>
            Ctrl,
            /// <summary>Alt key must be pressed to modify drawing objects</summary>
            Alt,
        }

        /// <summary>Mouse wheel behavior</summary>
        public enum ZoomContent
        {
            /// <summary>No effect on the contents</summary>
            Off,
            /// <summary>
            /// Moving the mouse wheel forward zooms in on the contents
            /// </summary>
            WheelForwardZoomsIn,
            /// <summary>
            /// Moving the mouse wheel backward zooms in on the contents
            /// </summary>
            WheelBackwardZoomsIn,
        }
    }
}
