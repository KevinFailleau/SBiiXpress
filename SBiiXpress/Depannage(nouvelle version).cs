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
using System.Management;
using System.IO;
using System.Security.Principal;
using Microsoft.Win32;
#endregion

namespace SBiiXpress
{
    public partial class Depannage : Form
    {
        #region Variables
        private static double espaceAv;
        private static double espaceAp;
        private static bool isCCleanerPresent = true;
        public static RegistryView rV;
        private Process p = new Process();
        #endregion

        #region Constructeur
        /// <summary>
        /// Méthode d'initialisation de la form Depannage
        /// </summary>
        public Depannage()
        {
            InitializeComponent();
            if (!Gestion_Verification.IsAdministrator())
                cB_veille.Enabled = false;
            if (Gestion_Verification.getOSVer() == "XP")
            {
                Gestion_Verification.RechercheCCleaner();
                EspaceAv = Gestion_Verification.EspaceLibre();
                cB_veille.Visible = false;
                bgw.WorkerSupportsCancellation = true;
                bgw.WorkerReportsProgress = true;
                lb_PourcentProg.Visible = false;
                lb_Progression.Visible = false;
                pb_Traitement.Visible = false;
                Gestion_Verification.VerifArchiOS();
            }
            else
            {
                Gestion_Verification.RechercheCCleaner();
                EspaceAv = Gestion_Verification.EspaceLibre();
                Hibernation();
                bgw.WorkerSupportsCancellation = true;
                bgw.WorkerReportsProgress = true;
                lb_PourcentProg.Visible = false;
                lb_Progression.Visible = false;
                pb_Traitement.Visible = false;
                Gestion_Verification.VerifArchiOS();
            }
        }
        #endregion

        #region Accesseurs

        public static bool IsCCleanerPresent
        {
            get
            {
                return isCCleanerPresent;
            }

            set
            {
                isCCleanerPresent = value;
            }
        }

        public static double EspaceAv
        {
            get
            {
                return espaceAv;
            }

            set
            {
                espaceAv = value;
            }
        }

        public static double EspaceAp
        {
            get
            {
                return espaceAp;
            }

            set
            {
                espaceAp = value;
            }
        }
        #endregion

        #region Gestion boutons
        /// <summary>
        /// Méthode qui gère le lancement du traitement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NettoyageDisque_Click(object sender, EventArgs e)
        {
            if (!Options.IE && Options.CCleaner && !IsCCleanerPresent)
            {
                MessageBox.Show("Impossible de démarrer le traitement, CCleaner est introuvable", "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp)
                {
                    //Si aucune des options n'est sélectionné, on affiche un message d'erreur
                    MessageBox.Show("Au moins une option doit être cochée pour démarrer le traitement", "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EspaceAv = Gestion_Verification.EspaceLibre(); //Calcul de l'espace disque disponible avant traitement
                    if (Gestion_Verification.IsAdministrator() == true)
                    {   //On teste si l'utilisateur actuel possède les droits d'administrateur, si c'est le cas on continue
                        DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir continuer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {   //Si l'utilisateur valide, on affiche les données de progression sur l'écran de l'application Dépannage
                            this.lb_PourcentProg.Text = "0%";
                            this.lb_Progression.Visible = true;
                            this.lb_PourcentProg.Visible = true;
                            this.pb_Traitement.Visible = true;
                            this.btn_Optimisation.Enabled = false;
                            bgw.RunWorkerAsync(); //On lance le BackGroundWorker, qui lancera le traitement et qui permettra d'obtenir des informations sur la progression et éviter que l'application principale ne freeze lors du lancement des process
                        }
                    }
                    else
                    {   //Si l'utilisateur ne possède pas les droits d'administrateur, on lance simplement le BackGroundWorker et on désactive le bouton des options
                        bgw.RunWorkerAsync();
                    }
                }
            }
        }
        
        /// <summary>
        /// cette méthode affiche simplement la form pour la séléction des options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Options_Click(object sender, EventArgs e)
        {
            Options FO = new Options();
            FO.Show();
        }

        private void btn_Journal_Click(object sender, EventArgs e)
        {
            Journal FJ = new Journal();
            FJ.Show();
        }

        /// <summary>
        /// Cette méthode gère la CheckBox pour la mise en vielle, elle s'active lorsque l'utilisateur coche ou décoche la case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_veille_MouseClick(object sender, MouseEventArgs e)
        {
            if (cB_veille.Checked)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir activer la mise en veille prolongée ?\n Cette action n'est pas recommandée", "SBiiXpress - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Gestion_Verification.ecrireRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 1, RegistryValueKind.DWord, rV);
                }
            }
            else
            {
                Gestion_Verification.ecrireRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 0, RegistryValueKind.DWord, rV);
            }
        }

