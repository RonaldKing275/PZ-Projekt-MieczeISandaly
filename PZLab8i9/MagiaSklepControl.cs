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
        public MagiaSklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            ZaladujSklep();
        }

        private void ZaladujSklep()
        {
            var b = glowneOkno.Bohater;
            int aktualneCzary = b.PosiadanePrzedmioty.Count(p => p is Czar);

            string infoCzary = $"| Czary: {aktualneCzary}/{b.LimitCzarow}";
            WypiszStatystyki(lblZloto, infoCzary);

            lstAsortyment.Items.Clear();

            foreach (var czar in BazaPrzedmiotow.WszystkieCzary)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(czar.Cena);
                lstAsortyment.Items.Add($"{czar.Nazwa} - {cenaFinalna}G (Wymaga: {czar.WymaganaInteligencja} Inteligencji)");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            ObsluzZakup(lstAsortyment, BazaPrzedmiotow.WszystkieCzary, "Od teraz możesz rzucać to zaklęcie w walce.");
            ZaladujSklep();
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            ObsluzPrzyciskWrot();
        }
    }
}