using System;
using System.Collections.Generic;
using System.Drawing;
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

            // Horizontalni scroll podešavanja
            flpProizvodi.WrapContents = false;
            flpProizvodi.AutoScroll = true;

            // Wire buttons
            this.btnProfil.Click += btnProfil_Click;
            this.btnPregledKorpe.Click += BtnPregledKorpe_Click;
        }

        private void InicijalizujKategorije()
        {
            pnlCategoryScroll.Controls.Clear();

            // 1. GRUPA: SUITS & TUXEDOS
            string[] suits = { "Suits", "Tuxedos", "Jackets & Blazers", "Pants", "Dress Pants", "Vests" };
            DodajGlavnuKategorijuSaMenijem("SUITS & TUXEDOS", suits);

            DodajSeparator();

            // 2. GRUPA: ACCESSORIES
            string[] acc = { "Dress Shirts", "Ties & Bow Ties", "Belts & Suspenders", "Shoes", "Socks", "Cufflinks", "Pocket Squares", "Cummerbunds" };
            DodajGlavnuKategorijuSaMenijem("ACCESSORIES", acc);
        }

        private void DodajGlavnuKategorijuSaMenijem(string naslov, string[] podkategorije)
        {
            // Glavni label koji reaguje na kursor
            Label lblGlavna = new Label();
            lblGlavna.Text = naslov + " ▼";
            lblGlavna.AutoSize = true;
            lblGlavna.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblGlavna.Cursor = Cursors.Hand;
            lblGlavna.Margin = new Padding(20, 12, 5, 0);
            lblGlavna.ForeColor = Color.Black;

            // Kreiranje Dropdown menija
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
                    // Ovde ide tvoja logika za filtriranje baze podataka
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

            // Attach product info to button
            btnKupi.Tag = new Models.Product { Id = flpProizvodi.Controls.Count + 1, Name = ime, Price = 54000m };
            btnKupi.Click += (s, e) => {
                if (cartForm == null || cartForm.IsDisposed) cartForm = new CartForm();
                // Dodaj proizvod u korpu koristeći srpski naziv metode
                cartForm.DodajProizvod((Models.Product)((Button)s).Tag);
                // Ažuriraj tekst na dugmetu za korpu ako želiš broj stavki
                btnPregledKorpe.Text = $"KORPA";
            };

            flpProizvodi.Controls.Add(card);
        }

        private void FormGlavna_Load(object sender, EventArgs e)
        {
            // Simulacija proizvoda pri učitavanju
            for (int i = 0; i < 10; i++)
            {
                DodajProizvodUKolekciju("Black Slim Fit Suit", "54.000", null);
            }
       
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            FormProfil profil = new FormProfil();
            profil.ShowDialog(); // Ovo je ključno!
        }

        private void BtnPregledKorpe_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed) cartForm = new CartForm();
            cartForm.ShowDialog();
        }
    }
}