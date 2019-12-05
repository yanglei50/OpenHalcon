using HalconDotNet;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WFVisionInspection.JsonUtil;

namespace WFVisionInspection
{
    public partial class MainForm : Form
    {
        private HTuple WindowID;
        private HObject Image4HObject;

        //存放图像的数组
        private HObject[] ImageArrary = new HObject[100];

        //线程对象
        private Thread ThreadObject;                                //正常测试线程

        //线程停止标记
        private bool Thread_Stop = false;                           //正常测试线程停止标记

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
        private int defect_detection_method=1;
        public MainForm()
        {
            InitializeComponent();

            Image4HObject = new HObject();

            CreateHalconWindow();

            //LoadBatchImage();

            //LoadImage();
            ThreadObject = new Thread(new ThreadStart(PlayThread));

            //允许跨线程访问界面控件
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

        }
        //线程函数
        public void PlayThread()
        {
            int i = 0;
            Thread_Stop = false;
            HTuple width = null, height = null;
            while (!Thread_Stop)
            {

                HOperatorSet.DispObj(ImageArrary[i], WindowID);

                //获取图像大小
                HOperatorSet.GetImageSize(ImageArrary[i], out width, out height);


                //通过改变图像的缩放来适应图像在窗口的正常显示
                HOperatorSet.SetPart(WindowID, 0, 0, height, width);

                double CircleRadius = ImageAlgorithmII(ImageArrary[i]);
                if (CircleRadius >= 311 && CircleRadius <= 313)//PASS
                {
                    //更新结果到UI上
                    UpdateTestResult(i.ToString() + "@" + CircleRadius.ToString() + "@PASS");

                    //保存数据
                    SaveResult("编号,半径,测试结果", i.ToString() + "," + CircleRadius.ToString() + ",PASS");

                    //保存图像
                    string FileName = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒fff毫秒");
                    HOperatorSet.WriteImage(ImageArrary[i], "bmp", 0, "images/result/" + FileName + ".bmp");

                }
                else//NG
                {
                    //更新结果到UI上
                    UpdateTestResult(i.ToString() + "@" + CircleRadius.ToString() + "@FAIL");

                    SaveResult("编号,半径,测试结果", i.ToString() + "," + CircleRadius.ToString() + ",NG");

                    //保存图像
                    string FileName = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒fff毫秒");
                    HOperatorSet.WriteImage(ImageArrary[i], "bmp", 0, "images/result/" + FileName + ".bmp");

                }

                Thread.Sleep(300);

                i++;

                if (i >= 8)
                {
                    i = 0;
                }
            }

        }


        private void UpdateTestResult(string Result)
        {
            string[] SubResult = Result.Split('@');
            ListViewItem lt = new ListViewItem(SubResult[0]);
            lt.SubItems.Add(SubResult[1]);
            lt.SubItems.Add(SubResult[2]);
            this.Result_listView.Items.Add(lt);

        }

        public void SaveResult(string ResulteHeader, string ResultContent)
        {


            string FileName = DateTime.Now.ToString("yyyy年MM月dd日");
            bool flag = File.Exists(@"Result/" + FileName + ".csv");
            if (!flag)
            {
                WriteCsv(@"Result/" + FileName + ".csv", ResulteHeader);
                WriteCsv(@"Result/" + FileName + ".csv", ResultContent);

            }
            else
            {
                WriteCsv(@"Result/" + FileName + ".csv", ResultContent);
            }


        }

        public void WriteCsv(string FilePath, string WriteContent)
        {
            //打开一个文件流
            FileStream fs = new FileStream(FilePath, FileMode.Append);
            //处理文本文件的类
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(WriteContent + "\n");
            sw.Close();
            fs.Close();
        }


        //批量加载图像
        public void LoadBatchImage()
        {
            for (int i = 0; i < 8; i++)
            {
                HOperatorSet.ReadImage(out ImageArrary[i], "images\\rotate\\" + i.ToString() + ".bmp");

            }
        }

