namespace PZLab8i9
{
    partial class UlicaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UlicaControl));
            btnZbrojny = new Button();
            btnBronie = new Button();
            btnMagia = new Button();
            btnKosciol = new Button();
            btnArena = new Button();
            barExp = new ProgressBar();
            lblExpInfo = new Label();
            SuspendLayout();
            // 
            // btnZbrojny
            // 
            btnZbrojny.Anchor = AnchorStyles.None;
            btnZbrojny.Location = new Point(809, 347);
            btnZbrojny.Name = "btnZbrojny";
            btnZbrojny.Size = new Size(94, 51);
            btnZbrojny.TabIndex = 0;
            btnZbrojny.Text = "Zbrojownia";
            btnZbrojny.UseVisualStyleBackColor = true;
            btnZbrojny.Click += btnZbrojny_Click;
            // 
            // btnBronie
            // 
            btnBronie.Anchor = AnchorStyles.None;
            btnBronie.Location = new Point(102, 325);
            btnBronie.Name = "btnBronie";
            btnBronie.Size = new Size(94, 48);
            btnBronie.TabIndex = 1;
            btnBronie.Text = "Zbrojmistrz";
            btnBronie.UseVisualStyleBackColor = true;
            btnBronie.Click += btnBronie_Click;
            // 
            // btnMagia
            // 
            btnMagia.Location = new Point(232, 277);
            btnMagia.Name = "btnMagia";
            btnMagia.Size = new Size(99, 55);
            btnMagia.TabIndex = 2;
            btnMagia.Text = "Sklep z magią";
            btnMagia.UseVisualStyleBackColor = true;
            btnMagia.Click += btnMagia_Click;
            // 
            // btnKosciol
            // 
            btnKosciol.Anchor = AnchorStyles.None;
            btnKosciol.Location = new Point(698, 277);
            btnKosciol.Name = "btnKosciol";
            btnKosciol.Size = new Size(94, 29);
            btnKosciol.TabIndex = 3;
            btnKosciol.Text = "Kościół";
            btnKosciol.UseVisualStyleBackColor = true;
            btnKosciol.Click += btnKosciol_Click;
            // 
            // btnArena
            // 
            btnArena.Anchor = AnchorStyles.None;
            btnArena.Location = new Point(153, 59);
            btnArena.Name = "btnArena";
            btnArena.Size = new Size(94, 29);
            btnArena.TabIndex = 4;
            btnArena.Text = "Arena";
            btnArena.UseVisualStyleBackColor = true;
            btnArena.Click += btnArena_Click;
            // 
            // barExp
            // 
            barExp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            barExp.Location = new Point(623, 42);
            barExp.Name = "barExp";
            barExp.Size = new Size(362, 23);
            barExp.TabIndex = 5;
            // 
            // lblExpInfo
            // 
            lblExpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblExpInfo.Location = new Point(623, 14);
            lblExpInfo.Name = "lblExpInfo";
            lblExpInfo.Size = new Size(362, 25);
            lblExpInfo.TabIndex = 6;
            lblExpInfo.Text = "label1";
            lblExpInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UlicaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(lblExpInfo);
            Controls.Add(barExp);
            Controls.Add(btnArena);
            Controls.Add(btnKosciol);
            Controls.Add(btnMagia);
            Controls.Add(btnBronie);
            Controls.Add(btnZbrojny);
            Name = "UlicaControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
        }

        #endregion

        private Button btnZbrojny;
        private Button btnBronie;
        private Button btnMagia;
        private Button btnKosciol;
        private Button btnArena;
        private ProgressBar barExp;
        private Label lblExpInfo;
    }
}
