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
using Google.Apis.Gmail.v1.Data;

namespace GmailClient
{
    public partial class frmPrincipal : Form
    {
        Font fontBasica;
        private GmailService service;
        private string userId;
        private List<Mensaje> mensajes;
        private int numeroMensajes = 0;
        private Profile profile;

        public frmPrincipal(GmailService service, string userId)
        {
            InitializeComponent();
            this.service = service;
            this.userId = userId;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cbNumMensajes.SelectedItem = "20";
            numeroMensajes = Convert.ToInt32(cbNumMensajes.SelectedItem);
            imLSGmail.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            profile = Usuario.GetProfile(service, userId);
            if (profile == null)
            {
                Close();
                return;
            }
            string userMail = profile.EmailAddress;
            StringBuilder aux = new StringBuilder("                ");
            for (int i = 0; i < userMail.Length; i++)
            {
                if (userMail[i] == '@')
                {
                    break;
                }
                aux[i] = userMail[i];
            }
            label1.Text = aux.ToString();

            /* Diseño de los objetos */
            this.BackColor = Color.LightGray;
            lvMensajes.Columns[0].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[1].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[2].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.4f) - 4;
            lvMensajes.Columns[3].Width = 0;
            lvMensajes.Columns[4].Width = 0;
            lvSpam.Columns[0].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[1].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[2].Width = Convert.ToInt32(lvSpam.Size.Width * 0.4f) - 4;
            lvSpam.Columns[3].Width = 0;
            lvSpam.Columns[4].Width = 0;
            lvCorreosEnviados.Columns[0].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[1].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[2].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.4f) - 4;
            lvCorreosEnviados.Columns[3].Width = 0;
            lvCorreosEnviados.Columns[4].Width = 0;

