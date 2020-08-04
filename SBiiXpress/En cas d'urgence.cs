using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBiiXpress
{
    public partial class Form_Urgence : Form
    {
        #region Initialisation
        /// <summary>
        /// Constructreur de Form_Urgence
        /// </summary>
        public Form_Urgence()
        {
            InitializeComponent();
        }

        #endregion

        #region Boutons

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur clique sur le bouton Fermer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close(); //Fermeture de la form
        }

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur clique sur l'adresse mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lnk_Mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:contact@sbixxpress.fr"); //On ouvre l'application de messagerie par défaut avec le mail de l'entreprise
        }

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur clique sur le lien du site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lnk_Site_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://sbiixpress.fr/"); //On ouvre le site dans le navigateur par défaut
        }

        /// <summary>
        /// cette méthode s'exécute lorsque l'utilisateur clique sur le bouton pour remplir le formulaire sur le site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Site_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sbiixpress.fr/nous-contacter"); //On ouvre le lien dans le navigateur par défaut
        }

        #endregion
    }
}
