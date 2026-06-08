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
        private bool czyTuraGracza = true;

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

        private readonly StatyAtaku AtakSnipe = new StatyAtaku(60, 1.2, 15, 2.5);   // Podmieniony Normalny
        private readonly StatyAtaku AtakBombard = new StatyAtaku(35, 1.8, 30, 4.0); // Podmieniony Ciężki

        private int ObliczKosztRuchu() => 30;

        private int ObliczKosztAtaku(Postac postac, StatyAtaku staty)
            => staty.BazowyKoszt + (int)(postac.Sila * staty.SkalowanieSily);

        private int ObliczKosztKrzyku(Postac postac)
            => 20 + (postac.Charyzma * 2);


        public ArenaWalkaControl(Form1 form, PrzeciwnikKomputer wygenerowanyWrog)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
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

        private void OdswiezPrzyciskiUI()
        {
            if (!czyTuraGracza)
            {
                if (btnSzybkiAtak != null) btnSzybkiAtak.Visible = false;
                if (btnNormalnyAtak != null) btnNormalnyAtak.Visible = false;
                if (btnCiezkiAtak != null) btnCiezkiAtak.Visible = false;
                if (btnKrokPrzod != null) btnKrokPrzod.Visible = false;
                if (btnKrokTyl != null) btnKrokTyl.Visible = false;
                if (btnKrzyk != null) btnKrzyk.Visible = false;
                if (btnOdpocznij != null) btnOdpocznij.Visible = false;

                bool maBronDystansowa = glowneOkno.Bohater.WyposazonaBronPomocnicza != null && glowneOkno.Bohater.WyposazonaBronPomocnicza.Nazwa != "Brak";
                btnZmienBron.Visible = maBronDystansowa;

                return;
            }

            btnKrokPrzod.BackgroundImage = Properties.Resources.IkonaKrokPrzodPrzeskalowane;
            btnKrokTyl.BackgroundImage = Properties.Resources.IkonaKrokTylPrzeskalowane;
            btnKrzyk.BackgroundImage = Properties.Resources.IkonaKrzykPrzeskalowane;
            btnZmienBron.BackgroundImage = Properties.Resources.IkonaZmienBronPrzeskalowane;
            btnOdpocznij.BackgroundImage = Properties.Resources.IkonaOdpocznijPrzeskalowane;

            btnKrokPrzod.Text = "";
            btnKrokTyl.Text = "";
            btnKrzyk.Text = "";
            btnZmienBron.Text = "";
            btnOdpocznij.Text = "";

            btnZmienBron.Visible = true;
            btnOdpocznij.Visible = true;

            int kosztRuchu = ObliczKosztRuchu();
            btnKrokPrzod.Visible = glowneOkno.Bohater.AktualnaStamina >= kosztRuchu;
            btnKrokTyl.Visible = glowneOkno.Bohater.AktualnaStamina >= kosztRuchu;
            btnKrzyk.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztKrzyku(glowneOkno.Bohater);

            if (uzywaBroniDystansowej)
            {
                btnSzybkiAtak.Visible = false;

                btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaLukSnipePrzeskalowane;
                btnNormalnyAtak.Text = "";
                btnNormalnyAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakSnipe);

                btnCiezkiAtak.BackgroundImage = Properties.Resources.IkonaLukBombardPrzeskalowane;
                btnCiezkiAtak.Text = "";
                btnCiezkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakBombard);
            }
            else
            {
                btnSzybkiAtak.BackgroundImage = Properties.Resources.IkonaAtakQuickPrzeskalowane;
                btnSzybkiAtak.Text = "";
                btnSzybkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakSzybki);

                btnCiezkiAtak.BackgroundImage = Properties.Resources.IkonaAtakPowerPrzeskalowane;
                btnCiezkiAtak.Text = "";
                btnCiezkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakCiezki);

                if (PobierzDystans() > 0.5)
                {
                    btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaAtakNormalPrzeskalowane;
                    btnNormalnyAtak.Text = "Szarża"; // TODO: ZOBACZYĆ CZY KONIECZNE!
                    btnNormalnyAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakDash);
                }
                else
                {
                    btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaAtakNormalPrzeskalowane;
                    btnNormalnyAtak.Text = "";
                    btnNormalnyAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakNormalny);
                }
            }
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

            OdswiezPrzyciskiUI();
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
        private bool WykonajRuchMechanika(Postac ruszajacy, bool toGracz, bool wPrzod)
        {
            int kosztRuchu = ObliczKosztRuchu();

            if (!ruszajacy.CzyMozeWykonacAkcje(kosztRuchu))
            {
                UstawKomunikat(toGracz ? "Nie masz staminy na ruch! Odpocznij." : $"{ruszajacy.Imie} opada z sił i nie może się ruszyć!");
                return false;
            }

            ruszajacy.AktualnaStamina -= kosztRuchu;
            double mocSkoku = 1.0 + (ruszajacy.Zrecznosc * 0.2);

            // Przypisanie pozycji na podstawie tego kto się rusza
            double posRuszajacego = toGracz ? pozycjaGracza : pozycjaWroga;
            double posCelu = toGracz ? pozycjaWroga : pozycjaGracza;

            bool celPoPrawej = posCelu > posRuszajacego;

            // Jeśli idzie w przód, idzie w stronę celu. Jeśli w tył - w przeciwną.
            double kierunek = wPrzod ? (celPoPrawej ? 1.0 : -1.0) : (celPoPrawej ? -1.0 : 1.0);

            double nowaPozycja = posRuszajacego + (mocSkoku * kierunek);

            if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
            if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;

            // Sprawdzanie przeskoczenia
            bool przeskoczyl = (celPoPrawej && nowaPozycja > posCelu) || (!celPoPrawej && nowaPozycja < posCelu);

            if (Math.Abs(nowaPozycja - posCelu) < 0.5)
            {
                if (przeskoczyl)
                    nowaPozycja = posCelu + (celPoPrawej ? 0.5 : -0.5);
                else
                    nowaPozycja = posCelu - (celPoPrawej ? 0.5 : -0.5);

                if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
                if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;
            }

            // Nadpisanie właściwej zmiennej po wykonaniu obliczeń
            if (toGracz) pozycjaGracza = nowaPozycja;
            else pozycjaWroga = nowaPozycja;

            double nowyDystans = PobierzDystans();

            // Komunikaty
            if (wPrzod && przeskoczyl)
                UstawKomunikat(toGracz ? $"Przeskakujesz wroga! Jesteś za jego plecami. (Dystans: {Math.Round(nowyDystans, 1)}m)" : $"{ruszajacy.Imie} przeskakuje za Twoje plecy! (Dystans: {Math.Round(nowyDystans, 1)}m)");
            else if (wPrzod)
                UstawKomunikat(toGracz ? $"Zbliżasz się do wroga. (Dystans: {Math.Round(nowyDystans, 1)}m)" : $"{ruszajacy.Imie} zbliża się. (Dystans: {Math.Round(nowyDystans, 1)}m)");
            else
            {
                if (nowaPozycja == LEWA_KRAWEDZ || nowaPozycja == PRAWA_KRAWEDZ)
                    UstawKomunikat(toGracz ? $"Odskakujesz pod samą ścianę areny! (Dystans: {Math.Round(nowyDystans, 1)}m)" : $"{ruszajacy.Imie} zapędzony pod ścianę! (Dystans: {Math.Round(nowyDystans, 1)}m)");
                else
                    UstawKomunikat(toGracz ? $"Wycofujesz się! (Dystans: {Math.Round(nowyDystans, 1)}m)" : $"{ruszajacy.Imie} odskakuje do tyłu! (Dystans: {Math.Round(nowyDystans, 1)}m)");
            }

            return true;
        }

        private async void WykonajRuchGracza(bool wPrzod)
        {
            if (WykonajRuchMechanika(glowneOkno.Bohater, toGracz: true, wPrzod))
            {
                ZaktualizujPaski();
                await OddajTureWrogowi();
            }
        }

        private void btnKrokPrzod_Click(object sender, EventArgs e) => WykonajRuchGracza(wPrzod: true);
        private void btnKrokTyl_Click(object sender, EventArgs e) => WykonajRuchGracza(wPrzod: false);


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

        private void WykonajAtakWreczBota()
        {
            int losAtaku = rnd.Next(1, 101);
            int kosztCiezki = ObliczKosztAtaku(wrog, AtakCiezki);
            int kosztNormalny = ObliczKosztAtaku(wrog, AtakNormalny);
            int kosztSzybki = ObliczKosztAtaku(wrog, AtakSzybki);

            if (wrog.AktualnaStamina >= kosztCiezki && losAtaku <= 25)
                WykonajAtak(wrog, glowneOkno.Bohater, false, AtakCiezki);
            else if (wrog.AktualnaStamina >= kosztNormalny && losAtaku <= 75)
                WykonajAtak(wrog, glowneOkno.Bohater, false, AtakNormalny);
            else if (wrog.AktualnaStamina >= kosztSzybki)
                WykonajAtak(wrog, glowneOkno.Bohater, false, AtakSzybki);
            else
            {
                wrog.Odpocznij();
                UstawKomunikat($"{wrog.Imie} dyszy i brakuje mu sił na cios!");
            }
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
            bool udanaAkcja = false;

            if (uzywaBroniDystansowej)
            {
                udanaAkcja = WykonajAtak(glowneOkno.Bohater, wrog, true, AtakSnipe);
            }
            else
            {
                if (PobierzDystans() > 0.5)
                    udanaAkcja = WykonajDashAtak(glowneOkno.Bohater, wrog);
                else
                    udanaAkcja = WykonajAtak(glowneOkno.Bohater, wrog, false, AtakNormalny);
            }

            if (udanaAkcja)
            {
                if (SprawdzCzyKoniec()) return;
                await OddajTureWrogowi();
            }
        }

        private async void btnCiezkiAtak_Click(object sender, EventArgs e)
        {
            bool udanaAkcja = false;

            if (uzywaBroniDystansowej)
            {
                udanaAkcja = WykonajAtak(glowneOkno.Bohater, wrog, true, AtakBombard);
            }
            else
            {
                udanaAkcja = WykonajAtak(glowneOkno.Bohater, wrog, false, AtakCiezki);
            }

            if (udanaAkcja)
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
            if (glowneOkno.Bohater.WyposazonaBronPomocnicza == null || glowneOkno.Bohater.WyposazonaBronPomocnicza.Nazwa == "Brak")
            {
                UstawKomunikat("Nie posiadasz broni dystansowej!");
                return;
            }

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
            czyTuraGracza = false;
            OdswiezPrzyciskiUI();

            ZablokujPrzyciski(true);
            await Task.Delay(1500);

            RuchPrzeciwnika();

            if (!SprawdzCzyKoniec())
            {
                runda++;
                czyTuraGracza = true;
                ZablokujPrzyciski(false);
                OdswiezPrzyciskiUI();
            }
        }

        private void RuchPrzeciwnika()
        {
            double aktDystans = PobierzDystans();
            int losCzynnosci = rnd.Next(1, 101);

            int kosztKrzykuWroga = ObliczKosztKrzyku(wrog);
            int kosztRuchuWroga = ObliczKosztRuchu();

            // AI dedukuje, czy chce grać na dystans
            bool botMaLuk = wrog.WyposazonaBronPomocnicza != null && wrog.WyposazonaBronPomocnicza.Nazwa != "Brak";
            bool preferujeLuk = botMaLuk && (wrog.Zrecznosc >= wrog.Sila); // Łuk jeśli ma więcej Zręczności

            // Zawsze 15% szans na Krzyk (jeśli go stać)
            if (losCzynnosci <= 15 && wrog.AktualnaStamina >= kosztKrzykuWroga)
            {
                WykonajKrzyk(wrog, glowneOkno.Bohater);
                ZaktualizujPaski();
                return;
            }

            // TAKTYKA GŁÓWNA
            if (preferujeLuk)
            {
                // TAKTYKA: ŁUCZNIK
                if (aktDystans <= 0.5) // Gracz podszedł do zwarcia
                {
                    if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                        WykonajRuchMechanika(wrog, false, wPrzod: false); // Łucznik robi unik w tył
                    else
                        WykonajAtakWreczBota(); // Brak staminy na ucieczkę, bije wręcz
                }
                else
                {
                    int kosztSnipe = ObliczKosztAtaku(wrog, AtakSnipe);
                    int kosztBombard = ObliczKosztAtaku(wrog, AtakBombard);

                    if (wrog.AktualnaStamina >= kosztBombard && rnd.Next(100) < 30)
                        WykonajAtak(wrog, glowneOkno.Bohater, true, AtakBombard); // 30% szans na potężny strzał
                    else if (wrog.AktualnaStamina >= kosztSnipe)
                        WykonajAtak(wrog, glowneOkno.Bohater, true, AtakSnipe); // Zwykły strzał
                    else if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                        WykonajRuchMechanika(wrog, false, wPrzod: false); // Odsunięcie się dla poprawy dystansu
                    else
                    {
                        wrog.Odpocznij();
                        UstawKomunikat($"{wrog.Imie} opuszcza łuk ze zmęczenia.");
                    }
                }
            }
            else
            {
                // TAKTYKA: WOJOWNIK
                if (aktDystans > 0.5)
                {
                    int kosztDash = ObliczKosztAtaku(wrog, AtakDash);
                    if (wrog.AktualnaStamina >= kosztDash && rnd.Next(100) < 40)
                    {
                        WykonajDashAtak(wrog, glowneOkno.Bohater); // 40% szans na Szarżę
                    }
                    else if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                    {
                        WykonajRuchMechanika(wrog, false, wPrzod: true); // Zwykłe podejście
                    }
                    else
                    {
                        wrog.Odpocznij();
                        UstawKomunikat($"{wrog.Imie} zatrzymuje się by złapać oddech.");
                    }
                }
                else // Zwarcie
                {
                    WykonajAtakWreczBota();
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
            czyTuraGracza = false;
            OdswiezPrzyciskiUI();

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