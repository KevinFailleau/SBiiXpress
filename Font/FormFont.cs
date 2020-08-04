using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

namespace howto_list_installed_fonts
{
    public partial class FormFont : Form
    {
        public FormFont()
        {
            InitializeComponent();
        }

        private FormFont MakeFont(string family, float size, FontStyle style)
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

        private void button3_Click(object sender, EventArgs e)
        {
            lstResultats.Items.Clear();

            foreach (FontFamily fam in FontFamily.Families)
            {
                lstFonts.Items.Add(fam.Name);
                lstResultats.Items.Add(fam.Name);
            }
            lstResultats.DrawMode = DrawMode.OwnerDrawFixed;

            MessageBox.Show(lstResultats.Items.ToString());
            //lstResultats.ItemHeight = lstResultats.GetItemHeight;
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

        private void lstResultats_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstResultats.IntegralHeight = true;
        }

        private void lstFonts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstFonts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstFonts.Items.Remove(lstFonts.SelectedItem);
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
