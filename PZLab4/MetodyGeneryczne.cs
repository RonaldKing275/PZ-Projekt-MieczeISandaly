using System;
using System.Collections.Generic;
using System.Linq;

namespace PZLab4
{
    public static class MetodyGeneryczne
    {
        public static void Zamien<T>(ref T a, ref T b)
        {
            (b, a) = (a, b);
        }

        public static void WyswietlIZresetuj<T1, T2>(ref T1 a, ref T2 b)
        {
            Console.WriteLine($"Parametr 1: Typ = {a.GetType().Name}, Stan = {a.ToString()}");
            Console.WriteLine($"Parametr 2: Typ = {b.GetType().Name}, Stan = {b.ToString()}");

            a = default;
            b = default;
        }

        public static T UtworzObiekt<T>() where T : new() => new();

        public static T ZwracajWiekszy<T>(T a, T b) where T : IComparable<T> 
            => a.CompareTo(b) > 0 ? a : b;

        public static List<T> PosortujElementy<T>(params T[] elementy) where T : IComparable<T> 
            => elementy.OrderBy(e => e).ToList();

        public static Dictionary<TKey, TValue> UtworzSlownik<TKey, TValue>(TKey klucz, TValue wartosc)
                    where TKey : struct
                    where TValue : class
                    => new() { [klucz] = wartosc };

        public static void WyswietlSlownik<TKey, TValue>(Dictionary<TKey, TValue> slownik)
        {
            foreach (var (klucz, wartosc) in slownik) 
                Console.WriteLine($"Klucz: {klucz}, Wartość: {wartosc}");
        }

        public static IEnumerable<T> UtworzKolekcje<T>(params T[] elementy) 
            => elementy.Length < 3 ? new Queue<T>(elementy) : new Stack<T>(elementy);
    }
}