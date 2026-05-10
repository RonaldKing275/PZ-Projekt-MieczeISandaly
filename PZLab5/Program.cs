using System;
using System.Collections.Generic;

namespace PZLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            GildiaNajemnikow gildia = new GildiaNajemnikow();

            // 1. SUBSKRYPCJA ZDARZEŃ (PODPINANIE WŁASNYCH METOD)
            gildia.OnMercenaryHired += (n) =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[WIEŚCI Z GILDII]: Nowy rekrut, {n.Imie}, dołącza do naszych szeregów!");
                Console.ResetColor();
            };

            gildia.OnQuestAdded += (w) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[TABLICA OGŁOSZEŃ]: Powieszono nowy pergamin! Misja: '{w.Nazwa}' w {w.Lokalizacja}.");
                Console.ResetColor();
            };

            gildia.OnQuestCompleting += (n, w) =>
            {
                Console.WriteLine($"\n>>> {n.Imie} ostrzy broń i rusza do {w.Lokalizacja} na spotkanie z {w.Potwor.Nazwa}...");
            };

            gildia.OnQuestCompleted += (n, w) =>
            {
                Console.WriteLine($"<<< Wyprawa '{w.Nazwa}' zakończona. Aktualny stan najemnika: HP={n.AktualneHp}, Złoto={n.Zloto}G, Exp={n.Exp}");
            };


            Console.WriteLine("=== INICJALIZACJA GILDII ===");

            // 2. DODAWANIE DO GILDII I TESTOWANIE WYJĄTKÓW
            try
            {
                gildia.DodajNajemnika(new Najemnik("Greed", 5, 200, 75));
                gildia.DodajNajemnika(new Najemnik("Jishuka", 2, 60, 15));
                gildia.DodajNajemnika(new Najemnik("Greed", 2, 50, 10)); // Do testowania wyjątku DuplicatedNameException

                gildia.DodajWyprawe(new Wyprawa("Walka z Golemem", "Zabij golema z labiryntu", "Labirynt", 
                    TrudnoscWyprawy.Trudna, new Potwor("Wielki Golem", 200, 40), 100, 300));
                gildia.DodajWyprawe(new Wyprawa("Ubij Demony", "Zabij gwiardie króla demonów", "Zamek Króla Demonów", 
                    TrudnoscWyprawy.Treningowa, new Potwor("Gwiarda Króla Demonów", 100, 15), 10, 20));
            }
            catch (DuplicatedNameException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"WYJĄTEK: {ex.Message}");
                Console.ResetColor();
            }

            // 3. TESTOWANIE DELEGATÓW NA LISTACH
            Console.WriteLine("\n=== ZESTAWIENIE NAJEMNIKÓW (Wykorzystanie Delegata) ===");
            gildia.WykonajDlaNajemnikow(n => Console.WriteLine($" > {n.Imie} zadaje {n.Obrazenia} obrażeń."));

            Console.WriteLine("\n=== ZESTAWIENIE POTWORÓW (Wykorzystanie Delegata) ===");
            gildia.WykonajDlaWypraw(w => Console.WriteLine($" > Cel misji '{w.Nazwa}': {w.Potwor.Nazwa}, " +
                $"obrażenia: {w.Potwor.Obrazenia}, hp: {w.Potwor.Hp}"));

            // 4. TESTOWANIE WYSZUKIWANIA
            Console.WriteLine("\n=== ZNAJDOWANIE SILNYCH NAJEMNIKÓW (> 2 lvl lub > 50 HP) ===");
            List<Najemnik> silni = gildia.ZnajdzSilnychNajemnikow(2, 50);
            foreach (var s in silni) Console.WriteLine(s.ToString());

            // 5. TESTOWANIE WYPRAW
            Console.WriteLine("\n=== CZAS NA AKCJĘ ===");
            gildia.WyslijNaWyprawe("Greed", "Walka z Golemem");
            gildia.WyslijNaWyprawe("Jishuka", "Ubij Demony");

            Console.ReadLine();
        }
    }
}