        #endregion

        #region Exécution de programme
        
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
            try
            {
                p.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show("Impossible d'effectuer l'opération demandée \n" + err, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            try
            {
                p.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show("Impossible d'effectuer l'opération demandée \n" + err, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Traitement Nettoyage et optimisation Administrateur / Invité

        /// <summary>
        /// Méthode qui permet de réaliser une sauvegarde de la base de registre
        /// </summary>
        public void saveRegistre()
        {
            if (Gestion_Verification.IsAdministrator()) //Vérification des droits
            {
                Gestion_Verification.SuppOldSaveReg(); //On vérifie le nombre de sauvegardes présente dans le dossier, si plus d'une sauvegarde est présente, on supprime la plus ancienne
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory("C:\\SBiiXpress\\Save\\Registry");
                    Exec("regedit.exe", " /E C:\\SBiiXpress\\Save\\Registry\\Save_" + DateTime.Now.ToString("dd_MM_yyyy") + ".reg"); //Création du fichier de sauvegarde avec la date actuelle
                    bgw.ReportProgress(10);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Impossible de sauvegarder le registre" + Environment.NewLine + err.Message, "SBiiXpress - Erreur lors de la sauvegarde du registre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bgw.ReportProgress(10);
                }
            }
        }

        /// <summary>
        /// Cette méthode lance le processus de nettoyage de Internet Explorer
        /// </summary>
        public void ClearIE()
        {
            Exec("rundll32.exe", " inetcpl.cpl,ClearMyTracksByProcess 4351");
        }

        /// <summary>
        /// Cette méthode permet de lancer CCleaner en mode automatique et également de vérifier la présence de celui-ci
        /// </summary>
        public void CCleaner()
        {
            if (File.Exists("C:\\Program Files\\CCleaner\\CCleaner.exe"))
            {
                //Si CCleaner est présent alors on l'exécute
                Exec("CCleaner.exe", " /auto");
            }
            else
            {
                //Si CCleaner est introuvable alors la variable isCCleanerPresent passe à faux
                IsCCleanerPresent = false;
            }
        }
        
        /// <summary>
        /// Cette méthode permet d'écrire dans le registre une valeur permettant de décharger automatiquement les DLL inutilisées
        /// </summary>
        public void DechargDll()
        {
            Gestion_Verification.ecrireRegistre("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AlwaysUnloadDll", 1, RegistryValueKind.DWord, rV);
        }

        /// <summary>
        /// Cette méthode permet de lancer l'outil de Nettoyage de disque de Windows en mode complet
        /// </summary>
        public void CleanMgrAll()
        {
            Gestion_Verification.LectureEcritureRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", 2, RegistryValueKind.DWord, rV);
            //On ajoute un flag sur toutes les options qui seront concernées par le nettoyage
            Exec("cleanmgr.exe", " /sagerun:0666");
            //On exécute le nettoyage en précisant le nom du flag correspondant aux valeurs à supprimer
        }

        /// <summary>
        /// Cette méthode permet de nettoyer le cache de Windows Update
        /// </summary>
        public void ClearWinUpdate()
        {
            if (Gestion_Verification.CheckService("wuauserv") == "Lancé" || Gestion_Verification.CheckService("wuauserv")== "En cours de démarrage")
            {
                Exec("cmd", " /c net stop wuauserv"); //On arrête le service de Windows Update
                System.Threading.Thread.Sleep(2000); //On stoppe le programme le temps que le service s'arrête
                Exec("cmd", "/c rd /s /Q %Windir%\\SoftwareDistribution"); //On supprime tout le dossier qui contient les fichiers de Windows Update
                System.Threading.Thread.Sleep(2000); //On refait une pause le temps que les fichiers soient supprimés 
                Exec("cmd", " /c net start wuauserv"); //Puis on redémarre le service de Windows Update
            }
            else
                if (Gestion_Verification.CheckService("wuauserv") == "Stoppé" || Gestion_Verification.CheckService("wuauserv") == "Arrêt en cours")
            {
                Exec("cmd", " /c net stop wuauserv"); //On arrête le service de Windows Update
                System.Threading.Thread.Sleep(2000); //On stoppe le programme le temps que le service s'arrête
                Exec("cmd", "/c rd /s /Q %Windir%\\SoftwareDistribution"); //On supprime tout le dossier qui contient les fichiers de Windows Update
            }
        }

        public void Hibernation()
        {
            int val = Convert.ToInt16(Gestion_Verification.LectureValCleRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled"));
            if (val == 1)
            {
                cB_veille.Checked = true;
                MessageBox.Show("Nous avons détecté que la mise en veille prolongée est activée, nous vous recommandons de la desactiver", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cB_veille.Checked = false;
            }
        }
        #endregion

        #region Traitement principal

        /// <summary>
        /// Cette méthode contient le traitement principal de l'application
        /// </summary>
        public void Traitement()
        {
            if (Gestion_Verification.IsAdministrator()) //On vérifie les droits de l'utilisateur
            {
                gb_Operation.Invoke((MethodInvoker)delegate { gb_Operation.Enabled = false; });
                gB_OptionsInfos.Invoke((MethodInvoker)delegate {gB_OptionsInfos.Enabled = false;});
                //gb_Operation.Enabled = false;
                //gB_OptionsInfos.Enabled = false;
                if (Options.Reg)
                {
                    saveRegistre(); //Si l'option de sauvegarde de registre est cochée alors on lance la sauvegarde
                }
                bgw.ReportProgress(25); //Mise à jour de la ProgressBar et du label de progression
                if (Options.IE)
                {
                    ClearIE(); //Si l'option de nettoyage de Internet Explorer est cochée alors on lance le nettoyage
                }
                bgw.ReportProgress(35);
                if (Options.CCleaner)
                {
                    if (Gestion_Verification.ProcessEnCours("rundll.exe") == 1)
                    {
                        CCleaner(); //Si l'option CCleaner est cochée et si le processus de nettoyage de IE n'est pas en cours, alors on exécute CCleaner
                    }
                }
                bgw.ReportProgress(45);
                if (Options.Cleanmgr)
                {
                    if (Gestion_Verification.ProcessEnCours("CCleaner") == 1 || Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll.exe") == 1 )
                    {
                        CleanMgrAll(); //Si l'option de nettoyage de disque Windows est cochée et que tous les processus précedents sont terminés, alors on exécute Cleanmgr.exe
                    }
                }
                bgw.ReportProgress(60);
                if (Options.WinUp)
                {
                    if (Gestion_Verification.ProcessEnCours("CCleaner") == 1  || Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("rundll.exe") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                    {
                        ClearWinUpdate(); //Si l'option de nettoyage de Windows Update est cochée et que tous les processus précédents sont terminés alors on nettoie le cache de Windows Update
                    }
                }
                bgw.ReportProgress(80);
                if (Options.DechargDll)
                {
                    DechargDll(); //Ajout de la valeur permettant de décharger les DLL inutiles si l'option a été cochée
                }
                bgw.ReportProgress(100);
            }
            else
            {
                btn_Options.Invoke((MethodInvoker)delegate { btn_Options.Enabled = false; }); //Cette ligne permet de désactiver le bouton Options au lancement du traitement simple, sans générer d'erreur
                btn_Journal.Invoke((MethodInvoker)delegate { btn_Journal.Enabled = false; });
                btn_Optimisation.Invoke((MethodInvoker)delegate { btn_Optimisation.Enabled = false; });
                btn_Defrag.Invoke((MethodInvoker)delegate { btn_Defrag.Enabled = false; });
                //this.btn_Journal.Enabled = false;
                //this.btn_Optimisation.Enabled = false;
                //this.btn_Defrag.Enabled = false;
                if (Options.CCleaner && !Options.IE)
                { 
                    CCleaner(); //Si seul l'option CCleaner est cochée, alors on ne lance que CCleaner
                }
                else
                    if (Options.IE && !Options.CCleaner)
                {
                    ClearIE(); //Si seul l'option de nettoyage de Internet Explorer est cochée alors on n'exécute que ce nettoyage
                }
                else
                {   //Si les deux options sont cochées
                    ClearIE(); //On exécute le nettoyage de Internet Explorer
                    if (Gestion_Verification.ProcessEnCours("rundll32.exe") == 1) //On attends que le nettoyage de Internet Explorer soit terminé
                    {
                        CCleaner(); //Lorsque le processus précédent est terminé, on lance CCleaner
                    }
                }
            }
        }
            #endregion

        #region Lancement de l'outil de défragmentation de Windows

        /// <summary>
        /// Cette méthode gère le bouton de défragmentation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Defrag_Click(object sender, EventArgs e)
        {
            try
            {
                Exec("defrag", "/C");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Impossible de démarrer le programme de défragmentation", "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region BackGroundWorker
        
        /// <summary>
        /// Méthode de lancement du BackGroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker; //Création d'un BackGroundWorker
            Traitement(); //Lancement du traitement
       }

        /// <summary>
        /// Méthode qui gère la progression du traitement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lb_PourcentProg.Text = (e.ProgressPercentage.ToString() + "%"); //Mise à jour du pourcentage de progression sur la Form dépannage
            this.pb_Traitement.Value = e.ProgressPercentage; //Mise à jour de la barre de progression sur la Form dépannage (mode Administrateur uniquement)
        }

        /// <summary>
        /// Méthode qui gère la fin du traitement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.lb_Progression.Text = ("Erreur"); //Si l'application rencontre une erreur, on affiche "Erreur" dans le statut de progression de la Form dépannage
                MessageBox.Show("L'application à rencontré une erreur : " + e.Error.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); //Affichage d'un message d'erreur avec détails
            }
            else
            {
                if (!IsCCleanerPresent && Gestion_Verification.IsAdministrator()) //Vérification des droits et de la présence de CCleaner
                {
                    if (Options.Reg && Options.DechargDll && !Options.Cleanmgr && !Options.IE && !Options.WinUp)
                    {
                        EspaceAp = espaceAv;
                        MessageBox.Show("Le registre à bien été sauvegardé et les DLL inutiles seront desormais déchargés automatiquement", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    if (Options.Reg && !Options.IE && !Options.Cleanmgr && !Options.WinUp && !Options.DechargDll)
                    {
                        EspaceAp = espaceAv;
                        MessageBox.Show("La sauvegarde du registre a bien été effectuée", "SBiiXpress - Sauvegarde terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (Options.DechargDll && !Options.Reg && !Options.IE && !Options.Cleanmgr && !Options.WinUp)
                        {
                            EspaceAp = espaceAv;
                            MessageBox.Show("Les DLL inutiles seront désormais automatiquement déchargés", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (!Options.Cleanmgr)
                            {
                                if (Gestion_Verification.ProcessEnCours("rundll32.exe") == 1)
                                {
                                    EspaceAp = Gestion_Verification.EspaceLibre();
                                    MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner\n " + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (Gestion_Verification.ProcessEnCours("cleanmgr.exe") == 1)
                                {
                                    EspaceAp = Gestion_Verification.EspaceLibre();
                                    MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                                }
                            }
                        }
                    this.lb_PourcentProg.Visible = false;
                    this.lb_Progression.Visible = false;
                    this.pb_Traitement.Visible = false;
                    this.btn_Optimisation.Enabled = true;
                    this.gb_Operation.Enabled = true;
                    this.gB_OptionsInfos.Enabled = true;
                    Gestion_Verification.ecriture_Log();
                }
                else
                {
                    if (!IsCCleanerPresent && !Gestion_Verification.IsAdministrator())
                    {
                        //Si CCleaner n'est pas installé, on affiche le message suivant
                        EspaceAp = Gestion_Verification.EspaceLibre();
                        MessageBox.Show("Le nettoyage est terminé cependant vous pourriez obtenir de meilleurs résultats en installant CCleaner\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (!Gestion_Verification.IsAdministrator() && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 || !Gestion_Verification.IsAdministrator() && Gestion_Verification.ProcessEnCours("CCleaner") == 1) //On vérifie que CCleaner ait fini pour afficher le message final
                        {
                            //Si l'utilisateur n'est pas Admin et que CCleaner à terminé, on affiche le message suivant
                            EspaceAp = Gestion_Verification.EspaceLibre();
                            MessageBox.Show("Le nettoyage est maintenant terminé, cependant, vous obtiendrez de meilleurs résultats en mode administrateur\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_Journal.Enabled = true;
                            btn_Options.Enabled = true;
                        }
                        else if (Gestion_Verification.IsAdministrator() && Gestion_Verification.ProcessEnCours("CCleaner") == 1 ||Gestion_Verification.IsAdministrator() && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr.exe") == 1 && Gestion_Verification.ProcessEnCours("rundll.exe") == 1)
                        {
                            if (Options.Cleanmgr && Options.DechargDll && !Options.Cleanmgr && !Options.IE && !Options.Reg && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre à bien été sauvegardé et les DLL inutiles seront desormais déchargés automatiquement", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Reg && !Options.CCleaner && !Options.DechargDll && !Options.IE && !Options.Cleanmgr && !Options.WinUp)
                            {
                                //Si seule la sauvegarde du registre à été cochée et qu'elle s'est bien terminée alors on affiche le message suivant
                                EspaceAp = espaceAv;
                                MessageBox.Show("La sauvegarde du registre à bien été éffectuée", "SBiiXpress - Sauvegarde terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.Cleanmgr || Options.DechargDll)
                                {
                                    //Si le nettoyage de Windows et le déchargement des DLL a été cochée alors on réalise le traitement suivant
                                    if (Options.DechargDll && !Options.Cleanmgr)
                                    {
                                        //Si seule le déchargement des DLL a été cochée, on affiche le message suivant
                                        EspaceAp = espaceAv;
                                        MessageBox.Show("Les DLL inutiles seront desormais automatiquement déchargées", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Si le nettoyage de Windows a été sélectionné et que tout s'est bien passé, alors on affiche le message suivant
                                        EspaceAp = Gestion_Verification.EspaceLibre();
                                        MessageBox.Show("Le nettoyage est maintenant terminé.\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                                        //On supprime les flags qui ont étés ajoutés au registre pour le nettoyage de Windows
                                    }
                                }
                                else
                                {
                                    //Si le nettoyage de Windows n'a pas été sélectionné et que tout s'est bien passé, alors on affiche le message suivant
                                    EspaceAp = Gestion_Verification.EspaceLibre();
                                    MessageBox.Show("Le nettoyage est maintenant terminé.\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Nettoyage terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Ici on ne supprime pas les flags du registre, car pas de nettoyage Windows. Cette option permet d'éviter des messsages d'erreur à la fin de l'exécution du programme
                                }
                            }
                        }
                    }
                    this.lb_PourcentProg.Visible = false;
                    this.lb_Progression.Visible = false;
                    this.pb_Traitement.Visible = false;
                    this.btn_Optimisation.Enabled = true;
                    this.gb_Operation.Enabled = true;
                    this.gB_OptionsInfos.Enabled = true;
                    Gestion_Verification.ecriture_Log();
                }
            }
        }*/

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.lb_Progression.Text = ("Erreur"); //Si l'application rencontre une erreur, on affiche "Erreur" dans le statut de progression de la Form dépannage
                MessageBox.Show("L'application à rencontré une erreur : " + e.Error.Message, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); //Affichage d'un message d'erreur avec détails
            }
            else
            {
                if (Gestion_Verification.IsAdministrator()) //Utilisateur est admin
                {
                    if (isCCleanerPresent)
                    {
                        if (Options.Reg && Options.IE && Options.Cleanmgr && Options.WinUp && Options.DechargDll && Options.CCleaner)
                        {
                            if (Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                            }
                        }
                        else
                        {
                            if (Options.Reg && Options.DechargDll && !Options.IE && !Options.Cleanmgr && !Options.WinUp && !Options.CCleaner)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé et les DLL inutiles seront automatiquement déchargés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.DechargDll && !Options.Reg && !Options.IE && !Options.Cleanmgr && !Options.WinUp && !Options.CCleaner)
                                {
                                    EspaceAp = espaceAv;
                                    MessageBox.Show("Les DLL inutiles seront desormais déchargés automatiquement", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (Gestion_Verification.ProcessEnCours("cleanmgr") == 1 && Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                                    {
                                        EspaceAp = Gestion_Verification.EspaceLibre();
                                        MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        EspaceAp = Gestion_Verification.EspaceLibre();
                                        MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }

                    else //CCleaner n'est pas présent
                    {
                        if (Options.Reg && Options.IE && Options.WinUp && Options.DechargDll)
                        {
                            if (Gestion_Verification.ProcessEnCours("rundll32") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                            }
                        }
                        else
                        {
                            if (Options.Reg && Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé et les DLL inutiles seront automatiquement déchargés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.WinUp)
                                {
                                    EspaceAp = espaceAv;
                                    MessageBox.Show("Le registre a bien été sauvegardé", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.Reg && !Options.WinUp)
                                    {
                                        EspaceAp = espaceAv;
                                        MessageBox.Show("Les DLL inutiles seront desormais déchargés", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (Options.Cleanmgr && Gestion_Verification.ProcessEnCours("cleanmgr") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                                        {
                                            EspaceAp = Gestion_Verification.EspaceLibre();
                                            MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                                        }
                                        else
                                        {
                                            EspaceAp = Gestion_Verification.EspaceLibre();
                                            MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner", "SBiiXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    this.lb_PourcentProg.Visible = false;
                    this.lb_Progression.Visible = false;
                    this.pb_Traitement.Visible = false;
                    this.btn_Optimisation.Enabled = true;
                    this.gb_Operation.Enabled = true;
                    this.gB_OptionsInfos.Enabled = true;
                    Gestion_Verification.ecriture_Log();
                }
                else
                { //L'utilisateur n'est pas admin
                    if (IsCCleanerPresent) //Si CCleaner est présent
                    {
                        if (Options.CCleaner && Gestion_Verification.ProcessEnCours("CCleaner") == 1)
                        {
                            EspaceAp = Gestion_Verification.EspaceLibre();
                            MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if(Options.Cleanmgr && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {   //CCleaner n'est pas présent
                        if (Options.Cleanmgr && Gestion_Verification.ProcessEnCours("Cleanmgr") == 1)
                        {
                            EspaceAp = Gestion_Verification.EspaceLibre();
                            MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "SBiiXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    this.lb_PourcentProg.Visible = false;
                    this.lb_Progression.Visible = false;
                    this.pb_Traitement.Visible = false;
                    this.btn_Optimisation.Enabled = true;
                    this.gb_Operation.Enabled = true;
                    this.gB_OptionsInfos.Enabled = true;
                    Gestion_Verification.ecriture_Log();
                }
            }
        }
        #endregion
    }
}