        public void CreateHalconWindow()
        {
            HTuple FatherWindow = this.DisplayVideo_pictureBox.Handle;

            //设置窗口的背景颜色
            HOperatorSet.SetWindowAttr("background_color", "green");

            HOperatorSet.OpenWindow(0, 0, this.DisplayVideo_pictureBox.Width, this.DisplayVideo_pictureBox.Height, FatherWindow, "visible", "", out WindowID);
        }

        public void LoadImage()
        {
            //读取一张图像
            HOperatorSet.ReadImage(out Image4HObject, "1.bmp");

            HTuple width = null, height = null;

            //获取图像大小
            HOperatorSet.GetImageSize(Image4HObject, out width, out height);

            //设置对象显示的颜色
            HOperatorSet.SetColor(WindowID, "yellow");

            //通过改变图像的缩放来适应图像在窗口的正常显示
            HOperatorSet.SetPart(WindowID, 0, 0, height, width);

            //在窗口上显示图像
            HOperatorSet.DispObj(Image4HObject, WindowID);


        }

        public void GetAllCrlLocation(Control CrlContainer)//获得并存储窗体中各控件的初始位置
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                Console.WriteLine(iCrl.Name+":"+iCrl.Text+"-("+ iCrl.Location.X+","+ iCrl.Location.Y+")");
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

        private void btn_camerasetting_Click(object sender, EventArgs e)
        {
            CameraSetting cs = new CameraSetting();
            cs.Show();
        }

