namespace surface_scratch
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.myHalconControl1 = new HalconDotNet.MyHalconControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始处理...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myHalconControl1
            // 
            this.myHalconControl1.BackColor = System.Drawing.Color.Black;
            this.myHalconControl1.BorderColor = System.Drawing.Color.Black;
            this.myHalconControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.myHalconControl1.Location = new System.Drawing.Point(54, 83);
            this.myHalconControl1.Name = "myHalconControl1";
            this.myHalconControl1.Size = new System.Drawing.Size(388, 322);
            this.myHalconControl1.TabIndex = 2;
            this.myHalconControl1.WindowSize = new System.Drawing.Size(320, 240);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 592);
            this.Controls.Add(this.myHalconControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private HalconDotNet.MyHalconControl myHalconControl1;
    }
}

