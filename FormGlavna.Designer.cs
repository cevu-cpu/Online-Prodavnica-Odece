namespace Online_Prodavnica_Odece
{
    partial class FormGlavna
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
            this.pnlUserSection = new System.Windows.Forms.Panel();
            this.btnProfil = new System.Windows.Forms.Button();
            this.btnPregledKorpe = new System.Windows.Forms.Button();
            this.pnlLogoContainer = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlCategoryScroll = new System.Windows.Forms.FlowLayoutPanel();
            this.lblKategorijaNaslov = new System.Windows.Forms.Label();
            this.flpProizvodi = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserSection.SuspendLayout();
            this.pnlLogoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.pnlSidebar.Controls.Add(this.pnlUserSection);
            this.pnlSidebar.Controls.Add(this.pnlLogoContainer);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            this.pnlSidebar.TabIndex = 2;
            // 
            // pnlUserSection
            // 
            this.pnlUserSection.Controls.Add(this.btnProfil);
            this.pnlUserSection.Controls.Add(this.btnPregledKorpe);
            this.pnlUserSection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserSection.Location = new System.Drawing.Point(0, 550);
            this.pnlUserSection.Name = "pnlUserSection";
            this.pnlUserSection.Padding = new System.Windows.Forms.Padding(20);
            this.pnlUserSection.Size = new System.Drawing.Size(240, 150);
            this.pnlUserSection.TabIndex = 0;
            // 
            // btnProfil
            // 
            this.btnProfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfil.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfil.ForeColor = System.Drawing.Color.White;
            this.btnProfil.Location = new System.Drawing.Point(20, 20);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(200, 40);
            this.btnProfil.TabIndex = 0;
            this.btnProfil.Text = "MOJ PROFIL";
            // 
            // btnPregledKorpe
            // 
            this.btnPregledKorpe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPregledKorpe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPregledKorpe.FlatAppearance.BorderSize = 0;
            this.btnPregledKorpe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPregledKorpe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPregledKorpe.ForeColor = System.Drawing.Color.White;
            this.btnPregledKorpe.Location = new System.Drawing.Point(20, 85);
            this.btnPregledKorpe.Name = "btnPregledKorpe";
            this.btnPregledKorpe.Size = new System.Drawing.Size(200, 45);
            this.btnPregledKorpe.TabIndex = 1;
            this.btnPregledKorpe.Text = "KORPA (0)";
            this.btnPregledKorpe.UseVisualStyleBackColor = false;
            // 
            // pnlLogoContainer
            // 
            this.pnlLogoContainer.Controls.Add(this.pbLogo);
            this.pnlLogoContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogoContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoContainer.Name = "pnlLogoContainer";
            this.pnlLogoContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLogoContainer.Size = new System.Drawing.Size(240, 120);
            this.pnlLogoContainer.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::Online_Prodavnica_Odece.Properties.Resources.Gemini_Generated_Image_b70r5xb70r5xb70r;
            this.pbLogo.Location = new System.Drawing.Point(20, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 80);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pnlCategoryScroll);
            this.pnlHeader.Controls.Add(this.lblKategorijaNaslov);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 100);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlCategoryScroll
            // 
            this.pnlCategoryScroll.AutoScroll = true;
            this.pnlCategoryScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCategoryScroll.Location = new System.Drawing.Point(0, 60);
            this.pnlCategoryScroll.Name = "pnlCategoryScroll";
            this.pnlCategoryScroll.Size = new System.Drawing.Size(960, 40);
            this.pnlCategoryScroll.TabIndex = 0;
            this.pnlCategoryScroll.WrapContents = false;
            // 
            // lblKategorijaNaslov
            // 
            this.lblKategorijaNaslov.AutoSize = true;
            this.lblKategorijaNaslov.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKategorijaNaslov.Location = new System.Drawing.Point(20, 15);
            this.lblKategorijaNaslov.Name = "lblKategorijaNaslov";
            this.lblKategorijaNaslov.Size = new System.Drawing.Size(238, 32);
            this.lblKategorijaNaslov.TabIndex = 1;
            this.lblKategorijaNaslov.Text = "FLASH COLLECTION";
            // 
            // flpProizvodi
            // 
            this.flpProizvodi.AutoScroll = true;
            this.flpProizvodi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.flpProizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProizvodi.Location = new System.Drawing.Point(240, 100);
            this.flpProizvodi.Name = "flpProizvodi";
            this.flpProizvodi.Padding = new System.Windows.Forms.Padding(30);
            this.flpProizvodi.Size = new System.Drawing.Size(960, 600);
            this.flpProizvodi.TabIndex = 0;
            // 
            // FormGlavna
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.flpProizvodi);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormGlavna_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserSection.ResumeLayout(false);
            this.pnlLogoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpProizvodi;
        private System.Windows.Forms.Button btnPregledKorpe;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Panel pnlLogoContainer;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlUserSection;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblKategorijaNaslov;
        private System.Windows.Forms.FlowLayoutPanel pnlCategoryScroll;
    }
}