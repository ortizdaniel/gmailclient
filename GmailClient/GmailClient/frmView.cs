﻿using Google.Apis.Gmail.v1;
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
            /* No donem opcio a respondre un correu nostre */
            if (m.From.Equals(principal.getProfile().EmailAddress))
            {
                btnResponder.Visible = false;
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
            principal.tsmiMarcarLeido_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            principal.tsmiEliminar_Click(sender, e);
            Close();
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            List<string> guarro = new List<string>();
            guarro.Add(m.To);
            (new frmRedactar(principal.getService(), "me", guarro, m.Subject, m.Body)).ShowDialog();
        }

        private void btnMarcarComoNoLeido_Click(object sender, EventArgs e)
        {
            principal.tsmiMarcarNoLeido_Click(sender, e);
        }

        private void btnMarcarComoSpam_Click(object sender, EventArgs e)
        {
            principal.tsmiMarcarSpam_Click(sender, e);
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            List<string> guarro = new List<string>();
            guarro.Add(m.To);
            (new frmRedactar(principal.getService(), "me", guarro, m.Subject, m.Body)).ShowDialog();
        }
    }
}
