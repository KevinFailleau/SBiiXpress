﻿namespace SBiiXpress
{
    /// <summary>
    /// Classe de la form Urgence
    /// </summary>
    partial class Form_Urgence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Urgence));
            this.lb_Info = new System.Windows.Forms.Label();
            this.lb_NbBureau = new System.Windows.Forms.Label();
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.lb_nB_Portable = new System.Windows.Forms.Label();
            this.lb_Mail = new System.Windows.Forms.Label();
            this.Lnk_Site = new System.Windows.Forms.LinkLabel();
            this.lb_Site = new System.Windows.Forms.Label();
            this.Lnk_Mail = new System.Windows.Forms.LinkLabel();
            this.lb_Bureau = new System.Windows.Forms.Label();
            this.lb_Portable = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Site = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Info
            // 
            this.lb_Info.AutoSize = true;
            this.lb_Info.Location = new System.Drawing.Point(6, 16);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(478, 13);
            this.lb_Info.TabIndex = 0;
            this.lb_Info.Text = "En cas de problème ou de question, vous pourrez nous contacter grâce aux informat" +
    "ions suivantes :";
            // 
            // lb_NbBureau
            // 
            this.lb_NbBureau.AutoSize = true;
            this.lb_NbBureau.Location = new System.Drawing.Point(234, 73);
            this.lb_NbBureau.Name = "lb_NbBureau";
            this.lb_NbBureau.Size = new System.Drawing.Size(79, 13);
            this.lb_NbBureau.TabIndex = 1;
            this.lb_NbBureau.Text = "02.44.02.39.42";
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Location = new System.Drawing.Point(230, 329);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(75, 23);
            this.btn_Fermer.TabIndex = 2;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            this.btn_Fermer.Click += new System.EventHandler(this.btn_Fermer_Click);
            // 
            // lb_nB_Portable
            // 
            this.lb_nB_Portable.AutoSize = true;
            this.lb_nB_Portable.Location = new System.Drawing.Point(234, 97);
            this.lb_nB_Portable.Name = "lb_nB_Portable";
            this.lb_nB_Portable.Size = new System.Drawing.Size(79, 13);
            this.lb_nB_Portable.TabIndex = 3;
            this.lb_nB_Portable.Text = "06.41.61.98.79";
            // 
            // lb_Mail
            // 
            this.lb_Mail.AutoSize = true;
            this.lb_Mail.Location = new System.Drawing.Point(161, 119);
            this.lb_Mail.Name = "lb_Mail";
            this.lb_Mail.Size = new System.Drawing.Size(72, 13);
            this.lb_Mail.TabIndex = 4;
            this.lb_Mail.Text = "Adresse mail :";
            // 
            // Lnk_Site
            // 
            this.Lnk_Site.AutoSize = true;
            this.Lnk_Site.Location = new System.Drawing.Point(234, 142);
            this.Lnk_Site.Name = "Lnk_Site";
            this.Lnk_Site.Size = new System.Drawing.Size(92, 13);
            this.Lnk_Site.TabIndex = 5;
            this.Lnk_Site.TabStop = true;
            this.Lnk_Site.Text = "http://sbiixpress.fr";
            this.Lnk_Site.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lnk_Site_LinkClicked);
            // 
            // lb_Site
            // 
            this.lb_Site.AutoSize = true;
            this.lb_Site.Location = new System.Drawing.Point(161, 142);
            this.lb_Site.Name = "lb_Site";
            this.lb_Site.Size = new System.Drawing.Size(70, 13);
            this.lb_Site.TabIndex = 6;
            this.lb_Site.Text = "Site Internet :";
            // 
            // Lnk_Mail
            // 
            this.Lnk_Mail.AutoSize = true;
            this.Lnk_Mail.Location = new System.Drawing.Point(234, 119);
            this.Lnk_Mail.Name = "Lnk_Mail";
            this.Lnk_Mail.Size = new System.Drawing.Size(108, 13);
            this.Lnk_Mail.TabIndex = 7;
            this.Lnk_Mail.TabStop = true;
            this.Lnk_Mail.Text = "contact@sbiixpress.fr";
            this.Lnk_Mail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lnk_Mail_LinkClicked);
            // 
            // lb_Bureau
            // 
            this.lb_Bureau.AutoSize = true;
            this.lb_Bureau.Location = new System.Drawing.Point(118, 73);
            this.lb_Bureau.Name = "lb_Bureau";
            this.lb_Bureau.Size = new System.Drawing.Size(115, 13);
            this.lb_Bureau.TabIndex = 8;
            this.lb_Bureau.Text = "Téléphone du bureau :";
            // 
            // lb_Portable
            // 
            this.lb_Portable.AutoSize = true;
            this.lb_Portable.Location = new System.Drawing.Point(128, 97);
            this.lb_Portable.Name = "lb_Portable";
            this.lb_Portable.Size = new System.Drawing.Size(105, 13);
            this.lb_Portable.TabIndex = 9;
            this.lb_Portable.Text = "Téléphone portable :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Site);
            this.groupBox1.Controls.Add(this.lb_nB_Portable);
            this.groupBox1.Controls.Add(this.lb_Portable);
            this.groupBox1.Controls.Add(this.Lnk_Mail);
            this.groupBox1.Controls.Add(this.lb_Info);
            this.groupBox1.Controls.Add(this.lb_Mail);
            this.groupBox1.Controls.Add(this.lb_NbBureau);
            this.groupBox1.Controls.Add(this.lb_Bureau);
            this.groupBox1.Controls.Add(this.Lnk_Site);
            this.groupBox1.Location = new System.Drawing.Point(25, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 193);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btn_Site
            // 
            this.btn_Site.Location = new System.Drawing.Point(210, 258);
            this.btn_Site.Name = "btn_Site";
            this.btn_Site.Size = new System.Drawing.Size(111, 37);
            this.btn_Site.TabIndex = 12;
            this.btn_Site.Text = "Remplir le formulaire sur le site";
            this.btn_Site.UseVisualStyleBackColor = true;
            this.btn_Site.Click += new System.EventHandler(this.btn_Site_Click);
            // 
            // Form_Urgence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 364);
            this.Controls.Add(this.btn_Site);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Fermer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Urgence";
            this.Text = "En cas d\'urgence";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_Info;
        private System.Windows.Forms.Label lb_NbBureau;
        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.Label lb_nB_Portable;
        private System.Windows.Forms.Label lb_Mail;
        private System.Windows.Forms.LinkLabel Lnk_Site;
        private System.Windows.Forms.Label lb_Site;
        private System.Windows.Forms.LinkLabel Lnk_Mail;
        private System.Windows.Forms.Label lb_Bureau;
        private System.Windows.Forms.Label lb_Portable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Site;
    }
}