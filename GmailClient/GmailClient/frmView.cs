using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailClient
{
    public partial class frmView : Form
    {

        private Mensaje m;

        public frmView(Mensaje m)
        {
            InitializeComponent();
            this.m = m;
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
    }
}
