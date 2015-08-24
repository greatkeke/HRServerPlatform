using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHtmlEditor;

namespace _01UI
{
    static class Tools
    {
        /// <summary>
        /// 检查控件的合法性
        /// </summary>
        /// <param name="controls">要检查的控件</param>
        /// <returns>非法的控件</returns>
        internal static Control CheckIllegalControls(params Control[] controls)
        {
            foreach (var item in controls)
            {
                var com = item as ComboBox;
                var tbx = item as TextBox;
                var html = item as HtmlEditor;
                if (com != null)
                {
                    if (com.SelectedIndex < 0)
                    {
                        return com;
                    }
                }
                if (tbx != null)
                {
                    if (string.IsNullOrEmpty(tbx.Text))
                    {
                        return tbx;
                    }
                }
                if (html != null)
                {
                    if (html.BodyHtml == @"<BODY scroll=auto><P>&nbsp;</P></BODY>")
                    {
                        return html;
                    }
                }
            }
            return null;
        }
    }
}
