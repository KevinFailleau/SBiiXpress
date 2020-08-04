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
    public partial class CleanerXpress : Form
    {
        #region Variables
        private static double espaceAv;
        private static double espaceAp;
        private static bool isCCleanerPresent = true;
        /// <summary>
        /// rV est une variable, elle permet de différencier les bases de registres des OS 32 et 64bits
        /// </summary>
        public static RegistryView rV;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la form Depannage
        /// </summary>
        public CleanerXpress()
        {
            InitializeComponent();
            if (!Gestion_Verification.IsAdministrator())
                cB_veille.Enabled = false; cB_Restauration.Enabled = false; //Si l'utilisateur n'est pas administrateur, on désactive les CheckBox, car leur traitement necessite les droits d'administrateur
            if (Gestion_Verification.GetOSVer() == "XP")
            {   //Traitement a réaliser si l'OS actuel est XP
                EspaceAv = Gestion_Verification.EspaceLibre();
                RestaurationSysteme();
                cB_veille.Enabled = false;
                cB_Restauration.Enabled = true;
                bgw.WorkerSupportsCancellation = true;
                bgw.WorkerReportsProgress = true;
                lb_PourcentProg.Visible = false;
                lb_Progression.Visible = false;
                pb_Traitement.Visible = false;
                Gestion_Verification.VerifArchiOS();
                Gestion_Verification.RechercheCCleaner();
            }
            else
            {   //Si l'OS actuel est différent de XP
                EspaceAv = Gestion_Verification.EspaceLibre();
                Hibernation();
                bgw.WorkerSupportsCancellation = true;
                bgw.WorkerReportsProgress = true;
                lb_PourcentProg.Visible = false;
                lb_Progression.Visible = false;
                pb_Traitement.Visible = false;
                cB_Restauration.Enabled = false;
                Gestion_Verification.VerifArchiOS();
                Gestion_Verification.RechercheCCleaner();
            }
        }
        #endregion

        #region Accesseurs
        /// <summary>
        /// Accesseur pour la variable IsCCleanerPresent
        /// </summary>
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
        /// <summary>
        /// Accesseur pour la EspaceAv
        /// </summary>
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
        /// <summary>
        /// Accesseur pour EspaceAp
        /// </summary>
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
            if (Options.Telechargement && !Options.Superfetch && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp)
            {
                this.Invoke(new MethodInvoker(DossierDownloads));
            }
            else
            if (Options.Superfetch && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp && Gestion_Verification.GetOSVer() == "XP")
            {
                MessageBox.Show("Le traitement du service Superfetch n'est pas disponible sur cette version de Windows", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (!Options.IE && Options.CCleaner && !IsCCleanerPresent)
            {
                MessageBox.Show("Impossible de démarrer le traitement, CCleaner est introuvable", "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Options.Superfetch && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp && !Options.Telechargement)
                {
                    //Si aucune des options n'est sélectionné, on affiche un message d'erreur
                    MessageBox.Show("Au moins une option doit être cochée pour démarrer le traitement", "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EspaceAv = Gestion_Verification.EspaceLibre(); //Calcul de l'espace disque disponible avant traitement
                    if (Gestion_Verification.IsAdministrator() == true)
                    {   //On teste si l'utilisateur actuel possède les droits d'administrateur, si c'est le cas on continue
                        DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir continuer ?", "CleanerXpress - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {   //Si l'utilisateur valide, on affiche les données de progression sur l'écran de l'application Dépannage
                            lb_Avertissement.Visible = true;
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
                        lb_Avertissement.Visible = true;
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
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir activer la mise en veille prolongée ?\nCette action n'est pas recommandée", "CleanerXpress - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Gestion_Verification.ecrireRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 1, RegistryValueKind.DWord, rV); //Si l'utilisateur souhaite vraiment activer la mise en veille prolongée, alors on l'active depuis la base de registre
                }
                else
                    if (result == DialogResult.No)
                {
                    cB_veille.Checked = false;
                }

            }
            else
            {
                Gestion_Verification.ecrireRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 0, RegistryValueKind.DWord, rV); //Sinon si l'utilisateur décoche la case, on désactive la mise en veille prolongée depuis la base de registre
            }
        }
        
        /// <summary>
        /// Cette méthode gère la Checkbox pour la restauration système
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cB_Restauration_MouseClick(object sender, MouseEventArgs e)
        {
            if (Gestion_Verification.GetOSVer() == "XP") //On vérifie que l'OS actuel est XP
            {
                if (cB_Restauration.Checked) //Si la case a été coché
                {
                    DialogResult result = MessageBox.Show("Bien que cette action soit recommandée, elle supprimera tous les points de restauration\nÊtes-vous sûr de vouloir continuer ?", "CleanerXpress - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Gestion_Verification.ecrireRegistre(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "DisableSR", 1, RegistryValueKind.DWord, rV); //On défini la valeur de DisableSR à 1
                        Exec("cmd", "/c net stop srservice"); //On stoppe le service de Restauration système
                        Exec("cmd", "/c cacls \"C:\\Volume System Information\\\" /E /G " + Environment.UserName.ToString() + ":F"); //On applique des droits d'administration sur le dossier contenant les points de restauration système
                        Exec("cmd", "/c rmdir /S \"C:\\System Volume Information\\\" /Q"); //Puis on supprime le dossier
                    }
                    else
                    {
                        cB_Restauration.Checked = false; //Si la réponse à la MessageBox est non, alors on décoche la case Restauration
                    }
                }
                else
                    if (!cB_Restauration.Checked) //Si la case a été décochée
                    {
                        Gestion_Verification.ecrireRegistre(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "DisableSR", 0, RegistryValueKind.DWord, rV); //On défini la valeur de DisableSR à 0
                        Exec("cmd", "/c net start srservice"); //Et on démarre le service de restauration système
                    }
            }
        }

        #endregion

        #region Exécution de programme
        
        /// <summary>
        /// Méthode qui permet de lancer une application avec des paramètres
        /// </summary>
        /// <param name="path">Chemin d'accès à l'application</param>
        /// <param name="args">Paramètres pour lancer l'application</param>
        public static void Exec(string path, string args)
        {
            Process p = new Process();
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
                MessageBox.Show("Impossible d'effectuer l'opération demandée \n" + err, "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Méthode qui permet de lancer une application sans paramètres
        /// </summary>
        /// <param name="path">Paramètres pour lancer l'application</param>
        public static void Exec(string path)
        {
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                p.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show("Impossible d'effectuer l'opération demandée \n" + err, "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Options.Superfetch && Gestion_Verification.GetOSVer() != "XP")
                {
                    this.Invoke(new MethodInvoker(Superfetch));
                }
                bgw.ReportProgress(10);
                if (Options.Reg)
                {
                    this.Invoke(new MethodInvoker(saveRegistre)); //Si l'option de sauvegarde de registre est cochée alors on lance la sauvegarde
                }
                bgw.ReportProgress(25); //Mise à jour de la ProgressBar et du label de progression
                if (Options.IE)
                {
                    this.Invoke(new MethodInvoker(ClearIE)); //Si l'option de nettoyage de Internet Explorer est cochée alors on lance le nettoyage
                }
                bgw.ReportProgress(35);
                if (Options.CCleaner)
                {
                    if (Gestion_Verification.ProcessEnCours("rundll.exe") == 1)
                    {
                        this.Invoke(new MethodInvoker(CCleaner)); //Si l'option CCleaner est cochée et si le processus de nettoyage de IE n'est pas en cours, alors on exécute CCleaner
                    }
                }
                bgw.ReportProgress(45);
                if (Options.Cleanmgr)
                {
                    if (Gestion_Verification.ProcessEnCours("CCleaner") == 1 || Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll.exe") == 1 )
                    {
                        this.Invoke(new MethodInvoker(CleanMgrAll)); //Si l'option de nettoyage de disque Windows est cochée et que tous les processus précedents sont terminés, alors on exécute Cleanmgr.exe
                    }
                }
                bgw.ReportProgress(60);
                if (Options.WinUp)
                {
                    if (Gestion_Verification.ProcessEnCours("CCleaner") == 1  || Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("rundll.exe") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                    {
                        this.Invoke(new MethodInvoker(ClearWinUpdate)); //Si l'option de nettoyage de Windows Update est cochée et que tous les processus précédents sont terminés alors on nettoie le cache de Windows Update
                    }
                }
                bgw.ReportProgress(80);
                if (Options.DechargDll)
                {
                    this.Invoke(new MethodInvoker(DechargDll)); //Ajout de la valeur permettant de décharger les DLL inutiles si l'option a été cochée
                }
                if (Options.Telechargement)
                {
                    //Si Telechargement a été coché dans la form Options, alors on lance la méthode DossierDownloads
                    this.Invoke(new MethodInvoker(DossierDownloads));
                }
                bgw.ReportProgress(100);
            }
            else
            {
                btn_Options.Invoke((MethodInvoker)delegate { btn_Options.Enabled = false; }); //Cette ligne permet de désactiver le bouton Options au lancement du traitement simple, sans générer d'erreur
                btn_Journal.Invoke((MethodInvoker)delegate { btn_Journal.Enabled = false; });
                btn_Optimisation.Invoke((MethodInvoker)delegate { btn_Optimisation.Enabled = false; });
                btn_Defrag.Invoke((MethodInvoker)delegate { btn_Defrag.Enabled = false; });
                if (Options.Telechargement && !Options.CCleaner && !Options.IE)
                {
                    this.Invoke(new MethodInvoker(DossierDownloads));
                }
                else
                if (Options.CCleaner && !Options.IE && !Options.Telechargement)
                { 
                    this.Invoke(new MethodInvoker(CCleaner)); //Si seul l'option CCleaner est cochée, alors on ne lance que CCleaner
                }
                else
                    if (Options.IE && !Options.CCleaner && !Options.Telechargement)
                {
                    this.Invoke(new MethodInvoker(ClearIE)); //Si seul l'option de nettoyage de Internet Explorer est cochée alors on n'exécute que ce nettoyage
                }
                else
                {   //Si les deux options sont cochées
                    this.Invoke(new MethodInvoker(ClearIE)); //On exécute le nettoyage de Internet Explorer
                    if (Gestion_Verification.ProcessEnCours("rundll32.exe") == 1) //On attends que le nettoyage de Internet Explorer soit terminé
                    {
                        this.Invoke(new MethodInvoker(CCleaner)); //Lorsque le processus précédent est terminé, on lance CCleaner
                        if (Gestion_Verification.ProcessEnCours("CCleaner.exe") == 1)
                        {
                            this.Invoke(new MethodInvoker(DossierDownloads));
                        }
                    }
                }
            }
        }
        #endregion

        #region Méthodes traitement

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
                }
                catch (Exception err)
                {
                    MessageBox.Show("Impossible de sauvegarder le registre" + Environment.NewLine + err.Message, "CleanerXpress - Erreur lors de la sauvegarde du registre", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (IsCCleanerPresent)
            {
                Exec("CCleaner.exe", " /auto");
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
            Gestion_Verification.ParcoursEcritureRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", 2, RegistryValueKind.DWord, rV);
            //On ajoute un flag sur toutes les options qui seront concernées par le nettoyage
            Exec("cleanmgr.exe", " /sagerun:0666");
            //On exécute le nettoyage en précisant le nom du flag correspondant aux valeurs à supprimer
        }

        /// <summary>
        /// Cette méthode permet de nettoyer le cache de Windows Update
        /// </summary>
        public void ClearWinUpdate()
        {
            if (Gestion_Verification.CheckService("wuauserv") == "Lancé" || Gestion_Verification.CheckService("wuauserv") == "En cours de démarrage")
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

        /// <summary>
        /// Cette méthode vérifie l'état de la mise en veille prolongée
        /// </summary>
        public void Hibernation()
        {
            int val = Convert.ToInt16(Gestion_Verification.LectureValCleRegistre(@"SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled")); //Lecture de la valeur de la clé correspondante à la mise en veille prolongée
            if (val == 1) //Si la valeur est égale à 1
            {
                cB_veille.Checked = true; //On coche la case
                MessageBox.Show("Nous avons détecté que la mise en veille prolongée est activée, nous vous recommandons de la desactiver", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cB_veille.Checked = false;
            }
        }

        /// <summary>
        /// Cette méthode vérifie si la restauration système est désactivée, si c'est le cas alors la case Restauration
        /// de la form Dépannage est cochée
        /// </summary>
        public void RestaurationSysteme()
        {
            int val = Convert.ToInt16(Gestion_Verification.LectureValCleRegistre(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "DisableSR")); //Lecture dans la base de registre
            if (val == 1) //Si la valeur de la clé de la base de registre est égale à 1
            {
                cB_Restauration.Checked = true; //On coche la case de la form Dépannage
            }
            else
            {
                cB_Restauration.Checked = false; //Sinon, on ne la coche pas
            }
        }

        /// <summary>
        /// Cette méthode vérifie si le service Superfetch est lancé, si oui, alors il est arrêté
        /// </summary>
        public void Superfetch()
        {
            if (Gestion_Verification.GetOSVer() != "XP") // On vérifie que l'OS actuel n'est pas XP
            {
                if (Gestion_Verification.CheckService("superfetch") == "Lancé") //Vérification de l'état de Superfetch
                {
                    Exec("cmd", "/c net stop superfetch");
                    Exec("cmd", " /c sc config sysmain start= disabled");
                }
            }
        }

        /// <summary>
        /// Cette méthode permet de vérifier et de gérer le contenu du dossier Téléchargements
        /// </summary>
        public void DossierDownloads()
        {
            float tailleMo = 0;
            double tailleGo = 0;
            if (Gestion_Verification.GetOSVer() != "XP")
            {
                //Si l'OS n'est pas XP, alors le dossier de téléchargement est le suivant
                var folderPath = "%USERPROFILE%\\Downloads";
                var folder = Environment.ExpandEnvironmentVariables(folderPath); //On stocke le chemin du dossier dans une méthode capable de gérer les variables d'environnement
                if (Directory.Exists(folder)) //On vérifie que le dossier existe
                {
                    tailleMo = Gestion_Verification.FolderSize(folder, "Mo"); //On récupère la taille en Mo
                    tailleGo = Math.Round((tailleMo / 1024), 2); // Puis en Go
                    if (tailleMo >= 100)
                    {
                        //Si la taille du dossier est supérieure ou égale à 100Mo alors on propose le nettoyage
                        DialogResult result = MessageBox.Show("Votre dossier de téléchargement semble contenir des fichiers\nTrès souvent ces fichiers sont inutilisés\nEn les supprimant vous pourriez libérer " + tailleMo + " Mo, soit " + tailleGo + " Go\nSouhaitez-vous que le programme supprime automatiquement les fichiers inutiles ?\nCliquez sur \"Oui\" pour la suppression automatique, vous pouvez également cliquer sur \"Non\" pour faire une sélection manuelle", "CleanerXpress - Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.No)
                        {
                            //Si l'utilisateur clique sur "Non", la form Téléchargement apparaît
                            espaceAv = Gestion_Verification.EspaceLibre();
                            Telechargements FT = new Telechargements(folder); //On passe le chemin d'accès au dossier à la form
                            FT.Show();
                        }
                        else
                        if (result == DialogResult.Yes)
                        {
                            //Si l'utilisateur clique sur "Oui", alors la suppression automatique démarre
                            Telechargements.SuppressAuto(folder); //On passe le chemin d'accès à la méthode de suppression automatique
                        }
                    }
                    if (tailleMo <= 100 && Options.Telechargement && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.Superfetch && !Options.WinUp)
                    {
                        //Si la taille du dossier est inférieure à 100Mo et que seule la case de netoyyage du dossier de téléchargement a été coché, alors on affiche un message
                        MessageBox.Show("Votre dossier de téléchargement ne semble pas prendre beaucoup de place, le nettoyage est donc inutile", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (Gestion_Verification.GetOSVer() == "XP")
                {
                    //Si l'OS est XP, alors le dossier de téléchargement est situé a l'emplacement suivant
                    //Le traitement reste le même, il n'y a que l'emplacement du dossier qui change
                    var folderPath = @"%USERPROFILE%\Mes documents\Téléchargements";
                    var folder = Environment.ExpandEnvironmentVariables(folderPath);
                    if (Directory.Exists(folder))
                    {
                        tailleMo = Gestion_Verification.FolderSize(folder, "Mo");
                        tailleGo = Math.Round((tailleMo / 1024), 2);
                        if (tailleMo >= 100)
                        {
                            DialogResult result = MessageBox.Show("Votre dossier de téléchargement semble contenir des fichiers\nTrès souvent ces fichiers sont inutilisés\nEn les supprimant vous pourriez libérer " + tailleMo + " Mo, soit " + tailleGo + " Go\nSouhaitez-vous que le programme supprime automatiquement les fichiers inutiles ?\nCliquez sur \"Oui\" pour la suppression automatique, vous pouvez également cliquer sur \"Non\" pour faire une sélection manuelle", "CleanerXpress - Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                            if (result == DialogResult.No)
                            {
                                espaceAv = Gestion_Verification.EspaceLibre();
                                Telechargements FT = new Telechargements(folder);
                                FT.Show();
                            }
                            else
                                if (result == DialogResult.Yes)
                            {
                                Telechargements.SuppressAuto(folder);
                            }
                        }
                        if (tailleMo <= 100 && Options.Telechargement && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.Superfetch && !Options.WinUp)
                        {
                            MessageBox.Show("Votre dossier de téléchargement ne semble pas prendre beaucoup de place, le nettoyage est donc inutile", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        folderPath = @"%USERPROFILE%\Mes documents\Downloads";
                        folder = Environment.ExpandEnvironmentVariables(folderPath);
                        if (Directory.Exists(folder))
                        {
                            tailleMo = Gestion_Verification.FolderSize(folder, "Mo");
                            tailleGo = Math.Round((tailleMo / 1024), 2);
                            if (tailleMo >= 100)
                            {
                                DialogResult result = MessageBox.Show("Votre dossier de téléchargement semble contenir des fichiers\nTrès souvent ces fichiers sont inutilisés\nEn les supprimant vous pourriez libérer " + tailleMo + " Mo, soit " + tailleGo + " Go\nSouhaitez-vous que le programme supprime automatiquement les fichiers inutiles ?\nCliquez sur \"Oui\" pour la suppression automatique, vous pouvez également cliquer sur \"Non\" pour faire une sélection manuelle", "CleanerXpress - Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                if (result == DialogResult.No)
                                {
                                    espaceAv = Gestion_Verification.EspaceLibre();
                                    Telechargements FT = new Telechargements(folder);
                                    FT.Show();
                                }
                                else
                                if(result == DialogResult.Yes)
                                {
                                    Telechargements.SuppressAuto(folder);
                                }
                            }
                            if (tailleMo <= 100 && Options.Telechargement && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.Superfetch && !Options.WinUp)
                            {
                                MessageBox.Show("Votre dossier de téléchargement ne semble pas prendre beaucoup de place, le nettoyage est donc inutile", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
            //N'ayant pas encore trouvé de méthode pour accéder à l'outil de défragmentation Windows par les lignes de commandes
            //L'option de défragmentation est désactivée dans l'application
            MessageBox.Show("Fonctionnalité bientôt disponible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*try
            {
                Exec("defrag", "/C");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Impossible de démarrer le programme de défragmentation", "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.lb_Progression.Text = ("Erreur"); //Si l'application rencontre une erreur, on affiche "Erreur" dans le statut de progression de la Form dépannage
                MessageBox.Show("L'application à rencontré une erreur : " + e.Error.Message, "CleanerXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); //Affichage d'un message d'erreur avec détails
            }
            else
            {
                if (Gestion_Verification.IsAdministrator()) //Utilisateur est admin
                {
                    if (isCCleanerPresent)
                    {
                        if (Options.Reg && Options.IE && Options.Cleanmgr && Options.WinUp && Options.DechargDll && Options.CCleaner && Options.Telechargement)
                        {
                            if (Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                            }
                        }
                        else
                        {
                            if (Options.Superfetch && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp && !Options.Telechargement)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le service Superfetch à bien été traité", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Superfetch && Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.WinUp && !Options.Telechargement || Options.Superfetch && Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.Reg && !Options.IE && !Options.WinUp && !Options.Telechargement || Options.Superfetch && Options.Reg && Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.WinUp && !Options.Telechargement)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le traitement est maintenant terminé", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Reg && Options.DechargDll && !Options.IE && !Options.Cleanmgr && !Options.WinUp && !Options.CCleaner && !Options.Telechargement)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé et les DLL inutiles seront automatiquement déchargés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.Superfetch && !Options.WinUp && !Options.Telechargement)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.DechargDll && !Options.Reg && !Options.IE && !Options.Cleanmgr && !Options.WinUp && !Options.CCleaner && !Options.Telechargement)
                                {
                                    EspaceAp = espaceAv;
                                    MessageBox.Show("Les DLL inutiles seront desormais déchargés automatiquement", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (Gestion_Verification.ProcessEnCours("cleanmgr") == 1 && Gestion_Verification.ProcessEnCours("CCleaner") == 1 && Gestion_Verification.ProcessEnCours("CCleaner64") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                                    {
                                        EspaceAp = Gestion_Verification.EspaceLibre();
                                        MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        EspaceAp = Gestion_Verification.EspaceLibre();
                                        MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }

                    else //CCleaner n'est pas présent
                    {
                        if (Options.Reg && Options.IE && Options.WinUp && Options.DechargDll && Options.Superfetch)
                        {
                            if (Gestion_Verification.ProcessEnCours("rundll32") == 1 && Gestion_Verification.ProcessEnCours("cleanmgr") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                            }
                        }
                        else
                        {
                            if (Options.Superfetch && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le service Superfetch à bien été traité", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Superfetch && Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.WinUp || Options.Superfetch && Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.Reg && !Options.IE && !Options.WinUp || Options.Superfetch && Options.Reg && Options.DechargDll &&!Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le traitement est maintenant terminé", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            if (Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.Reg && !Options.Superfetch && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (Options.Reg && Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.WinUp)
                            {
                                EspaceAp = espaceAv;
                                MessageBox.Show("Le registre a bien été sauvegardé et les DLL inutiles seront automatiquement déchargés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.Reg && !Options.CCleaner && !Options.Cleanmgr && !Options.DechargDll && !Options.IE && !Options.WinUp)
                                {
                                    EspaceAp = espaceAv;
                                    MessageBox.Show("Le registre a bien été sauvegardé", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (Options.DechargDll && !Options.CCleaner && !Options.Cleanmgr && !Options.IE && !Options.Reg && !Options.WinUp)
                                    {
                                        EspaceAp = espaceAv;
                                        MessageBox.Show("Les DLL inutiles seront desormais déchargés", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (Options.Cleanmgr && Gestion_Verification.ProcessEnCours("cleanmgr") == 1 && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                                        {
                                            EspaceAp = Gestion_Verification.EspaceLibre();
                                            MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Gestion_Verification.SupprimerValeurRegistre(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches\\", "StateFlags0666", rV);
                                        }
                                        else
                                        {
                                            EspaceAp = Gestion_Verification.EspaceLibre();
                                            MessageBox.Show("Le nettoyage est maintenant terminé, cependant vous obtiendrez de meilleurs résultats en installant CCleaner", "CleanerXpress - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Désactivation de la progressBar et des labels de la form, réactivation des boutons
                    //Utilisation des MethodInvoker pour éviter les crashs
                    this.lb_Avertissement.Invoke((MethodInvoker)delegate { this.lb_Avertissement.Visible = false;});
                    this.lb_PourcentProg.Invoke((MethodInvoker)delegate { this.lb_PourcentProg.Visible = false; });
                    this.lb_Progression.Invoke((MethodInvoker)delegate { this.lb_Progression.Visible = false; });
                    this.pb_Traitement.Invoke((MethodInvoker)delegate { this.pb_Traitement.Visible = false; });
                    this.btn_Optimisation.Invoke((MethodInvoker)delegate { this.btn_Optimisation.Enabled = true; });
                    this.gb_Operation.Invoke((MethodInvoker)delegate { this.gb_Operation.Enabled = true; });
                    this.gB_OptionsInfos.Invoke((MethodInvoker)delegate { this.gB_OptionsInfos.Enabled = true; });
                    this.Invoke(new MethodInvoker(Gestion_Verification.Ecriture_Log));
                }
                else
                { //L'utilisateur n'est pas admin
                    if (IsCCleanerPresent) //Si CCleaner est présent
                    {
                        if (Options.CCleaner && Gestion_Verification.ProcessEnCours("CCleaner") == 1)
                        {
                            EspaceAp = Gestion_Verification.EspaceLibre();
                            MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (Options.IE && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                            {
                                EspaceAp = Gestion_Verification.EspaceLibre();
                                MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (Options.IE && Options.CCleaner && Options.Telechargement && Gestion_Verification.ProcessEnCours("rundll32") == 1 && Gestion_Verification.ProcessEnCours("CCleaner") == 1)
                                {
                                    EspaceAp = Gestion_Verification.EspaceLibre();
                                    MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    EspaceAp = Gestion_Verification.EspaceLibre();
                                    MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {   //CCleaner n'est pas présent
                        if (Options.IE && Gestion_Verification.ProcessEnCours("rundll32") == 1)
                        {
                            EspaceAp = Gestion_Verification.EspaceLibre();
                            MessageBox.Show("Le nettoyage est maintenant terminé\n" + Gestion_Verification.CalculEspaceLibere() + " Mo ont étés libérés", "CleanerXpress - Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //Désactivation de la progressBar et des labels de la form, réactivation des boutons
                    //Utilisation des MethodInvoker pour éviter les crashs
                    this.lb_Avertissement.Invoke((MethodInvoker)delegate { this.lb_Avertissement.Visible = false; });
                    this.lb_PourcentProg.Invoke((MethodInvoker)delegate { this.lb_PourcentProg.Visible = false; });
                    this.lb_Progression.Invoke((MethodInvoker)delegate { this.lb_Progression.Visible = false; });
                    this.pb_Traitement.Invoke((MethodInvoker)delegate { this.pb_Traitement.Visible = false; });
                    this.btn_Optimisation.Invoke((MethodInvoker)delegate { this.btn_Optimisation.Enabled = true; });
                    this.gb_Operation.Invoke((MethodInvoker)delegate { this.gb_Operation.Enabled = true; });
                    this.gB_OptionsInfos.Invoke((MethodInvoker)delegate { this.gB_OptionsInfos.Enabled = true; });
                    this.btn_Defrag.Invoke((MethodInvoker)delegate { this.btn_Defrag.Enabled = true; });
                    this.btn_Journal.Invoke((MethodInvoker)delegate { this.btn_Journal.Enabled = true; });
                    this.btn_Options.Invoke((MethodInvoker)delegate { this.btn_Options.Enabled = true; });
                    this.cB_veille.Invoke((MethodInvoker)delegate { this.cB_veille.Enabled = true; });
                    this.cB_Restauration.Invoke((MethodInvoker)delegate { this.cB_Restauration.Enabled = true; });
                    Gestion_Verification.Ecriture_Log();
                }
            }
        }
        #endregion

        #region Fermeture de la form
        /// <summary>
        /// Cette méthode gère la fermeture de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Depannage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cB_BDD.Checked)
            {
                Gestion_Verification.BDD();
            }
        }
        #endregion
    }
}
