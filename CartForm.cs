using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Online_Prodavnica_Odece.Models;

namespace Online_Prodavnica_Odece
{
    public partial class CartForm : Form
    {
        // Stavke u korpi: svaki element je tuple (proizvod, kolicina)
        private List<(Product proizvod, int kolicina)> stavke = new List<(Product, int)>();

        public CartForm()
        {
            InitializeComponent();
            this.Text = "Korpa";

            if (lvKorpa != null)
            {
                lvKorpa.FullRowSelect = true;
                // eventovi
                lvKorpa.MouseDoubleClick += LvKorpa_DoubleClick;
                lvKorpa.SelectedIndexChanged += LvKorpa_SelectedIndexChanged;
            }

            if (btnNaplata != null)
            {
                btnNaplata.Click += (s, e) => MessageBox.Show("Checkout nije implementiran u demo verziji.");
            }

            // dugmad 
            if (btnUkloni != null) btnUkloni.Click += (s, e) => UkloniSelektovano();
            if (btnPovecaj != null) btnPovecaj.Click += (s, e) => PromeniKolicinu(1);
            if (btnSmanji != null) btnSmanji.Click += (s, e) => PromeniKolicinu(-1);
        }

        // 2 put klikni i izbacujemo stvari hell yea vuce samo se ti muci
        private void LvKorpa_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (lvKorpa.SelectedItems.Count == 0) return;
            var it = lvKorpa.SelectedItems[0];
            int idx = it.Index;
            // Uklanjamo stavku
            stavke.RemoveAt(idx);
            OsveziListu();
        }

        // ovo nz zas ssam ubacio
        private void LvKorpa_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ima = lvKorpa.SelectedItems.Count > 0;
            if (btnUkloni != null) btnUkloni.Enabled = ima;
            if (btnPovecaj != null) btnPovecaj.Enabled = ima;
            if (btnSmanji != null) btnSmanji.Enabled = ima;
        }

        // uklanjanje selektovane stavke iz korpe
        private void UkloniSelektovano()
        {
            if (lvKorpa.SelectedItems.Count == 0) return;
            int idx = lvKorpa.SelectedItems[0].Index;
            stavke.RemoveAt(idx);
            OsveziListu();
        }

        // promena količine selektovane stavke (+1 / -1)
        private void PromeniKolicinu(int delta)
        {
            if (lvKorpa.SelectedItems.Count == 0) return;
            int idx = lvKorpa.SelectedItems[0].Index;
            var cur = stavke[idx];
            int nova = Math.Max(1, cur.kolicina + delta);
            stavke[idx] = (cur.proizvod, nova);
            OsveziListu();
            // Ponovo selektujemo istu stavku
            if (lvKorpa.Items.Count > idx) lvKorpa.Items[idx].Selected = true;
        }

        // dodavanje proizvoda u korpu; ako postoji povećavamo količinu
        public void DodajProizvod(Product p)
        {
            var idx = stavke.FindIndex(x => x.proizvod.Id == p.Id);
            if (idx >= 0)
            {
                var cur = stavke[idx];
                stavke[idx] = (cur.proizvod, cur.kolicina + 1);
            }
            else
            {
                stavke.Add((p, 1));
            }
            OsveziListu();
        }

        // osvežavanje prikaza korpe i ukupne cene
        private void OsveziListu()
        {
            lvKorpa.Items.Clear();
            decimal ukupno = 0;
            foreach (var stavka in stavke)
            {
                var li = new ListViewItem(new[] { stavka.proizvod.Name, stavka.kolicina.ToString(), (stavka.proizvod.Price * stavka.kolicina).ToString("0.00") });
                lvKorpa.Items.Add(li);
                ukupno += stavka.proizvod.Price * stavka.kolicina;
            }
            lblUkupno.Text = $"Ukupno: {ukupno:0.00} RSD";
        }

       
    }
}
