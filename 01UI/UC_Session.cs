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
    public partial class UC_Session : UserControl, IRefreshable
    {
        BaseBLL<t_Session> sessionBll = new BaseBLL<t_Session>();
        BaseBLL<t_User> userBll = new BaseBLL<t_User>();
        BaseBLL<t_ChatContent> chatBll = new BaseBLL<t_ChatContent>();
        BaseBLL<t_Requirement> reqBll = new BaseBLL<t_Requirement>();
        private string _role;
        public UC_Session()
        {
            InitializeComponent();
            this.treeView1.DoubleClick += treeView1_DoubleClick;
        }

        public UC_Session(Guid id) : this()
        {
            //初始化左边《会话》列表
            //学生：展示需求方
            var roles = sessionBll.GetRoleName(Program.loginUserID);
            if (roles.Any(u => u == "学生"))
            {
                _role = "学生";
                //企业名1
                //  需求1
                //  需求2
                var sessionList = sessionBll.Query(u => u.AchivementID == id);
                var users = userBll.Query(a => sessionList.Select(u => u.RequireID).Contains(a.ID));//一级节点
                var reqs = reqBll.Query(a => users.Select(u => u.ID).Contains(a.PostID));//二级节点
                StuAttachToTree(users.ToList(), reqs.ToList(), this.treeView1);
            }
            //企业：展示实现者
            if (roles.Any(u => u == "企业"))
            {
                _role = "企业";
                //需求1
                //  实现者1
                //  实现者2
                var reqs = reqBll.Query(a => a.PostID == Program.loginUserID);//一级节点
                var ses = sessionBll.Query(u => u.RequireID == Program.loginUserID);
                var users = userBll.Query(a => ses.Select(u => u.AchivementID).Contains(a.ID));//二级节点
                EntAttachToTree(reqs.ToList(), users.ToList(), ses.ToList(), this.treeView1);
            }
        }

        private void EntAttachToTree(List<t_Requirement> reqs, List<t_User> users, List<t_Session> ses, TreeView treeView1)
        {
            foreach (var req in reqs)
            {
                var node = new TreeNode() { Text = "需求：" + req.Title, Tag = req.ID };
                node.Expand();
                treeView1.Nodes.Add(node);
                foreach (var ach in users)
                {
                    var acher = ses.Where(u => u.RequirementID == req.ID).Select(u => u.AchivementID).FirstOrDefault();
                    if (ach.ID == acher)
                    {
                        var cnode = new TreeNode() { Text = "学生：" + ach.User, Tag = ach.ID };
                        node.Nodes.Add(cnode);
                    }
                }
            }
        }

        /// <summary>
        /// 加载到树上
        /// </summary>
        /// <param name="users">一级节点</param>
        /// <param name="reqs">二级节点</param>
        /// <param name="treeView1">树</param>
        private void StuAttachToTree(List<t_User> users, List<t_Requirement> reqs, TreeView treeView1)
        {
            foreach (var item in users)
            {
                var node = new TreeNode() { Text = "企业：" + item.User, Tag = item.ID };
                node.Expand();
                this.treeView1.Nodes.Add(node);
                foreach (var req in reqs)
                {
                    if (req.PostID == item.ID)
                    {
                        var cnode = new TreeNode() { Text = "需求：" + req.Title, Tag = req.ID };
                        node.Nodes.Add(cnode);
                    }
                }
            }
        }

        /// <summary>
        /// 双击会话，在右边展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //获取选中的节点
            var node = this.treeView1.SelectedNode;
            if (node.Nodes.Count > 0) return;
            if (node.Tag == null) return;
            var id = new Guid(node.Tag.ToString());
            var session = new t_Session();
            if (_role == "学生")
            {
                //需求ID
                session = sessionBll.Query(u => u.RequirementID == id && u.AchivementID == Program.loginUserID).FirstOrDefault();

            }
            else
            {
                //企业
                //学生ID
                session = sessionBll.Query(u => u.AchivementID == id && u.RequireID == Program.loginUserID).FirstOrDefault();
            }
            //获取聊天记录→填充到左侧chatBoxHistory
            if (session == null) return;
            var chats = chatBll.Query(u => u.SessionID == session.ID).OrderBy(u=>u.Date).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in chats)
            {

                sb.AppendLine(item.Content+ "</P>");
            }
            this.ChatHistory.BodyHtml = sb.ToString();
        }
        /// <summary>
        /// 点击发送 输出内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //数据剥皮
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="obj"></param>
        public void Refresh(object obj)
        {
            throw new NotImplementedException();
        }
        //后台线程，监听socket，随时载入数据。
    }
}
