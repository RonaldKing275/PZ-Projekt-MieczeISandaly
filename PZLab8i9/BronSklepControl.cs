using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PZLab8i9Lib;

namespace PZLab8i9
{
    public partial class BronSklepControl : UserControl
    {
        private Form1 glowneOkno;
        public BronSklepControl(Form1 form)
        {
            InitializeComponent();
            glowneOkno = form;

            ZaladujSklep();
        }

        private void ZaladujSklep()
        {
            var b = glowneOkno.Bohater;
            string bron = b.WyposazonaBron != null ? b.WyposazonaBron.Nazwa : "Pięści";

            lblZloto.Text = $"Złoto: {b.Zloto}G | Broń: {bron} ({b.ObliczObrazeniaZwykle()} dmg)\n" +
                            $"Siła: {b.Sila} | Zręczność: {b.Zrecznosc} | Inteligencja: {b.Inteligencja}\n" +
                            $"Charyzma: {b.Charyzma} | Witalność: {b.Witalnosc} | Wytrzymałość: {b.Wytrzymalosc}\n" +
                            $"Pancerz:\n{b.PobierzRaportPancerza()}";

            lstAsortyment.Items.Clear();
            foreach (var przedmiot in BazaPrzedmiotow.WszystkieBronie)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(przedmiot.Cena);
                lstAsortyment.Items.Add($"{przedmiot.Nazwa} - {cenaFinalna}G (Wymaga: S{przedmiot.WymaganaSila}/Z{przedmiot.WymaganaZrecznosc})");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            int index = lstAsortyment.SelectedIndex;

            if (index >= 0)
            {
                Bron wybranaBron = BazaPrzedmiotow.WszystkieBronie[index];

                try
                {
                    glowneOkno.Bohater.KupPrzedmiot(wybranaBron);

                    MessageBox.Show($"Kupiłeś: {wybranaBron.Nazwa}!\nZostała automatycznie wyposażona jako Twoja główna broń.", "Zakup udany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ZaladujSklep();
                }
                catch (NotEnoughGoldException ex)
                {
                    MessageBox.Show(ex.Message, "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (RequirementNotMetException ex)
                {
                    MessageBox.Show(ex.Message, "Jesteś za słaby!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz broń z listy!");
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
