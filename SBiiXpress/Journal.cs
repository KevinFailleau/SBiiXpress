#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
#endregion

namespace SBiiXpress
{
    public partial class Journal : Form
    {
        #region Constructeur
        /// <summary>
        /// Constructeur de la form Journal
        /// </summary>
        public Journal()
        {
            InitializeComponent();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Cette méthode s'exécute au chargement de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Journal_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\SBiiXpress\\Logs"))
            {
                //Si le fichier de log n'existe pas alors on affiche un message
                MessageBox.Show("Il s'agit de votre première utilisation de l'application, les informations seront complétées lorsque le processus d'optimisation/nettoyage aura été complété", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lb_NbEsp.Text = "0 Mo"; //La taille affichée sur la form est définie à zéro
                lb_Date.Text = DateTime.Now.ToShortDateString(); //Et la date a celle du jour
            }
            else
            {
                if (Gestion_Verification.LectureEspace_Log() != 0)
                {
                    //Si la taille totale trouvée avec le log est différent de zéro
                    if (Gestion_Verification.LectureEspace_Log().ToString().Length >= 4)
                    {
                        double taille = Gestion_Verification.LectureEspace_Log() / 1024;
                        taille = Math.Round(taille, 2);
                        lb_NbEsp.Text = taille.ToString() + " Go"; //Alors on affiche cette taille sur la form
                    }
                    else
                    {
                        lb_NbEsp.Text = Gestion_Verification.LectureEspace_Log().ToString() + " Mo"; //Alors on affiche cette taille sur la form
                    }
                    lb_Date.Text = Gestion_Verification.LectureDate_Log(); //Puis on affiche la date de première utilisation inscrite dans le log
                }
                else
                {
                    //Sinon on mets des valeurs par défaut et on désactive le bouton
                    lb_NbEsp.Text = "0 Mo";
                    lb_Date.Text = DateTime.Now.ToShortDateString();
                }
            }
        }
        #endregion

        #region Gestion boutons
        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region RichTextBox
        /// <summary>
        /// Cette méthode empêche la sélection du texte dans la RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rTB_Infos_Enter(object sender, EventArgs e)
        {
            int index = this.Controls.IndexOf(rTB_Infos);
            this.Controls[index - 1].Focus();
        }
        #endregion
    }
}
