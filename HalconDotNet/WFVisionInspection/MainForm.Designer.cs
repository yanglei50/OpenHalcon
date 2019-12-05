namespace WFVisionInspection
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvPictureList = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Result_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ktdlb_logs = new KTDUiLib.KTDListBox(this.components);
            this.Stop_button = new System.Windows.Forms.Button();
            this.Start_button = new System.Windows.Forms.Button();
            this.cbSampleData = new System.Windows.Forms.ComboBox();
            this.btn_camerasetting = new System.Windows.Forms.Button();
            this.btn_CurrentImage = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.lb_piclist_desc = new System.Windows.Forms.Label();
            this.sim_timer = new System.Windows.Forms.Timer(this.components);
            this.DisplayVideo_pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_deeplearning = new System.Windows.Forms.RadioButton();
            this.rb_Morphology = new System.Windows.Forms.RadioButton();
            this.btn_grabsample = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayVideo_pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(621, 372);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Tag = "关闭系统";
            this.btnClose.Text = "关闭系统";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(543, 372);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(74, 31);
            this.btnPause.TabIndex = 0;
            this.btnPause.Tag = "暂停系统";
            this.btnPause.Text = "暂停系统";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前产品状态";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mental_01.bmp");
            this.imageList1.Images.SetKeyName(1, "mental_02.bmp");
            this.imageList1.Images.SetKeyName(2, "mental_03.bmp");
            this.imageList1.Images.SetKeyName(3, "mental_04.bmp");
            this.imageList1.Images.SetKeyName(4, "mental_05.bmp");
            this.imageList1.Images.SetKeyName(5, "mental_06.bmp");
            // 
            // lvPictureList
            // 
            this.lvPictureList.LargeImageList = this.imageList1;
            this.lvPictureList.Location = new System.Drawing.Point(25, 260);
            this.lvPictureList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvPictureList.Name = "lvPictureList";
            this.lvPictureList.Size = new System.Drawing.Size(353, 144);
            this.lvPictureList.TabIndex = 2;
            this.lvPictureList.UseCompatibleStateImageBehavior = false;
            this.lvPictureList.SelectedIndexChanged += new System.EventHandler(this.lvPictureList_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 427);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(431, 47);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Result_listView);
            this.splitContainer1.Panel1.Controls.Add(this.ktdlb_logs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Stop_button);
            this.splitContainer1.Panel2.Controls.Add(this.Start_button);
            this.splitContainer1.Panel2.Controls.Add(this.cbSampleData);
            this.splitContainer1.Panel2.Controls.Add(this.btn_camerasetting);
            this.splitContainer1.Panel2.Controls.Add(this.btn_CurrentImage);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(265, 313);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // Result_listView
            // 
            this.Result_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.Result_listView.Location = new System.Drawing.Point(13, 7);
            this.Result_listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Result_listView.Name = "Result_listView";
            this.Result_listView.Size = new System.Drawing.Size(245, 87);
            this.Result_listView.TabIndex = 8;
            this.Result_listView.UseCompatibleStateImageBehavior = false;
            this.Result_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "半径";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "测试结果";
            // 
            // ktdlb_logs
            // 
            this.ktdlb_logs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ktdlb_logs.FormattingEnabled = true;
            this.ktdlb_logs.Location = new System.Drawing.Point(13, 97);
            this.ktdlb_logs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ktdlb_logs.MaxLength = 1000;
            this.ktdlb_logs.Name = "ktdlb_logs";
            this.ktdlb_logs.Size = new System.Drawing.Size(245, 83);
            this.ktdlb_logs.TabIndex = 0;
            // 
            // Stop_button
            // 
            this.Stop_button.Location = new System.Drawing.Point(193, 45);
            this.Stop_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(50, 23);
            this.Stop_button.TabIndex = 2;
            this.Stop_button.Text = "停止";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(139, 45);
            this.Start_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(50, 23);
            this.Start_button.TabIndex = 2;
            this.Start_button.Text = "开始";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // cbSampleData
            // 
            this.cbSampleData.FormattingEnabled = true;
            this.cbSampleData.Location = new System.Drawing.Point(21, 80);
            this.cbSampleData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSampleData.Name = "cbSampleData";
            this.cbSampleData.Size = new System.Drawing.Size(105, 20);
            this.cbSampleData.TabIndex = 1;
            this.cbSampleData.SelectedIndexChanged += new System.EventHandler(this.cbSampleData_SelectedIndexChanged);
            // 
            // btn_camerasetting
            // 
            this.btn_camerasetting.Location = new System.Drawing.Point(139, 9);
            this.btn_camerasetting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_camerasetting.Name = "btn_camerasetting";
            this.btn_camerasetting.Size = new System.Drawing.Size(104, 23);
            this.btn_camerasetting.TabIndex = 0;
            this.btn_camerasetting.Text = "相机参数调节";
            this.btn_camerasetting.UseVisualStyleBackColor = true;
            this.btn_camerasetting.Click += new System.EventHandler(this.btn_camerasetting_Click);
            // 
            // btn_CurrentImage
            // 
            this.btn_CurrentImage.Location = new System.Drawing.Point(139, 75);
            this.btn_CurrentImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CurrentImage.Name = "btn_CurrentImage";
            this.btn_CurrentImage.Size = new System.Drawing.Size(104, 23);
            this.btn_CurrentImage.TabIndex = 0;
            this.btn_CurrentImage.Text = "检测当前图像";
            this.btn_CurrentImage.UseVisualStyleBackColor = true;
            this.btn_CurrentImage.Click += new System.EventHandler(this.btn_CurrentImage_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 45);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "设备参数调节";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "检测参数调节";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(41, 114);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(351, 142);
            this.hWindowControl1.TabIndex = 7;
            this.hWindowControl1.Visible = false;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(351, 142);
            this.hWindowControl1.HInitWindow += new HalconDotNet.HInitWindowEventHandler(this.hWindowControl1_HInitWindow);
            this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
            // 
            // lb_piclist_desc
            // 
            this.lb_piclist_desc.AutoSize = true;
            this.lb_piclist_desc.Location = new System.Drawing.Point(27, 245);
            this.lb_piclist_desc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_piclist_desc.Name = "lb_piclist_desc";
            this.lb_piclist_desc.Size = new System.Drawing.Size(89, 12);
            this.lb_piclist_desc.TabIndex = 6;
            this.lb_piclist_desc.Text = "当前选中的....";
            // 
            // DisplayVideo_pictureBox
            // 
            this.DisplayVideo_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayVideo_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayVideo_pictureBox.Location = new System.Drawing.Point(29, 47);
            this.DisplayVideo_pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DisplayVideo_pictureBox.Name = "DisplayVideo_pictureBox";
            this.DisplayVideo_pictureBox.Size = new System.Drawing.Size(348, 151);
            this.DisplayVideo_pictureBox.TabIndex = 7;
            this.DisplayVideo_pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_deeplearning);
            this.groupBox1.Controls.Add(this.rb_Morphology);
            this.groupBox1.Location = new System.Drawing.Point(443, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(243, 35);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测模式";
            // 
            // rb_deeplearning
            // 
            this.rb_deeplearning.AutoSize = true;
            this.rb_deeplearning.Location = new System.Drawing.Point(131, 16);
            this.rb_deeplearning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rb_deeplearning.Name = "rb_deeplearning";
            this.rb_deeplearning.Size = new System.Drawing.Size(71, 16);
            this.rb_deeplearning.TabIndex = 9;
            this.rb_deeplearning.TabStop = true;
            this.rb_deeplearning.Text = "深度学习";
            this.rb_deeplearning.UseVisualStyleBackColor = true;
            this.rb_deeplearning.CheckedChanged += new System.EventHandler(this.rb_deeplearning_CheckedChanged);
            // 
            // rb_Morphology
            // 
            this.rb_Morphology.AutoSize = true;
            this.rb_Morphology.Location = new System.Drawing.Point(33, 16);
            this.rb_Morphology.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rb_Morphology.Name = "rb_Morphology";
            this.rb_Morphology.Size = new System.Drawing.Size(59, 16);
            this.rb_Morphology.TabIndex = 0;
            this.rb_Morphology.TabStop = true;
            this.rb_Morphology.Text = "形态学";
            this.rb_Morphology.UseVisualStyleBackColor = true;
            this.rb_Morphology.CheckedChanged += new System.EventHandler(this.rb_Morphology_CheckedChanged);
            // 
            // btn_grabsample
            // 
            this.btn_grabsample.Location = new System.Drawing.Point(465, 373);
            this.btn_grabsample.Margin = new System.Windows.Forms.Padding(2);
            this.btn_grabsample.Name = "btn_grabsample";
            this.btn_grabsample.Size = new System.Drawing.Size(74, 31);
            this.btn_grabsample.TabIndex = 0;
            this.btn_grabsample.Tag = "抓取样本";
            this.btn_grabsample.Text = "抓取样本";
            this.btn_grabsample.UseVisualStyleBackColor = true;
            this.btn_grabsample.Click += new System.EventHandler(this.btn_grabsample_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.DisplayVideo_pictureBox);
            this.Controls.Add(this.lb_piclist_desc);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lvPictureList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_grabsample);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "视觉检测系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayVideo_pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lvPictureList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_camerasetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lb_piclist_desc;
        private System.Windows.Forms.Timer sim_timer;
        private System.Windows.Forms.Button btn_CurrentImage;
        private HalconDotNet.HWindowControl hWindowControl1;
        private KTDUiLib.KTDListBox ktdlb_logs;
        private System.Windows.Forms.ComboBox cbSampleData;
        private System.Windows.Forms.PictureBox DisplayVideo_pictureBox;
        private System.Windows.Forms.ListView Result_listView;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_deeplearning;
        private System.Windows.Forms.RadioButton rb_Morphology;
        private System.Windows.Forms.Button btn_grabsample;
    }
}

