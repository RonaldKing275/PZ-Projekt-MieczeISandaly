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
            btnMagia = new Button();
            btnKosciol = new Button();
            btnArena = new Button();
            barExp = new ProgressBar();
            lblExpInfo = new Label();
            btnBronie = new Button();
            SuspendLayout();
            // 
            // btnZbrojny
            // 
            btnZbrojny.Anchor = AnchorStyles.None;
            btnZbrojny.BackColor = Color.Transparent;
            btnZbrojny.Cursor = Cursors.Hand;
            btnZbrojny.FlatAppearance.BorderSize = 0;
            btnZbrojny.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZbrojny.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnZbrojny.FlatStyle = FlatStyle.Flat;
            btnZbrojny.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            btnZbrojny.ForeColor = Color.Transparent;
            btnZbrojny.Location = new Point(783, 326);
            btnZbrojny.Name = "btnZbrojny";
            btnZbrojny.Size = new Size(156, 73);
            btnZbrojny.TabIndex = 0;
            btnZbrojny.Text = "Zbrojownia";
            btnZbrojny.UseVisualStyleBackColor = false;
            btnZbrojny.Click += btnZbrojny_Click;
            // 
            // btnMagia
            // 
            btnMagia.BackColor = Color.Transparent;
            btnMagia.Cursor = Cursors.Hand;
            btnMagia.FlatAppearance.BorderSize = 0;
            btnMagia.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMagia.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMagia.FlatStyle = FlatStyle.Flat;
            btnMagia.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            btnMagia.ForeColor = Color.Transparent;
            btnMagia.Location = new Point(212, 268);
            btnMagia.Name = "btnMagia";
            btnMagia.Size = new Size(144, 77);
            btnMagia.TabIndex = 2;
            btnMagia.Text = "Sklep z magią";
            btnMagia.UseVisualStyleBackColor = false;
            btnMagia.Click += btnMagia_Click;
            // 
            // btnKosciol
            // 
            btnKosciol.Anchor = AnchorStyles.None;
            btnKosciol.BackColor = Color.Transparent;
            btnKosciol.Cursor = Cursors.Hand;
            btnKosciol.FlatAppearance.BorderSize = 0;
            btnKosciol.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnKosciol.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnKosciol.FlatStyle = FlatStyle.Flat;
            btnKosciol.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            btnKosciol.ForeColor = Color.Transparent;
            btnKosciol.Location = new Point(682, 256);
            btnKosciol.Name = "btnKosciol";
            btnKosciol.Size = new Size(120, 64);
            btnKosciol.TabIndex = 3;
            btnKosciol.Text = "Kościół";
            btnKosciol.UseVisualStyleBackColor = false;
            btnKosciol.Click += btnKosciol_Click;
            // 
            // btnArena
            // 
            btnArena.Anchor = AnchorStyles.None;
            btnArena.BackColor = Color.Transparent;
            btnArena.Cursor = Cursors.Hand;
            btnArena.FlatAppearance.BorderSize = 0;
            btnArena.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnArena.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnArena.FlatStyle = FlatStyle.Flat;
            btnArena.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            btnArena.ForeColor = Color.Transparent;
            btnArena.Location = new Point(118, 38);
            btnArena.Name = "btnArena";
            btnArena.Size = new Size(139, 51);
            btnArena.TabIndex = 4;
            btnArena.Text = "Arena";
            btnArena.UseVisualStyleBackColor = false;
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
            // btnBronie
            // 
            btnBronie.Anchor = AnchorStyles.None;
            btnBronie.BackColor = Color.Transparent;
            btnBronie.Cursor = Cursors.Hand;
            btnBronie.FlatAppearance.BorderSize = 0;
            btnBronie.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBronie.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBronie.FlatStyle = FlatStyle.Flat;
            btnBronie.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            btnBronie.ForeColor = Color.Transparent;
            btnBronie.Location = new Point(59, 326);
            btnBronie.Name = "btnBronie";
            btnBronie.Size = new Size(147, 88);
            btnBronie.TabIndex = 1;
            btnBronie.Text = "Zbrojmistrz";
            btnBronie.UseVisualStyleBackColor = false;
            btnBronie.Click += btnBronie_Click;
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
        private Button btnMagia;
        private Button btnKosciol;
        private Button btnArena;
        private ProgressBar barExp;
        private Label lblExpInfo;
        private Button btnBronie;
    }
}
