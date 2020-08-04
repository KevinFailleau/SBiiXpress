#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace SBiiXpress
{
    /// <summary>
    /// Classe de la form Options
    /// </summary>
    public partial class Options : Form
    {
        #region Variables
        /// <summary>
        /// Initialisation des variables booléennes, elles permettent de retouvé l'état des cases lorsqu'elles ont été modifiées par l'utilisateur 
        /// </summary>
        public static bool Reg = true, IE = true, CCleaner = true, Cleanmgr = true, WinUp = true, DechargDll = true, Superfetch = true, Telechargement = true;
        #endregion

        #region Initialisation
        /// <summary>
        /// Méthode d'initialisation de la form, les cases sont cochées en fonction des derniers choix de l'utilisateur
        /// Par défaut, elles sont toutes cochées
        /// </summary>
        public Options()
        {
            InitializeComponent();
            if (Gestion_Verification.IsAdministrator())
            {
                AfficheOptionsAdmin();
                if (Gestion_Verification.GetOSVer() != "XP")
                {
                    //Si l'OS n'est pas XP, on vérifie l'état du service Superfetch
                    if (Gestion_Verification.CheckService("superfetch") == "Stoppé")
                    {
                        //Si Superfetch est stoppé, on l'affiche en vert au bas de la form
                        lb_Superfetch.Text = "Superfetch est arrêté";
                        lb_Superfetch.ForeColor = Color.Green;
                        Superfetch = false; //Et on mets la variable Superfetch à false, afin que la Checkbox pour Superfetch ne se recoche pas toute seule au prochain affichage de la form Options
                    }
                    else
                        if (Gestion_Verification.CheckService("superfetch") == "Lancé")
                    {
                        //Sinon on affiche en rouge en bas de la form que Superfetch est lancé
                        lb_Superfetch.Text = "Superfetch est en cours";
                        lb_Superfetch.ForeColor = Color.Red;
                        Superfetch = true; //Et Superfetch passe à true
                    }
                }
                else
                if (Gestion_Verification.GetOSVer() == "XP")
                {
                    //Si l'OS est XP alors on désactive tout ce qui concerne Superfetch sur la form Options
                    cB_Superfetch.Visible = false;
                    cB_Superfetch.Checked = false;
                    lb_Superfetch.Visible = false;
                }

                //Les lignes suivantes permettent de récupérer l'état de chaque CheckBox au moment de la fermeture de la form
                if (Reg)
                {
                    cB_SaveReg.Checked = true;
                }
                else
                {
                    cB_SaveReg.Checked = false;
                }
                if (Cleanmgr)
                {
                    cB_Cleanmgr.Checked = true;
                }
                else
                {
                    cB_Cleanmgr.Checked = false;
                }
                if (CCleaner)
                {
                    cB_CCleaner.Checked = true;
                }
                else
                {
                    cB_CCleaner.Checked = false;
                }
                if (IE)
                {
                    cB_CleanIE.Checked = true;
                }
                else
                {
                    cB_CleanIE.Checked = false;
                }
                if (WinUp)
                {
                    cB_WinUp.Checked = true;
                }
                else
                {
                    cB_WinUp.Checked = false;
                }
                if (DechargDll)
                {
                    cB_DLL.Checked = true;
                }
                else
                {
                    cB_DLL.Checked = false;
                }
                if (Superfetch)
                {
                    cB_Superfetch.Checked = true;
                }
                else
                {
                    cB_Superfetch.Checked = false;
                }
                if (Telechargement)
                {
                    cB_Telechargement.Checked = true;
                }
                else
                {
                    cB_Telechargement.Checked = false;
                }
            }
        }
        #endregion

        #region Boutons
        /// <summary>
        /// Vérifie si le nettoyage de IE à été coché, si c'est le cas, la variable IE = true, sinon IE = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_CleanIE_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_CleanIE.Checked)
            {
                IE = true;
            }
            else
            {
                IE = false;
            }
        }
        /// <summary>
        /// Vérifie si CCleaner a été coché, si c'est la cas, la variable CCleaner = true, sinon CCleaner = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_CCleaner_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_CCleaner.Checked)
            {
                CCleaner = true;
            }
            else
            {
                CCleaner = false;
            }
        }
        /// <summary>
        /// Si le nettoyage Windows a été coché, la variable Cleanmgr = true, sinon Cleanmgr = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_Cleanmgr_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Cleanmgr.Checked)
            {
                Cleanmgr = true;
            }
            else
            {
                Cleanmgr = false;
            }
        }

        /// <summary>
        /// Si le nettoyage du cache de Windows Update a été coché, WinUp = true, sinon WinUp = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_WinUp_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_WinUp.Checked)
            {
                WinUp = true;
            }
            else
            {
                WinUp = false;
            }
        }

        /// <summary>
        /// Si le déchargement des DLL inutiles a été coché, DechargDll = true, sinon DechargDll = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_DLL_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_DLL.Checked)
            {
                DechargDll = true;
            }
            else
            {
                DechargDll = false;
            }
        }

        /// <summary>
        /// Si l'analyse du dossier de téléchargement a été coché, Telechargement = true, sinon Telechargement = false;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_Telechargement_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Telechargement.Checked)
            {
                Telechargement = true;
            }
            else
            {
                Telechargement = false;
            }
        }

        private void cB_Superfetch_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Superfetch.Checked && Gestion_Verification.GetOSVer() != "XP")
            {
                Superfetch = true;
            }
            else
            {
                Superfetch = false;
            }
        }

        /// <summary>
        /// Si la sauvegarde du regstre à été coché, Reg = true, sinon Reg = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_SaveReg_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_SaveReg.Checked)
            {
                Reg = true;
            }
            else
            {
                Reg = false;
            }
        }

        /// <summary>
        /// Lorsque l'utilisateur appuie sur le bouton, la méthode parcourt tous les contrôles de la GroupBox
        /// si le contrôle en cours est une Checkbox et qu'elle n'est pas cochée alors on la coche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cocher_Click(object sender, EventArgs e)
        {
            if (!Gestion_Verification.IsAdministrator())
            {
                //Si l'utilisateur n'est pas administrateur, alors on ne coche que les trois Checkboxs suivantes
                cB_CCleaner.Checked = true;
                cB_CleanIE.Checked = true;
                cB_Telechargement.Checked = true;
            }
            else
            {
                //Sinon on les parcours toutes
                foreach (Control c in gB_Options.Controls)
                {
                    //Pour chaque contrôles sur la form Options
                    if (c is CheckBox)
                    {
                        //Si le contrôle en cours est un checkBox
                        CheckBox chk = (CheckBox)c;
                        if (!chk.Checked)
                        {
                            //Si la checkBox est n'est pas cochée, alors on la coche
                            chk.Checked = true;
                        }
                    }
                }
            }
            if (Gestion_Verification.GetOSVer() == "XP")
            {
                //Si l'OS est XP alors on décoche la checkBox Superfetch
                cB_Superfetch.Checked = false;
            }
        }

        /// <summary>
        /// Lorsque l'utilisateur appuie sur le bouton, la méthode parcourt tous les contrôles de la GroupBox
        /// si le contrôle en cours est une Checkbox et qu'elle est cochée alors on la décoche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Decoche_Click(object sender, EventArgs e)
        {
                foreach (Control c in gB_Options.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox chk = (CheckBox)c;
                        if (chk.Checked)
                        {
                            chk.Checked = false;
                        }
                    }
                }
        }
        
       /// <summary>
       /// Si l'utilisateur appuie sur le bouton annuler, on mets toutes les valeurs booléennes correspondantes
       /// aux différentes options à true
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir annuler ?", "SBiiXpress - Annuler", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Reg = true;
                IE = true;
                CCleaner = true;
                Cleanmgr = true;
                WinUp = true;
                DechargDll = true;
                Telechargement = true;
                this.Close();
            }
        }

        /// <summary>
        /// A la validation, si les cases sont cochées ou non, on redéfini les valeurs booléennes
        /// correspondantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Valider_Click(object sender, EventArgs e)
        {
            if (!cB_SaveReg.Checked)
            {
                Reg = false;
            }
            else
            {
                Reg = true;
            }
            if (!cB_CleanIE.Checked)
            {
                IE = false;
            }
            else
            {
                IE = true;
            }
            if (!cB_CCleaner.Checked)
            {
                CCleaner = false;
            }
            else
            {
                CCleaner = true;
            }
            if (!cB_Cleanmgr.Checked)
            {
                Cleanmgr = false;
            }
            else
            {
                Cleanmgr = true;
            }
            if (!cB_WinUp.Checked)
            {
                WinUp = false;
            }
            else
            {
                WinUp = true;
            }
            if (!cB_DLL.Checked)
            {
                DechargDll = false;
            }
            else
            {
                DechargDll = true;
            }
            if (!cB_Telechargement.Checked)
            {
                Telechargement = false;
            }
            else
            {
                Telechargement = true;
            }
            this.Close();
        }
        #endregion

        #region Affichage des options
        /// <summary>
        /// Permet de rendre disponible les options spécifiques aux administrateurs
        /// </summary>
        public void AfficheOptionsAdmin()
        {
            cB_Cleanmgr.Enabled = true;
            cB_DLL.Enabled = true;
            cB_SaveReg.Enabled = true;
            cB_WinUp.Enabled = true;
            cB_Superfetch.Enabled = true;
        }

        #endregion
    }
}
