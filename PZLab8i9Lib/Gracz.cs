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
            else if (p is Czar c)
            {
                if (Inteligencja < c.WymaganaInteligencja) throw new RequirementNotMetException($"Za mało inteligencji! Wymagane: {c.WymaganaInteligencja}");

                int aktualnaLiczbaCzarow = PosiadanePrzedmioty.Count(item => item is Czar);

                // PROGI: 1lv->1, 3lv->2, 5lv->3, 8lv->4, 12lv->5, 16lv->6, 20lv->7, 25lv->8
                LimitCzarow = (Poziom >= 25) ? 8 : (Poziom >= 20) ? 7 : (Poziom >= 16) ? 6 : 
                    (Poziom >= 12) ? 5 : (Poziom >= 8) ? 4 : (Poziom >= 5) ? 3 : (Poziom >= 3) ? 2 : 1;

                // Jeśli chce kupić kolejny, a nie ma miejsca
                if (aktualnaLiczbaCzarow >= LimitCzarow)
                {
                    throw new RequirementNotMetException($"Brak miejsca na pasku czarów! Twój limit to {LimitCzarow}.");
                }
            }

            Zloto -= p.Cena;

            switch (p)
            {
                case Bron nowaBron:
                    WyposazonaBron = nowaBron;
                    break;

                case Zbroja nowaZbroja:
                    UbranyPancerz[nowaZbroja.TypCzesci] = nowaZbroja;
                    break;

                case Czar nowyCzar:
                    PosiadanePrzedmioty.Add(nowyCzar);
                    break;

                case Mikstura nowaMikstura:
                    PosiadanePrzedmioty.Add(nowaMikstura);
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
