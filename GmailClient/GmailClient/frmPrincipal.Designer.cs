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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLeerMensajes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResponder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResponderRemitente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResponderAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarcarSpam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarcarLeido = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarcarNoLeido = new System.Windows.Forms.ToolStripMenuItem();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnRedactar = new System.Windows.Forms.Button();
            this.imLSGmail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgbProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInterfaz = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCambiarFondo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColorFondo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImagenFondo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiarFondo = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcBandejas = new System.Windows.Forms.TabControl();
            this.tbpBandejaEntrada = new System.Windows.Forms.TabPage();
            this.lvMensajes = new System.Windows.Forms.ListView();
            this.clmRemitente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAsunto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPreview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUnseen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpSpam = new System.Windows.Forms.TabPage();
            this.lvSpam = new System.Windows.Forms.ListView();
            this.clmRemitenteSpam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAsuntoSpam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmContenidoSpam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUnseenSpam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpEnviados = new System.Windows.Forms.TabPage();
            this.lvCorreosEnviados = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgwMessages = new System.ComponentModel.BackgroundWorker();
            this.cbNumMensajes = new System.Windows.Forms.ComboBox();
            this.lbNumMensajes = new System.Windows.Forms.Label();
            this.clmIdMessageSpam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tbcBandejas.SuspendLayout();
            this.tbpBandejaEntrada.SuspendLayout();
            this.tbpSpam.SuspendLayout();
            this.tbpEnviados.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLeerMensajes,
            this.tsmiResponder,
            this.tsmiEliminar,
            this.tsmiMarcarSpam,
            this.tsmiMarcarLeido,
            this.tsmiMarcarNoLeido});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 158);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnLeerMensajes
            // 
            this.btnLeerMensajes.Name = "btnLeerMensajes";
            this.btnLeerMensajes.Size = new System.Drawing.Size(191, 22);
            this.btnLeerMensajes.Text = "Leer mensaje(s)";
            this.btnLeerMensajes.Click += new System.EventHandler(this.btnLeerMensajes_Click);
            // 
            // tsmiResponder
            // 
            this.tsmiResponder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResponderRemitente,
            this.tsmiResponderAll});
            this.tsmiResponder.Name = "tsmiResponder";
            this.tsmiResponder.Size = new System.Drawing.Size(191, 22);
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
            this.tsmiEliminar.Size = new System.Drawing.Size(191, 22);
            this.tsmiEliminar.Text = "Eliminar";
            this.tsmiEliminar.Click += new System.EventHandler(this.tsmiEliminar_Click);
            // 
            // tsmiMarcarSpam
            // 
            this.tsmiMarcarSpam.Name = "tsmiMarcarSpam";
            this.tsmiMarcarSpam.Size = new System.Drawing.Size(191, 22);
            this.tsmiMarcarSpam.Text = "Marcar como spam";
            // 
            // tsmiMarcarLeido
            // 
            this.tsmiMarcarLeido.Name = "tsmiMarcarLeido";
            this.tsmiMarcarLeido.Size = new System.Drawing.Size(191, 22);
            this.tsmiMarcarLeido.Text = "Marcar como leído";
            this.tsmiMarcarLeido.Click += new System.EventHandler(this.tsmiMarcarLeido_Click);
            // 
            // tsmiMarcarNoLeido
            // 
            this.tsmiMarcarNoLeido.Name = "tsmiMarcarNoLeido";
            this.tsmiMarcarNoLeido.Size = new System.Drawing.Size(191, 22);
            this.tsmiMarcarNoLeido.Text = "Marcar como no leído";
            this.tsmiMarcarNoLeido.Click += new System.EventHandler(this.tsmiMarcarNoLeido_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(193, 36);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(43, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnRedactar
            // 
            this.btnRedactar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRedactar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedactar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRedactar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnRedactar.Location = new System.Drawing.Point(242, 36);
            this.btnRedactar.Name = "btnRedactar";
            this.btnRedactar.Size = new System.Drawing.Size(95, 41);
            this.btnRedactar.TabIndex = 6;
            this.btnRedactar.Text = "Redactar Correo";
            this.btnRedactar.UseVisualStyleBackColor = false;
            this.btnRedactar.Click += new System.EventHandler(this.btnRedactar_Click);
            // 
            // imLSGmail
            // 
            this.imLSGmail.Image = ((System.Drawing.Image)(resources.GetObject("imLSGmail.Image")));
            this.imLSGmail.Location = new System.Drawing.Point(6, 33);
            this.imLSGmail.Name = "imLSGmail";
            this.imLSGmail.Size = new System.Drawing.Size(155, 50);
            this.imLSGmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imLSGmail.TabIndex = 7;
            this.imLSGmail.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(576, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(146, 35);
            this.tableLayoutPanel1.TabIndex = 10;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbProgreso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgbProgreso
            // 
            this.pgbProgreso.Name = "pgbProgreso";
            this.pgbProgreso.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.tsmiUser,
            this.tsmiInterfaz});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // tsmiUser
            // 
            this.tsmiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCerrarSesion});
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(59, 20);
            this.tsmiUser.Text = "Usuario";
            // 
            // tsmiCerrarSesion
            // 
            this.tsmiCerrarSesion.Name = "tsmiCerrarSesion";
            this.tsmiCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.tsmiCerrarSesion.Text = "Cerrar Sesión";
            this.tsmiCerrarSesion.Click += new System.EventHandler(this.tsmiCerrarSesion_Click);
            // 
            // tsmiInterfaz
            // 
            this.tsmiInterfaz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCambiarFondo});
            this.tsmiInterfaz.Name = "tsmiInterfaz";
            this.tsmiInterfaz.Size = new System.Drawing.Size(58, 20);
            this.tsmiInterfaz.Text = "Interfaz";
            // 
            // tsmiCambiarFondo
            // 
            this.tsmiCambiarFondo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiColorFondo,
            this.tsmiImagenFondo,
            this.tsmiLimpiarFondo});
            this.tsmiCambiarFondo.Name = "tsmiCambiarFondo";
            this.tsmiCambiarFondo.Size = new System.Drawing.Size(156, 22);
            this.tsmiCambiarFondo.Text = "Cambiar Fondo";
            this.tsmiCambiarFondo.Click += new System.EventHandler(this.tsmiCambiarFondo_Click);
            // 
            // tsmiColorFondo
            // 
            this.tsmiColorFondo.Name = "tsmiColorFondo";
            this.tsmiColorFondo.Size = new System.Drawing.Size(235, 22);
            this.tsmiColorFondo.Text = "Cambiar Color Fondo";
            this.tsmiColorFondo.Click += new System.EventHandler(this.tsmiColorFondo_Click);
            // 
            // tsmiImagenFondo
            // 
            this.tsmiImagenFondo.Name = "tsmiImagenFondo";
            this.tsmiImagenFondo.Size = new System.Drawing.Size(235, 22);
            this.tsmiImagenFondo.Text = "Introducir Imagen Fondo";
            // 
            // tsmiLimpiarFondo
            // 
            this.tsmiLimpiarFondo.Name = "tsmiLimpiarFondo";
            this.tsmiLimpiarFondo.Size = new System.Drawing.Size(235, 22);
            this.tsmiLimpiarFondo.Text = "Restablecer Fondo por defecto";
            this.tsmiLimpiarFondo.Click += new System.EventHandler(this.tsmiLimpiarFondo_Click);
            // 
            // tbcBandejas
            // 
            this.tbcBandejas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcBandejas.Controls.Add(this.tbpBandejaEntrada);
            this.tbcBandejas.Controls.Add(this.tbpSpam);
            this.tbcBandejas.Controls.Add(this.tbpEnviados);
            this.tbcBandejas.Location = new System.Drawing.Point(0, 89);
            this.tbcBandejas.Name = "tbcBandejas";
            this.tbcBandejas.SelectedIndex = 0;
            this.tbcBandejas.Size = new System.Drawing.Size(734, 384);
            this.tbcBandejas.TabIndex = 13;
            // 
            // tbpBandejaEntrada
            // 
            this.tbpBandejaEntrada.Controls.Add(this.lvMensajes);
            this.tbpBandejaEntrada.Location = new System.Drawing.Point(4, 22);
            this.tbpBandejaEntrada.Name = "tbpBandejaEntrada";
            this.tbpBandejaEntrada.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBandejaEntrada.Size = new System.Drawing.Size(726, 358);
            this.tbpBandejaEntrada.TabIndex = 0;
            this.tbpBandejaEntrada.Text = "Bandeja de entrada";
            this.tbpBandejaEntrada.UseVisualStyleBackColor = true;
            this.tbpBandejaEntrada.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lvMensajes
            // 
            this.lvMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMensajes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvMensajes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRemitente,
            this.clmAsunto,
            this.clmPreview,
            this.clmUnseen,
            this.clmId});
            this.lvMensajes.ContextMenuStrip = this.contextMenuStrip1;
            this.lvMensajes.FullRowSelect = true;
            this.lvMensajes.GridLines = true;
            this.lvMensajes.Location = new System.Drawing.Point(0, 0);
            this.lvMensajes.Name = "lvMensajes";
            this.lvMensajes.Size = new System.Drawing.Size(726, 358);
            this.lvMensajes.TabIndex = 2;
            this.lvMensajes.UseCompatibleStateImageBehavior = false;
            this.lvMensajes.View = System.Windows.Forms.View.Details;
            this.lvMensajes.DoubleClick += new System.EventHandler(this.lvMensajes_DoubleClick);
            // 
            // clmRemitente
            // 
            this.clmRemitente.Text = "Remitente";
            this.clmRemitente.Width = 154;
            // 
            // clmAsunto
            // 
            this.clmAsunto.Text = "Asunto";
            this.clmAsunto.Width = 168;
            // 
            // clmPreview
            // 
            this.clmPreview.Text = "Contenido";
            this.clmPreview.Width = 340;
            // 
            // clmUnseen
            // 
            this.clmUnseen.Text = "Unseen";
            // 
            // tbpSpam
            // 
            this.tbpSpam.Controls.Add(this.lvSpam);
            this.tbpSpam.Location = new System.Drawing.Point(4, 22);
            this.tbpSpam.Name = "tbpSpam";
            this.tbpSpam.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSpam.Size = new System.Drawing.Size(726, 358);
            this.tbpSpam.TabIndex = 1;
            this.tbpSpam.Text = "Spam";
            this.tbpSpam.UseVisualStyleBackColor = true;
            // 
            // lvSpam
            // 
            this.lvSpam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSpam.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvSpam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRemitenteSpam,
            this.clmAsuntoSpam,
            this.clmContenidoSpam,
            this.clmUnseenSpam,
            this.clmIdMessageSpam});
            this.lvSpam.ContextMenuStrip = this.contextMenuStrip1;
            this.lvSpam.FullRowSelect = true;
            this.lvSpam.GridLines = true;
            this.lvSpam.Location = new System.Drawing.Point(0, 3);
            this.lvSpam.Name = "lvSpam";
            this.lvSpam.Size = new System.Drawing.Size(726, 353);
            this.lvSpam.TabIndex = 3;
            this.lvSpam.UseCompatibleStateImageBehavior = false;
            this.lvSpam.View = System.Windows.Forms.View.Details;
            // 
            // clmRemitenteSpam
            // 
            this.clmRemitenteSpam.Text = "Remitente";
            this.clmRemitenteSpam.Width = 154;
            // 
            // clmAsuntoSpam
            // 
            this.clmAsuntoSpam.Text = "Asunto";
            this.clmAsuntoSpam.Width = 168;
            // 
            // clmContenidoSpam
            // 
            this.clmContenidoSpam.Text = "Contenido";
            this.clmContenidoSpam.Width = 340;
            // 
            // clmUnseenSpam
            // 
            this.clmUnseenSpam.Text = "Unseen";
            // 
            // tbpEnviados
            // 
            this.tbpEnviados.Controls.Add(this.lvCorreosEnviados);
            this.tbpEnviados.Location = new System.Drawing.Point(4, 22);
            this.tbpEnviados.Name = "tbpEnviados";
            this.tbpEnviados.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEnviados.Size = new System.Drawing.Size(726, 358);
            this.tbpEnviados.TabIndex = 2;
            this.tbpEnviados.Text = "Correos enviados";
            this.tbpEnviados.UseVisualStyleBackColor = true;
            // 
            // lvCorreosEnviados
            // 
            this.lvCorreosEnviados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCorreosEnviados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvCorreosEnviados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader1});
            this.lvCorreosEnviados.ContextMenuStrip = this.contextMenuStrip1;
            this.lvCorreosEnviados.FullRowSelect = true;
            this.lvCorreosEnviados.GridLines = true;
            this.lvCorreosEnviados.Location = new System.Drawing.Point(0, 3);
            this.lvCorreosEnviados.Name = "lvCorreosEnviados";
            this.lvCorreosEnviados.Size = new System.Drawing.Size(726, 353);
            this.lvCorreosEnviados.TabIndex = 3;
            this.lvCorreosEnviados.UseCompatibleStateImageBehavior = false;
            this.lvCorreosEnviados.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Remitente";
            this.columnHeader6.Width = 154;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Asunto";
            this.columnHeader7.Width = 168;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Contenido";
            this.columnHeader8.Width = 340;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Unseen";
            // 
            // bgwMessages
            // 
            this.bgwMessages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMessages_DoWork);
            this.bgwMessages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwMessages_ProgressChanged);
            this.bgwMessages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMessages_RunWorkerCompleted);
            // 
            // cbNumMensajes
            // 
            this.cbNumMensajes.FormattingEnabled = true;
            this.cbNumMensajes.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.cbNumMensajes.Location = new System.Drawing.Point(658, 74);
            this.cbNumMensajes.Name = "cbNumMensajes";
            this.cbNumMensajes.Size = new System.Drawing.Size(64, 21);
            this.cbNumMensajes.TabIndex = 14;
            this.cbNumMensajes.SelectedIndexChanged += new System.EventHandler(this.cbNumMensajes_SelectedIndexChanged);
            // 
            // lbNumMensajes
            // 
            this.lbNumMensajes.AutoSize = true;
            this.lbNumMensajes.Location = new System.Drawing.Point(501, 77);
            this.lbNumMensajes.Name = "lbNumMensajes";
            this.lbNumMensajes.Size = new System.Drawing.Size(151, 13);
            this.lbNumMensajes.TabIndex = 15;
            this.lbNumMensajes.Text = "Numero de mensajes a cargar:";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(734, 498);
            this.Controls.Add(this.lbNumMensajes);
            this.Controls.Add(this.cbNumMensajes);
            this.Controls.Add(this.tbcBandejas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.imLSGmail);
            this.Controls.Add(this.btnRedactar);
            this.Controls.Add(this.btnActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GmailClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.frmPrincipal_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imLSGmail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcBandejas.ResumeLayout(false);
            this.tbpBandejaEntrada.ResumeLayout(false);
            this.tbpSpam.ResumeLayout(false);
            this.tbpEnviados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnRedactar;
        private System.Windows.Forms.PictureBox imLSGmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponder;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponderRemitente;
        private System.Windows.Forms.ToolStripMenuItem tsmiResponderAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarcarSpam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgbProgreso;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcBandejas;
        private System.Windows.Forms.TabPage tbpBandejaEntrada;
        private System.Windows.Forms.TabPage tbpSpam;
        private System.Windows.Forms.ListView lvMensajes;
        private System.Windows.Forms.ColumnHeader clmRemitente;
        private System.Windows.Forms.ColumnHeader clmAsunto;
        private System.Windows.Forms.ColumnHeader clmPreview;
        private System.Windows.Forms.TabPage tbpEnviados;
        private System.ComponentModel.BackgroundWorker bgwMessages;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarcarLeido;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarcarNoLeido;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiInterfaz;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarFondo;
        private System.Windows.Forms.ToolStripMenuItem tsmiColorFondo;
        private System.Windows.Forms.ToolStripMenuItem tsmiImagenFondo;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiarFondo;
        private System.Windows.Forms.ColumnHeader clmUnseen;
        private System.Windows.Forms.ToolStripMenuItem btnLeerMensajes;
        private System.Windows.Forms.ListView lvSpam;
        private System.Windows.Forms.ColumnHeader clmRemitenteSpam;
        private System.Windows.Forms.ColumnHeader clmAsuntoSpam;
        private System.Windows.Forms.ColumnHeader clmContenidoSpam;
        private System.Windows.Forms.ColumnHeader clmUnseenSpam;
        private System.Windows.Forms.ListView lvCorreosEnviados;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox cbNumMensajes;
        private System.Windows.Forms.Label lbNumMensajes;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmIdMessageSpam;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

