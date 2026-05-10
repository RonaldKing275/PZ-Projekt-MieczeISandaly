using System;
using PZLab21;

namespace PZLab22
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utworzenie obiektu naszej klasy zarządzającej
            ZarzadcaDokumentow menedzer = new ZarzadcaDokumentow();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== SYSTEM ZARZĄDZANIA DOKUMENTAMI ===");
            Console.ResetColor();

            // 1. Dodanie po kilka egzemplarzy
            try
            {
                menedzer.DodajDokument(new Ksiazka("111-222", "Władca Pierścieni", 1954, 1200, "J.R.R. Tolkien"));
                menedzer.DodajDokument(new Ksiazka("111-333", "Hobbit", 1937, 310, "J.R.R. Tolkien"));
                menedzer.DodajDokument(new Tom("333-444", "Harry Potter i Kamień Filozoficzny", 1997, 300, "J.K. Rowling", 1, 7));
                menedzer.DodajDokument(new Tom("333-555", "Harry Potter i Komnata Tajemnic", 1998, 350, "J.K. Rowling", 2, 7));
                menedzer.DodajDokument(new Czasopismo("555-666", "Programista", 2023, 100, 105, Czestotliwosc.Miesiecznik));
                menedzer.DodajDokument(new Czasopismo("777-888", "Gazeta Codzienna", 2023, 20, 300, Czestotliwosc.Dziennik));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPomyślnie dodano początkowe dokumenty.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas inicjalizacji: {ex.Message}");
            }

            // 2. Wyświetlanie listy dokumentów
            Console.WriteLine("\n--- WSZYSTKIE DOKUMENTY ---");
            foreach (var doc in menedzer.PobierzWszystkie())
            {
                Console.WriteLine(doc.ToString());
            }

            // 3. Przetestowanie metod do wyszukiwania
            Console.WriteLine("\n--- WYSZUKIWANIE PO FRASIE 'Potter' ---");
            var znalezione = menedzer.SzukajWTytule("Potter");
            foreach (var doc in znalezione)
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("\n--- WYSZUKIWANIE CZASOPISM (Miesięcznik) ---");
            var czasopisma = menedzer.PobierzCzasopisma(Czestotliwosc.Miesiecznik);
            foreach (var doc in czasopisma)
            {
                Console.WriteLine(doc.ToString());
            }

            // 4. "Wydrukowanie" wszystkich dokumentów
            Console.WriteLine("\n--- DRUKOWANIE DOKUMENTÓW ---");
            foreach (var doc in menedzer.PobierzWszystkie())
            {
                Console.WriteLine(doc.Print());
            }

            // 5. Przechwycenie i obsługa wyjątków z kolorkami
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== TESTOWANIE WYJĄTKÓW ===");
            Console.ResetColor();

            // Sytuacja 1: dodanie dokumentu, który znajduje się już na liście
            try
            {
                Console.WriteLine("Próba dodania duplikatu ISBN...");
                menedzer.DodajDokument(new Ksiazka("111-222", "Inna Książka", 2000, 100, "Jan Kowalski"));
            }
            catch (DuplicateIsbnException ex)
            {
                WyswietlBlad(ex.Message);
            }

            // Sytuacja 2: dodanie tomu o numerze większym od liczby wszystkich tomów
            try
            {
                Console.WriteLine("Próba dodania tomu 8 z 7...");
                menedzer.DodajDokument(new Tom("999-000", "Wiedźmin", 1990, 400, "A. Sapkowski", 8, 7));
            }
            catch (InvalidVolumeException ex)
            {
                WyswietlBlad(ex.Message);
            }

            // Sytuacja 3: dodanie książki z rokiem wydania wcześniejszym niż rok wynalezienia druku
            try
            {
                Console.WriteLine("Próba dodania książki z 1200 roku...");
                menedzer.DodajDokument(new Ksiazka("000-111", "Starożytne Zwoje", 1200, 50, "Nieznany"));
            }
            catch (InvalidPublishYearException ex)
            {
                WyswietlBlad(ex.Message);
            }

            Console.ReadLine();
        }

        static void WyswietlBlad(string wiadomosc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"WYJĄTEK: {wiadomosc}\n");
            Console.ResetColor();
        }
    }
}