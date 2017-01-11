namespace GmailClient
{
    partial class frmView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnMarcarComoLeido = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMarcarComoNoLeido = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResponder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReenviar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMarcarComoSpam = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemitente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContenido
            // 
            this.txtContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContenido.Location = new System.Drawing.Point(12, 92);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.ReadOnly = true;
            this.txtContenido.Size = new System.Drawing.Size(575, 365);
            this.txtContenido.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMarcarComoLeido,
            this.btnMarcarComoNoLeido,
            this.btnMarcarComoSpam,
            this.btnResponder,
            this.btnReenviar,
            this.btnEliminar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnMarcarComoLeido
            // 
            this.btnMarcarComoLeido.Name = "btnMarcarComoLeido";
            this.btnMarcarComoLeido.Size = new System.Drawing.Size(119, 20);
            this.btnMarcarComoLeido.Text = "Marcar como léido";
            this.btnMarcarComoLeido.Click += new System.EventHandler(this.btnMarcarComoLeido_Click);
            // 
            // btnMarcarComoNoLeido
            // 
            this.btnMarcarComoNoLeido.Name = "btnMarcarComoNoLeido";
            this.btnMarcarComoNoLeido.Size = new System.Drawing.Size(136, 20);
            this.btnMarcarComoNoLeido.Text = "Marcar como no léido";
            // 
            // btnResponder
            // 
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(75, 20);
            this.btnResponder.Text = "Responder";
            // 
            // btnReenviar
            // 
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(64, 20);
            this.btnReenviar.Text = "Reenviar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(62, 20);
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnMarcarComoSpam
            // 
            this.btnMarcarComoSpam.Name = "btnMarcarComoSpam";
            this.btnMarcarComoSpam.Size = new System.Drawing.Size(122, 20);
            this.btnMarcarComoSpam.Text = "Marcar como spam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contenido:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(61, 27);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.ReadOnly = true;
            this.txtAsunto.Size = new System.Drawing.Size(526, 20);
            this.txtAsunto.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Asunto:";
            // 
            // txtRemitente
            // 
            this.txtRemitente.Location = new System.Drawing.Point(76, 53);
            this.txtRemitente.Name = "txtRemitente";
            this.txtRemitente.ReadOnly = true;
            this.txtRemitente.Size = new System.Drawing.Size(511, 20);
            this.txtRemitente.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Remitente:";
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 469);
            this.Controls.Add(this.txtRemitente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leer mensaje";
            this.Load += new System.EventHandler(this.frmView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnMarcarComoLeido;
        private System.Windows.Forms.ToolStripMenuItem btnMarcarComoNoLeido;
        private System.Windows.Forms.ToolStripMenuItem btnResponder;
        private System.Windows.Forms.ToolStripMenuItem btnReenviar;
        private System.Windows.Forms.ToolStripMenuItem btnEliminar;
        private System.Windows.Forms.ToolStripMenuItem btnMarcarComoSpam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemitente;
        private System.Windows.Forms.Label label1;
    }
}