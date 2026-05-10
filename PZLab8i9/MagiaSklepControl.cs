using PZLab8i9Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class MagiaSklepControl : UserControl
    {
        private Form1 glowneOkno;
        public MagiaSklepControl(Form1 form)
        {
            InitializeComponent();
            glowneOkno = form;

            ZaladujSklep();
        }

        private void ZaladujSklep()
        {
            var b = glowneOkno.Bohater;
            int aktualneCzary = b.PosiadanePrzedmioty.Count(p => p is Czar);

            string bron = b.WyposazonaBron != null ? b.WyposazonaBron.Nazwa : "Pięści";

            lblZloto.Text = $"Złoto: {b.Zloto}G | Czary: {aktualneCzary}/{b.LimitCzarow} | Broń: {bron}\n" +
                            $"Siła: {b.Sila} | Zręczność: {b.Zrecznosc} | Inteligencja: {b.Inteligencja}\n" +
                            $"Charyzma: {b.Charyzma} | Witalność: {b.Witalnosc} | Wytrzymałość: {b.Wytrzymalosc}\n" +
                            $"Pancerz: {b.PobierzRaportPancerza()}";

            lstAsortyment.Items.Clear();
            foreach (var czar in BazaPrzedmiotow.WszystkieCzary)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(czar.Cena);
                lstAsortyment.Items.Add($"{czar.Nazwa} - {cenaFinalna}G (Wymaga: {czar.WymaganaInteligencja} Inteligencji)");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            if (lstAsortyment.SelectedItem is Czar wybranyCzar)
            {
                try
                {
                    glowneOkno.Bohater.KupPrzedmiot(wybranyCzar);

                    MessageBox.Show($"Nauczyłeś się zaklęcia: {wybranyCzar.Nazwa}!", "Zakup udany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ZaladujSklep();
                }
                catch (NotEnoughGoldException ex)
                {
                    MessageBox.Show(ex.Message, "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (RequirementNotMetException ex)
                {
                    MessageBox.Show(ex.Message, "Brak predyspozycji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz czar z listy!");
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
