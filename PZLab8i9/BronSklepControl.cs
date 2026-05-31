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
    public partial class BronSklepControl : SklepBazowyControl
    {
        private string obecnaKategoria = "";
        private List<Bron> bronieWKategorii = new List<Bron>();
        private int aktualnaStrona = 1;

        public BronSklepControl(Form1 form) : base(form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            UstawStanGlownegoMenu();
        }

        private void UstawStanGlownegoMenu()
        {
            obecnaKategoria = "";

            btnMiecze.Visible = true;
            btnTopory.Visible = true;
            btnMaczugi.Visible = true;
            btnLuki.Visible = true;

            pnlPolkaSklepowa.Visible = false;
            if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = false;

            this.BackColor = SystemColors.Control;
            this.BackgroundImage = Properties.Resources.MiSSklepBronieGotowe;

            UstawDomyslnaChmurke(lblZloto);
        }

        private void OtworzKategorie(string kategoria, List<Bron> bronie)
        {
            obecnaKategoria = kategoria;
            bronieWKategorii = bronie;
            aktualnaStrona = 1;

            btnMiecze.Visible = false;
            btnTopory.Visible = false;
            btnMaczugi.Visible = false;
            btnLuki.Visible = false;

            pnlPolkaSklepowa.Visible = true;

            ZaladujKategorie();
        }

        private Image SkalujObrazek(Image oryginal, double skala)
        {
            if (oryginal == null) return null;
            int nowaSzerokosc = (int)(oryginal.Width * skala);
            int nowaWysokosc = (int)(oryginal.Height * skala);
            return new Bitmap(oryginal, nowaSzerokosc, nowaWysokosc);
        }

        private void ZaladujKategorie()
        {
            this.BackColor = SystemColors.Control;
            this.BackgroundImage = Properties.Resources.MiSSklepBronie1Gotowe;

            pnlPolkaSklepowa.Controls.Clear();

            var bronieNaTejStronie = bronieWKategorii.Where(b => b.StronaWSklepie == aktualnaStrona).ToList();

            foreach (var bron in bronieNaTejStronie)
            {
                PictureBox picPrzedmiot = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.AutoSize,

                    Location = new Point(bron.SklepX, bron.SklepY),

                    Image = (Image)Properties.Resources.ResourceManager.GetObject(bron.NazwaIkony),

                    BorderStyle = BorderStyle.None
                };

                picPrzedmiot.MouseEnter += (s, e) =>
                {
                    int cenaFinalna = glowneOkno.Bohater.ObliczCenePoRabacie(bron.Cena);
                    lblZloto.Text = $"{bron.Nazwa} - {cenaFinalna}G\n" +
                                    $"Obrażenia: {bron.MinObrazenia} - {bron.MaxObrazenia}\n" +
                                    $"Wymagana Zręczność: {bron.WymaganaZrecznosc} | Siła: {bron.WymaganaSila}";
                };

                picPrzedmiot.MouseLeave += (s, e) =>
                {
                    UstawDomyslnaChmurke(lblZloto);
                };

                picPrzedmiot.Click += (s, e) =>
                {
                    try
                    {
                        glowneOkno.Bohater.KupPrzedmiot(bron);
                        MessageBox.Show($"Kupiłeś: {bron.Nazwa}!\nZałożono automatycznie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UstawDomyslnaChmurke(lblZloto);
                    }
                    catch (NotEnoughGoldException ex)
                    {
                        MessageBox.Show(ex.Message, "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (RequirementNotMetException ex)
                    {
                        MessageBox.Show(ex.Message, "Jesteś za słaby!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                pnlPolkaSklepowa.Controls.Add(picPrzedmiot);
            }

            if (bronieWKategorii.Count > 0)
            {
                int maxStrona = bronieWKategorii.Max(b => b.StronaWSklepie);
                if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = maxStrona > 1;
            }
            else
            {
                if (btnNastepnaStrona != null) btnNastepnaStrona.Visible = false;
            }
        }

        private void btnNastepnaStrona_Click(object sender, EventArgs e)
        {
            if (bronieWKategorii.Count == 0) return;

            int maksymalnaStrona = bronieWKategorii.Max(b => b.StronaWSklepie);

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

        private void btnMiecze_Click(object sender, EventArgs e)
        {
            var miecze = BazaPrzedmiotow.WszystkieBronie.Where(b => b.Typ == TypBroni.Miecze).ToList();
            OtworzKategorie("Miecze", miecze);
        }

        private void btnTopory_Click(object sender, EventArgs e)
        {
            var topory = BazaPrzedmiotow.WszystkieBronie.Where(b => b.Typ == TypBroni.Topory).ToList();
            OtworzKategorie("Topory", topory);
        }

        private void btnMaczugi_Click(object sender, EventArgs e)
        {
            var maczugi = BazaPrzedmiotow.WszystkieBronie.Where(b => b.Typ == TypBroni.Maczugi).ToList();
            OtworzKategorie("Maczugi", maczugi);
        }

        private void btnLuki_Click(object sender, EventArgs e)
        {
            var luki = BazaPrzedmiotow.WszystkieBronie.Where(b => b.Typ == TypBroni.Luki).ToList();
            OtworzKategorie("Łuki", luki);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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