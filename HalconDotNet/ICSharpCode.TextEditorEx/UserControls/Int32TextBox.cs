using System;
using System.Windows.Forms;

namespace ICSharpCode.TextEditor.UserControls
{
    class Int32TextBox : TextBox
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public Int32TextBox()
            : this(1, int.MaxValue)
        {
        }

        public Int32TextBox(int min, int max)
        {
            Min = min;
            Max = max;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!IsValidNumber(Text))
            {
                Text = string.Empty;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;

            if (m.Msg == WM_PASTE)
            {
                string text = Clipboard.GetText();

                if (!IsValidNumber(text))
                    return;
            }

            base.WndProc(ref m);
        }

        private bool IsValidNumber(string text)
        {
            int i;
            if (int.TryParse(text, out i))
            {
                return i <= Max && i >= Min;
            }

            return false;
        }
    }
}