using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public abstract class Postac
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int Zloto { get; set; }

        // Statystyki RPG
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }
        public int Charyzma { get; set; }
        public int Witalnosc { get; set; }
        public int Wytrzymalosc { get; set; }

        public int MaxHp { get; set; }
        public int MaxStamina { get; set; }
        public int MaxPancerz { get; set; }

        private int aktualneHp;
        private int aktualnaStamina;
        private int aktualnyPancerz;

        // Zdarzenia wywoływane przy zmianie Hp/Staminy/Pancerza
        public event StatystykaZmienionaAkcja OnHpChanged;
        public event StatystykaZmienionaAkcja OnStaminaChanged;
        public event StatystykaZmienionaAkcja OnPancerzChanged;

        // Zawsze gdy HP, Stamina i Pancerz się zmienia - odpala się event
        public int AktualneHp
        {
            get => aktualneHp;
            set
            {
                aktualneHp = Math.Max(0, Math.Min(value, MaxHp));
                OnHpChanged?.Invoke(aktualneHp, MaxHp);
            }
        }

        public int AktualnaStamina
        {
            get => aktualnaStamina;
            set
            {
                aktualnaStamina = Math.Max(0, Math.Min(value, MaxStamina));
                OnStaminaChanged?.Invoke(aktualnaStamina, MaxStamina);
            }
        }

        public int AktualnyPancerz
        {
            get => aktualnyPancerz;
            set
            {
                aktualnyPancerz = Math.Max(0, value);
                OnPancerzChanged?.Invoke(aktualnyPancerz, MaxPancerz);
            }
        }

        public void PrzeliczMaxPaski()
        {
            // Bazowo 100, co poziom +15, do tego bonus za każdy punkt Witalności +15 HP za punkt
            MaxHp = 100 + ((Poziom - 1) * 15) + (Witalnosc * 15);

            // Bazowo 120, co poziom +10, do tego bonus za każdy punkt Wytrzymałości +10 Staminy za punkt
            MaxStamina = 120 + ((Poziom - 1) * 10) + (Wytrzymalosc * 10);
        }

        public void OdnowPancerz()
        {
            // Oblicza sumę zbroi z ekwipunku i ładuje ją jako barierę na start walki
            MaxPancerz = UbranyPancerz.Values.Sum(z => z.PunktyPancerza);
            AktualnyPancerz = MaxPancerz;
        }

        public void Odpocznij()
        {
            AktualnaStamina = MaxStamina;
        }

        public bool CzyMozeWykonacAkcje(int kosztStaminy)
        {
            return AktualnaStamina >= kosztStaminy;
        }

        // Ekwipunek
        public List<Przedmiot> PosiadanePrzedmioty { get; set; } = new List<Przedmiot>();
        public Bron WyposazonaBronGlowna { get; set; }
        public Bron WyposazonaBronPomocnicza { get; set; }
        public Dictionary<CzescZbroi, Zbroja> UbranyPancerz { get; set; }
            = new Dictionary<CzescZbroi, Zbroja>();

        // Kompatybilność wsteczna
        public Bron WyposazonaBron
        {
            get => WyposazonaBronGlowna;
            set => WyposazonaBronGlowna = value;
        }

        public bool CzyZyje => AktualneHp > 0;

        public Postac(string imie, int poziom)
        {
            Imie = imie;
            Poziom = poziom;
        }

        public void WyposazBron(Bron nowaBron)
        {
            if (nowaBron.Zasieg == RodzajZasiegu.Wrecz)
            {
                WyposazonaBronGlowna = nowaBron;
            }
            else if (nowaBron.Zasieg == RodzajZasiegu.Dystansowa)
            {
                WyposazonaBronPomocnicza = nowaBron;
            }
        }

        // Wirtualna metoda zadawania bazowych obrażeń (Bron + Siła)
        public virtual int ObliczObrazeniaZwykle(bool atakDystansowy = false)
        {
            // Zabezpieczenie, żeby gracz bez broni głównej mógł używać samego Łuku
            Bron uzywanaBron = atakDystansowy ? WyposazonaBronPomocnicza : WyposazonaBronGlowna;

            if (uzywanaBron == null)
            {
                return 4 + (int)(Sila * 0.75);
            }

            int bonus = (uzywanaBron.Typ == TypBroni.Miecze || uzywanaBron.Typ == TypBroni.Luki)
                        ? Zrecznosc
                        : Sila;

            return uzywanaBron.MinObrazenia + bonus;
        }

        public string PobierzZakresObrazen(bool atakDystansowy = false)
        {
            Bron uzywanaBron = atakDystansowy ? WyposazonaBronPomocnicza : WyposazonaBronGlowna;

            if (uzywanaBron == null)
            {
                int dmgPiesci = 4 + (int)(Sila * 0.75);
                return $"{dmgPiesci}-{dmgPiesci}";
            }

            int bonus = (uzywanaBron.Typ == TypBroni.Miecze || uzywanaBron.Typ == TypBroni.Luki)
                        ? Zrecznosc
                        : Sila;

            int min = uzywanaBron.MinObrazenia + bonus;
            int max = uzywanaBron.MaxObrazenia + bonus;

            return $"{min}-{max}";
        }

        // Losuje finalne obrażenia z przedziału
        private static Random r = new Random();
        public int LosujObrazenia(bool atakDystansowy = false)
        {
            Bron uzywanaBron = atakDystansowy ? WyposazonaBronPomocnicza : WyposazonaBronGlowna;

            if (uzywanaBron == null || uzywanaBron.Nazwa == "Brak")
            {
                if (atakDystansowy)
                    return 0;
                else
                    return 4 + (int)(Sila * 0.75);
            }

            int bonus = (uzywanaBron.Typ == TypBroni.Miecze || uzywanaBron.Typ == TypBroni.Luki) ? Zrecznosc : Sila;

            int min = uzywanaBron.MinObrazenia + bonus;
            int max = uzywanaBron.MaxObrazenia + bonus;

            return r.Next(min, max + 1);
        }

        public int OtrzymajObrazenia(int dmg)
        {
            if (dmg <= 0) return 0;

            // Jeśli bariera pochłania cały cios
            if (AktualnyPancerz >= dmg)
            {
                AktualnyPancerz -= dmg; // Zdziera pancerz
                return 0;
            }
            else
            {
                // Pancerz zostaje przebity i zniszczony do końca walki
                int resztaDmg = dmg - AktualnyPancerz;
                AktualnyPancerz = 0;
                AktualneHp -= resztaDmg; // Reszta obrażeń uderza w ciało

                return resztaDmg; // Zwraca informację, ile HP ubyło
            }
        }

        public string PobierzRaportPancerza()
        {
            if (UbranyPancerz.Count == 0) return "Brak zbroi (0 pancerza)";

            List<string> czesci = new List<string>();
            foreach (var kvp in UbranyPancerz)
            {
                czesci.Add($"{kvp.Key}: {kvp.Value.Nazwa} ({kvp.Value.PunktyPancerza})");
            }

            int suma = UbranyPancerz.Values.Sum(z => z.PunktyPancerza);
            return string.Join("\n", czesci) + $"\nSUMA: {suma}";
        }
    }
}
