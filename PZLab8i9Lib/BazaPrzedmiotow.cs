using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public static class BazaPrzedmiotow
    {
        public static List<Bron> WszystkieBronie { get; } = new List<Bron>
        {
            //      Nazwa,      Cena,  MinDmg, Typ,        RodzajZasiegu, Image,     reqSila,    reqZrecznosc
            // Miecze
            // Strona 1:
            new Bron("Dagger", 200, 3, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz1", strona:1, posX:46, posY:64, reqSila: 0, reqZrecznosc: 3),
            new Bron("Shortsword", 400, 4, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz2", strona:1, posX:139, posY:34, reqSila: 0, reqZrecznosc: 6),
            new Bron("Dirk", 600, 5, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz3", strona:1, posX:241, posY:17, reqSila: 0, reqZrecznosc: 9),
            new Bron("Gladius", 800, 6, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz4", strona:1, posX:349, posY:17, reqSila: 0, reqZrecznosc: 12),

            new Bron("Bastard Sword", 2000, 9, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz7", strona:1, posX:33, posY:215, reqSila: 0, reqZrecznosc: 21),
            new Bron("Longsword", 2500, 10, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz8", strona:1, posX:127, posY:215, reqSila: 0, reqZrecznosc: 24),
            new Bron("Broadsword", 1100, 7, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz5", strona:1, posX:231, posY:213, reqSila: 0, reqZrecznosc: 15),
            new Bron("Claymore", 1500, 8, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz6", strona:1, posX:323, posY:213, reqSila: 0, reqZrecznosc: 18),
            
            // Strona 2:
            new Bron("Knight Sword", 3000, 12, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz9", strona:2, posX:5, posY:83, reqSila: 0, reqZrecznosc: 27),
            new Bron("Silver Longsword", 3500, 14, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz10", strona:2, posX:65, posY:91, reqSila: 0, reqZrecznosc: 30),
            new Bron("Heartblade", 4000, 16, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz11", strona:2, posX:129, posY:83, reqSila: 0, reqZrecznosc: 33),
            new Bron("Crystal Sword", 4500, 18, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz12", strona:2, posX:199, posY:83, reqSila: 0, reqZrecznosc: 36),
            new Bron("Rapier", 5000, 19, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz13", strona:2, posX:280, posY:75, reqSila: 0, reqZrecznosc: 39),
            new Bron("Cutlas", 5500, 20, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz14", strona:2, posX:338, posY:83, reqSila: 0, reqZrecznosc: 42),

            // Strona 3:
            new Bron("Scimitar", 6000, 21, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz15", strona:3, posX:14, posY:52, reqSila: 0, reqZrecznosc: 45),
            new Bron("Raj Scimitar", 6500, 22, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz16", strona:3, posX:101, posY:63, reqSila: 0, reqZrecznosc: 48),
            new Bron("Katana", 7000, 23, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz17", strona:3, posX:171, posY:56, reqSila: 0, reqZrecznosc: 51),
            new Bron("Ancestor Katana", 7500, 24, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz18", strona:3, posX:226, posY:42, reqSila: 0, reqZrecznosc: 54),
            new Bron("Kensai Spirit", 8000, 25, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz19", strona:3, posX:282, posY:42, reqSila: 0, reqZrecznosc: 57),
            new Bron("Daikatana", 8500, 26, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz20", strona:3, posX:345, posY:42, reqSila: 0, reqZrecznosc: 60),

            //// Topory
            //// Strona 1:
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),

            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Cleaver", 200, 3, TypBroni.Topory, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //// Strona 2:


            //// Maczugi
            //// Strona 1:
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),

            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //new Bron("Blackjack", 200, 3, TypBroni.Maczugi, RodzajZasiegu.Wrecz, reqSila: 3, reqZrecznosc: 0),
            //// Strona 2:


            //// Łuki
            //// Strona 1:
            //new Bron("Iron Slingshot", 250, 5, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 6),
            //new Bron("Oak Slingshot", 450, 6, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 9),
            //new Bron("Shuriken", 750, 7, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 12),
            //new Bron("Yew Bow", 950, 8, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 15),

            //new Bron("Hunter's Bow", 1400, 9, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 18),
            //new Bron("Tracker's Bow", 1800, 10, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 21),
            //new Bron("Oak Longbow", 2300, 11, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 24),
            //new Bron("Steel Longbow", 2900, 12, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 27),
            //new Bron("Reinforced Longbow", 3600, 13, TypBroni.Luki, RodzajZasiegu.Dystansowa, reqSila: 0, reqZrecznosc: 30),
            // Strona 2:
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