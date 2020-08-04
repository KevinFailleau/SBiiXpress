namespace SBiiXpress
{
    /// <summary>
    /// Class de la form CleanerXpress
    /// </summary>
    partial class CleanerXpress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CleanerXpress));
            this.btn_Optimisation = new System.Windows.Forms.Button();
            this.btn_Defrag = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_Privileges = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Type = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.gb_Operation = new System.Windows.Forms.GroupBox();
            this.cB_BDD = new System.Windows.Forms.CheckBox();
            this.cB_veille = new System.Windows.Forms.CheckBox();
            this.pb_Traitement = new System.Windows.Forms.ProgressBar();
            this.lb_Progression = new System.Windows.Forms.Label();
            this.lb_PourcentProg = new System.Windows.Forms.Label();
            this.btn_Options = new System.Windows.Forms.Button();
            this.gB_OptionsInfos = new System.Windows.Forms.GroupBox();
            this.cB_Restauration = new System.Windows.Forms.CheckBox();
            this.btn_Journal = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lb_Avertissement = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.gb_Operation.SuspendLayout();
            this.gB_OptionsInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Optimisation
            // 
            this.btn_Optimisation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Optimisation.Location = new System.Drawing.Point(83, 51);
            this.btn_Optimisation.Name = "btn_Optimisation";
            this.btn_Optimisation.Size = new System.Drawing.Size(95, 45);
            this.btn_Optimisation.TabIndex = 0;
            this.btn_Optimisation.Text = "Optimisation et nettoyage";
            this.btn_Optimisation.UseVisualStyleBackColor = true;
            this.btn_Optimisation.Click += new System.EventHandler(this.btn_NettoyageDisque_Click);
            // 
            // btn_Defrag
            // 
            this.btn_Defrag.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Defrag.Location = new System.Drawing.Point(209, 51);
            this.btn_Defrag.Name = "btn_Defrag";
            this.btn_Defrag.Size = new System.Drawing.Size(95, 45);
            this.btn_Defrag.TabIndex = 1;
            this.btn_Defrag.Text = "Défragmenter le disque";
            this.btn_Defrag.UseVisualStyleBackColor = true;
            this.btn_Defrag.Click += new System.EventHandler(this.btn_Defrag_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_Privileges,
            this.lb_Type});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_Privileges
            // 
            this.lb_Privileges.Name = "lb_Privileges";
            this.lb_Privileges.Size = new System.Drawing.Size(44, 17);
            this.lb_Privileges.Text = "Mode :";
            // 
            // lb_Type
            // 
            this.lb_Type.Name = "lb_Type";
            this.lb_Type.Size = new System.Drawing.Size(0, 17);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // gb_Operation
            // 
            this.gb_Operation.Controls.Add(this.cB_BDD);
            this.gb_Operation.Controls.Add(this.btn_Defrag);
            this.gb_Operation.Controls.Add(this.btn_Optimisation);
            this.gb_Operation.Location = new System.Drawing.Point(27, 246);
            this.gb_Operation.Name = "gb_Operation";
            this.gb_Operation.Size = new System.Drawing.Size(384, 148);
            this.gb_Operation.TabIndex = 3;
            this.gb_Operation.TabStop = false;
            this.gb_Operation.Text = "Opérations";
            // 
            // cB_BDD
            // 
            this.cB_BDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_BDD.AutoSize = true;
            this.cB_BDD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cB_BDD.Location = new System.Drawing.Point(194, 12);
            this.cB_BDD.Name = "cB_BDD";
            this.cB_BDD.Size = new System.Drawing.Size(184, 17);
            this.cB_BDD.TabIndex = 9;
            this.cB_BDD.Text = "Ecriture dans la base de données";
            this.cB_BDD.UseVisualStyleBackColor = true;
            this.cB_BDD.Visible = false;
            // 
            // cB_veille
            // 
            this.cB_veille.AutoSize = true;
            this.cB_veille.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cB_veille.Location = new System.Drawing.Point(114, 102);
            this.cB_veille.Name = "cB_veille";
            this.cB_veille.Size = new System.Drawing.Size(140, 17);
            this.cB_veille.TabIndex = 2;
            this.cB_veille.Text = "Mise en veille prolongée";
            this.cB_veille.UseVisualStyleBackColor = true;
            this.cB_veille.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cB_veille_MouseClick);
            // 
            // pb_Traitement
            // 
            this.pb_Traitement.Location = new System.Drawing.Point(561, 195);
            this.pb_Traitement.Name = "pb_Traitement";
            this.pb_Traitement.Size = new System.Drawing.Size(106, 23);
            this.pb_Traitement.TabIndex = 4;
            // 
            // lb_Progression
            // 
            this.lb_Progression.AutoSize = true;
            this.lb_Progression.Location = new System.Drawing.Point(558, 179);
            this.lb_Progression.Name = "lb_Progression";
            this.lb_Progression.Size = new System.Drawing.Size(68, 13);
            this.lb_Progression.TabIndex = 5;
            this.lb_Progression.Text = "Progression :";
            // 
            // lb_PourcentProg
            // 
            this.lb_PourcentProg.AutoSize = true;
            this.lb_PourcentProg.Location = new System.Drawing.Point(628, 179);
            this.lb_PourcentProg.Name = "lb_PourcentProg";
            this.lb_PourcentProg.Size = new System.Drawing.Size(21, 13);
            this.lb_PourcentProg.TabIndex = 6;
            this.lb_PourcentProg.Text = "0%";
            // 
            // btn_Options
            // 
            this.btn_Options.Location = new System.Drawing.Point(26, 62);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(75, 23);
            this.btn_Options.TabIndex = 7;
            this.btn_Options.Text = "Options";
            this.btn_Options.UseVisualStyleBackColor = true;
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            // 
            // gB_OptionsInfos
            // 
            this.gB_OptionsInfos.Controls.Add(this.cB_Restauration);
            this.gB_OptionsInfos.Controls.Add(this.cB_veille);
            this.gB_OptionsInfos.Controls.Add(this.btn_Journal);
            this.gB_OptionsInfos.Controls.Add(this.btn_Options);
            this.gB_OptionsInfos.Location = new System.Drawing.Point(417, 246);
            this.gB_OptionsInfos.Name = "gB_OptionsInfos";
            this.gB_OptionsInfos.Size = new System.Drawing.Size(260, 148);
            this.gB_OptionsInfos.TabIndex = 8;
            this.gB_OptionsInfos.TabStop = false;
            this.gB_OptionsInfos.Text = "Options et informations";
            // 
            // cB_Restauration
            // 
            this.cB_Restauration.AutoSize = true;
            this.cB_Restauration.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cB_Restauration.Location = new System.Drawing.Point(67, 125);
            this.cB_Restauration.Name = "cB_Restauration";
            this.cB_Restauration.Size = new System.Drawing.Size(187, 17);
            this.cB_Restauration.TabIndex = 10;
            this.cB_Restauration.Text = "Désactiver la restauration système";
            this.cB_Restauration.UseVisualStyleBackColor = true;
            this.cB_Restauration.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cB_Restauration_MouseClick);
            // 
            // btn_Journal
            // 
            this.btn_Journal.Location = new System.Drawing.Point(157, 62);
            this.btn_Journal.Name = "btn_Journal";
            this.btn_Journal.Size = new System.Drawing.Size(75, 23);
            this.btn_Journal.TabIndex = 9;
            this.btn_Journal.Text = "Journal";
            this.btn_Journal.UseVisualStyleBackColor = true;
            this.btn_Journal.Click += new System.EventHandler(this.btn_Journal_Click);
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(150, 12);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(381, 206);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 9;
            this.pb_logo.TabStop = false;
            // 
            // lb_Avertissement
            // 
            this.lb_Avertissement.AutoSize = true;
            this.lb_Avertissement.Location = new System.Drawing.Point(93, 227);
            this.lb_Avertissement.Name = "lb_Avertissement";
            this.lb_Avertissement.Size = new System.Drawing.Size(471, 13);
            this.lb_Avertissement.TabIndex = 10;
            this.lb_Avertissement.Text = "Le traitement est en cours, il est possible que l\'application devienne inactive p" +
    "endant ce processus";
            this.lb_Avertissement.Visible = false;
            // 
            // CleanerXpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 432);
            this.Controls.Add(this.lb_Avertissement);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.gB_OptionsInfos);
            this.Controls.Add(this.lb_PourcentProg);
            this.Controls.Add(this.lb_Progression);
            this.Controls.Add(this.pb_Traitement);
            this.Controls.Add(this.gb_Operation);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 459);
            this.Name = "CleanerXpress";
            this.Text = "CleanerXpress";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Depannage_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gb_Operation.ResumeLayout(false);
            this.gb_Operation.PerformLayout();
            this.gB_OptionsInfos.ResumeLayout(false);
            this.gB_OptionsInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Optimisation;
        private System.Windows.Forms.Button btn_Defrag;
        /// <summary>
        /// lb_Type est le label qui indique le mode d'exécution de l'application (mode complet ou restreint)
        /// </summary>
        public System.Windows.Forms.ToolStripStatusLabel lb_Type;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.GroupBox gb_Operation;
        private System.Windows.Forms.ProgressBar pb_Traitement;
        private System.Windows.Forms.Label lb_Progression;
        private System.Windows.Forms.Label lb_PourcentProg;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.CheckBox cB_veille;
        private System.Windows.Forms.GroupBox gB_OptionsInfos;
        private System.Windows.Forms.Button btn_Journal;
        private System.Windows.Forms.CheckBox cB_Restauration;
        private System.Windows.Forms.CheckBox cB_BDD;
        /// <summary>
        /// lb_Privilege est le label qui indique "Mode :" sur la form CleanerXpress
        /// Elle est désactivée dans certaines conditions
        /// </summary>
        public System.Windows.Forms.ToolStripStatusLabel lb_Privileges;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label lb_Avertissement;
    }
}