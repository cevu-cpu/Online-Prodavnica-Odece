using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Online_Prodavnica_Odece
{
    public partial class FormGlavna : Form
    {
        private CartForm cartForm;
        public FormGlavna()
        {
            InitializeComponent();
            InicijalizujKategorije();

            flpProizvodi.WrapContents = false;
            flpProizvodi.AutoScroll = true;

            this.btnProfil.Click += btnProfil_Click;
            this.btnPregledKorpe.Click += BtnPregledKorpe_Click;
        }

        private void InicijalizujKategorije()
        {
            pnlCategoryScroll.Controls.Clear();

            string[] suits = { "Suits", "Tuxedos", "Jackets & Blazers", "Pants", "Dress Pants", "Vests" };
            DodajGlavnuKategorijuSaMenijem("SUITS & TUXEDOS", suits);

            DodajSeparator();


            string[] acc = { "Dress Shirts", "Ties & Bow Ties", "Belts & Suspenders", "Shoes", "Socks", "Cufflinks", "Pocket Squares", "Cummerbunds" };
            DodajGlavnuKategorijuSaMenijem("ACCESSORIES", acc);
        }

        private void DodajGlavnuKategorijuSaMenijem(string naslov, string[] podkategorije)
        {

            Label lblGlavna = new Label();
            lblGlavna.Text = naslov + " ▼";
            lblGlavna.AutoSize = true;
            lblGlavna.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblGlavna.Cursor = Cursors.Hand;
            lblGlavna.Margin = new Padding(20, 12, 5, 0);
            lblGlavna.ForeColor = Color.Black;


            ContextMenuStrip dropDownMenu = new ContextMenuStrip();
            dropDownMenu.ShowCheckMargin = false;
            dropDownMenu.ShowImageMargin = false;
            dropDownMenu.BackColor = Color.White;
            dropDownMenu.RenderMode = ToolStripRenderMode.System;

            foreach (string item in podkategorije)
            {
                var menuItem = dropDownMenu.Items.Add(item);
                menuItem.Font = new Font("Segoe UI", 9);
                menuItem.Click += (s, e) => {
                    lblKategorijaNaslov.Text = item.ToUpper();
                    // Prikaz proizvoda iz te kategorije
                    PrikaziProizvodeZaKategoriju(item);
                };
            }

            // Event: Kada kursor UĐE na labelu
            lblGlavna.MouseEnter += (s, e) => {
                lblGlavna.ForeColor = Color.FromArgb(46, 204, 113); // Zelena na hover
                dropDownMenu.Show(lblGlavna, new Point(0, lblGlavna.Height));
            };

            // Event: Kada kursor IZAĐE (vraćamo boju ako meni nije otvoren)
            lblGlavna.MouseLeave += (s, e) => {
                if (!dropDownMenu.Visible) lblGlavna.ForeColor = Color.Black;
            };

            pnlCategoryScroll.Controls.Add(lblGlavna);
        }

        private void DodajSeparator()
        {
            Label s = new Label { Text = "|", ForeColor = Color.LightGray, AutoSize = true, Margin = new Padding(10, 12, 10, 0) };
            pnlCategoryScroll.Controls.Add(s);
        }

        private void DodajProizvodUKolekciju(string ime, string cena, Image slika)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.Height = 400;
            card.Margin = new Padding(15, 10, 15, 10);
            card.BackColor = Color.White;

            PictureBox pb = new PictureBox();
            pb.Image = slika;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Dock = DockStyle.Top;
            pb.Height = 250;
            pb.Cursor = Cursors.Hand;

            Label lblIme = new Label();
            lblIme.Text = ime.ToUpper();
            lblIme.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblIme.ForeColor = Color.FromArgb(30, 30, 30);
            lblIme.Dock = DockStyle.Top;
            lblIme.Height = 40;
            lblIme.TextAlign = ContentAlignment.BottomCenter;

            Label lblCena = new Label();
            lblCena.Text = cena + " RSD";
            lblCena.Font = new Font("Segoe UI Semilight", 10);
            lblCena.ForeColor = Color.Gray;
            lblCena.Dock = DockStyle.Top;
            lblCena.Height = 30;
            lblCena.TextAlign = ContentAlignment.TopCenter;

            Button btnKupi = new Button();
            btnKupi.Text = "ADD TO CART";
            btnKupi.Dock = DockStyle.Bottom;
            btnKupi.Height = 45;
            btnKupi.FlatStyle = FlatStyle.Flat;
            btnKupi.FlatAppearance.BorderSize = 0;
            btnKupi.BackColor = Color.FromArgb(46, 204, 113);
            btnKupi.ForeColor = Color.White;
            btnKupi.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnKupi.Cursor = Cursors.Hand;

            card.Controls.Add(lblCena);
            card.Controls.Add(lblIme);
            card.Controls.Add(pb);
            card.Controls.Add(btnKupi);


            btnKupi.Tag = new Models.Product { Id = flpProizvodi.Controls.Count + 1, Name = ime, Price = 54000m };
            btnKupi.Click += (s, e) => {
                if (cartForm == null || cartForm.IsDisposed) cartForm = new CartForm();

                cartForm.DodajProizvod((Models.Product)((Button)s).Tag);

                btnPregledKorpe.Text = $"KORPA";
            };

            flpProizvodi.Controls.Add(card);
        }

        private void FormGlavna_Load(object sender, EventArgs e)
        {
            // Pri učitavanju prikaži sve proizvode ili zadatu početnu kategoriju
            PrikaziProizvodeZaKategoriju(null);
        }

        // Učitaj proizvode iz baze 
        private void PrikaziProizvodeZaKategoriju(string kategorija)
        {
            flpProizvodi.Controls.Clear();
            try
            {
                using (var conn = Konekcija.DobijKonekciju())
                {

                        // S obzirom na strukturu baze (varijante u posebnoj tabeli), uzimamo minimum cene po proizvodu
                        string sqlJoin = @"SELECT p.ProizvodID, p.Naziv, MIN(v.Cena) AS Cena, p.SlikaPutanja, k.Naziv AS Kategorija
                                            FROM Proizvodi p
                                            LEFT JOIN VarijanteProizvoda v ON p.ProizvodID = v.ProizvodID
                                            LEFT JOIN Kategorije k ON p.KategorijaID = k.KategorijaID";
                        if (!string.IsNullOrWhiteSpace(kategorija)) sqlJoin += " WHERE k.Naziv = @kat";
                        sqlJoin += " GROUP BY p.ProizvodID, p.Naziv, p.SlikaPutanja, k.Naziv";

                        using (var cmd2 = new System.Data.SqlClient.SqlCommand(sqlJoin, conn))
                        {
                            if (!string.IsNullOrWhiteSpace(kategorija)) cmd2.Parameters.AddWithValue("@kat", kategorija);

                            using (var r = cmd2.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    string naziv = r["Naziv"] == DBNull.Value ? "" : r["Naziv"].ToString();
                                    string cena = "0";
                                    if (r["Cena"] != DBNull.Value)
                                    {
                                        try { cena = Convert.ToDecimal(r["Cena"]).ToString("0.00"); } catch { cena = r["Cena"].ToString(); }
                                    }

                                    Image img = null;
                                    if (r["SlikaPutanja"] != DBNull.Value)
                                    {
                                        try
                                        {
                                            string path = r["SlikaPutanja"].ToString();
                                            if (!string.IsNullOrWhiteSpace(path))
                                            {
                                                if (File.Exists(path)) img = Image.FromFile(path);
                                                else
                                                {
                                                    string combined = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                                                    if (File.Exists(combined)) img = Image.FromFile(combined);
                                                }
                                            }
                                        }
                                        catch { img = null; }
                                    }

                                    DodajProizvodUKolekciju(naziv, cena, img);
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju proizvoda: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            FormProfil profil = new FormProfil();
            profil.ShowDialog(); // Ovo je bitnio 
        }

        private void BtnPregledKorpe_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed) cartForm = new CartForm();
            cartForm.ShowDialog();
        }
    }
}