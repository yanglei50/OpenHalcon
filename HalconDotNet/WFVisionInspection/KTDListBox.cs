using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTDUiLib
{
    class LogItem
    {
        public String info;
        public int index;
        public Color color;
    }
    public partial class KTDListBox : ListBox
    {
        private int m_nMaxLength = 100000;
        [CategoryAttribute("自定义")]
        [DescriptionAttribute("日志最大显示条数")]
        public int MaxLength
        {
            set
            {
                m_nMaxLength = value;
            }
            get
            {
                return m_nMaxLength;
            }
        }
        Dictionary<int, LogItem> m_dicItems = new Dictionary<int, LogItem>();
        public KTDListBox()
        {
            InitializeComponent();
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
        }

        public KTDListBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            // 确保listbox中有日志且该日志被记录在字典中
            if (e.Index >= 0 && m_dicItems.Keys.Contains(e.Index))
            {
                e.Graphics.DrawString(m_dicItems[e.Index].info, Font, new SolidBrush(m_dicItems[e.Index].color), e.Bounds);
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = 16;
        }
        public void AddLog(String log, Color color)
        {
            ModefyItems();
            LogItem item = new LogItem();
            String showLog = String.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss"), log);
            item.info = showLog;
            item.color = color;

            item.index = Items.Add(log);
            if (!m_dicItems.Keys.Contains(item.index))
                m_dicItems.Add(item.index, item);
            SelectedIndex = item.index;
        }

        public void Clear()
        {
            Items.Clear();
            m_dicItems.Clear();
        }

        private void ModefyItems()
        {
            if (Items.Count >= m_nMaxLength)
            {
                Items.RemoveAt(0);
                for (int n = 0; n < m_dicItems.Count - 1; n++)
                {
                    if (m_dicItems.Keys.Contains(n) && m_dicItems.Keys.Contains(n + 1))
                    {
                        m_dicItems[n].info = m_dicItems[n + 1].info;
                        m_dicItems[n].color = m_dicItems[n + 1].color;
                    }
                }

                m_dicItems.Remove(m_dicItems.Count - 1);
            }
        }
    }
}
