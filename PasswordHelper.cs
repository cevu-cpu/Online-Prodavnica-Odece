using System;
using System.Security.Cryptography;

namespace Online_Prodavnica_Odece
{
    static class PasswordHelper
    {
        // Hashovanjeeeeeeee :)
        public static string HashPassword(string password, int iterations = 10000)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    byte[] hash = pbkdf2.GetBytes(32);
                    return string.Format("{0}.{1}.{2}", iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
                }
            }
        }

        public static bool VerifyPassword(string stored, string provided)
        {
            if (string.IsNullOrEmpty(stored)) return false;
            if (provided == null) return false;

            // ako ne radi sa formatom iterations.salt.hash onda proveri direktno dont ask me, nisam siguran zasto bi neko imao password u bazi bez hashovanja, ali eto, da ne bi puklo ako se desi
            var parts = stored.Split('.');
            if (parts.Length != 3)
            {
                return string.Equals(stored, provided, StringComparison.Ordinal);
            }

            if (!int.TryParse(parts[0], out int iterations)) return false;
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] storedHash = Convert.FromBase64String(parts[2]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(provided, salt, iterations))
            {
                byte[] computed = pbkdf2.GetBytes(storedHash.Length);
                return AreEqual(storedHash, computed);
            }
        }

        private static bool AreEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
