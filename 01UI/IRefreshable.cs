using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01UI
{
    interface IRefreshable
    {
        /// <summary>
        /// 刷新方法
        /// </summary>
        void Refresh(object obj);
    }
}
