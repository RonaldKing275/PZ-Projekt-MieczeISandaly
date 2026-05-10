using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    public class Swinia : Zwierzak, IRoslinozerne, IMiesozerne
    {
        public Swinia(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        void IRoslinozerne.ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} szuka w korycie.");
        }

        public void ZjedzRoslinke()
        {
            Console.WriteLine($"{Imie} zjada siano.");
        }

        void IMiesozerne.ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} szuka mięska.");
        }

        public void ZjedzMiesko()
        {
            Console.WriteLine($"{Imie} zjada mięsko.");
        }
    }

    public class Dzik : Zwierzak, IRoslinozerne, IMiesozerne
    {
        public Dzik(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        void IRoslinozerne.ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} poszedł w szyszki.");
        }

        public void ZjedzRoslinke()
        {
            Console.WriteLine($"{Imie} zjada żołędzie.");
        }

        void IMiesozerne.ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} brodzi w rzece.");
        }

        public void ZjedzMiesko()
        {
            Console.WriteLine($"{Imie} zjada rybę.");
        }
    }
}