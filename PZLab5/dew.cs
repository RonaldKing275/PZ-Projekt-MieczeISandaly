using System;

namespace PZLab5
{
    public delegate void NajemnikAkcja(Najemnik n);
    public delegate void WyprawaAkcja(Wyprawa w);
    public delegate void NajemnikWyprawaAkcja(Najemnik n, Wyprawa w);

    public enum TrudnoscWyprawy
    {
        Treningowa, Latwa, NieTakaLatwa, Trudna, BardzoTrudna, KoszmarnieTrudna
    }

    public class DuplicatedNameException : Exception
    {
        public DuplicatedNameException(string message) : base(message) { }
    }
}