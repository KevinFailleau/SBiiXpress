using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.IO;
using System.Security.Principal;
using Microsoft.Win32;

namespace SBiiXpress
{
    public partial class Depannage : Form
    {
        #region Initialisation
        private double EspaceAv;
        private double EspaceAp;
        private bool isCCleanerPresent = true;
        public static RegistryView rV;
        public Depannage()
        {
            InitializeComponent();
            EspaceAv = EspaceLibre();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            lb_PourcentProg.Visible = false;
            lb_Progression.Visible = false;
            pb_Traitement.Visible = false;
            Verifications.VerifArchiOS();
        }
        
        #endregion

        #region Méthode de nettoyage

        private void btn_NettoyageDisque_Click(object sender, EventArgs e)
        {
            EspaceAv = EspaceLibre();
            if (Verifications.IsAdministrator() == true)
            {   //On teste si l'utilisateur actuel possède les droits d'administrateur, si c'est le cas on continue
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir continuer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {   //Si l'utilisateur valide, on affiche les données de progression sur l'écran de l'application Dépannage
                    this.lb_Progression.Visible = true;
                    this.lb_PourcentProg.Visible = true;
                    this.pb_Traitement.Visible = true;
                    this.btn_Optimisation.Enabled = false;
                    bgw.RunWorkerAsync(); //On lance le BackGroundWorker, qui permettra d'obtenir des informations sur la progression et éviter que l'application principale ne freeze lors du lancement des process
                }
            }
            else
            {
                bgw.RunWorkerAsync();
                this.btn_Optimisation.Enabled = false;
            }
        }

        #endregion

        #region Exécution de programme

        public Process p = new Process();

