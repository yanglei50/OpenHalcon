namespace ICSharpCode.TextEditor.UserControls
{
  partial class FormatCodeHtml
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.gbLanguage = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbCSharp = new System.Windows.Forms.RadioButton();
            this.rbVB = new System.Windows.Forms.RadioButton();
            this.rbHtml = new System.Windows.Forms.RadioButton();
            this.rbtsql = new System.Windows.Forms.RadioButton();
            this.rbJS = new System.Windows.Forms.RadioButton();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbLineNumbers = new System.Windows.Forms.CheckBox();
            this.cbEmbedCss = new System.Windows.Forms.CheckBox();
            this.cbAlternate = new System.Windows.Forms.CheckBox();
            this.rbJava = new System.Windows.Forms.RadioButton();
            this.gbLanguage.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(261, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Copy && Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(180, 150);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // gbLanguage
            // 
            this.gbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLanguage.Controls.Add(this.flowLayoutPanel2);
            this.gbLanguage.Location = new System.Drawing.Point(12, 12);
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.Size = new System.Drawing.Size(340, 75);
            this.gbLanguage.TabIndex = 2;
            this.gbLanguage.TabStop = false;
            this.gbLanguage.Text = "Language";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rbCSharp);
            this.flowLayoutPanel2.Controls.Add(this.rbVB);
            this.flowLayoutPanel2.Controls.Add(this.rbHtml);
            this.flowLayoutPanel2.Controls.Add(this.rbtsql);
            this.flowLayoutPanel2.Controls.Add(this.rbJS);
            this.flowLayoutPanel2.Controls.Add(this.rbJava);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(334, 56);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // rbCSharp
            // 
            this.rbCSharp.AutoSize = true;
            this.rbCSharp.Checked = true;
            this.rbCSharp.Location = new System.Drawing.Point(8, 8);
            this.rbCSharp.Name = "rbCSharp";
            this.rbCSharp.Size = new System.Drawing.Size(39, 17);
            this.rbCSharp.TabIndex = 5;
            this.rbCSharp.TabStop = true;
            this.rbCSharp.Text = "C#";
            this.rbCSharp.UseVisualStyleBackColor = true;
            // 
            // rbVB
            // 
            this.rbVB.AutoSize = true;
            this.rbVB.Location = new System.Drawing.Point(53, 8);
            this.rbVB.Name = "rbVB";
            this.rbVB.Size = new System.Drawing.Size(64, 17);
            this.rbVB.TabIndex = 4;
            this.rbVB.Text = "VB.NET";
            this.rbVB.UseVisualStyleBackColor = true;
            // 
            // rbHtml
            // 
            this.rbHtml.AutoSize = true;
            this.rbHtml.Location = new System.Drawing.Point(123, 8);
            this.rbHtml.Name = "rbHtml";
            this.rbHtml.Size = new System.Drawing.Size(73, 17);
            this.rbHtml.TabIndex = 6;
            this.rbHtml.Text = "Html/XML";
            this.rbHtml.UseVisualStyleBackColor = true;
            // 
            // rbtsql
            // 
            this.rbtsql.AutoSize = true;
            this.rbtsql.Location = new System.Drawing.Point(202, 8);
            this.rbtsql.Name = "rbtsql";
            this.rbtsql.Size = new System.Drawing.Size(56, 17);
            this.rbtsql.TabIndex = 3;
            this.rbtsql.Text = "T-SQL";
            this.rbtsql.UseVisualStyleBackColor = true;
            // 
            // rbJS
            // 
            this.rbJS.AutoSize = true;
            this.rbJS.Location = new System.Drawing.Point(8, 31);
            this.rbJS.Name = "rbJS";
            this.rbJS.Size = new System.Drawing.Size(75, 17);
            this.rbJS.TabIndex = 7;
            this.rbJS.Text = "JavaScript";
            this.rbJS.UseVisualStyleBackColor = true;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.flowLayoutPanel1);
            this.gbSettings.Location = new System.Drawing.Point(12, 95);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(337, 51);
            this.gbSettings.TabIndex = 3;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbLineNumbers);
            this.flowLayoutPanel1.Controls.Add(this.cbEmbedCss);
            this.flowLayoutPanel1.Controls.Add(this.cbAlternate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 32);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // cbLineNumbers
            // 
            this.cbLineNumbers.AutoSize = true;
            this.cbLineNumbers.Location = new System.Drawing.Point(8, 8);
            this.cbLineNumbers.Name = "cbLineNumbers";
            this.cbLineNumbers.Size = new System.Drawing.Size(91, 17);
            this.cbLineNumbers.TabIndex = 0;
            this.cbLineNumbers.Text = "Line Numbers";
            this.cbLineNumbers.UseVisualStyleBackColor = true;
            // 
            // cbEmbedCss
            // 
            this.cbEmbedCss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEmbedCss.AutoSize = true;
            this.cbEmbedCss.Location = new System.Drawing.Point(105, 8);
            this.cbEmbedCss.Name = "cbEmbedCss";
            this.cbEmbedCss.Size = new System.Drawing.Size(79, 17);
            this.cbEmbedCss.TabIndex = 1;
            this.cbEmbedCss.Text = "Embed Css";
            this.cbEmbedCss.UseVisualStyleBackColor = true;
            // 
            // cbAlternate
            // 
            this.cbAlternate.AutoSize = true;
            this.cbAlternate.Location = new System.Drawing.Point(190, 8);
            this.cbAlternate.Name = "cbAlternate";
            this.cbAlternate.Size = new System.Drawing.Size(123, 17);
            this.cbAlternate.TabIndex = 2;
            this.cbAlternate.Text = "Alternate Line Colors";
            this.cbAlternate.UseVisualStyleBackColor = true;
            // 
            // rbJava
            // 
            this.rbJava.AutoSize = true;
            this.rbJava.Location = new System.Drawing.Point(89, 31);
            this.rbJava.Name = "rbJava";
            this.rbJava.Size = new System.Drawing.Size(48, 17);
            this.rbJava.TabIndex = 8;
            this.rbJava.Text = "Java";
            this.rbJava.UseVisualStyleBackColor = true;
            // 
            // FormatCodeHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 185);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbLanguage);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatCodeHtml";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy Code as Html";
            this.gbLanguage.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnCopy;
    private System.Windows.Forms.GroupBox gbLanguage;
    private System.Windows.Forms.GroupBox gbSettings;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private System.Windows.Forms.RadioButton rbCSharp;
    private System.Windows.Forms.RadioButton rbVB;
    private System.Windows.Forms.RadioButton rbHtml;
    private System.Windows.Forms.RadioButton rbtsql;
    private System.Windows.Forms.RadioButton rbJS;
    private System.Windows.Forms.CheckBox cbLineNumbers;
    private System.Windows.Forms.CheckBox cbEmbedCss;
    private System.Windows.Forms.CheckBox cbAlternate;
    private System.Windows.Forms.RadioButton rbJava;
  }
}