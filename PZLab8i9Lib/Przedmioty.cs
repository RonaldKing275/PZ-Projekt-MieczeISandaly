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
        public int WymaganyPoziom { get; set; }

        public Przedmiot () { }

        public Przedmiot(string nazwa, int cena, int wymaganyPoziom)
        {
            Nazwa = nazwa;
            Cena = cena;
            WymaganyPoziom = wymaganyPoziom;
        }

        public override string ToString() => $"{Nazwa} (Lv.{WymaganyPoziom}) - {Cena}G";
    }

    public enum TypBroni { Wrecz, Dystansowa }

    public class Bron : Przedmiot
    {
        public int Obrazenia { get; set; }
        public TypBroni Typ { get; set; }
        public int WymaganaSila { get; set; }
        public int WymaganaZrecznosc { get; set; }

        public Bron () { }

        public Bron(string nazwa, int cena, int poziom, int dmg, TypBroni typ, int reqSila = 0, int reqZrecznosc = 0)
            : base(nazwa, cena, poziom)
        {
            Obrazenia = dmg;
            Typ = typ;
            WymaganaSila = reqSila;
            WymaganaZrecznosc = reqZrecznosc;
        }
    }

    public enum CzescZbroi { Helm, Naramienniki, Klata, Spodnie, Buty, Tarcza }
    public class Zbroja : Przedmiot
    {
        public int PunktyPancerza { get; set; }
        public CzescZbroi TypCzesci { get; set; }

        public Zbroja () { }

        public Zbroja(string nazwa, int cena, int poziom, int pancerz, CzescZbroi typCzesci)
            : base(nazwa, cena, poziom)
        {
            PunktyPancerza = pancerz;
            TypCzesci = typCzesci;
        }
    }

    public class Czar : Przedmiot
    {
        public int ObrazeniaMagiczne { get; set; }
        public int KosztStaminy { get; set; }
        public int WymaganaInteligencja { get; set; }

        public Czar() { }

        public Czar(string nazwa, int cena, int poziom, int dmg, int koszt, int reqInt)
            : base(nazwa, cena, poziom)
        {
            ObrazeniaMagiczne = dmg;
            KosztStaminy = koszt;
            WymaganaInteligencja = reqInt;
        }
    }

    public class Mikstura : Przedmiot
    {
        public int LeczenieHp { get; set; }
        public int LeczenieStaminy { get; set; }

        public Mikstura() { }

        public Mikstura(string nazwa, int cena, int poziom, int leczenieHp, int leczenieStaminy)
            : base(nazwa, cena, poziom)
        {
            LeczenieHp = leczenieHp;
            LeczenieStaminy = leczenieStaminy;
        }
    }
}
