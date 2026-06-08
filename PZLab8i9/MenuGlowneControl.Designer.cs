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
            btnNowaGra = new PictureBox();
            btnWczytaj = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnNowaGra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnWczytaj).BeginInit();
            SuspendLayout();
            // 
            // btnNowaGra
            // 
            btnNowaGra.BackColor = Color.Transparent;
            btnNowaGra.Cursor = Cursors.Hand;
            btnNowaGra.Location = new Point(373, 411);
            btnNowaGra.Name = "btnNowaGra";
            btnNowaGra.Size = new Size(91, 107);
            btnNowaGra.TabIndex = 2;
            btnNowaGra.TabStop = false;
            btnNowaGra.Click += btnNowaGra_Click;
            // 
            // btnWczytaj
            // 
            btnWczytaj.BackColor = Color.Transparent;
            btnWczytaj.Cursor = Cursors.Hand;
            btnWczytaj.Location = new Point(517, 411);
            btnWczytaj.Name = "btnWczytaj";
            btnWczytaj.Size = new Size(122, 107);
            btnWczytaj.TabIndex = 3;
            btnWczytaj.TabStop = false;
            btnWczytaj.Click += btnWczytaj_Click;
            // 
            // MenuGlowneControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MenuGlowneGotowe;
            Controls.Add(btnWczytaj);
            Controls.Add(btnNowaGra);
            Name = "MenuGlowneControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnNowaGra).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnWczytaj).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox btnNowaGra;
        private PictureBox btnWczytaj;
    }
}
