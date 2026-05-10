using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab7Lib
{
    public enum TypCzaru
    {
        Ofensywne,
        Defensywne,
        Uzdrawiajace
    }

    public class Czar
    {
        public string Nazwa { get; set; }
        public TypCzaru Typ { get; set; }
        public int Koszt { get; set; }
        public int Okres { get; set; }
        public int Efekt { get; set; }

        public Czar(string nazwa, TypCzaru typ, int koszt, int okres, int efekt)
        {
            Nazwa = nazwa;
            Typ = typ;
            Koszt = koszt;
            Okres = okres;
            Efekt = efekt;
        }

        public override string ToString()
        {
            return $"[{Typ}] {Nazwa} | Mana: {Koszt} | CD: {Okres} | Efekt: {Efekt}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Czar innyCzar)
            {
                return this.ToString() == innyCzar.ToString();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}