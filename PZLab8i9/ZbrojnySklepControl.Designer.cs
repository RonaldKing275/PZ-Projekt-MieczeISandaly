namespace PZLab8i9
{
    partial class ZbrojnySklepControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZbrojnySklepControl));
            lstAsortyment = new ListBox();
            lblZloto = new Label();
            btnWroc = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnWroc).BeginInit();
            SuspendLayout();
            // 
            // lstAsortyment
            // 
            lstAsortyment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstAsortyment.FormattingEnabled = true;
            lstAsortyment.Location = new Point(80, 262);
            lstAsortyment.Name = "lstAsortyment";
            lstAsortyment.Size = new Size(401, 64);
            lstAsortyment.TabIndex = 4;
            // 
            // lblZloto
            // 
            lblZloto.BackColor = Color.White;
            lblZloto.Location = new Point(48, 25);
            lblZloto.Name = "lblZloto";
            lblZloto.Size = new Size(335, 209);
            lblZloto.TabIndex = 1;
            lblZloto.Text = "label1";
            // 
            // btnWroc
            // 
            btnWroc.BackColor = Color.Transparent;
            btnWroc.BackgroundImage = Properties.Resources.IkonaWyjscieGotowePrzeskalowane;
            btnWroc.Cursor = Cursors.Hand;
            btnWroc.Location = new Point(920, 470);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(74, 74);
            btnWroc.TabIndex = 5;
            btnWroc.TabStop = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // ZbrojnySklepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnWroc);
            Controls.Add(lblZloto);
            Controls.Add(lstAsortyment);
            Name = "ZbrojnySklepControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnWroc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstAsortyment;
        private Label lblZloto;
        private PictureBox btnWroc;
    }
}
