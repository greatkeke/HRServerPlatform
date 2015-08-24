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
    public partial class UC_Info : UserControl, IRefreshable
    {
        BaseBLL<t_User> userBll = new BaseBLL<t_User>();
        t_User loginUser;
        public UC_Info()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.htmlEditor1.ShowToolBar = false;
            this.htmlEditor1.Enabled = false;
            this.Load += UC_Info_Load;
        }


        private void UC_Info_Load(object sender, EventArgs e)
        {
            if (Program.loginUserID == null)
            {
                //return;
            }
            //获取当前用户的特长信息

            this.loginUser = userBll.Query(u => u.ID == Program.loginUserID).FirstOrDefault();
            //展示
            if (loginUser != null)
            {
                this.htmlEditor1.BodyHtml = loginUser.ShowInfo ?? string.Empty;
            }

        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.htmlEditor1.ShowToolBar = true;
            this.htmlEditor1.Enabled = true;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.loginUser.ShowInfo = this.htmlEditor1.BodyHtml ?? string.Empty;
            userBll.Update(this.loginUser);
            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
        }

        public void Refresh(object obj)
        {
            this.UC_Info_Load(null, null);
        }
    }
}
