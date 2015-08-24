namespace _01UI
{
    partial class UC_Session
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChatHistory = new WinHtmlEditor.HtmlEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.ChatBox = new WinHtmlEditor.HtmlEditor();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ChatHistory);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1149, 487);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 0;
            // 
            // ChatHistory
            // 
            this.ChatHistory.AutoScroll = true;
            this.ChatHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChatHistory.BodyInnerHTML = null;
            this.ChatHistory.BodyInnerText = null;
            this.ChatHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatHistory.EnterToBR = false;
            this.ChatHistory.FontSize = WinHtmlEditor.FontSize.Three;
            this.ChatHistory.Location = new System.Drawing.Point(0, 0);
            this.ChatHistory.Name = "ChatHistory";
            this.ChatHistory.ReadOnly = true;
            this.ChatHistory.ShowStatusBar = false;
            this.ChatHistory.ShowToolBar = false;
            this.ChatHistory.ShowWb = true;
            this.ChatHistory.Size = new System.Drawing.Size(762, 321);
            this.ChatHistory.TabIndex = 0;
            this.ChatHistory.WebBrowserShortcutsEnabled = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.ChatBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 166);
            this.panel1.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(673, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 166);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChatBox.BodyInnerHTML = null;
            this.ChatBox.BodyInnerText = null;
            this.ChatBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChatBox.EnterToBR = false;
            this.ChatBox.FontSize = WinHtmlEditor.FontSize.Three;
            this.ChatBox.Location = new System.Drawing.Point(0, 0);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ShowStatusBar = true;
            this.ChatBox.ShowToolBar = true;
            this.ChatBox.ShowWb = true;
            this.ChatBox.Size = new System.Drawing.Size(673, 166);
            this.ChatBox.TabIndex = 2;
            this.ChatBox.WebBrowserShortcutsEnabled = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(383, 487);
            this.treeView1.TabIndex = 1;
            // 
            // UC_Session
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UC_Session";
            this.Size = new System.Drawing.Size(1149, 487);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinHtmlEditor.HtmlEditor ChatHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private WinHtmlEditor.HtmlEditor ChatBox;
        private System.Windows.Forms.TreeView treeView1;
    }
}
