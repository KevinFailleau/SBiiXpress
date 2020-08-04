using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using Microsoft.Win32;
using System.IO;

namespace SBiiXpress
{
    class Verifications
    {
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
        /// Cette méthode vérifie la version de l'OS
        /// </summary>
        /// <returns>Si l'OS est plus récent que Windows Vista la méthode retourne true, sinon elle retourne false</returns>
        public static bool VerifOS()
        {
            bool WinComp;
            string strOS = Environment.OSVersion.Version.ToString();
            string[] Tableau = strOS.Split(new char[] { '.' }, 3);
            string strVersion = Tableau[0] + Tableau[1];
            if (strVersion == "51" || strVersion == "52") WinComp = false;
            else WinComp = true;
            return WinComp;
        }

        /// <summary>
        /// Vérifie si une version 64bits ou 32bits de Windows est installée
        /// </summary>
        public static void VerifArchiOS()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                Depannage.rV = RegistryView.Registry64;
            }
            else
            {
                Depannage.rV = RegistryView.Registry32;
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
    }
    #endregion
    }