using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using GmailQuickstart;
using System.Diagnostics;

namespace GmailClient
{
    public partial class frmPrincipal : Form
    {
        GmailService service;
        string userId;
        List<Mensaje> mensajes;

        public frmPrincipal(GmailService service, string userId)
        {
            InitializeComponent();
            imLSGmail.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            String userMail = Usuario.GetProfile(service, userId).EmailAddress;
            StringBuilder aux = new StringBuilder("                ");
            for (int i = 0; i < userMail.Length; i++)
            {
               if(userMail[i] == '@')
                {
                    break; 
                }
                aux[i] = userMail[i];
            }
            label1.Text = aux.ToString();
            this.service = service;
            this.userId = userId;
            /* Diseño de los objetos */
            this.BackColor = Color.LightGray;
            lvMensajes.Columns[0].Width = 100;
            lvMensajes.Columns[1].Width = 150;
            lvMensajes.Columns[2].Width = 300;
            lvMensajes.Columns[3].Width = 0;
            lvMensajes.Columns[4].Width = 0;
            lvSpam.Columns[0].Width = 100;
            lvSpam.Columns[1].Width = 150;
            lvSpam.Columns[2].Width = 300;
            lvSpam.Columns[3].Width = 0;
            lvSpam.Columns[4].Width = 0;
            lvCorreosEnviados.Columns[0].Width = 100;
            lvCorreosEnviados.Columns[1].Width = 150;
            lvCorreosEnviados.Columns[2].Width = 300;
            lvCorreosEnviados.Columns[3].Width = 0;
            lvCorreosEnviados.Columns[4].Width = 0;
            /* Carga mensajes */
            bgwMessages.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSpam_Click(object sender, EventArgs e)
        {
            //lvMensajes.Items[0].BackColor = Color.Aqua;
        }

        private void btnEnviados_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lvMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            lvMensajes.Clear();
            bgwMessages.RunWorkerAsync();
        }

        private void btnOpcionesUsuario_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(lvMensajes.SelectedItems.Count == 1)
            {
                tsmiResponder.Visible = true;
            }else
            {
                tsmiResponder.Visible = false;
            }
        }

        private void btnRedactar_Click(object sender, EventArgs e)
        {

                frmRedactar frm = new frmRedactar();
                frm.ShowDialog();
        }

        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            //List<int> listaCorreos = new List<int>();
            for (int i = 0; i < lvMensajes.SelectedItems.Count; i++)
            {
                int messageNumber = Convert.ToInt32(lvMensajes.SelectedItems[i].SubItems[3].Text) - 1;
                //listaCorreos.Add(messageNumber);
                lvMensajes.SelectedItems[i].BackColor = Color.DarkGray;
                lvMensajes.SelectedItems[i].ForeColor = Color.White;
                MessageManager.DeleteMessage(service, userId, mensajes[messageNumber].MessageId);
            }
            //ordenaCorreus(listaCorreos);
        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void addToProgress(int n)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    pgbProgreso.Value += n;
                } catch (ArgumentOutOfRangeException ex) { }
            }));
        }

        private void bgwMessages_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 1;
            addToProgress(10);
            mensajes = MessageManager.getMensajes(userId, service,20);
            addToProgress(30);
            int differencePerMsg = 60 / (mensajes.Count);
            foreach (Mensaje m in mensajes)
            {
                if (m.IsInbox)
                {
                    ListViewItem lvi = new ListViewItem(m.From);
                    lvi.SubItems.Add(m.Subject);
                    lvi.SubItems.Add(m.Body);
                    lvi.SubItems.Add(i.ToString());
                    lvi.SubItems.Add(m.IsUnread.ToString());
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvMensajes.Items.Add(lvi);
                    }));

                }
                if (m.IsSent)
                {
                    ListViewItem lviSent = new ListViewItem(m.From);
                    lviSent.SubItems.Add(m.Subject);
                    lviSent.SubItems.Add(m.Body);
                    lviSent.SubItems.Add(i.ToString());
                    lviSent.SubItems.Add(m.IsUnread.ToString());
                    this.Invoke(new MethodInvoker(delegate
                    {

                        lvCorreosEnviados.Items.Add(lviSent);
                    }));
                    if (m.IsUnread) { lviSent.SubItems[i-1].BackColor = Color.White; }
                }
                if (m.IsSpam)
                {
                    ListViewItem lviSpam = new ListViewItem(m.From);
                    lviSpam.SubItems.Add(m.Subject);
                    lviSpam.SubItems.Add(m.Body);
                    lviSpam.SubItems.Add(i.ToString());
                    lviSpam.SubItems.Add(m.IsUnread.ToString());
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvSpam.Items.Add(lviSpam);
                    }));
                    if (m.IsUnread) { lviSpam.SubItems[lviSpam.SubItems.Count].BackColor = Color.White; }
                }
                i++;
            }
            addToProgress(100 - pgbProgreso.Value);
        }

        private void bgwMessages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void tsmiCerrarSesion_Click(object sender, EventArgs e)
        {
            Login.DoLogout();
            Application.Restart();
            Close();
        }

        private void tsmiCambiarFondo_Click(object sender, EventArgs e)
        {
            if(this.BackgroundImage == null && this.BackColor == Color.LightGray)
            {
                tsmiLimpiarFondo.Visible = false;
            }else
            {
                tsmiLimpiarFondo.Visible = true;
            }
        }

        private void tsmiLimpiarFondo_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            this.BackColor = Color.LightGray;
        }

        private void bgwMessages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbProgreso.Value = 0;
        }

        private void tsmiColorFondo_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = dlg.Color;
            }
        }
        private void ordenaCorreus(List<int> lista)
        {
            for(int i = lista[0]; i < lista.Count(); i++) 
            {

            }
        }
    }
}
