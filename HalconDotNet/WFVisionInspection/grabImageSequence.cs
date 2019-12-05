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
using Matrox.MatroxImagingLibrary;
using System.Runtime.InteropServices;

namespace WFVisionInspection
{
    public partial class grabImageSequence : Form
    {
        #region define parameter for autosize windows
        private ArrayList CrlLocationX = new ArrayList();
        //用以存储窗体中所有的控件原始位置
        private ArrayList CrlLocationY = new ArrayList();

        private ArrayList CrlSizeHeight = new ArrayList();
        //用以存储窗体中所有的控件原始位置
        private ArrayList CrlSizeWidth = new ArrayList();

        private double FormSizeChangedX;
        //用以存储相关父窗体/容器的水平变化量
        private double FormSizeChangedY;

        private int FormSizeHeight;
        //用以存储窗体中所有的控件原始的水平尺寸
        //用以存储窗体中所有的控件原始的垂直尺寸
        private int FormSizeWidth;

        private ArrayList InitialCrl = new ArrayList();//用以存储窗体中所有的控件名称
                                                       //用以存储窗体原始的水平尺寸
                                                       //用以存储窗体原始的垂直尺寸
                                                       //用以存储相关父窗体/容器的垂直变化量 
        private int Wcounter = 0;//为防止递归遍历控件时产生混乱，故专门设定一个全局计数器
        private float X;
        private float Y;
        #endregion
        #region define matrox MIL interface
        // Sequence file name
        private const string SEQUENCE_FILE = MIL.M_TEMP_DIR + "MilSequence.avi";

        // Image acquisition scale.
        private const double GRAB_SCALE = 1.0;

        // Quantization factor to use during the compression.
        // Valid values are 1 to 99 (higher to lower quality).
        private const int COMPRESSION_Q_FACTOR = 50;

        // Annotation flag. Set to false to draw the frame number in the saved image.
        private static readonly MIL_INT FRAME_NUMBER_ANNOTATION = MIL.M_YES;

        // Archive flag. Set to false to disable AVI Import/Export to disk.
        private static bool SAVE_SEQUENCE_TO_DISK = true;

        // Maximum number of images for the multiple buffering grab.
        private const int NB_GRAB_IMAGE_MAX = 22;
        public class HookDataObject // User's archive function hook data structure.
        {
            public MIL_ID MilSystem;
            public MIL_ID MilDisplay;
            public MIL_ID MilImageDisp;
            public MIL_ID MilCompressedImage;
            public int NbGrabbedFrames;
            public int NbArchivedFrames;
            public bool SaveSequenceToDisk;
        };
        MIL_ID MilApplication = MIL.M_NULL;
        MIL_ID MilRemoteApplication = MIL.M_NULL;   // Remote Application identifier if running on a remote computer
        MIL_ID MilSystem = MIL.M_NULL;
        MIL_ID MilDigitizer = MIL.M_NULL;
        MIL_ID MilDisplay = MIL.M_NULL;
        MIL_ID MilImageDisp = MIL.M_NULL;
        MIL_ID[] MilGrabImages = new MIL_ID[NB_GRAB_IMAGE_MAX];
        MIL_ID MilCompressedImage = MIL.M_NULL;
        ConsoleKeyInfo Selection = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);

        int NbFrames = 0;
        int n = 0;
        int NbFramesReplayed = 0;
        double FrameRate = 0;
        double TimeWait = 0;
        double TotalReplay = 0;
        double GrabScale = GRAB_SCALE;
        HookDataObject UserHookData = new HookDataObject();
        MIL_INT LicenseModules = 0;
        MIL_INT FrameCount = 0;
        MIL_INT FrameMissed = 0;
        MIL_INT CompressAttribute = 0;
        private const int STRING_LENGTH_MAX = 20;
        private const int STRING_POS_X = 20;
        private const int STRING_POS_Y = 20;

        #endregion
        public grabImageSequence()
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

