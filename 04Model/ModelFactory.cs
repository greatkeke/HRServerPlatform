using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _04Model
{
    public class ModelFactory
    {
        private static DbContext dbContext;
        /// <summary>
        /// 保证线程实例唯一
        /// </summary>
        /// <returns> 上下文对象 </returns>
        public static DbContext GetContext()
        {
            if (dbContext==null)
            {
                dbContext = new _04Model.Model1();
            }
            return dbContext;

            ////1、从数据槽中查找“DbContext”实例。
            //var data = CallContext.GetData("DbContext");
            //if (data == null)
            //{
            //    //2、如果不存在，则新建一个数据上下文，放入数据槽中。
            //    CallContext.SetData("DbContext", new _04Model.Model1());
            //}
            ////3、如果存在，则直接返回。
            //return data as DbContext;
        }
    }
}
