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
        public frmRedactar()
        {
            InitializeComponent();
            cbFont.SelectedItem = "Microsoft Sans Serif";
            cbSize.SelectedItem = "8";
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


    }
}
