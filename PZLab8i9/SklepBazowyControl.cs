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

            string bronWrecz = b.WyposazonaBronGlowna != null ? b.WyposazonaBronGlowna.Nazwa : "Pięści";
            string bronDystans = b.WyposazonaBronPomocnicza != null ? b.WyposazonaBronPomocnicza.Nazwa : "Brak";

            string dystansInfo = bronDystans == "Brak" ? "Brak" : $"{bronDystans} ({b.ObliczObrazeniaZwykle(true)} dmg)";

            labelUI.Text = $"Złoto: {b.Zloto}G {dodatkoweInfo}\n" +
                           $"Wręcz: {bronWrecz} ({b.ObliczObrazeniaZwykle(false)} dmg)\n" +
                           $"Dystans: {dystansInfo}\n" +
                           $"Siła: {b.Sila} | Zręczność: {b.Zrecznosc} | Inteligencja: {b.Inteligencja}\n" +
                           $"Charyzma: {b.Charyzma} | Witalność: {b.Witalnosc} | Wytrzymałość: {b.Wytrzymalosc}\n" +
                           $"Pancerz:\n{b.PobierzRaportPancerza()}";
        }

        protected void ObsluzPrzyciskWrot()
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }

        protected void UstawDomyslnaChmurke(Label labelUI, string dodatkoweInfo = "")
        {
            WypiszStatystyki(labelUI, dodatkoweInfo);
        }
    }
}