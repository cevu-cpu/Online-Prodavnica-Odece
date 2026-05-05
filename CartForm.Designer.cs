namespace Online_Prodavnica_Odece
{
    partial class CartForm
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
            this.lvKorpa = new System.Windows.Forms.ListView();
            this.btnNaplata = new System.Windows.Forms.Button();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvKorpa
            // 
            this.lvKorpa.View = System.Windows.Forms.View.Details;
            this.lvKorpa.FullRowSelect = true;
            this.lvKorpa.Location = new System.Drawing.Point(12, 12);
            this.lvKorpa.Size = new System.Drawing.Size(560, 280);
            this.lvKorpa.Columns.Add("Proizvod", 300);
            this.lvKorpa.Columns.Add("Količina", 80);
            this.lvKorpa.Columns.Add("Cena", 100);
            this.lvKorpa.FullRowSelect = true;
            this.lvKorpa.MultiSelect = false;
            // 
            // lblUkupno
            // 
            this.lblUkupno.Location = new System.Drawing.Point(12, 300);
            this.lblUkupno.Size = new System.Drawing.Size(560, 23);
            this.lblUkupno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUkupno.Text = "Ukupno: 0 RSD";
            // 
            // btnNaplata
            // 
            this.btnNaplata.Location = new System.Drawing.Point(472, 328);
            this.btnNaplata.Size = new System.Drawing.Size(100, 30);
            this.btnNaplata.Text = "Naplata";
            this.btnNaplata.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnNaplata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // btnUkloni
            // 
            this.btnUkloni = new System.Windows.Forms.Button();
            this.btnUkloni.Location = new System.Drawing.Point(12, 328);
            this.btnUkloni.Size = new System.Drawing.Size(100, 30);
            this.btnUkloni.Text = "Ukloni";
            this.btnUkloni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // btnPovecaj
            // 
            this.btnPovecaj = new System.Windows.Forms.Button();
            this.btnPovecaj.Location = new System.Drawing.Point(118, 328);
            this.btnPovecaj.Size = new System.Drawing.Size(40, 30);
            this.btnPovecaj.Text = "+";
            this.btnPovecaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // btnSmanji
            // 
            this.btnSmanji = new System.Windows.Forms.Button();
            this.btnSmanji.Location = new System.Drawing.Point(164, 328);
            this.btnSmanji.Size = new System.Drawing.Size(40, 30);
            this.btnSmanji.Text = "-";
            this.btnSmanji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // CartForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 371);
            this.Controls.Add(this.btnNaplata);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnPovecaj);
            this.Controls.Add(this.btnSmanji);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.lvKorpa);
            this.Name = "CartForm";
            this.Text = "Korpa";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lvKorpa;
        private System.Windows.Forms.Button btnNaplata;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.Button btnPovecaj;
        private System.Windows.Forms.Button btnSmanji;
    }
}
