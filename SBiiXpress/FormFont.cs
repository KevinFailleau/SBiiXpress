using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace SBiiXpress
{
    public partial class FormFont : Form
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public FormFont()
        {
            InitializeComponent();
        }

        private Font MakeFont(string family, float size, FontStyle style)
        {
            try
            {
                return new System.Drawing.Font(family, size, style);
            }
            catch
            {
                return null;
            }
        }

        private void lstResultats_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstFonts.SelectedIndex = lstResultats.SelectedIndex;
            lblSample.Text = lstFonts.Text;
        }

        private void btn_Demarrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(montext.Text))
            {
                MessageBox.Show("Vous devez saisir quelque chose pour pouvoir lancer le traitement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lstResultats.Items.Clear();

                foreach (FontFamily fam in FontFamily.Families)
                {
                    lstFonts.Items.Add(fam.Name);
                    lstResultats.Items.Add(fam.Name);
                }
                lstResultats.DrawMode = DrawMode.OwnerDrawFixed;
            }
        }

        private void lstResultats_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            FontFamily toto = new FontFamily(lstFonts.Items[e.Index].ToString());

            float taille;
            float.TryParse(Taille.Value.ToString(), out taille);

            if (toto.IsStyleAvailable(FontStyle.Regular))
                e.Graphics.DrawString(montext.Text, new System.Drawing.Font(lstResultats.Items[e.Index].ToString(),
                    taille, FontStyle.Regular), Brushes.Black, e.Bounds);

            else if (toto.IsStyleAvailable(FontStyle.Bold))
                e.Graphics.DrawString(montext.Text, new System.Drawing.Font(lstResultats.Items[e.Index].ToString(), 
                    taille, FontStyle.Bold), Brushes.Black, e.Bounds);

            else if (toto.IsStyleAvailable(FontStyle.Italic))
                e.Graphics.DrawString(montext.Text, new System.Drawing.Font(lstResultats.Items[e.Index].ToString(), 
                    taille, FontStyle.Italic), Brushes.Black, e.Bounds);

            else if (toto.IsStyleAvailable(FontStyle.Strikeout))
                e.Graphics.DrawString(montext.Text, new System.Drawing.Font(lstResultats.Items[e.Index].ToString(),
                    taille, FontStyle.Strikeout), Brushes.Black, e.Bounds);

            else if (toto.IsStyleAvailable(FontStyle.Underline))
                e.Graphics.DrawString(montext.Text, new System.Drawing.Font(lstResultats.Items[e.Index].ToString(),
                    taille, FontStyle.Underline), Brushes.Black, e.Bounds);
        }

        private void lstResultats_DoubleClick(object sender, EventArgs e)
        {
            lstFntChoisi.Items.Add(lstResultats.SelectedItem);
        }

        private void lstFntChoisi_DoubleClick(object sender, EventArgs e)
        {
            lstFntChoisi.Items.Remove(lstFntChoisi.SelectedItem);
        }
    }
}
