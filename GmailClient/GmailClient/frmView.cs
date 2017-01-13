using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GmailClient
{
    public partial class frmView : Form
    {

        private Mensaje m;
        private frmPrincipal principal;

        public frmView(frmPrincipal principal, Mensaje m)
        {
            InitializeComponent();
            this.m = m;
            this.principal = principal;
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            txtAsunto.Text = m.Subject;
            txtRemitente.Text = m.From;
            txtContenido.Text = m.Body;
        }

        private void btnMarcarComoLeido_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            principal.tsmiEliminar_Click(sender, e);
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            principal.tsmiReenviar_Click(sender, e);
        }
    }
}
