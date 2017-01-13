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
            //Recibir como parametros la instancia de la form principal y el mensaje en cuestion
            InitializeComponent();
            /* No donem opcio a respondre un correu nostre */
            if (m.From.Equals(principal.getProfile().EmailAddress))
            {
                btnResponder.Enabled = false;
            }
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
            //Llamar a la funcion ya codificada en la form principal
            principal.tsmiMarcarLeido_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Llamar a la funcion ya codificada en la form principal y cerrar esta
            //ventana para prevenir posibles errores
            principal.tsmiEliminar_Click(sender, e);
            Close();
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            //Ya que frmRedactar toma una List<String> como parametro en su constructor, esta
            //es la manera "mas sencilla" de "arreglarlo"
            List<string> guarro = new List<string>();
            guarro.Add(m.To);
            (new frmRedactar(principal.getService(), "me", guarro, m.Subject, m.Body)).ShowDialog();
        }

        private void btnMarcarComoNoLeido_Click(object sender, EventArgs e)
        {
            //Llamar a la funcion ya codificada en la form principal
            principal.tsmiMarcarNoLeido_Click(sender, e);
        }

        private void btnMarcarComoSpam_Click(object sender, EventArgs e)
        {
            //Llamar a la funcion ya codificada en la form principal
            principal.tsmiMarcarSpam_Click(sender, e);
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            //Ya que frmRedactar toma una List<String> como parametro en su constructor, esta
            //es la manera "mas sencilla" de "arreglarlo"
            List<string> guarro = new List<string>();
            guarro.Add(m.To);
            (new frmRedactar(principal.getService(), "me", guarro, m.Subject, m.Body)).ShowDialog();
        }
    }
}
