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
    public partial class Form1 : Form
    {
        /// <summary>
        /// 职场新闻
        /// </summary>
        UC_JobNews uc_JobNews;
        /// <summary>
        /// 个人资料
        /// </summary>
        UC_Info uc_Info;
        /// <summary>
        /// 首页按钮
        /// </summary>
        Button btnMain;
        /// <summary>
        /// 个人资料按钮
        /// </summary>
        Button btnInfo;
        /// <summary>
        /// 需求按钮
        /// </summary>
        Button btnRequire;
        /// <summary>
        /// 通讯按钮
        /// </summary>
        Button btnContact;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Height = 2048;
            this.Width = 1080;
            this.AutoSize = true;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitControls();
            //展示欢迎
            this.pictureBox1.Image = Image.FromFile(@"F:\ShellFile\HRServerPlatform\01UI\Source\屏幕截图(1).png");
            BtnMain_Click(null, null);


        }

        private void InitControls()
        {
            btnMain = new Button() { Text = "首页", Height = 150, Width = 150, BackColor = Color.SkyBlue };
            btnMain.Click += BtnMain_Click;
            btnInfo = new Button() { Text = "个人资料", Height = 150, Width = 150, BackColor = Color.SkyBlue };
            btnInfo.Click += BtnInfo_Click;
            btnRequire = new Button() { Text = "需求列表", Height = 150, Width = 150, BackColor = Color.SkyBlue };
            btnRequire.Click += BtnRequire_Click;
            btnContact = new Button() { Text = "通讯", Height = 150, Width = 150, BackColor = Color.SkyBlue };
            btnContact.Click += BtnContact_Click;
            this.flowLayoutPanel1.Controls.AddRange(new Button[] {
                btnMain,btnInfo,btnRequire,btnContact
            });
        }

        private void BtnContact_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 需求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRequire_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 个人资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInfo_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ucinfo = this.uc_Info ?? new UC_Info() { Dock = DockStyle.Fill };
            this.panel1.Controls.Add(ucinfo);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMain_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var jn = this.uc_JobNews ?? new UC_JobNews() { Dock = DockStyle.Fill };
            //展示首页新闻
            this.panel1.Controls.Add(jn);
        }
    }
}
