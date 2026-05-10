using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab5
{
    public class Potwor
    {
        public string Nazwa { get; set; }
        public int Hp { get; set; }
        public int Obrazenia { get; set; }

        public Potwor(string nazwa, int hp, int obrazenia)
        {
            Nazwa = nazwa;
            Hp = hp;
            Obrazenia = obrazenia;
        }

        public override string ToString() => $"[Potwór] {Nazwa} (HP: {Hp}, DMG: {Obrazenia})";
    }
}
