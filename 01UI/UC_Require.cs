using System;
using System.Windows.Forms;
using _02BLL;
using _04Model;
using System.Linq;
using DataGridViewAutoFilter;
using System.Data;

namespace _01UI
{
    public partial class UC_Require : UserControl, IRefreshable
    {
        BaseBLL<t_Requirement> requireBll = new BaseBLL<t_Requirement>();
        BaseBLL<t_User> userBll = new BaseBLL<t_User>();
        /// <summary>
        /// 展示需求的详细信息
        /// </summary>
        public event EventHandler EvenShowRequirementInfo;
        /// <summary>
        /// 发布新需求
        /// </summary>
        public event EventHandler EventNewReq;
        public UC_Require()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.Load += UC_Require_Load;
            this.dataGridView1.AutoGenerateColumns = false;
            ID.DataPropertyName = "ID";
            PostDate.DataPropertyName = "PostDate";
            Title.DataPropertyName = "Title";
            Categories.DataPropertyName = "CatetogriyName";
            Status.DataPropertyName = "Status";
            Gread.DataPropertyName = "Gread";
            CheckPower(Program.loginUserID);
        }

        private void CheckPower(Guid loginUserID)
        {
            if (!userBll.GetRoleName(loginUserID).Any(u => u == "企业"))
            {
                //this.btnNew.Visible = false;
            }
        }

        private void UC_Require_Load(object sender, EventArgs e)
        {
            try
            {
                //获取数据
                int status = (int)EnumRequireStauts.发布;
                DataTable table = requireBll.Query(u => u.Status >= status).ConvertToRequireShowModel().OrderByDescending(u => u.PostDate).CopyToDataTable();
                BindingSource source = new BindingSource();
                source.DataSource = table;
                this.dataGridView1.DataSource = source;
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
            var title = rows[0].Cells["Title"].Value.ToString();
            if (id != null)
            {
                if (this.EvenShowRequirementInfo != null)
                {
                    this.EvenShowRequirementInfo.Invoke(sender, new RequireEventArgs() { ID = id.Value, Title = title });
                }
            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="obj"></param>
        public void Refresh(object obj)
        {
            UC_Require_Load(null, null);
        }
        /// <summary>
        /// 查看我的需求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = userBll.GetMyRequirement(Program.loginUserID).ConvertToRequireShowModel().OrderByDescending(u => u.PostDate).CopyToDataTable();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = source;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (EventNewReq != null)
            {
                this.EventNewReq.Invoke(sender, new RequireEventArgs() { Title = "新需求" });
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

