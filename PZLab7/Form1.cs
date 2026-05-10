using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PZLab7Lib;

namespace PZLab7
{
    public partial class Form1 : Form
    {
        private GildiaMagow gildia;

        public Form1()
        {
            InitializeComponent();
            ZaladujDaneTestowe();
        }

        private void ZaladujDaneTestowe()
        {
            gildia = new GildiaMagow();

            // Ofensywne
            Czar kulaOgnia = new Czar("Kula Ognia", TypCzaru.Ofensywne, 20, 5, 100);
            Czar pocisk = new Czar("Magiczny Pocisk", TypCzaru.Ofensywne, 5, 1, 15);
            Czar zamiec = new Czar("Zamieć", TypCzaru.Ofensywne, 45, 15, 200);
            Czar blyskawica = new Czar("Łańcuch Błyskawic", TypCzaru.Ofensywne, 30, 8, 150);

            // Defensywne
            Czar tarcza = new Czar("Tarcza Many", TypCzaru.Defensywne, 30, 10, 50);
            Czar niewidzialnosc = new Czar("Niewidzialność", TypCzaru.Defensywne, 60, 120, 0);
            Czar pancerzMrozu = new Czar("Pancerz Mrozu", TypCzaru.Defensywne, 25, 15, 40);

            // Uzdrawiające
            Czar leczenie = new Czar("Mniejsze Leczenie", TypCzaru.Uzdrawiajace, 15, 3, 40);
            Czar wskrzeszenie = new Czar("Ostatnie Tchnienie", TypCzaru.Uzdrawiajace, 100, 60, 999);
            Czar regeneracja = new Czar("Regeneracja Many i HP", TypCzaru.Uzdrawiajace, 40, 10, 100);

            // MAGOWIE
            Mag gandalf = new Mag("Gandalf", 99, 20, 15, 100, 1000, 500)
            { PunktyDoswiadczenia = 99999, OdpornoscFizyczna = 50, OdpornoscOgien = 80, OdpornoscMroz = 80 };
            gandalf.Ksiega.AddRange(new[] { kulaOgnia, tarcza, leczenie, pocisk, niewidzialnosc });

            Mag saruman = new Mag("Saruman", 98, 15, 15, 95, 900, 600)
            { PunktyDoswiadczenia = 88000, OdpornoscFizyczna = 40, OdpornoscOgien = 70, OdpornoscTrucizna = 100 };
            saruman.Ksiega.AddRange(new[] { kulaOgnia, tarcza, wskrzeszenie, pocisk, zamiec });

            Mag yennefer = new Mag("Yennefer", 85, 12, 20, 90, 600, 800)
            { PunktyDoswiadczenia = 75000, OdpornoscMroz = 80, OdpornoscOgien = 60 };
            yennefer.Ksiega.AddRange(new[] { blyskawica, tarcza, niewidzialnosc, regeneracja });

            Mag voldemort = new Mag("Voldemort", 85, 8, 40, 85, 700, 500)
            // Ten sam level co Yen, ale więcej expa
            { PunktyDoswiadczenia = 82000, OdpornoscFizyczna = 20, OdpornoscTrucizna = 100 };
            voldemort.Ksiega.AddRange(new[] { blyskawica, zamiec, pancerzMrozu });

            Mag triss = new Mag("Triss", 70, 10, 25, 80, 500, 600)
            { PunktyDoswiadczenia = 55000, OdpornoscOgien = 90 };
            triss.Ksiega.AddRange(new[] { kulaOgnia, leczenie, pancerzMrozu });

            Mag harry = new Mag("Harry", 15, 10, 30, 25, 200, 150)
            { PunktyDoswiadczenia = 4500, OdpornoscFizyczna = 10, OdpornoscMroz = 5 };
            harry.Ksiega.AddRange(new[] { pocisk, tarcza, niewidzialnosc });

            Mag rincewind = new Mag("Rincewind", 2, 5, 99, 1, 50, 0)
            // Zemdlony + nie zna czarów
            { AktualnePunktyZycia = 5, OdpornoscFizyczna = 0, AktualnePunktyMany = 0 };

            gildia.PrzyjmijMaga(gandalf);
            gildia.PrzyjmijMaga(saruman);
            gildia.PrzyjmijMaga(yennefer);
            gildia.PrzyjmijMaga(voldemort);
            gildia.PrzyjmijMaga(triss);
            gildia.PrzyjmijMaga(harry);
            gildia.PrzyjmijMaga(rincewind);
        }

        private void Wypisz<T>(IEnumerable<T> kolekcja)
        {
            lstWyniki.Items.Clear(); // Wyczyszczenie pola z wynikami

            if (!kolekcja.Any())
            {
                lstWyniki.Items.Add("Brak wyników do wyświetlenia.");
                return;
            }

            foreach (var item in kolekcja)
            {
                lstWyniki.Items.Add(item.ToString());
                lstWyniki.Items.Add(""); // Pusta linia dla czytelności
            }
        }

        private void WypiszPojedyncza(object wartosc)
        {
            lstWyniki.Items.Clear();
            lstWyniki.Items.Add(wartosc.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzWszystkichMagow());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int minLvl = int.Parse(textBox1.Text);
            Wypisz(gildia.PobierzDoswiadczonychMagow(minLvl));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int maxLvl = int.Parse(textBox2.Text);
            Wypisz(gildia.PobierzNajbardziejUzdolnionych(maxLvl));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WypiszPojedyncza(gildia.ObliczWspolnyPotencjal());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int minCzarow = int.Parse(textBox3.Text);
            Wypisz(gildia.PobierzNajwiekszyArsenal(minCzarow));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzWszechstronnych());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzPrymusa());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzWszystkieCzaryBezPowtorzen());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzCzaryDanegoTypu(TypCzaru.Ofensywne));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.PobierzCzaryMaga("Gandalf", TypCzaru.Ofensywne));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.ZliczCzaryGildiiWgTypu());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Wypisz(gildia.ZliczCzaryMagaWgTypu("Gandalf"));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int pomin = int.Parse(textBox4.Text);
            int pobierz = int.Parse(textBox5.Text);
            Wypisz(gildia.PobierzNajpotezniejszych(pomin, pobierz));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            WypiszPojedyncza(gildia.CzyWszyscyWypoczeci() 
                ? "Tak, pełne HP i Mana!" : "Nie, ktoś musi odpocząć.");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            WypiszPojedyncza(gildia.CzyKtosZemdlal() 
                ? "Tak! Medyk!" : "Nie, wszyscy przytomni.");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int minLvl = int.Parse(textBox6.Text);
            Wypisz(gildia.WytypujNaMisje(minLvl));
        }
    }
}