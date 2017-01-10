namespace GmailClient
{
    partial class frmRedactar
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
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.tbContenido = new System.Windows.Forms.TextBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.tbDestinatario = new System.Windows.Forms.TextBox();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.btnBold = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinatario.Location = new System.Drawing.Point(12, 53);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(103, 18);
            this.lblDestinatario.TabIndex = 0;
            this.lblDestinatario.Text = "Destinatario/s:";
            this.lblDestinatario.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.Location = new System.Drawing.Point(12, 190);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(80, 18);
            this.lblContenido.TabIndex = 2;
            this.lblContenido.Text = "Contenido:";
            this.lblContenido.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbContenido
            // 
            this.tbContenido.Location = new System.Drawing.Point(15, 211);
            this.tbContenido.Multiline = true;
            this.tbContenido.Name = "tbContenido";
            this.tbContenido.Size = new System.Drawing.Size(448, 275);
            this.tbContenido.TabIndex = 2;
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsunto.Location = new System.Drawing.Point(12, 116);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(58, 18);
            this.lblAsunto.TabIndex = 3;
            this.lblAsunto.Text = "Asunto:";
            // 
            // tbDestinatario
            // 
            this.tbDestinatario.Location = new System.Drawing.Point(15, 74);
            this.tbDestinatario.Multiline = true;
            this.tbDestinatario.Name = "tbDestinatario";
            this.tbDestinatario.Size = new System.Drawing.Size(448, 29);
            this.tbDestinatario.TabIndex = 4;
            // 
            // tbAsunto
            // 
            this.tbAsunto.Location = new System.Drawing.Point(15, 147);
            this.tbAsunto.Multiline = true;
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(448, 29);
            this.tbAsunto.TabIndex = 5;
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "11",
            "12",
            "14",
            "16"});
            this.cbSize.Location = new System.Drawing.Point(142, 12);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(40, 21);
            this.cbSize.TabIndex = 6;
            // 
            // cbFont
            // 
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Franklin Gothic Book",
            "Microsoft Sans Serif"});
            this.cbFont.Location = new System.Drawing.Point(15, 12);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(121, 21);
            this.cbFont.TabIndex = 7;
            // 
            // btnBold
            // 
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(188, 8);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(28, 26);
            this.btnBold.TabIndex = 8;
            this.btnBold.Text = "N";
            this.btnBold.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(222, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEnviar.Location = new System.Drawing.Point(334, 19);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(128, 34);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            // 
            // frmRedactar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 498);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.cbFont);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.tbAsunto);
            this.Controls.Add(this.tbDestinatario);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.tbContenido);
            this.Controls.Add(this.lblContenido);
            this.Controls.Add(this.lblDestinatario);
            this.Name = "frmRedactar";
            this.Text = "frmRedactar";
            this.Load += new System.EventHandler(this.frmRedactar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.TextBox tbContenido;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox tbDestinatario;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEnviar;
    }
}