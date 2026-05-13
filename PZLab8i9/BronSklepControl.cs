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
    public partial class BronSklepControl : SklepBazowyControl
    {
        public BronSklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            ZaladujSklep();
        }

        private void ZaladujSklep()
        {
            WypiszStatystyki(lblZloto);

            var b = glowneOkno.Bohater;
            lstAsortyment.Items.Clear();

            foreach (var przedmiot in BazaPrzedmiotow.WszystkieBronie)
            {
                int cenaFinalna = b.ObliczCenePoRabacie(przedmiot.Cena);
                lstAsortyment.Items.Add($"{przedmiot.Nazwa} - {cenaFinalna}G (Wymaga: S{przedmiot.WymaganaSila}/Z{przedmiot.WymaganaZrecznosc})");
            }
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            ObsluzZakup(lstAsortyment, BazaPrzedmiotow.WszystkieBronie, "Została automatycznie wyposażona jako Twoja główna broń.");
            ZaladujSklep();
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            ObsluzPrzyciskWrot();
        }
    }
}