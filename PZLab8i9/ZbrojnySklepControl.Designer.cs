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
            btnKup = new Button();
            btnWroc = new Button();
            SuspendLayout();
            // 
            // lstAsortyment
            // 
            lstAsortyment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstAsortyment.FormattingEnabled = true;
            lstAsortyment.Location = new Point(583, 12);
            lstAsortyment.Name = "lstAsortyment";
            lstAsortyment.Size = new Size(401, 464);
            lstAsortyment.TabIndex = 4;
            // 
            // lblZloto
            // 
            lblZloto.AutoSize = true;
            lblZloto.Location = new Point(21, 12);
            lblZloto.Name = "lblZloto";
            lblZloto.Size = new Size(50, 20);
            lblZloto.TabIndex = 1;
            lblZloto.Text = "label1";
            // 
            // btnKup
            // 
            btnKup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKup.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnKup.Location = new Point(583, 480);
            btnKup.Name = "btnKup";
            btnKup.Size = new Size(401, 55);
            btnKup.TabIndex = 0;
            btnKup.Text = "Kup przedmiot";
            btnKup.UseVisualStyleBackColor = true;
            btnKup.Click += btnKup_Click;
            // 
            // btnWroc
            // 
            btnWroc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWroc.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnWroc.Location = new Point(21, 480);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(157, 55);
            btnWroc.TabIndex = 3;
            btnWroc.Text = "Wróć na ulice";
            btnWroc.UseVisualStyleBackColor = true;
            btnWroc.Click += btnWroc_Click;
            // 
            // ZbrojnySklepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnWroc);
            Controls.Add(btnKup);
            Controls.Add(lblZloto);
            Controls.Add(lstAsortyment);
            Name = "ZbrojnySklepControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstAsortyment;
        private Label lblZloto;
        private Button btnKup;
        private Button btnWroc;
    }
}
