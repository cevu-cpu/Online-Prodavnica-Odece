using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Prodavnica_Odece
{
    public partial class Log_in : Form
    {
        public Log_in()
        {
            InitializeComponent();
            this.Text = "Login - Online Prodavnica";

            this.LoginBtn.Click += DugmePrijava_Click;
            this.SigninBtn.Click += DugmeRegistracija_Click;

            // Kratak test da proverimo da li može da se uspostavi konekcija sa bazom
            try
            {
                using (var conn = Konekcija.DobijKonekciju())
                {
                    // Ako je konekcija otvorena bez izuzetka, smatramo da baza radi
                    MessageBox.Show("Veza sa bazom je uspešno uspostavljena.", "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspešna konekcija sa bazom: " + ex.Message, "DB Test - Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Glavno Dugme za Login
        private void DugmePrijava_Click(object sender, EventArgs e)
        {
            // 1. Provera praznih polja
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Molimo unesite korisničko ime i lozinku.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Konekcija i provera u bazi
            using (SqlConnection conn = Konekcija.DobijKonekciju())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Prvo dovatimo zapis korisnika po korisnickom imenu, uključujući UlogaID
                    string query = @"SELECT k.KorisnikID, k.Ime, k.Lozinka, u.NazivUloge, u.UlogaID 
                                     FROM Korisnici k 
                                     JOIN Uloge u ON k.UlogaID = u.UlogaID 
                                     WHERE k.KorisnickoIme = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUser.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ime = reader["Ime"].ToString();
                            string storedPassword = reader["Lozinka"].ToString();
                            string uloga = reader["NazivUloge"].ToString();
                            int korisnikID = Convert.ToInt32(reader["KorisnikID"]);
                            int ulogaID = reader["UlogaID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UlogaID"]);

                            bool ok = PasswordHelper.VerifyPassword(storedPassword, txtPass.Text.Trim());

                            if (ok)
                            {
                                MessageBox.Show($"Dobrodošli nazad, {ime}!", "Uspešan Login");

                                // Postavimo sesiju za prijavljenog korisnika
                                Sesija.TrenutniKorisnikId = korisnikID;
                                Sesija.KorisnickoIme = txtUser.Text.Trim();
                                Sesija.Ime = ime;
                                Sesija.Uloga = uloga;

                                // Ako je lozinka bila u sugavom tekstu, nadogradimo je u bazi na heš
                                if (!storedPassword.Contains("."))
                                {
                                    string newHash = PasswordHelper.HashPassword(txtPass.Text.Trim());
                                    reader.Close();
                                    using (var upd = new SqlCommand("UPDATE Korisnici SET Lozinka = @hash WHERE KorisnikID = @id", conn))
                                    {
                                        upd.Parameters.AddWithValue("@hash", newHash);
                                        upd.Parameters.AddWithValue("@id", korisnikID);
                                        upd.ExecuteNonQuery();
                                    }
                                }

                                // Sakrijemo login formu
                                this.Hide();

                                // Ako je naziv uloge "Admin" ili "Administrator" smatramo da je to Administrator
                                if (string.Equals(uloga, "Admin", StringComparison.OrdinalIgnoreCase)
                                    || string.Equals(uloga, "Administrator", StringComparison.OrdinalIgnoreCase))
                                {
                                    var admin = new AdminForm();
                                    admin.FormClosed += (s2, e2) => Application.Exit();
                                    admin.Show();
                                }
                                else
                                {
                                    var shop = new FormGlavna();
                                    shop.FormClosed += (s2, e2) => Application.Exit();
                                    shop.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška sa bazom: " + ex.Message, "Kritična Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
     
        }

        // Dugme za odlazak na Register formu
        private void DugmeRegistracija_Click(object sender, EventArgs e)
        {
            Register regForm = new Register();
            regForm.Show();
            this.Hide();
        }

        // Usrano sam slucajno ovo kliknuo
        private void LoginBtn_Click_1(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}