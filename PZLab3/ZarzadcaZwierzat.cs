using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab3
{
    public class ZarzadcaZwierzat
    {
        public List<Zwierzak> Zwierzaki { get; set; } = new List<Zwierzak>();
        public List<IRoslinozerne> Roslinozerne { get; set; } = new List<IRoslinozerne>();
        public List<IMiesozerne> Miesozerne { get; set; } = new List<IMiesozerne>();

        public void DodajZwierzaka(Zwierzak z) => Zwierzaki.Add(z);
        public void DodajRoslinozerce(IRoslinozerne r) => Roslinozerne.Add(r);
        public void DodajMiesozerce(IMiesozerne m) => Miesozerne.Add(m);

        public void KopiujZwierzaki()
        {
            foreach (var z in Zwierzaki)
            {
                if (z is IRoslinozerne roslinozerca) DodajRoslinozerce(roslinozerca);
                if (z is IMiesozerne miesozerca) DodajMiesozerce(miesozerca);
            }
        }

        public void NakarmWszystkieRoslinozerne()
        {
            foreach (var r in Roslinozerne)
            {
                r.ZnajdzPozywienie();
                r.ZjedzRoslinke();
            }
        }
        public void NakarmWszystkieMiesozerne()
        {
            foreach (var m in Miesozerne)
            {
                m.ZnajdzPozywienie();
                m.ZjedzMiesko();
            }
        }

        public static void NakarmPojedynczegoRoslinozerce(IRoslinozerne r)
        {
            r.ZnajdzPozywienie();
            r.ZjedzRoslinke();
        }

        public static void NakarmPojedynczegoMiesozerce(IMiesozerne m)
        {
            m.ZnajdzPozywienie();
            m.ZjedzMiesko();
        }

        public void WyswietlWszystkieZwierzaki()
        {
            foreach (var z in Zwierzaki) Console.WriteLine(z.ToString());
        }

        public void WyswietlRoslinozerne()
        {
            foreach (var r in Roslinozerne) Console.WriteLine(r.ToString());
        }

        public void WyswietlMiesozerne()
        {
            foreach (var m in Miesozerne) Console.WriteLine(m.ToString());
        }

        public Zwierzak PobierzZwierzakaPoImieniu(string imie)
        {
            return Zwierzaki.Find(z => z.Imie.Equals(imie, StringComparison.OrdinalIgnoreCase));
        }
    }
}