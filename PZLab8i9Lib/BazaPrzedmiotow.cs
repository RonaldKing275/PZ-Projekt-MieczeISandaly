using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public static class BazaPrzedmiotow
    {
        public static List<Bron> WszystkieBronie { get; } = new List<Bron>
        {
            // Nazwa, Cena, Dmg, Typ, reqSila, reqZrecznosc
            new Bron("Zardzewiały Miecz", 30, 8, TypBroni.Wrecz, reqSila: 1, reqZrecznosc: 5),
            new Bron("Sztylet Złodzieja", 50, 10, TypBroni.Wrecz, reqSila: 1, reqZrecznosc: 10),
            new Bron("Topór Drwala", 120, 18, TypBroni.Wrecz, reqSila: 15, reqZrecznosc: 1),
            new Bron("Krótki Łuk", 60, 12, TypBroni.Dystansowa, reqSila: 1, reqZrecznosc: 12),
            new Bron("Ciężka Maczuga", 200, 25, TypBroni.Wrecz, reqSila: 25, reqZrecznosc: 1)
        };

        public static List<Zbroja> WszystkieZbroje { get; } = new List<Zbroja>
        {
            // Nazwa, Cena, WymPoziom, Pancerz, Typ
            new Zbroja("Skórzany Hełm", 50, 1, 5, CzescZbroi.Helm),
            new Zbroja("Skórzana Klata", 100, 1, 10, CzescZbroi.Klata),
            new Zbroja("Płytowa Klata", 300, 5, 30, CzescZbroi.Klata),
            new Zbroja("Skórzane Buty", 40, 1, 3, CzescZbroi.Buty)
        };

        public static List<Czar> WszystkieCzary { get; } = new List<Czar>
        {
            // Nazwa, Cena, Dmg, Koszt, reqInt
            new Czar("Magiczny Pocisk", 100, 20, 10, reqInt: 15),
            new Czar("Kula Ognia", 300, 50, 25, reqInt: 30),
            new Czar("Lodowa Włócznia", 450, 80, 40, reqInt: 45),
            new Czar("Burza Piorunów", 800, 150, 60, reqInt: 60)
        };
    }
}