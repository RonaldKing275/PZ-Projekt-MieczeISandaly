using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public class PrzeciwnikKomputer : Postac
    {
        private Random rnd = new Random();

        private enum BotArchetyp { Wojownik, Lucznik, Mag, Tank }

        public PrzeciwnikKomputer(string imie, int poziomGracza) : base(imie, poziomGracza)
        {
            Zloto = poziomGracza * 50;
            int punktyDoRozdania = 10 + ((poziomGracza - 1) * 4);

            Sila = 1;
            Zrecznosc = 1;
            Inteligencja = 1;
            Charyzma = 1;
            Witalnosc = 1;
            Wytrzymalosc = 1;

            // LOSOWANIE ARCHETYPU BOTA
            BotArchetyp archetyp = (BotArchetyp)rnd.Next(4);

            // MĄDRZEJSZE ROZDAWANIE PUNKTÓW
            for (int i = 0; i < punktyDoRozdania; i++)
            {
                // 60% szans, że punkt pójdzie w główne statystyki archetypu, 40% na losowe
                if (rnd.Next(100) < 60)
                {
                    switch (archetyp)
                    {
                        case BotArchetyp.Wojownik:
                            if (rnd.Next(2) == 0) Sila++; else Witalnosc++;
                            break;
                        case BotArchetyp.Lucznik:
                            if (rnd.Next(2) == 0) Zrecznosc++; else Wytrzymalosc++;
                            break;
                        case BotArchetyp.Mag:
                            if (rnd.Next(2) == 0) Inteligencja++; else Charyzma++;
                            break;
                        case BotArchetyp.Tank:
                            if (rnd.Next(2) == 0) Witalnosc++; else Wytrzymalosc++;
                            break;
                    }
                }
                else
                {
                    // Pozostałe 40% idzie w losowe statystyki
                    int wylosowanaStatystyka = rnd.Next(6);
                    switch (wylosowanaStatystyka)
                    {
                        case 0: Sila++; break;
                        case 1: Zrecznosc++; break;
                        case 2: Inteligencja++; break;
                        case 3: Charyzma++; break;
                        case 4: Witalnosc++; break;
                        case 5: Wytrzymalosc++; break;
                    }
                }
            }

            PrzeliczMaxPaski();
            AktualneHp = MaxHp;
            AktualnaStamina = MaxStamina;

            WylosujEkwipunek(poziomGracza);
        }

        private void WylosujEkwipunek(int poziom)
        {
            // Pobranie wszystkich broni gdzie statystyki bota spełniają wymagania
            var mozliweBronie = BazaPrzedmiotow.WszystkieBronie
                .Where(b => b.WymaganaSila <= Sila && b.WymaganaZrecznosc <= Zrecznosc)
                .ToList();

            // Oddzielenie i sortowanie broni Wręcz
            var bronieWrecz = mozliweBronie
                .Where(b => b.Zasieg == RodzajZasiegu.Wrecz)
                .OrderByDescending(b => b.MaxObrazenia)
                .ToList();

            // Oddzielenie i sortowanie broni Dystansowych
            var bronieDystansowe = mozliweBronie
                .Where(b => b.Zasieg == RodzajZasiegu.Dystansowa)
                .OrderByDescending(b => b.MaxObrazenia)
                .ToList();

            // Wyposażenie w TOP 3 najlepszych Broni Głównych (Wręcz)
            if (bronieWrecz.Any())
            {
                int pulaWrecz = Math.Min(3, bronieWrecz.Count);
                WyposazonaBronGlowna = bronieWrecz[rnd.Next(pulaWrecz)];
            }

            // Wyposażenie w TOP 3 najlepszych Broni Pomocniczych (Dystansowych)
            if (bronieDystansowe.Any())
            {
                int pulaDystans = Math.Min(3, bronieDystansowe.Count);
                WyposazonaBronPomocnicza = bronieDystansowe[rnd.Next(pulaDystans)];
            }

            // Pobranie wszystkich Zbroi gdzie Poziom bota spełniają wymagania
            var dostepneZbroje = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.WymaganyPoziom <= poziom).ToList();

            if (poziom > 1 && dostepneZbroje.Any())
            {
                // Szansa na zbroję rośnie o 10% co level (max 90%)
                int szansaNaZbroje = Math.Min(90, 20 + (poziom * 10));

                foreach (CzescZbroi czesc in Enum.GetValues(typeof(CzescZbroi)))
                {
                    var zbrojeNaCzesc = dostepneZbroje.Where(z => z.TypCzesci == czesc).ToList();

                    if (zbrojeNaCzesc.Any() && rnd.Next(100) < szansaNaZbroje)
                    {
                        Zbroja pancerz = zbrojeNaCzesc[rnd.Next(zbrojeNaCzesc.Count)];
                        UbranyPancerz[czesc] = pancerz;
                    }
                }
            }
        }
    }
}