namespace Whatsapp
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnopenfile = new System.Windows.Forms.Button();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.dg = new System.Windows.Forms.DataGridView();
            this.btnexport = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btn_SendMedia = new System.Windows.Forms.Button();
            this.chkVideo = new System.Windows.Forms.CheckBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.txtDocuments = new System.Windows.Forms.TextBox();
            this.chkDocuments = new System.Windows.Forms.CheckBox();
            this.btn_SendDocuments = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.creditos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnopenfile
            // 
            this.btnopenfile.Location = new System.Drawing.Point(140, 9);
            this.btnopenfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnopenfile.Name = "btnopenfile";
            this.btnopenfile.Size = new System.Drawing.Size(82, 67);
            this.btnopenfile.TabIndex = 0;
            this.btnopenfile.Text = "ABRIR";
            this.btnopenfile.UseVisualStyleBackColor = true;
            this.btnopenfile.Click += new System.EventHandler(this.btnopenfile_Click);
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(9, 9);
            this.txtfilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtfilename.Multiline = true;
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.ReadOnly = true;
            this.txtfilename.Size = new System.Drawing.Size(127, 67);
            this.txtfilename.TabIndex = 1;
            this.txtfilename.TextChanged += new System.EventHandler(this.txtfilename_TextChanged);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToOrderColumns = true;
            this.dg.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg.Location = new System.Drawing.Point(9, 208);
            this.dg.Margin = new System.Windows.Forms.Padding(2);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.RowTemplate.Height = 24;
            this.dg.Size = new System.Drawing.Size(387, 327);
            this.dg.TabIndex = 2;
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(9, 152);
            this.btnexport.Margin = new System.Windows.Forms.Padding(2);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(385, 43);
            this.btnexport.TabIndex = 3;
            this.btnexport.Text = "EXPORTAR RESULTADOS";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(312, 9);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 67);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Pause-icon.png");
            this.imageList1.Images.SetKeyName(1, "Play-icon.png");
            this.imageList1.Images.SetKeyName(2, "Stop-icon.png");
            // 
            // btnEnviar
            // 
            this.btnEnviar.ImageList = this.imageList1;
            this.btnEnviar.Location = new System.Drawing.Point(226, 9);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(82, 67);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btn_SendMedia
            // 
            this.btn_SendMedia.Location = new System.Drawing.Point(309, 83);
            this.btn_SendMedia.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SendMedia.Name = "btn_SendMedia";
            this.btn_SendMedia.Size = new System.Drawing.Size(84, 24);
            this.btn_SendMedia.TabIndex = 6;
            this.btn_SendMedia.Text = "ABRIR";
            this.btn_SendMedia.UseVisualStyleBackColor = true;
            this.btn_SendMedia.Click += new System.EventHandler(this.Btn_SendMedia_Click);
            // 
            // chkVideo
            // 
            this.chkVideo.AutoSize = true;
            this.chkVideo.Location = new System.Drawing.Point(13, 86);
            this.chkVideo.Name = "chkVideo";
            this.chkVideo.Size = new System.Drawing.Size(121, 17);
            this.chkVideo.TabIndex = 7;
            this.chkVideo.Text = "Incluir Fotos/Video?";
            this.chkVideo.UseVisualStyleBackColor = true;
            this.chkVideo.CheckedChanged += new System.EventHandler(this.ChkVideo_CheckedChanged);
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(139, 83);
            this.txtMedia.Margin = new System.Windows.Forms.Padding(2);
            this.txtMedia.Multiline = true;
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.ReadOnly = true;
            this.txtMedia.Size = new System.Drawing.Size(163, 22);
            this.txtMedia.TabIndex = 8;
            // 
            // txtDocuments
            // 
            this.txtDocuments.Location = new System.Drawing.Point(139, 111);
            this.txtDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocuments.Multiline = true;
            this.txtDocuments.Name = "txtDocuments";
            this.txtDocuments.ReadOnly = true;
            this.txtDocuments.Size = new System.Drawing.Size(163, 22);
            this.txtDocuments.TabIndex = 11;
            // 
            // chkDocuments
            // 
            this.chkDocuments.AutoSize = true;
            this.chkDocuments.Location = new System.Drawing.Point(13, 114);
            this.chkDocuments.Name = "chkDocuments";
            this.chkDocuments.Size = new System.Drawing.Size(123, 17);
            this.chkDocuments.TabIndex = 10;
            this.chkDocuments.Text = "Incluir Documentos?";
            this.chkDocuments.UseVisualStyleBackColor = true;
            this.chkDocuments.CheckedChanged += new System.EventHandler(this.ChkDocuments_CheckedChanged);
            // 
            // btn_SendDocuments
            // 
            this.btn_SendDocuments.Location = new System.Drawing.Point(309, 111);
            this.btn_SendDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SendDocuments.Name = "btn_SendDocuments";
            this.btn_SendDocuments.Size = new System.Drawing.Size(84, 24);
            this.btn_SendDocuments.TabIndex = 9;
            this.btn_SendDocuments.Text = "ABRIR";
            this.btn_SendDocuments.UseVisualStyleBackColor = true;
            this.btn_SendDocuments.Click += new System.EventHandler(this.Btn_SendDocuments_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sobreToolStripMenuItem.Text = "sobre";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // creditos
            // 
            this.creditos.AutoSize = true;
            this.creditos.Location = new System.Drawing.Point(24, 579);
            this.creditos.Name = "creditos";
            this.creditos.Size = new System.Drawing.Size(468, 13);
            this.creditos.TabIndex = 13;
            this.creditos.Text = "Desenvolvido por www.marcossenna.tk LICENCIADO PARA USO EXCLUSIVO KLEFFMANN BR";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 593);
            this.Controls.Add(this.creditos);
            this.Controls.Add(this.txtDocuments);
            this.Controls.Add(this.chkDocuments);
            this.Controls.Add(this.btn_SendDocuments);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.chkVideo);
            this.Controls.Add(this.btn_SendMedia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.btnopenfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatsApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnopenfile;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_SendMedia;
        private System.Windows.Forms.CheckBox chkVideo;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.TextBox txtDocuments;
        private System.Windows.Forms.CheckBox chkDocuments;
        private System.Windows.Forms.Button btn_SendDocuments;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label creditos;
    }
}

