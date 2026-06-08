using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using PZLab8i9Lib;

namespace PZLab8i9
{
    public partial class KosciolControl : UserControl
    {
        private Form1 glowneOkno;
        private static string sciezkaZapisu = "savegame.json";

        public static string SciezkaZapisu
        {
            get => sciezkaZapisu;
        }
        public KosciolControl(Form1 form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            glowneOkno = form;
            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            lblInfo.Text = $"Błogosławieństwo z Tobą, {glowneOkno.Bohater.Imie}.\n" +
                           $"Poziom: {glowneOkno.Bohater.Poziom} | Złoto: {glowneOkno.Bohater.Zloto}G\n" +
                           $"Czy chcesz uwiecznić swoje postępy w księgach?";
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                if (glowneOkno.Bohater.Zloto < 100)
                {
                    MessageBox.Show("Nie masz wystarczająco złota na ofiarę (wymagane 100G)!", "Brak złota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                glowneOkno.Bohater.Zloto -= 100;

                // Zmiana Bohatera w tekst (JSON)
                string jsonString = JsonSerializer.Serialize(glowneOkno.Bohater);

                File.WriteAllText(sciezkaZapisu, jsonString);

                MessageBox.Show("Twoje postępy zostały zapisane przez kapłanów!", "Zapisano grę", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AktualizujWidok();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bogowie się gniewają (błąd zapisu):\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(sciezkaZapisu))
                {
                    string jsonString = File.ReadAllText(sciezkaZapisu);

                    // Odtworzenie obiektu z tekstu i podmiana gracza w głównym oknie
                    glowneOkno.Bohater = JsonSerializer.Deserialize<Gracz>(jsonString);

                    MessageBox.Show("Odtworzono Twoją dawną chwałę!", "Wczytano grę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AktualizujWidok();
                }
                else
                {
                    MessageBox.Show("Nie odnaleziono ksiąg z Twoim zapisem (brak pliku).", "Brak zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Księgi zostały uszkodzone (błąd odczytu):\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnWroc_Click(object sender, EventArgs e)
        {
            glowneOkno.ZmienEkran(new UlicaControl(glowneOkno));
        }
    }
}
