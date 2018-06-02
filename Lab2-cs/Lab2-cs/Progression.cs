using System;

namespace Lab2_cs
{
    public abstract class Progression : Object
    {
        protected double a1,    // перший елемент прогресії
                         d,     // різниця арифметичної, знаменник геометричної прогресії
                         an,    // n-й елемент прогресії
                         Sn;    // сумма n членів прогресії
        protected int n;        // індекс елемента прогресії
        public Progression() { }
        public Progression(int n, double a1, double d)
        {
            this.n = n;
            this.a1 = a1;
            this.d = d;
        }
        
        public double A1
        {
            get { return a1; }
            set { a1 = value; }
        }

        public double D
        {
            get { return d; }
            set { d = value; }
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public double AN
        {
            get { return an; }
        }

        public double SN
        {
            get { return Sn; }
        }

        public abstract void ToString();
        public abstract double CalculateElement(int n, double a1, double d);
        public abstract double CalculateSum(int n, double a1, double d);
        public abstract double CalculateSum(int n, double a1);

        public bool Equals(Progression p)
        {
            return a1 == p.A1 && d == p.D && n == p.N && an== p.AN && Sn == p.SN;
        }

        public static bool operator ==(Progression p1, Progression p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Progression p1, Progression p2)
        {
            return !p1.Equals(p2);
        }

        public override int GetHashCode()
        {
            return (int)a1 * (int)d * n;
        }

    }
}
