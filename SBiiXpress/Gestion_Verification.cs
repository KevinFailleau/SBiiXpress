#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Microsoft.Win32;
using System.IO;
using System.ServiceProcess;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Management;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
#endregion

namespace SBiiXpress
{
    class Gestion_Verification
    {
        #region Imprimante
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        public static string GetImprimante()
        {
            PrinterSettings setting = new PrinterSettings();
            string nomImp = setting.PrinterName;
            if (nomImp.Contains("Microsoft") || nomImp.Contains("XPS") || nomImp.Contains("PDF") || nomImp == "Fax" || nomImp == "L'imprimante par défaut n'est pas définie.")
            {
                nomImp = "Aucune";
                return nomImp;
            }
            else
            {
                return nomImp;
            }
        }
        #endregion

        #region Vérification des droits de l'utilisateur
        /// <summary>
        /// Permet de vérifier si l'utilisateur en cours possède les droits d'administrateur
        /// </summary>
        /// <returns>Vrai si l'utilisateur est admin sinon retourne false</returns>
        /*public static bool IsAdministrator()
        {   
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }*/


        //Ajout d'une deuxième méthode de vérification des droits, la precédente ne semblait pas toujours
        //efficace
        public static bool IsAdministrator()
        {
            bool isAdmin;
            WindowsIdentity user = null;
            try
            {
                //Récupère l'utilisateur connecté dans la variable user
                user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            finally
            {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }
        #endregion

        #region Vérification de l'OS
        /// <summary>
        /// Cette méthode permet de récupérer la version de l'OS
        /// </summary>
        /// <returns>Retourne la version de l'OS (ex : retourne 10 pour Windows 10)</returns>
        public static string GetOSVer()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("SELECT * FROM  Win32_OperatingSystem");
            string os = "";
            try
            {
                foreach (ManagementObject objManagement in objMOS.Get())
                {
                    // Get OS version from WMI - This also gives us the edition
                    object osCaption = objManagement.GetPropertyValue("Caption");
                    if (osCaption != null)
                    {
                        // Remove all non-alphanumeric characters so that only letters, numbers, and spaces are left.
                        string osC = Regex.Replace(osCaption.ToString(), "[^A-Za-z0-9 ]", "");
                        //string osC = osCaption.ToString();
                        // If the OS starts with "Microsoft," remove it.  We know that already
                        if (osC.StartsWith("Microsoft"))
                        {
                            osC = osC.Substring(9);
                        }
                        // If the OS now starts with "Windows," again... useless.  Remove it.
                        if (osC.Trim().StartsWith("Windows"))
                        {
                            osC = osC.Trim().Substring(7);
                        }
                        // Remove any remaining beginning or ending spaces.
                        os = osC.Trim();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue\n " + e, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] osVer = os.Split(' '); //On sépare la version de l'OS de son édition (Professionnelle, ...)
            os = osVer[0]; //On ne mets que la version de l'OS dans la variable OS
            return os;
        }

        /// <summary>
        /// Vérifie si une version 64bits ou 32bits de Windows est installée
        /// </summary>
        public static void VerifArchiOS()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                CleanerXpress.rV = RegistryView.Registry64;
            }
            else
            {
                CleanerXpress.rV = RegistryView.Registry32;
            }
        }
        #endregion

        #region Vérification de l'état de service Windows
        /// <summary>
        /// Cette méthode permet de connaître l'état d'un service Windows
        /// </summary>
        /// <param name="nomService"></param>
        /// <returns></returns>
        public static string CheckService(string nomService)
        {
            ServiceController sc = new ServiceController(nomService);

            switch (sc.Status)
            {   //On vérifie chaque états pour un service donné et on retourne l'état actuel
                case ServiceControllerStatus.Running:
                    return "Lancé";
                case ServiceControllerStatus.Stopped:
                    return "Stoppé";
                case ServiceControllerStatus.Paused:
                    return "En pause";
                case ServiceControllerStatus.StopPending:
                    return "Arrêt de cours";
                case ServiceControllerStatus.StartPending:
                    return "En cours de démarrage";
                default:
                    return "Statut en cours de changement";
            }
        }
        #endregion

        #region Suppression d'anciennes sauvegardes de la base de registre

        /// <summary>
        /// Permet de connaitre et de supprimer les anciennes sauvegardes de la base de registre
        /// </summary>
        public static void SuppOldSaveReg()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\SBiiXpress\Save\Registry");
            if (dir.Exists) //On vérifie si le dossier existe avant de tenter de supprimer les fichiers
            {
                FileInfo[] fichiers = dir.GetFiles(); //On récupère tous les fichiers situés dans le dossier
                if (fichiers.Count() > 2) //Si il y a plus de deux fichiers dans le dossier, on supprime le plus vieux
                {
                    fichiers[0].Delete(); //Suppression
                }
            }
        }

        #endregion

        #region Gestion fichier log
        /// <summary>
        /// Cette méthode permet d'écrire un log qui permettra d'établir un journal
        /// Dans ce log on stocke la date et l'espace libéré
        /// </summary>
        public static void Ecriture_Log()
        {
            if (File.Exists("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml")) //Vérification de l'existance du fichier
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("C:\\SbiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml"); //on ouvre le fichier existant
                XmlNode root = xmlDoc.DocumentElement;
                XmlElement parentNode = xmlDoc.CreateElement("Use"); //Création d'un noeud Use
                XmlText date = xmlDoc.CreateTextNode("DateTime=" + DateTime.Now.ToString("!dd/MM/yyyy!H:mm:ss") + ";Espace_libre=$" + CalculEspaceLibere()+"$"); //On ajoute la date et l'espace libéré dans use
                parentNode.AppendChild(date);
                xmlDoc.DocumentElement.PrependChild(parentNode);
                root.InsertAfter(parentNode, root.LastChild);
                xmlDoc.Save("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml");
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement rootNode = xmlDoc.CreateElement("Root");
                xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
                xmlDoc.AppendChild(rootNode);
                XmlElement parentNode = xmlDoc.CreateElement("Use");
                XmlText date = xmlDoc.CreateTextNode("DateTime=" + DateTime.Now.ToString("!dd/MM/yyyy!H:mm:ss") + ";Espace_libre=$" + CalculEspaceLibere()+"$");
                parentNode.AppendChild(date);
                xmlDoc.DocumentElement.PrependChild(parentNode);
                DirectoryInfo DI = Directory.CreateDirectory("C:\\SBiiXpress\\Logs");
                xmlDoc.Save("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml");
            }
        }

