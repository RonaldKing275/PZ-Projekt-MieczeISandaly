namespace PZLab21
{
    public abstract class Dokument
    {
        public string ISBN { get; set; }
        public string Tytul { get; set; }
        public int RokWydania { get; set; }
        public int LiczbaStron { get; set; }

        public Dokument() { }

        public Dokument(string isbn, string tytul, int rokWydania, int liczbaStron)
        {
            ISBN = isbn;
            Tytul = tytul;
            RokWydania = rokWydania;
            LiczbaStron = liczbaStron;
        }

        public abstract string Print();

        public override string ToString()
        {
            return $"[{ISBN}] {Tytul} ({RokWydania}) - Stron: {LiczbaStron}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return this.ToString() == obj.ToString();
        }

        public static bool operator ==(Dokument d1, Dokument d2)
        {
            if (ReferenceEquals(d1, null)) return ReferenceEquals(d2, null);
            return d1.Equals(d2);
        }

        public static bool operator !=(Dokument d1, Dokument d2)
        {
            return !(d1 == d2);
        }
    }
}