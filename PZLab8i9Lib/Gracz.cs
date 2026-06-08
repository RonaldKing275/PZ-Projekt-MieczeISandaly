using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public class Gracz : Postac
    {
        public int Exp { get; set; }
        public int PunktyDoRozdania { get; set; }
        public int LimitCzarow { get; set; }

        // Wzór: na 1 poziomie potrzeba 200, na 2 poziomie 300, itd.
        public int WymaganyExp => (Poziom + 1) * 100;

        public Gracz(string imie) : base(imie, 1)
        {
            Sila = 1;
            Zrecznosc = 1;
            Inteligencja = 1;
            Charyzma = 1;
            Witalnosc = 1;
            Wytrzymalosc = 1;
            Zloto = 400;

            PunktyDoRozdania = 10;

            PrzeliczMaxPaski();
            AktualneHp = MaxHp;
            AktualnaStamina = MaxStamina;
        }

        public int ObliczCenePoRabacie(int cenaBazowa)
        {
            // Każdy punkt charyzmy to 1% rabatu, maksymalnie 50% zniżki
            double procentRabatu = Math.Min(Charyzma * 0.01, 0.5);
            return (int)(cenaBazowa * (1.0 - procentRabatu));
        }

        public void KupPrzedmiot(Przedmiot p)
        {
            int cenaPoRabacie = ObliczCenePoRabacie(p.Cena);

            if (Zloto < cenaPoRabacie)
                throw new NotEnoughGoldException($"Nie masz złota! Cena po rabacie ({Charyzma} Charyzmy): {cenaPoRabacie}G.");

            if (p is Bron b)
            {
                if (Sila < b.WymaganaSila) throw new RequirementNotMetException($"Za mało siły! Wymagane: {b.WymaganaSila}");
                if (Zrecznosc < b.WymaganaZrecznosc) throw new RequirementNotMetException($"Za mało zręczności! Wymagane: {b.WymaganaZrecznosc}");
            }
            else if (p is Zbroja z)
            {
                if (Poziom < z.WymaganyPoziom) throw new RequirementNotMetException($"Za niski poziom! Wymagany: {z.WymaganyPoziom}");
            }

            Zloto -= cenaPoRabacie;

            switch (p)
            {
                case Bron nowaBron:
                    WyposazonaBron = nowaBron;
                    break;

                case Zbroja nowaZbroja:
                    UbranyPancerz[nowaZbroja.TypCzesci] = nowaZbroja;
                    OdnowPancerz();
                    break;
            }
        }

        public void DodajExp(int iloscExp)
        {
            Exp += iloscExp;

            while (Exp >= WymaganyExp)
            {
                Exp -= WymaganyExp;
                Poziom++;
                PunktyDoRozdania += 4;

                PrzeliczMaxPaski();
                AktualneHp = MaxHp;
                AktualnaStamina = MaxStamina;
            }
        }
    }
}
