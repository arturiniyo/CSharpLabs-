using System;

namespace Lab2_cs
{
    class Linear : Progression
    {
        public Linear() { }
        public Linear(int n, double a1, double d) : base(n, a1, d)
        {
            CalculateElement(n, a1, d);
            CalculateSum(n, a1, an);
        }
        public override void ToString()
        {
            Console.WriteLine("The progression is linear. 1st element is " + a1 + ", common difference is " + d + ", current n is " + n + ".");
            Console.WriteLine("The n-element is " + an + ". The sum of n elements is " + Sn + ".");
        }
    
        public override double CalculateElement(int n, double a1, double d)
        {
            an = a1 + (n - 1) * d;
            return an;
        }
        public override double CalculateSum(int n, double a1, double an)
        {
            Sn = n * (2 * a1 + d * (n - 1)) / 2;
            return Sn;
        }
        public override double CalculateSum(int n, double a1)
        {
            return Sn;
        }
    }
}
