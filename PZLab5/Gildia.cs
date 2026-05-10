using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab5
{
    public class GildiaNajemnikow
    {
        private List<Najemnik> najemnicy = new List<Najemnik>();
        private List<Wyprawa> wyprawy = new List<Wyprawa>();

        public event NajemnikAkcja OnMercenaryHired;
        public event WyprawaAkcja OnQuestAdded;
        public event NajemnikWyprawaAkcja OnQuestCompleting;
        public event NajemnikWyprawaAkcja OnQuestCompleted;

        public void DodajNajemnika(Najemnik n)
        {
            if (najemnicy.Exists(x => x.Imie.Equals(n.Imie, StringComparison.OrdinalIgnoreCase)))
                throw new DuplicatedNameException($"Najemnik o imieniu {n.Imie} już należy do gildii!");

            najemnicy.Add(n);
            if (OnMercenaryHired != null) OnMercenaryHired(n);
        }

        public void DodajWyprawe(Wyprawa w)
        {
            if (wyprawy.Exists(x => x.Nazwa.Equals(w.Nazwa, StringComparison.OrdinalIgnoreCase)))
                throw new DuplicatedNameException($"Wyprawa o nazwie '{w.Nazwa}' znajduje się już na tablicy ogłoszeń!");

            wyprawy.Add(w);
            if (OnQuestAdded != null) OnQuestAdded(w);
        }

        public void WyslijNaWyprawe(string imieNajemnika, string nazwaWyprawy)
        {
            Najemnik n = ZnajdzNajemnika(imieNajemnika);
            Wyprawa w = ZnajdzWyprawe(nazwaWyprawy);

            if (n == null || w == null)
            {
                Console.WriteLine("Błąd! Nie znaleziono najemnika lub wyprawy.");
                return;
            }

            // Przed wyprawą
            if (OnQuestCompleting != null) OnQuestCompleting(n, w);

            // Logika walki
            Console.ForegroundColor = ConsoleColor.Yellow;
            int hpPotwora = w.Potwor.Hp;
            int tura = 1;

            while (n.AktualneHp > 0 && hpPotwora > 0)
            {
                Console.WriteLine($"Runda: {tura}");
                // Najemnik bije potwora
                hpPotwora -= n.Obrazenia;
                Console.WriteLine($"{n.Imie} uderzył {w.Potwor.Nazwa} za: {n.Obrazenia}dmg");
                Console.WriteLine($"Pozostałe hp {w.Potwor.Nazwa}: {hpPotwora}hp");

                // Jeśli potwór przeżył, oddaje cios
                if (hpPotwora > 0)
                {
                    n.AktualneHp -= w.Potwor.Obrazenia;
                    Console.WriteLine($"{w.Potwor.Nazwa} uderzył {n.Imie} za: {w.Potwor.Obrazenia}dmg");
                    Console.WriteLine($"Pozostałe hp {n.Imie}: {n.AktualneHp}hp\n");
                }
                tura++;
            }

            if (n.AktualneHp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSukces! {n.Imie} pokonuje {w.Potwor.Nazwa} (zostało mu {n.AktualneHp} HP) i wraca z łupami!");
                n.Exp += w.ExpNagroda;
                n.Zloto += w.ZlotoNagroda;
            }
            else
            {
                n.AktualneHp = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Porażka... {n.Imie} został zmasakrowany przez {w.Potwor.Nazwa} i ledwo uchodzi z życiem (0 HP).");
                Console.WriteLine($"Potworowi {w.Potwor.Nazwa} zostało {hpPotwora}hp.");
            }
            Console.ResetColor();

            // Po wyprawie
            if (OnQuestCompleted != null) OnQuestCompleted(n, w);
        }

        public void WykonajDlaNajemnikow(NajemnikAkcja akcja)
        {
            foreach (var n in najemnicy) akcja(n);
        }

        public void WykonajDlaWypraw(WyprawaAkcja akcja)
        {
            foreach (var w in wyprawy) akcja(w);
        }

        public Najemnik ZnajdzNajemnika(string imie)
            => najemnicy.Find(n => n.Imie.Equals(imie, StringComparison.OrdinalIgnoreCase));

        public List<Najemnik> ZnajdzSilnychNajemnikow(int minPoziom, int minMaxHp)
            => najemnicy.FindAll(n => n.Poziom > minPoziom || n.MaxHp > minMaxHp);

        public Wyprawa ZnajdzWyprawe(string nazwa)
            => wyprawy.Find(w => w.Nazwa.Equals(nazwa, StringComparison.OrdinalIgnoreCase));

        public List<Wyprawa> ZnajdzWyprawy(string lokalizacja, TrudnoscWyprawy trudnosc)
            => wyprawy.FindAll(w => w.Lokalizacja == lokalizacja && w.Trudnosc == trudnosc);
    }
}
