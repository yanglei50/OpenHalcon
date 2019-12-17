using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalconDotNet
{
    public partial class MyHalconControl : UserControl
    {
        private IntPtr hwnd = IntPtr.Zero;
        private Rectangle imagePart = new Rectangle(0, 0, 640, 480);
        private Rectangle windowExtents = new Rectangle(0, 0, 320, 240);
        private Color borderColor = Color.Black;
        private const string positionDescription = " The position is returned in the image coordinate system.";
        private HWindow window;
        private int borderWidth;
        private PaintEventHandler paintEventDelegate;
        protected override Size DefaultSize
        {
            get
            {
                return new Size(320, 240);
            }
        }
        /// <summary>
        /// Size of the HALCON window in pixels.
        ///               Without border, this will be identical to the control size.
        /// 
        /// </summary>
        [Category("Layout")]
        [Description("Size of the HALCON window in pixels. Without border, this will be identical to the control size")]
        public Size WindowSize
        {
            get
            {
                return this.windowExtents.Size;
            }
            set
            {
                this.ClientSize = new Size(value.Width + 2 * this.borderWidth, value.Height + 2 * this.borderWidth);
            }
        }
        /// <summary>
        /// This rectangle specifies the image part to be displayed.
        ///              The method SetFullImagePart() will adapt this property to
        ///              show the full image.
        /// 
        /// </summary>
        [Description("This rectangle specifies the image part to be displayed, which will automatically be zoomed to fill the window. To display a full image of size W x H, set this to 0;0;W;H")]
        [Category("Layout")]
        public Rectangle ImagePart
        {
            get
            {
                if (this.window != null)
                {
                    int row1;
                    int column1;
                    int row2;
                    int column2;
                    this.window.GetPart(out row1, out column1, out row2, out column2);
                    this.imagePart = new Rectangle(column1, row1, column2 - column1 + 1, row2 - row1 + 1);
                }
                return this.imagePart;
            }
            set
            {
                this.imagePart = !value.IsEmpty ? value : new Rectangle(0, 0, this.Width - 2 * this.borderWidth, this.Height - 2 * this.BorderWidth);
                this.UpdatePart();
            }
        }

        /// <summary>
        /// Width of optional border in pixels
        /// 
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Width of optional border in pixels")]
        public int BorderWidth
        {
            get
            {
                return this.borderWidth;
            }
            set
            {
                this.borderWidth = value;
                this.UpdateWindowExtents();
            }
        }

        /// <summary>
        /// Color of optional border around window
        /// 
        /// </summary>
        [Description("Color of optional border around window")]
        [Category("Appearance")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
                this.BackColor = this.borderColor;
            }
        }

        [Browsable(false)]
        public HWindow HalconWindow
        {
            get
            {
                if (this.window != null)
                    return this.window;
                return new HWindow();
            }
        }

        [Browsable(false)]
        public IntPtr HalconID
        {
            get
            {
                if (this.window != null)
                    return this.window.Handle;
                return IntPtr.Zero;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        /// <summary>
        /// Occurs after the HALCON window has been initialized
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Under Mono/Linux, the HALCON window cannot be initialized
        ///               before the Form is visible. Therefore, accessing the window
        ///               in the event Load of the Form is not portable.
        /// 
        /// </remarks>
        [Description("Occurs after the HALCON window has been initialized.")]
        [Category("Behavior")]
        public event HInitWindowEventHandler HInitWindow;

        /// <summary>
        /// Occurs when the mouse is moved over the HALCON window. Note that
        ///               delta is meaningless here.
        /// 
        /// </summary>
        [Description("Occurs when the mouse is moved over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        [Category("Mouse")]
        public event HMouseEventHandler HMouseMove;

        /// <summary>
        /// Occurs when a button is pressed over the HALCON window. Note that
        ///               delta is meaningless here.
        /// 
        /// </summary>
        [Category("Mouse")]
        [Description("Occurs when a button is pressed over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        public event HMouseEventHandler HMouseDown;

        /// <summary>
        /// Occurs when a button is released over the HALCON window. Note that
        ///               delta is meaningless here.
        /// 
        /// </summary>
        [Category("Mouse")]
        [Description("Occurs when a button is released over the HALCON window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
        public event HMouseEventHandler HMouseUp;

        /// <summary>
        /// Occurs when the wheel is used over the HALCON window.  Note that
        ///               button is meaningless here.
        /// 
        /// </summary>
        [Description("Occurs when the wheel is used over the HALCON window. Note that button is meaningless here. The position is returned in the image coordinate system.")]
        [Category("Mouse")]
        public event HMouseEventHandler HMouseWheel;
        public MyHalconControl()
        {
            InitializeComponent();
            if (HalconAPI.isWindows)
                this.createWindow(false);
            this.paintEventDelegate = new PaintEventHandler(this.MyHWindowControl_Paint);
            this.Paint += this.paintEventDelegate;
        }

        private void MyHWindowControl_Paint(object sender, PaintEventArgs e)
        {
            this.Paint -= this.paintEventDelegate;
            if (!HalconAPI.isWindows)
            {
                this.createWindow(false);
                try
                {
                    ((Form)this.TopLevelControl).Closing += new CancelEventHandler(this.Form_Closing);
                }
                catch (Exception ex)
                {
                }
            }
            this.OnHInitWindow();
        }

        //private void Form_Closing(object sender, CancelEventArgs e)
        //{
        //    this.Dispose();
        //}

        //private void HWindowControl_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (this.window == null || !this.Visible || !(this.hwnd != this.Handle))
        //        return;
        //    this.createWindow(true);
        //}

        private void createWindow(bool repair)
        {
            this.BackColor = this.BorderColor;
            if (this.window != null && !repair)
                return;
            //if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
             //   return;
            try
            {
                HOperatorSet.SetCheck((HTuple)"~father");
                if (this.window == null)
                {
                    this.window = new HWindow();
                }
                else
                {
                    int row1;
                    int column1;
                    int row2;
                    int column2;
                    this.window.GetPart(out row1, out column1, out row2, out column2);
                    this.imagePart = new Rectangle(column1, row1, column2 - column1 + 1, row2 - row1 + 1);
                }
                this.hwnd = this.Handle;
                this.window.OpenWindow(this.borderWidth, this.borderWidth, this.Width - 2 * this.borderWidth, this.Height - 2 * this.borderWidth, this.hwnd, "visible", "");
                this.UpdatePart();
            }
            catch (HOperatorException ex)
            {
                int errorCode = ex.GetErrorCode();
                if (errorCode >= 5100 && errorCode < 5200)
                    throw ex;
            }
            catch (DllNotFoundException ex)
            {
            }
        }

        private void Form_Closing(object sender, CancelEventArgs e)
        {
            this.Dispose();
        }

        private void HWindowControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.window == null || !this.Visible || !(this.hwnd != this.Handle))
                return;
            this.createWindow(true);
        }

       
        /// <summary>
        /// Clean up any resources being used.
        /// 
        /// </summary>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && this.window != null)
        //    {
        //        this.window.Dispose();
        //        this.window = (HWindow)null;
        //        if (this.components != null)
        //            this.components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        /// <summary>
        /// Required method for Designer support - do not modify
        ///             the contents of this method with the code editor.
        /// 
        /// </summary>
        //private override void InitializeComponent()
        //{
        //    this.Name = "HWindowControl";
        //    this.Size = new Size(320, 240);
        //    //this.VisibleChanged += new EventHandler(this.HWindowControl_VisibleChanged);
        //    this.Resize += new EventHandler(this.HWindowControl_Resize);
        //    this.MouseUp += new MouseEventHandler(this.HWindowControl_MouseUp);
        //    this.MouseMove += new MouseEventHandler(this.HWindowControl_MouseMove);
        //    this.MouseWheel += new MouseEventHandler(this.HWindowControl_MouseWheel);
        //    this.MouseDown += new MouseEventHandler(this.HWindowControl_MouseDown);
        //}

        private void UpdateWindowExtents()
        {
            this.windowExtents = new Rectangle(this.borderWidth, this.borderWidth, this.ClientSize.Width - 2 * this.borderWidth, this.ClientSize.Height - 2 * this.borderWidth);
            if (this.window != null && this.windowExtents.Width > 0 && this.windowExtents.Height > 0)
            {
                int row;
                int column;
                int width;
                int height;
                this.window.GetWindowExtents(out row, out column, out width, out height);
                if (this.windowExtents.Equals((object)new Rectangle(row, column, width, height)))
                    return;
                this.window.SetWindowExtents(this.windowExtents.Left, this.windowExtents.Top, this.windowExtents.Width, this.windowExtents.Height);
                if (!(HSystem.GetSystem(new HTuple("flush_graphic")).S == "true"))
                    return;
                this.Refresh();
            }
            else
                this.Refresh();
        }

        private void UpdatePart()
        {
            if (this.window == null)
                return;
            this.window.SetPart(this.imagePart.Top, this.imagePart.Left, this.imagePart.Top + this.imagePart.Height - 1, this.imagePart.Left + this.imagePart.Width - 1);
        }

        //private void HWindowControl_Resize(object sender, EventArgs e)
        //{
        //    this.UpdateWindowExtents();
        //}

        /// <summary>
        /// Adapt ImagePart to show the full image.
        /// 
        /// </summary>
        /// <param name="reference"/>
        public void SetFullImagePart(HImage reference)
        {
            string type;
            int width;
            int height;
            reference.GetImagePointer1(out type, out width, out height);
            this.ImagePart = new Rectangle(0, 0, width, height);
        }

        protected virtual void OnHInitWindow()
        {
            if (this.HInitWindow == null)
                return;
            this.HInitWindow((object)this, new EventArgs());
        }

        protected virtual void OnHMouseMove(HMouseEventArgs e)
        {
            if (this.HMouseMove == null)
                return;
            this.HMouseMove((object)this, e);
        }

        protected virtual void OnHMouseDown(HMouseEventArgs e)
        {
            if (this.HMouseDown == null)
                return;
            this.HMouseDown((object)this, e);
        }

        protected virtual void OnHMouseUp(HMouseEventArgs e)
        {
            if (this.HMouseUp == null)
                return;
            this.HMouseUp((object)this, e);
        }

        protected virtual void OnHMouseWheel(HMouseEventArgs e)
        {
            if (this.HMouseWheel == null)
                return;
            this.HMouseWheel((object)this, e);
        }

        private HMouseEventArgs ToHMouse(MouseEventArgs e)
        {
            double rowImage;
            double columnImage;
            if (this.window == null)
            {
                rowImage = (double)this.imagePart.Top + (double)(e.Y - this.borderWidth) * (double)this.imagePart.Height / (double)this.windowExtents.Height;
                columnImage = (double)this.imagePart.Left + (double)(e.X - this.borderWidth) * (double)this.imagePart.Width / (double)this.windowExtents.Width;
            }
            else
                this.window.ConvertCoordinatesWindowToImage((double)(e.Y - this.borderWidth), (double)(e.X - this.borderWidth), out rowImage, out columnImage);
            return new HMouseEventArgs(e.Button, e.Clicks, columnImage, rowImage, e.Delta);
        }

        //private void HWindowControl_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!this.windowExtents.Contains(e.X, e.Y))
        //        return;
        //    this.OnHMouseMove(this.ToHMouse(e));
        //}

        //private void HWindowControl_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (!this.windowExtents.Contains(e.X, e.Y))
        //        return;
        //    this.OnHMouseDown(this.ToHMouse(e));
        //}

        //private void HWindowControl_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (!this.windowExtents.Contains(e.X, e.Y))
        //        return;
        //    this.OnHMouseUp(this.ToHMouse(e));
        //}

        //private void HWindowControl_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (!this.windowExtents.Contains(e.X, e.Y))
        //        return;
        //    this.OnHMouseWheel(this.ToHMouse(e));
        //}

        private void MyHWindowControl_Resize(object sender, EventArgs e)
        {
            this.UpdateWindowExtents();
        }

        private void MyHWindowControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.windowExtents.Contains(e.X, e.Y))
                return;
            this.OnHMouseUp(this.ToHMouse(e));
        }

        private void MyHWindowControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.windowExtents.Contains(e.X, e.Y))
                return;
            this.OnHMouseDown(this.ToHMouse(e));
        }

        private void MyHWindowControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.windowExtents.Contains(e.X, e.Y))
                return;
            this.OnHMouseMove(this.ToHMouse(e));
        }

        private void MyHWindowControl_MouseHover(object sender, EventArgs e)
        {
            if (this.HMouseWheel == null)
                return;
            //this.HMouseWheel((object)this, e);
        }

        private void MyHWindowControl_Load(object sender, EventArgs e)
        {

        }
    }
}
