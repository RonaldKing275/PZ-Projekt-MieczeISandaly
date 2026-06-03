namespace PZLab8i9
{
    partial class ArenaWalkaControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArenaWalkaControl));
            lblImieGracza = new Label();
            lblImieWroga = new Label();
            btnWroc = new Button();
            barPancerzGracza = new KolorowyPasek();
            barHpGracza = new KolorowyPasek();
            barStaminaGracza = new KolorowyPasek();
            barPancerzWroga = new KolorowyPasek();
            barHpWroga = new KolorowyPasek();
            barStaminaWroga = new KolorowyPasek();
            lblKomunikatWalki = new Label();
            btnKrokTyl = new PictureBox();
            btnKrokPrzod = new PictureBox();
            btnKrzyk = new PictureBox();
            btnOdpocznij = new PictureBox();
            btnSzybkiAtak = new PictureBox();
            btnNormalnyAtak = new PictureBox();
            btnCiezkiAtak = new PictureBox();
            btnZmienBron = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnKrokTyl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnKrokPrzod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnKrzyk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnOdpocznij).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSzybkiAtak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnNormalnyAtak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCiezkiAtak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnZmienBron).BeginInit();
            SuspendLayout();
            // 
            // lblImieGracza
            // 
            lblImieGracza.AutoSize = true;
            lblImieGracza.Location = new Point(224, 168);
            lblImieGracza.Name = "lblImieGracza";
            lblImieGracza.Size = new Size(50, 20);
            lblImieGracza.TabIndex = 0;
            lblImieGracza.Text = "label1";
            // 
            // lblImieWroga
            // 
            lblImieWroga.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblImieWroga.AutoSize = true;
            lblImieWroga.Location = new Point(735, 158);
            lblImieWroga.Name = "lblImieWroga";
            lblImieWroga.Size = new Size(50, 20);
            lblImieWroga.TabIndex = 1;
            lblImieWroga.Text = "label2";
            // 
            // btnWroc
            // 
            btnWroc.Anchor = AnchorStyles.Bottom;
            btnWroc.Location = new Point(451, 499);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(94, 29);
            btnWroc.TabIndex = 9;
            btnWroc.Text = "Powrót";
            btnWroc.UseVisualStyleBackColor = true;
            btnWroc.Visible = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // barPancerzGracza
            // 
            barPancerzGracza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barPancerzGracza.BackColor = Color.FromArgb(224, 224, 224);
            barPancerzGracza.ForeColor = Color.Silver;
            barPancerzGracza.Location = new Point(22, 405);
            barPancerzGracza.Name = "barPancerzGracza";
            barPancerzGracza.Size = new Size(125, 29);
            barPancerzGracza.TabIndex = 10;
            // 
            // barHpGracza
            // 
            barHpGracza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barHpGracza.BackColor = Color.FromArgb(224, 224, 224);
            barHpGracza.ForeColor = Color.Red;
            barHpGracza.Location = new Point(22, 451);
            barHpGracza.Name = "barHpGracza";
            barHpGracza.Size = new Size(125, 29);
            barHpGracza.TabIndex = 11;
            // 
            // barStaminaGracza
            // 
            barStaminaGracza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barStaminaGracza.BackColor = Color.FromArgb(224, 224, 224);
            barStaminaGracza.ForeColor = Color.Blue;
            barStaminaGracza.Location = new Point(22, 499);
            barStaminaGracza.Name = "barStaminaGracza";
            barStaminaGracza.Size = new Size(125, 29);
            barStaminaGracza.TabIndex = 12;
            // 
            // barPancerzWroga
            // 
            barPancerzWroga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            barPancerzWroga.BackColor = Color.FromArgb(224, 224, 224);
            barPancerzWroga.ForeColor = Color.Silver;
            barPancerzWroga.Location = new Point(855, 405);
            barPancerzWroga.Name = "barPancerzWroga";
            barPancerzWroga.Size = new Size(125, 29);
            barPancerzWroga.TabIndex = 13;
            // 
            // barHpWroga
            // 
            barHpWroga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            barHpWroga.BackColor = Color.FromArgb(224, 224, 224);
            barHpWroga.ForeColor = Color.Red;
            barHpWroga.Location = new Point(855, 451);
            barHpWroga.Name = "barHpWroga";
            barHpWroga.Size = new Size(125, 29);
            barHpWroga.TabIndex = 14;
            // 
            // barStaminaWroga
            // 
            barStaminaWroga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            barStaminaWroga.BackColor = Color.FromArgb(224, 224, 224);
            barStaminaWroga.ForeColor = Color.Blue;
            barStaminaWroga.Location = new Point(855, 499);
            barStaminaWroga.Name = "barStaminaWroga";
            barStaminaWroga.Size = new Size(125, 29);
            barStaminaWroga.TabIndex = 15;
            // 
            // lblKomunikatWalki
            // 
            lblKomunikatWalki.Location = new Point(420, 50);
            lblKomunikatWalki.Name = "lblKomunikatWalki";
            lblKomunikatWalki.Size = new Size(160, 100);
            lblKomunikatWalki.TabIndex = 16;
            lblKomunikatWalki.Text = "label1";
            lblKomunikatWalki.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnKrokTyl
            // 
            btnKrokTyl.BackColor = Color.Transparent;
            btnKrokTyl.BackgroundImage = Properties.Resources.IkonaKrokTylPrzeskalowane;
            btnKrokTyl.Location = new Point(120, 138);
            btnKrokTyl.Name = "btnKrokTyl";
            btnKrokTyl.Size = new Size(65, 63);
            btnKrokTyl.TabIndex = 23;
            btnKrokTyl.TabStop = false;
            btnKrokTyl.Click += btnKrokTyl_Click;
            // 
            // btnKrokPrzod
            // 
            btnKrokPrzod.BackColor = Color.Transparent;
            btnKrokPrzod.BackgroundImage = Properties.Resources.IkonaKrokPrzodPrzeskalowane;
            btnKrokPrzod.Location = new Point(319, 138);
            btnKrokPrzod.Name = "btnKrokPrzod";
            btnKrokPrzod.Size = new Size(65, 63);
            btnKrokPrzod.TabIndex = 24;
            btnKrokPrzod.TabStop = false;
            btnKrokPrzod.Click += btnKrokPrzod_Click;
            // 
            // btnKrzyk
            // 
            btnKrzyk.BackColor = Color.Transparent;
            btnKrzyk.BackgroundImage = Properties.Resources.IkonaKrzykPrzeskalowane;
            btnKrzyk.Location = new Point(82, 276);
            btnKrzyk.Name = "btnKrzyk";
            btnKrzyk.Size = new Size(65, 63);
            btnKrzyk.TabIndex = 25;
            btnKrzyk.TabStop = false;
            btnKrzyk.Click += btnKrzyk_Click;
            // 
            // btnOdpocznij
            // 
            btnOdpocznij.BackColor = Color.Transparent;
            btnOdpocznij.BackgroundImage = Properties.Resources.IkonaOdpocznijPrzeskalowane;
            btnOdpocznij.Location = new Point(82, 207);
            btnOdpocznij.Name = "btnOdpocznij";
            btnOdpocznij.Size = new Size(65, 63);
            btnOdpocznij.TabIndex = 26;
            btnOdpocznij.TabStop = false;
            btnOdpocznij.Click += btnOdpocznij_Click;
            // 
            // btnSzybkiAtak
            // 
            btnSzybkiAtak.BackColor = Color.Transparent;
            btnSzybkiAtak.BackgroundImage = Properties.Resources.IkonaAtakQuickPrzeskalowane;
            btnSzybkiAtak.Location = new Point(319, 345);
            btnSzybkiAtak.Name = "btnSzybkiAtak";
            btnSzybkiAtak.Size = new Size(65, 63);
            btnSzybkiAtak.TabIndex = 27;
            btnSzybkiAtak.TabStop = false;
            btnSzybkiAtak.Click += btnSzybkiAtak_Click;
            // 
            // btnNormalnyAtak
            // 
            btnNormalnyAtak.BackColor = Color.Transparent;
            btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaAtakNormalPrzeskalowane;
            btnNormalnyAtak.Location = new Point(356, 276);
            btnNormalnyAtak.Name = "btnNormalnyAtak";
            btnNormalnyAtak.Size = new Size(65, 63);
            btnNormalnyAtak.TabIndex = 28;
            btnNormalnyAtak.TabStop = false;
            btnNormalnyAtak.Click += btnNormalnyAtak_Click;
            // 
            // btnCiezkiAtak
            // 
            btnCiezkiAtak.BackColor = Color.Transparent;
            btnCiezkiAtak.BackgroundImage = Properties.Resources.IkonaAtakPowerPrzeskalowane;
            btnCiezkiAtak.Location = new Point(356, 207);
            btnCiezkiAtak.Name = "btnCiezkiAtak";
            btnCiezkiAtak.Size = new Size(65, 63);
            btnCiezkiAtak.TabIndex = 29;
            btnCiezkiAtak.TabStop = false;
            btnCiezkiAtak.Click += btnCiezkiAtak_Click;
            // 
            // btnZmienBron
            // 
            btnZmienBron.BackColor = Color.Transparent;
            btnZmienBron.BackgroundImage = Properties.Resources.IkonaZmienBronPrzeskalowane;
            btnZmienBron.Location = new Point(120, 345);
            btnZmienBron.Name = "btnZmienBron";
            btnZmienBron.Size = new Size(53, 53);
            btnZmienBron.TabIndex = 30;
            btnZmienBron.TabStop = false;
            btnZmienBron.Click += btnZmienBron_Click;
            // 
            // ArenaWalkaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnZmienBron);
            Controls.Add(btnCiezkiAtak);
            Controls.Add(btnNormalnyAtak);
            Controls.Add(btnSzybkiAtak);
            Controls.Add(btnOdpocznij);
            Controls.Add(btnKrzyk);
            Controls.Add(btnKrokPrzod);
            Controls.Add(btnKrokTyl);
            Controls.Add(lblKomunikatWalki);
            Controls.Add(barStaminaWroga);
            Controls.Add(barHpWroga);
            Controls.Add(barPancerzWroga);
            Controls.Add(barStaminaGracza);
            Controls.Add(barHpGracza);
            Controls.Add(barPancerzGracza);
            Controls.Add(btnWroc);
            Controls.Add(lblImieWroga);
            Controls.Add(lblImieGracza);
            Name = "ArenaWalkaControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnKrokTyl).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnKrokPrzod).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnKrzyk).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnOdpocznij).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSzybkiAtak).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnNormalnyAtak).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCiezkiAtak).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnZmienBron).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImieGracza;
        private Label lblImieWroga;
        private Button btnWroc;
        private KolorowyPasek barPancerzGracza;
        private KolorowyPasek barHpGracza;
        private KolorowyPasek barStaminaGracza;
        private KolorowyPasek barPancerzWroga;
        private KolorowyPasek barHpWroga;
        private KolorowyPasek barStaminaWroga;
        private Label lblKomunikatWalki;
        private PictureBox btnKrokTyl;
        private PictureBox btnKrokPrzod;
        private PictureBox btnKrzyk;
        private PictureBox btnOdpocznij;
        private PictureBox btnSzybkiAtak;
        private PictureBox btnNormalnyAtak;
        private PictureBox btnCiezkiAtak;
        private PictureBox btnZmienBron;
    }
}
