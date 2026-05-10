using System;
using System.Windows.Forms;
using PZLab8i9Lib;
using System.ComponentModel;

namespace PZLab8i9
{
    public partial class Form1 : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Gracz Bohater { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Text = "Miecze i Sandały - MiniProjekt";
            this.Size = new System.Drawing.Size(1000, 550);
            this.StartPosition = FormStartPosition.CenterScreen;

            Bohater = new Gracz("Gladiator");

            if (Bohater.PunktyDoRozdania > 0)
            {
                ZmienEkran(new RozdajPunktyControl(this));
            }
            else
            {
                ZmienEkran(new UlicaControl(this));
            }
        }

        public void ZmienEkran(UserControl nowyEkran)
        {
            this.Controls.Clear();              // Czyszczenie obecnego okna
            nowyEkran.Dock = DockStyle.Fill;    // Rozciągnięcie nowego ekranu na całe okno
            this.Controls.Add(nowyEkran);       // Dodanie nowego ekranu do widoku
        }
    }
}