        private void btn_CurrentImage_Click(object sender, EventArgs e)
        {
            
            Console.Out.WriteLine(cbSampleData.SelectedIndex+":"+cbSampleData.SelectedItem);
            Console.Out.WriteLine(lvPictureList.FocusedItem.Index + ":" + lvPictureList.FocusedItem.Text);
            switch (cbSampleData.SelectedIndex)
            {
                case 0:
                    hdev_export.action(hWindowControl1, skillArray[0].path, skillArray[0].prefix, lvPictureList.FocusedItem.Text);
                    break;
                case 1:
                    hdev_export.action(hWindowControl1, skillArray[1].path, skillArray[1].prefix, lvPictureList.FocusedItem.Text);
                    break;
                case 2:
                    hdev_export.action(hWindowControl1, skillArray[2].path, skillArray[2].prefix, lvPictureList.FocusedItem.Text);
                    break;
                case 3:
                    hdev_export.action(hWindowControl1, skillArray[2].path, skillArray[3].prefix, lvPictureList.FocusedItem.Text);
                    break;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hWindowControl1_HInitWindow(object sender, EventArgs e)
        {
            //HTuple width, height;
            //hdev_export.hv_ExpDefaultWinHandle = hSmartWindowControlWPF1.HalconID;
            //HOperatorSet.ReadImage(out background_image, "fabrik");
            ////read image       
            //HOperatorSet.GetImageSize(background_image, out width, out height);
            //hSmartWindowControlWPF1.HalconWindow.SetPart(0.0, 0.0, height - 1, width - 1);
            //hSmartWindowControlWPF1.HalconWindow.AttachBackgroundToWindow(new HImage(background_image));
            ////show image       
            //display_results_delegate = new DisplayResultsDelegate(() =>       {           lock(image_lock)           {               if (ho_EdgeAmplitude != null)                   hdev_export.display_results(ho_EdgeAmplitude);           }       });
            ////using lambda to define an anonymous delegate       
            //cb = new HDrawingObject.HDrawingObjectCallback(DisplayCallback); 
        }

        private void lvPictureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPictureList.SelectedItems.Count > 0)
            {
                int index = 0;
                index = this.lvPictureList.SelectedItems[0].ImageIndex;

                this.lb_piclist_desc.Text = "你选择的图片是：" + this.lvPictureList.SelectedItems[0].Text;
                hdev_export.action_load(hWindowControl1, skillArray[cbSampleData.SelectedIndex].path+ lvPictureList.SelectedItems[0].Text);
                //lvPictureList.Items[index]
                DisplayImageInPictureBox(index);
                //this.pb_CurrentPicture.BackgroundImageLayout= System.Windows.Forms.ImageLayout.Stretch;
                //this.pb_CurrentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                //this.pb_CurrentPicture.Image = Image.FromFile(filename[index]);
            }
        }
        private void DisplayImageInPictureBox(int i)
        {
            HTuple width, height;
            HOperatorSet.DispObj(ImageArrary[i], WindowID);

            //获取图像大小
            HOperatorSet.GetImageSize(ImageArrary[i], out width, out height);


            //通过改变图像的缩放来适应图像在窗口的正常显示
            HOperatorSet.SetPart(WindowID, 0, 0, height, width);

            double CircleRadius = ImageAlgorithmII(ImageArrary[i]);
            if (CircleRadius >= 311 && CircleRadius <= 313)//PASS
            {
                //更新结果到UI上
                UpdateTestResult(i.ToString() + "@" + CircleRadius.ToString() + "@PASS");

                //保存数据
                SaveResult("编号,半径,测试结果", i.ToString() + "," + CircleRadius.ToString() + ",PASS");

                //保存图像
                string FileName = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒fff毫秒");
                HOperatorSet.WriteImage(ImageArrary[i], "bmp", 0, "images/" + FileName + ".bmp");

            }
            else//NG
            {
                //更新结果到UI上
                UpdateTestResult(i.ToString() + "@" + CircleRadius.ToString() + "@FAIL");

                SaveResult("编号,半径,测试结果", i.ToString() + "," + CircleRadius.ToString() + ",NG");

                //保存图像
                string FileName = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒fff毫秒");
                HOperatorSet.WriteImage(ImageArrary[i], "bmp", 0, "images/" + FileName + ".bmp");

            }

            Thread.Sleep(300);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetInitialFormSize();
            //this.AutoScroll = true;
            //this.SetAutoSizeMode(FormSizeWidth,FormSizeHeight);
            //this.AutoScrollMinSize.Width = FormSizeWidth;
            //this.AutoScrollMinSize.Height = FormSizeHeight;
            GetAllCrlLocation(this);
            GetAllCrlSize(this);
            defect_detection_method = 0;//图像形态学方法
            rb_Morphology.Checked = true;
            rb_deeplearning.Checked = false;
            //this.Resize += new EventHandler(MainForm_Resize);

            X = this.Width;
            Y = this.Height;

            /*
            sim_timer = new System.Windows.Forms.Timer();
            sim_timer.Interval = 1000;
            sim_timer.Enabled = true;
            sim_timer.Tick += new EventHandler(sim_timer_Tick);
            */
            setTag(this);

            imageList1.Dispose();
            imageList1 = new ImageList();

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
            for (int i=0;i< skillArray.Length; i++)
            {
                cbSampleData.Items.Add(skillArray[i].name);

            }
            /*
             * 2018.09拍摄钢管
             * 2018.08东莞样图
             * 2018.06塑料样图
             */

            cbSampleData.SelectedIndex = 2;
            //this.lvPictureList.View = View.LargeIcon;
            //this.lvPictureList.LargeImageList = this.imageList1;
            //this.lvPictureList.BeginUpdate();
            ////数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度    
            //for (int i = 0; i < skillArray[0].number; i++)//添加10行数据  
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    lvi.ImageIndex = i;
            //    //通过与imageList绑定，显示imageList中第i项图标        
            //    lvi.Text = skillArray[0].prefix + string.Format("{0:00}.bmp", i+1);
            //    lvi.Text = skillArray[0].prefix + string.Format("{0:00}.bmp", i + 1);
            //    this.lvPictureList.Items.Add(lvi);
            //}
            //this.lvPictureList.EndUpdate();
            hdev_export = new HDevelopExport(hWindowControl1.HalconWindow);


            // hdev_export = new HDevelopExport();
            //MainForm_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            this.Text = this.Width.ToString() + " " + this.Height.ToString();
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

            HTuple FatherWindow = this.DisplayVideo_pictureBox.Handle;
            HOperatorSet.CloseWindow(WindowID);
            HOperatorSet.OpenWindow(0, 0, this.DisplayVideo_pictureBox.Width, this.DisplayVideo_pictureBox.Height, FatherWindow, "visible", "", out WindowID);
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

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        //private void sim_timer_Tick(object sender, EventArgs e)
        //{
        //    if (this.lvPictureList.Items.Count < 12)
        //    {
        //        this.lvPictureList.View = View.LargeIcon;

        //        this.lvPictureList.LargeImageList = this.imageList1;
        //        this.lvPictureList.BeginUpdate();
        //        //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度    
        //        for (int i = 0; i < 6; i++)//添加10行数据  
        //        {
        //            ListViewItem lvi = new ListViewItem();
        //            lvi.ImageIndex = i;
        //            //通过与imageList绑定，显示imageList中第i项图标        
        //            lvi.Text = "subitem" + (i + lvPictureList.Items.Count).ToString();
        //            lvi.Text = "item" + (i + lvPictureList.Items.Count).ToString();
        //            this.lvPictureList.Items.Add(lvi);
        //        }
        //        this.lvPictureList.EndUpdate();
        //        //结束数据处理，UI界面一次性绘制。 
        //    }
        //}

        private void cbSampleData_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageList1.Dispose();
            imageList1.Images.Clear();
            for (int i = 1; i <= skillArray[cbSampleData.SelectedIndex].number; i++)
            {
                if(ImageArrary[i - 1]!=null)
                    ImageArrary[i - 1].Dispose();
                ImageArrary[i - 1] = null;
                HOperatorSet.ReadImage(out ImageArrary[i - 1], skillArray[cbSampleData.SelectedIndex].path + skillArray[cbSampleData.SelectedIndex].prefix + string.Format("{0:00}.bmp", i));
                imageList1.Images.Add(Image.FromFile(skillArray[cbSampleData.SelectedIndex].path + skillArray[cbSampleData.SelectedIndex].prefix + string.Format("{0:00}.bmp", i)));
            }
            lvPictureList.Clear();
            lvPictureList.Items.Clear();
            this.lvPictureList.View = View.LargeIcon;
            this.lvPictureList.LargeImageList = this.imageList1;
            this.lvPictureList.BeginUpdate();
            //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度    
            for (int i = 0; i < skillArray[cbSampleData.SelectedIndex].number; i++)//添加10行数据  
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                //通过与imageList绑定，显示imageList中第i项图标        
                lvi.Text = skillArray[cbSampleData.SelectedIndex].prefix + string.Format("{0:00}.bmp", i + 1);
                lvi.Text = skillArray[cbSampleData.SelectedIndex].prefix + string.Format("{0:00}.bmp", i + 1);
                this.lvPictureList.Items.Add(lvi);
            }
            
