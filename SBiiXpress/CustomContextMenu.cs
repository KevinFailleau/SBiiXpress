#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
#endregion

namespace SBiiXpress
{
    public partial class CustomContextMenu : Form
    {
        #region Variables

        private int desiredStartLocationX;
        private int desiredStartLocationY;
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur, on passe en paramètre les indices de position de la souris
        /// pour faire apparaître le menu 
        /// </summary>
        /// <param name="x">Position X de la souris</param>
        /// <param name="y">Position Y de la souris</param>
        public CustomContextMenu(int x, int y)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.desiredStartLocationX = x - 133;
            this.desiredStartLocationY = y - 350;
            Load += new EventHandler(CustomContextMenu_Load);
            lb_Sep.AutoSize = false;
            lb_Sep.Height = 2;
            lb_Sep.BorderStyle = BorderStyle.Fixed3D;
            lb_Sep2.AutoSize = false;
            lb_Sep2.Height = 2;
            lb_Sep2.BorderStyle = BorderStyle.Fixed3D;
        }

        #endregion

        #region Gestion des boutons du menu

        /// <summary>
        /// S'exécute lorsque l'utilisateur clique sur CleanerXpress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CleanerXpress_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Lorsque l'utilisateur clique sur ImprimXpress, on ouvre la form FormAccesSite et on passe le paramètre I
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_ImprimXpress_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('I');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur En cas d'urgence, on ouvre la form Urgence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Urgence_Click(object sender, EventArgs e)
        {
            Form_Urgence FU = new Form_Urgence();
            FU.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur FontXpress, on ouvre la form FontXpress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Font_Click(object sender, EventArgs e)
        {
            FormFont FF = new FormFont();
            FF.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur WebXpress, on ouvre la FormAccesSite et on passe le paramètre W
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_WebXpress_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('W');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur EncreXpress, on ouvre la FormAccesSite et on passe le paramètre E
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Encre_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('E');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur DepanXpress, on ouvre la FormAccesSite et on passe le paramètre D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Depan_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('D');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur VenteXpress, on ouvre la FormAccesSite et on passe la paramètre V
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_VenteXpress_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('V');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur CodeurXpress, on ouvre la FormAccesSite et on passe le paramètre C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CodeurXpress_Click(object sender, EventArgs e)
        {
            FormAccesSite FAS = new FormAccesSite('C');
            FAS.Show();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique qsur Quitter, on ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Lorsque l'utilisateur clique sur Accéder au site, on ouvre la page principale sur site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Site_Click(object sender, EventArgs e)
        {
            Process.Start("http:\\sbiixpress.fr");
        }

        #endregion

        #region Gestion de l'ombre du menu

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);
        /// <summary>
        /// Cette méthode permet d'ajouter une ombre au menu, on fait appel à User32.dll
        /// </summary>
        private void SetShadow()
        {
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }

        #endregion

        #region Événements de la form
        /// <summary>
        /// Peremet de faire apparaître le menu a la position voulue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomContextMenu_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);
        }
        /// <summary>
        /// Lorsque le menu ferme le focus, on ferme le menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomContextMenu_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Ajout d'une bordure au menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 2f),this.DisplayRectangle);
        }

        #endregion

