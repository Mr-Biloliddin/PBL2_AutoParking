namespace OnlineAutoParking
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabAuth = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginHint = new System.Windows.Forms.Label();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.tlpRegister = new System.Windows.Forms.TableLayoutPanel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRegisterUsername = new System.Windows.Forms.Label();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.lblRegisterPassword = new System.Windows.Forms.Label();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tabAuth.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tlpLogin.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tlpRegister.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(444, 86);
            this.pnlHeader.TabIndex = 0;
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(194)))), ((int)(((byte)(217)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(250, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Tizimga kiring yoki ro‘yxatdan o‘ting";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ONLINE AUTOPARKING";
            //
            // tabAuth
            //
            this.tabAuth.Controls.Add(this.tabLogin);
            this.tabAuth.Controls.Add(this.tabRegister);
            this.tabAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAuth.Location = new System.Drawing.Point(0, 86);
            this.tabAuth.Name = "tabAuth";
            this.tabAuth.Padding = new System.Drawing.Point(16, 6);
            this.tabAuth.SelectedIndex = 0;
            this.tabAuth.Size = new System.Drawing.Size(444, 395);
            this.tabAuth.TabIndex = 1;
            this.tabAuth.SelectedIndexChanged += new System.EventHandler(this.tabAuth_SelectedIndexChanged);
            //
            // tabLogin
            //
            this.tabLogin.BackColor = System.Drawing.Color.White;
            this.tabLogin.Controls.Add(this.tlpLogin);
            this.tabLogin.Location = new System.Drawing.Point(4, 32);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Size = new System.Drawing.Size(436, 359);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Kirish";
            //
            // tlpLogin
            //
            this.tlpLogin.ColumnCount = 1;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogin.Controls.Add(this.lblLoginUsername, 0, 0);
            this.tlpLogin.Controls.Add(this.txtLoginUsername, 0, 1);
            this.tlpLogin.Controls.Add(this.lblLoginPassword, 0, 2);
            this.tlpLogin.Controls.Add(this.txtLoginPassword, 0, 3);
            this.tlpLogin.Controls.Add(this.btnLogin, 0, 4);
            this.tlpLogin.Controls.Add(this.lblLoginHint, 0, 5);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(0, 0);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.Padding = new System.Windows.Forms.Padding(32, 22, 32, 10);
            this.tlpLogin.RowCount = 7;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogin.Size = new System.Drawing.Size(436, 359);
            this.tlpLogin.TabIndex = 0;
            //
            // lblLoginUsername
            //
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.TabIndex = 0;
            this.lblLoginUsername.Text = "Login";
            //
            // txtLoginUsername
            //
            this.txtLoginUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoginUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.txtLoginUsername.MaxLength = 30;
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.TabIndex = 1;
            //
            // lblLoginPassword
            //
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Margin = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.TabIndex = 2;
            this.lblLoginPassword.Text = "Parol";
            //
            // txtLoginPassword
            //
            this.txtLoginPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.txtLoginPassword.MaxLength = 100;
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.TabIndex = 3;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            //
            // btnLogin
            //
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(366, 44);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Kirish";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            //
            // lblLoginHint
            //
            this.lblLoginHint.AutoSize = true;
            this.lblLoginHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblLoginHint.Margin = new System.Windows.Forms.Padding(3, 14, 3, 0);
            this.lblLoginHint.MaximumSize = new System.Drawing.Size(366, 0);
            this.lblLoginHint.Name = "lblLoginHint";
            this.lblLoginHint.TabIndex = 5;
            this.lblLoginHint.Text = "Hisobingiz yo‘qmi? \"Ro‘yxatdan o‘tish\" bo‘limiga o‘ting.";
            //
            // tabRegister
            //
            this.tabRegister.BackColor = System.Drawing.Color.White;
            this.tabRegister.Controls.Add(this.tlpRegister);
            this.tabRegister.Location = new System.Drawing.Point(4, 32);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Size = new System.Drawing.Size(436, 359);
            this.tabRegister.TabIndex = 1;
            this.tabRegister.Text = "Ro‘yxatdan o‘tish";
            //
            // tlpRegister
            //
            this.tlpRegister.ColumnCount = 1;
            this.tlpRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRegister.Controls.Add(this.lblFullName, 0, 0);
            this.tlpRegister.Controls.Add(this.txtFullName, 0, 1);
            this.tlpRegister.Controls.Add(this.lblRegisterUsername, 0, 2);
            this.tlpRegister.Controls.Add(this.txtRegisterUsername, 0, 3);
            this.tlpRegister.Controls.Add(this.lblRegisterPassword, 0, 4);
            this.tlpRegister.Controls.Add(this.txtRegisterPassword, 0, 5);
            this.tlpRegister.Controls.Add(this.lblConfirmPassword, 0, 6);
            this.tlpRegister.Controls.Add(this.txtConfirmPassword, 0, 7);
            this.tlpRegister.Controls.Add(this.btnRegister, 0, 8);
            this.tlpRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRegister.Location = new System.Drawing.Point(0, 0);
            this.tlpRegister.Name = "tlpRegister";
            this.tlpRegister.Padding = new System.Windows.Forms.Padding(32, 10, 32, 6);
            this.tlpRegister.RowCount = 10;
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRegister.Size = new System.Drawing.Size(436, 359);
            this.tlpRegister.TabIndex = 0;
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Ism va familiya";
            //
            // txtFullName
            //
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.TabIndex = 1;
            //
            // lblRegisterUsername
            //
            this.lblRegisterUsername.AutoSize = true;
            this.lblRegisterUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.lblRegisterUsername.Name = "lblRegisterUsername";
            this.lblRegisterUsername.TabIndex = 2;
            this.lblRegisterUsername.Text = "Login (harf va raqamlar, 3–30 belgi)";
            //
            // txtRegisterUsername
            //
            this.txtRegisterUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegisterUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtRegisterUsername.MaxLength = 30;
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.TabIndex = 3;
            //
            // lblRegisterPassword
            //
            this.lblRegisterPassword.AutoSize = true;
            this.lblRegisterPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.lblRegisterPassword.Name = "lblRegisterPassword";
            this.lblRegisterPassword.TabIndex = 4;
            this.lblRegisterPassword.Text = "Parol (kamida 6 belgi)";
            //
            // txtRegisterPassword
            //
            this.txtRegisterPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegisterPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtRegisterPassword.MaxLength = 100;
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.TabIndex = 5;
            this.txtRegisterPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Parolni tasdiqlang";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtConfirmPassword.MaxLength = 100;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            //
            // btnRegister
            //
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(366, 44);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Ro‘yxatdan o‘tish";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // LoginForm
            //
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(444, 481);
            this.Controls.Add(this.tabAuth);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online AutoParking — Kirish";
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabAuth.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tlpLogin.ResumeLayout(false);
            this.tlpLogin.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tlpRegister.ResumeLayout(false);
            this.tlpRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabAuth;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TableLayoutPanel tlpLogin;
        private System.Windows.Forms.Label lblLoginUsername;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginHint;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.TableLayoutPanel tlpRegister;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRegisterUsername;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.Label lblRegisterPassword;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
    }
}
