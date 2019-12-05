using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFVisionInspection
{
    public partial class BaseForm : Form
    {
        private ArrayList InitialCrl = new ArrayList();//用以存储窗体中所有的控件名称
        private ArrayList CrlLocationX = new ArrayList();//用以存储窗体中所有的控件原始位置
        private ArrayList CrlLocationY = new ArrayList();//用以存储窗体中所有的控件原始位置
        private ArrayList CrlSizeWidth = new ArrayList();//用以存储窗体中所有的控件原始的水平尺寸
        private ArrayList CrlSizeHeight = new ArrayList();//用以存储窗体中所有的控件原始的垂直尺寸
        private int FormSizeWidth;//用以存储窗体原始的水平尺寸
        private int FormSizeHeight;//用以存储窗体原始的垂直尺寸
        private double FormSizeChangedX;//用以存储相关父窗体/容器的水平变化量
        private double FormSizeChangedY;//用以存储相关父窗体/容器的垂直变化量 
        private int Wcounter = 0;//为防止递归遍历控件时产生混乱，故专门设定一个全局计数器
        private float X;
        private float Y;
        public BaseForm()
        {
            InitializeComponent();
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("窗体尺寸改变");
            Wcounter = 0;
            int counter = 0;
            if (FormSizeWidth == 0 || FormSizeHeight == 0)
                return;
            if (this.Size.Width < FormSizeWidth || this.Size.Height < FormSizeHeight)
            //如果窗体的大小在改变过程中小于窗体尺寸的初始值，则窗体中的各个控件自动重置为初始尺寸，且窗体自动添加滚动条
            {
                foreach (Control iniCrl in InitialCrl)
                {
                    iniCrl.Width = (int)CrlSizeWidth[counter];
                    iniCrl.Height = (int)CrlSizeHeight[counter];
                    Point point = new Point();
                    point.X = (int)CrlLocationX[counter];
                    point.Y = (int)CrlLocationY[counter];
                    iniCrl.Bounds = new Rectangle(point, iniCrl.Size);
                    counter++;
                }
                this.AutoScroll = true;
            }
            else
            //否则，重新设定窗体中所有控件的大小（窗体内所有控件的大小随窗体大小的变化而变化）
            {
                this.AutoScroll = false;
                ResetAllCrlState(this);
            }
        }
        public void ResetAllCrlState(Control CrlContainer)//重新设定窗体中各控件的状态（在与原状态的对比中计算而来）
        {
            FormSizeChangedX = (double)this.Size.Width / (double)FormSizeWidth;
            FormSizeChangedY = (double)this.Size.Height / (double)FormSizeHeight;

            foreach (Control kCrl in CrlContainer.Controls)
            {
                /*string name = kCrl.Name.ToString();
                MessageBox.Show(name);
                MessageBox.Show(Wcounter.ToString());*/
                if (kCrl.Controls.Count > 0)
                {
                    ResetAllCrlState(kCrl);
                }
                Point point = new Point();
                point.X = (int)((int)CrlLocationX[Wcounter] * FormSizeChangedX);
                point.Y = (int)((int)CrlLocationY[Wcounter] * FormSizeChangedY);
                kCrl.Width = (int)((int)CrlSizeWidth[Wcounter] * FormSizeChangedX);
                kCrl.Height = (int)((int)CrlSizeHeight[Wcounter] * FormSizeChangedY);
                kCrl.Bounds = new Rectangle(point, kCrl.Size);
                Wcounter++;
            }
        }

        public void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (con == null)
                    break;

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            GetInitialFormSize();
            //this.AutoScroll = true;
            //this.SetAutoSizeMode(FormSizeWidth,FormSizeHeight);
            //this.AutoScrollMinSize.Width = FormSizeWidth;
            //this.AutoScrollMinSize.Height = FormSizeHeight;
            GetAllCrlLocation(this);
            GetAllCrlSize(this);

            setTag(this);
        }


        public void GetAllCrlLocation(Control CrlContainer)//获得并存储窗体中各控件的初始位置
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                if (iCrl.Controls.Count > 0)
                    GetAllCrlLocation(iCrl);
                InitialCrl.Add(iCrl);
                CrlLocationX.Add(iCrl.Location.X);
                CrlLocationY.Add(iCrl.Location.Y);
            }
        }

        public void GetAllCrlSize(Control CrlContainer)//获得并存储窗体中各控件的初始尺寸
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                if (iCrl.Controls.Count > 0)
                    GetAllCrlSize(iCrl);
                CrlSizeWidth.Add(iCrl.Width);
                CrlSizeHeight.Add(iCrl.Height);
            }
        }

        public void GetInitialFormSize()//获得并存储窗体的初始尺寸
        {
            FormSizeWidth = this.Size.Width;
            FormSizeHeight = this.Size.Height;

            if (FormSizeWidth == 0)
                FormSizeWidth = 1012;// this.Size.Width;
            if (FormSizeHeight == 0)
                FormSizeHeight = 630;// this.Size.Height;
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            this.Text = this.Width.ToString() + " " + this.Height.ToString();
        }
    }
}
