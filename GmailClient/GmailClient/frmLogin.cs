using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GmailQuickstart;
using System.Threading;

namespace GmailClient
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Iniciar el login
            bgwWait.RunWorkerAsync();
        }
        
        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            //Para que la ventana del programa no se trabe mientras se espera el login, se hace
            //este proceso de login en una thread
            Program.SetService(Login.DoLogin());
        }

        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cuando el proceso de login haya acabado, cerrar la ventana
            Close();
        }
    }
}
