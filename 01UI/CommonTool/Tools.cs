using _04Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHtmlEditor;

namespace _01UI
{
    public static class Tools
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

        /// <summary>
        /// 把对象序列化为字节数组
        /// </summary>
        public static byte[] SerializeObject(Msg obj)
        {
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        /// <summary>
        /// 把字节数组反序列化成对象
        /// </summary>
        public static Msg DeserializeObject(byte[] bytes)
        {
            Msg obj = null;
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms) as Msg;
            ms.Close();
            return obj;
        }
    }
}
