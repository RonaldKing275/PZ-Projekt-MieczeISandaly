using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PZLab8i9Lib
{
    [JsonDerivedType(typeof(Bron), typeDiscriminator: "Bron")]
    [JsonDerivedType(typeof(Zbroja), typeDiscriminator: "Zbroja")]
    [JsonDerivedType(typeof(Czar), typeDiscriminator: "Czar")]
    [JsonDerivedType(typeof(Mikstura), typeDiscriminator: "Mikstura")]
    public abstract class Przedmiot
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public Przedmiot () { }

        public Przedmiot(string nazwa, int cena)
        {
            Nazwa = nazwa;
            Cena = cena;
        }

        public override string ToString() => $"{Nazwa} - {Cena}G";
    }

    public enum TypBroni { Miecze, Topory, Maczugi, Luki }
    public enum RodzajZasiegu { Wrecz, Dystansowa }

    public class Bron : Przedmiot
    {
        public int MinObrazenia { get; set; }
        public int MaxObrazenia { get; set; }
        public TypBroni Typ { get; set; }
        public RodzajZasiegu Zasieg { get; set; }
        public int WymaganaSila { get; set; }
        public int WymaganaZrecznosc { get; set; }
        public string NazwaIkony { get; set; }
        public int StronaWSklepie { get; set; } // Na której stronie (1, 2 czy 3) ma się pojawić
        public int SklepX { get; set; } // Oś X na ekranie
        public int SklepY { get; set; } // Oś Y na ekranie

        public Bron () { }

        public Bron(string nazwa, int cena, int minDmg, TypBroni typ, RodzajZasiegu zasieg, string nazwaIkony,
            int strona, int posX, int posY, int reqSila = 0, int reqZrecznosc = 0)
            : base(nazwa, cena)
        {
            MinObrazenia = minDmg;
            Typ = typ;
            Zasieg = zasieg;
            NazwaIkony = nazwaIkony;
            StronaWSklepie = strona;
            SklepX = posX;
            SklepY = posY;
            WymaganaSila = reqSila;
            WymaganaZrecznosc = reqZrecznosc;

            // LOGIKA SWORDS & SANDALS 2
            switch (Typ)
            {
                case TypBroni.Miecze:
                case TypBroni.Luki:
                    // Wzór: Max = Min^2
                    MaxObrazenia = minDmg * minDmg;
                    break;
                case TypBroni.Topory:
                    // Wzór: Max = Min * 4
                    MaxObrazenia = minDmg * 4;
                    break;
                case TypBroni.Maczugi:
                    // Wzór: Max = Min * 3
                    MaxObrazenia = minDmg * 3;
                    break;
                default:
                    MaxObrazenia = minDmg;
                    break;
            }
        }

        public override string ToString() => $"{Nazwa} (Wymaga: S{WymaganaSila}/Z{WymaganaZrecznosc}) - {Cena}G";
    }

    public enum CzescZbroi { Helm, Naramienniki, Klata, Spodnie, Buty, Tarcza }
    public class Zbroja : Przedmiot
    {
        public int PunktyPancerza { get; set; }
        public CzescZbroi TypCzesci { get; set; }
        public int WymaganyPoziom { get; set; }

        public Zbroja () { }

        public Zbroja(string nazwa, int cena, int poziom, int pancerz, CzescZbroi typCzesci)
            : base(nazwa, cena)
        {
            PunktyPancerza = pancerz;
            TypCzesci = typCzesci;
            WymaganyPoziom = poziom;
        }

        public override string ToString() => $"{Nazwa} (Wymaga: Lv{WymaganyPoziom}) - {Cena}G";
    }

    public class Czar : Przedmiot
    {
        public int ObrazeniaMagiczne { get; set; }
        public int KosztStaminy { get; set; }
        public int WymaganaInteligencja { get; set; }

        public Czar() { }

        public Czar(string nazwa, int cena, int dmg, int koszt, int reqInt)
            : base(nazwa, cena)
        {
            ObrazeniaMagiczne = dmg;
            KosztStaminy = koszt;
            WymaganaInteligencja = reqInt;
        }

        public override string ToString() => $"{Nazwa} (Wymaga: {WymaganaInteligencja} Int) - {Cena}G";
    }

    public class Mikstura : Przedmiot
    {
        public int LeczenieHp { get; set; }
        public int LeczenieStaminy { get; set; }

        public Mikstura() { }

        public Mikstura(string nazwa, int cena, int leczenieHp, int leczenieStaminy)
            : base(nazwa, cena)
        {
            LeczenieHp = leczenieHp;
            LeczenieStaminy = leczenieStaminy;
        }

        // TODO: Napisać ToString
    }
}
