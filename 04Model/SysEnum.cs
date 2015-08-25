using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Model
{
    public enum EnumRequireStauts
    {
        被删除 = 0,
        取消 = 1,
        未发布 = 2,
        发布 = 3,
        成交 = 4,
        完成 = 5

    }
    public enum EnumRequireGread
    {
        简单 = 0,
        一般 = 1,
        困难 = 2
    }
    public enum EnumOrderStatus
    {
        已签约 = 0,
        已成交 = 1
    }
    [Serializable]
    public class Msg
    {
        private Guid speakID;
        private Guid sessionID;
        private String content;
        private Guid listenID;

        public Guid SpeakID
        {
            get
            {
                return speakID;
            }

            set
            {
                speakID = value;
            }
        }

        public Guid SessionID
        {
            get
            {
                return sessionID;
            }

            set
            {
                sessionID = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public Guid ListenID
        {
            get
            {
                return listenID;
            }

            set
            {
                listenID = value;
            }
        }
        /// <summary>
        /// 返回消息的内容
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return content;
        }
    }
}
