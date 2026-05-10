using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab5
{
    public class Wyprawa
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Lokalizacja { get; set; }
        public TrudnoscWyprawy Trudnosc { get; set; }
        public Potwor Potwor { get; set; }
        public int ExpNagroda { get; set; }
        public int ZlotoNagroda { get; set; }

        public Wyprawa(string nazwa, string opis, string lokalizacja, TrudnoscWyprawy trudnosc, Potwor potwor, int expNagroda, int zlotoNagroda)
        {
            Nazwa = nazwa;
            Opis = opis;
            Lokalizacja = lokalizacja;
            Trudnosc = trudnosc;
            Potwor = potwor;
            ExpNagroda = expNagroda;
            ZlotoNagroda = zlotoNagroda;
        }

        public override string ToString() =>
            $"[Wyprawa] {Nazwa} ({Trudnosc}) w {Lokalizacja} | Cel: {Potwor.Nazwa} | Obrażenia: {Potwor.Obrazenia} | HP: {Potwor.Hp} | Nagroda: {ZlotoNagroda}G, {ExpNagroda}EXP";
    }
}
