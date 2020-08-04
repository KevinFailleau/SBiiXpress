namespace SBiiXpress
{
    partial class Securite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Securite));
            this.btn_Analyse = new System.Windows.Forms.Button();
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_FermerPort = new System.Windows.Forms.Button();
            this.btn_Rafraichir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Analyse
            // 
            this.btn_Analyse.Location = new System.Drawing.Point(136, 387);
            this.btn_Analyse.Name = "btn_Analyse";
            this.btn_Analyse.Size = new System.Drawing.Size(98, 41);
            this.btn_Analyse.TabIndex = 1;
            this.btn_Analyse.Text = "Lancer l\'analyse";
            this.btn_Analyse.UseVisualStyleBackColor = true;
            this.btn_Analyse.Click += new System.EventHandler(this.btn_Analyse_Click);
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Fermer.Location = new System.Drawing.Point(529, 387);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(98, 41);
            this.btn_Fermer.TabIndex = 2;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            this.btn_Fermer.Click += new System.EventHandler(this.btn_Fermer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckBox,
            this.ColumnProcessName,
            this.ColumnNumPort,
            this.ColumnInfo});
            this.dataGridView1.Location = new System.Drawing.Point(42, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(673, 272);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.HeaderText = "";
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            this.ColumnCheckBox.ReadOnly = true;
            this.ColumnCheckBox.Width = 30;
            // 
            // ColumnProcessName
            // 
            this.ColumnProcessName.HeaderText = "Nom du processus";
            this.ColumnProcessName.Name = "ColumnProcessName";
            this.ColumnProcessName.ReadOnly = true;
            this.ColumnProcessName.Width = 200;
            // 
            // ColumnNumPort
            // 
            this.ColumnNumPort.HeaderText = "Numéro du port";
            this.ColumnNumPort.Name = "ColumnNumPort";
            this.ColumnNumPort.ReadOnly = true;
            this.ColumnNumPort.Width = 150;
            // 
            // ColumnInfo
            // 
            this.ColumnInfo.HeaderText = "Informations";
            this.ColumnInfo.Name = "ColumnInfo";
            this.ColumnInfo.ReadOnly = true;
            this.ColumnInfo.Width = 290;
            // 
            // btn_FermerPort
            // 
            this.btn_FermerPort.Location = new System.Drawing.Point(267, 387);
            this.btn_FermerPort.Name = "btn_FermerPort";
            this.btn_FermerPort.Size = new System.Drawing.Size(98, 41);
            this.btn_FermerPort.TabIndex = 4;
            this.btn_FermerPort.Text = "Fermer les ports sélectionnés";
            this.btn_FermerPort.UseVisualStyleBackColor = true;
            this.btn_FermerPort.Click += new System.EventHandler(this.btn_FermerPort_Click);
            // 
            // btn_Rafraichir
            // 
            this.btn_Rafraichir.Location = new System.Drawing.Point(398, 387);
            this.btn_Rafraichir.Name = "btn_Rafraichir";
            this.btn_Rafraichir.Size = new System.Drawing.Size(98, 41);
            this.btn_Rafraichir.TabIndex = 5;
            this.btn_Rafraichir.Text = "Rafrîchir la liste";
            this.btn_Rafraichir.UseVisualStyleBackColor = true;
            this.btn_Rafraichir.Click += new System.EventHandler(this.btn_Rafraichir_Click);
            // 
            // Securite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 485);
            this.Controls.Add(this.btn_Rafraichir);
            this.Controls.Add(this.btn_FermerPort);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Fermer);
            this.Controls.Add(this.btn_Analyse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Securite";
            this.Text = "Sécurité";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Analyse;
        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInfo;
        private System.Windows.Forms.Button btn_FermerPort;
        private System.Windows.Forms.Button btn_Rafraichir;
    }
}