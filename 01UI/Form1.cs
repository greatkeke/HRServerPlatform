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
        /// 需求
        /// </summary>
        UC_Require uc_Require;
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
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.tabControl1.ContextMenuStrip = this.PageMenu;
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
            btnMain = new Button() { Text = "首页", Height = 100, Width = 150, BackColor = Color.SkyBlue };
            btnMain.Click += BtnMain_Click;
            btnInfo = new Button() { Text = "个人资料", Height = 100, Width = 150, BackColor = Color.SkyBlue };
            btnInfo.Click += BtnInfo_Click;
            btnRequire = new Button() { Text = "需求列表", Height = 100, Width = 150, BackColor = Color.SkyBlue };
            btnRequire.Click += BtnRequire_Click;
            btnContact = new Button() { Text = "通讯", Height = 100, Width = 150, BackColor = Color.SkyBlue };
            btnContact.Click += BtnContact_Click;
            this.flowLayoutPanel1.Controls.AddRange(new Button[] {
                btnMain,btnInfo,btnRequire,btnContact
            });
        }

        private void BtnContact_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 需求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRequire_Click(object sender, EventArgs e)
        {
            //是否已经打开首页选项卡
            var page = this.tabControl1.TabPages.WherePage("需求");
            if (page == null)
            {
                var uc = this.uc_Require ?? new UC_Require() { Dock = DockStyle.Fill };
                page = new TabPage("需求") { Tag = "需求" };
                page.Controls.Add(uc);
                this.tabControl1.TabPages.Add(page);
                uc.EvenShowRequirementInfo += Uc_EvenShowRequirementInfo;
            }
            this.tabControl1.SelectedTab = page;

        }

        private void Uc_EvenShowRequirementInfo(object sender, EventArgs e)
        {
            var arg = e as RequireEventArgs;
            if (arg!=null)
            {

                //展示页面
            }
        }

        /// <summary>
        /// 个人资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInfo_Click(object sender, EventArgs e)
        {
            //是否已经打开首页选项卡
            var page = this.tabControl1.TabPages.WherePage("个人资料");
            if (page == null)
            {
                var ucinfo = this.uc_Info ?? new UC_Info() { Dock = DockStyle.Fill };
                page = new TabPage("个人资料") { Tag = "个人资料" };
                page.Controls.Add(ucinfo);
                this.tabControl1.TabPages.Add(page);
            }
            this.tabControl1.SelectedTab = page;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMain_Click(object sender, EventArgs e)
        {
            //是否已经打开首页选项卡
            var page = this.tabControl1.TabPages.WherePage("首页");
            if (page == null)
            {
                var jn = this.uc_JobNews ?? new UC_JobNews() { Dock = DockStyle.Fill };
                //展示首页新闻
                page = new TabPage("首页") { Tag = "首页" };
                page.Controls.Add(jn);
                this.tabControl1.TabPages.Add(page);
            }
            this.tabControl1.SelectedTab = page;
        }
    }
}
