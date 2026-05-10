namespace PZLab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWojownik = new Label();
            lblLucznik = new Label();
            lblCzarodziej = new Label();
            lblSmok = new Label();
            lblNapoje = new Label();
            pbWojownik = new ProgressBar();
            pbLucznik = new ProgressBar();
            pbCzarodziej = new ProgressBar();
            pbSmok = new ProgressBar();
            btnRunda = new Button();
            btnSymulacja = new Button();
            btnReset = new Button();
            btnLeczWojownika = new Button();
            btnLeczLucznika = new Button();
            btnLeczCzarodzieja = new Button();
            txtExpLucznik = new TextBox();
            txtExpCzarodziej = new TextBox();
            txtExpWojownik = new TextBox();
            btnExpWojownik = new Button();
            btnExpLucznik = new Button();
            btnExpCzarodziej = new Button();
            SuspendLayout();
            // 
            // lblWojownik
            // 
            lblWojownik.AutoSize = true;
            lblWojownik.Location = new Point(23, 28);
            lblWojownik.Name = "lblWojownik";
            lblWojownik.Size = new Size(74, 20);
            lblWojownik.TabIndex = 0;
            lblWojownik.Text = "Wojownik";
            // 
            // lblLucznik
            // 
            lblLucznik.AutoSize = true;
            lblLucznik.Location = new Point(23, 102);
            lblLucznik.Name = "lblLucznik";
            lblLucznik.Size = new Size(57, 20);
            lblLucznik.TabIndex = 1;
            lblLucznik.Text = "Lucznik";
            // 
            // lblCzarodziej
            // 
            lblCzarodziej.AutoSize = true;
            lblCzarodziej.Location = new Point(23, 178);
            lblCzarodziej.Name = "lblCzarodziej";
            lblCzarodziej.Size = new Size(79, 20);
            lblCzarodziej.TabIndex = 2;
            lblCzarodziej.Text = "Czarodziej";
            // 
            // lblSmok
            // 
            lblSmok.AutoSize = true;
            lblSmok.Location = new Point(498, 83);
            lblSmok.Name = "lblSmok";
            lblSmok.Size = new Size(46, 20);
            lblSmok.TabIndex = 3;
            lblSmok.Text = "Smok";
            // 
            // lblNapoje
            // 
            lblNapoje.AutoSize = true;
            lblNapoje.Location = new Point(28, 278);
            lblNapoje.Name = "lblNapoje";
            lblNapoje.Size = new Size(58, 20);
            lblNapoje.TabIndex = 4;
            lblNapoje.Text = "Napoje";
            // 
            // pbWojownik
            // 
            pbWojownik.Location = new Point(23, 51);
            pbWojownik.Name = "pbWojownik";
            pbWojownik.Size = new Size(92, 29);
            pbWojownik.TabIndex = 5;
            // 
            // pbLucznik
            // 
            pbLucznik.Location = new Point(23, 125);
            pbLucznik.Name = "pbLucznik";
            pbLucznik.Size = new Size(92, 29);
            pbLucznik.TabIndex = 6;
            // 
            // pbCzarodziej
            // 
            pbCzarodziej.Location = new Point(23, 201);
            pbCzarodziej.Name = "pbCzarodziej";
            pbCzarodziej.Size = new Size(92, 29);
            pbCzarodziej.TabIndex = 7;
            // 
            // pbSmok
            // 
            pbSmok.Location = new Point(498, 106);
            pbSmok.Name = "pbSmok";
            pbSmok.Size = new Size(127, 29);
            pbSmok.TabIndex = 8;
            // 
            // btnRunda
            // 
            btnRunda.Location = new Point(28, 368);
            btnRunda.Name = "btnRunda";
            btnRunda.Size = new Size(127, 29);
            btnRunda.TabIndex = 9;
            btnRunda.Text = "Nastepna Runda";
            btnRunda.UseVisualStyleBackColor = true;
            btnRunda.Click += btnRunda_Click_1;
            // 
            // btnSymulacja
            // 
            btnSymulacja.Location = new Point(264, 368);
            btnSymulacja.Name = "btnSymulacja";
            btnSymulacja.Size = new Size(94, 29);
            btnSymulacja.TabIndex = 10;
            btnSymulacja.Text = "Symulacja";
            btnSymulacja.UseVisualStyleBackColor = true;
            btnSymulacja.Click += btnSymulacja_Click_1;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(446, 368);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click_1;
            // 
            // btnLeczWojownika
            // 
            btnLeczWojownika.Location = new Point(133, 264);
            btnLeczWojownika.Name = "btnLeczWojownika";
            btnLeczWojownika.Size = new Size(94, 49);
            btnLeczWojownika.TabIndex = 12;
            btnLeczWojownika.Text = "Lecz Wojownika";
            btnLeczWojownika.UseVisualStyleBackColor = true;
            btnLeczWojownika.Click += btnLeczWojownika_Click_1;
            // 
            // btnLeczLucznika
            // 
            btnLeczLucznika.Location = new Point(280, 264);
            btnLeczLucznika.Name = "btnLeczLucznika";
            btnLeczLucznika.Size = new Size(94, 49);
            btnLeczLucznika.TabIndex = 13;
            btnLeczLucznika.Text = "Lecz Lucznika";
            btnLeczLucznika.UseVisualStyleBackColor = true;
            btnLeczLucznika.Click += btnLeczLucznika_Click_1;
            // 
            // btnLeczCzarodzieja
            // 
            btnLeczCzarodzieja.Location = new Point(426, 264);
            btnLeczCzarodzieja.Name = "btnLeczCzarodzieja";
            btnLeczCzarodzieja.Size = new Size(98, 49);
            btnLeczCzarodzieja.TabIndex = 14;
            btnLeczCzarodzieja.Text = "Lecz Czarodzieja";
            btnLeczCzarodzieja.UseVisualStyleBackColor = true;
            btnLeczCzarodzieja.Click += btnLeczCzarodzieja_Click_1;
            // 
            // txtExpLucznik
            // 
            txtExpLucznik.Location = new Point(280, 127);
            txtExpLucznik.Name = "txtExpLucznik";
            txtExpLucznik.Size = new Size(94, 27);
            txtExpLucznik.TabIndex = 16;
            txtExpLucznik.TextChanged += txtExpLucznik_TextChanged;
            // 
            // txtExpCzarodziej
            // 
            txtExpCzarodziej.Location = new Point(280, 203);
            txtExpCzarodziej.Name = "txtExpCzarodziej";
            txtExpCzarodziej.Size = new Size(94, 27);
            txtExpCzarodziej.TabIndex = 17;
            txtExpCzarodziej.TextChanged += txtExpCzarodziej_TextChanged;
            // 
            // txtExpWojownik
            // 
            txtExpWojownik.Location = new Point(280, 51);
            txtExpWojownik.Name = "txtExpWojownik";
            txtExpWojownik.Size = new Size(94, 27);
            txtExpWojownik.TabIndex = 18;
            txtExpWojownik.TextChanged += txtExpWojownik_TextChanged;
            // 
            // btnExpWojownik
            // 
            btnExpWojownik.Location = new Point(185, 51);
            btnExpWojownik.Name = "btnExpWojownik";
            btnExpWojownik.Size = new Size(89, 29);
            btnExpWojownik.TabIndex = 19;
            btnExpWojownik.Text = "Dodaj Exp";
            btnExpWojownik.UseVisualStyleBackColor = true;
            btnExpWojownik.Click += btnExpWojownik_Click;
            // 
            // btnExpLucznik
            // 
            btnExpLucznik.Location = new Point(185, 127);
            btnExpLucznik.Name = "btnExpLucznik";
            btnExpLucznik.Size = new Size(89, 29);
            btnExpLucznik.TabIndex = 20;
            btnExpLucznik.Text = "Dodaj Exp";
            btnExpLucznik.UseVisualStyleBackColor = true;
            btnExpLucznik.Click += btnExpLucznik_Click;
            // 
            // btnExpCzarodziej
            // 
            btnExpCzarodziej.Location = new Point(185, 201);
            btnExpCzarodziej.Name = "btnExpCzarodziej";
            btnExpCzarodziej.Size = new Size(89, 29);
            btnExpCzarodziej.TabIndex = 21;
            btnExpCzarodziej.Text = "Dodaj Exp";
            btnExpCzarodziej.UseVisualStyleBackColor = true;
            btnExpCzarodziej.Click += btnExpCzarodziej_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExpCzarodziej);
            Controls.Add(btnExpLucznik);
            Controls.Add(btnExpWojownik);
            Controls.Add(txtExpWojownik);
            Controls.Add(txtExpCzarodziej);
            Controls.Add(txtExpLucznik);
            Controls.Add(btnLeczCzarodzieja);
            Controls.Add(btnLeczLucznika);
            Controls.Add(btnLeczWojownika);
            Controls.Add(btnReset);
            Controls.Add(btnSymulacja);
            Controls.Add(btnRunda);
            Controls.Add(pbSmok);
            Controls.Add(pbCzarodziej);
            Controls.Add(pbLucznik);
            Controls.Add(pbWojownik);
            Controls.Add(lblNapoje);
            Controls.Add(lblSmok);
            Controls.Add(lblCzarodziej);
            Controls.Add(lblLucznik);
            Controls.Add(lblWojownik);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWojownik;
        private Label lblLucznik;
        private Label lblCzarodziej;
        private Label lblSmok;
        private Label lblNapoje;
        private ProgressBar pbWojownik;
        private ProgressBar pbLucznik;
        private ProgressBar pbCzarodziej;
        private ProgressBar pbSmok;
        private Button btnRunda;
        private Button btnSymulacja;
        private Button btnReset;
        private Button btnLeczWojownika;
        private Button btnLeczLucznika;
        private Button btnLeczCzarodzieja;
        private TextBox txtExpLucznik;
        private TextBox txtExpCzarodziej;
        private TextBox txtExpWojownik;
        private Button btnExpWojownik;
        private Button btnExpLucznik;
        private Button btnExpCzarodziej;
    }
}
