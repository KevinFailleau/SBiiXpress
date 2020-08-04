using System.Windows.Forms;

namespace SBiiXpress
{
    partial class Options
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.gB_Options = new System.Windows.Forms.GroupBox();
            this.cB_Telechargement = new System.Windows.Forms.CheckBox();
            this.cB_Superfetch = new System.Windows.Forms.CheckBox();
            this.cB_DLL = new System.Windows.Forms.CheckBox();
            this.cB_WinUp = new System.Windows.Forms.CheckBox();
            this.cB_Cleanmgr = new System.Windows.Forms.CheckBox();
            this.cB_CCleaner = new System.Windows.Forms.CheckBox();
            this.cB_CleanIE = new System.Windows.Forms.CheckBox();
            this.cB_SaveReg = new System.Windows.Forms.CheckBox();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.btn_Annuler = new System.Windows.Forms.Button();
            this.btn_Cocher = new System.Windows.Forms.Button();
            this.btn_Decoche = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_Superfetch = new System.Windows.Forms.ToolStripStatusLabel();
            this.gB_Options.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_Options
            // 
            this.gB_Options.Controls.Add(this.cB_Telechargement);
            this.gB_Options.Controls.Add(this.cB_Superfetch);
            this.gB_Options.Controls.Add(this.cB_DLL);
            this.gB_Options.Controls.Add(this.cB_WinUp);
            this.gB_Options.Controls.Add(this.cB_Cleanmgr);
            this.gB_Options.Controls.Add(this.cB_CCleaner);
            this.gB_Options.Controls.Add(this.cB_CleanIE);
            this.gB_Options.Controls.Add(this.cB_SaveReg);
            this.gB_Options.Location = new System.Drawing.Point(37, 27);
            this.gB_Options.Name = "gB_Options";
            this.gB_Options.Size = new System.Drawing.Size(402, 220);
            this.gB_Options.TabIndex = 0;
            this.gB_Options.TabStop = false;
            this.gB_Options.Text = "Nettoyage et optimisation";
            // 
            // cB_Telechargement
            // 
            this.cB_Telechargement.AutoSize = true;
            this.cB_Telechargement.Checked = true;
            this.cB_Telechargement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_Telechargement.Location = new System.Drawing.Point(23, 100);
            this.cB_Telechargement.Name = "cB_Telechargement";
            this.cB_Telechargement.Size = new System.Drawing.Size(220, 17);
            this.cB_Telechargement.TabIndex = 7;
            this.cB_Telechargement.Text = "Vérification du dossier de téléchargement";
            this.cB_Telechargement.UseVisualStyleBackColor = true;
            this.cB_Telechargement.CheckedChanged += new System.EventHandler(this.cB_Telechargement_CheckedChanged);
            // 
            // cB_Superfetch
            // 
            this.cB_Superfetch.AutoSize = true;
            this.cB_Superfetch.Enabled = false;
            this.cB_Superfetch.Location = new System.Drawing.Point(23, 195);
            this.cB_Superfetch.Name = "cB_Superfetch";
            this.cB_Superfetch.Size = new System.Drawing.Size(198, 17);
            this.cB_Superfetch.TabIndex = 6;
            this.cB_Superfetch.Text = "Désactivation du service Superfetch";
            this.cB_Superfetch.UseVisualStyleBackColor = true;
            this.cB_Superfetch.CheckedChanged += new System.EventHandler(this.cB_Superfetch_CheckedChanged);
            // 
            // cB_DLL
            // 
            this.cB_DLL.AutoSize = true;
            this.cB_DLL.Enabled = false;
            this.cB_DLL.Location = new System.Drawing.Point(23, 172);
            this.cB_DLL.Name = "cB_DLL";
            this.cB_DLL.Size = new System.Drawing.Size(234, 17);
            this.cB_DLL.TabIndex = 5;
            this.cB_DLL.Text = "Décharger automatiquement les DLL inutiles";
            this.cB_DLL.UseVisualStyleBackColor = true;
            this.cB_DLL.CheckedChanged += new System.EventHandler(this.cB_DLL_CheckedChanged);
            // 
            // cB_WinUp
            // 
            this.cB_WinUp.AutoSize = true;
            this.cB_WinUp.Enabled = false;
            this.cB_WinUp.Location = new System.Drawing.Point(23, 148);
            this.cB_WinUp.Name = "cB_WinUp";
            this.cB_WinUp.Size = new System.Drawing.Size(208, 17);
            this.cB_WinUp.TabIndex = 4;
            this.cB_WinUp.Text = "Nettoyage du cache Windows Update";
            this.cB_WinUp.UseVisualStyleBackColor = true;
            this.cB_WinUp.CheckedChanged += new System.EventHandler(this.cB_WinUp_CheckedChanged);
            // 
            // cB_Cleanmgr
            // 
            this.cB_Cleanmgr.AutoSize = true;
            this.cB_Cleanmgr.Enabled = false;
            this.cB_Cleanmgr.Location = new System.Drawing.Point(23, 124);
            this.cB_Cleanmgr.Name = "cB_Cleanmgr";
            this.cB_Cleanmgr.Size = new System.Drawing.Size(205, 17);
            this.cB_Cleanmgr.TabIndex = 3;
            this.cB_Cleanmgr.Text = "Outil de nettoyage Windows (complet)";
            this.cB_Cleanmgr.UseVisualStyleBackColor = true;
            this.cB_Cleanmgr.CheckedChanged += new System.EventHandler(this.cB_Cleanmgr_CheckedChanged);
            // 
            // cB_CCleaner
            // 
            this.cB_CCleaner.AutoSize = true;
            this.cB_CCleaner.Checked = true;
            this.cB_CCleaner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_CCleaner.Location = new System.Drawing.Point(23, 77);
            this.cB_CCleaner.Name = "cB_CCleaner";
            this.cB_CCleaner.Size = new System.Drawing.Size(185, 17);
            this.cB_CCleaner.TabIndex = 2;
            this.cB_CCleaner.Text = "Exécution de CCleaner (si installé)";
            this.cB_CCleaner.UseVisualStyleBackColor = true;
            this.cB_CCleaner.CheckedChanged += new System.EventHandler(this.cB_CCleaner_CheckedChanged);
            // 
            // cB_CleanIE
            // 
            this.cB_CleanIE.AutoSize = true;
            this.cB_CleanIE.Checked = true;
            this.cB_CleanIE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_CleanIE.Location = new System.Drawing.Point(23, 53);
            this.cB_CleanIE.Name = "cB_CleanIE";
            this.cB_CleanIE.Size = new System.Drawing.Size(170, 17);
            this.cB_CleanIE.TabIndex = 1;
            this.cB_CleanIE.Text = "Nettoyage de Internet Explorer";
            this.cB_CleanIE.UseVisualStyleBackColor = true;
            this.cB_CleanIE.CheckedChanged += new System.EventHandler(this.cB_CleanIE_CheckedChanged);
            // 
            // cB_SaveReg
            // 
            this.cB_SaveReg.AutoSize = true;
            this.cB_SaveReg.Enabled = false;
            this.cB_SaveReg.Location = new System.Drawing.Point(23, 29);
            this.cB_SaveReg.Name = "cB_SaveReg";
            this.cB_SaveReg.Size = new System.Drawing.Size(136, 17);
            this.cB_SaveReg.TabIndex = 0;
            this.cB_SaveReg.Text = "Sauvegarde du registre";
            this.cB_SaveReg.UseVisualStyleBackColor = true;
            this.cB_SaveReg.CheckedChanged += new System.EventHandler(this.cB_SaveReg_CheckedChanged);
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(202, 269);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(75, 23);
            this.btn_Valider.TabIndex = 1;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Location = new System.Drawing.Point(313, 269);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuler.TabIndex = 2;
            this.btn_Annuler.Text = "Annuler";
            this.btn_Annuler.UseVisualStyleBackColor = true;
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Cocher
            // 
            this.btn_Cocher.Location = new System.Drawing.Point(445, 80);
            this.btn_Cocher.Name = "btn_Cocher";
            this.btn_Cocher.Size = new System.Drawing.Size(100, 23);
            this.btn_Cocher.TabIndex = 3;
            this.btn_Cocher.Text = "Tout cocher";
            this.btn_Cocher.UseVisualStyleBackColor = true;
            this.btn_Cocher.Click += new System.EventHandler(this.btn_Cocher_Click);
            // 
            // btn_Decoche
            // 
            this.btn_Decoche.Location = new System.Drawing.Point(445, 128);
            this.btn_Decoche.Name = "btn_Decoche";
            this.btn_Decoche.Size = new System.Drawing.Size(100, 23);
            this.btn_Decoche.TabIndex = 4;
            this.btn_Decoche.Text = "Tout décocher";
            this.btn_Decoche.UseVisualStyleBackColor = true;
            this.btn_Decoche.Click += new System.EventHandler(this.btn_Decoche_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_Superfetch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(557, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_Superfetch
            // 
            this.lb_Superfetch.Name = "lb_Superfetch";
            this.lb_Superfetch.Size = new System.Drawing.Size(64, 17);
            this.lb_Superfetch.Text = "Superfetch";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 329);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Decoche);
            this.Controls.Add(this.btn_Cocher);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.gB_Options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.gB_Options.ResumeLayout(false);
            this.gB_Options.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Options;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Button btn_Annuler;
        /// <summary>
        /// CheckBox pour la sauvegarde du registre 
        /// </summary>
        public CheckBox cB_SaveReg;
        /// <summary>
        /// CheckBox pour l'exécution de CCleaner
        /// </summary>
        public CheckBox cB_CCleaner;
        /// <summary>
        /// CheckBox pour le nettoyage de Internet Explorer
        /// </summary>
        public CheckBox cB_CleanIE;
        /// <summary>
        /// CheckBox pour le nettoyage du cache de Windows Update
        /// </summary>
        public CheckBox cB_WinUp;
        /// <summary>
        /// CheckBox pour le lancement du nettoyeur de disque Windows
        /// </summary>
        public CheckBox cB_Cleanmgr;
        /// <summary>
        /// CheckBox pour la désactivation des DLLs inutiles
        /// </summary>
        public CheckBox cB_DLL;
        /// <summary>
        /// Bouton qui permet de cocher toutes les cases qui n'ont pas été cochées
        /// </summary>
        private Button btn_Cocher;
        /// <summary>
        /// Bouton qui permet de décocher toutes les cases qui ont été cochées
        /// </summary>
        private Button btn_Decoche;
        /// <summary>
        /// CheckBox pour la désactivation du service Superfetch
        /// </summary>
        public CheckBox cB_Superfetch;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lb_Superfetch;
        private CheckBox cB_Telechargement;
    }
}