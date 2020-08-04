using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SBiiXpress
{
    public partial class Telechargements : Form
    {
        static DirectoryInfo dinfo;
        static FileInfo[] Files;
        static DirectoryInfo[] Directories;
        static string folder;
        int newSortColumn;
        ListSortDirection newColumnDirection = ListSortDirection.Ascending;
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="Dossier"></param>
        public Telechargements(string Dossier)
        {
            InitializeComponent();
            folder = Dossier;
        }

        #region Chargement de la form

        private void Telechargements_Load(object sender, EventArgs e)
        {
            ColumnCheckBox.TrueValue = true;
            ColumnCheckBox.FalseValue = false; //Définition des valeurs true et false pour la colonne qui accueille les Checkboxs
            dinfo = new DirectoryInfo(folder); //On récupère le dossier de téléchargement, avec l'emplacement qui aura été passé par la form CleanerXpress
            Directories = dinfo.GetDirectories(); //On récupère les sous-dossiers du dossier de Téléchargement
            Files = dinfo.GetFiles(); //Puis on récupère les fichiers
            GetContenu();
        }
        #endregion

        #region Affichage des fichiers et des sous-dossiers

        private void GetContenu()
        {
            try
            {
                double tailleKo = 0, tailleMo = 0, tailleGo = 0;
                decimal nbFichierGo = 0;
                int nbFiles = 0, nbDir = 0;
                foreach (FileInfo file in Files)
                {
                    //Pour chaque fichiers du dossier de téléchargement
                    nbFiles++; //Incrémentation du 
                    tailleKo = file.Length / 1024; //On récupère la taille du fichier courant en Ko
                    tailleMo = Math.Round(Convert.ToDouble(tailleKo / 1024), 2); //Puis conversion en Mo
                    tailleGo = Math.Round(Convert.ToDouble(tailleMo / 1024), 2); // Et en Go
                    if (file.Name != "desktop.ini")
                    {
                        //On vérifie que le fichier en cours n'est pas Desktop.ini, qui est un fichier système
                        if (tailleKo == 0) dGV_Telechargement.Rows.Add(false, file.Name, "Fichier", tailleKo); //Si le fichier est très petit alors on n'ajoute que sa taille en Ko
                        else if (tailleGo < 0.1) dGV_Telechargement.Rows.Add(false, file.Name, "Fichier", tailleKo, tailleMo); //Sinon on ajoute la taille en Mo
                        else dGV_Telechargement.Rows.Add(false, file.Name, "Fichier", tailleKo, tailleMo, tailleGo); //Et sinon on ajoute tout
                    }
                }
                foreach (DirectoryInfo dir in Directories)
                {
                    //Pour chaque dossiers du dossier de téléchargement
                    nbDir++; //Incrémentation du nombre de dossier
                    //Le traitement est le même que pour les fichiers
                    tailleKo = Math.Round(Convert.ToDouble(Gestion_Verification.FolderSize(folder + "\\" + dir.ToString(), "Ko")), 2);
                    tailleMo = Math.Round(Convert.ToDouble(Gestion_Verification.FolderSize(folder + "\\" + dir.ToString(), "Mo")), 2);
                    tailleGo = Math.Round(Convert.ToDouble(Gestion_Verification.FolderSize(folder + "\\" + dir.ToString(), "Go")), 2);
                    if (tailleKo == 0) dGV_Telechargement.Rows.Add(false, dir.Name, "Dossier", tailleKo);
                    else if (tailleGo < 0.1) dGV_Telechargement.Rows.Add(false, dir.Name, "Dossier", tailleKo, tailleMo);
                    else dGV_Telechargement.Rows.Add(false, dir.Name, "Dossier", tailleKo, tailleMo, tailleGo);
                }
                if (nbFiles == 0 && nbDir == 0)
                {
                    //Si aucun fichier ni sous-dossiers n'a été trouvé, alors on désactive tout et on affiche un message
                    dGV_Telechargement.Columns[0].Visible = false;
                    dGV_Telechargement.Columns[1].Visible = false;
                    dGV_Telechargement.Columns[2].Visible = false;
                    dGV_Telechargement.Columns[3].Visible = false;
                    dGV_Telechargement.Columns[4].Visible = false;
                    MessageBox.Show("Le dossier est vide", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                for (int i = 0; i < dGV_Telechargement.Rows.Count; i++)
                {
                    //On vérifie s'il y a une ligne qui utilise la colonne Taille (en Go)
                    nbFichierGo += Convert.ToDecimal(dGV_Telechargement.Rows[i].Cells["ColumnTailleGo"].Value);
                }
                if (nbFichierGo < 1)
                {
                    //Si ce n'est pas le cas, alors on la désactive
                    dGV_Telechargement.Columns["ColumnTailleGo"].Visible = false;
                }
            }
            catch (Exception e)
            {
                //Affichage d'un message en cas d'erreur
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Boutons
        /// <summary>
        /// Cette méthode s'exécute lorsque qu'une cellule à été cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGV_Telechargement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //Si l'index de e = -1 alors la ligne actuelle est un header, donc impossible de cocher la CheckBox de la ligne puisqu'elle n'existe pas
            else
            {
                //Sinon, si la ligne actuelle n'est pas un header
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dGV_Telechargement.Rows[e.RowIndex].Cells[0];

                if (chk.Value == chk.TrueValue)
                {
                    //Si la ligne de la cellule est cochée, alors on la décoche
                    dGV_Telechargement.Rows[e.RowIndex].Cells[0].Value = chk.FalseValue;
                }
                else
                {
                    //Sinon on la coche
                    dGV_Telechargement.Rows[e.RowIndex].Cells[0].Value = chk.TrueValue;
                }
            }
        }

        /// <summary>
        /// Cette mèthode gère le bouton Fermer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close(); //Fermeture de la form
        }

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur à cliquer sur le bouton "Supprimer"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les fichiers séléctionnés ?\nCette action est irréversible", "SBiiXpress - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Affichage d'un message de confirmation
                if (result == DialogResult.Yes)
                {
                    //Si l'utilisateur valide alors on supprime les fichers qu'il a sélectionné
                    foreach (DataGridViewRow d in dGV_Telechargement.Rows)
                    {
                        //Pour chaque lignes du DataGridView
                        if (Convert.ToBoolean(d.Cells[ColumnCheckBox.Name].Value) == true && d.Cells[ColumnType.Name].Value.ToString() == "Fichier")
                        {
                            //Si la ligne actuelle a été cochée par l'utilisateur et si le contenu de la cellule "Type" est égal à "Fichier"
                            Files[d.Index].Delete(); //Alors on supprime
                        }
                        else
                        {
                            if (Convert.ToBoolean(d.Cells[ColumnCheckBox.Name].Value) == true && d.Cells[ColumnType.Name].Value.ToString() == "Dossier")
                            {
                                //Sinon, si la ligne actuelle a été cochée et que le contenu de la cellule "Type" est égal à "Dossier"
                                foreach (DirectoryInfo dir in Directories)
                                {
                                    //Alors on parcours les sous-dossiers du dossier de téléchargement, stockés dans dir
                                    if (dir.Name.ToString() == d.Cells[ColumnNom.Name].Value.ToString())
                                    {
                                        //Si le nom du dossier actuel dans le dossier de téléchargement est égal au nom du fichier contenu dans la ligne du DataGridView
                                        dir.Delete(true); //Alors on supprime en désactivant la confirmation
                                    }
                                }
                            }
                        }
                    }
                    CleanerXpress.EspaceAp = Gestion_Verification.EspaceLibre();
                    MessageBox.Show("Le traitement est mainteant terminé, l'opération a permis de libérer " + Gestion_Verification.CalculEspaceLibere() + " Mo", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Gestion_Verification.Ecriture_Log();
                    dGV_Telechargement.Rows.Clear();
                    Telechargements_Load(sender, e);
                }
            }
            catch (Exception err)
            {
                //En cas d'erreur, affichage d'un message
                MessageBox.Show(err.Message);
            }
        }
        
        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur à cliqué sur le bouton tout sélectionner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ToutSelectionner_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in dGV_Telechargement.Rows)
            {
                //On parcours toutes les lignes du DataGridView
                if (Convert.ToBoolean(d.Cells[ColumnCheckBox.Name].Value) == false)
                {
                    //Si la colonne CheckBox de la ligne actuelle n'est pas cochée, alors on la coche
                    d.Cells[ColumnCheckBox.Name].Value = true;
                }
            }
        }

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur clique sur le bouton "Tout décocher"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ToutDecocher_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in dGV_Telechargement.Rows)
            {
                //On parcours toutes les ligne du DataGridView
                if (Convert.ToBoolean(d.Cells[ColumnCheckBox.Name].Value) == true)
                {
                    //Si la colonne CheckBox de la ligne actuelle est cochée, alors on la décoche
                    d.Cells[ColumnCheckBox.Name].Value = false;
                }
            }
        }
        #endregion

        #region Suppression automatique
        /// <summary>
        /// Cette méthode gère la suppression automatique des fichiers
        /// </summary>
        /// <param name="folder"></param>
        public static void SuppressAuto(string folder)
        {
            int i = 0;
            double espaceAv, espaceAp = 0;
            espaceAv = Gestion_Verification.EspaceLibre();
            dinfo = new DirectoryInfo(folder); //On récupère l'emplacement du dossier de téléchargement
            Directories = dinfo.GetDirectories();
            Files = dinfo.GetFiles();
            foreach (FileInfo file in Files)
            {
                //Pour chaque fichiers du dossier de téléchargement
                if (file.Extension == ".exe" || file.Extension == ".msi")
                {
                    //Si l'extension du ficher actuel est .exe ou .msi
                    i++;
                    file.Delete(); //Alors on le supprime
                }
                if ((Convert.ToInt16(file.LastAccessTime.Month) - Convert.ToInt16(DateTime.Now.Month) >= 2))
                {
                    //Si la date de dernier accès du ficher actuel est supérieur à 2 mois
                    i++;
                    file.Delete(); //Alors on le supprime
                }
            }
            if (i != 0)
            {
                //Si au moins un fichier a été supprimé, alors on affiche un message avec la taille libérée
                CleanerXpress.EspaceAp = Gestion_Verification.EspaceLibre();
                MessageBox.Show("Le traitement est terminé, " + Gestion_Verification.CalculEspaceLibere() + " Mo ont été libérés", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (i == 0)
                {
                    //Sinon on affiche un message qui annonce qu'aucun fichier n'a été supprimé
                    espaceAp = espaceAv;
                    MessageBox.Show("Aucun fichier n'a été supprimé car aucun ne correspondait à nos critères de sélection", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Gestion_Verification.Ecriture_Log();
        }
        #endregion

        /// <summary>
        /// Cette méthode s'exécute lorsque l'utilisateur clique sur l'un des headers du DataGridView
        /// Elle réalise un tri par ordre alphabétique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGV_Telechargement_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            if (dGV_Telechargement.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
            {
                if (e.ColumnIndex == newSortColumn)
                {
                    if (newColumnDirection == ListSortDirection.Ascending)
                        newColumnDirection = ListSortDirection.Descending;
                    else
                        newColumnDirection = ListSortDirection.Ascending;
                }

                newSortColumn = e.ColumnIndex;

                switch (newColumnDirection)
                {
                    case ListSortDirection.Ascending:
                        dGV_Telechargement.Sort(dGV_Telechargement.Columns[newSortColumn], ListSortDirection.Ascending);
                        break;
                    case ListSortDirection.Descending:
                        dGV_Telechargement.Sort(dGV_Telechargement.Columns[newSortColumn], ListSortDirection.Descending);
                        break;
                }
            }
        }
    }
}
