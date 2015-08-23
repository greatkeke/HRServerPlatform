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
    public partial class UC_ShowRequirementInfo : UserControl
    {
        private t_Requirement requirement;
        private BaseBLL<t_Requirement> bll = new BaseBLL<t_Requirement>();
        public UC_ShowRequirementInfo()
        {
            InitializeComponent();
        }
        public UC_ShowRequirementInfo(Guid id) : this()
        {
            this.requirement = bll.Query(u => u.ID == id).FirstOrDefault();
            this.AutoSize = true;
            this.Load += UC_ShowRequirementInfo_Load;

        }
        /// <summary>
        /// load时加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_ShowRequirementInfo_Load(object sender, EventArgs e)
        {
            this.cmbCate.DataSource = new BaseBLL<t_Categories>().Query(u => true).ToList();
            this.cmbCate.DisplayMember = "CategoryName";
            this.cmbCate.ValueMember = "ID";
            this.cmbGread.DataSource = Enum.GetValues(typeof(EnumRequireGread));
            this.cmbStatus.DataSource = Enum.GetValues(typeof(EnumRequireStauts));

            if (this.requirement != null)
            {
                this.tbxTitle.Text = requirement.Title;
                this.cmbCate.SelectedValue = requirement.CategoryID;
                this.cmbGread.SelectedIndex = requirement.Gread == null ? 0 : requirement.Gread.Value;
                this.cmbStatus.SelectedIndex = requirement.Status;
                this.dtiDate.Value = requirement.PostDate;
                this.htmlEditor1.BodyHtml = requirement.Content;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
        }
    }
}
