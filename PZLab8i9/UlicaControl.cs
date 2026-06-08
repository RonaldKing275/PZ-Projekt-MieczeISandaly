using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.DoubleBuffered = true;

            UstawPrzyciskZObramowaniem(btnBronie);
            UstawPrzyciskZObramowaniem(btnMagia);
            UstawPrzyciskZObramowaniem(btnZbrojny);
            UstawPrzyciskZObramowaniem(btnKosciol);
            UstawPrzyciskZObramowaniem(btnArena);

            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            var b = glowneOkno.Bohater;

            barExp.Maximum = b.WymaganyExp;
            barExp.Value = Math.Min(b.Exp, b.WymaganyExp);

            lblExpInfo.Text = $"Poziom: {b.Poziom} | Doświadczenie: {b.Exp} / {b.WymaganyExp}";
        }

        private void UstawPrzyciskZObramowaniem(Button btn)
        {
            btn.UseVisualStyleBackColor = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.BackColor = Color.Transparent;

            typeof(Button).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, btn, new object[] { true });

            // 3. Podpinamy Twoją metodę rysującą tekst
            btn.Paint += RysujObramowanyTekst;
        }

        private void RysujObramowanyTekst(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || string.IsNullOrEmpty(btn.Text)) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float rozmiarCzcionki = e.Graphics.DpiY * btn.Font.SizeInPoints / 72f;

            using (GraphicsPath path = new GraphicsPath())
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                path.AddString(
                    btn.Text,
                    btn.Font.FontFamily,
                    (int)btn.Font.Style,
                    rozmiarCzcionki,
                    new RectangleF(0, 0, btn.Width, btn.Height),
                    format);

                using (Pen pen = new Pen(Color.Red, 3))
                {
                    e.Graphics.DrawPath(pen, path);
                }

                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
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
            glowneOkno.ZmienEkran(new ArenaTrybControl(glowneOkno));
        }
    }
}
