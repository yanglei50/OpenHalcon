using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFVisionInspection
{
    public partial class StartOption : Form
    {
        public StartOption()
        {
            InitializeComponent();
        }

        private void btn_acquire_Click(object sender, EventArgs e)
        {
            grabImageSequence grab = new grabImageSequence();
            grab.Show();
        }
    }
}