            this.lvPictureList.EndUpdate();
        }

        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {

        }

        private double ImageAlgorithmII(HObject ho_ResultImage)
        {
            // Local iconic variables 

            HObject ho_ResultRegion = null;
            HObject ho_ResultConnectedRegions = null, ho_ResultSelectedRegions = null;
            HObject ho_ResultCircle = null, ho_ResultContour = null;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null;
            HTuple hv_MetrologyHandle = null, hv_CircleRadiusTolerance = null;
            HTuple hv_NewRadius = null;
            HTuple hv_ResultArea = new HTuple(), hv_ResultRow = new HTuple();
            HTuple hv_ResultColumn = new HTuple(), hv_MetrologyCircleIndice = new HTuple();
            HTuple hv_CircleRadiusResult = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ResultRegion);
            HOperatorSet.GenEmptyObj(out ho_ResultConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ResultSelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ResultCircle);
            HOperatorSet.GenEmptyObj(out ho_ResultContour);

            HOperatorSet.GetImageSize(ho_ResultImage, out hv_Width, out hv_Height);

            //创建测量模型
            HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);

            //设置测量对象图像大小
            HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
            //
            hv_CircleRadiusTolerance = 100;

            //圆半径
            hv_NewRadius = 324;


            //阈值图像
            ho_ResultRegion.Dispose();
            HOperatorSet.Threshold(ho_ResultImage, out ho_ResultRegion, 0, 60);

            //区域连通处理
            ho_ResultConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_ResultRegion, out ho_ResultConnectedRegions);

            //根据面积和圆度来过滤想要的圆区域
            ho_ResultSelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_ResultConnectedRegions, out ho_ResultSelectedRegions,
                       (new HTuple("area")).TupleConcat("roundness"), "and", (new HTuple(250000)).TupleConcat(
                       0.9), (new HTuple(320000)).TupleConcat(1));

            //获取圆的中心坐标和面积
            HOperatorSet.AreaCenter(ho_ResultSelectedRegions, out hv_ResultArea, out hv_ResultRow, out hv_ResultColumn);


            HOperatorSet.SetColor(WindowID, "green");

            //设置区域的填充模式
            HOperatorSet.SetDraw(WindowID, "margin");

            //显示图像
            HOperatorSet.DispObj(ho_ResultImage, WindowID);

            if (hv_ResultArea.Length!=0)
            {
                //生成圆
                ho_ResultCircle.Dispose();
                HOperatorSet.GenCircle(out ho_ResultCircle, hv_ResultRow, hv_ResultColumn, hv_NewRadius);
                //添加圆到测量模型里
                HOperatorSet.AddMetrologyObjectCircleMeasure(hv_MetrologyHandle, hv_ResultRow,
                            hv_ResultColumn, hv_NewRadius, hv_CircleRadiusTolerance, 5, 1.5, 30, (new HTuple("measure_transition")).TupleConcat(
                            "min_score"), (new HTuple("all")).TupleConcat(0.4), out hv_MetrologyCircleIndice);

                //测量并拟合几何形状
                HOperatorSet.ApplyMetrologyModel(ho_ResultImage, hv_MetrologyHandle);

                //获取测量模型里的测量轮廓
                ho_ResultContour.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_ResultContour, hv_MetrologyHandle, "all", "all", 1.5);

                //获取测量模型里的测量结果
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_MetrologyCircleIndice, "all", "result_type", "radius", out hv_CircleRadiusResult);

                //显示测量轮廓
                HOperatorSet.DispObj(ho_ResultContour, WindowID);

                //设置文字显示位置
                HOperatorSet.SetTposition(WindowID, 0, 0);
                //* 在窗口指定位置输出文字信息
                HOperatorSet.WriteString(WindowID, "圆外径:" + hv_CircleRadiusResult);


                //清除测量模型
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                ho_ResultRegion.Dispose();
                ho_ResultConnectedRegions.Dispose();
                ho_ResultSelectedRegions.Dispose();
                ho_ResultCircle.Dispose();
                ho_ResultContour.Dispose();

                return hv_CircleRadiusResult.D;
            }else
            {
                ho_ResultRegion.Dispose();
                ho_ResultConnectedRegions.Dispose();
                ho_ResultSelectedRegions.Dispose();
                ho_ResultCircle.Dispose();
                ho_ResultContour.Dispose();

                return 0;
            }
          

           
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            //开启正常测试线程
            if (ThreadObject.ThreadState == System.Threading.ThreadState.Unstarted)
            {
                ThreadObject.Start();

            }

            if ((ThreadObject.ThreadState == System.Threading.ThreadState.Stopped) || (ThreadObject.ThreadState == System.Threading.ThreadState.Aborted))
            {
                ThreadObject = new Thread(new ThreadStart(PlayThread));
                ThreadObject.Start();

            }
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            Thread_Stop = true;
        }

        private void rb_Morphology_CheckedChanged(object sender, EventArgs e)
        {
            //rb_Morphology.Checked = true;
            //rb_deeplearning.Checked = false;
            defect_detection_method = 0;//图像形态学方法
        }

        private void rb_deeplearning_CheckedChanged(object sender, EventArgs e)
        {
            //rb_Morphology.Checked = false;
            //rb_deeplearning.Checked = true;
            defect_detection_method = 1;//深度学习方法
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetectionParameterSetting ds = new DetectionParameterSetting();
            ds.Show();
        }

        private void btn_grabsample_Click(object sender, EventArgs e)
        {
            grabImageSequence grab = new grabImageSequence();
            grab.Show();
        }
    }
}
