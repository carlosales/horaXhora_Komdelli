using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace hora_Komdelli
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            using (var context = new Conexao())
            {

                // Migrate the database
                //context.Database.EnsureCreated();
            }

            //using (var db = new Conexao())
            //{
            //    db.corte_Executados.Add(new Corte_executado { primeiro = "1020", segundo = "123", terceiro = "1234", quarto = "12345", quinto = "12", sexto = "1232", setimo = "321", oitavo = "423", nono = "213", decimo = "543" });
            //    db.SaveChanges();
            //}


        }
    }
}
