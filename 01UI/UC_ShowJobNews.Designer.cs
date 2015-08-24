namespace _01UI
{
    partial class UC_ShowJobNews
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAuther = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.htmlEditor1 = new WinHtmlEditor.HtmlEditor();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxAuther, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.htmlEditor1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDel, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(898, 526);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbxTitle, 3);
            this.tbxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTitle.Location = new System.Drawing.Point(53, 3);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(842, 21);
            this.tbxTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "作者";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxAuther
            // 
            this.tbxAuther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxAuther.Location = new System.Drawing.Point(53, 28);
            this.tbxAuther.Name = "tbxAuther";
            this.tbxAuther.Size = new System.Drawing.Size(313, 21);
            this.tbxAuther.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(372, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Location = new System.Drawing.Point(422, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(473, 21);
            this.dtpDate.TabIndex = 5;
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.htmlEditor1.BodyInnerHTML = null;
            this.htmlEditor1.BodyInnerText = null;
            this.tableLayoutPanel1.SetColumnSpan(this.htmlEditor1, 4);
            this.htmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditor1.EnterToBR = false;
            this.htmlEditor1.FontSize = WinHtmlEditor.FontSize.Three;
            this.htmlEditor1.Location = new System.Drawing.Point(3, 53);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ShowStatusBar = true;
            this.htmlEditor1.ShowToolBar = true;
            this.htmlEditor1.ShowWb = true;
            this.htmlEditor1.Size = new System.Drawing.Size(892, 440);
            this.htmlEditor1.TabIndex = 6;
            this.htmlEditor1.WebBrowserShortcutsEnabled = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(682, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(213, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "发布";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.Location = new System.Drawing.Point(53, 499);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(313, 24);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // UC_ShowJobNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_ShowJobNews";
            this.Size = new System.Drawing.Size(898, 526);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAuther;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private WinHtmlEditor.HtmlEditor htmlEditor1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
    }
}
