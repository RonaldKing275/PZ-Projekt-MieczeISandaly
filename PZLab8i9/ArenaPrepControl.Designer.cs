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
            btnLosuj = new Button();
            btnWalcz = new Button();
            btnWroc = new Button();
            lblVS = new Label();
            SuspendLayout();
            // 
            // lblGracz
            // 
            lblGracz.ImageAlign = ContentAlignment.TopLeft;
            lblGracz.Location = new Point(21, 16);
            lblGracz.Name = "lblGracz";
            lblGracz.Size = new Size(395, 445);
            lblGracz.TabIndex = 0;
            lblGracz.Text = "label1";
            lblGracz.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWrog
            // 
            lblWrog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWrog.ImageAlign = ContentAlignment.TopLeft;
            lblWrog.Location = new Point(588, 16);
            lblWrog.Name = "lblWrog";
            lblWrog.Size = new Size(395, 445);
            lblWrog.TabIndex = 1;
            lblWrog.Text = "label1";
            // 
            // btnLosuj
            // 
            btnLosuj.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLosuj.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLosuj.Location = new Point(588, 470);
            btnLosuj.Name = "btnLosuj";
            btnLosuj.Size = new Size(193, 65);
            btnLosuj.TabIndex = 2;
            btnLosuj.Text = "Znajdź innego przeciwnika";
            btnLosuj.UseVisualStyleBackColor = true;
            btnLosuj.Click += btnLosuj_Click;
            // 
            // btnWalcz
            // 
            btnWalcz.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnWalcz.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnWalcz.Location = new Point(787, 470);
            btnWalcz.Name = "btnWalcz";
            btnWalcz.Size = new Size(196, 65);
            btnWalcz.TabIndex = 3;
            btnWalcz.Text = "Wejdź na arene!";
            btnWalcz.UseVisualStyleBackColor = true;
            btnWalcz.Click += btnWalcz_Click;
            // 
            // btnWroc
            // 
            btnWroc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWroc.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnWroc.Location = new Point(21, 480);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(157, 55);
            btnWroc.TabIndex = 4;
            btnWroc.Text = "Wróć na ulice";
            btnWroc.UseVisualStyleBackColor = true;
            btnWroc.Click += btnWroc_Click;
            // 
            // lblVS
            // 
            lblVS.Anchor = AnchorStyles.Top;
            lblVS.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblVS.Location = new Point(469, 90);
            lblVS.Name = "lblVS";
            lblVS.Size = new Size(62, 25);
            lblVS.TabIndex = 5;
            lblVS.Text = "VS";
            lblVS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ArenaPrepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblVS);
            Controls.Add(btnWroc);
            Controls.Add(btnWalcz);
            Controls.Add(btnLosuj);
            Controls.Add(lblWrog);
            Controls.Add(lblGracz);
            Name = "ArenaPrepControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
        }

        #endregion

        private Label lblGracz;
        private Label lblWrog;
        private Button btnLosuj;
        private Button btnWalcz;
        private Button btnWroc;
        private Label lblVS;
    }
}
