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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void File_New_File_MenuItem_Click(object sender, EventArgs e)
        {
            ProgramWnd childForm = new ProgramWnd();//创建一个子窗体
            childForm.MdiParent = this;//这一句很重要
            childForm.Text = "窗口" ;//窗体标题
            childForm.Show();//显示之
        }

        private void Open_Image_Wnd_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImgDlg childForm = new NewImgDlg();//创建一个子窗体
            childForm.MdiParent = this;//这一句很重要
            childForm.Text = "窗口";//窗体标题
            childForm.Show();//显示之
        }
    }
}
