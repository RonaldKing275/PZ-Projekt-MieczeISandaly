using System;
using System.Collections.Generic;

namespace PZLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CZĘŚĆ I: METODY GENERYCZNE ===");

            // 1. Zamiana wartości
            int x = 10, y = 20;
            MetodyGeneryczne.Zamien(ref x, ref y);
            Console.WriteLine($"1) Po zamianie: x={x}, y={y}");

            // 2. Wyświetlanie i reset do default
            double liczba = 99.9;
            string tekst = "Witaj";
            Console.WriteLine("\n2) Przed resetem:");
            MetodyGeneryczne.WyswietlIZresetuj(ref liczba, ref tekst);
            Console.WriteLine($"Po resecie: liczba={liczba}, tekst={(tekst == null ? "NULL" : tekst)}");

            // 3. Tworzenie obiektu
            Osoba nowaOsoba = MetodyGeneryczne.UtworzObiekt<Osoba>();
            nowaOsoba.Imie = "Jan"; nowaOsoba.Nazwisko = "Kowalski";
            Console.WriteLine($"\n3) Utworzono: {nowaOsoba}");

            // 4. Większy element
            int wieksza = MetodyGeneryczne.ZwracajWiekszy(5, 15);
            Console.WriteLine($"\n4) Większa z (5, 15) to: {wieksza}");

            // 5. Sortowanie dowolnej liczby parametrów
            var posortowane = MetodyGeneryczne.PosortujElementy(9, 2, 7, 1, 5);
            Console.WriteLine($"\n5) Posortowane parametry: {string.Join(", ", posortowane)}");

            // 6 & 7. Słownik (klucz=struct, wartosc=class)
            var slownik = MetodyGeneryczne.UtworzSlownik(1, nowaOsoba);
            Console.WriteLine("\n6 i 7) Zawartość słownika:");
            MetodyGeneryczne.WyswietlSlownik(slownik);

            // 8. Kolekcja zależna od ilości parametrów (<3 Queue, >=3 Stack)
            var malaKolekcja = MetodyGeneryczne.UtworzKolekcje(1, 2);
            var duzaKolekcja = MetodyGeneryczne.UtworzKolekcje(1, 2, 3, 4);
            Console.WriteLine($"\n8) 2 elementy -> typ kolekcji: {malaKolekcja.GetType().Name}");
            Console.WriteLine($"   4 elementy -> typ kolekcji: {duzaKolekcja.GetType().Name}");


            Console.WriteLine("\n=== CZĘŚĆ II: SAMOCHODY I CZŁOWIEK ===");

            Czlowiek c1 = new Czlowiek("Adam", "Nowak", 30, new List<Samochod> { new Samochod("Audi", 100000), new Samochod("BMW", 150000) });
            Czlowiek c2 = new Czlowiek("Ewa", "Kowalska", 25, new List<Samochod> { new Samochod("Fiat", 20000) });
            Czlowiek c3 = new Czlowiek("Piotr", "Zalewski", 40, new List<Samochod> { new Samochod("Porsche", 500000) });

            Console.WriteLine("Auta Adama (użycie foreach bezpośrednio na obiekcie Czlowiek):");
            foreach (Samochod auto in c1)
            {
                Console.WriteLine($" - {auto}");
            }

            List<Czlowiek> ludzie = new List<Czlowiek> { c1, c2, c3 };
            ludzie.Sort();
            Console.WriteLine("\nLudzie posortowani po łącznej wartości floty:");
            foreach (var czlowiek in ludzie)
            {
                Console.WriteLine(czlowiek);
            }


            Console.WriteLine("\n=== CZĘŚĆ III: CZWÓRKA GENERYCZNA ===");

            List<Czworka<int, string, double, bool>> listaCzworek = new List<Czworka<int, string, double, bool>>
            {
                new Czworka<int, string, double, bool>(3, "Trzy", 3.3, false),
                new Czworka<int, string, double, bool>(1, "Jeden", 1.1, true),
                new Czworka<int, string, double, bool>(2, "Dwa", 2.2, false)
            };

            Console.WriteLine("Przed sortowaniem:");
            foreach (var cz in listaCzworek) Console.WriteLine(cz);

            listaCzworek.Sort();

            Console.WriteLine("\nPo sortowaniu (po pierwszym polu ID):");
            foreach (var cz in listaCzworek) Console.WriteLine(cz);
        }
    }
}