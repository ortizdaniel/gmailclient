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

namespace GmailClient
{
    public partial class frmRedactar : Form
    {
        private bool bold = false;
        private bool underline = false;
        private int size = 10;
        private GmailService service;
        private String userId;

        public frmRedactar(GmailService service, String userId, List<String> destinatario, String asunto,String Contenido)
        {
            /* User ID util per a enviar el correu */
            this.userId = userId;
            InitializeComponent();
            StringBuilder strbdr = new StringBuilder();
            String dest;
            /* Si hi ha destinatari el fiquem al bloc de text del destinatari */
            if (destinatario != null)
            {
                if (destinatario.Count > 1)
                {
                    for (int i = 0; i < destinatario.Count; i++)
                    {
                        dest = destinatario[i];
                        if (i == (destinatario.Count - 1))
                        {
                            strbdr.Append(dest);
                        }
                        else
                        {
                            strbdr.Append(dest + ", ");
                        }
                    }
                }
                else
                {
                    tbDestinatario.Text = destinatario[0];
                }
            }
            /* Si es fa un responder o reenviar s'afegeix l'etiqueta RE: + l'asumpte */
            if (asunto != null)
            {
                tbAsunto.Text = "RE: " + asunto;
            }
            /* default interface */
            rtbContenido.Text = Contenido;
            btnBold.BackColor = Color.LightGray;
            btnUnderline.BackColor = Color.LightGray;
            cbFont.SelectedItem = "Microsoft Sans Serif";
            cbSize.SelectedItem = "10";
            size = Int32.Parse(cbSize.SelectedItem.ToString());
            Font font = new Font(cbFont.SelectedItem.ToString(), size);
            tbAsunto.Font = font;
            tbDestinatario.Font = font;
            this.service = service;
        }

        private void frmRedactar_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            /* Activa o desactiva la negreta al Body */
            bold = !bold;
            /* No es pot tenir subrallat i negreta a l'hora */
            if (underline)
            {
                btnUnderline.BackColor = Color.LightGray;
                underline = false;
            }
            if (bold)
            {
                btnBold.BackColor = Color.Gray;
                Font font = new Font(rtbContenido.Font, FontStyle.Bold);
                rtbContenido.Font = font;
            }else
            {
                btnBold.BackColor = Color.LightGray;
                Font font = new Font(rtbContenido.Font, FontStyle.Regular);
                rtbContenido.Font = font;
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            /* Activa o desactiva el subrallat al Body */
            underline = !underline;
            /* No es pot tenir subrallat i negreta a l'hora */
            if (bold)
            {
                btnBold.BackColor = Color.LightGray;
                bold = false;
            }
            if (underline)
            {
                btnUnderline.BackColor = Color.Gray;
                Font font = new Font(rtbContenido.Font, FontStyle.Underline);
                rtbContenido.Font = font;
            }
            else
            {
                btnUnderline.BackColor = Color.LightGray;
                Font font = new Font(rtbContenido.Font, FontStyle.Regular);
                rtbContenido.Font = font;
            }
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Canvi de mida de la lletra */
            size = Int32.Parse(cbSize.SelectedItem.ToString());
            rtbContenido.Font = new Font(rtbContenido.Font.Name,size);
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Tipus de text (Arial,Calibri,...) */
            rtbContenido.Font = new Font(cbFont.SelectedItem.ToString(),size);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            /* Enviem el correu */
            List<string> lista = new List<string>(tbDestinatario.Text.Replace(" ", "").Split(','));
            foreach (string dest in lista)
            {
                MessageManager.SendMessage(userId, dest, rtbContenido.Text, tbAsunto.Text, service);
            }
            Close();
        }

    }
}
