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
            this.tbxAuther.Enabled = false;
            this.tbxTitle.Enabled = false;
            this.dtpDate.Enabled = false;
            this.htmlEditor1.ShowToolBar = false;
            this.htmlEditor1.Enabled = false;
            this.btnSave.Visible = false;
            this.btnDel.Visible = false;

        }
        public UC_ShowJobNews(bool isNew) : this()
        {
            if (isNew == true)
            {
                this.tbxTitle.Enabled = true;
                this.htmlEditor1.ShowToolBar = true;
                this.htmlEditor1.Enabled = true;
                this.btnSave.Visible = true;
                //显示当前用户的登录名
                var user = userBll.Query(u => u.ID == Program.loginUserID).Select(u => u.User).FirstOrDefault();
                if (user != null)
                {
                    this.tbxAuther.Text = user;
                }
            }
        }
        public UC_ShowJobNews(Guid id) : this()
        {
            var jobNews = bll.Query(u => u.ID == id).FirstOrDefault();
            if (jobNews != null)
            {
                this._jobNews = jobNews;
            }
            if (userBll.GetRoleName(Program.loginUserID).Any(u => u == "管理员"))
            {
                this.btnDel.Visible = true;
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
            }
        }

        public void Refresh(object obj)
        {
            if (obj != null)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check
            var con = Tools.CheckIllegalControls(this.tbxTitle, this.htmlEditor1);
            if (con != null)
            {
                con.Focus();
                MessageBox.Show("该项不能为空");
                return;
            }
            var jobNews = new t_JobNews();
            jobNews.ID = Guid.NewGuid();
            jobNews.PostID = Program.loginUserID;
            jobNews.Content = this.htmlEditor1.BodyHtml;
            jobNews.Date = DateTime.Now;
            jobNews.Title = this.tbxTitle.Text;
            if (bll.Add(jobNews))
            {
                MessageBox.Show("发布成功");
            }
            else
            {
                MessageBox.Show("发布失败");
            }
        }
    }
}
