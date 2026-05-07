namespace Online_Prodavnica_Odece
{
    partial class AdminForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnKorisnici = new System.Windows.Forms.Button();
            this.btnNarudzbine = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.lblTabelaNaslov = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlSidebar.Controls.Add(this.btnKorisnici);
            this.pnlSidebar.Controls.Add(this.btnNarudzbine);
            this.pnlSidebar.Controls.Add(this.btnDodajProizvod);
            this.pnlSidebar.Controls.Add(this.lblAdminTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnKorisnici
            // 
            this.btnKorisnici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKorisnici.FlatAppearance.BorderSize = 0;
            this.btnKorisnici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKorisnici.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKorisnici.ForeColor = System.Drawing.Color.White;
            this.btnKorisnici.Location = new System.Drawing.Point(0, 200);
            this.btnKorisnici.Name = "btnKorisnici";
            this.btnKorisnici.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKorisnici.Size = new System.Drawing.Size(220, 45);
            this.btnKorisnici.TabIndex = 3;
            this.btnKorisnici.Text = "KORISNICI";
            this.btnKorisnici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKorisnici.UseVisualStyleBackColor = true;
            // 
            // btnNarudzbine
            // 
            this.btnNarudzbine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNarudzbine.FlatAppearance.BorderSize = 0;
            this.btnNarudzbine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNarudzbine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNarudzbine.ForeColor = System.Drawing.Color.White;
            this.btnNarudzbine.Location = new System.Drawing.Point(0, 150);
            this.btnNarudzbine.Name = "btnNarudzbine";
            this.btnNarudzbine.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNarudzbine.Size = new System.Drawing.Size(220, 45);
            this.btnNarudzbine.TabIndex = 2;
            this.btnNarudzbine.Text = "LISTA PORUDŽBINA";
            this.btnNarudzbine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNarudzbine.UseVisualStyleBackColor = true;
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajProizvod.FlatAppearance.BorderSize = 0;
            this.btnDodajProizvod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajProizvod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDodajProizvod.ForeColor = System.Drawing.Color.White;
            this.btnDodajProizvod.Location = new System.Drawing.Point(0, 100);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDodajProizvod.Size = new System.Drawing.Size(220, 45);
            this.btnDodajProizvod.TabIndex = 1;
            this.btnDodajProizvod.Text = "DODAJ PROIZVOD";
            this.btnDodajProizvod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDodajProizvod.UseVisualStyleBackColor = true;
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.ForeColor = System.Drawing.Color.White;
            this.lblAdminTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(220, 80);
            this.lblAdminTitle.TabIndex = 0;
            this.lblAdminTitle.Text = "FLASH ADMIN";
            this.lblAdminTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvProizvodi);
            this.pnlMain.Controls.Add(this.lblTabelaNaslov);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(220, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(880, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.BackgroundColor = System.Drawing.Color.White;
            this.dgvProizvodi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProizvodi.Location = new System.Drawing.Point(20, 60);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.RowHeadersWidth = 51;
            this.dgvProizvodi.RowTemplate.Height = 24;
            this.dgvProizvodi.Size = new System.Drawing.Size(840, 620);
            this.dgvProizvodi.TabIndex = 1;
            // 
            // lblTabelaNaslov
            // 
            this.lblTabelaNaslov.AutoSize = true;
            this.lblTabelaNaslov.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabelaNaslov.Location = new System.Drawing.Point(20, 15);
            this.lblTabelaNaslov.Name = "lblTabelaNaslov";
            this.lblTabelaNaslov.Size = new System.Drawing.Size(248, 28);
            this.lblTabelaNaslov.TabIndex = 0;
            this.lblTabelaNaslov.Text = "PREGLED SVIH PROIZVODA";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN DASHBOARD";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.Button btnKorisnici;
        private System.Windows.Forms.Button btnNarudzbine;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.Label lblTabelaNaslov;
    }
}