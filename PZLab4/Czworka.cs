using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab4
{
    public class Czworka<T1, T2, T3, T4> : IComparable<Czworka<T1, T2, T3, T4>> where T1 : IComparable<T1>
    {
        private T1 pole1;
        private T2 pole2;
        private T3 pole3;
        private T4 pole4;

        public T1 Pole1 { get => pole1; set => pole1 = value; }
        public T2 Pole2 { get => pole2; set => pole2 = value; }
        public T3 Pole3 { get => pole3; set => pole3 = value; }
        public T4 Pole4 { get => pole4; set => pole4 = value; }

        public Czworka() { }

        public Czworka(T1 p1, T2 p2, T3 p3, T4 p4)
        {
            Pole1 = p1;
            Pole2 = p2;
            Pole3 = p3;
            Pole4 = p4;
        }

        public override string ToString()
        {
            return $"ID: {Pole1} | P2: {Pole2} | P3: {Pole3} | P4: {Pole4}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return this.ToString() == obj.ToString();
        }

        public int CompareTo(Czworka<T1, T2, T3, T4> other)
        {
            if (other == null) return 1;
            return this.Pole1.CompareTo(other.Pole1);
        }
    }
}