        /// <summary>
        /// Méthode qui permet de lancer une application avec des paramètres
        /// </summary>
        /// <param name="path">Chemin d'accès à l'application</param>
        /// <param name="args">Paramètres pour lancer l'application</param>
        public void Exec(string path, string args)
        {
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = args;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        /// <summary>
        /// Méthode qui permet de lancer une application sans paramètres
        /// </summary>
        /// <param name="path">Paramètres pour lancer l'application</param>
        public void Exec(string path)
        {
            p.StartInfo.FileName = path;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        #endregion

        #region Traitement Nettoyage et optimisation Administrateur / Invité

        public void Traitement()
        {
            if (Verifications.IsAdministrator())
            {
                Verifications.SuppOldSaveReg();
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory("C:\\SBiiXpress\\Save\\Registry");
                    Exec("regedit.exe", " /E C:\\SBiiXpress\\Save\\Registry\\Save_" + DateTime.Now.ToString("MM_dd_yyyy") + ".reg");
                    bgw.ReportProgress(10);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Impossible de sauvegarder le registre" + Environment.NewLine + err.Message, "SBiiXpress - Erreur lors de la sauvegarde du registre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bgw.ReportProgress(10);
                }
                Exec("rundll32.exe", " inetcpl.cpl,ClearMyTracksByProcess 4351");
                bgw.ReportProgress(25);
                if (ProcessEnCours("rundll32") == 1)
                {
                    if (File.Exists("C:\\Program Files\\CCleaner\\CCleaner.exe") == true)
                    {
                        Exec("CCleaner.exe", " /auto");
                    }
                    else
                    {
                        isCCleanerPresent = false;
                    }
                }
                bgw.ReportProgress(35);
                LectureEcritureRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", 2, RegistryValueKind.DWord, rV);
                bgw.ReportProgress(50);
                ecrireRegistre("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AlwaysUnloadDll", 1, RegistryValueKind.DWord, rV);
                bgw.ReportProgress(60);
                if (ProcessEnCours("CCleaner64") == 1)
                {
                    Exec("cleanmgr.exe", " /sagerun:0666");
                }
                bgw.ReportProgress(70);
                Exec("cmd", " /c net stop wuauserv");
                Exec("cmd", "/c rd /s /Q %Windir%\\SoftwareDistribution");
                bgw.ReportProgress(80);
                if (ProcessEnCours("cleanmgr") == 1)
                {
                    bgw.ReportProgress(100);
                    Exec("cmd", " /c net start wuauserv");
                }
            }
            else
            {
                //Cette partie est réservée aux utilisateurs invités, le traitement est donc plus limité car les droits sont nécessaires pour certaines fonctionnalités
                Exec("rundll32.exe", " inetcpl.cpl,ClearMyTracksByProcess 4351");
                if (ProcessEnCours("rundll32") == 1) //On vérifie que RunDll32 ait terminé pour pouvoir tenter de lancer CCleaner
                {
                    if (File.Exists("C:\\Program Files\\CCleaner\\CCleaner.exe") == true) //On vérifie que le fichier CCleaner.exe existe pour pouvoir le lancer
                    {
                        Exec("CCleaner.exe", " /auto"); //Lancement de CCleaner en mode automatique
                    }
                    else
                    {
                        isCCleanerPresent = false;
                    }
                }
                
            }
        }
        #endregion

        #region Lancement de l'outil de défragmentation de Windows

        private void btn_Defrag_Click(object sender, EventArgs e)
        {
            Exec("defrag", "/C");
        }

        #endregion

        #region Méthode de test et de calcul
        /// <summary>
        /// Récupère l'espace libre du lecteur C:\
        /// </summary>
        /// <returns>Retourne l'espace libre du lecteur C:\</returns>
        private double EspaceLibre() //Méthode à revoir, les résultats semblent erronnés
        {
            double Espace = 0;

            foreach (DriveInfo CurrentDrive in DriveInfo.GetDrives()) //On parcours la liste des disques dur disponibles sur la machine
            {
                if (CurrentDrive.DriveType == DriveType.Fixed && CurrentDrive.Name == "C:\\")//Si le disque dur sélectionné par le foreach est de type fixe et sa lettre de lecteur est C:, alors on récupère la taille totale et l'espace libre
                {
                    Espace = CurrentDrive.AvailableFreeSpace; //Permet de determiner l'espace disponible sur le disque C:
                }
            }
            return Espace;
        }

        /// <summary>
        /// Calcule l'espace qui a été libéré pendant la phase de nettoyage
        /// </summary>
        /// <returns>Quantité libérée</returns>
        private double CalculEspaceLibere()
        {
            double EspaceGagne;
            EspaceGagne = EspaceAp - EspaceAv; //On obtient l'espace libréré en octets
            EspaceGagne = (EspaceGagne / 1024) / 1024; //Convertion du résultat en Mo
            EspaceGagne = Math.Round(EspaceGagne, 2); //On ne garde que 2 chiffres après la virgule
            if (EspaceGagne <= 0)
            {   
                //Ce teste permet de supprimer un éventuel signe moins devant la somme libérée lors de l'affichage final
                EspaceGagne = EspaceAv - EspaceAp;  //On réalise l'opération inverse à celle effectuée plus tôt
                EspaceGagne = (EspaceGagne / 1024) / 1024;
                EspaceGagne = Math.Round(EspaceGagne, 2);
            }
            return EspaceGagne;
        }

        /// <summary>
        /// Cette méthode permet de vérifier si un processus précis est déjà en cours d'exécution sur la machine
        /// </summary>
        /// <param name="process">Contient le nom du processus à rechercher</param>
        /// <returns>Retourne la valeur 2 si au moins un processus recherché est déjà en cours</returns>

        private int ProcessEnCours(string process)
        {
            int enCours = 0;
            while (enCours != 1)
            {
                if (Process.GetProcessesByName(process).Length != 0)
                {
                    enCours = 2;
                }
                else
                {
                    enCours = 1;
                }
            }
            return enCours;
        }
        #endregion

        #region Lecture / parcours et modification de la base de registre

        /// <summary>
        /// Cette méthode permet d'ajouter une valeur (définie en paramètre) dans la base de registre
        /// </summary>
        /// <param name="path">Contient le chemin de la clé à ajouter</param>
        /// <param name="valueName">Contient le nom de la valeur à ajouter</param>
        /// <param name="value">Contient la valeur à ajouter</param>
        /// <param name="valueKind">Contient le type de valeur</param>

        private void ecrireRegistre(string path, string valueName, int value, RegistryValueKind valueKind, RegistryView rV)
        {
            
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV); //Ouvre un nouveau RegistryKey qui représente la clé demandée sur l'ordinateur local avec la vue spécifiée.
            var reg = baseReg.CreateSubKey(path); //Création d'une variable avec le chemin spécifié

            try
            {
                reg = baseReg.OpenSubKey(path, true); //On tente d'ouvrir la sous-clé avec le chemin indiqué

                if (reg == null)
                {
                    baseReg.CreateSubKey(path); //Si il est impossible d'ouvrir cette sous-clé, on la crée
                }

                reg.SetValue(valueName, value, valueKind); //Ensuite on défini la valeur, le nom et le type de la valeur pour cette sous-clé
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop); //En cas d'erreur, on affiche un message
            }
            finally
            {
                baseReg.Close();
            }
        }

        /// <summary>
        /// Cette méthode permet de parcourir une partie de la base de registre et d'ajouter une valeur dans chacune des sous-clés souhaitées
        /// </summary>
        /// <param name="pathLecture">Chemin d'accès</param>
        /// <param name="valueName">Nom de la valeur</param>
        /// <param name="value">Valeur à ajouter</param>
        /// <param name="valueKind">Type de valeur à ajouter</param>

        private void LectureEcritureRegistre(string pathLecture, string valueName, int value, RegistryValueKind valueKind, RegistryView rV)
        {
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV); //Ouvre un nouveau RegistryKey qui représente la clé demandée sur l'ordinateur local avec la vue spécifiée.
            var SubKey = baseReg.OpenSubKey(pathLecture); //Création d'une variable avec le chemin spécifié

