// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HalconWindowLayoutDialog
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HalconDotNet
{
    /// <summary>Summary description for HalconWindowLayoutDialog.</summary>
    internal class HalconWindowLayoutDialog : Form
    {
        public bool resultCancel = true;
        public int resultPercent = 100;
        private RadioButton radioSizeFull;
        private Button buttonOK;
        private Button buttonCancel;
        private Label labelSize;
        private RadioButton radioSizeHalf;
        private RadioButton radioSizeQuarter;
        private Label labelReference;
        private Label labelInfo;
        /// <summary>Required designer variable.</summary>
        private Container components;

        public HalconWindowLayoutDialog()
        {
            this.InitializeComponent();
        }

        public HalconWindowLayoutDialog(Size referenceSize)
          : this()
        {
            this.labelReference.Text = this.labelReference.Text + " " + (object)referenceSize.Width + " x " + (object)referenceSize.Height;
        }

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelReference = new Label();
            this.radioSizeFull = new RadioButton();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.labelSize = new Label();
            this.labelInfo = new Label();
            this.radioSizeHalf = new RadioButton();
            this.radioSizeQuarter = new RadioButton();
            this.SuspendLayout();
            this.labelReference.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelReference.Location = new Point(8, 8);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new Size(216, 16);
            this.labelReference.TabIndex = 1;
            this.labelReference.Text = "Reference Image Size:";
            this.radioSizeFull.Checked = true;
            this.radioSizeFull.Location = new Point(16, 56);
            this.radioSizeFull.Name = "radioSizeFull";
            this.radioSizeFull.Size = new Size(56, 16);
            this.radioSizeFull.TabIndex = 2;
            this.radioSizeFull.TabStop = true;
            this.radioSizeFull.Text = "100%";
            this.buttonOK.Location = new Point(8, 116);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(104, 24);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Location = new Point(120, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(104, 24);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.labelSize.Location = new Point(8, 32);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new Size(216, 16);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Choose a Window Size:";
            this.labelInfo.Location = new Point(8, 80);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(216, 28);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "The default ImagePart will be adapted to make the entire image fit into this window.";
            this.radioSizeHalf.Location = new Point(84, 56);
            this.radioSizeHalf.Name = "radioSizeHalf";
            this.radioSizeHalf.Size = new Size(56, 16);
            this.radioSizeHalf.TabIndex = 7;
            this.radioSizeHalf.Text = "50%";
            this.radioSizeQuarter.Location = new Point(152, 56);
            this.radioSizeQuarter.Name = "radioSizeQuarter";
            this.radioSizeQuarter.Size = new Size(56, 16);
            this.radioSizeQuarter.TabIndex = 8;
            this.radioSizeQuarter.Text = "25%";
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(230, 147);
            this.Controls.AddRange(new Control[8]
            {
        (Control) this.radioSizeQuarter,
        (Control) this.radioSizeHalf,
        (Control) this.labelInfo,
        (Control) this.labelSize,
        (Control) this.buttonCancel,
        (Control) this.buttonOK,
        (Control) this.radioSizeFull,
        (Control) this.labelReference
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = nameof(HalconWindowLayoutDialog);
            this.Text = "HALCON Window Layout";
            this.ResumeLayout(false);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.radioSizeHalf.Checked)
                this.resultPercent = 50;
            else if (this.radioSizeQuarter.Checked)
                this.resultPercent = 25;
            this.resultCancel = false;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
