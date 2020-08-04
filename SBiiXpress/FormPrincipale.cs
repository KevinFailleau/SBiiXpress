#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
#endregion

namespace SBiiXpress
{
    /// <summary>
    /// Classe de la FormPrincipale
    /// </summary>
    public partial class FormPrincipale : Form
    {
        #region Initialisation du programme principal
        /// <summary>
        /// Constructeur de la form principale
        /// </summary>
        public FormPrincipale()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            //Menu_SBii.Renderer = new MyRenderer();
            if (!Gestion_Verification.IsAdministrator())
            {
                MessageBox.Show("Il est recommandé de lancer cette application en mode administrateur", "SBiiXpress - Privilèges administrateur recommandés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Méthodes bouton ToolStripMenu
        /// <summary>
        /// Lorsque l'utilisateur clique sur le bouton Quitter, on ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur "En cas d'urgence", on ouvre la form urgence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enCasDurgenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Urgence FU = new Form_Urgence();
            FU.Show(); 
        }
        /// <summary>
        /// Permet d'accéder à la section Impression du site (inutilisée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acces_Site_Imprim_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/imprimxpress-impression-numerique-et-3d/");
        }
        /// <summary>
        /// Permet d'accéder à la section Vente du site (inutilisée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acces_Site_Vente_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/ventexpress-vente-de-produits-informatiques-multimedias-et-high-tech/");
        }
        /// <summary>
        /// Permet d'accéder à la section WebXpress du site (inutilisée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acces_Site_Web_Click(object sender, EventArgs e)
        { 
            Process.Start("http://sbiixpress.fr/webxpress-conception-de-sites-internets-e-commerce-et-communautaire/");
        }
        /// <summary>
        /// Peremet d'accéder à la section CodeurXpress du site (inutilisée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acces_Site_Codeur_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/codeurxpress/");
        }
        /// <summary>
        /// Permet d'accéder au site Internet (inutilisée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accéderAuSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr//");
        }
        /// <summary>
        /// Ouvre CleanerXpress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cleanerXpressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Gestion_Verification.GetOSVer() == "95" || Gestion_Verification.GetOSVer() == "98" || Gestion_Verification.GetOSVer() == "Me" || Gestion_Verification.GetOSVer() == "2000")
            {
                //Si l'OS de l'utilisateur est anterieur à Windows Vista, la form dépannage ne sera pas créée
                MessageBox.Show("Ce programme necessite une version plus récente de Windows", "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CleanerXpress CX = new CleanerXpress();
                CX.Show();
                if (Gestion_Verification.GetOSVer() != "XP")
                {
                    //On vérifie les droits de l'utilisateur et on affiche ensuite sur la form dépannage
                    if (Gestion_Verification.IsAdministrator())
                    {
                        CX.lb_Type.Text = "Complet (administrateur)";
                        CX.lb_Type.ForeColor = Color.Green;
                    }
                    else
                    {
                        CX.lb_Type.Text = "Restreint (invité)";
                        CX.lb_Type.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (Gestion_Verification.GetOSVer() == "XP")
                    {
                        CX.lb_Privileges.Visible = false;
                        CX.lb_Type.Visible = false;
                    }
                }
            }
        }

        #endregion

        #region Rendu ContextMenuStrip
        /// <summary>
        /// Cette section permet de modifier l'apparence du ContextMenuStrip (inutilisée)
        /// </summary>
        class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.DisplayStyle == ToolStripItemDisplayStyle.Image)
                {
                    e.Item.BackgroundImage = SBiiXpress.Properties.Resources.SBii_B;
                    e.Item.BackgroundImageLayout = ImageLayout.Center;
                    e.Item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    e.Item.BackColor = Color.Transparent;
                }
            }
        }
        #endregion

        #region Evénement souris
        /// <summary>
        /// Permet d'activer le menu que si l'utilisateur clique sur l'icône avec le bouton Droit de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Application.OpenForms.OfType<CustomContextMenu>().Count() == 1)
                    Application.OpenForms.OfType<CustomContextMenu>().First().Close();
                else
                {
                    CustomContextMenu F2 = new CustomContextMenu(Cursor.Position.X, Cursor.Position.Y);
                    F2.TopMost = true;
                    F2.Show();
                }
            }
        }
        #endregion
    }
}
