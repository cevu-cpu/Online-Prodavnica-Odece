using System.Drawing;

namespace Online_Prodavnica_Odece
{
    partial class Log_in
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SigninBtn = new System.Windows.Forms.Button();
            this.UserLbl = new System.Windows.Forms.Label();
            this.PassLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubText = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUser.Location = new System.Drawing.Point(398, 100);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(320, 27);
            this.txtUser.TabIndex = 7;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPass.Location = new System.Drawing.Point(398, 160);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(320, 27);
            this.txtPass.TabIndex = 8;
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(398, 220);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(320, 40);
            this.LoginBtn.TabIndex = 11;
            this.LoginBtn.Text = "Sign In";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click_1);
            // 
            // SigninBtn
            // 
            this.SigninBtn.FlatAppearance.BorderSize = 0;
            this.SigninBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SigninBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Underline);
            this.SigninBtn.Location = new System.Drawing.Point(480, 270);
            this.SigninBtn.Name = "SigninBtn";
            this.SigninBtn.Size = new System.Drawing.Size(150, 25);
            this.SigninBtn.TabIndex = 12;
            this.SigninBtn.Text = "Don\'t have an account?";
            // 
            // UserLbl
            // 
            this.UserLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.UserLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.UserLbl.Location = new System.Drawing.Point(395, 80);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(100, 23);
            this.UserLbl.TabIndex = 9;
            this.UserLbl.Text = "USERNAME";
            // 
            // PassLbl
            // 
            this.PassLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.PassLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.PassLbl.Location = new System.Drawing.Point(395, 140);
            this.PassLbl.Name = "PassLbl";
            this.PassLbl.Size = new System.Drawing.Size(100, 23);
            this.PassLbl.TabIndex = 10;
            this.PassLbl.Text = "PASSWORD";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Online_Prodavnica_Odece.Properties.Resources.men__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 331);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.lblWelcome);
            this.panel2.Controls.Add(this.lblSubText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 331);
            this.panel2.TabIndex = 7;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(25, 100);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back!";
            // 
            // lblSubText
            // 
            this.lblSubText.BackColor = System.Drawing.Color.Transparent;
            this.lblSubText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.lblSubText.Location = new System.Drawing.Point(28, 145);
            this.lblSubText.Name = "lblSubText";
            this.lblSubText.Size = new System.Drawing.Size(300, 20);
            this.lblSubText.TabIndex = 1;
            this.lblSubText.Text = "Discover the latest trends now";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.txtUser);
            this.panelMain.Controls.Add(this.txtPass);
            this.panelMain.Controls.Add(this.UserLbl);
            this.panelMain.Controls.Add(this.PassLbl);
            this.panelMain.Controls.Add(this.LoginBtn);
            this.panelMain.Controls.Add(this.SigninBtn);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(40, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(757, 331);
            this.panelMain.TabIndex = 9;
            // 
            // Log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Online_Prodavnica_Odece.Properties.Resources.men__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(837, 451);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Log_in";
            this.Padding = new System.Windows.Forms.Padding(40, 60, 40, 60);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clothing Store Login";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button SigninBtn;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.Label PassLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubText;
    }
}