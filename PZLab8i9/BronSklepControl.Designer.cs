namespace PZLab8i9
{
    partial class BronSklepControl
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
            lblZloto = new Label();
            pictureBox1 = new PictureBox();
            btnMiecze = new Button();
            btnTopory = new Button();
            btnMaczugi = new Button();
            btnLuki = new Button();
            btnNastepnaStrona = new Button();
            pnlPolkaSklepowa = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblZloto
            // 
            lblZloto.AutoSize = true;
            lblZloto.BackColor = Color.White;
            lblZloto.Location = new Point(104, 31);
            lblZloto.Name = "lblZloto";
            lblZloto.Size = new Size(50, 20);
            lblZloto.TabIndex = 1;
            lblZloto.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(921, 472);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 75);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnMiecze
            // 
            btnMiecze.BackColor = Color.Transparent;
            btnMiecze.FlatAppearance.BorderSize = 0;
            btnMiecze.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMiecze.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMiecze.FlatStyle = FlatStyle.Flat;
            btnMiecze.Location = new Point(529, 154);
            btnMiecze.Name = "btnMiecze";
            btnMiecze.Size = new Size(43, 166);
            btnMiecze.TabIndex = 6;
            btnMiecze.UseVisualStyleBackColor = false;
            btnMiecze.Click += btnMiecze_Click;
            // 
            // btnTopory
            // 
            btnTopory.BackColor = Color.Transparent;
            btnTopory.FlatAppearance.BorderSize = 0;
            btnTopory.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTopory.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTopory.FlatStyle = FlatStyle.Flat;
            btnTopory.Location = new Point(597, 142);
            btnTopory.Name = "btnTopory";
            btnTopory.Size = new Size(82, 178);
            btnTopory.TabIndex = 7;
            btnTopory.UseVisualStyleBackColor = false;
            btnTopory.Click += btnTopory_Click;
            // 
            // btnMaczugi
            // 
            btnMaczugi.BackColor = Color.Transparent;
            btnMaczugi.FlatAppearance.BorderSize = 0;
            btnMaczugi.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMaczugi.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMaczugi.FlatStyle = FlatStyle.Flat;
            btnMaczugi.Location = new Point(707, 142);
            btnMaczugi.Name = "btnMaczugi";
            btnMaczugi.Size = new Size(65, 178);
            btnMaczugi.TabIndex = 8;
            btnMaczugi.UseVisualStyleBackColor = false;
            btnMaczugi.Click += btnMaczugi_Click;
            // 
            // btnLuki
            // 
            btnLuki.BackColor = Color.Transparent;
            btnLuki.FlatAppearance.BorderSize = 0;
            btnLuki.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLuki.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLuki.FlatStyle = FlatStyle.Flat;
            btnLuki.Location = new Point(819, 154);
            btnLuki.Name = "btnLuki";
            btnLuki.Size = new Size(41, 166);
            btnLuki.TabIndex = 9;
            btnLuki.UseVisualStyleBackColor = false;
            btnLuki.Click += btnLuki_Click;
            // 
            // btnNastepnaStrona
            // 
            btnNastepnaStrona.Location = new Point(603, 472);
            btnNastepnaStrona.Name = "btnNastepnaStrona";
            btnNastepnaStrona.Size = new Size(199, 36);
            btnNastepnaStrona.TabIndex = 10;
            btnNastepnaStrona.Text = "Następna Strona";
            btnNastepnaStrona.UseVisualStyleBackColor = true;
            btnNastepnaStrona.Click += btnNastepnaStrona_Click;
            // 
            // pnlPolkaSklepowa
            // 
            pnlPolkaSklepowa.BackColor = Color.Transparent;
            pnlPolkaSklepowa.Location = new Point(496, 31);
            pnlPolkaSklepowa.Name = "pnlPolkaSklepowa";
            pnlPolkaSklepowa.Padding = new Padding(2);
            pnlPolkaSklepowa.Size = new Size(414, 435);
            pnlPolkaSklepowa.TabIndex = 11;
            // 
            // BronSklepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MiSSklepBronieGotowe;
            Controls.Add(pnlPolkaSklepowa);
            Controls.Add(btnMiecze);
            Controls.Add(btnNastepnaStrona);
            Controls.Add(btnLuki);
            Controls.Add(btnMaczugi);
            Controls.Add(btnTopory);
            Controls.Add(pictureBox1);
            Controls.Add(lblZloto);
            Name = "BronSklepControl";
            Size = new Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblZloto;
        private PictureBox pictureBox1;
        private Button btnMiecze;
        private Button btnTopory;
        private Button btnMaczugi;
        private Button btnLuki;
        private Button btnNastepnaStrona;
        private Panel pnlPolkaSklepowa;
    }
}
