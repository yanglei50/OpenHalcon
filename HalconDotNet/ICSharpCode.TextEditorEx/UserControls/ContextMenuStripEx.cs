using System;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Utils;

namespace ICSharpCode.TextEditor.UserControls
{
    public partial class ContextMenuStripEx : ContextMenuStrip
    {
        public ToolStripMenuItem AddToolStripMenuItem(string text, Bitmap bitmap, EventHandler<EventArgs> clickEvent, Keys keys, Func<bool> enabled)
        {
            var menuItem = new ToolStripMenuItem(text);
            if (bitmap != null)
            {
                menuItem.Image = bitmap;
            }

            if (keys != Keys.None)
            {
                menuItem.ShortcutKeys = keys;
            }

            if (clickEvent != null)
            {
                menuItem.Click += new WeakEventHandler<EventArgs>(clickEvent).Handler;
            }

            Items.Add(menuItem);

            EventHandler<EventArgs> toolstripOpening = (sender, args) =>
            {
                menuItem.Enabled = enabled();
            };
            Opening += new WeakEventHandler<EventArgs>(toolstripOpening).Handler;

            return menuItem;
        }

        public ToolStripSeparator AddToolStripSeparator()
        {
            var strip = new ToolStripSeparator();
            Items.Add(strip);

            return strip;
        }
    }
}