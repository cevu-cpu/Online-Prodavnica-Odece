using System;
using System.Windows.Forms;

namespace Online_Prodavnica_Odece
{

    public class ProductEditForm : Form
    {
        public string Kategorija { get; set; }
        public byte[] SlikaBytes { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public int Kolicina { get; set; }// Form fields

        private TextBox txtNaziv;
        private TextBox txtCena;
        private TextBox txtKolicina;
        private TextBox txtKategorija;
        private Button btnBrowse;
        private PictureBox pbPreview;

        public ProductEditForm()
        {
            this.Text = "Uredi proizvod";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(400, 200);

            var lblNaziv = new Label { Text = "Naziv:", Left = 10, Top = 20 };
            txtNaziv = new TextBox { Left = 100, Top = 18, Width = 260 };

            var lblCena = new Label { Text = "Cena:", Left = 10, Top = 60 };
            txtCena = new TextBox { Left = 100, Top = 58, Width = 260 };

            var lblKolicina = new Label { Text = "Količina:", Left = 10, Top = 100 };
            txtKolicina = new TextBox { Left = 100, Top = 98, Width = 120 };

            var lblKategorija = new Label { Text = "Kategorija:", Left = 230, Top = 100 };
            txtKategorija = new TextBox { Left = 320, Top = 98, Width = 120 };

            pbPreview = new PictureBox { Left = 100, Top = 130, Width = 80, Height = 50, BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            btnBrowse = new Button { Text = "Učitaj sliku", Left = 190, Top = 140, Width = 100 };
            btnBrowse.Click += (s, e) => {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Image|*.png;*.jpg;*.jpeg;*.bmp|All|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var img = System.Drawing.Image.FromFile(dlg.FileName);
                        pbPreview.Image = img;
                        using (var ms = new System.IO.MemoryStream())
                        {
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            SlikaBytes = ms.ToArray();
                        }
                    }
                }
            };

            var btnOk = new Button { Text = "OK", Left = 200, Width = 80, Top = 190, DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancel", Left = 290, Width = 80, Top = 190, DialogResult = DialogResult.Cancel };

            btnOk.Click += (s, e) => {
               
                if (string.IsNullOrWhiteSpace(txtNaziv.Text)) { MessageBox.Show("Unesite naziv."); this.DialogResult = DialogResult.None; return; }
                if (!decimal.TryParse(txtCena.Text, out decimal c)) { MessageBox.Show("Pogrešna cena."); this.DialogResult = DialogResult.None; return; }
                if (!int.TryParse(txtKolicina.Text, out int k)) { MessageBox.Show("Pogrešna količina."); this.DialogResult = DialogResult.None; return; }
                Naziv = txtNaziv.Text.Trim();
                Cena = c;
                Kolicina = k;
                Kategorija = txtKategorija.Text.Trim();
            };

            this.Controls.Add(lblNaziv);
            this.Controls.Add(txtNaziv);
            this.Controls.Add(lblCena);
            this.Controls.Add(txtCena);
            this.Controls.Add(lblKolicina);
            this.Controls.Add(txtKolicina);
            this.Controls.Add(lblKategorija);
            this.Controls.Add(txtKategorija);
            this.Controls.Add(pbPreview);
            this.Controls.Add(btnBrowse);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }
    }
}
