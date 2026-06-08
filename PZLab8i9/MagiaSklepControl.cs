using PZLab8i9Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class MagiaSklepControl : SklepBazowyControl
    {
        private enum StanSklepu { Glowny, Zaklecia }
        private StanSklepu aktualnyStan = StanSklepu.Glowny;

        private bool zaklinajBronGlowna = true;
        private TypZakleciaBroni wybranyTyp = TypZakleciaBroni.Flame;
        private WielkoscZakleciaBroni wybranaWielkosc = WielkoscZakleciaBroni.Male;

        public MagiaSklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            UstawStan(StanSklepu.Glowny);
        }

        private struct ParametryZaklecia
        {
            public int Szansa;
            public int Cena;
            public int Dmg;

            public ParametryZaklecia(int szansa, int cena, int dmg)
            {
                Szansa = szansa;
                Cena = cena;
                Dmg = dmg;
            }
        }

        private void UstawStan(StanSklepu nowyStan)
        {
            aktualnyStan = nowyStan;

            if (aktualnyStan == StanSklepu.Glowny)
            {
                this.BackgroundImage = Properties.Resources.MiSSklepMagiaGotowe;

                if (btnKupSpell != null) btnKupSpell.Visible = true;
                if (btnKupZaklecie != null) btnKupZaklecie.Visible = true;

                if (btnKup != null) btnKup.Visible = false;
                if (btnZaklecieFlame != null) btnZaklecieFlame.Visible = false;
                if (btnZaklecieFrost != null) btnZaklecieFrost.Visible = false;
                if (btnZakleciePoison != null) btnZakleciePoison.Visible = false;
                if (btnZaklecieWraith != null) btnZaklecieWraith.Visible = false;
                if (btnZaklecieZmianaBron != null) btnZaklecieZmianaBron.Visible = false;
                if (btnZaklecieMale != null) btnZaklecieMale.Visible = false;
                if (btnZaklecieSrednie != null) btnZaklecieSrednie.Visible = false;
                if (btnZaklecieDuze != null) btnZaklecieDuze.Visible = false;

                WypiszStatystyki(lblZloto, "| Wybierz usługę");
            }
            else if (aktualnyStan == StanSklepu.Zaklecia)
            {
                this.BackgroundImage = Properties.Resources.MiSSklepMagia2Gotowe;

                if (btnKupSpell != null) btnKupSpell.Visible = false;
                if (btnKupZaklecie != null) btnKupZaklecie.Visible = false;

                if (btnKup != null) btnKup.Visible = true;
                if (btnZaklecieFlame != null) btnZaklecieFlame.Visible = true;
                if (btnZaklecieFrost != null) btnZaklecieFrost.Visible = true;
                if (btnZakleciePoison != null) btnZakleciePoison.Visible = true;
                if (btnZaklecieWraith != null) btnZaklecieWraith.Visible = true;
                if (btnZaklecieZmianaBron != null) btnZaklecieZmianaBron.Visible = true;
                if (btnZaklecieMale != null) btnZaklecieMale.Visible = true;
                if (btnZaklecieSrednie != null) btnZaklecieSrednie.Visible = true;
                if (btnZaklecieDuze != null) btnZaklecieDuze.Visible = true;

                OdswiezWidokZaklec();
            }
        }

        private void OdswiezWidokZaklec()
        {
            var b = glowneOkno.Bohater;
            Bron docelowaBron = zaklinajBronGlowna ? b.WyposazonaBronGlowna : b.WyposazonaBronPomocnicza;

            if (docelowaBron == null || docelowaBron.Nazwa == "Brak")
            {
                lblZloto.Text = $"Złoto: {b.Zloto}G\nAktualny cel: BRAK BRONI! (Zmień broń)";
                if (btnKup != null) btnKup.Enabled = false;
                return;
            }

            if (btnKup != null) btnKup.Enabled = true;

            ParametryZaklecia parametry = ObliczParametryZaklecia(b, docelowaBron, wybranaWielkosc);

            string rodzajBroni = zaklinajBronGlowna ? "[Główna]" : "[Pomocnicza]";
            string obecneZakl = docelowaBron.TypZaklecia != TypZakleciaBroni.Brak ?
                $"{docelowaBron.TypZaklecia} {docelowaBron.WielkoscZaklecia} ({docelowaBron.ZaklecieSzansa}%)" : "Brak";

            lblZloto.Text = $"Złoto: {b.Zloto}G\n" +
                            $"Cel: {docelowaBron.Nazwa} {rodzajBroni} (Obecnie: {obecneZakl})\n" +
                            $"Moc: {wybranaWielkosc} {wybranyTyp}\n" +
                            $"Efekt: {parametry.Szansa}% szans na {parametry.Dmg} DMG magią i uśpienie wroga\n" +
                            $"Koszt Rytuału: {parametry.Cena}G";
        }

        private void btnKupSpell_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaklęcia z ręki są w trakcie przygotowań. Wróć później!", "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKupZaklecie_Click(object sender, EventArgs e)
        {
            UstawStan(StanSklepu.Zaklecia);
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            if (aktualnyStan == StanSklepu.Zaklecia)
                UstawStan(StanSklepu.Glowny);
            else
                ObsluzPrzyciskWrot();
        }

        private void btnZaklecieZmianaBron_Click(object sender, EventArgs e)
        {
            zaklinajBronGlowna = !zaklinajBronGlowna;
            OdswiezWidokZaklec();
        }

        private void btnZaklecieFlame_Click(object sender, EventArgs e) { wybranyTyp = TypZakleciaBroni.Flame; OdswiezWidokZaklec(); }
        private void btnZaklecieFrost_Click(object sender, EventArgs e) { wybranyTyp = TypZakleciaBroni.Frost; OdswiezWidokZaklec(); }
        private void btnZakleciePoison_Click(object sender, EventArgs e) { wybranyTyp = TypZakleciaBroni.Poison; OdswiezWidokZaklec(); }
        private void btnZaklecieWraith_Click(object sender, EventArgs e) { wybranyTyp = TypZakleciaBroni.Wraith; OdswiezWidokZaklec(); }

        private void btnZaklecieMale_Click(object sender, EventArgs e) { wybranaWielkosc = WielkoscZakleciaBroni.Male; OdswiezWidokZaklec(); }
        private void btnZaklecieSrednie_Click(object sender, EventArgs e) { wybranaWielkosc = WielkoscZakleciaBroni.Srednie; OdswiezWidokZaklec(); }
        private void btnZaklecieDuze_Click(object sender, EventArgs e) { wybranaWielkosc = WielkoscZakleciaBroni.Duze; OdswiezWidokZaklec(); }

        private void btnKup_Click(object sender, EventArgs e)
        {
            var b = glowneOkno.Bohater;
            Bron docelowaBron = zaklinajBronGlowna ? b.WyposazonaBronGlowna : b.WyposazonaBronPomocnicza;

            if (docelowaBron == null || docelowaBron.Nazwa == "Brak") return;

            ParametryZaklecia parametry = ObliczParametryZaklecia(b, docelowaBron, wybranaWielkosc);

            if (b.Zloto < parametry.Cena)
            {
                MessageBox.Show($"Nie stać Cię na ten rytuał! Wymagane {parametry.Cena}G.", "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            b.Zloto -= parametry.Cena;
            docelowaBron.TypZaklecia = wybranyTyp;
            docelowaBron.WielkoscZaklecia = wybranaWielkosc;
            docelowaBron.ZaklecieSzansa = parametry.Szansa;
            docelowaBron.ZaklecieObrazenia = parametry.Dmg;

            MessageBox.Show($"Zakończono rytuał! Twoja broń ({docelowaBron.Nazwa}) emanuje teraz potęgą {wybranyTyp}.", "Zaklęto broń", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OdswiezWidokZaklec();
        }

        private ParametryZaklecia ObliczParametryZaklecia(Gracz b, Bron docelowaBron, WielkoscZakleciaBroni wielkosc)
        {
            switch (wielkosc)
            {
                case WielkoscZakleciaBroni.Male:
                    return new ParametryZaklecia(
                        10,
                        b.Inteligencja * 100,
                        (b.Inteligencja * 1) + docelowaBron.MinObrazenia
                    );

                case WielkoscZakleciaBroni.Srednie:
                    return new ParametryZaklecia(
                        20,
                        b.Inteligencja * 300,
                        (b.Inteligencja * 2) + ((docelowaBron.MinObrazenia + docelowaBron.MaxObrazenia) / 2)
                    );

                case WielkoscZakleciaBroni.Duze:
                    return new ParametryZaklecia(
                        30,
                        b.Inteligencja * 600,
                        (b.Inteligencja * 3) + docelowaBron.MaxObrazenia
                    );

                default:
                    return new ParametryZaklecia(0, 0, 0);
            }
        }
    }
}