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
    public partial class ArenaWalkaControl : UserControl
    {
        private Form1 glowneOkno;
        private PrzeciwnikKomputer wrog;
        private int runda = 1;

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

            ZaktualizujPaski();
            Log("=== WALKA ROZPOCZĘTA ===");
        }

        private void ZaktualizujPaski()
        {
            lblImieGracza.Text = $"{glowneOkno.Bohater.Imie} [Pancerz: {glowneOkno.Bohater.AktualnyPancerz}]";
            lblImieWroga.Text = $"{wrog.Imie} [Pancerz: {wrog.AktualnyPancerz}]";

            barHpGracza.Maximum = glowneOkno.Bohater.MaxHp;
            barHpGracza.Value = glowneOkno.Bohater.AktualneHp;
            barStaminaGracza.Maximum = glowneOkno.Bohater.MaxStamina;
            barStaminaGracza.Value = glowneOkno.Bohater.AktualnaStamina;

            barHpWroga.Maximum = wrog.MaxHp;
            barHpWroga.Value = wrog.AktualneHp;
            barStaminaWroga.Maximum = wrog.MaxStamina;
            barStaminaWroga.Value = wrog.AktualnaStamina;
        }

        private void Log(string wiadomosc)
        {
            txtLogi.AppendText($"[Runda {runda}] {wiadomosc}\r\n");
            txtLogi.SelectionStart = txtLogi.Text.Length;
            txtLogi.ScrollToCaret();
        }

        private async void btnZwyklyAtak_Click(object sender, EventArgs e)
        {
            int kosztAtaku = 15;

            if (!glowneOkno.Bohater.CzyMozeWykonacAkcje(kosztAtaku))
            {
                Log("Masz za mało staminy! Musisz odpocząć.");
                return;
            }

            btnZwyklyAtak.Enabled = false;
            btnOdpocznij.Enabled = false;

            glowneOkno.Bohater.AktualnaStamina -= kosztAtaku;
            int bazoweObrazenia = glowneOkno.Bohater.ObliczObrazeniaZwykle();

            int utrataHp = wrog.OtrzymajObrazenia(bazoweObrazenia);

            Log($"Atakujesz za {bazoweObrazenia} DMG! Pancerz wroga: {wrog.AktualnyPancerz}. Utrata HP: {utrataHp}");
            ZaktualizujPaski();

            if (!wrog.CzyZyje)
            {
                ZakonczWalke(wygrana: true);
                return;
            }

            await Task.Delay(500);

            RuchPrzeciwnika();

            if (!glowneOkno.Bohater.CzyZyje)
            {
                ZakonczWalke(wygrana: false);
                return;
            }

            runda++;
            btnZwyklyAtak.Enabled = true;
            btnOdpocznij.Enabled = true;
        }

        private async void btnOdpocznij_Click(object sender, EventArgs e)
        {
            btnZwyklyAtak.Enabled = false;
            btnOdpocznij.Enabled = false;

            glowneOkno.Bohater.Odpocznij();
            Log("Odpoczywasz i odnawiasz całą staminę!");
            ZaktualizujPaski();

            await Task.Delay(500);
            RuchPrzeciwnika();

            if (!glowneOkno.Bohater.CzyZyje)
            {
                ZakonczWalke(wygrana: false);
                return;
            }

            runda++;
            btnZwyklyAtak.Enabled = true;
            btnOdpocznij.Enabled = true;
        }

        private void RuchPrzeciwnika()
        {
            int kosztAtakuWroga = 15;

            if (wrog.CzyMozeWykonacAkcje(kosztAtakuWroga))
            {
                wrog.AktualnaStamina -= kosztAtakuWroga;
                int dmgBazowe = wrog.ObliczObrazeniaZwykle();

                int utrataHp = glowneOkno.Bohater.OtrzymajObrazenia(dmgBazowe);
                Log($"{wrog.Imie} atakuje za {dmgBazowe} DMG! Twój pancerz: {glowneOkno.Bohater.AktualnyPancerz}. Tracisz {utrataHp} HP!");
            }
            else
            {
                wrog.Odpocznij();
                Log($"{wrog.Imie} jest wyczerpany i musi odpocząć!");
            }
            ZaktualizujPaski();
        }

        private void ZakonczWalke(bool wygrana)
        {
            if (wygrana)
            {
                Log($"ZWYCIĘSTWO! Otrzymujesz {wrog.Zloto}G i 100 EXP.");
                glowneOkno.Bohater.Zloto += wrog.Zloto;
                glowneOkno.Bohater.DodajExp(100);
            }
            else
            {
                int traconeZloto = (int)(glowneOkno.Bohater.Zloto * 0.2);
                glowneOkno.Bohater.Zloto -= traconeZloto;
                Log($"PORAŻKA! Medycy wyciągają Cię z areny. Tracisz {traconeZloto}G na koszty leczenia.");
            }

            glowneOkno.Bohater.AktualneHp = glowneOkno.Bohater.MaxHp;
            glowneOkno.Bohater.AktualnaStamina = glowneOkno.Bohater.MaxStamina;
            btnWroc.Visible = true;
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            if (glowneOkno.Bohater.PunktyDoRozdania > 0)
                glowneOkno.ZmienEkran(new RozdajPunktyControl(glowneOkno));
            else
                glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
