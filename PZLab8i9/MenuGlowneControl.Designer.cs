namespace PZLab8i9
{
    partial class MenuGlowneControl
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
            btnNowaGra = new Button();
            btnWczytaj = new Button();
            SuspendLayout();
            // 
            // btnNowaGra
            // 
            btnNowaGra.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnNowaGra.Location = new Point(350, 300);
            btnNowaGra.Name = "btnNowaGra";
            btnNowaGra.Size = new Size(300, 60);
            btnNowaGra.TabIndex = 0;
            btnNowaGra.Text = "Nowa Gra";
            btnNowaGra.UseVisualStyleBackColor = true;
            btnNowaGra.Click += btnNowaGra_Click;
            // 
            // btnWczytaj
            // 
            btnWczytaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnWczytaj.Location = new Point(350, 380);
            btnWczytaj.Name = "btnWczytaj";
            btnWczytaj.Size = new Size(300, 60);
            btnWczytaj.TabIndex = 1;
            btnWczytaj.Text = "Wczytaj Zapis";
            btnWczytaj.UseVisualStyleBackColor = true;
            btnWczytaj.Click += btnWczytaj_Click;
            // 
            // MenuGlowneControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnWczytaj);
            Controls.Add(btnNowaGra);
            Name = "MenuGlowneControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNowaGra;
        private Button btnWczytaj;
    }
}
