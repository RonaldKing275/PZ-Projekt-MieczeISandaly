using PZLab3;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ZarzadcaZwierzat zoo = new ZarzadcaZwierzat();

            Console.WriteLine("=== SYSTEM ZARZĄDZANIA ZOO ===");

            zoo.DodajZwierzaka(new Owca("Benek", 3, 40.5));
            zoo.DodajZwierzaka(new Krowa("Mućka", 5, 450.0));
            zoo.DodajZwierzaka(new Wilk("Geralt", 4, 35.0));
            zoo.DodajZwierzaka(new Lew("Tuk", 6, 220.0));
            zoo.DodajZwierzaka(new Swinia("Peppa", 2, 80.0));
            zoo.DodajZwierzaka(new Dzik("Buk", 8, 300.0));

            zoo.KopiujZwierzaki();
            Console.WriteLine("\n[Zwierzaki zostały skopiowane do odpowiednich list dietetycznych]");

            zoo.WyswietlWszystkieZwierzaki();

            Console.WriteLine("\n--- TYLKO ROŚLINOŻERNE ---");
            zoo.WyswietlRoslinozerne();

            Console.WriteLine("\n--- TYLKO MIĘSOŻERNE ---");
            zoo.WyswietlMiesozerne();

            Console.WriteLine("\n--- GRUPOWE KARMIENIE ROŚLINOŻERCÓW ---");
            zoo.NakarmWszystkieRoslinozerne();

            Console.WriteLine("\n--- GRUPOWE KARMIENIE MIĘSOŻERCÓW ---");
            zoo.NakarmWszystkieMiesozerne();

            Console.WriteLine("\n--- INDYWIDUALNE KARMIENIE ---");

            var lew = zoo.PobierzZwierzakaPoImieniu("Tuk") as IMiesozerne;
            if (lew != null)
            {
                Console.WriteLine("\nKarmienie lwa mięskiem:");
                ZarzadcaZwierzat.NakarmPojedynczegoMiesozerce(lew);
            }

            var swinia = zoo.PobierzZwierzakaPoImieniu("Peppa") as IRoslinozerne;
            if (swinia != null)
            {
                Console.WriteLine("\nKarmienie świni rośliną:");
                ZarzadcaZwierzat.NakarmPojedynczegoRoslinozerce(swinia);
            }
        }
    }
}