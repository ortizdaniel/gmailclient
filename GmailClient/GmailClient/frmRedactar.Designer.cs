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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRedactar));
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.tbDestinatario = new System.Windows.Forms.TextBox();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rtbContenido = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imLSGmail = new System.Windows.Forms.PictureBox();
            this.lbAdvice = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinatario.Location = new System.Drawing.Point(12, 73);
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
            this.lblContenido.Location = new System.Drawing.Point(12, 172);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(80, 18);
            this.lblContenido.TabIndex = 2;
            this.lblContenido.Text = "Contenido:";
            this.lblContenido.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsunto.Location = new System.Drawing.Point(12, 123);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(58, 18);
            this.lblAsunto.TabIndex = 3;
            this.lblAsunto.Text = "Asunto:";
            // 
            // tbDestinatario
            // 
            this.tbDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDestinatario.Location = new System.Drawing.Point(12, 94);
            this.tbDestinatario.Multiline = true;
            this.tbDestinatario.Name = "tbDestinatario";
            this.tbDestinatario.Size = new System.Drawing.Size(448, 26);
            this.tbDestinatario.TabIndex = 4;
            // 
            // tbAsunto
            // 
            this.tbAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAsunto.Location = new System.Drawing.Point(14, 144);
            this.tbAsunto.Multiline = true;
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(448, 25);
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
            this.cbSize.Location = new System.Drawing.Point(138, 3);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(40, 21);
            this.cbSize.TabIndex = 6;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // cbFont
            // 
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Franklin Gothic Book",
            "Microsoft Sans Serif"});
            this.cbFont.Location = new System.Drawing.Point(3, 3);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(121, 21);
            this.cbFont.TabIndex = 7;
            this.cbFont.SelectedIndexChanged += new System.EventHandler(this.cbFont_SelectedIndexChanged);
            // 
            // btnBold
            // 
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(189, 3);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(28, 25);
            this.btnBold.TabIndex = 8;
            this.btnBold.Text = "N";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnderline.Location = new System.Drawing.Point(228, 3);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(28, 25);
            this.btnUnderline.TabIndex = 9;
            this.btnUnderline.Text = "S";
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEnviar.Location = new System.Drawing.Point(334, 19);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(128, 34);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rtbContenido
            // 
            this.rtbContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbContenido.Location = new System.Drawing.Point(12, 193);
            this.rtbContenido.Name = "rtbContenido";
            this.rtbContenido.Size = new System.Drawing.Size(448, 245);
            this.rtbContenido.TabIndex = 11;
            this.rtbContenido.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.48677F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.51323F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel1.Controls.Add(this.cbFont, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBold, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUnderline, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 441);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 31);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // imLSGmail
            // 
            this.imLSGmail.Image = ((System.Drawing.Image)(resources.GetObject("imLSGmail.Image")));
            this.imLSGmail.Location = new System.Drawing.Point(12, 12);
            this.imLSGmail.Name = "imLSGmail";
            this.imLSGmail.Size = new System.Drawing.Size(144, 58);
            this.imLSGmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imLSGmail.TabIndex = 10;
            this.imLSGmail.TabStop = false;
            // 
            // lbAdvice
            // 
            this.lbAdvice.AutoSize = true;
            this.lbAdvice.Location = new System.Drawing.Point(11, 476);
            this.lbAdvice.Name = "lbAdvice";
            this.lbAdvice.Size = new System.Drawing.Size(452, 13);
            this.lbAdvice.TabIndex = 14;
            this.lbAdvice.Text = "*Si se quiere utilizar diferentes tipos de letra se debe seleccionar el texto que" +
    " se desea cambiar";
            // 
            // frmRedactar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 498);
            this.Controls.Add(this.lbAdvice);
            this.Controls.Add(this.imLSGmail);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rtbContenido);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.tbAsunto);
            this.Controls.Add(this.tbDestinatario);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.lblContenido);
            this.Controls.Add(this.lblDestinatario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRedactar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redactar mensaje";
            this.Load += new System.EventHandler(this.frmRedactar_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox tbDestinatario;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rtbContenido;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox imLSGmail;
        private System.Windows.Forms.Label lbAdvice;
    }
}