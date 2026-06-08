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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BronSklepControl));
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
            lblZloto.BackColor = Color.White;
            resources.ApplyResources(lblZloto, "lblZloto");
            lblZloto.Name = "lblZloto";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnMiecze
            // 
            btnMiecze.BackColor = Color.Transparent;
            btnMiecze.Cursor = Cursors.Hand;
            btnMiecze.FlatAppearance.BorderSize = 0;
            btnMiecze.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMiecze.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnMiecze, "btnMiecze");
            btnMiecze.Name = "btnMiecze";
            btnMiecze.UseVisualStyleBackColor = false;
            btnMiecze.Click += btnMiecze_Click;
            // 
            // btnTopory
            // 
            btnTopory.BackColor = Color.Transparent;
            btnTopory.Cursor = Cursors.Hand;
            btnTopory.FlatAppearance.BorderSize = 0;
            btnTopory.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTopory.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnTopory, "btnTopory");
            btnTopory.Name = "btnTopory";
            btnTopory.UseVisualStyleBackColor = false;
            btnTopory.Click += btnTopory_Click;
            // 
            // btnMaczugi
            // 
            btnMaczugi.BackColor = Color.Transparent;
            btnMaczugi.Cursor = Cursors.Hand;
            btnMaczugi.FlatAppearance.BorderSize = 0;
            btnMaczugi.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMaczugi.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnMaczugi, "btnMaczugi");
            btnMaczugi.Name = "btnMaczugi";
            btnMaczugi.UseVisualStyleBackColor = false;
            btnMaczugi.Click += btnMaczugi_Click;
            // 
            // btnLuki
            // 
            btnLuki.BackColor = Color.Transparent;
            btnLuki.Cursor = Cursors.Hand;
            btnLuki.FlatAppearance.BorderSize = 0;
            btnLuki.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLuki.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnLuki, "btnLuki");
            btnLuki.Name = "btnLuki";
            btnLuki.UseVisualStyleBackColor = false;
            btnLuki.Click += btnLuki_Click;
            // 
            // btnNastepnaStrona
            // 
            btnNastepnaStrona.Cursor = Cursors.Hand;
            resources.ApplyResources(btnNastepnaStrona, "btnNastepnaStrona");
            btnNastepnaStrona.Name = "btnNastepnaStrona";
            btnNastepnaStrona.UseVisualStyleBackColor = true;
            btnNastepnaStrona.Click += btnNastepnaStrona_Click;
            // 
            // pnlPolkaSklepowa
            // 
            pnlPolkaSklepowa.BackColor = Color.Transparent;
            resources.ApplyResources(pnlPolkaSklepowa, "pnlPolkaSklepowa");
            pnlPolkaSklepowa.Name = "pnlPolkaSklepowa";
            // 
            // BronSklepControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MiSSklepBronie1Gotowe;
            Controls.Add(pnlPolkaSklepowa);
            Controls.Add(btnMiecze);
            Controls.Add(btnNastepnaStrona);
            Controls.Add(btnLuki);
            Controls.Add(btnMaczugi);
            Controls.Add(btnTopory);
            Controls.Add(pictureBox1);
            Controls.Add(lblZloto);
            Name = "BronSklepControl";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
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
