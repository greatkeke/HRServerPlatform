using _02BLL;
using _04Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _01UI
{
    public static class ExtensionFunc
    {
        /// <summary>
        /// 转换为需求展示模型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<RequirementShowModel> ConvertToRequireShowModel(this IEnumerable<t_Requirement> source)
        {
            var cateList = new BaseBLL<t_Categories>().Query(u => true).ToList();
            List<RequirementShowModel> list = new List<RequirementShowModel>();
            foreach (var item in source)
            {
                list.Add(new RequirementShowModel()
                {
                    ID = item.ID,
                    Title = item.Title,
                    PostDate = item.PostDate.ToString("yyyy-MM-dd hh:mm"),
                    CatetogriyName = cateList.Where(u => u.ID == item.ID).Select(u => u.CategoryName).FirstOrDefault() ?? string.Empty,
                    Gread = ((EnumRequireGread)(item.Gread ?? 0)).ToString(),
                    Status = ((EnumRequireStauts)(item.Status)).ToString()
                });
            }
            return list;
        }
        /// <summary>
        /// 是否已经包含该页
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="whereStr"></param>
        /// <returns>如果存在则返回TabPage，否则返回null</returns>
        public static TabPage WherePage(this TabControl.TabPageCollection pages, string whereStr)
        {
            foreach (TabPage item in pages)
            {
                if ((item.Tag??string.Empty).ToString() == whereStr)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
