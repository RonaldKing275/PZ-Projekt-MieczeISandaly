using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    public class Wilk : Zwierzak, IMiesozerne
    {
        public Wilk(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        public void ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} poluje w lesie.");
        }

        public void ZjedzMiesko()
        {
            Console.WriteLine($"{Imie} pożera mięso.");
        }
    }

    public class Lew : Zwierzak, IMiesozerne
    {
        public Lew(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        public void ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} poluje na ofiare.");
        }

        public void ZjedzMiesko()
        {
            Console.WriteLine($"{Imie} rozrywa upolowaną zdobycz.");
        }
    }
}
