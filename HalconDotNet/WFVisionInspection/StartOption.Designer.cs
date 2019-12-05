namespace WFVisionInspection
{
    partial class StartOption
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
            this.btn_acquire = new System.Windows.Forms.Button();
            this.btn_train = new System.Windows.Forms.Button();
            this.btn_recog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_acquire
            // 
            this.btn_acquire.Location = new System.Drawing.Point(45, 72);
            this.btn_acquire.Name = "btn_acquire";
            this.btn_acquire.Size = new System.Drawing.Size(75, 99);
            this.btn_acquire.TabIndex = 0;
            this.btn_acquire.Text = "数据获取";
            this.btn_acquire.UseVisualStyleBackColor = true;
            this.btn_acquire.Click += new System.EventHandler(this.btn_acquire_Click);
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(140, 72);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(75, 99);
            this.btn_train.TabIndex = 0;
            this.btn_train.Text = "数据训练";
            this.btn_train.UseVisualStyleBackColor = true;
            // 
            // btn_recog
            // 
            this.btn_recog.Location = new System.Drawing.Point(240, 72);
            this.btn_recog.Name = "btn_recog";
            this.btn_recog.Size = new System.Drawing.Size(75, 99);
            this.btn_recog.TabIndex = 0;
            this.btn_recog.Text = "数据识别";
            this.btn_recog.UseVisualStyleBackColor = true;
            // 
            // StartOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 261);
            this.Controls.Add(this.btn_recog);
            this.Controls.Add(this.btn_train);
            this.Controls.Add(this.btn_acquire);
            this.Name = "StartOption";
            this.Text = "StartOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_acquire;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Button btn_recog;
    }
}