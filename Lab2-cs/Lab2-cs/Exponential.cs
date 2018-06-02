using System;

namespace Lab2_cs
{
    class Exponential : Progression
    {
        public Exponential() { }
        public Exponential(int n, double a1, double d) : base(n, a1, d)
        {
            CalculateElement(n, a1, d);
            if (d == 1)
                CalculateSum(n, a1);
            else
                CalculateSum(n, a1, d);
        }
        public override void ToString()
        {
            Console.WriteLine("The progression is exponential. 1st element is " + a1 + ", common ratio is " + d + ", current n is " + n + ".");
            Console.WriteLine("The n-element is " + an + ". The sum of n elements is " + Sn + ".");
        }
        public override double CalculateElement(int n, double a1, double d)
        {
            an = a1 * Math.Pow(d, n - 1);
            return an;
        }
        public override double CalculateSum(int n, double a1, double d) // q != 1
        {
            Sn = a1 * (1 - Math.Pow(d, n)) / (1 - d);
            return Sn;
        }
        public override double CalculateSum(int n, double a1) //q = 1
        {
            Sn = n * a1;
            return Sn;
        }
    }
}
