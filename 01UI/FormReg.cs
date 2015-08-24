using _02BLL;
using _04Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01UI
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
            var bll = new BaseBLL<t_Role>();
            var source = bll.Query(u => true).ToList();
            this.cmbRole.DataSource = source;
            this.cmbRole.DisplayMember = "RoleName";
            this.cmbRole.ValueMember = "ID";
            this.tbxPwd.PasswordChar = '*';
            this.tbxRePwd.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Tools.CheckIllegalControls(this.tbxRePwd, this.tbxPwd, this.tbxName, this.cmbRole);
            if (con != null)
            {
                MessageBox.Show("该项不能为空");
                con.Focus();
                return;
            }
            if (this.tbxPwd.Text != this.tbxRePwd.Text)
            {
                MessageBox.Show("输入的密码不一样");
                this.tbxRePwd.Focus();
                return;
            }
            var bll = new BaseBLL<t_User>();
            var urBll = new BaseBLL<t_UserRole>();
            var user = new t_User()
            {
                ID = Guid.NewGuid(),
                Pwd = this.tbxPwd.Text,
                RoleID = new Guid(this.cmbRole.SelectedValue.ToString()),
                User = this.tbxName.Text
            };
            var ur = new t_UserRole()
            {
                RoleID = user.RoleID,
                UserID = user.ID
            };
            if (bll.Query(u => u.User == user.User).Any())
            {
                MessageBox.Show("该用户名已被注册"); return;
            }
            if (bll.Add(user) && urBll.Add(ur))
            {
                if (MessageBox.Show("注册成功", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
