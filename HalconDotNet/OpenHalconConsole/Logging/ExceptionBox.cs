using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenHalconConsole.Logging
{
    public partial class ExceptionBox : Form
    {
        public ExceptionBox()
        {
            InitializeComponent();
        }

        private void exceptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                exceptionTextBox.SelectAll();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
