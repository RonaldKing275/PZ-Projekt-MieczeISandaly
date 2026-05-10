using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZLab1
{
    class Program
    {
        const decimal RocznyBudzet = 2000000m;
        static void Main(string[] args)
        {
            List<Pracownik> employees = new List<Pracownik>
            {
                new MenadzerProjektu(1, "Jan", "Kowalski", 40, 'M', 10000, 3),
                new MenadzerProjektu(2, "Kasia", "Nowak", 25, 'K', 8500, 2),
                new Analityk(3, "Piotr", "Kowalski", 45, 'M', 8000, 12),
                new Analityk(4, "Maria", "Kowalski", 30, 'K', 7500, 15),
                new Programista(5, "Adam", "Kowalski", 20, 'M', 8500, 6),
                new Programista(6, "Ewa", "Kowalski", 45, 'K', 7800, 8),
                new ZdalnyProgramista(7, "Michał", "Kowalski", 27, 'M', 9000, 7, 60),
                new ZdalnyProgramista(8, "Weronika", "Kowalski", 35, 'K', 8000, 9, 45)
            };

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- MENU ZARZĄDZANIA PRACOWNIKAMI ---");
                Console.ResetColor();
                Console.WriteLine("1. Wyświetl wszystkich pracowników");
                Console.WriteLine("2. Wyświetl pracowników posortowanych malejąco względem pensji");
                Console.WriteLine("3. Wyświetl pracownika o ID");
                Console.WriteLine("4. Zwiększ pensje pracownika o ID");
                Console.WriteLine("5. Zwiększe pensje wszystkim pracownikom");
                Console.WriteLine("6. Wyświetl roczne podsumowanie budżetu");
                Console.WriteLine("7. Wyjście");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (var emp in employees)
                            Console.WriteLine(emp.ToString());
                        break;

                    case "2":
                        var sorted = employees.OrderByDescending(e => e.Pensja).ToList();
                        foreach (var emp in sorted)
                            Console.WriteLine(emp.ToString());
                        break;

                    case "3":
                        Console.Write("Podaj ID pracownika: ");
                        if (int.TryParse(Console.ReadLine(), out int idSzukany))
                        {
                            var pracownik = employees.FirstOrDefault(e => e.Id == idSzukany);
                            if (pracownik != null)
                                Console.WriteLine(pracownik.ToString());
                            else
                                Console.WriteLine("Nie znaleziono pracownika o podanym ID");
                        }
                        break;

                    case "4":
                        Console.Write("Podaj ID pracownika: ");
                        if (int.TryParse(Console.ReadLine(), out int idPodwyzka))
                        {
                            var pracownik = employees.FirstOrDefault(e => e.Id == idPodwyzka);
                            if (pracownik != null)
                            {
                                Console.Write("Podaj kwotę podwyżki: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal kwota))
                                {
                                    pracownik.ZwiekszPensje(kwota);
                                    Console.WriteLine("Pensja została zwiększona.");
                                }
                            }
                            else
                                Console.WriteLine("Nie znaleziono pracownika o podanym ID");
                        }
                        break;

                    case "5":
                        Console.Write("Podaj kwotę podwyżki dla wszystkich: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal kwotaWszyscy))
                        {
                            foreach (var emp in employees)
                            {
                                emp.ZwiekszPensje(kwotaWszyscy);
                            }
                            Console.WriteLine("Pensje zostały zwiększone.");
                        }
                        break;

                    case "6":
                        decimal miesieczneWydatki = employees.Sum(e => e.Pensja);
                        decimal roczneWydatki = miesieczneWydatki * 12;
                        decimal roznica = RocznyBudzet - roczneWydatki;

                        Console.WriteLine($"\nRoczny budżet firmy: {RocznyBudzet:C}");
                        Console.WriteLine($"Suma rocznych wydatków na pensje: {roczneWydatki:C}");

                        Console.Write("Różnica: ");
                        if (roznica >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"+{roznica:C}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{roznica:C}");
                        }
                        Console.ResetColor();
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Niepoprawna opcja!");
                        break;
                }
            }
        }
    }
}
