namespace GmailClient
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnBandejaEntrada = new System.Windows.Forms.Button();
            this.btnSpam = new System.Windows.Forms.Button();
            this.btnEnviados = new System.Windows.Forms.Button();
            this.lvMensajes = new System.Windows.Forms.ListView();
            this.clmRemitente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAsunto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPreview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiResponder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResponderRemitente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResponderAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarcarSpam = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.imLSGmail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpcionesUsuario = new System.Windows.Forms.Button();
            this.clmIdMensaje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBandejaEntrada
            // 
            this.btnBandejaEntrada.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBandejaEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBandejaEntrada.Location = new System.Drawing.Point(12, 94);
            this.btnBandejaEntrada.Name = "btnBandejaEntrada";
            this.btnBandejaEntrada.Size = new System.Drawing.Size(152, 35);
            this.btnBandejaEntrada.TabIndex = 0;
            this.btnBandejaEntrada.Text = "Bandeja de Entrada";
            this.btnBandejaEntrada.UseVisualStyleBackColor = false;
            this.btnBandejaEntrada.Click += new System.EventHandler(this.btnBandejaEntrada_Click_1);
            // 
            // btnSpam
            // 
            this.btnSpam.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSpam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpam.Location = new System.Drawing.Point(12, 135);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(152, 35);
            this.btnSpam.TabIndex = 0;
            this.btnSpam.Text = "Spam";
            this.btnSpam.UseVisualStyleBackColor = false;
            this.btnSpam.Click += new System.EventHandler(this.btnSpam_Click);
            // 
            // btnEnviados
            // 
            this.btnEnviados.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnviados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviados.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnviados.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEnviados.Location = new System.Drawing.Point(12, 176);
            this.btnEnviados.Name = "btnEnviados";
            this.btnEnviados.Size = new System.Drawing.Size(152, 35);
            this.btnEnviados.TabIndex = 0;
            this.btnEnviados.Text = "Correos Enviados";
            this.btnEnviados.UseVisualStyleBackColor = false;
            this.btnEnviados.Click += new System.EventHandler(this.btnEnviados_Click);
            // 
            // lvMensajes
            // 
            this.lvMensajes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvMensajes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRemitente,
            this.clmAsunto,
            this.clmPreview,
            this.clmIdMensaje});
            this.lvMensajes.ContextMenuStrip = this.contextMenuStrip1;
            this.lvMensajes.FullRowSelect = true;
            this.lvMensajes.GridLines = true;
            this.lvMensajes.Location = new System.Drawing.Point(183, 74);
            this.lvMensajes.Name = "lvMensajes";
            this.lvMensajes.Size = new System.Drawing.Size(421, 411);
            this.lvMensajes.TabIndex = 1;
            this.lvMensajes.UseCompatibleStateImageBehavior = false;
            this.lvMensajes.View = System.Windows.Forms.View.Details;
            this.lvMensajes.SelectedIndexChanged += new System.EventHandler(this.lvMensajes_SelectedIndexChanged);
            // 
            // clmRemitente
            // 
            this.clmRemitente.Text = "Remitente";
            this.clmRemitente.Width = 115;
            // 
            // clmAsunto
            // 
            this.clmAsunto.Text = "Asunto";
            this.clmAsunto.Width = 131;
            // 
            // clmPreview
            // 
            this.clmPreview.Text = "Contenido";
            this.clmPreview.Width = 186;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResponder,
            this.tsmiEliminar,
            this.tsmiMarcarSpam});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiResponder
            // 
            this.tsmiResponder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResponderRemitente,
            this.tsmiResponderAll});
            this.tsmiResponder.Name = "tsmiResponder";
            this.tsmiResponder.Size = new System.Drawing.Size(178, 22);
            this.tsmiResponder.Text = "Responder";
            this.tsmiResponder.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmiResponderRemitente
            // 
            this.tsmiResponderRemitente.Name = "tsmiResponderRemitente";
            this.tsmiResponderRemitente.Size = new System.Drawing.Size(172, 22);
            this.tsmiResponderRemitente.Text = "Responder";
            // 
            // tsmiResponderAll
            // 
            this.tsmiResponderAll.Name = "tsmiResponderAll";
            this.tsmiResponderAll.Size = new System.Drawing.Size(172, 22);
            this.tsmiResponderAll.Text = "Responder a todos";
            // 
            // tsmiEliminar
            // 
            this.tsmiEliminar.Name = "tsmiEliminar";
            this.tsmiEliminar.Size = new System.Drawing.Size(178, 22);
            this.tsmiEliminar.Text = "Eliminar";
            this.tsmiEliminar.Click += new System.EventHandler(this.tsmiEliminar_Click);
            // 
            // tsmiMarcarSpam
            // 
            this.tsmiMarcarSpam.Name = "tsmiMarcarSpam";
            this.tsmiMarcarSpam.Size = new System.Drawing.Size(178, 22);
            this.tsmiMarcarSpam.Text = "Marcar como Spam";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button4.Location = new System.Drawing.Point(12, 278);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Marcar como leído";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button5.Location = new System.Drawing.Point(12, 307);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Marcar como no leído";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button6.Location = new System.Drawing.Point(12, 336);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Borrar";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(183, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(43, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button8.Location = new System.Drawing.Point(232, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(95, 41);
            this.button8.TabIndex = 6;
            this.button8.Text = "Redactar Correo";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // imLSGmail
            // 
            this.imLSGmail.Image = ((System.Drawing.Image)(resources.GetObject("imLSGmail.Image")));
            this.imLSGmail.Location = new System.Drawing.Point(9, 12);
            this.imLSGmail.Name = "imLSGmail";
            this.imLSGmail.Size = new System.Drawing.Size(155, 50);
            this.imLSGmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imLSGmail.TabIndex = 7;
            this.imLSGmail.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // btnOpcionesUsuario
            // 
            this.btnOpcionesUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnOpcionesUsuario.Image")));
            this.btnOpcionesUsuario.Location = new System.Drawing.Point(582, 13);
            this.btnOpcionesUsuario.Name = "btnOpcionesUsuario";
            this.btnOpcionesUsuario.Size = new System.Drawing.Size(22, 16);
            this.btnOpcionesUsuario.TabIndex = 9;
            this.btnOpcionesUsuario.UseVisualStyleBackColor = true;
            this.btnOpcionesUsuario.Click += new System.EventHandler(this.btnOpcionesUsuario_Click);
            // 
            // clmIdMensaje
            // 
            this.clmIdMensaje.Text = "id";
            this.clmIdMensaje.Width = 0;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(616, 498);
            this.Controls.Add(this.btnOpcionesUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imLSGmail);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lvMensajes);
            this.Controls.Add(this.btnEnviados);
            this.Controls.Add(this.btnSpam);
            this.Controls.Add(this.btnBandejaEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "GmailClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBandejaEntrada;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.Button btnEnviados;
        private System.Windows.Forms.ListView lvMensajes;
        private System.Windows.Forms.ColumnHeader clmRemitente;
        private System.Windows.Forms.ColumnHeader clmAsunto;
        private System.Windows.Forms.ColumnHeader clmPreview;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.PictureBox imLSGmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpcionesUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponder;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponderRemitente;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponderAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarcarSpam;
        private System.Windows.Forms.ColumnHeader clmIdMensaje;
    }
}

