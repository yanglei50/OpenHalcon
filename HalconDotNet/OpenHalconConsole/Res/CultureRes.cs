using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenHalconConsole.Res
{
    class CultureRes
    {
        /// <summary>
        /// 为窗体更新资源文件内容
        /// </summary>
        /// <param name="form"></param>
        public static void ApplyResources(Form form)
        {
            ComponentResourceManager rm = new System.ComponentModel.ComponentResourceManager(form.GetType());
            foreach (Control ctl in form.Controls)
            {
                rm.ApplyResources(ctl, ctl.Name);
                form.ResumeLayout(false);
                form.PerformLayout();
            }

            //Caption
            rm.ApplyResources(form, "$this");
        }
        /// <summary>
        ///   查找类似 戴晓峰 的本地化字符串。
        /// </summary>
        public static string Author
        {
            get
            {
                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "zh-CN":
                        return ResourceZh.Author;
                        break;
                    case "en-US":
                        return ResourceEn.Author;
                        break;
                    default:
                        return ResourceZh.Author;
                        break;
                }
            }
        }

        private class ResourceZh
        {
            public static string Author { get; internal set; }
        }

        private class ResourceEn
        {
            public static string Author { get; internal set; }
        }
    }
}
