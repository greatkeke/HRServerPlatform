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
    public partial class UC_ShowRequirementInfo : UserControl, IRefreshable
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
                this.cmbGread.SelectedIndex = requirement.Gread;
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
            //非法校验
            var ctl = new Tools().CheckIllegalControls(this.tbxTitle, this.cmbCate, this.cmbGread, this.cmbStatus, this.htmlEditor1);
            if (ctl != null)
            {
                ctl.Focus();
                MessageBox.Show("您还有信息未录入哦！");
                return;
            }
            requirement.Title = this.tbxTitle.Text;
            requirement.CategoryID = new Guid(this.cmbCate.SelectedValue.ToString());
            requirement.Gread = this.cmbGread.SelectedIndex;
            requirement.Status = this.cmbStatus.SelectedIndex;
            requirement.PostDate = this.dtiDate.Value;
            requirement.Content = this.htmlEditor1.BodyHtml;
            if (bll.Update(this.requirement))
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK);
            }
        }

        public void Refresh(object obj)
        {
            var id = new Guid(obj.ToString());
            this.requirement = bll.QueryNoTracking(u => u.ID == id).FirstOrDefault();
            this.UC_ShowRequirementInfo_Load(null, null);
        }
    }
}
