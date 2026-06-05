using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class RozdajPunktyControl : UserControl
    {
        private Form1 glowneOkno;

        private int tSila, tZrecznosc, tInteligencja, tCharyzma, tWitalnosc, tWytrzymalosc;
        private int tPunkty;
        public RozdajPunktyControl(Form1 form)
        {
            InitializeComponent();
            glowneOkno = form;

            ZaladujAktualneStatystyki();
        }

        private void ZaladujAktualneStatystyki()
        {
            tSila = glowneOkno.Bohater.Sila;
            tZrecznosc = glowneOkno.Bohater.Zrecznosc;
            tInteligencja = glowneOkno.Bohater.Inteligencja;
            tCharyzma = glowneOkno.Bohater.Charyzma;
            tWitalnosc = glowneOkno.Bohater.Witalnosc;
            tWytrzymalosc = glowneOkno.Bohater.Wytrzymalosc;

            tPunkty = glowneOkno.Bohater.PunktyDoRozdania;

            OdswiezWidok();
        }

        private void OdswiezWidok()
        {
            lblPunkty.Text = $"Punkty do rozdania: {tPunkty}";

            lblStatystyki.Text = $"\n" +
                                 $"Siła: {tSila}\n\n\n" +
                                 $"Zręczność: {tZrecznosc}\n\n\n" +
                                 $"Inteligencja: {tInteligencja}\n\n\n" +
                                 $"Charyzma: {tCharyzma}\n\n\n" +
                                 $"Witalność: {tWitalnosc}\n\n\n" +
                                 $"Wytrzymałość: {tWytrzymalosc}";

            bool moznaDodawac = tPunkty > 0;
            btnSila.Enabled = moznaDodawac;
            btnZrecznosc.Enabled = moznaDodawac;
            btnInteligencja.Enabled = moznaDodawac;
            btnCharyzma.Enabled = moznaDodawac;
            btnWitalnosc.Enabled = moznaDodawac;
            btnWytrzymalosc.Enabled = moznaDodawac;

            btnZatwierdz.Enabled = tPunkty == 0;
        }

        private void btnSila_Click(object sender, EventArgs e) { tSila++; tPunkty--; OdswiezWidok(); }
        private void btnZrecznosc_Click(object sender, EventArgs e) { tZrecznosc++; tPunkty--; OdswiezWidok(); }
        private void btnInteligencja_Click(object sender, EventArgs e) { tInteligencja++; tPunkty--; OdswiezWidok(); }
        private void btnCharyzma_Click(object sender, EventArgs e) { tCharyzma++; tPunkty--; OdswiezWidok(); }
        private void btnWitalnosc_Click(object sender, EventArgs e) { tWitalnosc++; tPunkty--; OdswiezWidok(); }
        private void btnWytrzymalosc_Click(object sender, EventArgs e) { tWytrzymalosc++; tPunkty--; OdswiezWidok(); }

        private void btnZatwierdz_Click(object sender, EventArgs e)
        {
            glowneOkno.Bohater.Sila = tSila;
            glowneOkno.Bohater.Zrecznosc = tZrecznosc;
            glowneOkno.Bohater.Inteligencja = tInteligencja;
            glowneOkno.Bohater.Charyzma = tCharyzma;
            glowneOkno.Bohater.Witalnosc = tWitalnosc;
            glowneOkno.Bohater.Wytrzymalosc = tWytrzymalosc;
            glowneOkno.Bohater.PunktyDoRozdania = 0;

            glowneOkno.Bohater.PrzeliczMaxPaski();

            glowneOkno.Bohater.AktualneHp = glowneOkno.Bohater.MaxHp;
            glowneOkno.Bohater.AktualnaStamina = glowneOkno.Bohater.MaxStamina;

            MessageBox.Show("Punkty zostały rozdane! Paski zdrowia i staminy zaktualizowane.", "Awans", MessageBoxButtons.OK, MessageBoxIcon.Information);

            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
