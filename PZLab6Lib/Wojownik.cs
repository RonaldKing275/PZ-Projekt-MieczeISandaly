using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab6Lib
{
    public class Wojownik : Postac
    {
        public int LiczbaAtakowNaRunde { get; set; }

        public Wojownik(string imie) : base(imie, 1, 15, 10, 5, 50, 10, 5)
        {
            LiczbaAtakowNaRunde = 2;
        }

        // Nadpisanie, Wojownik uderza kilka razy
        public override int ObrazeniaWRundzie => base.ObrazeniaWRundzie * LiczbaAtakowNaRunde;

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHp += 12;
            Sila += 4;
            Odpornosc += 3;
            AktualneHp = MaxHp;
        }
    }
}
