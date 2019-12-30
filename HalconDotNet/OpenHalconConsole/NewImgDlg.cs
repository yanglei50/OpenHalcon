using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenHalconConsole
{
    public partial class NewImgDlg : Form
    {
        public NewImgDlg()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            ImageWnd childForm = new ImageWnd();//创建一个子窗体
            childForm.MdiParent = this.ActiveMdiChild;//这一句很重要
         //   System.Windows.Forms.Form frm = this.ActiveMdiChild;
            childForm.Text = "窗口";//窗体标题
            childForm.Show();//显示之
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