            /* Carga mensajes */
            bgwMessages.RunWorkerAsync();
        }
        
        private void btnSpam_Click(object sender, EventArgs e)
        {
            //lvMensajes.Items[0].BackColor = Color.Aqua;
        }
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            lvMensajes.Items.Clear();
            if (bgwMessages.IsBusy)
            {
                MessageBox.Show(this, "Proceso en marcha espera a que termine", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bgwMessages.RunWorkerAsync();
            }
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
            if(tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                tsmiResponder.Visible = false;
            }

        }

        private void btnRedactar_Click(object sender, EventArgs e)
        {
                frmRedactar frm = new frmRedactar(service,userId,null,null);
                frm.ShowDialog();
        }

        internal void tsmiEliminar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMensajes.SelectedItems)
            {
                int messageNumber = lvMensajes.Items.IndexOf(item);
                item.Remove();
                MessageManager.DeleteMessage(service, userId, mensajes[messageNumber].MessageId);
                for (int i = messageNumber; i < mensajes.Count - 1; i++)
                {
                    mensajes[i] = mensajes[i + 1];
                }
            }
        }
        
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
                       
            addToProgress(10);
            mensajes = MessageManager.getMensajes(userId, service, numeroMensajes);
            addToProgress(30);
            int differencePerMsg = 60 / (mensajes.Count);
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {

                    lvMensajes.BeginUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
            foreach (Mensaje m in mensajes)
            {
                if (m.IsInbox)
                {
                    ListViewItem lvi = new ListViewItem(m.From);
                    lvi.SubItems.Add(m.Subject);
                    lvi.SubItems.Add(m.Body);
                    lvi.SubItems.Add(m.IsUnread.ToString());
                    lvi.SubItems.Add(m.MessageId);
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
                    lviSent.SubItems.Add(m.IsUnread.ToString());
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvCorreosEnviados.Items.Add(lviSent);
                    }));
                }
                
                if (m.IsSpam)
                {
                    ListViewItem lviSpam = new ListViewItem(m.From);
                    lviSpam.SubItems.Add(m.Subject);
                    lviSpam.SubItems.Add(m.Body);
                    lviSpam.SubItems.Add(m.IsUnread.ToString());
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvSpam.Items.Add(lviSpam);
                    }));
                }
            }
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.EndUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
            
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
            this.BackColor = Color.Gainsboro;
        }

        private void bgwMessages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbProgreso.Value = 0;
            Font fontBold = new Font(lvMensajes.Font, FontStyle.Bold);
            for(int i = 0; i< lvMensajes.Items.Count; i++)
            {
                if (lvMensajes.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvMensajes.Items[i].Font = fontBold;
                    lvMensajes.Items[i].BackColor = Color.White;
                }else
                {
                    fontBasica = lvMensajes.Items[i].Font;
                    lvMensajes.Items[i].BackColor = Color.LightGray;
                }
            }
            for (int i = 0; i < lvSpam.Items.Count; i++)
            {
                if (lvSpam.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvSpam.Items[i].Font = fontBold;
                    lvSpam.Items[i].BackColor = Color.White;
                }else
                {
                    lvSpam.Items[i].BackColor = Color.LightGray;
                }
            }
            for (int i = 0; i < lvCorreosEnviados.Items.Count; i++)
            {
                if (lvCorreosEnviados.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvCorreosEnviados.Items[i].Font = fontBold;
                    lvCorreosEnviados.Items[i].BackColor = Color.White;
                }else
                {
                    lvCorreosEnviados.Items[i].BackColor = Color.LightGray;
                }
            }
        }

        private void tsmiColorFondo_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = dlg.Color;
            }
        }

        private void lvMensajes_DoubleClick(object sender, EventArgs e)
        {
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            ListViewItem item = lvMensajes.SelectedItems[0];
                foreach (Mensaje m in mensajes)
                {
                    if (m.MessageId == item.SubItems[4].Text)
                    {
                        if (item.SubItems[3].Text.Equals("True"))
                        {
                            MessageManager.ModifyMessage(service, userId, m.MessageId, null, listaMensajes);
                            lvMensajes.SelectedItems[0].Font = fontBasica;
                            lvMensajes.SelectedItems[0].BackColor = Color.LightGray;
                        }
                        (new frmView(this, m)).ShowDialog();
                    }
                
            }
        }

        private void btnLeerMensajes_Click(object sender, EventArgs e)
        {
            lvMensajes_DoubleClick(sender, e);
        }

        internal void tsmiMarcarLeido_Click(object sender, EventArgs e)
        {
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada")) {
                for (int i = 0; i<lvMensajes.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvMensajes.SelectedItems[i].SubItems[4].Text,null,listaMensajes);
                    lvMensajes.SelectedItems[i].Font = fontBasica;
                    lvMensajes.SelectedItems[i].BackColor = Color.LightGray;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                for (int i = 0; i < lvSpam.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvSpam.SelectedItems[i].SubItems[4].Text, null, listaMensajes);
                    lvSpam.SelectedItems[i].Font = fontBasica;
                    lvSpam.SelectedItems[i].BackColor = Color.LightGray;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                for (int i = 0; i < lvCorreosEnviados.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvCorreosEnviados.SelectedItems[i].SubItems[4].Text, null, listaMensajes);
                    lvCorreosEnviados.SelectedItems[i].Font = fontBasica;
                    lvCorreosEnviados.SelectedItems[i].BackColor = Color.LightGray;
                }
            }

        }

        private void frmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            lvMensajes.Columns[0].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[1].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[2].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.4f);
            lvMensajes.Columns[3].Width = 0;
            lvSpam.Columns[0].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[1].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[2].Width = Convert.ToInt32(lvSpam.Size.Width * 0.4f);
            lvSpam.Columns[3].Width = 0;
            lvCorreosEnviados.Columns[0].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[1].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[2].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.4f);
            lvCorreosEnviados.Columns[3].Width = 0;
        }

        private void cbNumMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeroMensajes = Convert.ToInt32(cbNumMensajes.SelectedItem);
        }

        internal void tsmiMarcarNoLeido_Click(object sender, EventArgs e)
        {
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
            {
                for (int i = 0; i < lvMensajes.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvMensajes.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvMensajes.SelectedItems[i].Font = new Font (lvMensajes.Items[i].Font,FontStyle.Bold);
                    lvMensajes.SelectedItems[i].BackColor = Color.White;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                for (int i = 0; i < lvSpam.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvSpam.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvSpam.SelectedItems[i].Font = new Font(lvSpam.Items[i].Font, FontStyle.Bold);
                    lvSpam.SelectedItems[i].BackColor = Color.White;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                for (int i = 0; i < lvCorreosEnviados.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvCorreosEnviados.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvCorreosEnviados.SelectedItems[i].Font = new Font(lvCorreosEnviados.Items[i].Font, FontStyle.Bold);
                    lvCorreosEnviados.SelectedItems[i].BackColor = Color.White;
                }
            }
        }

        internal void tsmiResponder_Click(object sender, EventArgs e)
        {
            List< String > destinatarios = new List<string>();
            destinatarios.Add(lvMensajes.SelectedItems[0].SubItems[0].Text);
            frmRedactar frm = new frmRedactar(service, userId,destinatarios,
                                     lvMensajes.SelectedItems[0].SubItems[1].Text);
            frm.ShowDialog();
        }

        internal void tsmiMarcarSpam_Click(object sender, EventArgs e)
        {
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("SPAM");
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
            {
                for (int i = 0; i < lvMensajes.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvMensajes.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvMensajes.SelectedItems[i].Font = fontBasica;
                    lvMensajes.SelectedItems[i].BackColor = Color.LightGray;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                for (int i = 0; i < lvSpam.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvSpam.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvSpam.SelectedItems[i].Font = fontBasica;
                    lvSpam.SelectedItems[i].BackColor = Color.LightGray;
                }
            }
            /*if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                for (int i = 0; i < lvCorreosEnviados.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvCorreosEnviados.SelectedItems[i].SubItems[4].Text, null, listaMensajes);
                    lvCorreosEnviados.SelectedItems[i].Font = fontBasica;
                    lvCorreosEnviados.SelectedItems[i].BackColor = Color.LightGray;
                }
            }*/
        }
    }
}
