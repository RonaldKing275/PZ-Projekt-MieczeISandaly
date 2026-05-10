using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PZLab8i9
{
    public partial class UlicaControl : UserControl
    {
        private Form1 glowneOkno;
        public UlicaControl(Form1 form)
        {
            InitializeComponent();
            glowneOkno = form;

            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            var b = glowneOkno.Bohater;

            barExp.Maximum = b.WymaganyExp;
            barExp.Value = Math.Min(b.Exp, b.WymaganyExp);

            lblExpInfo.Text = $"Poziom: {b.Poziom} | Doświadczenie: {b.Exp} / {b.WymaganyExp}";
        }

        private void btnZbrojny_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new ZbrojnySklepControl(glowneOkno));
        }

        private void btnBronie_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new BronSklepControl(glowneOkno));
        }

        private void btnMagia_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new MagiaSklepControl(glowneOkno));
        }

        private void btnKosciol_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new KosciolControl(glowneOkno));
        }

        private void btnArena_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new ArenaPrepControl(glowneOkno));
        }
    }
}
