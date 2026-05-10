using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab5
{
    public class Najemnik
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int Exp { get; set; }
        public int AktualneHp { get; set; }
        public int MaxHp { get; set; }
        public int Obrazenia { get; set; }
        public int Zloto { get; set; }

        public Najemnik(string imie, int poziom, int maxHp, int obrazenia)
        {
            Imie = imie;
            Poziom = poziom;
            MaxHp = maxHp;
            AktualneHp = maxHp;
            Obrazenia = obrazenia;
            Exp = 0;
            Zloto = 0;
        }

        public override string ToString() =>
            $"[Lv.{Poziom}] {Imie} | HP: {AktualneHp}/{MaxHp} | DMG: {Obrazenia} | EXP: {Exp} | Złoto: {Zloto}G";
    }   
}
