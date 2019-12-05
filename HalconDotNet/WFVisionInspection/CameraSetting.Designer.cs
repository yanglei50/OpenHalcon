namespace WFVisionInspection
{
    partial class CameraSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_camera_selector = new System.Windows.Forms.Label();
            this.cb_cameraselect = new System.Windows.Forms.ComboBox();
            this.btn_findcamera = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tx_commandparameter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_autowhitebalance = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_camera_selector
            // 
            this.lb_camera_selector.AutoSize = true;
            this.lb_camera_selector.Location = new System.Drawing.Point(28, 39);
            this.lb_camera_selector.Name = "lb_camera_selector";
            this.lb_camera_selector.Size = new System.Drawing.Size(98, 18);
            this.lb_camera_selector.TabIndex = 0;
            this.lb_camera_selector.Text = "相机选择：";
            // 
            // cb_cameraselect
            // 
            this.cb_cameraselect.FormattingEnabled = true;
            this.cb_cameraselect.Items.AddRange(new object[] {
            "1: By User defined Name",
            "2: By Serial Number",
            "3: By Server Name",
            "4: By Model Name",
            "find a GigE-Vision camera server name from its user defined name",
            "detect new CameraLink cameras"});
            this.cb_cameraselect.Location = new System.Drawing.Point(133, 35);
            this.cb_cameraselect.Name = "cb_cameraselect";
            this.cb_cameraselect.Size = new System.Drawing.Size(276, 26);
            this.cb_cameraselect.TabIndex = 1;
            // 
            // btn_findcamera
            // 
            this.btn_findcamera.Location = new System.Drawing.Point(368, 141);
            this.btn_findcamera.Name = "btn_findcamera";
            this.btn_findcamera.Size = new System.Drawing.Size(100, 42);
            this.btn_findcamera.TabIndex = 2;
            this.btn_findcamera.Text = "查找相机";
            this.btn_findcamera.UseVisualStyleBackColor = true;
            this.btn_findcamera.Click += new System.EventHandler(this.btn_findcamera_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tx_commandparameter);
            this.groupBox1.Controls.Add(this.btn_findcamera);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_camera_selector);
            this.groupBox1.Controls.Add(this.cb_cameraselect);
            this.groupBox1.Location = new System.Drawing.Point(21, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机选择";
            // 
            // tx_commandparameter
            // 
            this.tx_commandparameter.Location = new System.Drawing.Point(133, 68);
            this.tx_commandparameter.Name = "tx_commandparameter";
            this.tx_commandparameter.Size = new System.Drawing.Size(276, 28);
            this.tx_commandparameter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "命令参数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_autowhitebalance);
            this.groupBox2.Location = new System.Drawing.Point(513, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 205);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "白平衡";
            // 
            // btn_autowhitebalance
            // 
            this.btn_autowhitebalance.Location = new System.Drawing.Point(91, 68);
            this.btn_autowhitebalance.Name = "btn_autowhitebalance";
            this.btn_autowhitebalance.Size = new System.Drawing.Size(244, 28);
            this.btn_autowhitebalance.TabIndex = 0;
            this.btn_autowhitebalance.Text = "自动白平衡";
            this.btn_autowhitebalance.UseVisualStyleBackColor = true;
            this.btn_autowhitebalance.Click += new System.EventHandler(this.btn_autowhitebalance_Click);
            // 
            // CameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CameraSetting";
            this.Text = "相机参数调节";
            this.Load += new System.EventHandler(this.CameraSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_camera_selector;
        private System.Windows.Forms.ComboBox cb_cameraselect;
        private System.Windows.Forms.Button btn_findcamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tx_commandparameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_autowhitebalance;
    }
}