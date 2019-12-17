namespace HalconDotNet
{
    partial class MyHalconControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyHalconControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MyHalconControl";
            this.Size = new System.Drawing.Size(388, 322);
            this.Load += new System.EventHandler(this.MyHWindowControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyHWindowControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyHWindowControl_MouseDown);
            this.MouseHover += new System.EventHandler(this.MyHWindowControl_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyHWindowControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyHWindowControl_MouseUp);
            this.Resize += new System.EventHandler(this.MyHWindowControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
