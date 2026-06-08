using PZLab8i9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class ArenaTrybControl : UserControl
    {
        private Form1 glowneOkno;

        public ArenaTrybControl(Form1 form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            glowneOkno = form;

            OdswiezInfo();
        }

        private void OdswiezInfo()
        {
            var bohater = glowneOkno.Bohater;

            string tekst = $"Witaj na Arenie, {bohater.Imie}!\n\n";
            tekst += $"Złoto: {bohater.Zloto}G\n";
            tekst += $"Zdrowie: {bohater.AktualneHp} / {bohater.MaxHp}\n\n";
            tekst += "Wybierz tryb walki, aby rozpocząć.";

            lblInfo.Text = tekst;
        }

        private void btnDuel_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new ArenaPrepControl(glowneOkno));
        }

        private void btnTournament_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tryb Tournament jest w trakcie przygotowań. Wróć później!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}