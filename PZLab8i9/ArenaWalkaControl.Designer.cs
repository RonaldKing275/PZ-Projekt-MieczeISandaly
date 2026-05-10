namespace PZLab8i9
{
    partial class ArenaWalkaControl
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
            lblImieGracza = new Label();
            lblImieWroga = new Label();
            barHpGracza = new ProgressBar();
            barStaminaGracza = new ProgressBar();
            barHpWroga = new ProgressBar();
            barStaminaWroga = new ProgressBar();
            txtLogi = new TextBox();
            btnZwyklyAtak = new Button();
            btnOdpocznij = new Button();
            btnWroc = new Button();
            SuspendLayout();
            // 
            // lblImieGracza
            // 
            lblImieGracza.AutoSize = true;
            lblImieGracza.Location = new Point(148, 89);
            lblImieGracza.Name = "lblImieGracza";
            lblImieGracza.Size = new Size(50, 20);
            lblImieGracza.TabIndex = 0;
            lblImieGracza.Text = "label1";
            // 
            // lblImieWroga
            // 
            lblImieWroga.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblImieWroga.AutoSize = true;
            lblImieWroga.Location = new Point(777, 89);
            lblImieWroga.Name = "lblImieWroga";
            lblImieWroga.Size = new Size(50, 20);
            lblImieWroga.TabIndex = 1;
            lblImieWroga.Text = "label2";
            // 
            // barHpGracza
            // 
            barHpGracza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barHpGracza.Location = new Point(22, 451);
            barHpGracza.Name = "barHpGracza";
            barHpGracza.Size = new Size(125, 29);
            barHpGracza.TabIndex = 2;
            // 
            // barStaminaGracza
            // 
            barStaminaGracza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barStaminaGracza.Location = new Point(22, 499);
            barStaminaGracza.Name = "barStaminaGracza";
            barStaminaGracza.Size = new Size(125, 29);
            barStaminaGracza.TabIndex = 3;
            // 
            // barHpWroga
            // 
            barHpWroga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            barHpWroga.Location = new Point(855, 451);
            barHpWroga.Name = "barHpWroga";
            barHpWroga.Size = new Size(125, 29);
            barHpWroga.TabIndex = 4;
            // 
            // barStaminaWroga
            // 
            barStaminaWroga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            barStaminaWroga.Location = new Point(855, 499);
            barStaminaWroga.Name = "barStaminaWroga";
            barStaminaWroga.Size = new Size(125, 29);
            barStaminaWroga.TabIndex = 5;
            // 
            // txtLogi
            // 
            txtLogi.Anchor = AnchorStyles.Top;
            txtLogi.Location = new Point(342, 86);
            txtLogi.Multiline = true;
            txtLogi.Name = "txtLogi";
            txtLogi.ReadOnly = true;
            txtLogi.ScrollBars = ScrollBars.Vertical;
            txtLogi.Size = new Size(309, 365);
            txtLogi.TabIndex = 6;
            // 
            // btnZwyklyAtak
            // 
            btnZwyklyAtak.Location = new Point(127, 146);
            btnZwyklyAtak.Name = "btnZwyklyAtak";
            btnZwyklyAtak.Size = new Size(94, 51);
            btnZwyklyAtak.TabIndex = 7;
            btnZwyklyAtak.Text = "Zwykły Atak";
            btnZwyklyAtak.UseVisualStyleBackColor = true;
            btnZwyklyAtak.Click += btnZwyklyAtak_Click;
            // 
            // btnOdpocznij
            // 
            btnOdpocznij.Location = new Point(127, 237);
            btnOdpocznij.Name = "btnOdpocznij";
            btnOdpocznij.Size = new Size(94, 36);
            btnOdpocznij.TabIndex = 8;
            btnOdpocznij.Text = "Odpocznij";
            btnOdpocznij.UseVisualStyleBackColor = true;
            btnOdpocznij.Click += btnOdpocznij_Click;
            // 
            // btnWroc
            // 
            btnWroc.Anchor = AnchorStyles.Bottom;
            btnWroc.Location = new Point(451, 499);
            btnWroc.Name = "btnWroc";
            btnWroc.Size = new Size(94, 29);
            btnWroc.TabIndex = 9;
            btnWroc.Text = "Powrót";
            btnWroc.UseVisualStyleBackColor = true;
            btnWroc.Visible = false;
            btnWroc.Click += btnWroc_Click;
            // 
            // ArenaWalkaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnWroc);
            Controls.Add(btnOdpocznij);
            Controls.Add(btnZwyklyAtak);
            Controls.Add(txtLogi);
            Controls.Add(barStaminaWroga);
            Controls.Add(barHpWroga);
            Controls.Add(barStaminaGracza);
            Controls.Add(barHpGracza);
            Controls.Add(lblImieWroga);
            Controls.Add(lblImieGracza);
            Name = "ArenaWalkaControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImieGracza;
        private Label lblImieWroga;
        private ProgressBar barHpGracza;
        private ProgressBar barStaminaGracza;
        private ProgressBar barHpWroga;
        private ProgressBar barStaminaWroga;
        private TextBox txtLogi;
        private Button btnZwyklyAtak;
        private Button btnOdpocznij;
        private Button btnWroc;
    }
}
