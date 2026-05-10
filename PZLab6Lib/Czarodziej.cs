using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab6Lib
{
    public class Czarodziej : Postac
    {
        public int AktualnaMana { get; set; }
        public int MaxMana { get; set; }

        public Czarodziej(string imie) : base(imie, 1, 5, 10, 15, 30, 5, 2)
        {
            MaxMana = 50;
            AktualnaMana = 50;
        }

        // Nadpisanie obrażeń
        public static int kosztMany = 40;
        public override int ObrazeniaWRundzie
        {
            get
            {
                if (AktualnaMana >= kosztMany)
                {
                    AktualnaMana -= kosztMany; // Zużywa 40 many na zaklęcie
                    return base.ObrazeniaWRundzie + Inteligencja; // Bije mocniej (z użyciem inteligencji)
                }
                else
                {
                    return 1; // Brak many, mag uderza kosturem za 1 punkt obrażeń
                }
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHp += 4;
            Odpornosc += 1;
            Inteligencja += 8;
            MaxMana += 20;
            AktualnaMana = MaxMana;
            AktualneHp = MaxHp;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Mana: {AktualnaMana}/{MaxMana}";
        }
    }
}
