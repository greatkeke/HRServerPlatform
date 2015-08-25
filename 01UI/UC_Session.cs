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
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace _01UI
{
    public partial class UC_Session : UserControl, IRefreshable
    {
        BaseBLL<t_Session> sessionBll = new BaseBLL<t_Session>();
        BaseBLL<t_User> userBll = new BaseBLL<t_User>();
        BaseBLL<t_ChatContent> chatBll = new BaseBLL<t_ChatContent>();
        BaseBLL<t_Requirement> reqBll = new BaseBLL<t_Requirement>();
        private string _role;
        //当前正在进行的会话
        private t_Session _session = new t_Session();
        //会话服务器
        private Socket _sessionServer;
        BaseBLL<t_Orders> ordBll = new BaseBLL<t_Orders>();
        public UC_Session()
        {
            InitializeComponent();
            this.Load += UC_Session_Load;
            this.treeView1.DoubleClick += treeView1_DoubleClick;
        }

        private void UC_Session_Load(object sender, EventArgs e)
        {
            #region 初始化左边《会话》列表
            //学生：展示需求方
            var roles = sessionBll.GetRoleName(Program.loginUserID);
            if (roles.Any(u => u == "学生"))
            {
                _role = "学生";
                //企业名1
                //  需求1
                //  需求2
                var sessionList = sessionBll.Query(u => u.AchivementID == Program.loginUserID);
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
                this.ContextMenuStrip = contextMenuStrip1;
            }
            #endregion

            //启动Socket
            //后台线程，监听socket，随时载入数据。
            InitSocketClient();
        }

        private void InitSocketClient()
        {
            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var point = new IPEndPoint(new IPAddress(new Byte[] { 127, 0, 0, 1 }), 60000);
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        serverSocket.Connect(point);
                        _sessionServer = serverSocket;//连上服务器之后，就保存会话服务器的socket。
                    }
                    catch
                    {
                    }
                    while (serverSocket.Connected)
                    {
                        var buff = new Byte[1024];
                        serverSocket.Receive(buff);
                        var msg = Tools.DeserializeObject(buff);//接受消息
                        //判断是否展示
                        if (msg.ListenID == Program.loginUserID)
                        {
                            ShowMsg(msg);
                        }
                    }
                }
            });
        }

        private void ShowMsg(Msg msg)
        {
            var history = this.ChatHistory.BodyInnerHTML;
            this.ChatHistory.BodyHtml = history + MyMsg(msg.Content);
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

            if (_role == "学生")
            {
                //需求ID
                _session = sessionBll.Query(u => u.RequirementID == id && u.AchivementID == Program.loginUserID).FirstOrDefault();

            }
            else
            {
                //企业
                //学生ID
                _session = sessionBll.Query(u => u.AchivementID == id && u.RequireID == Program.loginUserID).FirstOrDefault();
            }
            //获取聊天记录→填充到左侧chatBoxHistory
            if (_session == null) return;
            var chats = chatBll.Query(u => u.SessionID == _session.ID).OrderBy(u => u.Date).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in chats)
            {
                //<P align=right>这是我的个人资料。</P>
                if (item.SpeakID != Program.loginUserID)
                {
                    sb.AppendLine(item.Content + "</P>");
                }
                else
                {
                    sb.AppendLine(MyMsg(item.Content));//自己说的话放在右边
                }

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
            var msg = new Msg();
            msg.Content = ChatBox.BodyInnerHTML; //数据剥皮
            msg.SpeakID = Program.loginUserID;
            if (_session != null && _session.ID != Guid.Empty)
            {
                if (_session.AchivementID == Program.loginUserID)
                {
                    msg.ListenID = _session.RequireID;
                }
                else
                {
                    msg.ListenID = _session.AchivementID;
                }
                msg.SessionID = _session.ID;
                //发送数据到会话服务器
                if (_sessionServer != null)
                {
                    _sessionServer.Send(Tools.SerializeObject(msg));
                    //保存到服务器
                    this.chatBll.Add(new t_ChatContent()
                    {
                        ID = Guid.NewGuid(),
                        Date = DateTime.Now,
                        SessionID = _session.ID,
                        SpeakID = msg.SpeakID,
                        Content = msg.Content
                    });
                }
                else
                {
                    Console.WriteLine("前方网络故障，您的消息已被返回~~~");
                }

            }
            else
            {
                MessageBox.Show("Sorry,您似乎还没有决定和谁对话呢~~~");
                return;
            }

            var history = this.ChatHistory.BodyInnerHTML;
            this.ChatHistory.BodyHtml = history + MyMsg(msg.Content);

        }
        /// <summary>
        /// 将我说的话显示在右边
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string MyMsg(string content)
        {
            if (content.StartsWith("<P"))
            {
                content = content.Insert(2, " align=right");
            }
            else
            {
                content = "<P align=right>" + content + "</P>";
            }
            return content;
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="obj"></param>
        public void Refresh(object obj)
        {
            this.UC_Session_Load(null, null);
        }
        /// <summary>
        /// 企业和学生签约，生成订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 签约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //判断节点
                var node = this.treeView1.SelectedNode;
                if (node == null) return;
                var achid = new Guid(node.Tag.ToString());
                var pnode = node.Parent;
                if (pnode == null) return;
                var rementid = new Guid(pnode.Tag.ToString());
                if (!userBll.GetRoleName(achid).Any(u => u == "学生")) return;
                var ord = new t_Orders()
                {
                    ID = Guid.NewGuid(),
                    AchievementID = achid,
                    OrderDate = DateTime.Now,
                    RequirementID = rementid,
                    Status = (int)EnumOrderStatus.已签约
                };
                if (ordBll.Add(ord))
                {
                    MessageBox.Show("签约成功！");
                }
                else
                {
                    MessageBox.Show("未能成功签约，请稍后重试~~");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"前方高能，请稍后重试~~");
            }

        }
        /// <summary>
        /// 企业验收完项目，正是成交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 成交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //判断节点
                var node = this.treeView1.SelectedNode;
                if (node == null) return;
                var achid = new Guid(node.Tag.ToString());
                var pnode = node.Parent;
                if (pnode == null) return;
                var rementid = new Guid(pnode.Tag.ToString());
                if (!userBll.GetRoleName(achid).Any(u => u == "学生")) return;
                //查询订单
                var ord = ordBll.Query(u => u.RequirementID == rementid && u.AchievementID == achid).FirstOrDefault();
                //修改订单状态
                if (ord != null)
                {
                    ord.Status = (int)EnumOrderStatus.已成交;
                }
                if (ordBll.Update(ord))
                {
                    MessageBox.Show("已成交");
                }
                else
                {
                    MessageBox.Show("不符合成交条件，请先确认是否签约。");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"前方高能，请稍后重试");
            }
        }
    }
}
