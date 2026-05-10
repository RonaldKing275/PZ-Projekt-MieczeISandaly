namespace PZLab21
{
    public class Tom : Ksiazka
    {
        public int NumerTomu { get; set; }
        public int LiczbaWszystkichTomow { get; set; }

        public Tom() : base() { }

        public Tom(string isbn, string tytul, int rokWydania, int liczbaStron, string autor, int numerTomu, int liczbaWszystkichTomow)
            : base(isbn, tytul, rokWydania, liczbaStron, autor)
        {
            NumerTomu = numerTomu;
            LiczbaWszystkichTomow = liczbaWszystkichTomow;
        }

        public override string Print()
        {
            return $"Wydrukowano tom {NumerTomu}/{LiczbaWszystkichTomow}: '{Tytul}'.";
        }

        public override string ToString()
        {
            return base.ToString() + $" [Tom {NumerTomu} z {LiczbaWszystkichTomow}]";
        }
    }
}