using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    public class MenadzerProjektu : Pracownik
    {
        public int LiczbaProjektow { get; set; }
        public MenadzerProjektu() : base() { }
        public MenadzerProjektu(int id, string imie, string nazwisko, int wiek, char plec, decimal pensja, int liczbaProjektow)
            : base(id, imie, nazwisko, wiek, plec, pensja)
        {
            LiczbaProjektow = liczbaProjektow;
        }

        public override void ZwiekszPensje(decimal kwota)
        {
            base.ZwiekszPensje(kwota + (LiczbaProjektow * 500));
        }

        public override string ToString()
        {
            return $"[Menadżer] {base.ToString()}, Projekty: {LiczbaProjektow}";
        }
    }
}
