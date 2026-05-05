namespace Online_Prodavnica_Odece
{
    partial class Register
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.panelGreyOverlay = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelGreyOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIme.Location = new System.Drawing.Point(38, 95);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(180, 25);
            this.txtIme.TabIndex = 0;
            // 
            // txtPrezime
            // 
            this.txtPrezime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrezime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrezime.Location = new System.Drawing.Point(230, 95);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(180, 25);
            this.txtPrezime.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUser.Location = new System.Drawing.Point(38, 155);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(180, 25);
            this.txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPass.Location = new System.Drawing.Point(38, 215);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(372, 25);
            this.txtPass.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(230, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 25);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAdresa
            // 
            this.txtAdresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdresa.Location = new System.Drawing.Point(38, 275);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(372, 25);
            this.txtAdresa.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Black;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(38, 334);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(372, 45);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "CREATE ACCOUNT";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Underline);
            this.btnBack.Location = new System.Drawing.Point(130, 385);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 25);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Already a member? Log in";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // panelSide
            // 
            this.panelSide.BackgroundImage = global::Online_Prodavnica_Odece.Properties.Resources._61C6PNUi5UL__AC_UY1000_;
            this.panelSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSide.Location = new System.Drawing.Point(502, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(298, 440);
            this.panelSide.TabIndex = 8;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelSide);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblIme);
            this.panelMain.Controls.Add(this.txtIme);
            this.panelMain.Controls.Add(this.txtPrezime);
            this.panelMain.Controls.Add(this.lblUser);
            this.panelMain.Controls.Add(this.txtUser);
            this.panelMain.Controls.Add(this.lblPass);
            this.panelMain.Controls.Add(this.txtPass);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblAdresa);
            this.panelMain.Controls.Add(this.txtAdresa);
            this.panelMain.Controls.Add(this.btnRegister);
            this.panelMain.Controls.Add(this.btnBack);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(50, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 440);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 37);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Create Account";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblIme.ForeColor = System.Drawing.Color.Gray;
            this.lblIme.Location = new System.Drawing.Point(35, 75);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(70, 13);
            this.lblIme.TabIndex = 10;
            this.lblIme.Text = "FULL NAME";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.Gray;
            this.lblUser.Location = new System.Drawing.Point(35, 135);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(108, 13);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "USERNAME & EMAIL";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.Gray;
            this.lblPass.Location = new System.Drawing.Point(35, 195);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 13);
            this.lblPass.TabIndex = 12;
            this.lblPass.Text = "PASSWORD";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAdresa.ForeColor = System.Drawing.Color.Gray;
            this.lblAdresa.Location = new System.Drawing.Point(35, 255);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(110, 13);
            this.lblAdresa.TabIndex = 13;
            this.lblAdresa.Text = "SHIPPING ADDRESS";
            // 
            // panelGreyOverlay
            // 
            this.panelGreyOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelGreyOverlay.Controls.Add(this.panelMain);
            this.panelGreyOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGreyOverlay.Location = new System.Drawing.Point(0, 0);
            this.panelGreyOverlay.Name = "panelGreyOverlay";
            this.panelGreyOverlay.Padding = new System.Windows.Forms.Padding(50, 70, 50, 70);
            this.panelGreyOverlay.Size = new System.Drawing.Size(900, 580);
            this.panelGreyOverlay.TabIndex = 0;
            this.panelGreyOverlay.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGreyOverlay_Paint);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Online_Prodavnica_Odece.Properties.Resources.men__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.panelGreyOverlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelGreyOverlay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGreyOverlay;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblAdresa;
    }
}