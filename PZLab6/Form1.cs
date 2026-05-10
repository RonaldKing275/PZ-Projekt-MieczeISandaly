using Microsoft.VisualBasic.Logging;
using PZLab6Lib;

namespace PZLab6
{
    public partial class Form1 : Form
    {
        private Wojownik wojownik;
        private Lucznik lucznik;
        private Czarodziej czarodziej;
        private Smok smok;
        private List<Postac> druzyna;

        private int iloscNapojow = 3;

        public Form1()
        {
            InitializeComponent();
            InicjalizujBitwe();
        }

        private void InicjalizujBitwe()
        {
            iloscNapojow = 10;

            // Inicjalizacja bohaterów
            wojownik = new Wojownik("Aragorn");
            lucznik = new Lucznik("Legolas");
            czarodziej = new Czarodziej("Gandalf");
            druzyna = new List<Postac> { wojownik, lucznik, czarodziej };

            // Inicjalizacja Smoka za pomocą inicjalizatora obiektów
            smok = new Smok
            {
                Imie = "Smaug",
                Poziom = 100,
                Sila = 50,
                Zrecznosc = 20,
                Inteligencja = 30,
                MaxHp = 2500,
                AktualneHp = 2000,
                Obrazenia = 50,
                Odpornosc = 15,
                ExpZaZabicie = 50000
            };

            // Co ma sie dziać po wywołaniu eventu OnZianieOgniem
            Random los = new Random();
            smok.OnZianieOgniem += (intensywnosc) =>
            {
                foreach (var bohater in druzyna)
                {
                    if (!bohater.CzyNieZyje)
                    {
                        // Każdy żywy dostaje dmg
                        bohater.OtrzymajObrazenia(intensywnosc);
                        // Ogień smoka ma szansę zniszczyć ekwipunek bohatera
                        int rzut = los.Next(1, 101);
                        if (rzut <= 15) bohater.Rozbroj(10); // 15% szans na stopienie broni
                        else if (rzut > 15 && rzut <= 30) bohater.ZdejmijPancerz(4); // 15% szans na stopienie pancerza
                    }

                }
            };

            WlaczWylaczPrzyciski(true);
            AktualizujUI();
        }

        // Metoda odświeżająca paski zdrowia i teksty na ekranie
        private void AktualizujUI()
        {
            lblNapoje.Text = $"Napoje uzdrawiające: {iloscNapojow}";

            AktualizujPasek(pbWojownik, lblWojownik, wojownik);
            AktualizujPasek(pbLucznik, lblLucznik, lucznik);
            AktualizujPasek(pbCzarodziej, lblCzarodziej, czarodziej);
            AktualizujPasek(pbSmok, lblSmok, smok);

            if (iloscNapojow <= 0)
            {
                btnLeczWojownika.Enabled = false;
                btnLeczLucznika.Enabled = false;
                btnLeczCzarodzieja.Enabled = false;
            }
        }

        // Pomocnicza metoda do pasków postępu
        private void AktualizujPasek(ProgressBar pb, Label lbl, Postac p)
        {
            pb.Maximum = p.MaxHp;
            pb.Value = Math.Max(0, Math.Min(p.AktualneHp, p.MaxHp));
            lbl.Text = $"{p.Imie} (Lv.{p.Poziom}) | HP: {p.AktualneHp}/{p.MaxHp}";
        }

        // Metoda realizująca jedną rundę walki
        public static void RundaWalki(List<Postac> bohaterowie, Smok boss)
        {
            // Drużyna bije smoka
            foreach (var bohater in bohaterowie)
            {
                if (!bohater.CzyNieZyje && !boss.CzyNieZyje)
                {
                    // Specjalna logika dla Czarodzieja
                    if (bohater is Czarodziej mag && mag.AktualnaMana < Czarodziej.kosztMany)
                    {
                        mag.RegenerujMane(Czarodziej.kosztMany * 2); // Mag traci turę na regenerację, bo nie ma many
                    }
                    else
                    {
                        boss.OtrzymajObrazenia(bohater.ObrazeniaWRundzie); // Normalny atak
                    }
                }
            }

            if (!boss.CzyNieZyje)
            {
                boss.ZionOgniem();
            }
        }

        // --- OBSŁUGA PRZYCISKÓW Z INTERFEJSU ---
        private void btnRunda_Click_1(object sender, EventArgs e)
        {
            RundaWalki(druzyna, smok);
            SprawdzKoniecWalki();
            AktualizujUI();
        }

        private void btnSymulacja_Click_1(object sender, EventArgs e)
        {
            while (!smok.CzyNieZyje && druzyna.Any(b => !b.CzyNieZyje))
            {
                RundaWalki(druzyna, smok);
            }
            SprawdzKoniecWalki();
            AktualizujUI();
        }

        private void SprawdzKoniecWalki()
        {
            if (smok.CzyNieZyje)
            {
                MessageBox.Show("Sukces! Smok pokonany! Drużyna zdobywa skarby!", "Zwycięstwo");
                WlaczWylaczPrzyciski(false);
            }
            else if (druzyna.All(b => b.CzyNieZyje))
            {
                MessageBox.Show("Porażka... Cała drużyna poległa w walce z bestią.", "Przegrana");
                WlaczWylaczPrzyciski(false);
            }
        }

        private void WlaczWylaczPrzyciski(bool stan)
        {
            btnRunda.Enabled = stan;
            btnSymulacja.Enabled = stan;
            btnLeczWojownika.Enabled = stan;
            btnLeczLucznika.Enabled = stan;
            btnLeczCzarodzieja.Enabled = stan;
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            InicjalizujBitwe();
        }

        private void btnLeczWojownika_Click_1(object sender, EventArgs e)
        {
            if (iloscNapojow > 0 && !wojownik.CzyNieZyje)
            {
                wojownik.WypijNapojLeczacy();
                iloscNapojow--;
                AktualizujUI();
            }
        }

        private void btnLeczLucznika_Click_1(object sender, EventArgs e)
        {
            if (iloscNapojow > 0 && !lucznik.CzyNieZyje)
            {
                lucznik.WypijNapojLeczacy();
                iloscNapojow--;
                AktualizujUI();
            }
        }

        private void btnLeczCzarodzieja_Click_1(object sender, EventArgs e)
        {
            if (iloscNapojow > 0 && !czarodziej.CzyNieZyje)
            {
                czarodziej.WypijNapojLeczacy();
                iloscNapojow--;
                AktualizujUI();
            }
        }
        private void txtExpWojownik_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExpLucznik_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExpCzarodziej_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExpWojownik_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpWojownik.Text, out int exp) && !wojownik.CzyNieZyje)
            {
                wojownik.DodajExp(exp);
                txtExpWojownik.Text = "";
                AktualizujUI();
            }
        }

        private void btnExpLucznik_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpLucznik.Text, out int exp) && !lucznik.CzyNieZyje)
            {
                lucznik.DodajExp(exp);
                txtExpLucznik.Text = "";
                AktualizujUI();
            }
        }

        private void btnExpCzarodziej_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpCzarodziej.Text, out int exp) && !czarodziej.CzyNieZyje)
            {
                czarodziej.DodajExp(exp);
                txtExpCzarodziej.Text = "";
                AktualizujUI();
            }
        }
    }
}
