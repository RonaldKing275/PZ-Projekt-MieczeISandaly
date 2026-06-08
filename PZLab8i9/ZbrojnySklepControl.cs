using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PZLab8i9Lib;

namespace PZLab8i9
{
    public partial class ZbrojnySklepControl : SklepBazowyControl
    {
        public ZbrojnySklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ZaladujSklep();
        }

        private void ZaladujSklep()
        {
            WypiszStatystyki(lblZloto);

            var b = glowneOkno.Bohater;
            lstAsortyment.Items.Clear();

            foreach (var zbroja in BazaPrzedmiotow.WszystkieZbroje)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(zbroja.Cena);
                lstAsortyment.Items.Add($"{zbroja.Nazwa} - {cenaFinalna}G (Wymaga: Poziom {zbroja.WymaganyPoziom})");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            ObsluzZakup(lstAsortyment, BazaPrzedmiotow.WszystkieZbroje, "Założono automatycznie.");
            ZaladujSklep();
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            ObsluzPrzyciskWrot();
        }
    }
}