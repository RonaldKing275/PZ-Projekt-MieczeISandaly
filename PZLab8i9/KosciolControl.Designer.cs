namespace PZLab8i9
{
    partial class KosciolControl
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
            lblInfo = new Label();
            btnZapisz = new Button();
            btnWczytaj = new Button();
            btnWroc = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblInfo.Location = new Point(168, 50);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(664, 193);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Witaj w Kościele. Tutaj zapiszesz i wczytasz swoją postać";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnZapisz
            // 
            btnZapisz.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnZapisz.Location = new Point(168, 259);
            btnZapisz.Name = "btnZapisz";
            btnZapisz.Size = new Size(159, 49);
            btnZapisz.TabIndex = 1;
            btnZapisz.Text = "Zapisz grę";
            btnZapisz.UseVisualStyleBackColor = true;
            btnZapisz.Click += btnZapisz_Click;
            // 
            // btnWczytaj
            // 
            btnWczytaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWczytaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnWczytaj.Location = new Point(673, 259);
            btnWczytaj.Name = "btnWczytaj";
            btnWczytaj.Size = new Size(159, 49);
            btnWczytaj.TabIndex = 2;
            btnWczytaj.Text = "Wczytaj grę";
            btnWczytaj.UseVisualStyleBackColor = true;
            btnWczytaj.Click += btnWczytaj_Click;
            // 
            // btnWroc
            // 
            btnWroc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWroc.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnWroc.Location = new Point(21, 480);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(157, 55);
            btnWroc.TabIndex = 3;
            btnWroc.Text = "Wróć na ulice";
            btnWroc.UseVisualStyleBackColor = true;
            btnWroc.Click += btnWroc_Click;
            // 
            // KosciolControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnWroc);
            Controls.Add(btnWczytaj);
            Controls.Add(btnZapisz);
            Controls.Add(lblInfo);
            Name = "KosciolControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
        }

        #endregion

        private Label lblInfo;
        private Button btnZapisz;
        private Button btnWczytaj;
        private Button btnWroc;
    }
}
