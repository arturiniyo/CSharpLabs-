using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageAdd Handler1 = new MessageAdd();
            MessageChangeData Handler2 = new MessageChangeData();
            MessageRemove Handler3 = new MessageRemove();

            Series testSeries = new Series();

            testSeries.EventAdd += Handler1.Message;
            testSeries.EventChangeData += Handler2.Message;
            testSeries.EventRemove += Handler3.Message;

            testSeries.AddToSeries(new Exponential(5, 2, 3));
            testSeries.AddToSeries(new Linear(7, -3, 2));
            testSeries.AddToSeries(new Linear(6, 2, 7));
            testSeries.AddToSeries(new Exponential(5, 2, 3));
            testSeries.AddToSeries(new Exponential(4, 3, 7));

            Console.WriteLine("\nSeries after adding 5 progressions :\n");
            testSeries.PrintSeries();
            Console.WriteLine();

            testSeries.ChangeData(2, 7, 3, 7);
            testSeries.Remove(1);

            Console.WriteLine("\nSeries after changing 3rd progression and removing the 2nd one :\n");
            testSeries.PrintSeries();
            Console.WriteLine();

            testSeries.PrintTotalSum();

            Console.WriteLine("\nTesting deep copy: \n");
            List<Progression> testSeries2 = new List<Progression>();
            testSeries2 = testSeries.DeepCopy();
            Console.WriteLine("New series : ");
            foreach (Progression p in testSeries2)
            {
                p.ToString();
            }

            Linear p1 = new Linear(2, 7, 5);
            Exponential p2 = new Exponential(5, 7, 8);
            if (p1.Equals(new Linear(2, 7, 5)) && p2.Equals(new Exponential(5, 7, 8)))
                Console.WriteLine("\nMethod Equals works correctly");
            else
                Console.WriteLine("\nMethod Equals doesn't work correctly");

            Linear p3 = new Linear(2, 7, 5);
            Exponential p4 = new Exponential(5, 7, 8);
            if (p1 == p3 && p2 == p4)
                Console.WriteLine("\nOperators == and != work correctly");
            else
                Console.WriteLine("\nOperators == and != don't work correctly");

            if (p1.GetHashCode() == p3.GetHashCode())
                Console.WriteLine("\nGetting hash code works correctly");
            else
                Console.WriteLine("\nGetting hash code doesn't work correctly");

            Console.ReadKey();
        }
    }
}
