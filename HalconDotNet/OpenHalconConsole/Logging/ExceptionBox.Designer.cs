namespace OpenHalconConsole.Logging
{
    partial class ExceptionBox
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
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.copyErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(199, 56);
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.ReadOnly = true;
            this.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.exceptionTextBox.Size = new System.Drawing.Size(448, 184);
            this.exceptionTextBox.TabIndex = 1;
            this.exceptionTextBox.Text = "textBoxExceptionText";
            this.exceptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exceptionTextBox_KeyDown);
            // 
            // copyErrorCheckBox
            // 
            this.copyErrorCheckBox.AutoSize = true;
            this.copyErrorCheckBox.Checked = true;
            this.copyErrorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyErrorCheckBox.Location = new System.Drawing.Point(230, 373);
            this.copyErrorCheckBox.Name = "copyErrorCheckBox";
            this.copyErrorCheckBox.Size = new System.Drawing.Size(78, 16);
            this.copyErrorCheckBox.TabIndex = 2;
            this.copyErrorCheckBox.Text = "checkBox1";
            this.copyErrorCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "ThankYouMsg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // ExceptionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyErrorCheckBox);
            this.Controls.Add(this.exceptionTextBox);
            this.Name = "ExceptionBox";
            this.Text = "ExceptionBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.CheckBox copyErrorCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}