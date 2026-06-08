using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PZLab8i9Lib
{
    [JsonDerivedType(typeof(Bron), typeDiscriminator: "Bron")]
    [JsonDerivedType(typeof(Zbroja), typeDiscriminator: "Zbroja")]
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
    public enum TypZakleciaBroni { Brak, Flame, Frost, Poison, Wraith }
    public enum WielkoscZakleciaBroni { Brak, Male, Srednie, Duze }

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
        public TypZakleciaBroni TypZaklecia { get; set; } = TypZakleciaBroni.Brak;
        public WielkoscZakleciaBroni WielkoscZaklecia { get; set; } = WielkoscZakleciaBroni.Brak;
        public int ZaklecieSzansa { get; set; } = 0;
        public int ZaklecieObrazenia { get; set; } = 0;

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
        public string NazwaIkony { get; set; }
        public int StronaWSklepie { get; set; }
        public int SklepX { get; set; }
        public int SklepY { get; set; }

        public Zbroja () { }

        public Zbroja(string nazwa, int cena, int poziom, int pancerz, CzescZbroi typCzesci,
            string nazwaIkony = "", int strona = 1, int posX = 0, int posY = 0)
            : base(nazwa, cena)
        {
            PunktyPancerza = pancerz;
            TypCzesci = typCzesci;
            WymaganyPoziom = poziom;
            NazwaIkony = nazwaIkony;
            StronaWSklepie = strona;
            SklepX = posX;
            SklepY = posY;
        }

        public override string ToString() => $"{Nazwa} (Wymaga: Lv{WymaganyPoziom}) - {Cena}G";
    }
}
