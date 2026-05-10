using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab4
{
    public class Samochod
    {
        public string Marka { get; set; }
        public decimal Cena { get; set; }

        public Samochod(string marka, decimal cena)
        {
            Marka = marka;
            Cena = cena;
        }

        public override string ToString() => $"{Marka} ({Cena} PLN)";
    }
}
