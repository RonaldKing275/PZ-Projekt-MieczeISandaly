using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    public class ZdalnyProgramista : Programista
    {
        public int Odleglosc { get; set; }
        public ZdalnyProgramista() : base() { }
        public ZdalnyProgramista(int id, string imie, string nazwisko, int wiek, char plec, decimal pensja, int liczbaTechnologii, 
            int odleglosc) : base(id, imie, nazwisko, wiek, plec, pensja, liczbaTechnologii)
        {
            Odleglosc = odleglosc;
        }

        public override void ZwiekszPensje(decimal kwota)
        {
            base.ZwiekszPensje(kwota + (Odleglosc * 5));
        }

        public override string ToString()
        {
            return $"[Zdalny]{base.ToString()}, Odległość: {Odleglosc} km";
        }
    }
}
