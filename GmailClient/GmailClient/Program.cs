using GmailQuickstart;
using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Se mira si no hay ningun archivo de login
            if (!Login.isLogged())
            {
                //Mostrar boton de logear
                Console.WriteLine("Por favor logeate");
            }
            //Siempre se hace el login para conseguir la insancia de GmailService necesaria para todo
            GmailService s = Login.DoLogin();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPrincipal(s, "me"));

            //Siempre se deslogea hasta que se implemente el boton
            Login.DoLogout();
        }
    }
}