        private void grabImageSequence_Load(object sender, EventArgs e)
        {
            X = this.Width;
            Y = this.Height;
            GetInitialFormSize();
            GetAllCrlLocation(this);
            GetAllCrlSize(this);
            setTag(this);



        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get a handle to the DigHookUserData object in the managed heap, we will use this 
            // handle to get the object back in the callback function
            GCHandle UserHookDataHandle = GCHandle.Alloc(UserHookData);
            MIL_DIG_HOOK_FUNCTION_PTR UserHookFunctionDelegate = new MIL_DIG_HOOK_FUNCTION_PTR(ArchiveFunction);

            // Acquire the sequence. The processing hook function will
            // be called for each image grabbed to archive and display it. 
            // If sequence is not saved to disk, stop after NbFrames.
            MIL.MdigProcess(MilDigitizer, MilGrabImages, NbFrames, SAVE_SEQUENCE_TO_DISK ? MIL.M_START : MIL.M_SEQUENCE, MIL.M_DEFAULT, UserHookFunctionDelegate, GCHandle.ToIntPtr(UserHookDataHandle));

            // Wait for a key press.
            //Console.WriteLine("Press <Enter> to continue.");
            //Console.WriteLine();
            //Console.ReadKey(true);

            // Stop the sequence acquisition.
            MIL.MdigProcess(MilDigitizer, MilGrabImages, NbFrames, MIL.M_STOP, MIL.M_DEFAULT, UserHookFunctionDelegate, GCHandle.ToIntPtr(UserHookDataHandle));

            // Free the GCHandle when no longer used
            UserHookDataHandle.Free();

            // Read and print final statistics.
            MIL.MdigInquire(MilDigitizer, MIL.M_PROCESS_FRAME_COUNT, ref FrameCount);
            MIL.MdigInquire(MilDigitizer, MIL.M_PROCESS_FRAME_RATE, ref FrameRate);
            MIL.MdigInquire(MilDigitizer, MIL.M_PROCESS_FRAME_MISSED, ref FrameMissed);

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("{0} frames archived ({1} missed), at {2:0.0} frames/sec ({3:0.0}ms/frame).", UserHookData.NbArchivedFrames, FrameMissed, FrameRate, 1000.0 / FrameRate);

            // Sequence file closing if required.
            if (SAVE_SEQUENCE_TO_DISK)
            {
                MIL.MbufExportSequence(SEQUENCE_FILE, MIL.M_DEFAULT, MIL.M_NULL, MIL.M_NULL, FrameRate, MIL.M_CLOSE);
            }

            // Free all allocated buffers.
            MIL.MbufFree(MilImageDisp);
            for (n = 0; n < NbFrames; n++)
            {
                MIL.MbufFree(MilGrabImages[n]);
            }

            if (MilCompressedImage != MIL.M_NULL)
            {
                MIL.MbufFree(MilCompressedImage);
            }

            // Free defaults.
            MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MilDigitizer, MIL.M_NULL);
        }
        //}
        // User's archive function called each time a new buffer is grabbed.
        // -------------------------------------------------------------------*/

        // Local defines for the annotations.

        static MIL_INT ArchiveFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {
            GCHandle HookDataHandle = GCHandle.FromIntPtr(HookDataPtr);
            HookDataObject UserHookDataPtr = HookDataHandle.Target as HookDataObject;
            MIL_ID ModifiedImage = 0;

            // Retrieve the MIL_ID of the grabbed buffer.
            MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedImage);

            // Increment the frame count.
            UserHookDataPtr.NbGrabbedFrames++;

            // Draw the frame count in the image if enabled.
            if (FRAME_NUMBER_ANNOTATION == MIL.M_YES)
            {
                MIL.MgraText(MIL.M_DEFAULT, ModifiedImage, STRING_POS_X, STRING_POS_Y, UserHookDataPtr.NbGrabbedFrames.ToString());
            }

            // Compress the new image.
            if (UserHookDataPtr.MilCompressedImage != MIL.M_NULL)
            {
                MIL.MbufCopy(ModifiedImage, UserHookDataPtr.MilCompressedImage);
            }

            // Archive the new image.
            if (UserHookDataPtr.SaveSequenceToDisk)
            {
                MIL_ID ImageToExport;
                if (UserHookDataPtr.MilCompressedImage != MIL.M_NULL)
                {
                    ImageToExport = UserHookDataPtr.MilCompressedImage;
                }
                else
                {
                    ImageToExport = ModifiedImage;
                }

                MIL.MbufExportSequence(SEQUENCE_FILE, MIL.M_DEFAULT, ref ImageToExport, 1, MIL.M_DEFAULT, MIL.M_WRITE);
                UserHookDataPtr.NbArchivedFrames++;
                Console.Write("Frame #{0}               \r", UserHookDataPtr.NbArchivedFrames);
            }



            // Copy the new grabbed image to the display.
            MIL.MbufCopy(ModifiedImage, UserHookDataPtr.MilImageDisp);

            return 0;
        }
    }
}
