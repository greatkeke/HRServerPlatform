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
            //展示首页新闻
            this.panel1.Controls.Add(new UC_JobNews() { Dock = DockStyle.Fill });


        }

        private void InitControls()
        {
            Button b1 = new Button();
            b1.Controls.Add(new TextBox() { Text = "Search……" });
            this.flowLayoutPanel1.Controls.AddRange(new Button[] {
                new Button() {Text="首页",Height=150,Width=150,BackColor= Color.SkyBlue},
                new Button() {Text="个人资料",Height=150,Width=150,BackColor= Color.SkyBlue},
                new Button() {Text="需求列表",Height=150,Width=150,BackColor= Color.SkyBlue},
                new Button() {Text="通讯",Height=150,Width=150,BackColor= Color.SkyBlue},
                b1
            });
        }
    }
}
