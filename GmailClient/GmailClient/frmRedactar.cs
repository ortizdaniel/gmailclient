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
        private Boolean bold = false;
        private Boolean underline = false;
        int size = 10;

        public frmRedactar()
        {
            InitializeComponent();
            cbFont.SelectedItem = "Microsoft Sans Serif";
            cbSize.SelectedItem = "10";
            size = Int32.Parse(cbSize.SelectedItem.ToString());
            Font font = new Font(cbFont.SelectedItem.ToString(), size);
            tbAsunto.Font = font;
            tbDestinatario.Font = font;
        }

        private void frmRedactar_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            //Console.Write(tbContenido.SelectedText.ToString());
            bold = !bold;
            //if(richTextBox1.SelectionFont.Bold)
            //if(tbContenido.SelectionFont.
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            underline = !underline;
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = size = Int32.Parse(cbSize.SelectedItem.ToString());
            rtbContenido.Font = new Font(rtbContenido.Font.Name,size);
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbContenido.Font = new Font(cbFont.SelectedItem.ToString(),size);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Console.WriteLine(rtbContenido.SelectedText);//testing
        }
    }
}
