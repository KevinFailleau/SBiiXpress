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
#endregion

namespace SBiiXpress
{
    public partial class FormAccesSite : Form
    {
        #region Constructeur
        char adrSite;
        /// <summary>
        /// Constructeur, on passe un char en paramètre pour pouvoir savoir
        /// sur quel service, l'utilisateur à cliqué
        /// </summary>
        /// <param name="site">Représente le service choisi</param>
        public FormAccesSite(char site)
        {
            InitializeComponent();
            adrSite = site;
            switch (adrSite)
            {
                //En fonction du service choisi, on adapte le nom de la fenêtre au service
                case 'D':
                    this.Text = "Accéder à la page DépanXpress";
                    break;
                case 'I':
                    this.Text = "Accéder à la page ImprimXpress";
                    break;
                case 'V':
                    this.Text = "Accéder à la page VenteXpress";
                    break;
                case 'W':
                    this.Text = "Accéder à la page WebXpress";
                    break;
                case 'C':
                    this.Text = "Accéder à la page CodeurXpress";
                    break;
                case 'E':
                    this.Text = "Accéder à la page EncreXpress";
                    break;
            }
        }
        #endregion

        #region Gestion des boutons
        /// <summary>
        /// Méthode qui s'exécute lorsque l'utilisateur clique sur le bouton Fermer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Méthode qui s'exécute lorsque l'utilisateur clique sur le bouton pour accéder au site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AccesSite_Click(object sender, EventArgs e)
        {
            switch (adrSite)
            {
                //En fonction du service choisi, on adapte le lien qui sera ouvert lorsque l'utilisateur appuie sur le bouton
                case 'D':
                    Process.Start("http://sbiixpress.fr/depanxpress-maintenance-informatique-reseau/");
                    break;
                case 'I':
                    Process.Start("http://sbiixpress.fr/imprimxpress-impression-numerique-et-3d/");
                    break;
                case 'V':
                    Process.Start("http://sbiixpress.fr/ventexpress-vente-de-produits-informatiques-multimedias-et-high-tech/");
                    break;
                case 'W':
                    Process.Start("http://sbiixpress.fr/webxpress-conception-de-sites-internets-e-commerce-et-communautaire/");
                    break;
                case 'C':
                    Process.Start("http://sbiixpress.fr/codeurxpress/");
                    break;
                case 'E':
                    Process.Start("http://sbiixpress.fr/codeurxpress/");
                    break;
            }
        }
        #endregion
    }
}