        public static float LectureEspace_Log()
        {
            if (File.Exists("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml"))
            {
                float i;
                float total = 0;
                List<string> lines = File.ReadAllLines("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml").ToList<string>();
                lines.RemoveAt(0);
                lines.RemoveAt(0);
                lines.RemoveAt(lines.Count - 1);
                string text = string.Join("", lines.ToArray());
                string[] words = text.Split('$');

                foreach (string s in words)
                {
                    if (float.TryParse(s, out i))
                    {
                        total = total + i;
                    }
                }
                return total;
            }
            else
            {
                return 0;
            }
        }

        public static string LectureDate_Log()
        {
            string dateReturn = "";
            if (File.Exists("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml"))
            {
                DateTime date;
                List<string> lines = File.ReadAllLines("C:\\SBiiXpress\\Logs\\Log_Usr_" + Environment.UserName + ".xml").ToList<string>();
                string line = Convert.ToString(lines[2]);
                string text = string.Join("", line);
                string[] words = text.Split('!');
                foreach (string s in words)
                {
                    if (DateTime.TryParse(s, out date))
                    {
                        dateReturn =  date.ToShortDateString();
                    }
                }
            }
            else
            {
                dateReturn = "Erreur lors de la récupération de la date";
            }
            return dateReturn;
        }
        #endregion

