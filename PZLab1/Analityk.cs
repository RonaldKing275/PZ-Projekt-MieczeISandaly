using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    public class Analityk : Pracownik
    {
        public int LiczbaKlientow { get; set; }
        public Analityk() : base() { }
        public Analityk(int id, string imie, string nazwisko, int wiek, char plec, decimal pensja, int liczbaKlientow)
            : base(id, imie, nazwisko, wiek, plec, pensja)
        {
            LiczbaKlientow = liczbaKlientow;
        }

        public override void ZwiekszPensje(decimal kwota)
        {
            base.ZwiekszPensje(kwota + (LiczbaKlientow * 300));
        }

        public override string ToString()
        {
            return $"[Analityk] {base.ToString()}, Klienci: {LiczbaKlientow}";
        }
    }
}