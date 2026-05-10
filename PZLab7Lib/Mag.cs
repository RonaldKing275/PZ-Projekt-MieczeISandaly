using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab7Lib
{
    public class Mag
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int PunktyDoswiadczenia { get; set; }

        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }

        public int AktualnePunktyZycia { get; set; }
        public int MaksymalnePunktyZycia { get; set; }

        public int AktualnePunktyMany { get; set; }
        public int MaksymalnePunktyMany { get; set; }

        public int ZadawaneObrazenia { get; set; }

        public int OdpornoscFizyczna { get; set; }
        public int OdpornoscOgien { get; set; }
        public int OdpornoscMroz { get; set; }
        public int OdpornoscTrucizna { get; set; }

        public KsiegaCzarow Ksiega { get; set; } = new KsiegaCzarow();

        public Mag(string imie, int poziom, int sila, int zrecznosc, int inteligencja, int maxHp, int maxMana)
        {
            Imie = imie;
            Poziom = poziom;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Inteligencja = inteligencja;
            MaksymalnePunktyZycia = maxHp;
            AktualnePunktyZycia = maxHp;
            MaksymalnePunktyMany = maxMana;
            AktualnePunktyMany = maxMana;
        }

        public override string ToString()
        {
            return $"[Lv.{Poziom}] Arcymag {Imie} | INT: {Inteligencja} | HP: {AktualnePunktyZycia}/{MaksymalnePunktyZycia} | Mana: {AktualnePunktyMany}/{MaksymalnePunktyMany}";
        }
    }
}