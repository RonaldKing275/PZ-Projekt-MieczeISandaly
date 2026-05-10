namespace PZLab6Lib
{
    public abstract class Postac : IComparable<Postac>
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int Exp { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }
        public int AktualneHp { get; set; }
        public int MaxHp { get; set; }
        public int Obrazenia { get; set; }
        public int Odpornosc { get; set; }

        // Właściwość tylko do odczytu (wirtualna, bo Wojownik ją nadpisze)
        public virtual int ObrazeniaWRundzie => Obrazenia + (Sila / 2);

        public bool CzyNieZyje => AktualneHp <= 0;

        public Postac() { }

        public Postac(string imie, int poziom, int sila, int zrecznosc, int inteligencja, int maxHp, int obrazenia, int odpornosc)
        {
            Imie = imie;
            Poziom = poziom;
            Exp = 0;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Inteligencja = inteligencja;
            MaxHp = maxHp;
            AktualneHp = maxHp;
            Obrazenia = obrazenia;
            Odpornosc = odpornosc;
        }

        public void Uzbroj(int bonusDmg) => Obrazenia += bonusDmg;
        public void ZalozPancerz(int bonusPancerz) => Odpornosc += bonusPancerz;

        // Wirtualna metoda otrzymywania obrażeń (aby Łucznik mógł zrobić unik)
        public virtual void OtrzymajObrazenia(int dmg)
        {
            int faktyczneObrazenia = dmg - Odpornosc;
            if (faktyczneObrazenia < 0) faktyczneObrazenia = 0;

            AktualneHp -= faktyczneObrazenia;
            if (AktualneHp < 0) AktualneHp = 0;
        }

        public virtual void LevelUp()
        {
            Poziom++;
            MaxHp += 10;
            AktualneHp = MaxHp;
            Sila += 2;
            Zrecznosc += 2;
            Inteligencja += 2;
        }

        public void DodajExp(int exp)
        {
            Exp += exp;
            // Próg na kolejny poziom to (Poziom * 100)
            while (Exp >= Poziom * 100)
            {
                Exp -= Poziom * 100;
                LevelUp();
            }
        }

        public override string ToString() =>
            $"[{this.GetType().Name} Lv.{Poziom}] {Imie} | HP: {AktualneHp}/{MaxHp} | DMG Runda: {ObrazeniaWRundzie} | Odp: {Odpornosc}";

        public int CompareTo(Postac other)
        {
            if (other == null) return 1;
            return this.Poziom.CompareTo(other.Poziom);
        }
    }
}