        #region Animation sélection menu
        /// <summary>
        /// On change l'image de DepanXpress et on la surligne lorsque la souris passe dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Depan_MouseMove(object sender, MouseEventArgs e)
        {
            pb_Depan.Image = SBiiXpress.Properties.Resources.Depan_Ap;
            pb_Depan.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Quand la souris quitte DepanXpress, on remets l'image dans la situation initiale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Depan_MouseLeave(object sender, EventArgs e)
        {
            pb_Depan.Image = SBiiXpress.Properties.Resources.Depan_Av;
            pb_Depan.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Lorsque la souris passe sur CleanerXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CleanerXpress_MouseMove(object sender, MouseEventArgs e)
        {
            pb_CleanerXpress.Image = SBiiXpress.Properties.Resources.Cleaner_Ap;
            pb_CleanerXpress.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte CleanerXpress, on remets l'image dans la situation initiale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CleanerXpress_MouseLeave(object sender, EventArgs e)
        {
            pb_CleanerXpress.Image = SBiiXpress.Properties.Resources.Cleaner_Av;
            pb_CleanerXpress.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Quand la souris quitte WebXpress, on remets dans l'état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_WebXpress_MouseLeave(object sender, EventArgs e)
        {
            pb_WebXpress.Image = SBiiXpress.Properties.Resources.Web_Av;
            pb_WebXpress.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Lorsque la souris quitte WebXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_WebXpress_MouseMove(object sender, MouseEventArgs e)
        {
            pb_WebXpress.Image = SBiiXpress.Properties.Resources.Web_Ap;
            pb_WebXpress.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte VenteXpress, on remets dans l'état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_VenteXpress_MouseLeave(object sender, EventArgs e)
        {
            pb_VenteXpress.Image = SBiiXpress.Properties.Resources.Vente_Av;
            pb_VenteXpress.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Lorsque la souris passe sur VenteXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_VenteXpress_MouseMove(object sender, MouseEventArgs e)
        {
            pb_VenteXpress.Image = SBiiXpress.Properties.Resources.Vente_Ap;
            pb_VenteXpress.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris passe sur ImprimXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_ImprimXpress_MouseMove(object sender, MouseEventArgs e)
        {
            pb_ImprimXpress.Image = SBiiXpress.Properties.Resources.Imprim_Ap;
            pb_ImprimXpress.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte ImprimXpress, on remets l'image dans son état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_ImprimXpress_MouseLeave(object sender, EventArgs e)
        {
            pb_ImprimXpress.Image = SBiiXpress.Properties.Resources.Imprim_Av;
            pb_ImprimXpress.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Lorsque la souris passe sur CodeurXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CodeurXpress_MouseMove(object sender, MouseEventArgs e)
        {
            pb_CodeurXpress.Image = SBiiXpress.Properties.Resources.Codeur_Ap;
            pb_CodeurXpress.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Quand la souris quitte, on remets l'image dans son état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CodeurXpress_MouseLeave(object sender, EventArgs e)
        {
            pb_CodeurXpress.Image = SBiiXpress.Properties.Resources.Codeur_Av;
            pb_CodeurXpress.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Lorsque la souris passe sur le label En cas d'urgence, on le surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Urgence_MouseMove(object sender, MouseEventArgs e)
        {
            lb_Urgence.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte le label, on enlève la surbrillance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Urgence_MouseLeave(object sender, EventArgs e)
        {
            lb_Urgence.BackColor = SystemColors.Control;
        }
        /// <summary>
        /// Quand la souris passe sur le label Accéder au site, on le surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Site_MouseMove(object sender, MouseEventArgs e)
        {
            lb_Site.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Quand la souris quitte le label Accéder au site, on enlève la surbrillance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Site_MouseLeave(object sender, EventArgs e)
        {
            lb_Site.BackColor = SystemColors.Control;
        }
        /// <summary>
        /// Lorsque la souris survole le label Quitter, on le surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Quitter_MouseMove(object sender, MouseEventArgs e)
        {
            lb_Quitter.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte le label, on enlève la surbrillance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Quitter_MouseLeave(object sender, EventArgs e)
        {
            lb_Quitter.BackColor = SystemColors.Control;
        }
        /// <summary>
        /// Quand la souris passe sur EncreXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Encre_MouseMove(object sender, MouseEventArgs e)
        {
            pb_Encre.Image = SBiiXpress.Properties.Resources.Encre_Ap;
            pb_Encre.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Quand la souris quitte EncreXpress, on remets dans l'état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Encre_MouseLeave(object sender, EventArgs e)
        {
            pb_Encre.Image = SBiiXpress.Properties.Resources.Encre_Av;
            pb_Encre.BackColor = SystemColors.Control;
        }
        /// <summary>
        /// Lorsque la souris passe sur FontXpress, on change l'image et on la surligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Font_MouseMove(object sender, MouseEventArgs e)
        {
            pb_Font.Image = SBiiXpress.Properties.Resources.Font_Ap;
            pb_Font.BackColor = SystemColors.Highlight;
        }
        /// <summary>
        /// Lorsque la souris quitte, on remets dans l'état d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Font_MouseLeave(object sender, EventArgs e)
        {
            pb_Font.Image = SBiiXpress.Properties.Resources.Font_Av;
            pb_Font.BackColor = SystemColors.Control;
        }

        #endregion
    }
}
