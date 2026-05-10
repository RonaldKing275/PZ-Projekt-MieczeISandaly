using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab7Lib
{
    public class KsiegaCzarow : List<Czar>
    {
        public override string ToString()
        {
            if (this.Count == 0) return "Księga czarów jest pusta.";

            // Wykorzystanie this do iteracji po samej sobie
            string wynik = "Zaklęcia w księdze:\n";
            foreach (var czar in this)
            {
                wynik += $"   - {czar.ToString()}\n";
            }
            return wynik;
        }
    }
}