﻿using Google.Apis.Gmail.v1;
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
        int numeroMensajes = 0;
        Font fontBasica;

        public frmPrincipal(GmailService service, string userId)
        {
            InitializeComponent();
            cbNumMensajes.SelectedItem = "20";
            numeroMensajes = Convert.ToInt32(cbNumMensajes.SelectedItem);
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
            lvMensajes.Columns[0].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[1].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.3f);
            lvMensajes.Columns[2].Width = Convert.ToInt32(lvMensajes.Size.Width * 0.4f);
            lvMensajes.Columns[3].Width = 0;
            lvMensajes.Columns[4].Width = 0;
            lvSpam.Columns[0].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[1].Width = Convert.ToInt32(lvSpam.Size.Width * 0.3f);
            lvSpam.Columns[2].Width = Convert.ToInt32(lvSpam.Size.Width * 0.4f);
            lvSpam.Columns[3].Width = 0;
            lvSpam.Columns[4].Width = 0;
            lvCorreosEnviados.Columns[0].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[1].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.3f);
            lvCorreosEnviados.Columns[2].Width = Convert.ToInt32(lvCorreosEnviados.Size.Width * 0.4f);
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
                }
            }
            for (int i = 0; i < lvSpam.Items.Count; i++)
            {
                if (lvSpam.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvSpam.Items[i].Font = fontBold;
                    lvSpam.Items[i].BackColor = Color.White;
                }
            }
            for (int i = 0; i < lvCorreosEnviados.Items.Count; i++)
            {
                if (lvCorreosEnviados.Items[i].SubItems[3].Text.Equals("True"))
                {
                    lvCorreosEnviados.Items[i].Font = fontBold;
                    lvCorreosEnviados.Items[i].BackColor = Color.White;
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

        private void ordenaCorreus(List<int> lista)
        {
            for(int i = lista[0]; i < lista.Count(); i++) 
            {

            }
        }

        private void lvMensajes_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMensajes.SelectedItems)
            {
                foreach (Mensaje m in mensajes)
                {
                    Console.WriteLine(m.MessageId);
                    Console.WriteLine(item.SubItems[4].Text.ToString());
                    if (m.MessageId == item.SubItems[4].Text)
                    {
                        (new frmView(this, m)).Show();
                    }
                }
            }
        }

        private void btnLeerMensajes_Click(object sender, EventArgs e)
        {
            lvMensajes_DoubleClick(sender, e);
        }

        public void tsmiMarcarLeido_Click(object sender, EventArgs e)
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

        private void tsmiMarcarNoLeido_Click(object sender, EventArgs e)
        {
            List<String> listaMensajes = new List<string>();
            listaMensajes.Add("UNREAD");
            if (tbcBandejas.SelectedTab.Text.Equals("Bandeja de entrada"))
            {
                for (int i = 0; i < lvMensajes.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvMensajes.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvMensajes.Items[i].Font = new Font (lvMensajes.Items[i].Font,FontStyle.Bold);
                    lvMensajes.Items[i].BackColor = Color.White;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Spam"))
            {
                for (int i = 0; i < lvSpam.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvSpam.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvSpam.Items[i].Font = new Font(lvSpam.Items[i].Font, FontStyle.Bold);
                    lvSpam.Items[i].BackColor = Color.White;
                }
            }
            if (tbcBandejas.SelectedTab.Text.Equals("Correos enviados"))
            {
                for (int i = 0; i < lvCorreosEnviados.SelectedItems.Count; i++)
                {
                    MessageManager.ModifyMessage(service, userId, lvCorreosEnviados.SelectedItems[i].SubItems[4].Text, listaMensajes, null);
                    lvCorreosEnviados.Items[i].Font = new Font(lvCorreosEnviados.Items[i].Font, FontStyle.Bold);
                    lvCorreosEnviados.Items[i].BackColor = Color.White;
                }
            }
        }
    }
}
