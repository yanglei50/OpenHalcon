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
    public partial class ProgramWnd : Form
    {
        public ProgramWnd()
        {
            InitializeComponent();
            Main_textBox.SetHighlighting("XML");
            Main_textBox.SetFoldingStrategy("XML");
            Main_textBox.Font = new Font("Courier New", 8.25f, FontStyle.Regular);
        }

        private void Main_textBox_TextChanged(object sender, System.EventArgs e)
        {
            UpdateAndCheckFoldings();
        }

        private void UpdateAndCheckFoldings()
        {
            Main_textBox.Document.FoldingManager.UpdateFoldings(null, null);
            //textBox1.Text = string.Join("\r\n", textEditorControl1.GetFoldingErrors());
        }

        private void cmbHighlight_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var cmb = (ComboBox)sender;
            Main_textBox.SetHighlighting(cmb.SelectedItem.ToString());
        }
    }
}
