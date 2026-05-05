using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Prodavnica_Odece
{
    internal static class Program
    {
        /// <summary>
        /// Odje da odma krene te pita za lozinku i username, a ne da se prvo otvori forma pa onda da se klikne na dugme za logovanje
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Log_in());
        }
    }
}
