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
    public partial class ArenaPrepControl : UserControl
    {
        private Form1 glowneOkno;
        private PrzeciwnikKomputer wylosowanyWrog;
        public ArenaPrepControl(Form1 form)
        {
            InitializeComponent();
            glowneOkno = form;

            LosujPrzeciwnika();
        }

        private void LosujPrzeciwnika()
        {
            wylosowanyWrog = new PrzeciwnikKomputer("Bezimienny Gladiator", glowneOkno.Bohater.Poziom);

            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            var b = glowneOkno.Bohater;
            var w = wylosowanyWrog;

            string bronGracza = b.WyposazonaBron != null ? b.WyposazonaBron.Nazwa : "Pięści";
            string bronWroga = w.WyposazonaBron != null ? w.WyposazonaBron.Nazwa : "Pięści";

            lblGracz.Text = $"--- TY ---\n" +
                            $"{b.Imie} (Poziom {b.Poziom})\n" +
                            $"HP: {b.MaxHp} | Stamina: {b.MaxStamina}\n" +
                            $"Siła: {b.Sila} | Zręczność: {b.Zrecznosc} | Inteligencja: {b.Inteligencja}\n" +
                            $"Charyzma: {b.Charyzma} | Witalność: {b.Witalnosc} | Wytrzymałość: {b.Wytrzymalosc}\n" +
                            $"Broń: {bronGracza} ({b.ObliczObrazeniaZwykle()} dmg)\n" +
                            $"Pancerz:\n{b.PobierzRaportPancerza()}";

            lblWrog.Text = $"--- PRZECIWNIK ---\n" +
                           $"{w.Imie} (Poziom {w.Poziom})\n" +
                           $"HP: {w.MaxHp} | Stamina: {w.MaxStamina}\n" +
                           $"Siła: {w.Sila} | Zręczność: {w.Zrecznosc} | Inteligencja: {w.Inteligencja}\n" +
                           $"Charyzma: {w.Charyzma} | Witalność: {w.Witalnosc} | Wytrzymałość: {w.Wytrzymalosc}\n" +
                           $"Broń: {bronWroga} ({w.ObliczObrazeniaZwykle()} dmg)\n" +
                           $"Pancerz:\n{w.PobierzRaportPancerza()}";
        }

        private void btnLosuj_Click(object sender, EventArgs e)
        {
            LosujPrzeciwnika();
        }

        private void btnWalcz_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new ArenaWalkaControl(glowneOkno, wylosowanyWrog));
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
