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
            new Bron("Dagger",      200, 3, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz1", strona:1, posX:46, posY:64, reqSila: 0, reqZrecznosc: 3),
            new Bron("Shortsword",  400, 4, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz2", strona:1, posX:139, posY:34, reqSila: 0, reqZrecznosc: 6),
            new Bron("Dirk",        600, 5, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz3", strona:1, posX:241, posY:17, reqSila: 0, reqZrecznosc: 9),
            new Bron("Gladius",     800, 6, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz4", strona:1, posX:349, posY:17, reqSila: 0, reqZrecznosc: 12),

            new Bron("Bastard Sword",   2000, 9, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz7", strona:1, posX:33, posY:215, reqSila: 0, reqZrecznosc: 21),
            new Bron("Longsword",      2500, 10, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz8", strona:1, posX:127, posY:215, reqSila: 0, reqZrecznosc: 24),
            new Bron("Broadsword",      1100, 7, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz5", strona:1, posX:231, posY:213, reqSila: 0, reqZrecznosc: 15),
            new Bron("Claymore",        1500, 8, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz6", strona:1, posX:323, posY:213, reqSila: 0, reqZrecznosc: 18),
            
            // Strona 2:
            new Bron("Knight Sword",    3000, 12, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz9", strona:2, posX:5, posY:83, reqSila: 0, reqZrecznosc: 27),
            new Bron("Silver Longsword",3500, 14, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz10", strona:2, posX:65, posY:91, reqSila: 0, reqZrecznosc: 30),
            new Bron("Heartblade",      4000, 16, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz11", strona:2, posX:129, posY:83, reqSila: 0, reqZrecznosc: 33),
            new Bron("Crystal Sword",   4500, 18, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz12", strona:2, posX:199, posY:83, reqSila: 0, reqZrecznosc: 36),
            new Bron("Rapier",          5000, 19, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz13", strona:2, posX:280, posY:75, reqSila: 0, reqZrecznosc: 39),
            new Bron("Cutlas",          5500, 20, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz14", strona:2, posX:338, posY:83, reqSila: 0, reqZrecznosc: 42),

            // Strona 3:
            new Bron("Scimitar",        6000, 21, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz15", strona:3, posX:14, posY:52, reqSila: 0, reqZrecznosc: 45),
            new Bron("Raj Scimitar",    6500, 22, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz16", strona:3, posX:101, posY:63, reqSila: 0, reqZrecznosc: 48),
            new Bron("Katana",          7000, 23, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz17", strona:3, posX:171, posY:56, reqSila: 0, reqZrecznosc: 51),
            new Bron("Ancestor Katana", 7500, 24, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz18", strona:3, posX:226, posY:42, reqSila: 0, reqZrecznosc: 54),
            new Bron("Kensai Spirit",   8000, 25, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz19", strona:3, posX:282, posY:42, reqSila: 0, reqZrecznosc: 57),
            new Bron("Daikatana",       8500, 26, TypBroni.Miecze, RodzajZasiegu.Wrecz, "miecz20", strona:3, posX:345, posY:42, reqSila: 0, reqZrecznosc: 60),

            // Topory
            // Strona 1:
            new Bron("Cleaver",         200, 4, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor1", strona:1, posX:14, posY:63, reqSila: 3, reqZrecznosc: 0),
            new Bron("Hand axe",        400, 5, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor2", strona:1, posX:88, posY:57, reqSila: 6, reqZrecznosc: 0),
            new Bron("Bronze axe",      600, 6, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:1, posX:164, posY:49, reqSila: 9, reqZrecznosc: 0),
            new Bron("Hatchet",         800, 8, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor4", strona:1, posX:246, posY:57, reqSila: 12, reqZrecznosc: 0),
            new Bron("Warrior axe",   1100, 10, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor5", strona:1, posX:299, posY:26, reqSila: 15, reqZrecznosc: 0),

            new Bron("Berserker axe",    1500, 15, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor6", strona:1, posX:14, posY:225, reqSila: 18, reqZrecznosc: 0),
            new Bron("Greensteel axe",   2000, 18, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor7", strona:1, posX:130, posY:185, reqSila: 21, reqZrecznosc: 0),
            new Bron("Madman's cleaver", 2500, 20, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor8", strona:1, posX:218, posY:238, reqSila: 24, reqZrecznosc: 0),
            new Bron("Greataxe",         3000, 25, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor9", strona:1, posX:312, posY:225, reqSila: 27, reqZrecznosc: 0),
            
            // Strona 2:
            new Bron("Blacksteel battleaxe", 4500, 40, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:33, posY:46, reqSila: 36, reqZrecznosc: 0),
            new Bron("Steel battleaxe",      4000, 35, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:129, posY:46, reqSila: 33, reqZrecznosc: 0),
            new Bron("Ramhead sickle",       6000, 60, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:223, posY:46, reqSila: 45, reqZrecznosc: 0),
            new Bron("Reaper scythe",       8500, 110, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:314, posY:46, reqSila: 60, reqZrecznosc: 0),
            
            new Bron("Ogre battleaxe", 5000, 45, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:33, posY:237, reqSila: 39, reqZrecznosc: 0),
            new Bron("Iron greataxe",  3500, 30, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:129, posY:237, reqSila: 30, reqZrecznosc: 0),
            new Bron("Hunter spear",   5500, 50, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:223, posY:237, reqSila: 42, reqZrecznosc: 0),
            new Bron("Halberd",        6500, 70, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:2, posX:314, posY:237, reqSila: 48, reqZrecznosc: 0),
            
            // Strona 3:
            new Bron("Awl Pike", 7000, 80, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:3, posX:33, posY:46, reqSila: 51, reqZrecznosc: 0),
            new Bron("Poleaxe",  7500, 90, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:3, posX:129, posY:46, reqSila: 54, reqZrecznosc: 0),
            new Bron("Pilum",   8000, 100, TypBroni.Topory, RodzajZasiegu.Wrecz, "topor3", strona:3, posX:223, posY:46, reqSila: 57, reqZrecznosc: 0),


            // Maczugi
            // Strona 1:
            new Bron("Blackjack",       200, 4, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:33, posY:46, reqSila: 3, reqZrecznosc: 0),
            new Bron("Hammer",          400, 5, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:129, posY:46, reqSila: 6, reqZrecznosc: 0),
            new Bron("Knuckle Duster",  600, 8, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:223, posY:46, reqSila: 9, reqZrecznosc: 0),
            new Bron("Wooden club",    800, 10, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:314, posY:46, reqSila: 12, reqZrecznosc: 0),

            new Bron("Iron Mace",   1100, 15, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:33, posY:237, reqSila: 15, reqZrecznosc: 0),
            new Bron("Steel Mace",  1500, 20, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:129, posY:237, reqSila: 18, reqZrecznosc: 0),
            new Bron("Spiked Mace", 2000, 25, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:223, posY:237, reqSila: 21, reqZrecznosc: 0),
            new Bron("Warhammer",   2500, 30, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:1, posX:314, posY:237, reqSila: 24, reqZrecznosc: 0),

            // Strona 2:
            new Bron("Sledgehammer", 5000, 60, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:33, posY:46, reqSila: 39, reqZrecznosc: 0),
            new Bron("Morning Star", 3000, 35, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:129, posY:46, reqSila: 27, reqZrecznosc: 0),
            new Bron("Studded Mace", 3500, 40, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:223, posY:46, reqSila: 30, reqZrecznosc: 0),
            new Bron("Maul",         4000, 45, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:314, posY:46, reqSila: 33, reqZrecznosc: 0),

            new Bron("Spiked Maul",         4500, 50, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:33, posY:237, reqSila: 36, reqZrecznosc: 0),
            new Bron("Claw Hammer",         5500, 70, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:129, posY:237, reqSila: 42, reqZrecznosc: 0),
            new Bron("Imperial Warhammer",  6500, 90, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:223, posY:237, reqSila: 48, reqZrecznosc: 0),
            new Bron("Heavy Mallet",        6000, 80, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:2, posX:314, posY:237, reqSila: 45, reqZrecznosc: 0),

            // Strona 3:
            new Bron("Bonecrusher Cudgel",   7000, 100, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:3, posX:33, posY:46, reqSila: 51, reqZrecznosc: 0),
            new Bron("Quake Staff",          7500, 120, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:3, posX:129, posY:46, reqSila: 54, reqZrecznosc: 0),
            new Bron("Dual Maul",            8000, 160, TypBroni.Maczugi, RodzajZasiegu.Wrecz, "maczuga7", strona:3, posX:223, posY:46, reqSila: 60, reqZrecznosc: 0),

            // Łuki
            // Strona 1:
            new Bron("Iron Slingshot",  200, 5, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:33, posY:46, reqSila: 0, reqZrecznosc: 6),
            new Bron("Oak Slingshot",   400, 6, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:129, posY:46, reqSila: 0, reqZrecznosc: 9),
            new Bron("Shuriken",        600, 7, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:223, posY:46, reqSila: 0, reqZrecznosc: 12),
            new Bron("Yew Bow",         800, 8, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:314, posY:46, reqSila: 0, reqZrecznosc: 15),

            new Bron("Hunter's Bow",        1100, 9, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:33, posY:237, reqSila: 0, reqZrecznosc: 18),
            new Bron("Tracker's Bow",       1500, 10, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:129, posY:237, reqSila: 0, reqZrecznosc: 21),
            new Bron("Oak Longbow",         2000, 11, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:223, posY:237, reqSila: 0, reqZrecznosc: 24),
            new Bron("Steel Longbow",       2500, 12, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:1, posX:314, posY:237, reqSila: 0, reqZrecznosc: 27),
            
            // Strona 2:
            new Bron("Reinforced Longbow",  3000, 13, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:33, posY:46, reqSila: 0, reqZrecznosc: 30),
            new Bron("Crabclaw Bow",        3500, 14, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:129, posY:46, reqSila: 0, reqZrecznosc: 33),
            new Bron("Batwing Bow",         4000, 15, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:223, posY:46, reqSila: 0, reqZrecznosc: 36),
            new Bron("Kraken Bow",          4500, 16, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:314, posY:46, reqSila: 0, reqZrecznosc: 39),

            new Bron("Wyvern Bow",      5000, 17, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:33, posY:237, reqSila: 0, reqZrecznosc: 42),
            new Bron("Seer's Bow",      5500, 18, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:129, posY:237, reqSila: 0, reqZrecznosc: 45),
            new Bron("Blaze Bow",       6000, 19, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:223, posY:237, reqSila: 0, reqZrecznosc: 48),
            new Bron("Titanium Bow",    6500, 20, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:2, posX:314, posY:237, reqSila: 0, reqZrecznosc: 51),

            // Strona 3:
            new Bron("Knight Crossbow",     7000, 21, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:3, posX:33, posY:46, reqSila: 0, reqZrecznosc: 54),
            new Bron("Falcon Crossbow",     7500, 22, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:3, posX:129, posY:46, reqSila: 0, reqZrecznosc: 57),
            new Bron("Doombolt Crossbow",   8000, 23, TypBroni.Luki, RodzajZasiegu.Dystansowa, "luk4", strona:3, posX:223, posY:46, reqSila: 0, reqZrecznosc: 60),
        };

        public static List<Zbroja> WszystkieZbroje { get; } = new List<Zbroja>
        {
            //            Nazwa,   Cena, Lvl, Pancerz,Typ,       nazwaPng,strona,posX,posY
            // Ceny: 200, 400, 600, 800, 1100, 1500, 2000, 2500, 3000, 3500 itd..
            // Helm:
            // Strona 1:
            new Zbroja("Peasant helmet", 200, 1, 20, CzescZbroi.Helm, "helm4", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse helmet", 400, 1, 30, CzescZbroi.Helm, "helm4", strona:1, posX:161, posY:22),
            new Zbroja("Brigand helmet", 600, 1, 40, CzescZbroi.Helm, "helm4", strona:1, posX:301, posY:22),

            new Zbroja("Militia helmet", 800, 6, 50, CzescZbroi.Helm, "helm4", strona:1, posX:26, posY:174),
            new Zbroja("Veteran helmet", 1100, 6, 60, CzescZbroi.Helm, "helm4", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite helmet", 1500, 12, 70, CzescZbroi.Helm, "helm4", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler helmet", 2000, 12, 80, CzescZbroi.Helm, "helm4", strona:1, posX:26, posY:309),
            new Zbroja("Retarius helmet", 2500, 12, 90, CzescZbroi.Helm, "helm4", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon helmet", 3000, 18, 100, CzescZbroi.Helm, "helm4", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion helmet", 3500, 18, 110, CzescZbroi.Helm, "helm4", strona:2, posX:26, posY:22),
            new Zbroja("Warlord helmet", 4000, 18, 120, CzescZbroi.Helm, "helm4", strona:2, posX:161, posY:22),
            new Zbroja("Centurion helmet", 4500, 24, 130, CzescZbroi.Helm, "helm4", strona:2, posX:301, posY:22),

            new Zbroja("Knight helmet", 5000, 24, 140, CzescZbroi.Helm, "helm4", strona:2, posX:26, posY:174),
            new Zbroja("Paladin helmet", 5500, 24, 150, CzescZbroi.Helm, "helm4", strona:2, posX:161, posY:174),
            new Zbroja("Templar helmet", 6000, 30, 160, CzescZbroi.Helm, "helm4", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier helmet", 6500, 30, 170, CzescZbroi.Helm, "helm4", strona:2, posX:26, posY:309),
            new Zbroja("Crusader helmet", 7500, 30, 180, CzescZbroi.Helm, "helm4", strona:2, posX:161, posY:309),
            new Zbroja("Avenger helmet", 8000, 36, 190, CzescZbroi.Helm, "helm4", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal helmet", 8500, 36, 200, CzescZbroi.Helm, "helm4", strona:3, posX:26, posY:22),
            new Zbroja("Samurai helmet", 9000, 36, 210, CzescZbroi.Helm, "helm4", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate helmet", 9500, 42, 220, CzescZbroi.Helm, "helm4", strona:3, posX:301, posY:22),


            new Zbroja("Conquerer helmet", 10000, 42, 230, CzescZbroi.Helm, "helm4", strona:3, posX:26, posY:309),
            new Zbroja("Automaton helmet", 10500, 42, 240, CzescZbroi.Helm, "helm4", strona:3, posX:161, posY:309),
            new Zbroja("Champions helmet", 11000, 48, 250, CzescZbroi.Helm, "helm4", strona:3, posX:301, posY:309),

            // Naramienniki:
            // Strona 1:
            new Zbroja("Peasant shoulderguard", 200, 1, 16, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse shoulderguard", 400, 1, 24, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:161, posY:22),
            new Zbroja("Brigand shoulderguard", 600, 1, 32, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:301, posY:22),

            new Zbroja("Militia shoulderguard", 800, 6, 40, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:26, posY:174),
            new Zbroja("Veteran shoulderguard", 1100, 6, 48, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite shoulderguard", 1500, 12, 56, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler shoulderguard", 2000, 12, 64, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:26, posY:309),
            new Zbroja("Retarius shoulderguard", 2500, 12, 72, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon shoulderguard", 3000, 18, 80, CzescZbroi.Naramienniki, "naramienniki12", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion shoulderguard", 3500, 18, 88, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:26, posY:22),
            new Zbroja("Warlord shoulderguard", 4000, 18, 96, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:161, posY:22),
            new Zbroja("Centurion shoulderguard", 4500, 24, 104, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:301, posY:22),

            new Zbroja("Knight shoulderguard", 5000, 24, 112, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:26, posY:174),
            new Zbroja("Paladin shoulderguard", 5500, 24, 120, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:161, posY:174),
            new Zbroja("Templar shoulderguard", 6000, 30, 128, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier shoulderguard", 6500, 30, 136, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:26, posY:309),
            new Zbroja("Crusader shoulderguard", 7500, 30, 144, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:161, posY:309),
            new Zbroja("Avenger shoulderguard", 8000, 36, 152, CzescZbroi.Naramienniki, "naramienniki12", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal shoulderguard", 8500, 36, 160, CzescZbroi.Naramienniki, "naramienniki12", strona:3, posX:26, posY:22),
            new Zbroja("Samurai shoulderguard", 9000, 36, 168, CzescZbroi.Naramienniki, "naramienniki12", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate shoulderguard", 9500, 42, 176, CzescZbroi.Naramienniki, "naramienniki12", strona:3, posX:301, posY:22),

            new Zbroja("Conquerer shoulderguard", 10000, 42, 184, CzescZbroi.Naramienniki, "naramienniki12", strona:3, posX:26, posY:309),
            new Zbroja("Automaton shoulderguard", 10500, 42, 192, CzescZbroi.Naramienniki, "naramienniki12", strona:3, posX:161, posY:309),


            // Klaty:
            // Strona 1:
            new Zbroja("Peasant breastplate", 200, 1, 32, CzescZbroi.Klata, "klata11", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse breastplate", 400, 1, 48, CzescZbroi.Klata, "klata11", strona:1, posX:161, posY:22),
            new Zbroja("Brigand breastplate", 600, 1, 64, CzescZbroi.Klata, "klata11", strona:1, posX:301, posY:22),

            new Zbroja("Militia breastplate", 800, 6, 80, CzescZbroi.Klata, "klata11", strona:1, posX:26, posY:174),
            new Zbroja("Veteran breastplate", 1100, 6, 96, CzescZbroi.Klata, "klata11", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite breastplate", 1500, 12, 112, CzescZbroi.Klata, "klata11", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler breastplate", 2000, 12, 128, CzescZbroi.Klata, "klata11", strona:1, posX:26, posY:309),
            new Zbroja("Retarius breastplate", 2500, 12, 144, CzescZbroi.Klata, "klata11", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon breastplate", 3000, 18, 160, CzescZbroi.Klata, "klata11", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion breastplate", 3500, 18, 176, CzescZbroi.Klata, "klata11", strona:2, posX:26, posY:22),
            new Zbroja("Warlord breastplate", 4000, 18, 192, CzescZbroi.Klata, "klata11", strona:2, posX:161, posY:22),
            new Zbroja("Centurion breastplate", 4500, 24, 208, CzescZbroi.Klata, "klata11", strona:2, posX:301, posY:22),

            new Zbroja("Knight breastplate", 5000, 24, 224, CzescZbroi.Klata, "klata11", strona:2, posX:26, posY:174),
            new Zbroja("Paladin breastplate", 5500, 24, 240, CzescZbroi.Klata, "klata11", strona:2, posX:161, posY:174),
            new Zbroja("Templar breastplate", 6000, 30, 256, CzescZbroi.Klata, "klata11", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier breastplate", 6500, 30, 272, CzescZbroi.Klata, "klata11", strona:2, posX:26, posY:309),
            new Zbroja("Crusader breastplate", 7500, 30, 288, CzescZbroi.Klata, "klata11", strona:2, posX:161, posY:309),
            new Zbroja("Avenger breastplate", 8000, 36, 304, CzescZbroi.Klata, "klata11", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal breastplate", 8500, 36, 320, CzescZbroi.Klata, "klata11", strona:3, posX:26, posY:22),
            new Zbroja("Samurai breastplate", 9000, 36, 336, CzescZbroi.Klata, "klata11", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate breastplate", 9500, 42, 352, CzescZbroi.Klata, "klata11", strona:3, posX:301, posY:22),


            new Zbroja("Conquerer breastplate", 10000, 42, 368, CzescZbroi.Klata, "klata11", strona:3, posX:26, posY:309),
            new Zbroja("Automaton breastplate", 10500, 42, 384, CzescZbroi.Klata, "klata11", strona:3, posX:161, posY:309),
            new Zbroja("Champions breastplate", 11000, 48, 400, CzescZbroi.Klata, "klata11", strona:3, posX:301, posY:309),


            // Tarcze:
            // Strona 1:
            new Zbroja("Peasant shield", 200, 1, 24, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse shield", 400, 1, 36, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:161, posY:22),
            new Zbroja("Brigand shield", 600, 1, 48, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:301, posY:22),

            new Zbroja("Militia shield", 800, 6, 60, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:26, posY:174),
            new Zbroja("Veteran shield", 1100, 6, 72, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite shield", 1500, 12, 84, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler shield", 2000, 12, 96, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:26, posY:309),
            new Zbroja("Retarius shield", 2500, 12, 108, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon shield", 3000, 18, 120, CzescZbroi.Tarcza, "tarcza10", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion shield", 3500, 18, 132, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:26, posY:22),
            new Zbroja("Warlord shield", 4000, 18, 144, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:161, posY:22),
            new Zbroja("Centurion shield", 4500, 24, 156, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:301, posY:22),

            new Zbroja("Knight shield", 5000, 24, 168, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:26, posY:174),
            new Zbroja("Paladin shield", 5500, 24, 180, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:161, posY:174),
            new Zbroja("Templar shield", 6000, 30, 192, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier shield", 6500, 30, 204, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:26, posY:309),
            new Zbroja("Crusader shield", 7500, 30, 216, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:161, posY:309),
            new Zbroja("Avenger shield", 8000, 36, 228, CzescZbroi.Tarcza, "tarcza10", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal shield", 8500, 36, 240, CzescZbroi.Tarcza, "tarcza10", strona:3, posX:26, posY:22),
            new Zbroja("Samurai shield", 9000, 36, 252, CzescZbroi.Tarcza, "tarcza10", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate shield", 9500, 42, 264, CzescZbroi.Tarcza, "tarcza10", strona:3, posX:301, posY:22),


            new Zbroja("Conquerer shield", 10000, 42, 276, CzescZbroi.Tarcza, "tarcza10", strona:3, posX:26, posY:309),
            new Zbroja("Automaton shield", 10500, 42, 288, CzescZbroi.Tarcza, "tarcza10", strona:3, posX:161, posY:309),


            // Spodnie:
            // Strona 1:
            new Zbroja("Peasant shinguard", 200, 1, 12, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse shinguard", 400, 1, 18, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:161, posY:22),
            new Zbroja("Brigand shinguard", 600, 1, 24, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:301, posY:22),

            new Zbroja("Militia shinguard", 800, 6, 30, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:26, posY:174),
            new Zbroja("Veteran shinguard", 1100, 6, 36, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite shinguard", 1500, 12, 42, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler shinguard", 2000, 12, 48, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:26, posY:309),
            new Zbroja("Retarius shinguard", 2500, 12, 54, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon shinguard", 3000, 18, 60, CzescZbroi.Spodnie, "spodnie4", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion shinguard", 3500, 18, 66, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:26, posY:22),
            new Zbroja("Warlord shinguard", 4000, 18, 72, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:161, posY:22),
            new Zbroja("Centurion shinguard", 4500, 24, 78, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:301, posY:22),

            new Zbroja("Knight shinguard", 5000, 24, 84, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:26, posY:174),
            new Zbroja("Paladin shinguard", 5500, 24, 90, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:161, posY:174),
            new Zbroja("Templar shinguard", 6000, 30, 96, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier shinguard", 6500, 30, 102, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:26, posY:309),
            new Zbroja("Crusader shinguard", 7500, 30, 108, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:161, posY:309),
            new Zbroja("Avenger shinguard", 8000, 36, 114, CzescZbroi.Spodnie, "spodnie4", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal shinguard", 8500, 36, 120, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:26, posY:22),
            new Zbroja("Samurai shinguard", 9000, 36, 126, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate shinguard", 9500, 42, 132, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:301, posY:22),


            new Zbroja("Conquerer shinguard", 10000, 42, 138, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:26, posY:309),
            new Zbroja("Automaton shinguard", 10500, 42, 144, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:161, posY:309),
            new Zbroja("Champions shinguard", 11000, 48, 150, CzescZbroi.Spodnie, "spodnie4", strona:3, posX:301, posY:309),


            // Buty:
            // Strona 1:
            new Zbroja("Peasant boots", 200, 1, 4, CzescZbroi.Buty, "buty11", strona:1, posX:26, posY:22),
            new Zbroja("Cutpurse boots", 400, 1, 6, CzescZbroi.Buty, "buty11", strona:1, posX:161, posY:22),
            new Zbroja("Brigand boots", 600, 1, 8, CzescZbroi.Buty, "buty11", strona:1, posX:301, posY:22),

            new Zbroja("Militia boots", 800, 6, 10, CzescZbroi.Buty, "buty11", strona:1, posX:26, posY:174),
            new Zbroja("Veteran boots", 1100, 6, 12, CzescZbroi.Buty, "buty11", strona:1, posX:161, posY:174),
            new Zbroja("Hoplite boots", 1500, 12, 14, CzescZbroi.Buty, "buty11", strona:1, posX:301, posY:174),

            new Zbroja("Swashbuckler boots", 2000, 12, 16, CzescZbroi.Buty, "buty11", strona:1, posX:26, posY:309),
            new Zbroja("Retarius boots", 2500, 12, 18, CzescZbroi.Buty, "buty11", strona:1, posX:161, posY:309),
            new Zbroja("Myrmidon boots", 3000, 18, 20, CzescZbroi.Buty, "buty11", strona:1, posX:301, posY:309),

            // Strona 2:
            new Zbroja("Legion boots", 3500, 18, 22, CzescZbroi.Buty, "buty11", strona:2, posX:26, posY:22),
            new Zbroja("Warlord boots", 4000, 18, 24, CzescZbroi.Buty, "buty11", strona:2, posX:161, posY:22),
            new Zbroja("Centurion boots", 4500, 24, 26, CzescZbroi.Buty, "buty11", strona:2, posX:301, posY:22),

            new Zbroja("Knight boots", 5000, 24, 28, CzescZbroi.Buty, "buty11", strona:2, posX:26, posY:174),
            new Zbroja("Paladin boots", 5500, 24, 30, CzescZbroi.Buty, "buty11", strona:2, posX:161, posY:174),
            new Zbroja("Templar boots", 6000, 30, 32, CzescZbroi.Buty, "buty11", strona:2, posX:301, posY:174),

            new Zbroja("Cavalier boots", 6500, 30, 34, CzescZbroi.Buty, "buty11", strona:2, posX:26, posY:309),
            new Zbroja("Crusader boots", 7500, 30, 36, CzescZbroi.Buty, "buty11", strona:2, posX:161, posY:309),
            new Zbroja("Avenger boots", 8000, 36, 38, CzescZbroi.Buty, "buty11", strona:2, posX:301, posY:309),

            // Strona 3:
            new Zbroja("Infernal boots", 8500, 36, 40, CzescZbroi.Buty, "buty11", strona:3, posX:26, posY:22),
            new Zbroja("Samurai boots", 9000, 36, 42, CzescZbroi.Buty, "buty11", strona:3, posX:161, posY:22),
            new Zbroja("Demon-plate boots", 9500, 42, 44, CzescZbroi.Buty, "buty11", strona:3, posX:301, posY:22),


            new Zbroja("Conquerer boots", 10000, 42, 46, CzescZbroi.Buty, "buty11", strona:3, posX:26, posY:309),
            new Zbroja("Automaton boots", 10500, 42, 48, CzescZbroi.Buty, "buty11", strona:3, posX:161, posY:309),
            new Zbroja("Champions boots", 11000, 48, 50, CzescZbroi.Buty, "buty11", strona:3, posX:301, posY:309),
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