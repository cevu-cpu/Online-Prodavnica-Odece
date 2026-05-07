using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Online_Prodavnica_Odece
{
    public partial class AdminForm : Form
    {
        enum AdminMod { Proizvodi, Korisnici, Narudzbine }
        private AdminMod trenutniMod = AdminMod.Proizvodi;
        private ContextMenuStrip cms;

        public AdminForm()
        {
            InitializeComponent();
            InicijalizujAdmin();
        }

        private void InicijalizujAdmin()
        {
            // Kontekst meni za dgv
            cms = new ContextMenuStrip();
            cms.Items.Add("Dodaj", null, (s, e) => Dodaj_Click());
            cms.Items.Add("Izmeni", null, (s, e) => Izmeni_Click());
            cms.Items.Add("Obriši", null, (s, e) => Obrisi_Click());
            dgvProizvodi.ContextMenuStrip = cms;

            // Wire dugmad
            btnDodajProizvod.Click += (s, e) => OtvoriProizvodi();
            btnKorisnici.Click += (s, e) => OtvoriKorisnike();
            btnNarudzbine.Click += (s, e) => OtvoriNarudzbine();

            // Početno pokaži proizvode
            OtvoriProizvodi();
        }

        private int? UzmiSelektovaniId()
        {
            if (dgvProizvodi.SelectedRows.Count == 0) return null;
            var val = dgvProizvodi.SelectedRows[0].Cells[0].Value;
            if (val == null) return null;
            return Convert.ToInt32(val);
        }

        // Pomoćne metode za čitanje kolona iz SqlDataReader-a kada je moguće da imena kolona nisu standardna
        private string CitajString(IDataRecord r, params string[] kandidati)
        {
            foreach (var k in kandidati)
            {
                try
                {
                    var v = r[k];
                    if (v != null && v != DBNull.Value) return v.ToString();
                }
                catch (IndexOutOfRangeException) { }
            }
            return string.Empty;
        }

        private decimal CitajDecimal(IDataRecord r, params string[] kandidati)
        {
            foreach (var k in kandidati)
            {
                try
                {
                    var v = r[k];
                    if (v != null && v != DBNull.Value)
                    {
                        if (v is decimal) return (decimal)v;
                        if (decimal.TryParse(v.ToString(), out decimal d)) return d;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            return 0m;
        }

        private int CitajInt(IDataRecord r, params string[] kandidati)
        {
            foreach (var k in kandidati)
            {
                try
                {
                    var v = r[k];
                    if (v != null && v != DBNull.Value)
                    {
                        if (v is int) return (int)v;
                        if (int.TryParse(v.ToString(), out int i)) return i;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            return 0;
        }

        private void Dodaj_Click()
        {
            if (trenutniMod == AdminMod.Proizvodi)
            {
                var f = new ProductEditForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var conn = Konekcija.DobijKonekciju())
                        {
                            // Upis proizvoda u tabelu Proizvodi (bez cene/kolicine, to ide u VarijanteProizvoda)
                            // Prvo obezbedimo kategoriju
                            int katId = 0;
                            if (!string.IsNullOrWhiteSpace(f.Kategorija))
                            {
                                using (var chk = new System.Data.SqlClient.SqlCommand("SELECT KategorijaID FROM Kategorije WHERE Naziv = @naziv", conn))
                                {
                                    chk.Parameters.AddWithValue("@naziv", f.Kategorija);
                                    var res = chk.ExecuteScalar();
                                    if (res != null) katId = Convert.ToInt32(res);
                                    else
                                    {
                                        using (var insk = new System.Data.SqlClient.SqlCommand("INSERT INTO Kategorije (Naziv) VALUES (@naziv); SELECT SCOPE_IDENTITY();", conn))
                                        {
                                            insk.Parameters.AddWithValue("@naziv", f.Kategorija);
                                            katId = Convert.ToInt32(insk.ExecuteScalar());
                                        }
                                    }
                                }
                            }

                            string slikaPutanja = null;
                            if (f.SlikaBytes != null && f.SlikaBytes.Length > 0)
                            {
                                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images"));
                                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", $"prod_{DateTime.Now.Ticks}.png");
                                File.WriteAllBytes(fileName, f.SlikaBytes);
                                slikaPutanja = fileName;
                            }

                            using (var cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO Proizvodi (Naziv, SlikaPutanja, KategorijaID) VALUES (@n, @s, @k); SELECT SCOPE_IDENTITY();", conn))
                            {
                                cmd.Parameters.AddWithValue("@n", f.Naziv);
                                cmd.Parameters.AddWithValue("@s", (object)slikaPutanja ?? DBNull.Value);
                                // Ako nije izabrana ili unesena kategorija, postavi NULL u bazi umesto 0
                                cmd.Parameters.AddWithValue("@k", katId > 0 ? (object)katId : DBNull.Value);
                                var newId = Convert.ToInt32(cmd.ExecuteScalar());

                                // Ubacimo osnovnu varijantu sa cenom i zalihom
                                using (var vcmd = new System.Data.SqlClient.SqlCommand("INSERT INTO VarijanteProizvoda (ProizvodID, Velicina, Boja, Cena, Zaliha) VALUES (@pid, '', '', @c, @z)", conn))
                                {
                                    vcmd.Parameters.AddWithValue("@pid", newId);
                                    vcmd.Parameters.AddWithValue("@c", f.Cena);
                                    vcmd.Parameters.AddWithValue("@z", f.Kolicina);
                                    vcmd.ExecuteNonQuery();
                                }
                            }
                        }
                        OtvoriProizvodi();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška pri dodavanju proizvoda: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dodavanje nije podržano za ovaj prikaz.");
            }
        }

        private void Izmeni_Click()
        {
            var id = UzmiSelektovaniId();
            if (id == null) return;
            if (trenutniMod == AdminMod.Proizvodi)
            {
                try
                {
                    using (var conn = Konekcija.DobijKonekciju())
                    {
                        // Uzimamo osnovne podatke proizvoda i agregirane vrednosti iz varijanti
                        string sql = @"SELECT p.Naziv, p.SlikaPutanja, k.Naziv AS Kategorija, MIN(v.Cena) AS Cena, SUM(v.Zaliha) AS Kolicina
                                       FROM Proizvodi p
                                       LEFT JOIN VarijanteProizvoda v ON p.ProizvodID = v.ProizvodID
                                       LEFT JOIN Kategorije k ON p.KategorijaID = k.KategorijaID
                                       WHERE p.ProizvodID = @id
                                       GROUP BY p.Naziv, p.SlikaPutanja, k.Naziv";

                        using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            string naziv = null;
                            decimal cena = 0;
                            int kolicina = 0;
                            string slikaPutanja = null;
                            string kategorija = null;
                            using (var r = cmd.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    naziv = CitajString(r, "Naziv", "Ime", "Title");
                                    cena = CitajDecimal(r, "Cena", "Price", "CENA");
                                    kolicina = CitajInt(r, "Kolicina", "Qty", "Quantity", "Zaliha");
                                    slikaPutanja = CitajString(r, "SlikaPutanja", "Slika");
                                    kategorija = CitajString(r, "Kategorija", "Kategorija");
                                }
                            }

                            // Reader je zatvoren ovde — možemo otvoriti modal
                            if (naziv != null)
                            {
                                var f = new ProductEditForm();
                                f.Naziv = naziv;
                                f.Cena = cena;
                                f.Kolicina = kolicina;
                                f.Kategorija = kategorija;
                                if (!string.IsNullOrWhiteSpace(slikaPutanja) && File.Exists(slikaPutanja))
                                {
                                    try { f.SlikaBytes = File.ReadAllBytes(slikaPutanja); } catch { }
                                }
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    // Ažuriraj osnovne podatke proizvoda
                                    using (var upd = new System.Data.SqlClient.SqlCommand("UPDATE Proizvodi SET Naziv=@n, SlikaPutanja=@s WHERE ProizvodID=@id", conn))
                                    {
                                        string slikaPut = null;
                                        if (f.SlikaBytes != null && f.SlikaBytes.Length > 0)
                                        {
                                            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images"));
                                            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", $"prod_{DateTime.Now.Ticks}.png");
                                            File.WriteAllBytes(fileName, f.SlikaBytes);
                                            slikaPut = fileName;
                                        }
                                        upd.Parameters.AddWithValue("@n", f.Naziv);
                                        upd.Parameters.AddWithValue("@s", (object)slikaPut ?? DBNull.Value);
                                        upd.Parameters.AddWithValue("@id", id);
                                        upd.ExecuteNonQuery();
                                    }

                                    // Ažuriraj/ubaci varijantu sa cenom i zalihom
                                    using (var vcmd = new System.Data.SqlClient.SqlCommand("UPDATE VarijanteProizvoda SET Cena=@c, Zaliha=@z WHERE ProizvodID=@pid", conn))
                                    {
                                        vcmd.Parameters.AddWithValue("@c", f.Cena);
                                        vcmd.Parameters.AddWithValue("@z", f.Kolicina);
                                        vcmd.Parameters.AddWithValue("@pid", id);
                                        int affected = vcmd.ExecuteNonQuery();
                                        if (affected == 0)
                                        {
                                            using (var icmd = new System.Data.SqlClient.SqlCommand("INSERT INTO VarijanteProizvoda (ProizvodID, Velicina, Boja, Cena, Zaliha) VALUES (@pid, '', '', @c, @z)", conn))
                                            {
                                                icmd.Parameters.AddWithValue("@pid", id);
                                                icmd.Parameters.AddWithValue("@c", f.Cena);
                                                icmd.Parameters.AddWithValue("@z", f.Kolicina);
                                                icmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    OtvoriProizvodi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri izmeni proizvoda: " + ex.Message);
                }
            }
        }

        private void Obrisi_Click()
        {
            var id = UzmiSelektovaniId();
            if (id == null) return;
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani zapis?", "Potvrda", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                try
                {
                    using (var conn = Konekcija.DobijKonekciju())
                    {
                        string sql = "";
                    if (trenutniMod == AdminMod.Proizvodi) sql = "DELETE FROM Proizvodi WHERE ProizvodID = @id";
                    else if (trenutniMod == AdminMod.Korisnici) sql = "DELETE FROM Korisnici WHERE KorisnikID = @id";
                    else if (trenutniMod == AdminMod.Narudzbine) sql = "DELETE FROM Narudzbine WHERE NarudzbinaID = @id";
                    if (string.IsNullOrEmpty(sql)) return;
                    using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                // osvezi prikaz
                if (trenutniMod == AdminMod.Proizvodi) OtvoriProizvodi();
                else if (trenutniMod == AdminMod.Korisnici) OtvoriKorisnike();
                else OtvoriNarudzbine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message);
            }
        }

        private void OtvoriProizvodi()
        {
            trenutniMod = AdminMod.Proizvodi;
            lblTabelaNaslov.Text = "PREGLED PROIZVODA";
            dgvProizvodi.Columns.Clear();
            dgvProizvodi.Rows.Clear();
            dgvProizvodi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProizvodi.AllowUserToAddRows = false;
            dgvProizvodi.ReadOnly = true;
            dgvProizvodi.Columns.Add("ProizvodID", "ID");
            dgvProizvodi.Columns.Add("Naziv", "Naziv");
            dgvProizvodi.Columns.Add("Cena", "Cena");
            dgvProizvodi.Columns.Add("Kolicina", "Količina");
            try
            {
                using (var conn = Konekcija.DobijKonekciju())
                {
                    // Uzimamo minimalnu cenu iz varijanti i sumu zaliha po proizvodu
                    string sql = @"SELECT p.ProizvodID, p.Naziv, MIN(v.Cena) AS Cena, SUM(v.Zaliha) AS Kolicina
                                   FROM Proizvodi p
                                   LEFT JOIN VarijanteProizvoda v ON p.ProizvodID = v.ProizvodID
                                   GROUP BY p.ProizvodID, p.Naziv";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                    {
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                var id = CitajInt(r, "ProizvodID", "ID");
                                var naziv = CitajString(r, "Naziv", "Ime");
                                var cena = CitajDecimal(r, "Cena");
                                var kolicina = CitajInt(r, "Kolicina");
                                dgvProizvodi.Rows.Add(id, naziv, cena, kolicina);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju proizvoda: " + ex.Message);
            }
        }

        private void OtvoriKorisnike()
        {
            trenutniMod = AdminMod.Korisnici;
            lblTabelaNaslov.Text = "PREGLED KORISNIKA";
            dgvProizvodi.Columns.Clear();
            dgvProizvodi.Rows.Clear();
            dgvProizvodi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProizvodi.AllowUserToAddRows = false;
            dgvProizvodi.ReadOnly = true;
            dgvProizvodi.Columns.Add("KorisnikID", "ID");
            dgvProizvodi.Columns.Add("Ime", "Ime");
            dgvProizvodi.Columns.Add("KorisnickoIme", "Korisničko ime");
            dgvProizvodi.Columns.Add("Email", "Email");
            dgvProizvodi.Columns.Add("Uloga", "Uloga");
                try
                {
                    using (var conn = Konekcija.DobijKonekciju())
                    {
                        using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT k.KorisnikID, k.Ime, k.KorisnickoIme, k.Email, u.NazivUloge FROM Korisnici k LEFT JOIN Uloge u ON k.UlogaID = u.UlogaID", conn))
                    {
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                var id = CitajInt(r, "KorisnikID", "ID");
                                var ime = CitajString(r, "Ime", "Name");
                                var korisnicko = CitajString(r, "KorisnickoIme", "Username");
                                var email = CitajString(r, "Email", "Mail");
                                var uloga = CitajString(r, "NazivUloge", "Uloga");
                                dgvProizvodi.Rows.Add(id, ime, korisnicko, email, uloga);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju korisnika: " + ex.Message);
            }
        }

        private void OtvoriNarudzbine()
        {
            trenutniMod = AdminMod.Narudzbine;
            lblTabelaNaslov.Text = "PREGLED PORUDŽBINA";
            dgvProizvodi.Columns.Clear();
            dgvProizvodi.Rows.Clear();
            dgvProizvodi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProizvodi.AllowUserToAddRows = false;
            dgvProizvodi.ReadOnly = true;
            dgvProizvodi.Columns.Add("NarudzbinaID", "ID");
            dgvProizvodi.Columns.Add("Korisnik", "Korisnik");
            dgvProizvodi.Columns.Add("Ukupno", "Ukupno");
            dgvProizvodi.Columns.Add("Status", "Status");
                try
                {
                    using (var conn = Konekcija.DobijKonekciju())
                    {
                        using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT n.NarudzbinaID, k.Ime, n.Ukupno, n.Status FROM Narudzbine n LEFT JOIN Korisnici k ON n.KorisnikID = k.KorisnikID", conn))
                    {
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                var id = CitajInt(r, "NarudzbinaID", "ID");
                                var ime = CitajString(r, "Ime", "Korisnik");
                                var ukupno = CitajDecimal(r, "Ukupno", "Total", "Price");
                                var status = CitajString(r, "Status", "Stanje");
                                dgvProizvodi.Rows.Add(id, ime, ukupno, status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju porudžbina: " + ex.Message);
            }
        }
    }
}
