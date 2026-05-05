using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Online_Prodavnica_Odece
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.btnBack.Click += BtnBack_Click;
            this.btnRegister.Click += btnRegister_Click;
        }

        private void panelGreyOverlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Polja potrebna: Ime, Prezime, KorisnickoIme, Lozinka, Email
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                MessageBox.Show("Polje 'Ime' ne sme biti prazno.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIme.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                MessageBox.Show("Polje 'Prezime' ne sme biti prazno.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrezime.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUser.Text) || txtUser.Text.Trim().Length < 3)
            {
                MessageBox.Show("Korisničko ime mora imati najmanje 3 znaka.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text.Trim().Length < 6)
            {
                MessageBox.Show("Lozinka mora imati najmanje 6 karaktera.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Unesite ispravan email.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (var conn = Konekcija.DobijKonekciju())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Proveravam da li korisnicko ime vec postoji
                    using (var check = new SqlCommand("SELECT COUNT(1) FROM Korisnici WHERE KorisnickoIme = @user", conn))
                    {
                        check.Parameters.AddWithValue("@user", txtUser.Text.Trim());
                        int exists = Convert.ToInt32(check.ExecuteScalar());
                        if (exists > 0)
                        {
                            MessageBox.Show("Korisničko ime već postoji. Molimo odaberite drugo.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUser.Focus();
                            return;
                        }
                    }

                    // Uzimam UlogaID za Kupca (ako ne postoji, ubacićemo ga)
                    int ulogaId = 0;
                    using (var cmd = new SqlCommand("SELECT UlogaID FROM Uloge WHERE NazivUloge = 'Kupac'", conn))
                    {
                        var res = cmd.ExecuteScalar();
                        if (res == null)
                        {
                            using (var ins = new SqlCommand("INSERT INTO Uloge (NazivUloge) VALUES ('Kupac'); SELECT SCOPE_IDENTITY();", conn))
                            {
                                ulogaId = Convert.ToInt32(ins.ExecuteScalar());
                            }
                        }
                        else
                        {
                            ulogaId = Convert.ToInt32(res);
                        }
                    }

                    string hashed = PasswordHelper.HashPassword(txtPass.Text.Trim());

                    using (var insert = new SqlCommand("INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, Email, Adresa, UlogaID) VALUES (@ime, @prezime, @user, @pass, @email, @adresa, @uloga)", conn))
                    {
                        insert.Parameters.AddWithValue("@ime", txtIme.Text.Trim());
                        insert.Parameters.AddWithValue("@prezime", txtPrezime.Text.Trim());
                        insert.Parameters.AddWithValue("@user", txtUser.Text.Trim());
                        insert.Parameters.AddWithValue("@pass", hashed);
                        insert.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        insert.Parameters.AddWithValue("@adresa", txtAdresa.Text.Trim());
                        insert.Parameters.AddWithValue("@uloga", ulogaId);
                        insert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Uspešno ste registrovani.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Vratimo se na formu za prijavu
                var prijava = new Log_in();
                prijava.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri registraciji: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                // REgex nz odakle mi ovo uzeo sam od chatgptja dont ask me nije normalan search teo da radi
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var login = new Log_in();
            login.Show();
            this.Close();
        }
    }
}
