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
    public partial class UC_JobNews : UserControl
    {
        public UC_JobNews()
        {
            InitializeComponent();
            this.Width = 1080;
            this.Height = 2048;
            this.AutoSize = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.Load += UC_JobNews_Load;
            this.ContextMenuStrip = new ContextMenuStrip();
        }

        private void UC_JobNews_Load(object sender, EventArgs e)
        {
            //获取news
            BaseBLL<t_JobNews> newsBll = new BaseBLL<t_JobNews>();
            var source = newsBll.Query(u => 1 == 1).OrderByDescending(u => u.Date).ToList();
            this.dataGridView1.DataSource = source;
            this.dataGridView1.Columns[0].DataPropertyName = "Date";
            this.dataGridView1.Columns[1].DataPropertyName = "Title";
        }
    }
}
