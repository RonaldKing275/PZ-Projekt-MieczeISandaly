using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    public class Programista : Pracownik
    {
        public int LiczbaTechnologii { get; set; }
        public Programista() : base() { }
        public Programista(int id, string imie, string nazwisko, int wiek, char plec, decimal pensja, int liczbaTechnologii)
            : base(id, imie, nazwisko, wiek, plec, pensja)
        {
            LiczbaTechnologii = liczbaTechnologii;
        }

        public override void ZwiekszPensje(decimal kwota)
        {
            base.ZwiekszPensje(kwota + (LiczbaTechnologii * 200));
        }

        public override string ToString()
        {
            return $"[Programista] {base.ToString()}, Technologie: {LiczbaTechnologii}";
        }
    }
}