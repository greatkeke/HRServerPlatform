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
            this.AutoSize = true;
            //权限控制相关
            this.btnDel.Visible = false;
            this.btnWant.Visible = false;
            this.htmlEditor1.ShowToolBar = false;
            this.tbxTitle.Enabled = false;
            this.cmbCate.Enabled = false;
            this.cmbGread.Enabled = false;
            this.cmbStatus.Enabled = false;
            this.dtiDate.Enabled = false;
            //加载初始化数据
            this.cmbCate.DataSource = new BaseBLL<t_Categories>().Query(u => true).ToList();
            this.cmbCate.DisplayMember = "CategoryName";
            this.cmbCate.ValueMember = "ID";
            this.cmbGread.DataSource = Enum.GetValues(typeof(EnumRequireGread));
            this.cmbStatus.DataSource = Enum.GetValues(typeof(EnumRequireStauts));
        }
        public UC_ShowRequirementInfo(bool isNew) : this()
        {
            if (isNew)
            {
                this.htmlEditor1.ShowToolBar = true;
                this.tbxTitle.Enabled = true;
                this.cmbCate.Enabled = true;
                this.cmbGread.Enabled = true;
                this.cmbStatus.SelectedIndex = (int)EnumRequireStauts.未发布;
            }
        }
        public UC_ShowRequirementInfo(Guid id) : this()
        {
            this.requirement = bll.Query(u => u.ID == id).FirstOrDefault();
            CheckIsMine(id);
            this.Load += UC_ShowRequirementInfo_Load;

        }
        /// <summary>
        /// 根据权限控制UI
        /// </summary>
        /// <param name="id"></param>
        private void CheckIsMine(Guid id)
        {
            if (bll.GetRoleName(Program.loginUserID).Any(u => u == "管理员"))
            {
                //如果是管理员，则显示“删除”
                this.btnDel.Visible = true;
            }
            else if (bll.GetRoleName(Program.loginUserID).Any(u => u == "学生"))
            {
                //显示竞标
                this.btnWant.Visible = true;
            }
            else
            {
                if (bll.Query(u => u.ID == id && u.PostID == Program.loginUserID).Any())
                {
                    //自己发布的需求，还没有成交的话则可以更改。
                    if (this.requirement.Status < (int)EnumRequireStauts.成交)
                    {
                        this.htmlEditor1.ShowToolBar = true;
                        this.tbxTitle.Enabled = true;
                        this.cmbCate.Enabled = true;
                        this.cmbGread.Enabled = true;
                        this.dtiDate.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// load时加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_ShowRequirementInfo_Load(object sender, EventArgs e)
        {
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
            var ctl = Tools.CheckIllegalControls(this.tbxTitle, this.cmbCate, this.cmbGread, this.cmbStatus, this.htmlEditor1);
            if (ctl != null)
            {
                ctl.Focus();
                MessageBox.Show("您还有信息未录入哦！");
                return;
            }
            bool isNew = false;
            if (requirement == null)
            {
                isNew = true;
                requirement = new t_Requirement() { ID = Guid.NewGuid(), PostID = Program.loginUserID };
            }
            requirement.Title = this.tbxTitle.Text;
            requirement.CategoryID = new Guid(this.cmbCate.SelectedValue.ToString());
            requirement.Gread = this.cmbGread.SelectedIndex;
            requirement.Status = this.cmbStatus.SelectedIndex;
            requirement.PostDate = this.dtiDate.Value;
            requirement.Content = this.htmlEditor1.BodyHtml;
            if (MessageBox.Show("是否立即发布", "发布?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                requirement.Status = (int)EnumRequireStauts.发布;
            }
            else
            {
                requirement.Status = (int)EnumRequireStauts.未发布;
            }
            if (isNew ? bll.Add(this.requirement) : bll.Update(this.requirement))
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
            if (obj != null)
            {
                var id = new Guid(obj.ToString());
                this.requirement = bll.QueryNoTracking(u => u.ID == id).FirstOrDefault();
                CheckIsMine(id);
                this.UC_ShowRequirementInfo_Load(null, null);
            }
        }

        private void btnWant_Click(object sender, EventArgs e)
        {

        }
    }
}
