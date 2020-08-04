namespace SBiiXpress
{
    partial class Journal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Journal));
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.lb_EspTot = new System.Windows.Forms.Label();
            this.lb_PrUtilisation = new System.Windows.Forms.Label();
            this.lb_NbEsp = new System.Windows.Forms.Label();
            this.lb_Date = new System.Windows.Forms.Label();
            this.rTB_Infos = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Location = new System.Drawing.Point(194, 251);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(75, 23);
            this.btn_Fermer.TabIndex = 0;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            this.btn_Fermer.Click += new System.EventHandler(this.btn_Fermer_Click);
            // 
            // lb_EspTot
            // 
            this.lb_EspTot.AutoSize = true;
            this.lb_EspTot.Location = new System.Drawing.Point(129, 113);
            this.lb_EspTot.Name = "lb_EspTot";
            this.lb_EspTot.Size = new System.Drawing.Size(100, 13);
            this.lb_EspTot.TabIndex = 1;
            this.lb_EspTot.Text = "Espace total libéré :";
            // 
            // lb_PrUtilisation
            // 
            this.lb_PrUtilisation.AutoSize = true;
            this.lb_PrUtilisation.Location = new System.Drawing.Point(129, 153);
            this.lb_PrUtilisation.Name = "lb_PrUtilisation";
            this.lb_PrUtilisation.Size = new System.Drawing.Size(100, 13);
            this.lb_PrUtilisation.TabIndex = 2;
            this.lb_PrUtilisation.Text = "Première utilisation :";
            // 
            // lb_NbEsp
            // 
            this.lb_NbEsp.AutoSize = true;
            this.lb_NbEsp.Location = new System.Drawing.Point(235, 113);
            this.lb_NbEsp.Name = "lb_NbEsp";
            this.lb_NbEsp.Size = new System.Drawing.Size(31, 13);
            this.lb_NbEsp.TabIndex = 3;
            this.lb_NbEsp.Text = "0 Mo";
            // 
            // lb_Date
            // 
            this.lb_Date.AutoSize = true;
            this.lb_Date.Location = new System.Drawing.Point(235, 153);
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Size = new System.Drawing.Size(65, 13);
            this.lb_Date.TabIndex = 4;
            this.lb_Date.Text = "01/01/0000";
            // 
            // rTB_Infos
            // 
            this.rTB_Infos.BackColor = System.Drawing.SystemColors.Control;
            this.rTB_Infos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB_Infos.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rTB_Infos.DetectUrls = false;
            this.rTB_Infos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.rTB_Infos.Location = new System.Drawing.Point(26, 26);
            this.rTB_Infos.Name = "rTB_Infos";
            this.rTB_Infos.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rTB_Infos.Size = new System.Drawing.Size(337, 32);
            this.rTB_Infos.TabIndex = 6;
            this.rTB_Infos.Text = "Les informations ci-dessous représentent la date de première utilisation de l\'app" +
    "lication ainsi que la quantité d\'espace libérée";
            this.rTB_Infos.Enter += new System.EventHandler(this.rTB_Infos_Enter);
            // 
            // Journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 288);
            this.Controls.Add(this.rTB_Infos);
            this.Controls.Add(this.lb_Date);
            this.Controls.Add(this.lb_NbEsp);
            this.Controls.Add(this.lb_PrUtilisation);
            this.Controls.Add(this.lb_EspTot);
            this.Controls.Add(this.btn_Fermer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Journal";
            this.Text = "Journal";
            this.Load += new System.EventHandler(this.Journal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.Label lb_EspTot;
        private System.Windows.Forms.Label lb_PrUtilisation;
        private System.Windows.Forms.Label lb_NbEsp;
        private System.Windows.Forms.Label lb_Date;
        private System.Windows.Forms.RichTextBox rTB_Infos;
    }
}