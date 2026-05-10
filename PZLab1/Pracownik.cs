using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    public abstract class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek {  get; set; }
        public char Plec {  get; set; }
        public decimal Pensja { get; set; }

        public Pracownik() { }

        public Pracownik(int id, string imie, string nazwisko, int wiek, char plec, decimal pensja)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Plec = plec;
            Pensja = pensja;
        }

        public virtual void ZwiekszPensje(decimal kwota)
        {
            Pensja += kwota;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Imie} {Nazwisko}, {Wiek}, Płeć {Plec}, Pensja: {Pensja} PLN";
        }
    }
}
