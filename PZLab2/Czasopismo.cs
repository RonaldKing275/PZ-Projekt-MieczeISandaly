namespace PZLab21
{
    public class Czasopismo : Dokument
    {
        public int Numer { get; set; }
        public Czestotliwosc Czestotliwosc { get; set; }

        public Czasopismo() : base() { }

        public Czasopismo(string isbn, string tytul, int rokWydania, int liczbaStron, int numer, Czestotliwosc czestotliwosc)
            : base(isbn, tytul, rokWydania, liczbaStron)
        {
            Numer = numer;
            Czestotliwosc = czestotliwosc;
        }

        public override string Print()
        {
            return $"Wydrukowano czasopismo: '{Tytul}' (Nr {Numer}, {Czestotliwosc}).";
        }

        public override string ToString()
        {
            return base.ToString() + $" - Nr {Numer} ({Czestotliwosc})";
        }
    }
}