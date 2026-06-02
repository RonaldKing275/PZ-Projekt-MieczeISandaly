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

            // Topory
            // Strona 1:
            new Bron("Cleaver", 200, 4, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor1", strona:1, posX:14, posY:63, reqSila: 3, reqZrecznosc: 0),
            new Bron("Hand axe", 400, 5, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor2", strona:1, posX:88, posY:57, reqSila: 6, reqZrecznosc: 0),
            new Bron("Bronze axe", 600, 6, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:1, posX:164, posY:49, reqSila: 9, reqZrecznosc: 0),
            new Bron("Hatchet", 800, 8, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor4", strona:1, posX:246, posY:57, reqSila: 12, reqZrecznosc: 0),
            new Bron("Warrior axe", 1100, 10, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor5", strona:1, posX:299, posY:26, reqSila: 15, reqZrecznosc: 0),

            new Bron("Berserker axe", 1500, 15, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor6", strona:1, posX:14, posY:225, reqSila: 18, reqZrecznosc: 0),
            new Bron("Greensteel axe", 2000, 18, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor7", strona:1, posX:130, posY:185, reqSila: 21, reqZrecznosc: 0),
            new Bron("Madman's cleaver", 2500, 20, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor8", strona:1, posX:218, posY:238, reqSila: 24, reqZrecznosc: 0),
            new Bron("Greataxe", 3000, 25, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor9", strona:1, posX:312, posY:225, reqSila: 27, reqZrecznosc: 0),
            
            // Strona 2:
            new Bron("Blacksteel battleaxe", 4500, 40, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor10", strona:2, posX:14, posY:63, reqSila: 36, reqZrecznosc: 0),
            new Bron("Steel battleaxe", 4000, 35, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor11", strona:2, posX:14, posY:63, reqSila: 33, reqZrecznosc: 0),
            new Bron("Ramhead sickle", 6000, 60, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor12", strona:2, posX:14, posY:63, reqSila: 45, reqZrecznosc: 0),
            new Bron("Reaper scythe", 8500, 110, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor13", strona:2, posX:14, posY:63, reqSila: 60, reqZrecznosc: 0),
            new Bron("Ogre battleaxe", 5000, 45, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor14", strona:2, posX:14, posY:63, reqSila: 39, reqZrecznosc: 0),
            new Bron("Iron greataxe", 3500, 30, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor15", strona:3, posX:14, posY:63, reqSila: 30, reqZrecznosc: 0),
            
            // Strona 3:
            new Bron("Hunter spear", 5500, 50, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor16", strona:3, posX:14, posY:63, reqSila: 42, reqZrecznosc: 0),
            new Bron("Halberd", 6500, 70, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor17", strona:3, posX:14, posY:63, reqSila: 48, reqZrecznosc: 0),
            new Bron("Awl Pike", 7000, 80, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor18", strona:3, posX:14, posY:63, reqSila: 51, reqZrecznosc: 0),
            new Bron("Poleaxe", 7500, 90, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor19", strona:3, posX:14, posY:63, reqSila: 54, reqZrecznosc: 0),
            new Bron("Pilum", 8000, 100, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor20", strona:3, posX:14, posY:63, reqSila: 57, reqZrecznosc: 0),


            // Maczugi
            // Strona 1:
            new Bron("Blackjack", 200, 4, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga1", strona:1, posX:14, posY:63, reqSila: 3, reqZrecznosc: 0),
            new Bron("Hammer", 400, 5, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga2", strona:1, posX:14, posY:63, reqSila: 6, reqZrecznosc: 0),
            new Bron("Knuckle Duster", 600, 8, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga3", strona:1, posX:14, posY:63, reqSila: 9, reqZrecznosc: 0),
            new Bron("Wooden club", 800, 10, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga4", strona:1, posX:14, posY:63, reqSila: 12, reqZrecznosc: 0),

            new Bron("Iron Mace", 1100, 15, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga5", strona:1, posX:14, posY:63, reqSila: 15, reqZrecznosc: 0),
            new Bron("Steel Mace", 1500, 20, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga6", strona:1, posX:14, posY:63, reqSila: 18, reqZrecznosc: 0),
            new Bron("Spiked Mace", 2000, 25, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:14, posY:63, reqSila: 21, reqZrecznosc: 0),
            new Bron("Warhammer", 2500, 30, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga8", strona:1, posX:14, posY:63, reqSila: 24, reqZrecznosc: 0),

            // Strona 2:
            new Bron("Sledgehammer", 5000, 60, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga9", strona:2, posX:14, posY:63, reqSila: 39, reqZrecznosc: 0),
            
            new Bron("Morning Star", 3000, 35, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga10", strona:2, posX:14, posY:63, reqSila: 27, reqZrecznosc: 0),
            new Bron("Studded Mace", 3500, 40, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga11", strona:2, posX:14, posY:63, reqSila: 30, reqZrecznosc: 0),
            new Bron("Maul", 4000, 45, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga12", strona:2, posX:14, posY:63, reqSila: 33, reqZrecznosc: 0),
            new Bron("Spiked Maul", 4500, 50, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga13", strona:2, posX:14, posY:63, reqSila: 36, reqZrecznosc: 0),

            // Strona 3:
            new Bron("Claw Hammer", 5500, 70, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga14", strona:3, posX:14, posY:63, reqSila: 42, reqZrecznosc: 0),
            
            new Bron("Imperial Warhammer", 6500, 90, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga15", strona:3, posX:14, posY:63, reqSila: 48, reqZrecznosc: 0),
            new Bron("Heavy Mallet", 6000, 80, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga16", strona:3, posX:14, posY:63, reqSila: 45, reqZrecznosc: 0),
            new Bron("Bonecrusher Cudgel", 7000, 100, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga17", strona:3, posX:14, posY:63, reqSila: 51, reqZrecznosc: 0),
            new Bron("Quake Staff", 7500, 120, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga19", strona:3, posX:14, posY:63, reqSila: 54, reqZrecznosc: 0),
            new Bron("Dual Maul", 8000, 160, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga19", strona:3, posX:14, posY:63, reqSila: 60, reqZrecznosc: 0),

            // Łuki
            // Strona 1:
            new Bron("Iron Slingshot", 200, 5, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk1", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 6),
            new Bron("Oak Slingshot", 400, 6, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk2", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 9),
            new Bron("Shuriken", 600, 7, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk3", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 12),
            new Bron("Yew Bow", 800, 8, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 15),

            new Bron("Hunter's Bow", 1100, 9, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk5", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 18),
            new Bron("Tracker's Bow", 1500, 10, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk6", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 21),
            new Bron("Oak Longbow", 2000, 11, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk7", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 24),
            new Bron("Steel Longbow", 2500, 12, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk8", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 27),
            new Bron("Reinforced Longbow", 3000, 13, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk9", strona:1, posX:14, posY:63, reqSila: 0, reqZrecznosc: 30),

            // Strona 2:
            new Bron("Crabclaw Bow", 3500, 14, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk10", strona:2, posX:14, posY:63, reqSila: 0, reqZrecznosc: 33),
            new Bron("Batwing Bow", 4000, 15, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk11", strona:2, posX:14, posY:63, reqSila: 0, reqZrecznosc: 36),
            new Bron("Kraken Bow", 4500, 16, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk12", strona:2, posX:14, posY:63, reqSila: 0, reqZrecznosc: 39),

            new Bron("Wyvern Bow", 5000, 17, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk13", strona:2, posX:14, posY:63, reqSila: 0, reqZrecznosc: 42),
            new Bron("Seer's Bow", 5500, 18, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk14", strona:2, posX:14, posY:63, reqSila: 0, reqZrecznosc: 45),

            // Strona 3:
            new Bron("Blaze Bow", 6000, 19, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk15", strona:3, posX:14, posY:63, reqSila: 0, reqZrecznosc: 48),
            new Bron("Titanium Bow", 6500, 20, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk16", strona:3, posX:14, posY:63, reqSila: 0, reqZrecznosc: 51),

            new Bron("Knight Crossbow", 7000, 21, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk17", strona:3, posX:14, posY:63, reqSila: 0, reqZrecznosc: 54),
            new Bron("Falcon Crossbow", 7500, 22, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk18", strona:3, posX:14, posY:63, reqSila: 0, reqZrecznosc: 57),
            new Bron("Doombolt Crossbow", 8000, 23, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk19", strona:3, posX:14, posY:63, reqSila: 0, reqZrecznosc: 60),
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