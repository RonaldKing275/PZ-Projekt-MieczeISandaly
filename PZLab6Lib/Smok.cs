using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab6Lib
{
    public delegate void ZianieOgniemAkcja(int intensywnosc);

    public class Smok : Postac
    {
        public int ExpZaZabicie { get; set; }

        public event ZianieOgniemAkcja OnZianieOgniem;

        public int ZionOgniem()
        {
            // Wzór na intensywność ognia
            int intensywnosc = Poziom + Inteligencja;

            if (OnZianieOgniem != null)
            {
                OnZianieOgniem(intensywnosc);
            }

            return intensywnosc;
        }
    }
}
