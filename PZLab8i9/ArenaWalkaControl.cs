using PZLab8i9Lib;
using System;
using System.Drawing;
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

        private int pikseleXGracza = 0;
        private int pikseleXWroga = 0;

        private bool uzywaBroniDystansowej = false;
        private bool czyTuraGracza = true;

        private bool graczPatrzyWPrawo = true;
        private bool wrogPatrzyWPrawo = false;

        private double PobierzDystans() => Math.Abs(pozycjaGracza - pozycjaWroga);

        // PARAMETRY I KOSZTY
        private struct StatyAtaku
        {
            public int Szansa;
            public double Mnoznik;
            public int BazowyKoszt;
            public double SkalowanieSily;

            public StatyAtaku(int szansa, double mnoznik, int bazowyKoszt, double skalowanieSily)
            { Szansa = szansa; Mnoznik = mnoznik; BazowyKoszt = bazowyKoszt; SkalowanieSily = skalowanieSily; }
        }

        private readonly StatyAtaku AtakSzybki = new StatyAtaku(90, 0.9, 10, 2);
        private readonly StatyAtaku AtakNormalny = new StatyAtaku(45, 1.5, 20, 3.5);
        private readonly StatyAtaku AtakCiezki = new StatyAtaku(25, 2.0, 35, 4.5);
        private readonly StatyAtaku AtakDash = new StatyAtaku(40, 1.2, 20, 3.5);

        private readonly StatyAtaku AtakSnipe = new StatyAtaku(60, 1.2, 15, 2.5);
        private readonly StatyAtaku AtakBombard = new StatyAtaku(35, 1.8, 30, 4.0);

        private int ObliczKosztRuchu() => 30;
        private int ObliczKosztAtaku(Postac postac, StatyAtaku staty) => staty.BazowyKoszt + (int)(postac.Sila * staty.SkalowanieSily);
        private int ObliczKosztKrzyku(Postac postac) => 20 + (postac.Charyzma * 2);

        public ArenaWalkaControl(Form1 form, PrzeciwnikKomputer wygenerowanyWrog)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            glowneOkno = form;
            wrog = wygenerowanyWrog;

            if (picGracz != null && picWrog != null)
            {
                picGracz.Visible = false;
                picWrog.Visible = false;

                Control rodzic = picGracz.Parent;
                if (rodzic != null)
                {
                    typeof(Control).InvokeMember("DoubleBuffered",
                        System.Reflection.BindingFlags.SetProperty |
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic,
                        null, rodzic, new object[] { true });

                    rodzic.Paint += Arena_Paint;
                }
            }

            PrzygotujWalke();
        }

        private void Arena_Paint(object sender, PaintEventArgs e)
        {
            if (picWrog != null && picWrog.Image != null)
                e.Graphics.DrawImage(picWrog.Image, pikseleXWroga, picWrog.Location.Y, picWrog.Width, picWrog.Height);

            if (picGracz != null && picGracz.Image != null)
                e.Graphics.DrawImage(picGracz.Image, pikseleXGracza, picGracz.Location.Y, picGracz.Width, picGracz.Height);
        }

        private void OdswiezPozycjeGrafik()
        {
            if (picGracz == null || picWrog == null || picGracz.Image == null || picWrog.Image == null) return;

            Control rodzic = picGracz.Parent;
            int szerokoscAreny = rodzic != null ? rodzic.Width : this.Width;
            int dostepnaSzerokosc = szerokoscAreny - picGracz.Width;

            double pikseleNaMetr = (double)dostepnaSzerokosc / PRAWA_KRAWEDZ;

            pikseleXGracza = (int)(pozycjaGracza * pikseleNaMetr);
            pikseleXWroga = (int)(pozycjaWroga * pikseleNaMetr);

            bool graczPowinienPatrzecWPrawo = pozycjaWroga > pozycjaGracza;
            bool wrogPowinienPatrzecWPrawo = pozycjaGracza > pozycjaWroga;

            if (graczPatrzyWPrawo != graczPowinienPatrzecWPrawo)
            {
                picGracz.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                graczPatrzyWPrawo = graczPowinienPatrzecWPrawo;
            }

            if (wrogPatrzyWPrawo != wrogPowinienPatrzecWPrawo)
            {
                picWrog.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                wrogPatrzyWPrawo = wrogPowinienPatrzecWPrawo;
            }

            if (rodzic != null) rodzic.Invalidate();
            else this.Invalidate();
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

            bool botMaLuk = wrog.WyposazonaBronPomocnicza != null && wrog.WyposazonaBronPomocnicza.Nazwa != "Brak";
            bool preferujeLuk = botMaLuk && (wrog.Zrecznosc >= wrog.Sila);

            if (picWrog != null)
            {
                picWrog.BackgroundImage = null;
                picWrog.Image = preferujeLuk ? Properties.Resources.postacWrog2 : Properties.Resources.postacWrog1;
            }

            ZaktualizujPaski();
            OdswiezPozycjeGrafik();
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
                btnNormalnyAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakSnipe);

                btnCiezkiAtak.BackgroundImage = Properties.Resources.IkonaLukBombardPrzeskalowane;
                btnCiezkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakBombard);
            }
            else
            {
                btnSzybkiAtak.BackgroundImage = Properties.Resources.IkonaAtakQuickPrzeskalowane;
                btnSzybkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakSzybki);

                btnCiezkiAtak.BackgroundImage = Properties.Resources.IkonaAtakPowerPrzeskalowane;
                btnCiezkiAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakCiezki);

                if (PobierzDystans() > 3.5)
                {
                    btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaAtakNormalPrzeskalowane;
                    btnNormalnyAtak.Visible = glowneOkno.Bohater.AktualnaStamina >= ObliczKosztAtaku(glowneOkno.Bohater, AtakDash);
                }
                else
                {
                    btnNormalnyAtak.BackgroundImage = Properties.Resources.IkonaAtakNormalPrzeskalowane;
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

        private bool WykonajRuchMechanika(Postac ruszajacy, bool toGracz, bool wPrawo)
        {
            int kosztRuchu = ObliczKosztRuchu();

            if (!ruszajacy.CzyMozeWykonacAkcje(kosztRuchu))
            {
                UstawKomunikat(toGracz ? "Nie masz staminy na ruch! Odpocznij." : $"{ruszajacy.Imie} opada z sił i nie może się ruszyć!");
                return false;
            }

            ruszajacy.AktualnaStamina -= kosztRuchu;
            double mocSkoku = 2.0 + (ruszajacy.Zrecznosc * 0.4);

            double posRuszajacego = toGracz ? pozycjaGracza : pozycjaWroga;
            double posCelu = toGracz ? pozycjaWroga : pozycjaGracza;

            bool wPrzod = (wPrawo && posCelu > posRuszajacego) || (!wPrawo && posCelu < posRuszajacego);
            double kierunek = wPrawo ? 1.0 : -1.0;
            double nowaPozycja = posRuszajacego + (mocSkoku * kierunek);

            if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
            if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;

            bool przeskoczyl = (posRuszajacego < posCelu && nowaPozycja > posCelu) ||
                               (posRuszajacego > posCelu && nowaPozycja < posCelu);

            if (Math.Abs(nowaPozycja - posCelu) < 3.5)
            {
                if (przeskoczyl) nowaPozycja = posCelu + (wPrawo ? 3.5 : -3.5);
                else nowaPozycja = posCelu - (wPrawo ? 3.5 : -3.5);

                if (nowaPozycja < LEWA_KRAWEDZ) nowaPozycja = LEWA_KRAWEDZ;
                if (nowaPozycja > PRAWA_KRAWEDZ) nowaPozycja = PRAWA_KRAWEDZ;
            }

            if (toGracz) pozycjaGracza = nowaPozycja;
            else pozycjaWroga = nowaPozycja;

            double nowyDystans = PobierzDystans();

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

            OdswiezPozycjeGrafik();
            return true;
        }

        private async void WykonajRuchGracza(bool wPrawo)
        {
            if (WykonajRuchMechanika(glowneOkno.Bohater, toGracz: true, wPrawo))
            {
                ZaktualizujPaski();
                await OddajTureWrogowi();
            }
        }

        private void btnKrokPrzod_Click(object sender, EventArgs e) => WykonajRuchGracza(wPrawo: true);
        private void btnKrokTyl_Click(object sender, EventArgs e) => WykonajRuchGracza(wPrawo: false);


        // SYSTEMY ZAKLĘĆ I ATAKÓW
        private (bool udanaAkcja, bool ogluszyl) WykonajAtak(Postac atakujacy, Postac broniacy, bool czyDystans, StatyAtaku staty)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            double aktDystans = PobierzDystans();
            int kosztAtaku = ObliczKosztAtaku(atakujacy, staty);

            if (!czyDystans && aktDystans > 3.5)
            {
                UstawKomunikat(toGracz ? "Jesteś za daleko! Podejdź bliżej lub użyj Szarży." : $"{atakujacy.Imie} uderza powietrze!");
                return (false, false);
            }
            if (czyDystans && aktDystans <= 3.5)
            {
                UstawKomunikat(toGracz ? "Wróg jest za blisko na łuk! Wyciągnij broń białą." : $"{atakujacy.Imie} nie może strzelać w zwarciu!");
                return (false, false);
            }

            if (!atakujacy.CzyMozeWykonacAkcje(kosztAtaku))
            {
                UstawKomunikat(toGracz ? "Masz za mało staminy! Musisz odpocząć." : $"{atakujacy.Imie} ledwo stoi na nogach!");
                return (false, false);
            }

            atakujacy.AktualnaStamina -= kosztAtaku;
            int los = rnd.Next(1, 101);
            bool ogluszylWroga = false;

            if (los <= staty.Szansa)
            {
                int bazoweDmg = atakujacy.LosujObrazenia(czyDystans);
                int finalneDmg = (int)(bazoweDmg * staty.Mnoznik);
                int utrataHp = broniacy.OtrzymajObrazenia(finalneDmg);

                if (!czyDystans) AudioPlayer.GrajEfekt("uderzenieMiecza.mp3");
                string komunikat = toGracz ? $"TRAFIENIE! Zadajesz {utrataHp} DMG." : $"{atakujacy.Imie} trafia Cię za {utrataHp} DMG.";

                // Mechanika Zaklęć
                Bron uzytaBron = czyDystans ? atakujacy.WyposazonaBronPomocnicza : atakujacy.WyposazonaBronGlowna;
                if (uzytaBron != null && uzytaBron.TypZaklecia != TypZakleciaBroni.Brak)
                {
                    if (rnd.Next(1, 101) <= uzytaBron.ZaklecieSzansa)
                    {
                        int dmgMagiczne = uzytaBron.ZaklecieObrazenia;
                        broniacy.AktualneHp -= dmgMagiczne; // Magia omija pancerz
                        if (broniacy.AktualneHp < 0) broniacy.AktualneHp = 0;
                        ogluszylWroga = true;

                        komunikat += $" ZAKLĘCIE ({uzytaBron.TypZaklecia}) trafia za {dmgMagiczne} DMG i OGŁUSZA!";
                    }
                }

                UstawKomunikat(komunikat);
            }
            else
            {
                UstawKomunikat(toGracz ? "PUDŁO! Przecinasz powietrze." : $"{atakujacy.Imie} pudłuje!");
            }

            ZaktualizujPaski();
            return (true, ogluszylWroga);
        }

        private (bool udanaAkcja, bool ogluszyl) WykonajDashAtak(Postac atakujacy, Postac broniacy)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            double aktDystans = PobierzDystans();
            int kosztDash = ObliczKosztAtaku(atakujacy, AtakDash);

            if (aktDystans <= 3.5)
            {
                UstawKomunikat(toGracz ? "Jesteś za blisko na szarżę!" : "");
                return (false, false);
            }

            if (!atakujacy.CzyMozeWykonacAkcje(kosztDash))
            {
                UstawKomunikat(toGracz ? "Za mało staminy na szarżę!" : $"{atakujacy.Imie} potyka się z braku sił!");
                return (false, false);
            }

            atakujacy.AktualnaStamina -= kosztDash;
            double zasiegSzarzy = 1.0 + (atakujacy.Zrecznosc * 0.15) + (atakujacy.Sila * 0.2);

            double posAtakujacego = toGracz ? pozycjaGracza : pozycjaWroga;
            double posBroniacego = toGracz ? pozycjaWroga : pozycjaGracza;

            bool wrogPoPrawej = posBroniacego > posAtakujacego;
            double kierunek = wrogPoPrawej ? 1.0 : -1.0;
            double dystansDoZwarcia = aktDystans - 3.5;
            bool ogluszylWroga = false;

            if (zasiegSzarzy >= dystansDoZwarcia)
            {
                double nowaPozycja = posBroniacego - (3.5 * kierunek);

                if (toGracz) pozycjaGracza = nowaPozycja;
                else pozycjaWroga = nowaPozycja;

                int los = rnd.Next(1, 101);
                if (los <= AtakDash.Szansa)
                {
                    int bazoweDmg = atakujacy.LosujObrazenia(false);
                    int finalneDmg = (int)(bazoweDmg * AtakDash.Mnoznik);
                    int utrataHp = broniacy.OtrzymajObrazenia(finalneDmg);

                    string komunikat = toGracz ? $"SZARŻA! Wpadasz we wroga i zadajesz {utrataHp} DMG." : $"{atakujacy.Imie} szarżuje i wbija Ci broń, zadając {utrataHp} DMG!";

                    // Mechanika Zaklęć w Szarży
                    Bron uzytaBron = atakujacy.WyposazonaBronGlowna;
                    if (uzytaBron != null && uzytaBron.TypZaklecia != TypZakleciaBroni.Brak)
                    {
                        if (rnd.Next(1, 101) <= uzytaBron.ZaklecieSzansa)
                        {
                            int dmgMagiczne = uzytaBron.ZaklecieObrazenia;
                            broniacy.AktualneHp -= dmgMagiczne;
                            if (broniacy.AktualneHp < 0) broniacy.AktualneHp = 0;
                            ogluszylWroga = true;

                            komunikat += $" ZAKLĘCIE ({uzytaBron.TypZaklecia}) trafia za {dmgMagiczne} DMG i OGŁUSZA!";
                        }
                    }

                    UstawKomunikat(komunikat);
                }
                else
                {
                    UstawKomunikat(toGracz ? "SZARŻA PUDŁUJE! Doskakujesz, ale wróg robi unik." : $"{atakujacy.Imie} szarżuje, ale w ostatniej chwili robisz unik!");
                }
            }
            else
            {
                double nowaPozycja = posAtakujacego + (zasiegSzarzy * kierunek);

                if (toGracz) pozycjaGracza = nowaPozycja;
                else pozycjaWroga = nowaPozycja;

                double nowyDystans = PobierzDystans();
                UstawKomunikat(toGracz ? $"Szarżujesz, ale opadasz z sił przed celem! (Zostało: {Math.Round(nowyDystans, 1)}m)" : $"{atakujacy.Imie} szarżuje, ale mija się z Tobą z braku sił!");
            }

            OdswiezPozycjeGrafik();
            ZaktualizujPaski();
            return (true, ogluszylWroga);
        }

        private bool WykonajKrzyk(Postac atakujacy, Postac broniacy)
        {
            bool toGracz = (atakujacy == glowneOkno.Bohater);
            int kosztKrzyku = ObliczKosztKrzyku(atakujacy);

            if (!atakujacy.CzyMozeWykonacAkcje(kosztKrzyku))
            {
                UstawKomunikat(toGracz ? "Masz zdarte gardło i brak tchu! Odpocznij." : $"{atakujacy.Imie} próbuje krzyczeć, ale chrypi z wyczerpania!");
                return false;
            }

            atakujacy.AktualnaStamina -= kosztKrzyku;

            int szansa = (atakujacy.Charyzma - broniacy.Charyzma) * 10;
            szansa = Math.Max(10, Math.Min(99, szansa));

            int los = rnd.Next(1, 101);

            AudioPlayer.GrajEfekt("krzyk.mp3");

            if (los <= szansa)
            {
                int dmg = 10 + (atakujacy.Charyzma * 2);
                int utrataHp = broniacy.OtrzymajObrazenia(dmg);

                UstawKomunikat(toGracz ? $"POTĘŻNY KRZYK! Twój ryk zadaje {utrataHp} obrażeń." : $"{atakujacy.Imie} drze się wniebogłosy! Tracisz {utrataHp} DMG.");
            }
            else
            {
                UstawKomunikat(toGracz ? "Krzyczysz, ale wróg tylko się zaśmiał. PUDŁO!" : $"{atakujacy.Imie} próbuje Cię ogłuszyć krzykiem, ale nie robi to na Tobie wrażenia.");
            }

            ZaktualizujPaski();
            return true;
        }

        private bool WykonajAtakWreczBota()
        {
            int losAtaku = rnd.Next(1, 101);
            int kosztCiezki = ObliczKosztAtaku(wrog, AtakCiezki);
            int kosztNormalny = ObliczKosztAtaku(wrog, AtakNormalny);
            int kosztSzybki = ObliczKosztAtaku(wrog, AtakSzybki);

            if (wrog.AktualnaStamina >= kosztCiezki && losAtaku <= 25)
                return WykonajAtak(wrog, glowneOkno.Bohater, false, AtakCiezki).ogluszyl;
            else if (wrog.AktualnaStamina >= kosztNormalny && losAtaku <= 75)
                return WykonajAtak(wrog, glowneOkno.Bohater, false, AtakNormalny).ogluszyl;
            else if (wrog.AktualnaStamina >= kosztSzybki)
                return WykonajAtak(wrog, glowneOkno.Bohater, false, AtakSzybki).ogluszyl;
            else
            {
                wrog.Odpocznij();
                UstawKomunikat($"{wrog.Imie} dyszy i brakuje mu sił na cios!");
                return false;
            }
        }

        // PRZYCISKI AKCJI GRACZA
        private async void btnSzybkiAtak_Click(object sender, EventArgs e)
        {
            var wynik = WykonajAtak(glowneOkno.Bohater, wrog, uzywaBroniDystansowej, AtakSzybki);
            if (wynik.udanaAkcja)
            {
                if (SprawdzCzyKoniec()) return;
                if (wynik.ogluszyl) return; // Zatrzymuje turę dla gracza

                await OddajTureWrogowi();
            }
        }

        private async void btnNormalnyAtak_Click(object sender, EventArgs e)
        {
            (bool udanaAkcja, bool ogluszyl) wynik = (false, false);

            if (uzywaBroniDystansowej)
            {
                wynik = WykonajAtak(glowneOkno.Bohater, wrog, true, AtakSnipe);
            }
            else
            {
                if (PobierzDystans() > 3.5)
                    wynik = WykonajDashAtak(glowneOkno.Bohater, wrog);
                else
                    wynik = WykonajAtak(glowneOkno.Bohater, wrog, false, AtakNormalny);
            }

            if (wynik.udanaAkcja)
            {
                if (SprawdzCzyKoniec()) return;
                if (wynik.ogluszyl) return;

                await OddajTureWrogowi();
            }
        }

        private async void btnCiezkiAtak_Click(object sender, EventArgs e)
        {
            (bool udanaAkcja, bool ogluszyl) wynik = (false, false);

            if (uzywaBroniDystansowej)
            {
                wynik = WykonajAtak(glowneOkno.Bohater, wrog, true, AtakBombard);
            }
            else
            {
                wynik = WykonajAtak(glowneOkno.Bohater, wrog, false, AtakCiezki);
            }

            if (wynik.udanaAkcja)
            {
                if (SprawdzCzyKoniec()) return;
                if (wynik.ogluszyl) return;

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

            bool kolejnaTuraBota = true;

            while (kolejnaTuraBota)
            {
                await Task.Delay(1500); // Odczekanie przed ruchem wroga
                if (SprawdzCzyKoniec()) return;

                kolejnaTuraBota = RuchPrzeciwnika(); // Jeśli zwróci true = ogłuszył i dostaje kolejny cios

                if (SprawdzCzyKoniec()) return;
            }

            runda++;
            czyTuraGracza = true;
            ZablokujPrzyciski(false);
            OdswiezPrzyciskiUI();
        }

        private bool RuchPrzeciwnika()
        {
            double aktDystans = PobierzDystans();
            int losCzynnosci = rnd.Next(1, 101);

            int kosztKrzykuWroga = ObliczKosztKrzyku(wrog);
            int kosztRuchuWroga = ObliczKosztRuchu();

            bool botMaLuk = wrog.WyposazonaBronPomocnicza != null && wrog.WyposazonaBronPomocnicza.Nazwa != "Brak";
            bool preferujeLuk = botMaLuk && (wrog.Zrecznosc >= wrog.Sila);

            if (losCzynnosci <= 15 && wrog.AktualnaStamina >= kosztKrzykuWroga)
            {
                WykonajKrzyk(wrog, glowneOkno.Bohater);
                ZaktualizujPaski();
                return false;
            }

            bool graczPoPrawej = pozycjaGracza > pozycjaWroga;
            bool ogluszylGracza = false;

            if (preferujeLuk)
            {
                if (aktDystans <= 3.5)
                {
                    if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                        WykonajRuchMechanika(wrog, false, wPrawo: !graczPoPrawej);
                    else
                        ogluszylGracza = WykonajAtakWreczBota();
                }
                else
                {
                    int kosztSnipe = ObliczKosztAtaku(wrog, AtakSnipe);
                    int kosztBombard = ObliczKosztAtaku(wrog, AtakBombard);

                    if (wrog.AktualnaStamina >= kosztBombard && rnd.Next(100) < 30)
                        ogluszylGracza = WykonajAtak(wrog, glowneOkno.Bohater, true, AtakBombard).ogluszyl;
                    else if (wrog.AktualnaStamina >= kosztSnipe)
                        ogluszylGracza = WykonajAtak(wrog, glowneOkno.Bohater, true, AtakSnipe).ogluszyl;
                    else if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                        WykonajRuchMechanika(wrog, false, wPrawo: !graczPoPrawej);
                    else
                    {
                        wrog.Odpocznij();
                        UstawKomunikat($"{wrog.Imie} opuszcza łuk ze zmęczenia.");
                    }
                }
            }
            else
            {
                if (aktDystans > 3.5)
                {
                    int kosztDash = ObliczKosztAtaku(wrog, AtakDash);
                    if (wrog.AktualnaStamina >= kosztDash && rnd.Next(100) < 40)
                    {
                        ogluszylGracza = WykonajDashAtak(wrog, glowneOkno.Bohater).ogluszyl;
                    }
                    else if (wrog.CzyMozeWykonacAkcje(kosztRuchuWroga))
                    {
                        WykonajRuchMechanika(wrog, false, wPrawo: graczPoPrawej);
                    }
                    else
                    {
                        wrog.Odpocznij();
                        UstawKomunikat($"{wrog.Imie} zatrzymuje się by złapać oddech.");
                    }
                }
                else
                {
                    ogluszylGracza = WykonajAtakWreczBota();
                }
            }

            ZaktualizujPaski();
            return ogluszylGracza;
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