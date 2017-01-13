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
        private List<Mensaje> mensajesSpam;
        private List<Mensaje> mensajesTrash;
        private int numeroMensajes = 0;
        private Profile profile;

        public Profile getProfile()
        {
            return profile;
        }

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
            lvPapelera.Columns[0].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvPapelera.Columns[1].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvPapelera.Columns[2].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.4f) - 4;
            lvPapelera.Columns[3].Width = 0;
            lvPapelera.Columns[4].Width = 0;

            /* Carga mensajes */
            bgwMessages.RunWorkerAsync();
        }
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (bgwMessages.IsBusy)
            {
                MessageBox.Show(this, "Proceso en marcha espera a que termine", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lvMensajes.Items.Clear();
                lvSpam.Items.Clear();
                lvCorreosEnviados.Items.Clear();
                lvPapelera.Items.Clear();
                bgwMessages.RunWorkerAsync();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /* evitem segon botó quan encara no hi han emails */
            if (bgwMessages.IsBusy)
            {
                btnLeerMensajes.Visible = false;
                tsmiReenviar.Visible = false;
                tsmiResponder.Visible = false;
                tsmiEliminar.Visible = false;
                tsmiMarcarLeido.Visible = false;
                tsmiMarcarNoLeido.Visible = false;
                tsmiMarcarSpam.Visible = false;
            }else
            {
                btnLeerMensajes.Visible = true;
                tsmiReenviar.Visible = true;
                tsmiResponder.Visible = true;
                tsmiEliminar.Visible = true;
                tsmiMarcarLeido.Visible = true;
                tsmiMarcarNoLeido.Visible = true;
                tsmiMarcarSpam.Visible = true;
            }
            /* evitem respondre a mes d'un email */
            if (lvMensajes.SelectedItems.Count == 1)
            {
                tsmiResponder.Visible = true;
            }else
            {
                tsmiResponder.Visible = false;
            }
            if (!tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
            {
                tsmiReenviar.Visible = false;
            }
                /* evitem opcions a un email enviat */
                if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                tsmiResponder.Visible = false;
                tsmiMarcarLeido.Visible = false;
                tsmiMarcarNoLeido.Visible = false;
                tsmiMarcarSpam.Visible = false;
            }

        }

        private void btnRedactar_Click(object sender, EventArgs e)
        {
            /* obrim ventant redaccio */
            frmRedactar frm = new frmRedactar(service,userId,null,null,null);
            frm.ShowDialog();
        }

        internal void tsmiEliminar_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.BeginUpdate();
                    lvSpam.BeginUpdate();
                    lvCorreosEnviados.BeginUpdate();
                    lvPapelera.BeginUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
            /* Eliminem el missatge en funció de la pestanya a la que estigui */
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
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
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                foreach (ListViewItem item in lvSpam.SelectedItems)
                {
                    int messageNumber = lvSpam.Items.IndexOf(item);
                    item.Remove();
                    MessageManager.DeleteMessage(service, userId, mensajes[messageNumber].MessageId);
                    for (int i = messageNumber; i < mensajes.Count - 1; i++)
                    {
                        mensajes[i] = mensajes[i + 1];
                    }
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                foreach (ListViewItem item in lvCorreosEnviados.SelectedItems)
                {
                    int messageNumber = lvCorreosEnviados.Items.IndexOf(item);
                    item.Remove();
                    MessageManager.DeleteMessage(service, userId, mensajes[messageNumber].MessageId);
                    for (int i = messageNumber; i < mensajes.Count - 1; i++)
                    {
                        mensajes[i] = mensajes[i + 1];
                    }
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Papelera"))
            {
                foreach (ListViewItem item in lvPapelera.SelectedItems)
                {
                    int messageNumber = lvPapelera.Items.IndexOf(item);
                    item.Remove();
                    MessageManager.DeleteForeverMessage(service, userId, mensajes[messageNumber].MessageId);
                    for (int i = messageNumber; i < mensajes.Count - 1; i++)
                    {
                        mensajes[i] = mensajes[i + 1];
                    }
                }
            }
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.EndUpdate();
                    lvSpam.EndUpdate();
                    lvCorreosEnviados.EndUpdate();
                    lvPapelera.EndUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
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
            /* booleans perque tots els emails son inbox */
            Boolean sent = false;
            int i = 0;
            addToProgress(10);
            /* Demanem Correus a l'API */
            mensajes = MessageManager.getMensajes(userId, service, numeroMensajes);
            mensajesSpam = MessageManager.getMensajes(userId, service, numeroMensajes, new string[] { "SPAM" });
            mensajesTrash = MessageManager.getMensajes(userId, service, numeroMensajes, new string[]{ "TRASH" });
            addToProgress(30);
            int differencePerMsg = 60 / (mensajes.Count);
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.BeginUpdate();
                    lvSpam.BeginUpdate();
                    lvCorreosEnviados.BeginUpdate();
                    lvPapelera.BeginUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
            if (mensajes != null)
            {
                foreach (Mensaje m in mensajes)
                {
                    /* Si es un correu enviat per nosaltres el fiquem al tab de enviats */
                    if (m.IsSent)
                    {
                        sent = true;
                        ListViewItem lviSent = new ListViewItem(m.From);
                        lviSent.SubItems.Add(m.Subject);
                        lviSent.SubItems.Add(m.Body);
                        lviSent.SubItems.Add(m.IsUnread.ToString());
                        lviSent.SubItems.Add(m.MessageId);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvCorreosEnviados.Items.Add(lviSent);
                        }));
                    }
                    /* Si NO es un correu enviat per nosaltres el fiquem a inbox */
                    if (m.IsInbox && !sent)
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
                    sent = false;
                }
            }
            if (mensajesSpam != null)
            {
                foreach (Mensaje m in mensajesSpam)
                {
                    /* Si es un correu de Spam el fiquem al tab de Spam */

                    if (m.IsSpam)
                    {
                        ListViewItem lviSpam = new ListViewItem(m.From);
                        lviSpam.SubItems.Add(m.Subject);
                        lviSpam.SubItems.Add(m.Body);
                        lviSpam.SubItems.Add(m.IsUnread.ToString());
                        lviSpam.SubItems.Add(m.MessageId);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvSpam.Items.Add(lviSpam);
                        }));
                    }
                }
            }
            if (mensajesTrash != null) {
                foreach (Mensaje m in mensajesTrash)
                {
                    /* Si es un correu de la paperera el fiquem al tab de la paperera */
                    if (m.IsTrash)
                    {
                        ListViewItem lviPapelera = new ListViewItem(m.From);
                        lviPapelera.SubItems.Add(m.Subject);
                        lviPapelera.SubItems.Add(m.Body);
                        lviPapelera.SubItems.Add(m.IsUnread.ToString());
                        lviPapelera.SubItems.Add(m.MessageId);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvPapelera.Items.Add(lviPapelera);
                        }));
                    }
                }
            }
            
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.EndUpdate();
                    lvSpam.EndUpdate();
                    lvCorreosEnviados.EndUpdate();
                    lvPapelera.EndUpdate();
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
            /* Tanquem Sessio */
            Login.DoLogout();
            Application.Restart();
            Close();
        }

        private void tsmiCambiarFondo_Click(object sender, EventArgs e)
        {
            /* Si el color de fons s'ha canviat mostra opcio per defecte */
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
            /* Fiquem fondo per defecte */
            this.BackgroundImage = null;
            this.BackColor = Color.Gainsboro;
        }

        private void bgwMessages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /* Si estan com a no llegits els marquem d'un altre color */
            pgbProgreso.Value = 0;
            Font fontBold = new Font(lvMensajes.Font, FontStyle.Bold);

            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.BeginUpdate();
                    lvSpam.BeginUpdate();
                    lvCorreosEnviados.BeginUpdate();
                    lvPapelera.BeginUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));

            //tab bandeja de entrada
            for (int i = 0; i< lvMensajes.Items.Count; i++)
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
            // tab spam
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
            //tab enviats
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
            //tab papelera
            for (int i = 0; i < lvPapelera.Items.Count; i++)
            {
                if (lvPapelera.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvPapelera.Items[i].Font = fontBold;
                    lvPapelera.Items[i].BackColor = Color.White;
                }
                else
                {
                    lvPapelera.Items[i].BackColor = Color.LightGray;
                }
            }
            this.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    lvMensajes.EndUpdate();
                    lvSpam.EndUpdate();
                    lvCorreosEnviados.EndUpdate();
                    lvPapelera.EndUpdate();
                }
                catch (ArgumentOutOfRangeException ex) { }
            }));
        }

        private void tsmiColorFondo_Click(object sender, EventArgs e)
        {
            /* Permetem personalitzar el fons */
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = dlg.Color;
            }
        }

        private void lvMensajes_DoubleClick(object sender, EventArgs e)
        {
            /* Obrim missatge de Inbox */
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
                    break;
                }

            }
        }
        private void lvCorreosEnviados_DoubleClick(object sender, EventArgs e)
        {
            /* Obrim missatge de Enviats */
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            ListViewItem item = lvCorreosEnviados.SelectedItems[0];
            foreach (Mensaje m in mensajes)
            {
                if (m.MessageId == item.SubItems[4].Text)
                {
                    if (item.SubItems[3].Text.Equals("True"))
                    {
                        MessageManager.ModifyMessage(service, userId, m.MessageId, null, listaMensajes);
                        lvCorreosEnviados.SelectedItems[0].Font = fontBasica;
                        lvCorreosEnviados.SelectedItems[0].BackColor = Color.LightGray;
                    }
                    (new frmView(this, m)).ShowDialog();
                    break;
                }

            }
        }
        private void lvSpam_DoubleClick(object sender, EventArgs e)
        {
            /* Obrim missatge de Spam */

            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            ListViewItem item = lvSpam.SelectedItems[0];
            foreach (Mensaje m in mensajesSpam)
            {
                Console.WriteLine(m.MessageId + " , " + item.SubItems[4].Text);

                if (m.MessageId == item.SubItems[4].Text)
                {
                    if (item.SubItems[3].Text.Equals("True"))
                    {
                        MessageManager.ModifyMessage(service, userId, m.MessageId, null, listaMensajes);
                        lvSpam.SelectedItems[0].Font = fontBasica;
                        lvSpam.SelectedItems[0].BackColor = Color.LightGray;
                    }
                    (new frmView(this, m)).ShowDialog();
                    break;
                }

            }
        }
        private void lvPapelera_DoubleClick(object sender, EventArgs e)
        {
            /* Obrim missatge de Papelera */

            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            ListViewItem item = lvPapelera.SelectedItems[0];
            foreach (Mensaje m in mensajesTrash)
            {
                if (m.MessageId == item.SubItems[4].Text)
                {
                    if (item.SubItems[3].Text.Equals("True"))
                    {
                        MessageManager.ModifyMessage(service, userId, m.MessageId, null, listaMensajes);
                        lvPapelera.SelectedItems[0].Font = fontBasica;
                        lvPapelera.SelectedItems[0].BackColor = Color.LightGray;
                    }
                    (new frmView(this, m)).ShowDialog();
                    break;
                }

            }
        }
        private void btnLeerMensajes_Click(object sender, EventArgs e)
        {
            /* Obrir missatges a partir del boto secundari */
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
            {
                lvMensajes_DoubleClick(sender, e);
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                lvSpam_DoubleClick(sender, e);
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                lvCorreosEnviados_DoubleClick(sender, e);
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Papelera"))
            {
                lvPapelera_DoubleClick(sender, e);
            }
        }

        internal void tsmiMarcarLeido_Click(object sender, EventArgs e)
        {
            /* Marcar com a llegit */
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
            /* Mantenim les proporcions de la finestra per quan es fa un resize */
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
            lvPapelera.Columns[0].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvPapelera.Columns[1].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvPapelera.Columns[2].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.4f) - 4;
            lvPapelera.Columns[3].Width = 0;
            lvPapelera.Columns[4].Width = 0;
            //lbNumMensajes.Location.X = Convert.ToInt32(lvMensajes.Size.Width) - 24;
        }

        private void cbNumMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeroMensajes = Convert.ToInt32(cbNumMensajes.SelectedItem);
        }

        internal void tsmiMarcarNoLeido_Click(object sender, EventArgs e)
        {
            /* Marquem com a no llegit */
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
            /* Obrim la finestra de redactar per a respondre a un correu */
            List< String > destinatarios = new List<string>();
            destinatarios.Add(lvMensajes.SelectedItems[0].SubItems[0].Text);
            frmRedactar frm = new frmRedactar(service, userId,destinatarios,
                                     lvMensajes.SelectedItems[0].SubItems[1].Text,null);
            frm.ShowDialog();
        }

        internal void tsmiMarcarSpam_Click(object sender, EventArgs e)
        {
            /* Marquem com a SPAM un missatge */
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
        }

        internal void tsmiReenviar_Click(object sender, EventArgs e)
        {
            /* Reenviem un correu a un altre persona */
            frmRedactar frm = new frmRedactar(service, userId, null,
                                     lvMensajes.SelectedItems[0].SubItems[1].Text, lvMensajes.SelectedItems[0].SubItems[2].Text);
            frm.ShowDialog();
        }
    }
}
