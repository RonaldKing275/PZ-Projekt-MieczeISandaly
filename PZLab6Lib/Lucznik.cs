using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab6Lib
{
    public class Lucznik : Postac
    {
        public int SzansaNaUnik { get; set; }
        private static Random rand = new Random();

        public Lucznik(string imie) : base(imie, 1, 10, 15, 8, 40, 8, 3)
        {
            SzansaNaUnik = 25;
        }

        public override void OtrzymajObrazenia(int dmg)
        {
            if (rand.Next(1, 101) <= SzansaNaUnik)
            {
                // Unik - Nie dostaje obrażeń
                return;
            }
            base.OtrzymajObrazenia(dmg);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHp += 5;
            Odpornosc += 1;
            Zrecznosc += 4;
            if (SzansaNaUnik <= 75) SzansaNaUnik += 2;
            else SzansaNaUnik = 75;
            AktualneHp = MaxHp;
        }
    }
}
