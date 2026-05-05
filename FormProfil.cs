using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Online_Prodavnica_Odece
{
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
            SrediDizajn();
        }

        private void SrediDizajn()
        {
            // Dodajemo crni okvir oko cele forme
            this.Paint += (s, e) => {
                e.Graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, this.Width - 1, this.Height - 1);
            };
            // Use designer controls: wire up buttons and set title
            if (lblNaslov != null) lblNaslov.Text = "MY PROFILE";
            if (btnClose != null)
            {
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => this.Close();
            }

            if (btnSave != null)
            {
                btnSave.Click += (s, e) => SaveProfile(txtEmail.Text.Trim(), txtAdresa.Text.Trim(), txtNewPass.Text.Trim());
            }

            if (btnLogout != null)
            {
                // Logout: brišemo sesiju i restartujemo aplikaciju
                btnLogout.Click += (s, e) => { Sesija.Ocisti(); Application.Restart(); };
            }
        }

        private void SaveProfile(string email, string address, string newPassword)
        {
            // Validacije
            if (!string.IsNullOrEmpty(email))
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!regex.IsMatch(email))
                {
                    MessageBox.Show("Unesite ispravan email.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(newPassword) && newPassword.Length < 6)
            {
                MessageBox.Show("Nova lozinka mora imati najmanje 6 karaktera.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Konekcija.DobijKonekciju())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Gradimo dinamički UPDATE
                    var sb = new System.Text.StringBuilder();
                    sb.Append("UPDATE Korisnici SET ");
                    sb.Append("Email = @email, Adresa = @adresa");
                    if (!string.IsNullOrEmpty(newPassword)) sb.Append(", Lozinka = @lozinka");
                    sb.Append(" WHERE KorisnikID = @id");

                    using (var cmd = new SqlCommand(sb.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@adresa", (object)address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", Sesija.TrenutniKorisnikId);

                        if (!string.IsNullOrEmpty(newPassword))
                        {
                            string hash = PasswordHelper.HashPassword(newPassword);
                            cmd.Parameters.AddWithValue("@lozinka", hash);
                        }

                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            MessageBox.Show("Profil uspešno ažuriran.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nije pronađen korisnik ili nije bilo promena.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri čuvanju profila: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {

        }
    }
}