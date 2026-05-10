using PZLab6Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab6
{
    public static class Rozszerzenia
    {
        // 1) Pełne uzdrowienie postaci
        public static void WypijNapojLeczacy(this Postac p)
        {
            p.AktualneHp = p.MaxHp;
        }

        // 2) Regeneracja many tylko dla Czarodzieja
        public static void RegenerujMane(this Czarodziej c, int wartosc)
        {
            c.AktualnaMana += wartosc;
            if (c.AktualnaMana > c.MaxMana) c.AktualnaMana = c.MaxMana; // Nie może przekroczyć maxa
        }

        // 3) Rozbrojenie (zmniejsza DMG)
        public static void Rozbroj(this Postac p, int wartosc)
        {
            p.Obrazenia -= wartosc;
            if (p.Obrazenia < 0) p.Obrazenia = 0;
        }

        // 4) Zdejmowanie pancerza (zmniejsza Odporność)
        public static void ZdejmijPancerz(this Postac p, int wartosc)
        {
            p.Odpornosc -= wartosc;
            if (p.Odpornosc < 0) p.Odpornosc = 0;
        }
    }
}
