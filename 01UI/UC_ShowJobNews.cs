using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _04Model;
using _02BLL;

namespace _01UI
{
    public partial class UC_ShowJobNews : UserControl, IRefreshable
    {
        private t_JobNews _jobNews;
        private BaseBLL<t_JobNews> bll = new BaseBLL<t_JobNews>();
        private BaseBLL<t_User> userBll = new BaseBLL<t_User>();
        public UC_ShowJobNews()
        {
            InitializeComponent();
        }
        public UC_ShowJobNews(Guid id) : this()
        {
            var jobNews = bll.Query(u => u.ID == id).FirstOrDefault();
            if (jobNews != null)
            {
                this._jobNews = jobNews;
            }
            this.Load += UC_ShowJobNews_Load;
        }

        private void UC_ShowJobNews_Load(object sender, EventArgs e)
        {
            if (_jobNews != null)
            {
                this.tbxTitle.Text = _jobNews.Title;
                var user = userBll.Query(u => u.ID == _jobNews.PostID).FirstOrDefault();
                tbxAuther.Text = user != null ? user.User : String.Empty;
                this.dtpDate.Value = _jobNews.Date;
                this.htmlEditor1.BodyHtml = _jobNews.Content;
                this.htmlEditor1.ShowToolBar = false;//查看时隐藏工具栏
                //readonly
            }
        }

        public void Refresh(object obj)
        {
            var id = new Guid(obj.ToString());
            var jobNews = bll.QueryNoTracking(u => u.ID == id).FirstOrDefault();
            if (jobNews != null)
            {
                this._jobNews = jobNews;
            }
            UC_ShowJobNews_Load(null, null);
        }
    }
}
