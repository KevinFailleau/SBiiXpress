namespace SBiiXpress
{
    partial class Depannage
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
            this.btn_Optimisation = new System.Windows.Forms.Button();
            this.btn_Defrag = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_Privileges = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Type = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.gb_Operation = new System.Windows.Forms.GroupBox();
            this.pb_Traitement = new System.Windows.Forms.ProgressBar();
            this.lb_Progression = new System.Windows.Forms.Label();
            this.lb_PourcentProg = new System.Windows.Forms.Label();
            this.btn_Options = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.gb_Operation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Optimisation
            // 
            this.btn_Optimisation.Location = new System.Drawing.Point(65, 35);
            this.btn_Optimisation.Name = "btn_Optimisation";
            this.btn_Optimisation.Size = new System.Drawing.Size(95, 45);
            this.btn_Optimisation.TabIndex = 0;
            this.btn_Optimisation.Text = "Optimisation et nettoyage";
            this.btn_Optimisation.UseVisualStyleBackColor = true;
            this.btn_Optimisation.Click += new System.EventHandler(this.btn_NettoyageDisque_Click);
            // 
            // btn_Defrag
            // 
            this.btn_Defrag.Location = new System.Drawing.Point(217, 35);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 233);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
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
            this.gb_Operation.Controls.Add(this.btn_Defrag);
            this.gb_Operation.Controls.Add(this.btn_Optimisation);
            this.gb_Operation.Location = new System.Drawing.Point(33, 38);
            this.gb_Operation.Name = "gb_Operation";
            this.gb_Operation.Size = new System.Drawing.Size(383, 127);
            this.gb_Operation.TabIndex = 3;
            this.gb_Operation.TabStop = false;
            this.gb_Operation.Text = "Opérations";
            // 
            // pb_Traitement
            // 
            this.pb_Traitement.Location = new System.Drawing.Point(316, 198);
            this.pb_Traitement.Name = "pb_Traitement";
            this.pb_Traitement.Size = new System.Drawing.Size(100, 23);
            this.pb_Traitement.TabIndex = 4;
            // 
            // lb_Progression
            // 
            this.lb_Progression.AutoSize = true;
            this.lb_Progression.Location = new System.Drawing.Point(313, 179);
            this.lb_Progression.Name = "lb_Progression";
            this.lb_Progression.Size = new System.Drawing.Size(68, 13);
            this.lb_Progression.TabIndex = 5;
            this.lb_Progression.Text = "Progression :";
            // 
            // lb_PourcentProg
            // 
            this.lb_PourcentProg.AutoSize = true;
            this.lb_PourcentProg.Location = new System.Drawing.Point(383, 179);
            this.lb_PourcentProg.Name = "lb_PourcentProg";
            this.lb_PourcentProg.Size = new System.Drawing.Size(21, 13);
            this.lb_PourcentProg.TabIndex = 6;
            this.lb_PourcentProg.Text = "0%";
            // 
            // btn_Options
            // 
            this.btn_Options.Location = new System.Drawing.Point(341, 9);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(75, 23);
            this.btn_Options.TabIndex = 7;
            this.btn_Options.Text = "Options";
            this.btn_Options.UseVisualStyleBackColor = true;
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Depannage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 255);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.lb_PourcentProg);
            this.Controls.Add(this.lb_Progression);
            this.Controls.Add(this.pb_Traitement);
            this.Controls.Add(this.gb_Operation);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Depannage";
            this.Text = "SBiiXpress - Dépannage";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gb_Operation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Optimisation;
        private System.Windows.Forms.Button btn_Defrag;
        private System.Windows.Forms.ToolStripStatusLabel lb_Privileges;
        public System.Windows.Forms.ToolStripStatusLabel lb_Type;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.GroupBox gb_Operation;
        private System.Windows.Forms.ProgressBar pb_Traitement;
        private System.Windows.Forms.Label lb_Progression;
        private System.Windows.Forms.Label lb_PourcentProg;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.Button button1;
    }
}