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
    public partial class ZbrojnySklepControl : UserControl
    {
        private Form1 glowneOkno;
        public ZbrojnySklepControl(Form1 form)
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
            foreach (var zbroja in BazaPrzedmiotow.WszystkieZbroje)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(zbroja.Cena);
                lstAsortyment.Items.Add($"{zbroja.Nazwa} - {cenaFinalna}G (Wymaga: Poziom {zbroja.WymaganyPoziom})");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            int index = lstAsortyment.SelectedIndex;

            if (index >= 0)
            {
                Zbroja wybranaZbroja = BazaPrzedmiotow.WszystkieZbroje[index];

                try
                {
                    glowneOkno.Bohater.KupPrzedmiot(wybranaZbroja);

                    MessageBox.Show($"Kupiłeś: {wybranaZbroja.Nazwa}!\nZałożono automatycznie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ZaladujSklep();
                }
                catch (NotEnoughGoldException ex)
                {
                    MessageBox.Show(ex.Message, "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (RequirementNotMetException ex)
                {
                    MessageBox.Show(ex.Message, "Wymagania niespełnione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz przedmiot z listy!");
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
