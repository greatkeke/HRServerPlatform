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
            this.关闭ToolStripMenuItem.Click += 关闭ToolStripMenuItem_Click;
            this.关闭其他窗口ToolStripMenuItem.Click += 关闭其他窗口ToolStripMenuItem_Click;
            this.刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var page = this.tabControl1.SelectedTab;
            var uc = page.Controls[0] as IRefreshable;
            uc.Refresh(page.Tag);
        }

        private void 关闭其他窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var page = this.tabControl1.SelectedTab;
            this.tabControl1.TabPages.Clear();
            this.tabControl1.TabPages.Add(page);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取当前page
            var index = this.tabControl1.SelectedIndex;
            this.tabControl1.TabPages.RemoveAt(index);
            this.tabControl1.SelectedIndex = index >= 1 ? index - 1 : 0;
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
            btnMain = new Button() { Text = "首页", Height = 50, Width = 150, BackColor = Color.SkyBlue };
            btnMain.Click += BtnMain_Click;
            btnInfo = new Button() { Text = "个人资料", Height = 50, Width = 150, BackColor = Color.SkyBlue };
            btnInfo.Click += BtnInfo_Click;
            btnRequire = new Button() { Text = "需求列表", Height = 50, Width = 150, BackColor = Color.SkyBlue };
            btnRequire.Click += BtnRequire_Click;
            btnContact = new Button() { Text = "通讯", Height = 50, Width = 150, BackColor = Color.SkyBlue };
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
            var uc = this.uc_Require ?? new UC_Require();
            uc.EvenShowRequirementInfo += Uc_EvenShowRequirementInfo;
            this.ShowPage(uc, "需求", "需求");
        }
        /// <summary>
        /// 双击展示需求详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Uc_EvenShowRequirementInfo(object sender, EventArgs e)
        {
            var arg = e as RequireEventArgs;
            if (arg != null)
            {
                var uc = new UC_ShowRequirementInfo(arg.ID);
                ShowPage(uc, arg.Title, arg.ID.ToString());
            }
        }



        /// <summary>
        /// 个人资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInfo_Click(object sender, EventArgs e)
        {
            var ucinfo = this.uc_Info ?? new UC_Info();
            this.ShowPage(ucinfo, "个人资料", "个人资料");
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMain_Click(object sender, EventArgs e)
        {
            var jn = this.uc_JobNews ?? new UC_JobNews();
            jn.EvenShowJobNews += Jn_EvenShowJobNews;
            this.ShowPage(jn, "首页", "首页");
        }
        /// <summary>
        /// 双击展示职场新闻详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jn_EvenShowJobNews(object sender, EventArgs e)
        {
            var arg = e as RequireEventArgs;
            var uc = new UC_ShowJobNews(arg.ID);
            this.ShowPage(uc, arg.Title, arg.ID.ToString());

        }

        /// <summary>
        /// 展示页面
        /// 如果该页面已经存在，则展示它。
        /// </summary>
        /// <param name="uc">用户控件</param>
        /// <param name="pageTitle">page的title</param>
        /// <param name="tag">page的tag</param>
        private void ShowPage(UserControl uc, string pageTitle, string tag)
        {
            var page = this.tabControl1.TabPages.WherePage(tag);
            if (page == null)
            {
                uc.Dock = DockStyle.Fill;
                page = new TabPage(pageTitle) { Tag = tag };
                page.Controls.Add(uc);
                this.tabControl1.TabPages.Add(page);
            }
            this.tabControl1.SelectedTab = page;
        }
    }
}
