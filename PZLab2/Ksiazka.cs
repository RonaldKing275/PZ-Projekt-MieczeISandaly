namespace PZLab21
{
    public class Ksiazka : Dokument
    {
        public string Autor { get; set; }

        public Ksiazka() : base() { }

        public Ksiazka(string isbn, string tytul, int rokWydania, int liczbaStron, string autor)
            : base(isbn, tytul, rokWydania, liczbaStron)
        {
            Autor = autor;
        }

        public override string Print()
        {
            return $"Wydrukowano książkę: '{Tytul}' autorstwa {Autor}.";
        }

        public override string ToString()
        {
            return base.ToString() + $" - Autor: {Autor}";
        }
    }
}