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
    public partial class Form1 : Form
    {
        #region Initialisation du programme principal
        public Form1()
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
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void enCasDurgenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Urgence FU = new Form_Urgence();
            FU.Show(); 
        }

        private void Acces_Site_Imprim_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/imprimxpress-impression-numerique-et-3d/");
        }

        private void Acces_Site_Vente_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/ventexpress-vente-de-produits-informatiques-multimedias-et-high-tech/");
        }

        private void Acces_Site_Web_Click(object sender, EventArgs e)
        { 
            Process.Start("http://sbiixpress.fr/ventexpress-vente-de-produits-informatiques-multimedias-et-high-tech/");
        }

        private void Acces_Site_Codeur_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr/codeurxpress/");
        }

        private void accéderAuSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://sbiixpress.fr//");
        }

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
    }
}
