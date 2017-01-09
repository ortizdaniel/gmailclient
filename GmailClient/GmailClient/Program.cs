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
        /// 

        private static GmailService service;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Se mira si no hay ningun archivo de login
            if (!Login.isLogged())
            {
                //Mostrar boton de logear
                Application.Run(new frmLogin());
            }
            if (Login.isLogged())
            {
                Application.Run(new frmPrincipal(service, "me"));
            }
        }

        public static void SetService(GmailService gs)
        {
            service = gs;
        }
    }
}
