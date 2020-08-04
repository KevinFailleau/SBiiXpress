namespace SBiiXpress
{
    partial class Encre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encre));
            this.lb_Defaut = new System.Windows.Forms.Label();
            this.lb_Imp = new System.Windows.Forms.Label();
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Defaut
            // 
            this.lb_Defaut.AutoSize = true;
            this.lb_Defaut.Location = new System.Drawing.Point(63, 79);
            this.lb_Defaut.Name = "lb_Defaut";
            this.lb_Defaut.Size = new System.Drawing.Size(118, 13);
            this.lb_Defaut.TabIndex = 0;
            this.lb_Defaut.Text = "Imprimante par défaut : ";
            // 
            // lb_Imp
            // 
            this.lb_Imp.AutoSize = true;
            this.lb_Imp.Location = new System.Drawing.Point(188, 79);
            this.lb_Imp.Name = "lb_Imp";
            this.lb_Imp.Size = new System.Drawing.Size(0, 13);
            this.lb_Imp.TabIndex = 1;
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Location = new System.Drawing.Point(160, 150);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(75, 23);
            this.btn_Fermer.TabIndex = 2;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            this.btn_Fermer.Click += new System.EventHandler(this.btn_Fermer_Click);
            // 
            // Encre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 185);
            this.Controls.Add(this.btn_Fermer);
            this.Controls.Add(this.lb_Imp);
            this.Controls.Add(this.lb_Defaut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Encre";
            this.Text = "SBiiXpress - Gestion de l\'encre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Defaut;
        private System.Windows.Forms.Label lb_Imp;
        private System.Windows.Forms.Button btn_Fermer;
    }
}