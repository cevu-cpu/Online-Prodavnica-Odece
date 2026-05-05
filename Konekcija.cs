using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Prodavnica_Odece
{
    //ovo kako bog da nauci da se konektuje na bazu, ne znam zasto je toliko komplikovano, ali eto, tako je
    class Konekcija
    {
        public static string adresa = LoadConnectionString();

        public static SqlConnection DobijKonekciju()
        {
            var conn = new SqlConnection(adresa);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
            
                throw new InvalidOperationException("Neuspešna konekcija: proverite connection string u App.config i da li je SQL Server dostupan.", ex);
            }
        }

        private static string LoadConnectionString()
        {
           
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string exeConfig = AppDomain.CurrentDomain.FriendlyName + ".config";
            string exeConfigPath = Path.Combine(baseDir, exeConfig);

            string projectConfigPath = Path.Combine(baseDir, "App.config");

            string configPath = File.Exists(exeConfigPath) ? exeConfigPath : (File.Exists(projectConfigPath) ? projectConfigPath : null);

            if (configPath == null)
                throw new InvalidOperationException("Ne mogu da nadjem App.config ili exe config. Dodajte connectionStrings u App.config sa imenom 'MojaKonekcija'.");

            var doc = new XmlDocument();
            doc.Load(configPath);
            var node = doc.SelectSingleNode("//connectionStrings/add[@name='MojaKonekcija']");
            if (node == null)
                throw new InvalidOperationException("Nije pronađen connection string 'MojaKonekcija' u konfiguracionom fajlu.");

            var attr = node.Attributes["connectionString"];
            if (attr == null || string.IsNullOrWhiteSpace(attr.Value))
                throw new InvalidOperationException("Connection string 'MojaKonekcija' je prazan.");

            return attr.Value;
        }
    }
}   
