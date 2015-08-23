using System;
using System.Windows.Forms;
using _02BLL;
using _04Model;
using System.Linq;

namespace _01UI
{
    public partial class UC_Require : UserControl
    {
        BaseBLL<t_Requirement> requireBll = new BaseBLL<t_Requirement>();
        /// <summary>
        /// 展示需求的详细信息
        /// </summary>
        public event EventHandler EvenShowRequirementInfo;
        public UC_Require()
        {
            InitializeComponent();
            this.Load += UC_Require_Load;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void UC_Require_Load(object sender, EventArgs e)
        {
            try
            {
                //获取数据
                var source = requireBll.Query(u => u.PostDate >= DateTime.Now.AddDays(-3)).ConvertToRequireShowModel().OrderByDescending(u => u.PostDate).ToList();
                this.dataGridView1.DataSource = source;
                ID.DataPropertyName = "ID";
                PostDate.DataPropertyName = "PostDate";
                Title.DataPropertyName = "Title";
                Categories.DataPropertyName = "CatetogriyName";
                Status.DataPropertyName = "Status";
                Gread.DataPropertyName = "Gread";
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 双击 查看详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var rows = this.dataGridView1.SelectedRows;
            if (rows.Count <= 0) return;
            var id = rows[0].Cells[0].Value as Guid?;
            if (id != null)
            {
                if (this.EvenShowRequirementInfo != null)
                {
                    this.EvenShowRequirementInfo.Invoke(sender, new RequireEventArgs() { ID = id.Value });
                }
            }

        }
    }
    /// <summary>
    /// 需求展示模型
    /// </summary>
    public class RequirementShowModel
    {
        public Guid ID { get; set; }
        public string PostDate { get; set; }
        public string Title { get; set; }
        public string CatetogriyName { get; set; }
        public string Status { get; set; }
        public string Gread { get; set; }
    }
}

