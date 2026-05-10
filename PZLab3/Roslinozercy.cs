using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    public class Owca : Zwierzak, IRoslinozerne
    {
        public Owca(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        public void ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} szuka trawy na pastwisku.");
        }

        public void ZjedzRoslinke()
        {
            Console.WriteLine($"{Imie} zjadł ze smakiem zielsko.");
        }
    }

    public class Krowa : Zwierzak, IRoslinozerne
    {
        public Krowa(string imie, int wiek, double waga) : base(imie, wiek, waga) { }

        public void ZnajdzPozywienie()
        {
            Console.WriteLine($"{Imie} szuka trawy na łące.");
        }

        public void ZjedzRoslinke()
        {
            Console.WriteLine($"{Imie} przeżuwa zielone.");
        }
    }
}
