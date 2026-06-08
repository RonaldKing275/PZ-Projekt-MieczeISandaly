using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PZLab8i9Lib;

namespace PZLab8i9
{
    public partial class ZbrojnySklepControl : SklepBazowyControl
    {
        private string obecnaKategoria = "";
        private List<Zbroja> zbrojeWKategorii = new List<Zbroja>();
        private int aktualnaStrona = 1;

        public ZbrojnySklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            UstawStanGlownegoMenu();

            if (pnlPolkaSklepowa != null)
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.SetProperty |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null, pnlPolkaSklepowa, new object[] { true });
            }
        }

        private void UstawStanGlownegoMenu()
        {
            obecnaKategoria = "";

            if (btnHelmy != null) btnHelmy.Visible = true;
            if (btnNaramienniki != null) btnNaramienniki.Visible = true;
            if (btnKlaty != null) btnKlaty.Visible = true;
            if (btnSpodnie != null) btnSpodnie.Visible = true;
            if (btnButy != null) btnButy.Visible = true;
            if (btnTarcze != null) btnTarcze.Visible = true;

            if (pnlPolkaSklepowa != null) pnlPolkaSklepowa.Visible = false;
            if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = false;

            this.BackColor = SystemColors.Control;
            this.BackgroundImage = Properties.Resources.MiSSklepZbrojeGotowe;

            UstawDomyslnaChmurke(lblZloto, "| Wybierz część pancerza");
        }

        private void OtworzKategorie(string kategoria, List<Zbroja> zbroje)
        {
            obecnaKategoria = kategoria;
            zbrojeWKategorii = zbroje;
            aktualnaStrona = 1;

            if (btnHelmy != null) btnHelmy.Visible = false;
            if (btnNaramienniki != null) btnNaramienniki.Visible = false;
            if (btnKlaty != null) btnKlaty.Visible = false;
            if (btnSpodnie != null) btnSpodnie.Visible = false;
            if (btnButy != null) btnButy.Visible = false;
            if (btnTarcze != null) btnTarcze.Visible = false;

            if (pnlPolkaSklepowa != null) pnlPolkaSklepowa.Visible = true;

            ZaladujKategorie();
        }

        private void ZaladujKategorie()
        {
            this.BackColor = SystemColors.Control;
            this.BackgroundImage = Properties.Resources.MiSSklepZbroje2Gotowe;

            if (pnlPolkaSklepowa == null) return;

            pnlPolkaSklepowa.SuspendLayout();
            pnlPolkaSklepowa.Controls.Clear();

            var zbrojeNaTejStronie = zbrojeWKategorii.Where(z => z.StronaWSklepie == aktualnaStrona).ToList();

            foreach (var zbroja in zbrojeNaTejStronie)
            {
                if (string.IsNullOrEmpty(zbroja.NazwaIkony)) continue;

                PictureBox picPrzedmiot = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Location = new Point(zbroja.SklepX, zbroja.SklepY),
                    Image = (Image)Properties.Resources.ResourceManager.GetObject(zbroja.NazwaIkony),
                    BorderStyle = BorderStyle.None
                };

                picPrzedmiot.MouseEnter += (s, e) =>
                {
                    int cenaFinalna = glowneOkno.Bohater.ObliczCenePoRabacie(zbroja.Cena);
                    lblZloto.Text = $"{zbroja.Nazwa} - {cenaFinalna}G\n" +
                                    $"Obrona (Pancerz): {zbroja.PunktyPancerza}\n" +
                                    $"Wymagany Poziom: {zbroja.WymaganyPoziom}";
                };

                picPrzedmiot.MouseLeave += (s, e) =>
                {
                    UstawDomyslnaChmurke(lblZloto);
                };

                picPrzedmiot.Click += (s, e) =>
                {
                    try
                    {
                        glowneOkno.Bohater.KupPrzedmiot(zbroja);
                        MessageBox.Show($"Kupiłeś: {zbroja.Nazwa}!\nZałożono na postać.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UstawDomyslnaChmurke(lblZloto);
                    }
                    catch (NotEnoughGoldException ex)
                    {
                        MessageBox.Show(ex.Message, "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (RequirementNotMetException ex)
                    {
                        MessageBox.Show(ex.Message, "Za niski poziom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                pnlPolkaSklepowa.Controls.Add(picPrzedmiot);
            }

            pnlPolkaSklepowa.ResumeLayout();

            if (zbrojeWKategorii.Count > 0)
            {
                int maxStrona = zbrojeWKategorii.Max(z => z.StronaWSklepie);
                if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = maxStrona > 1;
            }
            else
            {
                if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = false;
            }
        }

        private void btnNastepnaStrona_Click(object sender, EventArgs e)
        {
            if (zbrojeWKategorii.Count == 0) return;

            int maksymalnaStrona = zbrojeWKategorii.Max(z => z.StronaWSklepie);

            if (aktualnaStrona >= maksymalnaStrona)
            {
                aktualnaStrona = 1;
            }
            else
            {
                aktualnaStrona++;
            }

            ZaladujKategorie();
        }

        private void btnHelmy_Click(object sender, EventArgs e)
        {
            var helmy = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Helm).ToList();
            OtworzKategorie("Hełmy", helmy);
        }

        private void btnNaramienniki_Click(object sender, EventArgs e)
        {
            var naram = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Naramienniki).ToList();
            OtworzKategorie("Naramienniki", naram);
        }

        private void btnKlaty_Click(object sender, EventArgs e)
        {
            var klaty = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Klata).ToList();
            OtworzKategorie("Klaty", klaty);
        }

        private void btnSpodnie_Click(object sender, EventArgs e)
        {
            var spodnie = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Spodnie).ToList();
            OtworzKategorie("Spodnie", spodnie);
        }

        private void btnButy_Click(object sender, EventArgs e)
        {
            var buty = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Buty).ToList();
            OtworzKategorie("Buty", buty);
        }

        private void btnTarcze_Click(object sender, EventArgs e)
        {
            var tarcze = BazaPrzedmiotow.WszystkieZbroje.Where(z => z.TypCzesci == CzescZbroi.Tarcza).ToList();
            OtworzKategorie("Tarcze", tarcze);
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            if (obecnaKategoria == "")
            {
                ObsluzPrzyciskWrot();
            }
            else
            {
                UstawStanGlownegoMenu();
            }
        }
    }
}