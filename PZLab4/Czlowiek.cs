using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PZLab4
{
    public class Czlowiek : IEnumerable<Samochod>, IComparable<Czlowiek>
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public List<Samochod> ListaSamochodow { get; set; }

        public Czlowiek()
        {
            ListaSamochodow = new List<Samochod>();
        }

        public Czlowiek(string imie, string nazwisko, int wiek, List<Samochod> samochody)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            ListaSamochodow = samochody ?? new List<Samochod>();
        }

        public decimal LacznaWartoscSamochodow() => ListaSamochodow.Sum(s => s.Cena);

        public override string ToString()
        {
            string auta = string.Join(", ", ListaSamochodow);
            return $"{Imie} {Nazwisko} ({Wiek} lat) | Auta: [{auta}] | Wartość floty: {LacznaWartoscSamochodow()} PLN";
        }

        public IEnumerator<Samochod> GetEnumerator()
        {
            return ListaSamochodow.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Czlowiek other)
        {
            if (other == null) return 1;
            return this.LacznaWartoscSamochodow().CompareTo(other.LacznaWartoscSamochodow());
        }
    }
}
