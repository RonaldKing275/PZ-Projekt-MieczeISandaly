namespace PZLab8i9
{
    partial class ArenaTrybControl
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
            btnTournament = new PictureBox();
            btnDuel = new PictureBox();
            btnWroc = new PictureBox();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)btnTournament).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnDuel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnWroc).BeginInit();
            SuspendLayout();
            // 
            // btnTournament
            // 
            btnTournament.BackColor = Color.Transparent;
            btnTournament.Cursor = Cursors.Hand;
            btnTournament.Location = new Point(772, 88);
            btnTournament.Name = "btnTournament";
            btnTournament.Size = new Size(134, 183);
            btnTournament.TabIndex = 0;
            btnTournament.TabStop = false;
            btnTournament.Click += btnTournament_Click;
            // 
            // btnDuel
            // 
            btnDuel.BackColor = Color.Transparent;
            btnDuel.Cursor = Cursors.Hand;
            btnDuel.Location = new Point(760, 325);
            btnDuel.Name = "btnDuel";
            btnDuel.Size = new Size(122, 127);
            btnDuel.TabIndex = 1;
            btnDuel.TabStop = false;
            btnDuel.Click += btnDuel_Click;
            // 
            // btnWroc
            // 
            btnWroc.BackColor = Color.Transparent;
            btnWroc.Cursor = Cursors.Hand;
            btnWroc.Location = new Point(896, 458);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(81, 82);
            btnWroc.TabIndex = 2;
            btnWroc.TabStop = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.White;
            lblInfo.Location = new Point(28, 25);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(308, 180);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "label1";
            // 
            // ArenaTrybControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ArenaPrep1v2Gotowe;
            Controls.Add(lblInfo);
            Controls.Add(btnWroc);
            Controls.Add(btnDuel);
            Controls.Add(btnTournament);
            Name = "ArenaTrybControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnTournament).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnDuel).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnWroc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btnTournament;
        private PictureBox btnDuel;
        private PictureBox btnWroc;
        private Label lblInfo;
    }
}
