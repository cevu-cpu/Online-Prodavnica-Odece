namespace Online_Prodavnica_Odece
{
    partial class FormProfil
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
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.Text = "MY PROFILE";
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.Location = new System.Drawing.Point(0, 0);
            this.lblNaslov.Size = new System.Drawing.Size(800, 80);
            this.lblNaslov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Text = "✕";
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(765, 5);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Name = "btnClose";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(50, 120);
            this.lblUser.Text = "Korisničko ime:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(200, 116);
            this.txtUser.Width = 300;
            this.txtUser.ReadOnly = true;
            this.txtUser.Name = "txtUser";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(50, 160);
            this.lblFullName.Text = "Ime:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(200, 156);
            this.txtIme.Width = 300;
            this.txtIme.ReadOnly = true;
            this.txtIme.Name = "txtIme";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 200);
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(200, 196);
            this.txtEmail.Width = 300;
            this.txtEmail.Name = "txtEmail";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(50, 240);
            this.lblAdresa.Text = "Adresa:";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(200, 236);
            this.txtAdresa.Width = 300;
            this.txtAdresa.Name = "txtAdresa";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(50, 280);
            this.lblNewPass.Text = "Nova lozinka:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(200, 276);
            this.txtNewPass.Width = 300;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '●';
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 320);
            this.btnSave.Size = new System.Drawing.Size(200, 35);
            this.btnSave.Text = "Sačuvaj promene";
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Name = "btnSave";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(420, 320);
            this.btnLogout.Size = new System.Drawing.Size(80, 35);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Name = "btnLogout";
            // 
            // FormProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLogout);
            this.Name = "FormProfil";
            this.Text = "Profil";
            this.Load += new System.EventHandler(this.FormProfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLogout;
    }
}