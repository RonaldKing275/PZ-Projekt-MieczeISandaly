namespace PZLab8i9
{
    partial class RozdajPunktyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RozdajPunktyControl));
            lblStatystyki = new Label();
            lblPunkty = new Label();
            btnSila = new Button();
            btnZrecznosc = new Button();
            btnInteligencja = new Button();
            btnCharyzma = new Button();
            btnWitalnosc = new Button();
            btnWytrzymalosc = new Button();
            btnZatwierdz = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnZatwierdz).BeginInit();
            SuspendLayout();
            // 
            // lblStatystyki
            // 
            lblStatystyki.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatystyki.BackColor = Color.Transparent;
            lblStatystyki.Location = new Point(17, 190);
            lblStatystyki.Name = "lblStatystyki";
            lblStatystyki.Size = new Size(199, 345);
            lblStatystyki.TabIndex = 0;
            lblStatystyki.Text = "label1";
            lblStatystyki.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPunkty
            // 
            lblPunkty.BackColor = Color.Transparent;
            lblPunkty.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblPunkty.Location = new Point(50, 28);
            lblPunkty.Name = "lblPunkty";
            lblPunkty.Size = new Size(319, 85);
            lblPunkty.TabIndex = 1;
            lblPunkty.Text = "label1";
            lblPunkty.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnSila
            // 
            btnSila.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSila.Cursor = Cursors.Hand;
            btnSila.Location = new Point(222, 206);
            btnSila.Name = "btnSila";
            btnSila.Size = new Size(133, 29);
            btnSila.TabIndex = 2;
            btnSila.Text = "+1 Siła";
            btnSila.UseVisualStyleBackColor = true;
            btnSila.Click += btnSila_Click;
            // 
            // btnZrecznosc
            // 
            btnZrecznosc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnZrecznosc.Cursor = Cursors.Hand;
            btnZrecznosc.Location = new Point(222, 267);
            btnZrecznosc.Name = "btnZrecznosc";
            btnZrecznosc.Size = new Size(133, 29);
            btnZrecznosc.TabIndex = 3;
            btnZrecznosc.Text = "+1 Zręczność";
            btnZrecznosc.UseVisualStyleBackColor = true;
            btnZrecznosc.Click += btnZrecznosc_Click;
            // 
            // btnInteligencja
            // 
            btnInteligencja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnInteligencja.Cursor = Cursors.Hand;
            btnInteligencja.Location = new Point(222, 327);
            btnInteligencja.Name = "btnInteligencja";
            btnInteligencja.Size = new Size(133, 29);
            btnInteligencja.TabIndex = 4;
            btnInteligencja.Text = "+1 Inteligencja";
            btnInteligencja.UseVisualStyleBackColor = true;
            btnInteligencja.Click += btnInteligencja_Click;
            // 
            // btnCharyzma
            // 
            btnCharyzma.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCharyzma.Cursor = Cursors.Hand;
            btnCharyzma.Location = new Point(222, 386);
            btnCharyzma.Name = "btnCharyzma";
            btnCharyzma.Size = new Size(133, 29);
            btnCharyzma.TabIndex = 5;
            btnCharyzma.Text = "+1 Charyzma";
            btnCharyzma.UseVisualStyleBackColor = true;
            btnCharyzma.Click += btnCharyzma_Click;
            // 
            // btnWitalnosc
            // 
            btnWitalnosc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWitalnosc.Cursor = Cursors.Hand;
            btnWitalnosc.Location = new Point(222, 445);
            btnWitalnosc.Name = "btnWitalnosc";
            btnWitalnosc.Size = new Size(133, 29);
            btnWitalnosc.TabIndex = 6;
            btnWitalnosc.Text = "+1 Witalność";
            btnWitalnosc.UseVisualStyleBackColor = true;
            btnWitalnosc.Click += btnWitalnosc_Click;
            // 
            // btnWytrzymalosc
            // 
            btnWytrzymalosc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWytrzymalosc.Cursor = Cursors.Hand;
            btnWytrzymalosc.Location = new Point(222, 506);
            btnWytrzymalosc.Name = "btnWytrzymalosc";
            btnWytrzymalosc.Size = new Size(133, 29);
            btnWytrzymalosc.TabIndex = 7;
            btnWytrzymalosc.Text = "+1 Wytrzymałość";
            btnWytrzymalosc.UseVisualStyleBackColor = true;
            btnWytrzymalosc.Click += btnWytrzymalosc_Click;
            // 
            // btnZatwierdz
            // 
            btnZatwierdz.BackColor = Color.Transparent;
            btnZatwierdz.Cursor = Cursors.Hand;
            btnZatwierdz.Location = new Point(908, 468);
            btnZatwierdz.Name = "btnZatwierdz";
            btnZatwierdz.Size = new Size(76, 71);
            btnZatwierdz.TabIndex = 8;
            btnZatwierdz.TabStop = false;
            btnZatwierdz.Click += btnZatwierdz_Click;
            // 
            // RozdajPunktyControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnZatwierdz);
            Controls.Add(btnWytrzymalosc);
            Controls.Add(btnWitalnosc);
            Controls.Add(btnCharyzma);
            Controls.Add(btnInteligencja);
            Controls.Add(btnZrecznosc);
            Controls.Add(btnSila);
            Controls.Add(lblPunkty);
            Controls.Add(lblStatystyki);
            Name = "RozdajPunktyControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)btnZatwierdz).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblStatystyki;
        private Label lblPunkty;
        private Button btnSila;
        private Button btnZrecznosc;
        private Button btnInteligencja;
        private Button btnCharyzma;
        private Button btnWitalnosc;
        private Button btnWytrzymalosc;
        private PictureBox btnZatwierdz;
    }
}
