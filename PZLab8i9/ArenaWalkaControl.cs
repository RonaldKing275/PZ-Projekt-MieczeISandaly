using PZLab8i9Lib;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class ArenaWalkaControl : UserControl
    {
        private Form1 glowneOkno;
        private PrzeciwnikKomputer wrog;
        private int runda = 1;
        private Random rnd = new Random();

        private const double LEWA_KRAWEDZ = 0.0;
        private const double PRAWA_KRAWEDZ = 40.0;
        private double pozycjaGracza = 16.0;
        private double pozycjaWroga = 24.0;

        private bool uzywaBroniDystansowej = false;

        private double PobierzDystans() => Math.Abs(pozycjaGracza - pozycjaWroga);

        // PARAMETRY I KOSZTY
        private struct StatyAtaku
        {
            public int Szansa;
            public double Mnoznik;
            public int BazowyKoszt;
            public double SkalowanieSily; // Jak bardzo Siła zwiększa koszt staminy

            public StatyAtaku(int szansa, double mnoznik, int bazowyKoszt, double skalowanieSily)
            { Szansa = szansa; Mnoznik = mnoznik; BazowyKoszt = bazowyKoszt; SkalowanieSily = skalowanieSily; }
        }

        private readonly StatyAtaku AtakSzybki = new StatyAtaku(90, 0.9, 10, 2);    // Koszt: 10 + Siła * 2
        private readonly StatyAtaku AtakNormalny = new StatyAtaku(45, 1.5, 20, 3.5);// Koszt: 20 + Siła * 3.5
        private readonly StatyAtaku AtakCiezki = new StatyAtaku(25, 2.0, 35, 4.5);  // Koszt: 35 + Siła * 4.5
        private readonly StatyAtaku AtakDash = new StatyAtaku(40, 1.2, 20, 3.5);    // Koszt: 20 + Siła * 3.5 (taki sam jak normalny)

        private int ObliczKosztRuchu() => 30;

        private int ObliczKosztAtaku(Postac postac, StatyAtaku staty)
            => staty.BazowyKoszt + (int)(postac.Sila * staty.SkalowanieSily);

        private int ObliczKosztKrzyku(Postac postac)
            => 20 + (postac.Charyzma * 2);


        public ArenaWalkaControl(Form1 form, PrzeciwnikKomputer wygenerowanyWrog)
        {
            InitializeComponent();
            glowneOkno = form;
            wrog = wygenerowanyWrog;

            PrzygotujWalke();
        }

        private void PrzygotujWalke()
        {
            lblImieGracza.Text = glowneOkno.Bohater.Imie;
            lblImieWroga.Text = wrog.Imie;

            glowneOkno.Bohater.OdnowPancerz();
            wrog.OdnowPancerz();

            glowneOkno.Bohater.AktualneHp = glowneOkno.Bohater.MaxHp;
            glowneOkno.Bohater.AktualnaStamina = glowneOkno.Bohater.MaxStamina;

            // Gdy HP lub Stamina gracza/wroga się zmieni, paski zaktualizują się same
            glowneOkno.Bohater.OnHpChanged += (aktualne, max) => barHpGracza.Value = aktualne;
            glowneOkno.Bohater.OnStaminaChanged += (aktualne, max) => barStaminaGracza.Value = aktualne;
            glowneOkno.Bohater.OnPancerzChanged += (aktualne, max) => {
                barPancerzGracza.Maximum = max == 0 ? 1 : max;
                barPancerzGracza.Value = aktualne;
            };

            wrog.OnHpChanged += (aktualne, max) => barHpWroga.Value = aktualne;
            wrog.OnStaminaChanged += (aktualne, max) => barStaminaWroga.Value = aktualne;
            wrog.OnPancerzChanged += (aktualne, max) => {
                barPancerzWroga.Maximum = max == 0 ? 1 : max;
                barPancerzWroga.Value = aktualne;
            };

            ZaktualizujPaski();
            UstawKomunikat("=== WALKA ROZPOCZĘTA ===");
        }

        private void ZaktualizujPaski()
        {
            lblImieGracza.Text = $"{glowneOkno.Bohater.Imie} [Pancerz: {glowneOkno.Bohater.AktualnyPancerz}]";
            lblImieWroga.Text = $"{wrog.Imie} [Pancerz: {wrog.AktualnyPancerz}]";

            barHpGracza.Maximum = glowneOkno.Bohater.MaxHp;
            barHpGracza.Value = glowneOkno.Bohater.AktualneHp;
            barStaminaGracza.Maximum = glowneOkno.Bohater.MaxStamina;
            barStaminaGracza.Value = glowneOkno.Bohater.AktualnaStamina;
            barPancerzGracza.Maximum = glowneOkno.Bohater.MaxPancerz == 0 ? 1 : glowneOkno.Bohater.MaxPancerz;
            barPancerzGracza.Value = glowneOkno.Bohater.AktualnyPancerz;

            barHpWroga.Maximum = wrog.MaxHp;
            barHpWroga.Value = wrog.AktualneHp;
            barStaminaWroga.Maximum = wrog.MaxStamina;
            barStaminaWroga.Value = wrog.AktualnaStamina;
            barPancerzWroga.Maximum = wrog.MaxPancerz == 0 ? 1 : wrog.MaxPancerz;
            barPancerzWroga.Value = wrog.AktualnyPancerz;

            if (btnNormalnyAtak != null)
            {
                if (!uzywaBroniDystansowej && PobierzDystans() > 0.5)
                    btnNormalnyAtak.Text = "Szarża";
                else
                    btnNormalnyAtak.Text = "Normalny Atak";
            }
        }

        private void UstawKomunikat(string wiadomosc)
        {
            if (lblKomunikatWalki != null)
                lblKomunikatWalki.Text = wiadomosc;
        }

        private void ZablokujPrzyciski(bool zablokuj)
        {
            if (btnSzybkiAtak != null) btnSzybkiAtak.Enabled = !zablokuj;
            if (btnNormalnyAtak != null) btnNormalnyAtak.Enabled = !zablokuj;
            if (btnCiezkiAtak != null) btnCiezkiAtak.Enabled = !zablokuj;
            if (btnKrokPrzod != null) btnKrokPrzod.Enabled = !zablokuj;
            if (btnKrokTyl != null) btnKrokTyl.Enabled = !zablokuj;
            if (btnZmienBron != null) btnZmienBron.Enabled = !zablokuj;
            if (btnOdpocznij != null) btnOdpocznij.Enabled = !zablokuj;
            if (btnKrzyk != null) btnKrzyk.Enabled = !zablokuj;
        }

        // SYSTEM RUCHU (OŚ X)
        private async void WykonajRuch(bool wPrzod)
        {
            int kosztRuchu = ObliczKosztRuchu();

            if (!glowneOkno.Bohater.CzyMozeWykonacAkcje(kosztRuchu))
            {
                UstawKomunikat("Nie masz staminy na ruch! Odpocznij.");
                return;
            }

            glowneOkno.Bohater.AktualnaStamina -= kosztRuchu;
            double mocSkoku = 1.0 + (glowneOkno.Bohater.Zrecznosc * 0.2);

            bool wrogPoPrawej = pozycjaWroga > pozycjaGracza;
            double kierunek = wPrzod ? (wrogPoPrawej ? 1.0 : -1.0) : (wrogPoPrawej ? -1.0 : 1.0);

            double nowaPozycja = pozycjaGracza + (mocSkoku * kierunek);

            if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
            if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;

            bool przeskoczyl = (wrogPoPrawej && nowaPozycja > pozycjaWroga) || (!wrogPoPrawej && nowaPozycja < pozycjaWroga);

            if (Math.Abs(nowaPozycja - pozycjaWroga) < 0.5)
            {
                if (przeskoczyl)
                    nowaPozycja = pozycjaWroga + (wrogPoPrawej ? 0.5 : -0.5);
                else
                    nowaPozycja = pozycjaWroga - (wrogPoPrawej ? 0.5 : -0.5);

                if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
                if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;
            }

            pozycjaGracza = nowaPozycja;

            if (wPrzod && przeskoczyl)
                UstawKomunikat($"Przeskakujesz nad wrogiem! Jesteś za jego plecami. (Twój X: {Math.Round(pozycjaGracza, 1)})");
            else if (wPrzod)
                UstawKomunikat($"Idziesz w stronę wroga. (Twój X: {Math.Round(pozycjaGracza, 1)})");
            else
                UstawKomunikat($"Wycofujesz się! (Twój X: {Math.Round(pozycjaGracza, 1)})");

            ZaktualizujPaski();
            await OddajTureWrogowi();
        }

        private void btnKrokPrzod_Click(object sender, EventArgs e) => WykonajRuch(wPrzod: true);
        private void btnKrokTyl_Click(object sender, EventArgs e) => WykonajRuch(wPrzod: false);

        // SYSTEM ATAKU W MIEJSCU
        private bool WykonajAtak(Postac atakujacy, Postac broniacy, bool czyDystans, StatyAtaku staty)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            double aktDystans = PobierzDystans();
            int kosztAtaku = ObliczKosztAtaku(atakujacy, staty);

            if (!czyDystans && aktDystans > 0.5)
            {
                UstawKomunikat(toGracz ? "Jesteś za daleko! Podejdź bliżej lub użyj Szarży." : $"{atakujacy.Imie} uderza powietrze!");
                return false;
            }
            if (czyDystans && aktDystans <= 0.5)
            {
                UstawKomunikat(toGracz ? "Wróg jest za blisko na łuk! Wyciągnij broń białą." : $"{atakujacy.Imie} nie może strzelać w zwarciu!");
                return false;
            }

            if (!atakujacy.CzyMozeWykonacAkcje(kosztAtaku))
            {
                UstawKomunikat(toGracz ? "Masz za mało staminy! Musisz odpocząć." : $"{atakujacy.Imie} ledwo stoi na nogach!");
                return false;
            }

            atakujacy.AktualnaStamina -= kosztAtaku;
            int los = rnd.Next(1, 101);

            if (los <= staty.Szansa)
            {
                int bazoweDmg = atakujacy.LosujObrazenia(czyDystans);
                int finalneDmg = (int)(bazoweDmg * staty.Mnoznik);
                int utrataHp = broniacy.OtrzymajObrazenia(finalneDmg);

                UstawKomunikat(toGracz ?
                    $"TRAFIENIE! Zadajesz {utrataHp} obrażeń." :
                    $"{atakujacy.Imie} trafia Cię za {utrataHp} DMG!");
            }
            else
            {
                UstawKomunikat(toGracz ? "PUDŁO! Przecinasz powietrze." : $"{atakujacy.Imie} pudłuje!");
            }

            ZaktualizujPaski();
            return true;
        }

        // SYSTEM SZARŻY (DASH)
        private bool WykonajDashAtak(Postac atakujacy, Postac broniacy)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            double aktDystans = PobierzDystans();
            int kosztDash = ObliczKosztAtaku(atakujacy, AtakDash);

            if (aktDystans <= 0.5)
            {
                UstawKomunikat(toGracz ? "Jesteś za blisko na szarżę!" : "");
                return false;
            }

            if (!atakujacy.CzyMozeWykonacAkcje(kosztDash))
            {
                UstawKomunikat(toGracz ? "Za mało staminy na szarżę!" : $"{atakujacy.Imie} potyka się z braku sił!");
                return false;
            }

            atakujacy.AktualnaStamina -= kosztDash;
            double zasiegSzarzy = 1.0 + (atakujacy.Zrecznosc * 0.15) + (atakujacy.Sila * 0.2);

            double posAtakujacego = toGracz ? pozycjaGracza : pozycjaWroga;
            double posBroniacego = toGracz ? pozycjaWroga : pozycjaGracza;

            bool wrogPoPrawej = posBroniacego > posAtakujacego;
            double kierunek = wrogPoPrawej ? 1.0 : -1.0;

            double dystansDoZwarcia = aktDystans - 0.5;

            if (zasiegSzarzy >= dystansDoZwarcia)
            {
                double nowaPozycja = posBroniacego - (0.5 * kierunek);

                if (toGracz) pozycjaGracza = nowaPozycja;
                else pozycjaWroga = nowaPozycja;

                int los = rnd.Next(1, 101);
                if (los <= AtakDash.Szansa)
                {
                    int bazoweDmg = atakujacy.LosujObrazenia(false);
                    int finalneDmg = (int)(bazoweDmg * AtakDash.Mnoznik);
                    int utrataHp = broniacy.OtrzymajObrazenia(finalneDmg);

                    UstawKomunikat(toGracz ?
                        $"SZARŻA! Wpadasz we wroga i zadajesz {utrataHp} obrażeń." :
                        $"{atakujacy.Imie} szarżuje i wbija Ci broń, zadając {utrataHp} DMG!");
                }
                else
                {
                    UstawKomunikat(toGracz ?
                        "SZARŻA PUDŁUJE! Doskakujesz, ale wróg robi unik." :
                        $"{atakujacy.Imie} szarżuje, ale w ostatniej chwili robisz unik!");
                }
            }
            else
            {
                double nowaPozycja = posAtakujacego + (zasiegSzarzy * kierunek);

                if (toGracz) pozycjaGracza = nowaPozycja;
                else pozycjaWroga = nowaPozycja;

                double nowyDystans = PobierzDystans();

                UstawKomunikat(toGracz ?
                    $"Szarżujesz, ale opadasz z sił przed celem! (Zostało: {Math.Round(nowyDystans, 1)}m)" :
                    $"{atakujacy.Imie} szarżuje, ale mija się z Tobą z braku sił!");
            }

            ZaktualizujPaski();
            return true;
        }

        // SYSTEM KRZYKU (TAUNT)
        private bool WykonajKrzyk(Postac atakujacy, Postac broniacy)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            int kosztKrzyku = ObliczKosztKrzyku(atakujacy);

            if (!atakujacy.CzyMozeWykonacAkcje(kosztKrzyku))
            {
                UstawKomunikat(toGracz ?
                    "Masz zdarte gardło i brak tchu! Odpocznij." :
                    $"{atakujacy.Imie} próbuje krzyczeć, ale chrypi z wyczerpania!");
                return false;
            }

            atakujacy.AktualnaStamina -= kosztKrzyku;

            int szansa = (atakujacy.Charyzma - broniacy.Charyzma) * 10;
            szansa = Math.Max(10, Math.Min(99, szansa));

            int los = rnd.Next(1, 101);

            if (los <= szansa)
            {
                int dmg = 10 + (atakujacy.Charyzma * 2);
                int utrataHp = broniacy.OtrzymajObrazenia(dmg);

                UstawKomunikat(toGracz ?
                    $"POTĘŻNY KRZYK! Twój ryk zadaje {utrataHp} obrażeń." :
                    $"{atakujacy.Imie} drze się wniebogłosy! Tracisz {utrataHp} DMG.");
            }
            else
            {
                UstawKomunikat(toGracz ?
                    "Krzyczysz, ale wróg tylko się zaśmiał. PUDŁO!" :
                    $"{atakujacy.Imie} próbuje Cię ogłuszyć krzykiem, ale nie robi to na Tobie wrażenia.");
            }

            ZaktualizujPaski();
            return true;
        }

        // PRZYCISKI AKCJI GRACZA
        private async void btnSzybkiAtak_Click(object sender, EventArgs e)
        {
            if (WykonajAtak(glowneOkno.Bohater, wrog, uzywaBroniDystansowej, AtakSzybki))
            {
                if (SprawdzCzyKoniec()) return;
                await OddajTureWrogowi();
            }
        }

        private async void btnNormalnyAtak_Click(object sender, EventArgs e)
        {
            bool udanaAkcja = (!uzywaBroniDystansowej && PobierzDystans() > 0.5)
                ? WykonajDashAtak(glowneOkno.Bohater, wrog)
                : WykonajAtak(glowneOkno.Bohater, wrog, uzywaBroniDystansowej, AtakNormalny);

            if (udanaAkcja)
            {
                if (SprawdzCzyKoniec()) return;
                await OddajTureWrogowi();
            }
        }

        private async void btnCiezkiAtak_Click(object sender, EventArgs e)
        {
            if (WykonajAtak(glowneOkno.Bohater, wrog, uzywaBroniDystansowej, AtakCiezki))
            {
                if (SprawdzCzyKoniec()) return;
                await OddajTureWrogowi();
            }
        }

        private async void btnKrzyk_Click(object sender, EventArgs e)
        {
            if (WykonajKrzyk(glowneOkno.Bohater, wrog))
            {
                if (SprawdzCzyKoniec()) return;
                await OddajTureWrogowi();
            }
        }

        private async void btnZmienBron_Click(object sender, EventArgs e)
        {
            uzywaBroniDystansowej = !uzywaBroniDystansowej;
            string rodzaj = uzywaBroniDystansowej ? "Dystansową" : "Białą";
            UstawKomunikat($"Zmieniasz broń na: {rodzaj}");
            ZaktualizujPaski();
            await OddajTureWrogowi();
        }

        private async void btnOdpocznij_Click(object sender, EventArgs e)
        {
            glowneOkno.Bohater.Odpocznij();
            UstawKomunikat("Odpoczywasz i odnawiasz całą staminę!");
            ZaktualizujPaski();
            await OddajTureWrogowi();
        }

        // AI PRZECIWNIKA I LOGIKA TURY
        private async Task OddajTureWrogowi()
        {
            ZablokujPrzyciski(true);
            await Task.Delay(1500);

            RuchPrzeciwnika();

            if (!SprawdzCzyKoniec())
            {
                runda++;
                ZablokujPrzyciski(false);
            }
        }

        private void RuchPrzeciwnika()
        {
            double aktDystans = PobierzDystans();
            int losCzynnosci = rnd.Next(1, 101);

            int kosztKrzykuWroga = ObliczKosztKrzyku(wrog);
            int kosztDashWroga = ObliczKosztAtaku(wrog, AtakDash);
            int kosztRuchuWroga = ObliczKosztRuchu();

            // 15% szans na użycie Krzyku w tej turze
            if (losCzynnosci <= 15 && wrog.AktualnaStamina >= kosztKrzykuWroga)
            {
                WykonajKrzyk(wrog, glowneOkno.Bohater);
            }
            else if (aktDystans > 0.5)
            {
                if (wrog.AktualnaStamina >= kosztDashWroga && rnd.Next(100) < 40)
                {
                    WykonajDashAtak(wrog, glowneOkno.Bohater);
                }
                else
                {
                    if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                    {
                        wrog.AktualnaStamina -= kosztRuchuWroga;
                        double mocSkoku = 1.0 + (wrog.Zrecznosc * 0.2);

                        bool graczPoPrawej = pozycjaGracza > pozycjaWroga;
                        double kierunek = graczPoPrawej ? 1.0 : -1.0;

                        double nowaPozycja = pozycjaWroga + (mocSkoku * kierunek);

                        if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
                        if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;

                        bool przeskoczyl = (graczPoPrawej && nowaPozycja > pozycjaGracza) || (!graczPoPrawej && nowaPozycja < pozycjaGracza);

                        if (Math.Abs(nowaPozycja - pozycjaGracza) < 0.5)
                        {
                            if (przeskoczyl)
                                nowaPozycja = pozycjaGracza + (graczPoPrawej ? 0.5 : -0.5);
                            else
                                nowaPozycja = pozycjaGracza - (graczPoPrawej ? 0.5 : -0.5);

                            if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
                            if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;
                        }

                        pozycjaWroga = nowaPozycja;

                        if (przeskoczyl)
                        {
                            UstawKomunikat($"{wrog.Imie} przeskakuje za Twoje plecy!");
                        }
                        else
                        {
                            UstawKomunikat($"{wrog.Imie} zbliża się. (Jego X: {Math.Round(nowaPozycja, 1)})");
                        }
                    }
                    else
                    {
                        wrog.Odpocznij();
                        UstawKomunikat($"{wrog.Imie} zatrzymuje się, by odpocząć.");
                    }
                }
            }
            else // ZWARCIE
            {
                int losAtaku = rnd.Next(1, 101);

                int kosztCiezki = ObliczKosztAtaku(wrog, AtakCiezki);
                int kosztNormalny = ObliczKosztAtaku(wrog, AtakNormalny);
                int kosztSzybki = ObliczKosztAtaku(wrog, AtakSzybki);

                if (wrog.AktualnaStamina >= kosztCiezki && losAtaku <= 25)
                {
                    WykonajAtak(wrog, glowneOkno.Bohater, false, AtakCiezki);
                }
                else if (wrog.AktualnaStamina >= kosztNormalny && losAtaku <= 75)
                {
                    WykonajAtak(wrog, glowneOkno.Bohater, false, AtakNormalny);
                }
                else if (wrog.AktualnaStamina >= kosztSzybki)
                {
                    WykonajAtak(wrog, glowneOkno.Bohater, false, AtakSzybki);
                }
                else
                {
                    wrog.Odpocznij();
                    UstawKomunikat($"{wrog.Imie} jest wyczerpany i musi odpocząć!");
                }
            }

            ZaktualizujPaski();
        }

        private bool SprawdzCzyKoniec()
        {
            if (!wrog.CzyZyje)
            {
                ZakonczWalke(wygrana: true);
                return true;
            }
            if (!glowneOkno.Bohater.CzyZyje)
            {
                ZakonczWalke(wygrana: false);
                return true;
            }
            return false;
        }

        private void ZakonczWalke(bool wygrana)
        {
            ZablokujPrzyciski(true);

            if (wygrana)
            {
                UstawKomunikat($"ZWYCIĘSTWO! Otrzymujesz {wrog.Zloto}G i 100 EXP.");
                glowneOkno.Bohater.Zloto += wrog.Zloto;
                glowneOkno.Bohater.DodajExp(100);
            }
            else
            {
                int traconeZloto = (int)(glowneOkno.Bohater.Zloto * 0.2);
                glowneOkno.Bohater.Zloto -= traconeZloto;
                UstawKomunikat($"PORAŻKA! Medycy wyciągają Cię z areny. Tracisz {traconeZloto}G.");
            }

            if (btnWroc != null) btnWroc.Visible = true;
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.Bohater.AktualneHp = glowneOkno.Bohater.MaxHp;
            glowneOkno.Bohater.AktualnaStamina = glowneOkno.Bohater.MaxStamina;

            if (glowneOkno.Bohater.PunktyDoRozdania > 0)
                glowneOkno.ZmienEkran(new RozdajPunktyControl(glowneOkno));
            else
                glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}