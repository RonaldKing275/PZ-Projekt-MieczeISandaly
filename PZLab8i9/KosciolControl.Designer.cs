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
            btnZapisz = new PictureBox();
            btnWroc = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnZapisz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnWroc).BeginInit();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top;
            lblInfo.BackColor = Color.White;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblInfo.Location = new Point(26, 45);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(322, 176);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Witaj w Kościele. Tutaj zapiszesz i wczytasz swoją postać";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnZapisz
            // 
            btnZapisz.BackColor = Color.Transparent;
            btnZapisz.Cursor = Cursors.Hand;
            btnZapisz.Location = new Point(540, 446);
            btnZapisz.Name = "btnZapisz";
            btnZapisz.Size = new Size(102, 37);
            btnZapisz.TabIndex = 4;
            btnZapisz.TabStop = false;
            btnZapisz.Click += btnZapisz_Click;
            // 
            // btnWroc
            // 
            btnWroc.BackColor = Color.Transparent;
            btnWroc.BackgroundImage = Properties.Resources.IkonaWyjscieGotowePrzeskalowane;
            btnWroc.Cursor = Cursors.Hand;
            btnWroc.Location = new Point(910, 462);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(74, 74);
            btnWroc.TabIndex = 5;
            btnWroc.TabStop = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // KosciolControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MiSKosciolGotowe;
            Controls.Add(btnWroc);
            Controls.Add(btnZapisz);
            Controls.Add(lblInfo);
            Name = "KosciolControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnZapisz).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnWroc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblInfo;
        private PictureBox btnZapisz;
        private PictureBox btnWroc;
    }
}