            foreach (string sub in SubKey.GetSubKeyNames())
            {
                string ps = pathLecture + sub; //Pour chaque sous-clé d'une clé précise, on stocke le chemin de la clé et le nom de la sous-clé afin d'avoir le chemin complet
                var baseRegEcriture = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV);
                var reg = baseRegEcriture.CreateSubKey(ps); //Ici on créer un variable qui permettra de créer ou non une variable dans la sous-clé passé en paramètre (ps)

                try
                {
                    reg = baseReg.OpenSubKey(ps, true); //On ouvre la sous-clé avec le chemin spécifié
                    reg.SetValue(valueName, value, valueKind); //On crée la valeur dans la sous clé avec les informations renseignées
                }
                catch (Exception er)
                {
                    //En cas d'erreur on affiche un message
                    MessageBox.Show(er.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    baseReg.Close();
                }
                RegistryKey local = Registry.Users;
                local = SubKey.OpenSubKey(sub, true);
            }
        }

        /// <summary>
        /// Cette méthode permet de supprimer une valeur de la base de registre
        /// </summary>
        /// <param name="pathLecture">Chemin de la valeur</param>
        /// <param name="valueName">Nom de la valeur a supprimer</param>
        public void SupprimerValeurRegistre(string pathLecture, string valueName, RegistryView rV)
        {
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV); //Ouvre un nouveau RegistryKey qui représente la clé demandée sur l'ordinateur local avec la vue spécifiée.
            var SubKey = baseReg.OpenSubKey(pathLecture); //Création d'une variable avec le chemin spécifié

            foreach (string sub in SubKey.GetSubKeyNames())
            {
                string ps = pathLecture + sub; //Pour chaque sous-clé d'une clé précise, on stocke le chemin de la clé et le nom de la sous-clé afin d'avoir le chemin complet
                var baseRegEcriture = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV);
                var reg = baseRegEcriture.CreateSubKey(ps); //Ici on créer un variable qui permettra de créer ou non une variable dans la sous-clé passé en paramètre (ps)

                try
                {
                    reg = baseReg.OpenSubKey(ps, true); //On tente d'accéder à la sous-clé
                    reg.DeleteValue(valueName);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    baseReg.Close();
                }
                RegistryKey local = Registry.Users;
                local = SubKey.OpenSubKey(sub, true);
            }
        }

        #endregion

        #region BackgroundWorker
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Traitement();
       }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lb_PourcentProg.Text = (e.ProgressPercentage.ToString() + "%"); //Mise à jour du pourcentage de progression sur la Form dépannage
            this.pb_Traitement.Value = e.ProgressPercentage; //Mise à jour de la barre de progression sur la Form dépannage (mode Administrateur uniquement)
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.lb_Progression.Text = ("Erreur"); //Si l'application rencontre une erreur, on affiche "Erreur" dans le statut de progression de la Form dépannage
                MessageBox.Show("L'application à rencontré une erreur : " + e.Error.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); //Affichage d'un message d'erreur avec détails
            }
            else
            {
                //Si l'application ne rencontre pas d'erreur, on continue ici
                System.Threading.Thread.Sleep(5000); //On fait une petite pause de 5s pour que CCleaner puisse avoir le temps de se lancer
                if (!isCCleanerPresent)
                {
                    //Si CCleaner n'est pas installé, on affiche le message suivant
                    EspaceAp = EspaceLibre();
                    MessageBox.Show("Le nettoyage est terminé cependant vous pourriez obtenir de meilleurs résultats en installant CCleaner" + Environment.NewLine + CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!isCCleanerPresent && Verifications.IsAdministrator())
                    {
                        SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                        EspaceAp = EspaceLibre();
                        MessageBox.Show("Le nettoyage est terminé cependant vous pourriez obtenir de meilleurs résultats en installant CCleaner" + Environment.NewLine + CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (!Verifications.IsAdministrator() && ProcessEnCours("CCleaner64") == 1 || !Verifications.IsAdministrator() && ProcessEnCours("CCleaner") == 1) //On vérifie que CCleaner ait fini pour afficher le message final
                    {
                        //Si l'utilisateur n'est pas Admin et que CCleaner à terminé, on affiche le message suivant
                        EspaceAp = EspaceLibre();
                        MessageBox.Show("Le nettoyage est maintenant terminé, cependant, vous obtiendrez de meilleurs résultats en mode administrateur" + Environment.NewLine + CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Si tout est fini et que l'utilisateur est Admin, on affiche le message suivant
                        EspaceAp = EspaceLibre();
                        MessageBox.Show("Le nettoyage est maintenant terminé. \n" + CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                    }
                }
                this.lb_PourcentProg.Visible = false;
                this.lb_Progression.Visible = false;
                this.pb_Traitement.Visible = false;
                this.btn_Optimisation.Enabled = true;
            }
        }
        #endregion

        private void btn_Options_Click(object sender, EventArgs e)
        {
            Options FO = new Options();
            FO.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Options.Cleanmgr && Options.CCleaner && Options.IE && Options.Reg && Options.WinUp)
            {
                MessageBox.Show("Vous avez sélectionné le nettoyage complet", "Nettoyage complet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Au moins une des cinq options n'a pas été cochée");
            }
        }

    }
}
