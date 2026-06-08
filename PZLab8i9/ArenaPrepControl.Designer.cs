namespace PZLab8i9
{
    partial class ArenaPrepControl
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
            lblGracz = new Label();
            lblWrog = new Label();
            btnWroc = new PictureBox();
            btnWalcz = new PictureBox();
            btnLosuj = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnWroc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnWalcz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnLosuj).BeginInit();
            SuspendLayout();
            // 
            // lblGracz
            // 
            lblGracz.ImageAlign = ContentAlignment.TopLeft;
            lblGracz.Location = new Point(53, 53);
            lblGracz.Name = "lblGracz";
            lblGracz.Size = new Size(267, 260);
            lblGracz.TabIndex = 0;
            lblGracz.Text = "label1";
            lblGracz.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWrog
            // 
            lblWrog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWrog.ImageAlign = ContentAlignment.TopLeft;
            lblWrog.Location = new Point(662, 194);
            lblWrog.Name = "lblWrog";
            lblWrog.Size = new Size(263, 258);
            lblWrog.TabIndex = 1;
            lblWrog.Text = "label1";
            // 
            // btnWroc
            // 
            btnWroc.BackColor = Color.Transparent;
            btnWroc.Cursor = Cursors.Hand;
            btnWroc.Location = new Point(305, 390);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(90, 110);
            btnWroc.TabIndex = 6;
            btnWroc.TabStop = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // btnWalcz
            // 
            btnWalcz.BackColor = Color.Transparent;
            btnWalcz.Cursor = Cursors.Hand;
            btnWalcz.Location = new Point(545, 389);
            btnWalcz.Name = "btnWalcz";
            btnWalcz.Size = new Size(90, 136);
            btnWalcz.TabIndex = 7;
            btnWalcz.TabStop = false;
            btnWalcz.Click += btnWalcz_Click;
            // 
            // btnLosuj
            // 
            btnLosuj.BackColor = Color.Transparent;
            btnLosuj.Cursor = Cursors.Hand;
            btnLosuj.Location = new Point(423, 389);
            btnLosuj.Name = "btnLosuj";
            btnLosuj.Size = new Size(89, 136);
            btnLosuj.TabIndex = 8;
            btnLosuj.TabStop = false;
            btnLosuj.Click += btnLosuj_Click;
            // 
            // ArenaPrepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ArenaPrep2v2Gotowe;
            Controls.Add(btnLosuj);
            Controls.Add(btnWalcz);
            Controls.Add(btnWroc);
            Controls.Add(lblWrog);
            Controls.Add(lblGracz);
            Name = "ArenaPrepControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnWroc).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnWalcz).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnLosuj).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblGracz;
        private Label lblWrog;
        private PictureBox btnWroc;
        private PictureBox btnWalcz;
        private PictureBox btnLosuj;
    }
}
