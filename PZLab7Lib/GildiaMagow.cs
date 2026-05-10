using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab7Lib
{
    public class GildiaMagow
    {
        private List<Mag> magowie = new List<Mag>();

        public void PrzyjmijMaga(Mag mag)
        {
            magowie.Add(mag);
        }

        public override string ToString()
        {
            if (magowie.Count == 0) return "Gildia jest pusta.";
            return $"Gildia Magów (Członków: {magowie.Count}):\n" + string.Join("\n", magowie);
        }

        // 1) Potrzebuję listy wszystkich magów w gildii!
        public IEnumerable<Mag> PobierzWszystkichMagow()
        {
            return magowie.OrderBy(m => m.Imie);
        }

        // 2) Potrzebuję listy doświadczonych magów!
        public IEnumerable<Mag> PobierzDoswiadczonychMagow(int minPoziom)
        {
            return magowie.Where(m => m.Poziom > minPoziom).OrderBy(m => m.Poziom);
        }

        // 3) Potrzebuje informacji o najbardziej uzdolnionych magach!
        public IEnumerable<Mag> PobierzNajbardziejUzdolnionych(int maxPoziom)
        {
            return magowie
                .Where(m => m.Inteligencja > 20 && m.Poziom <= maxPoziom)
                .OrderByDescending(m => m.Inteligencja);
        }

        // 4) Chcę znać wspólny potencjał wszystkich magów bojowych!
        public int ObliczWspolnyPotencjal()
        {
            return magowie
                .Where(m => m.Poziom > 2 && m.Zrecznosc > 10)
                .Sum(m => m.AktualnePunktyMany);
        }

        // 5) Którzy magowie mają największy arsenał czarów?
        public IEnumerable<(string Imie, int LiczbaZaklec, int Mana)> PobierzNajwiekszyArsenal(int minLiczbaCzarow)
        {
            return magowie
                .Where(m => m.Ksiega.Count >= minLiczbaCzarow)
                .OrderByDescending(m => m.Ksiega.Count)
                .Select(m => (m.Imie, m.Ksiega.Count, m.AktualnePunktyMany));
        }

        // 6) Potrzebuję informacji o najbardziej wszechstronnych magach!
        public IEnumerable<(string Imie, int Poziom, double SredniaStatystyk)> PobierzWszechstronnych()
        {
            return magowie
                .Select(m => (
                    m.Imie,
                    m.Poziom,
                    SredniaStatystyk: (m.Sila + m.Zrecznosc + m.Inteligencja) / 3.0))
                .OrderByDescending(x => x.SredniaStatystyk);
        }

        // 7) Kto tam przyswoił najwięcej czarów?
        public IEnumerable<string> PobierzPrymusa()
        {
            if (!magowie.Any()) return Enumerable.Empty<string>();

            int maxCzarow = magowie.Max(m => m.Ksiega.Count);
            return magowie
                .Where(m => m.Ksiega.Count == maxCzarow)
                .Select(m => m.Imie);
        }

        // 8) Jakimi czarami dysponujemy? Tylko nie powtarzajcie mi tych samych!
        public IEnumerable<Czar> PobierzWszystkieCzaryBezPowtorzen()
        {
            return magowie
                .SelectMany(m => m.Ksiega)
                .Distinct();
        }

        // 9) Jakie mamy czary ofensywne? Jakie defensywne? A uzdrawiające?
        public IEnumerable<Czar> PobierzCzaryDanegoTypu(TypCzaru typ)
        {
            return magowie
                .SelectMany(m => m.Ksiega)
                .Where(c => c.Typ == typ)
                .Distinct();
        }

        // 10) A Gandalf to w ogóle ma jakieś czary ofensywne?
        public IEnumerable<Czar> PobierzCzaryMaga(string imieMaga, TypCzaru typ)
        {
            return magowie
                .Single(m => m.Imie.Equals(imieMaga, StringComparison.OrdinalIgnoreCase))
                .Ksiega
                .Where(c => c.Typ == typ);
        }

        // 11) To ile my tak właściwie znamy czarów w każdej z kategorii?
        public IEnumerable<(TypCzaru Typ, int Liczba)> ZliczCzaryGildiiWgTypu()
        {
            return magowie
                .SelectMany(m => m.Ksiega)
                .Distinct()
                .GroupBy(c => c.Typ)
                .Select(grupa => (grupa.Key, grupa.Count()));
        }

        // 12) A jak to się rozkłada u Gandalfa?
        public IEnumerable<(TypCzaru Typ, int Liczba)> ZliczCzaryMagaWgTypu(string imieMaga)
        {
            return magowie
                .Single(m => m.Imie.Equals(imieMaga, StringComparison.OrdinalIgnoreCase))
                .Ksiega
                .GroupBy(c => c.Typ)
                .Select(grupa => (grupa.Key, grupa.Count()));
        }

        // 13) Którzy magowie to są u nas najpotężniejsi? Nie licząc Gandalfa oczywiście.
        public IEnumerable<(string Imie, int Poziom)> PobierzNajpotezniejszych(int doPominiecia, int doPobrania)
        {
            return magowie
                .Where(m => !m.Imie.Equals("Gandalf", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(m => m.Poziom)
                .ThenByDescending(m => m.PunktyDoswiadczenia)
                .Skip(doPominiecia)
                .Take(doPobrania)
                .Select(m => (m.Imie, m.Poziom));
        }

        // 14) Czy wszyscy są gotowi na turniej w quidditch?
        public bool CzyWszyscyWypoczeci()
        {
            return magowie.All(m =>
                m.AktualnePunktyZycia == m.MaksymalnePunktyZycia &&
                m.AktualnePunktyMany == m.MaksymalnePunktyMany);
        }

        // 15) Czy ktoś podczas turnieju stracił przytomność?
        public bool CzyKtosZemdlal()
        {
            return magowie.Any(m => m.AktualnePunktyZycia <= 0);
        }

        // 16) Kto by się najlepiej nadawał do misji specjalnej w nieznanej krainie?
        public IEnumerable<(string Imie, int Poziom, int SumaOdpornosci, int OdpFiz,
            int OdpOgien, int OdpMroz, int OdpTrucizna)> WytypujNaMisje(int minPoziom)
        {
            return magowie
                .Where(m => m.Poziom > minPoziom)
                .Select(m => (
                    m.Imie,
                    m.Poziom,
                    SumaOdpornosci: m.OdpornoscFizyczna + m.OdpornoscOgien + m.OdpornoscMroz + m.OdpornoscTrucizna,
                    m.OdpornoscFizyczna,
                    m.OdpornoscOgien,
                    m.OdpornoscMroz,
                    m.OdpornoscTrucizna))
                .OrderByDescending(x => x.SumaOdpornosci)
                .Take(3);
        }
    }
}