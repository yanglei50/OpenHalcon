using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WFVisionInspection.JsonUtil;

namespace WFVisionInspection
{
    public partial class DetectionParameterSetting : Form
    {
        private ArrayList CrlLocationX = new ArrayList();
        //用以存储窗体中所有的控件原始位置
        private ArrayList CrlLocationY = new ArrayList();

        private ArrayList CrlSizeHeight = new ArrayList();
        //用以存储窗体中所有的控件原始位置
        private ArrayList CrlSizeWidth = new ArrayList();

        //private String[] filename_metal = { "mental_01.bmp", "mental_02.bmp", "mental_03.bmp", "mental_04.bmp", "mental_05.bmp", "mental_06.bmp" };
        //private String filename_metal_path = "C:\\Users\\lei\\Documents\\Visual Studio 2015\\Projects\\WFVisionInspection\\WFVisionInspection\\images\\";
        private double FormSizeChangedX;
        //用以存储相关父窗体/容器的水平变化量
        private double FormSizeChangedY;

        private int FormSizeHeight;
        //用以存储窗体中所有的控件原始的水平尺寸
        //用以存储窗体中所有的控件原始的垂直尺寸
        private int FormSizeWidth;
        private Image_Resource[] skillArray;
        HDevelopExport hdev_export;
        private ArrayList InitialCrl = new ArrayList();//用以存储窗体中所有的控件名称
                                                       //用以存储窗体原始的水平尺寸
                                                       //用以存储窗体原始的垂直尺寸
                                                       //用以存储相关父窗体/容器的垂直变化量 
        private int Wcounter = 0;//为防止递归遍历控件时产生混乱，故专门设定一个全局计数器
        private float X;
        private float Y;
        public DetectionParameterSetting()
        {
            InitializeComponent();
        }
        #region auto_win_size
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (con == null)
                    break;
                if (con.Tag == null)
                {
                    GetAllCrlLocation(this);
                    GetAllCrlSize(this);
                    setTag(this);

                }
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
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        private void DetectionParameterSetting_SizeChanged(object sender, EventArgs e)
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
                Console.WriteLine("ResetAllCrlState:" + kCrl.Name + ":" + kCrl.Text + "-(" + kCrl.Width + "," + kCrl.Height + ")");
                Wcounter++;
            }
        }

        public void GetAllCrlLocation(Control CrlContainer)//获得并存储窗体中各控件的初始位置
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                Console.WriteLine(iCrl.Name + ":" + iCrl.Text + "-(" + iCrl.Location.X + "," + iCrl.Location.Y + ")");
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
                Console.WriteLine(iCrl.Name + ":" + iCrl.Text + "-(" + iCrl.Width + "," + iCrl.Height + ")");
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
        #endregion
        #region read_image_xml
        #endregion
        private void DetectionParameterSetting_Load(object sender, EventArgs e)
        {
            X = this.Width;
            Y = this.Height;
            GetInitialFormSize();
            GetAllCrlLocation(this);
            GetAllCrlSize(this);
            setTag(this);

            skillArray = JsonMapper.ToObject<Image_Resource[]>(File.ReadAllText("images\\res.json", Encoding.UTF8));//使用这种方法，泛型类的字段，属性必须为public，而且字段名，顺序必须与json文件中对应
            foreach (var temp in skillArray)
            {
                Console.WriteLine(temp);
            }
            //imageList1.Images.Clear();
            //for (int i=1;i<= skillArray[0].number; i++)
            //{
            //    imageList1.Images.Add(Image.FromFile(skillArray[0].path + skillArray[0].prefix+string.Format("{0:00}.bmp", i)));
            //    HOperatorSet.ReadImage(out ImageArrary[i-1], skillArray[0].path + skillArray[0].prefix + string.Format("{0:00}.bmp", i));

            //}
            for (int i = 0; i < skillArray.Length; i++)
            {
                cbSampleData.Items.Add(skillArray[i].name);

            }

        }

        private void cbSampleData_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_X.Text= skillArray[cbSampleData.SelectedIndex].row1.ToString();
            this.txt_Y.Text = skillArray[cbSampleData.SelectedIndex].column1.ToString();
            this.txt_Width.Text = skillArray[cbSampleData.SelectedIndex].row2.ToString();
            this.txt_Height.Text = skillArray[cbSampleData.SelectedIndex].column2.ToString();

        }
    }
}
