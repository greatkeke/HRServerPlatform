namespace _01UI
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.tbxPwd = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnReGetPwd = new System.Windows.Forms.Button();
            this.ckbAuto = new System.Windows.Forms.CheckBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.ckbRemeber = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxPwd
            // 
            this.tbxPwd.Location = new System.Drawing.Point(136, 64);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.Size = new System.Drawing.Size(181, 21);
            this.tbxPwd.TabIndex = 4;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(136, 25);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(181, 21);
            this.tbxName.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(136, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(185, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnReGetPwd
            // 
            this.btnReGetPwd.Location = new System.Drawing.Point(333, 64);
            this.btnReGetPwd.Name = "btnReGetPwd";
            this.btnReGetPwd.Size = new System.Drawing.Size(75, 23);
            this.btnReGetPwd.TabIndex = 7;
            this.btnReGetPwd.Text = "找回密码";
            this.btnReGetPwd.UseVisualStyleBackColor = true;
            // 
            // ckbAuto
            // 
            this.ckbAuto.AutoSize = true;
            this.ckbAuto.Location = new System.Drawing.Point(243, 113);
            this.ckbAuto.Name = "ckbAuto";
            this.ckbAuto.Size = new System.Drawing.Size(72, 16);
            this.ckbAuto.TabIndex = 8;
            this.ckbAuto.Text = "自动登陆";
            this.ckbAuto.UseVisualStyleBackColor = true;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(333, 25);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 7;
            this.btnReg.Text = "注册账号";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // ckbRemeber
            // 
            this.ckbRemeber.AutoSize = true;
            this.ckbRemeber.Location = new System.Drawing.Point(136, 113);
            this.ckbRemeber.Name = "ckbRemeber";
            this.ckbRemeber.Size = new System.Drawing.Size(72, 16);
            this.ckbRemeber.TabIndex = 8;
            this.ckbRemeber.Text = "记住密码";
            this.ckbRemeber.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 104);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 201);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ckbRemeber);
            this.Controls.Add(this.ckbAuto);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnReGetPwd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.tbxPwd);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxPwd;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnReGetPwd;
        private System.Windows.Forms.CheckBox ckbAuto;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.CheckBox ckbRemeber;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}