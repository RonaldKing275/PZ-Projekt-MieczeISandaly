using System;
using System.Collections.Generic;
using System.Text;
using PZLab8i9Lib;

namespace PZLab8i9
{
    public class SklepBazowyControl : UserControl
    {
        protected Form1 glowneOkno;

        public SklepBazowyControl() { }

        public SklepBazowyControl(Form1 form)
        {
            glowneOkno = form;
        }

        protected void WypiszStatystyki(Label labelUI, string dodatkoweInfo = "")
        {
            var b = glowneOkno.Bohater;
            string bron = b.WyposazonaBron != null ? b.WyposazonaBron.Nazwa : "Pięści";

            labelUI.Text = $"Złoto: {b.Zloto}G | Broń: {bron} ({b.ObliczObrazeniaZwykle()} dmg) {dodatkoweInfo}\n" +
                           $"Siła: {b.Sila} | Zręczność: {b.Zrecznosc} | Inteligencja: {b.Inteligencja}\n" +
                           $"Charyzma: {b.Charyzma} | Witalność: {b.Witalnosc} | Wytrzymałość: {b.Wytrzymalosc}\n" +
                           $"Pancerz:\n{b.PobierzRaportPancerza()}";
        }

        protected void ObsluzZakup<T>(ListBox lst, List<T> bazaPrzedmiotow, string infoPoZakupie) where T : Przedmiot
        {
            int index = lst.SelectedIndex;

            if (index >= 0)
            {
                T wybranyPrzedmiot = bazaPrzedmiotow[index];

                try
                {
                    glowneOkno.Bohater.KupPrzedmiot(wybranyPrzedmiot);
                    MessageBox.Show($"Kupiłeś: {wybranyPrzedmiot.Nazwa}!\n{infoPoZakupie}", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        protected void ObsluzPrzyciskWrot()
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}