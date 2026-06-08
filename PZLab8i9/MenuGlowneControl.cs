using PZLab8i9Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class MenuGlowneControl : UserControl
    {
        private Form1 glowneOkno;
        public MenuGlowneControl(Form1 form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            glowneOkno = form;
        }

        private void btnNowaGra_Click(object sender, EventArgs e)
        {
            glowneOkno.Bohater = new Gracz("Gladiator");
            glowneOkno.ZmienEkran(new RozdajPunktyControl(glowneOkno));
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            string sciezka = KosciolControl.SciezkaZapisu;
            try
            {
                string json = File.ReadAllText(sciezka);
                glowneOkno.Bohater = JsonSerializer.Deserialize<Gracz>(json);
                glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania zapisu: " + ex.Message);
            }
        }
    }
}
