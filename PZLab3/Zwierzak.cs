using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    public abstract class Zwierzak
    {
        public String Imie {  get; set; }
        public int Wiek {  get; set; }
        public double Waga { get; set; }

        public Zwierzak(string imie, int wiek, double waga)
        {
            Imie = imie;
            Wiek = wiek;
            Waga = waga;
        }

        public override string ToString()
        {
            return $"{GetType().Name} o imieniu {Imie} (Wiek: {Wiek} lat, Waga: {Waga}kg)";
        }
    }
}
