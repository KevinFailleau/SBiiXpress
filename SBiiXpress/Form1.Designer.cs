namespace SBiiXpress
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu_SBii = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cleanerXpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webXpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Acces_Site_Web = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Acces_Site_Imprim = new System.Windows.Forms.ToolStripMenuItem();
            this.Acces_Site_Vente = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimXpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Acces_Site_Imprim = new System.Windows.Forms.ToolStripMenuItem();
            this.codeurXpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Acces_Site_Codeur = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enCasDurgenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accéderAuSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SBii.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SBiiXpress";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // Menu_SBii
            // 
            this.Menu_SBii.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Menu_SBii.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanerXpressToolStripMenuItem,
            this.webXpressToolStripMenuItem,
            this.tsmi_Acces_Site_Imprim,
            this.imprimXpressToolStripMenuItem,
            this.codeurXpressToolStripMenuItem,
            this.toolStripSeparator1,
            this.enCasDurgenceToolStripMenuItem,
            this.accéderAuSiteToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.Menu_SBii.Name = "Menu_SBii";
            this.Menu_SBii.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu_SBii.ShowImageMargin = false;
            this.Menu_SBii.ShowItemToolTips = false;
            this.Menu_SBii.Size = new System.Drawing.Size(139, 192);
            // 
            // cleanerXpressToolStripMenuItem
            // 
            this.cleanerXpressToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.cleanerXpressToolStripMenuItem.BackgroundImage = global::SBiiXpress.Properties.Resources.Cleaner_Av;
            this.cleanerXpressToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cleanerXpressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cleanerXpressToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cleanerXpressToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cleanerXpressToolStripMenuItem.Name = "cleanerXpressToolStripMenuItem";
            this.cleanerXpressToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cleanerXpressToolStripMenuItem.Text = "CleanerXpress";
            this.cleanerXpressToolStripMenuItem.Click += new System.EventHandler(this.cleanerXpressToolStripMenuItem_Click);
            // 
            // webXpressToolStripMenuItem
            // 
            this.webXpressToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.webXpressToolStripMenuItem.BackgroundImage = global::SBiiXpress.Properties.Resources.Web_Av;
            this.webXpressToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.webXpressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.webXpressToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Acces_Site_Web});
            this.webXpressToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.webXpressToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.webXpressToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.webXpressToolStripMenuItem.Name = "webXpressToolStripMenuItem";
            this.webXpressToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.webXpressToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.webXpressToolStripMenuItem.Text = "WebXpress";
            // 
            // Acces_Site_Web
            // 
            this.Acces_Site_Web.Name = "Acces_Site_Web";
            this.Acces_Site_Web.Size = new System.Drawing.Size(205, 22);
            this.Acces_Site_Web.Text = "Accéder à la page du site";
            this.Acces_Site_Web.Click += new System.EventHandler(this.Acces_Site_Web_Click);
            // 
            // tsmi_Acces_Site_Imprim
            // 
            this.tsmi_Acces_Site_Imprim.BackColor = System.Drawing.Color.Transparent;
            this.tsmi_Acces_Site_Imprim.BackgroundImage = global::SBiiXpress.Properties.Resources.Vente_Av;
            this.tsmi_Acces_Site_Imprim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsmi_Acces_Site_Imprim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmi_Acces_Site_Imprim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Acces_Site_Vente});
            this.tsmi_Acces_Site_Imprim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsmi_Acces_Site_Imprim.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmi_Acces_Site_Imprim.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_Acces_Site_Imprim.Name = "tsmi_Acces_Site_Imprim";
            this.tsmi_Acces_Site_Imprim.Size = new System.Drawing.Size(138, 22);
            this.tsmi_Acces_Site_Imprim.Text = "VenteXpress";
            // 
            // Acces_Site_Vente
            // 
            this.Acces_Site_Vente.Name = "Acces_Site_Vente";
            this.Acces_Site_Vente.Size = new System.Drawing.Size(205, 22);
            this.Acces_Site_Vente.Text = "Accéder à la page du site";
            this.Acces_Site_Vente.Click += new System.EventHandler(this.Acces_Site_Vente_Click);
            // 
            // imprimXpressToolStripMenuItem
            // 
            this.imprimXpressToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.imprimXpressToolStripMenuItem.BackgroundImage = global::SBiiXpress.Properties.Resources.Imprim_Av;
            this.imprimXpressToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imprimXpressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimXpressToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Acces_Site_Imprim});
            this.imprimXpressToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.imprimXpressToolStripMenuItem.ForeColor = System.Drawing.Color.Transparent;
            this.imprimXpressToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.imprimXpressToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imprimXpressToolStripMenuItem.Name = "imprimXpressToolStripMenuItem";
            this.imprimXpressToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.imprimXpressToolStripMenuItem.Text = "ImprimXpress";
            // 
            // Acces_Site_Imprim
            // 
            this.Acces_Site_Imprim.Name = "Acces_Site_Imprim";
            this.Acces_Site_Imprim.Size = new System.Drawing.Size(205, 22);
            this.Acces_Site_Imprim.Text = "Accéder à la page du site";
            this.Acces_Site_Imprim.Click += new System.EventHandler(this.Acces_Site_Imprim_Click);
            // 
            // codeurXpressToolStripMenuItem
            // 
            this.codeurXpressToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.codeurXpressToolStripMenuItem.BackgroundImage = global::SBiiXpress.Properties.Resources.Codeur_Av;
            this.codeurXpressToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.codeurXpressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.codeurXpressToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Acces_Site_Codeur});
            this.codeurXpressToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.codeurXpressToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.codeurXpressToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.codeurXpressToolStripMenuItem.Name = "codeurXpressToolStripMenuItem";
            this.codeurXpressToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.codeurXpressToolStripMenuItem.Text = "CodeurXpress";
            // 
            // Acces_Site_Codeur
            // 
            this.Acces_Site_Codeur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Acces_Site_Codeur.Name = "Acces_Site_Codeur";
            this.Acces_Site_Codeur.Size = new System.Drawing.Size(205, 22);
            this.Acces_Site_Codeur.Text = "Accéder à la page du site";
            this.Acces_Site_Codeur.Click += new System.EventHandler(this.Acces_Site_Codeur_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // enCasDurgenceToolStripMenuItem
            // 
            this.enCasDurgenceToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.enCasDurgenceToolStripMenuItem.Name = "enCasDurgenceToolStripMenuItem";
            this.enCasDurgenceToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.enCasDurgenceToolStripMenuItem.Text = "En cas d\'urgence";
            this.enCasDurgenceToolStripMenuItem.Click += new System.EventHandler(this.enCasDurgenceToolStripMenuItem_Click);
            // 
            // accéderAuSiteToolStripMenuItem
            // 
            this.accéderAuSiteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.accéderAuSiteToolStripMenuItem.Name = "accéderAuSiteToolStripMenuItem";
            this.accéderAuSiteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.accéderAuSiteToolStripMenuItem.Text = "Accéder au site";
            this.accéderAuSiteToolStripMenuItem.Click += new System.EventHandler(this.accéderAuSiteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 250);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SBiiXpress";
            this.Menu_SBii.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip Menu_SBii;
        private System.Windows.Forms.ToolStripMenuItem imprimXpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Acces_Site_Imprim;
        private System.Windows.Forms.ToolStripMenuItem webXpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeurXpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enCasDurgenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Acces_Site_Imprim;
        private System.Windows.Forms.ToolStripMenuItem Acces_Site_Web;
        private System.Windows.Forms.ToolStripMenuItem Acces_Site_Codeur;
        private System.Windows.Forms.ToolStripMenuItem accéderAuSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanerXpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Acces_Site_Vente;
    }
}