        #region Méthode de test et de calcul
        /// <summary>
        /// Récupère l'espace libre du lecteur C:\
        /// </summary>
        /// <returns>Retourne l'espace libre du lecteur C:\</returns>
        public static double EspaceLibre() //Méthode à revoir, les résultats semblent erronnés
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
       public static double CalculEspaceLibere()
        {
            double EspaceGagne;
            EspaceGagne = CleanerXpress.EspaceAp - CleanerXpress.EspaceAv; //On obtient l'espace libréré en octets
            EspaceGagne = (EspaceGagne / 1024) / 1024; //Convertion du résultat en Mo
            EspaceGagne = Math.Round(EspaceGagne, 2); //On ne garde que 2 chiffres après la virgule
            if (EspaceGagne <= 0)
            {
                //Ce teste permet de supprimer un éventuel signe moins devant la somme libérée lors de l'affichage final
                EspaceGagne = CleanerXpress.EspaceAv - CleanerXpress.EspaceAp;  //On réalise l'opération inverse à celle effectuée plus tôt
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
        public static int ProcessEnCours(string process)
        {
            int enCours = 0;
            System.Threading.Thread.Sleep(10000);
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
        public static void action() { }

        /// <summary>
        /// Méthode qui permet simplement de savoir si CCleaner est installé
        /// </summary>
        /// <returns></returns>
        public static void RechercheCCleaner()
        {
            string test = Gestion_Verification.LectureValCleRegistre(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\CCleaner", "InstallLocation", CleanerXpress.rV);
            if (File.Exists(test + "\\CCleaner.exe"))
            {
                CleanerXpress.IsCCleanerPresent = true;
            }
            else
            {
                CleanerXpress.IsCCleanerPresent = false;
            }
        }
        /// <summary>
        /// Cette méthode permet de connaitre la taille d'un dossier et convertit la taille avec le multiple souhaité
        /// </summary>
        /// <param name="path"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public static long FolderSize(string path, string multiple)
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path); //Récupèration de l'emplacement du dossier
            IEnumerable<FileInfo> files = directoryInfo.GetFiles("*", SearchOption.AllDirectories); //On séléctionne tous les fichiers du dossier
            foreach (FileInfo file in files)
            {
                //Pour chaque fichiers du dossier
                size += file.Length; //On ajoute la taille du fichiers actuel à size
            }
            if (multiple == "Ko" || multiple == "ko")
            {
                size = size / 1024; //Si le multiple souhaité est Ko, alors on convertit size en Ko
            }
            if (multiple == "Mo" || multiple == "mo")
            {
                size = (size / 1024) / 1024; //Sinon on convertit size en Mo
            }
            else
                if(multiple == "Go" || multiple == "go")
            {
                size = ((size / 1024) / 1024) / 1024; //Sinon on convertit size en Go
            }
            return size;
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
        /// <param name="rV"></param>
        public static void ecrireRegistre(string path, string valueName, int value, RegistryValueKind valueKind, RegistryView rV)
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
        /// <param name="rV"></param>
        public static void ParcoursEcritureRegistre(string pathLecture, string valueName, int value, RegistryValueKind valueKind, RegistryView rV)
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
        /// Cette méthode permet de lire une valeur dans la base de registre
        /// </summary>
        /// <param name="pathLecture">Chemin d'accès à la valeur</param>
        /// <param name="valName">Nom de la valeur</param>
        /// <returns>Retourne la valeur lue</returns>
        public static string LectureValCleRegistre(string pathLecture, string valName)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(pathLecture);
                if (key != null)
                {
                    Object o = key.GetValue(valName);
                    if (o != null)
                    {
                        return Convert.ToString(o);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'accès à la base de registre\n" + ex, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "err";
        }

        public static string LectureValCleRegistre(string pathLecture, string valName, RegistryView rV)
        {
            try
            {
                var basereg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rV);
                var subKey = basereg.OpenSubKey(pathLecture);
                if (subKey != null)
                {
                    Object o = subKey.GetValue(valName);
                    if (o != null)
                    {
                        return Convert.ToString(o);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L'application a rencontré une erreur lors de la lecture de la base de registre\n" + ex, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "err";
        }

        /// <summary>
        /// Cette méthode permet de supprimer une valeur de la base de registre
        /// </summary>
        /// <param name="pathLecture">Chemin de la valeur</param>
        /// <param name="valueName">Nom de la valeur a supprimer</param>
        /// <param name="rV"></param>
        public static void SupprimerValeurRegistre(string pathLecture, string valueName, RegistryView rV)
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

        #region Lecture de l'adresse MAC
        /// <summary>
        /// cette méthode permet de trouver l'adresse MAC de la machine
        /// </summary>
        /// <returns>Retourne l'adresse MAC trouvée</returns>
        public static string GetMacAdress()
        {
            string MacAdresse = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");

            ManagementObjectCollection mcCol = mc.GetInstances();

            foreach (ManagementObject mcObj in mcCol)
            {
                if (mcObj["MacAddress"] != null)
                    MacAdresse = mcObj["MacAddress"].ToString();
                else
                    MacAdresse = "err";
            }
            return MacAdresse;
        }
        #endregion

        #region Connexion à la base de données
        /// <summary>
        /// Cette méthode permet de se connecter à la base de données, dans la BDD on stocke l'adresse MAC du PC
        /// qui sert d'identifiant, la quantité totale d'espace libérée et le modèle d'imprimante
        /// </summary>
        public static void BDD()
        {
            //string cs = @"server=localhost;database=io1mf84j_sbiiapp;userid=root;password=;";  //Connexion à une base de donnée locale
            //string cs = @"server=lhcp1029.webapps.net:3306;database=sbiixpretq123456;userid=sbii2710;password=;"; //Chaîne de caractère qui contient les informations pour la connexion à la BDD
            string cs = @"server=lhcp1029.webapps.net:3306;database=io1mf84j_sbiixpress_appli;userid=io1mf84j_rpxiibs;password=+-123456A*bc+D-e/F;";
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs); //On crée une connexion SQL avec les information saisies dans la chaîne de caractères
                conn.Open(); //On ouvre la connexion
                string SelectQuery = "SELECT * from clt_config WHERE identifiant = '" + Gestion_Verification.GetMacAdress() + "'"; //Requête SLQ, on vérifie si un enregistrement avec le même identifiant existe déjà
                MySqlCommand cmd = new MySqlCommand(SelectQuery, conn); //On stocke la commande et les informations relatives au serveur dans une variable "cmd"
                MySqlDataReader dataReader = cmd.ExecuteReader(); //Exécution de la commande
                if (dataReader.Read())
                {   //Si la commande SELECT à trouver un tuple avec le même identifiant alors on fait le traitement suivant
                    dataReader.Close(); //Fermeture du dataReader necessaire pour la commande
                    string query = "UPDATE clt_config SET freespace ='" + Gestion_Verification.LectureEspace_Log() + "', print='" + Gestion_Verification.GetImprimante() + "' WHERE identifiant ='" + Gestion_Verification.GetMacAdress() + "'"; //On stocke la commande pour la mise à jour de l'enregistrement existant
                    MySqlCommand UpdateQuery = new MySqlCommand(query, conn); //Stockage de la commande et des informations relatives à la connexion à la BDD
                    UpdateQuery.ExecuteNonQuery(); //Exécution de la commande
                    dataReader.Close();
                }
                else
                if (!dataReader.Read())
                {
                    //Si aucun enregistrement avec le même identifiant existe
                    dataReader.Close();
                    string query = "INSERT INTO clt_config (identifiant,freespace,print) VALUES ('" + Gestion_Verification.GetMacAdress() + "','" + Gestion_Verification.LectureEspace_Log() + "','" + Gestion_Verification.GetImprimante() + "')"; //Stockage de la commande pour créer un nouvel enregistrement avec les informations voulues
                    MySqlCommand InsertQuery = new MySqlCommand(query, conn); //Stockage de la commande et des informations relatives à la connexion à la BDD
                    InsertQuery.ExecuteNonQuery(); //Exécution de la commande
                }
                conn.Close(); //Fermeture de la connexion
            }
            catch (Exception ex) //En cas d'erreur, on affiche un message
            {
                MessageBox.Show("Impossible de se connecter à la base de données\n" + ex, "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}