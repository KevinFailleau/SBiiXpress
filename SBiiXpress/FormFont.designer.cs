namespace SBiiXpress
{
    partial class FormFont
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFont));
            this.lstFonts = new System.Windows.Forms.ListBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.montext = new System.Windows.Forms.TextBox();
            this.lstResultats = new System.Windows.Forms.ListBox();
            this.btn_Demarrer = new System.Windows.Forms.Button();
            this.Taille = new System.Windows.Forms.NumericUpDown();
            this.lstFntChoisi = new System.Windows.Forms.ListBox();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            this.lb_Saisi = new System.Windows.Forms.Label();
            this.lb_Taille = new System.Windows.Forms.Label();
            this.lb_PoliceDispo = new System.Windows.Forms.Label();
            this.lb_Apercu = new System.Windows.Forms.Label();
            this.lb_PolicesSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Taille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFonts
            // 
            this.lstFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFonts.FormattingEnabled = true;
            this.lstFonts.IntegralHeight = false;
            this.lstFonts.Location = new System.Drawing.Point(43, 265);
            this.lstFonts.Name = "lstFonts";
            this.lstFonts.Size = new System.Drawing.Size(256, 305);
            this.lstFonts.TabIndex = 0;
            // 
            // lblSample
            // 
            this.lblSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSample.BackColor = System.Drawing.Color.White;
            this.lblSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSample.Location = new System.Drawing.Point(43, 573);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(256, 45);
            this.lblSample.TabIndex = 1;
            // 
            // montext
            // 
            this.montext.Location = new System.Drawing.Point(43, 223);
            this.montext.Name = "montext";
            this.montext.Size = new System.Drawing.Size(256, 20);
            this.montext.TabIndex = 3;
            // 
            // lstResultats
            // 
            this.lstResultats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResultats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResultats.FormattingEnabled = true;
            this.lstResultats.IntegralHeight = false;
            this.lstResultats.ItemHeight = 20;
            this.lstResultats.Location = new System.Drawing.Point(305, 265);
            this.lstResultats.Name = "lstResultats";
            this.lstResultats.Size = new System.Drawing.Size(471, 305);
            this.lstResultats.TabIndex = 4;
            this.lstResultats.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstResultats_DrawItem);
            this.lstResultats.SelectedIndexChanged += new System.EventHandler(this.lstResultats_SelectedIndexChanged);
            this.lstResultats.DoubleClick += new System.EventHandler(this.lstResultats_DoubleClick);
            // 
            // btn_Demarrer
            // 
            this.btn_Demarrer.Location = new System.Drawing.Point(386, 220);
            this.btn_Demarrer.Name = "btn_Demarrer";
            this.btn_Demarrer.Size = new System.Drawing.Size(124, 24);
            this.btn_Demarrer.TabIndex = 6;
            this.btn_Demarrer.Text = "Démarrer";
            this.btn_Demarrer.UseVisualStyleBackColor = true;
            this.btn_Demarrer.Click += new System.EventHandler(this.btn_Demarrer_Click);
            // 
            // Taille
            // 
            this.Taille.Location = new System.Drawing.Point(304, 223);
            this.Taille.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.Taille.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Taille.Name = "Taille";
            this.Taille.Size = new System.Drawing.Size(65, 20);
            this.Taille.TabIndex = 10;
            this.Taille.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lstFntChoisi
            // 
            this.lstFntChoisi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFntChoisi.FormattingEnabled = true;
            this.lstFntChoisi.Location = new System.Drawing.Point(784, 267);
            this.lstFntChoisi.Name = "lstFntChoisi";
            this.lstFntChoisi.Size = new System.Drawing.Size(437, 303);
            this.lstFntChoisi.TabIndex = 12;
            this.lstFntChoisi.DoubleClick += new System.EventHandler(this.lstFntChoisi_DoubleClick);
            // 
            // pb_Logo
            // 
            this.pb_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Logo.BackColor = System.Drawing.SystemColors.Control;
            this.pb_Logo.Image = global::SBiiXpress.Properties.Resources.Logo_Font_Trsp;
            this.pb_Logo.Location = new System.Drawing.Point(403, 12);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(432, 196);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Logo.TabIndex = 13;
            this.pb_Logo.TabStop = false;
            // 
            // lb_Saisi
            // 
            this.lb_Saisi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Saisi.AutoSize = true;
            this.lb_Saisi.Location = new System.Drawing.Point(40, 207);
            this.lb_Saisi.Name = "lb_Saisi";
            this.lb_Saisi.Size = new System.Drawing.Size(109, 13);
            this.lb_Saisi.TabIndex = 14;
            this.lb_Saisi.Text = "Saisissez votre texte :";
            // 
            // lb_Taille
            // 
            this.lb_Taille.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Taille.AutoSize = true;
            this.lb_Taille.Location = new System.Drawing.Point(301, 207);
            this.lb_Taille.Name = "lb_Taille";
            this.lb_Taille.Size = new System.Drawing.Size(38, 13);
            this.lb_Taille.TabIndex = 15;
            this.lb_Taille.Text = "Taille :";
            // 
            // lb_PoliceDispo
            // 
            this.lb_PoliceDispo.AutoSize = true;
            this.lb_PoliceDispo.Location = new System.Drawing.Point(40, 249);
            this.lb_PoliceDispo.Name = "lb_PoliceDispo";
            this.lb_PoliceDispo.Size = new System.Drawing.Size(102, 13);
            this.lb_PoliceDispo.TabIndex = 16;
            this.lb_PoliceDispo.Text = "Polices disponibles :";
            // 
            // lb_Apercu
            // 
            this.lb_Apercu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Apercu.AutoSize = true;
            this.lb_Apercu.Location = new System.Drawing.Point(305, 249);
            this.lb_Apercu.Name = "lb_Apercu";
            this.lb_Apercu.Size = new System.Drawing.Size(47, 13);
            this.lb_Apercu.TabIndex = 17;
            this.lb_Apercu.Text = "Aperçu :";
            // 
            // lb_PolicesSelect
            // 
            this.lb_PolicesSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_PolicesSelect.AutoSize = true;
            this.lb_PolicesSelect.Location = new System.Drawing.Point(781, 249);
            this.lb_PolicesSelect.Name = "lb_PolicesSelect";
            this.lb_PolicesSelect.Size = new System.Drawing.Size(115, 13);
            this.lb_PolicesSelect.TabIndex = 18;
            this.lb_PolicesSelect.Text = "Polices séléctionnées :";
            // 
            // FormFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 626);
            this.Controls.Add(this.lb_PolicesSelect);
            this.Controls.Add(this.lb_Apercu);
            this.Controls.Add(this.lb_PoliceDispo);
            this.Controls.Add(this.lb_Taille);
            this.Controls.Add(this.lb_Saisi);
            this.Controls.Add(this.pb_Logo);
            this.Controls.Add(this.lstFntChoisi);
            this.Controls.Add(this.Taille);
            this.Controls.Add(this.btn_Demarrer);
            this.Controls.Add(this.lstResultats);
            this.Controls.Add(this.montext);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.lstFonts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFont";
            this.Text = "FontXpress";
            ((System.ComponentModel.ISupportInitialize)(this.Taille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFonts;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.TextBox montext;
        private System.Windows.Forms.ListBox lstResultats;
        private System.Windows.Forms.Button btn_Demarrer;
        private System.Windows.Forms.NumericUpDown Taille;
        private System.Windows.Forms.ListBox lstFntChoisi;
        private System.Windows.Forms.PictureBox pb_Logo;
        private System.Windows.Forms.Label lb_Saisi;
        private System.Windows.Forms.Label lb_Taille;
        private System.Windows.Forms.Label lb_PoliceDispo;
        private System.Windows.Forms.Label lb_Apercu;
        private System.Windows.Forms.Label lb_PolicesSelect;
    }
}

