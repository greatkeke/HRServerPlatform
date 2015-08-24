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
    public partial class UC_JobNews : UserControl, IRefreshable
    {
        /// <summary>
        /// 展示职场新闻
        /// </summary>
        public event EventHandler EvenShowJobNews;
        /// <summary>
        /// 新增职场新闻
        /// </summary>
        public event EventHandler EvenNew;
        public UC_JobNews()
        {
            InitializeComponent();
            this.Width = 1080;
            this.Height = 2048;
            this.AutoSize = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.Load += UC_JobNews_Load;
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var rows = this.dataGridView1.SelectedRows;
            if (rows.Count <= 0)
            {
                return;
            }
            var id = rows[0].Cells["ID"].Value;
            var title = rows[0].Cells["Title"].Value;
            if (id != null && EvenShowJobNews != null && title != null)
            {
                EvenShowJobNews.Invoke(sender, new RequireEventArgs() { ID = new Guid(id.ToString()), Title = title.ToString() });
            }
        }

        private void UC_JobNews_Load(object sender, EventArgs e)
        {
            //获取news
            BaseBLL<t_JobNews> newsBll = new BaseBLL<t_JobNews>();
            var source = newsBll.Query(u => 1 == 1).OrderByDescending(u => u.Date).ToList();
            this.dataGridView1.DataSource = source;
            Date.DataPropertyName = "Date";
            Title.DataPropertyName = "Title";
            ID.DataPropertyName = "ID";
        }

        public void Refresh(object obj)
        {
            this.UC_JobNews_Load(null, null);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.EvenNew != null)
            {
                this.EvenNew.Invoke(sender, new RequireEventArgs() { Title = "我要发布" });
            }
        }
    }
}
