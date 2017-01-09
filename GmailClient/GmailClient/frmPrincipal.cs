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

namespace GmailClient
{
    public partial class frmPrincipal : Form
    {
        GmailService service;
        string userId;

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
            lvMensajes.Columns[0].Width = 100;
            lvMensajes.Columns[1].Width = 150;
            lvMensajes.Columns[2].Width = 300;
            lvMensajes.Columns[3].Width = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSpam_Click(object sender, EventArgs e)
        {

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

        private void btnBandejaEntrada_Click_1(object sender, EventArgs e)
        {
            bgwMessages.RunWorkerAsync();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lvMensajes.SelectedItems.Count; i++)
            {
                deleteMessage(lvMensajes.SelectedItems[i].SubItems[3].Text);
            }
        }
        private void deleteMessage( String messageId)
        {
            try
            {
                service.Users.Messages.Delete(userId, messageId).Execute();
            }catch(Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.DoLogout();
            Application.Restart();
            Close();
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

        private void bgwMessages_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 1;
            List<Mensaje> msgs = MessageManager.getMensajes(userId, service);
            foreach (Mensaje m in msgs)
            {
                ListViewItem lvi = new ListViewItem(m.From);
                lvi.SubItems.Add(m.Subject);
                lvi.SubItems.Add(m.Body);
                lvi.SubItems.Add(i.ToString());
                this.Invoke(new MethodInvoker(delegate
                {
                    lvMensajes.Items.Add(lvi);
                }));
                
            }
        }

        private void bgwMessages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbProgreso.Value = e.ProgressPercentage;
        }
    }
}
