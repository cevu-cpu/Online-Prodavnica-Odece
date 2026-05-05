namespace Online_Prodavnica_Odece
{
    static class Sesija
    {
        public static int TrenutniKorisnikId { get; set; }
        public static string KorisnickoIme { get; set; }
        public static string Ime { get; set; }
        public static string Uloga { get; set; }
        public static bool JePrijavljen => TrenutniKorisnikId > 0;
        public static void Ocisti()
        {
            TrenutniKorisnikId = 0;
            KorisnickoIme = null;
            Ime = null;
            Uloga = null;
        }
    }
}
