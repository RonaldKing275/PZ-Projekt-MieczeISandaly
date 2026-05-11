using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public class PrzeciwnikKomputer : Postac
    {
        private Random rnd = new Random();

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

            for (int i = 0; i < punktyDoRozdania; i++)
            {
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

            PrzeliczMaxPaski();
            AktualneHp = MaxHp;
            AktualnaStamina = MaxStamina;

            WylosujEkwipunek(poziomGracza);
        }

        private void WylosujEkwipunek(int poziom)
        {
            var dostepneBronie = BazaPrzedmiotow.WszystkieBronie
                .Where(b => b.WymaganaSila <= Sila && b.WymaganaZrecznosc <= Zrecznosc)
                .ToList();
            var dostepneZbroje = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.WymaganyPoziom <= poziom).ToList();

            if (dostepneBronie.Any())
            {
                int wylosowanyIndexBroni = rnd.Next(dostepneBronie.Count);
                WyposazonaBron = dostepneBronie[wylosowanyIndexBroni];
            }
            
            // powyżej 1lvla + 50%
            if (poziom > 1 && dostepneZbroje.Any() && rnd.Next(100) < 50)
            {
                int wylosowanyIndexZbroi = rnd.Next(dostepneZbroje.Count);
                Zbroja pancerz = dostepneZbroje[wylosowanyIndexZbroi];
                UbranyPancerz[pancerz.TypCzesci] = pancerz;
            }

            /* Lepsza metoda losująca zbroje do Projektu
            if (poziom > 1 && dostepneZbroje.Any())
            {
                foreach (CzescZbroi czesc in Enum.GetValues(typeof(CzescZbroi)))
                {
                    var zbrojeNaCzesc = dostepneZbroje.Where(z => z.TypCzesci == czesc).ToList();
        
                    // 50% szans na posiadanie przedmiotu w danym slocie
                    if (zbrojeNaCzesc.Any() && rnd.Next(100) < 50)
                    {
                        Zbroja pancerz = zbrojeNaCzesc[rnd.Next(zbrojeNaCzesc.Count)];
                        UbranyPancerz[czesc] = pancerz;
                    }
                }
            }
             */
        }
    }
}