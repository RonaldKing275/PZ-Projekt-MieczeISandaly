namespace PZLab21
{
    public class ZarzadcaDokumentow
    {
        private List<Dokument> dokumenty = new List<Dokument>();

        public void DodajDokument(Dokument doc)
        {
            if (dokumenty.Exists(d => d.ISBN == doc.ISBN))
            {
                throw new DuplicateIsbnException($"Dokument o ISBN {doc.ISBN} już istnieje na liście!");
            }

            if (doc is Tom tom)
            {
                if (tom.NumerTomu > tom.LiczbaWszystkichTomow)
                {
                    throw new InvalidVolumeException($"Błąd! Numer tomu ({tom.NumerTomu}) jest większy niż " +
                        $"łączna liczba tomów ({tom.LiczbaWszystkichTomow}).");
                }
            }

            if (doc is Ksiazka ksiazka)
            {
                if (ksiazka.RokWydania < 1440)
                {
                    throw new InvalidPublishYearException($"Błąd! Rok wydania książki ({ksiazka.RokWydania}) przed " +
                        $"wynalezieniem druku (ok. 1440 r.).");
                }
            }

            dokumenty.Add(doc);
        }

        public Dokument PobierzPoISBN(string isbn)
        {
            return dokumenty.Find(d => d.ISBN == isbn);
        }

        public List<Dokument> SzukajWTytule(string fraza)
        {
            return dokumenty.FindAll(d => d.Tytul.Contains(fraza, StringComparison.OrdinalIgnoreCase));
        }

        public List<Czasopismo> PobierzCzasopisma(Czestotliwosc czestotliwosc)
        {
            List<Czasopismo> wyniki = new List<Czasopismo>();
            foreach (var doc in dokumenty)
            {
                if (doc is Czasopismo)
                {
                    Czasopismo czaso = (Czasopismo)doc;
                    if (czaso.Czestotliwosc == czestotliwosc)
                    {
                        wyniki.Add(czaso);
                    }
                }
            }
            return wyniki;
        }

        public List<Dokument> PobierzWszystkie()
        {
            return dokumenty;
        }
    }
}