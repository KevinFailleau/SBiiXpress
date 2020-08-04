namespace SBiiXpress
{
    partial class Telechargements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telechargements));
            this.dGV_Telechargement = new System.Windows.Forms.DataGridView();
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.btn_Supprimer = new System.Windows.Forms.Button();
            this.btn_ToutSelectionner = new System.Windows.Forms.Button();
            this.btn_ToutDecocher = new System.Windows.Forms.Button();
            this.gb_Actions = new System.Windows.Forms.GroupBox();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTaille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTailleMo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTailleGo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Telechargement)).BeginInit();
            this.gb_Actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_Telechargement
            // 
            this.dGV_Telechargement.AllowUserToAddRows = false;
            this.dGV_Telechargement.AllowUserToDeleteRows = false;
            this.dGV_Telechargement.AllowUserToOrderColumns = true;
            this.dGV_Telechargement.AllowUserToResizeRows = false;
            this.dGV_Telechargement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_Telechargement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Telechargement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckBox,
            this.ColumnNom,
            this.ColumnType,
            this.ColumnTaille,
            this.ColumnTailleMo,
            this.ColumnTailleGo});
            this.dGV_Telechargement.Location = new System.Drawing.Point(32, 42);
            this.dGV_Telechargement.Name = "dGV_Telechargement";
            this.dGV_Telechargement.ReadOnly = true;
            this.dGV_Telechargement.RowHeadersVisible = false;
            this.dGV_Telechargement.Size = new System.Drawing.Size(779, 312);
            this.dGV_Telechargement.TabIndex = 0;
            this.dGV_Telechargement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Telechargement_CellClick);
            this.dGV_Telechargement.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGV_Telechargement_ColumnHeaderMouseClick);
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Fermer.Location = new System.Drawing.Point(379, 527);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(99, 23);
            this.btn_Fermer.TabIndex = 1;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            this.btn_Fermer.Click += new System.EventHandler(this.btn_Fermer_Click);
            // 
            // btn_Supprimer
            // 
            this.btn_Supprimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Supprimer.Location = new System.Drawing.Point(287, 69);
            this.btn_Supprimer.Name = "btn_Supprimer";
            this.btn_Supprimer.Size = new System.Drawing.Size(99, 23);
            this.btn_Supprimer.TabIndex = 2;
            this.btn_Supprimer.Text = "Supprimer";
            this.btn_Supprimer.UseVisualStyleBackColor = true;
            this.btn_Supprimer.Click += new System.EventHandler(this.btn_Supprimer_Click);
            // 
            // btn_ToutSelectionner
            // 
            this.btn_ToutSelectionner.Location = new System.Drawing.Point(77, 69);
            this.btn_ToutSelectionner.Name = "btn_ToutSelectionner";
            this.btn_ToutSelectionner.Size = new System.Drawing.Size(99, 23);
            this.btn_ToutSelectionner.TabIndex = 3;
            this.btn_ToutSelectionner.Text = "Tout cocher";
            this.btn_ToutSelectionner.UseVisualStyleBackColor = true;
            this.btn_ToutSelectionner.Click += new System.EventHandler(this.btn_ToutSelectionner_Click);
            // 
            // btn_ToutDecocher
            // 
            this.btn_ToutDecocher.Location = new System.Drawing.Point(182, 69);
            this.btn_ToutDecocher.Name = "btn_ToutDecocher";
            this.btn_ToutDecocher.Size = new System.Drawing.Size(99, 23);
            this.btn_ToutDecocher.TabIndex = 4;
            this.btn_ToutDecocher.Text = "Tout décocher";
            this.btn_ToutDecocher.UseVisualStyleBackColor = true;
            this.btn_ToutDecocher.Click += new System.EventHandler(this.btn_ToutDecocher_Click);
            // 
            // gb_Actions
            // 
            this.gb_Actions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gb_Actions.Controls.Add(this.btn_ToutSelectionner);
            this.gb_Actions.Controls.Add(this.btn_ToutDecocher);
            this.gb_Actions.Controls.Add(this.btn_Supprimer);
            this.gb_Actions.Location = new System.Drawing.Point(187, 360);
            this.gb_Actions.Name = "gb_Actions";
            this.gb_Actions.Size = new System.Drawing.Size(470, 147);
            this.gb_Actions.TabIndex = 5;
            this.gb_Actions.TabStop = false;
            this.gb_Actions.Text = "Actions";
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.HeaderText = "";
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            this.ColumnCheckBox.ReadOnly = true;
            this.ColumnCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCheckBox.Width = 30;
            // 
            // ColumnNom
            // 
            this.ColumnNom.HeaderText = "Nom";
            this.ColumnNom.Name = "ColumnNom";
            this.ColumnNom.ReadOnly = true;
            this.ColumnNom.Width = 350;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColumnTaille
            // 
            this.ColumnTaille.HeaderText = "Taille (en Ko)";
            this.ColumnTaille.Name = "ColumnTaille";
            this.ColumnTaille.ReadOnly = true;
            this.ColumnTaille.Width = 95;
            // 
            // ColumnTailleMo
            // 
            this.ColumnTailleMo.HeaderText = "Taille (en Mo)";
            this.ColumnTailleMo.Name = "ColumnTailleMo";
            this.ColumnTailleMo.ReadOnly = true;
            // 
            // ColumnTailleGo
            // 
            this.ColumnTailleGo.HeaderText = "Taille (en Go)";
            this.ColumnTailleGo.Name = "ColumnTailleGo";
            this.ColumnTailleGo.ReadOnly = true;
            // 
            // Telechargements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 562);
            this.Controls.Add(this.gb_Actions);
            this.Controls.Add(this.btn_Fermer);
            this.Controls.Add(this.dGV_Telechargement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Telechargements";
            this.Text = "Téléchargements";
            this.Load += new System.EventHandler(this.Telechargements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Telechargement)).EndInit();
            this.gb_Actions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_Telechargement;
        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.Button btn_Supprimer;
        private System.Windows.Forms.Button btn_ToutSelectionner;
        private System.Windows.Forms.Button btn_ToutDecocher;
        private System.Windows.Forms.GroupBox gb_Actions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaille;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTailleMo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTailleGo;
    }
}