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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.tbxPwd.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var bll = new BaseBLL<t_User>();
            var user = bll.Query(u => u.User == this.tbxName.Text && u.Pwd == this.tbxPwd.Text).FirstOrDefault();
            if (user != null)
            {
                Program.loginUserID = user.ID;
                this.Hide();
                Form1 fm = new Form1();
                fm.Show();
            }
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            FormReg fm = new FormReg();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }
    }
}
