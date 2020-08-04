namespace howto_list_installed_fonts
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
            this.lstFonts = new System.Windows.Forms.ListBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.montext = new System.Windows.Forms.TextBox();
            this.lstResultats = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Taille = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lstFntChoisi = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Taille)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFonts
            // 
            this.lstFonts.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFonts.FormattingEnabled = true;
            this.lstFonts.IntegralHeight = false;
            this.lstFonts.ItemHeight = 15;
            this.lstFonts.Location = new System.Drawing.Point(12, 51);
            this.lstFonts.Name = "lstFonts";
            this.lstFonts.Size = new System.Drawing.Size(256, 305);
            this.lstFonts.TabIndex = 0;
            this.lstFonts.SelectedIndexChanged += new System.EventHandler(this.lstFonts_SelectedIndexChanged);
            this.lstFonts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFonts_MouseDoubleClick);
            // 
            // lblSample
            // 
            this.lblSample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSample.BackColor = System.Drawing.Color.White;
            this.lblSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSample.Location = new System.Drawing.Point(13, 370);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(256, 45);
            this.lblSample.TabIndex = 1;
            // 
            // montext
            // 
            this.montext.Location = new System.Drawing.Point(13, 25);
            this.montext.Name = "montext";
            this.montext.Size = new System.Drawing.Size(256, 20);
            this.montext.TabIndex = 3;
            // 
            // lstResultats
            // 
            this.lstResultats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResultats.FormattingEnabled = true;
            this.lstResultats.IntegralHeight = false;
            this.lstResultats.ItemHeight = 20;
            this.lstResultats.Location = new System.Drawing.Point(274, 51);
            this.lstResultats.Name = "lstResultats";
            this.lstResultats.Size = new System.Drawing.Size(471, 305);
            this.lstResultats.TabIndex = 4;
            this.lstResultats.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstResultats_DrawItem);
            this.lstResultats.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstResultats_MeasureItem);
            this.lstResultats.SelectedIndexChanged += new System.EventHandler(this.lstResultats_SelectedIndexChanged);
            this.lstResultats.DoubleClick += new System.EventHandler(this.lstResultats_DoubleClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Taille
            // 
            this.Taille.Location = new System.Drawing.Point(274, 22);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(693, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstFntChoisi
            // 
            this.lstFntChoisi.FormattingEnabled = true;
            this.lstFntChoisi.Location = new System.Drawing.Point(753, 53);
            this.lstFntChoisi.Name = "lstFntChoisi";
            this.lstFntChoisi.Size = new System.Drawing.Size(437, 303);
            this.lstFntChoisi.TabIndex = 12;
            this.lstFntChoisi.DoubleClick += new System.EventHandler(this.lstFntChoisi_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 434);
            this.Controls.Add(this.lstFntChoisi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Taille);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lstResultats);
            this.Controls.Add(this.montext);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.lstFonts);
            this.Name = "Form1";
            this.Text = "howto_list_installed_fonts";
            ((System.ComponentModel.ISupportInitialize)(this.Taille)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFonts;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.TextBox montext;
        private System.Windows.Forms.ListBox lstResultats;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown Taille;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstFntChoisi;
    }
}

