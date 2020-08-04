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
    public partial class Encre : Form
    {
        #region Initialisation
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public Encre()
        {
            InitializeComponent();
            if (Gestion_Verification.GetImprimante() == "Aucune")
                MessageBox.Show("Aucune imprimante par défaut n'a été trouvé", "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lb_Imp.Text = Gestion_Verification.GetImprimante();
        }
        #endregion

        #region Bouton fermer
        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
