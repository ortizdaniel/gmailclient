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
            bgwWait.RunWorkerAsync();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.SetService(Login.DoLogin());
        }

        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnContinuar.Enabled = true;
        }
    }
}
