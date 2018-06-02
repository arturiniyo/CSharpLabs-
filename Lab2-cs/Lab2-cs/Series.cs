using System;
using System.Collections.Generic;

namespace Lab2_cs
{
    class Series
    {
        public delegate void MethodContainer1();
        public delegate void MethodContainer2();
        public delegate void MethodContainer3();

        public event MethodContainer1 EventAdd;
        public event MethodContainer2 EventRemove;
        public event MethodContainer3 EventChangeData;

        List<Progression> series = new List<Progression>();

        public Series() { }

        public Series(Progression p)
        {
            series.Add(p);
            EventAdd();
        }

        public void AddToSeries(Progression p)
        {
            series.Add(p);
            EventAdd();
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= series.Count)
                throw new MyIndexOutOfRange();
            series.RemoveAt(index);
            EventRemove();
        }

        public void PrintSeries()
        {
            foreach (Progression p in series)
            {
                p.ToString();
            }
        }

        public void PrintTotalSum()
        {
            double sum = 0;
            foreach (Progression p in series)
            {
                sum += p.SN;
            }
            Console.WriteLine("A total sum of progressions in series is: " + sum);
        }

        public List<Progression> DeepCopy()
        {
            List<Progression> series2 = new List<Progression>();
            foreach (Progression p in series)
            {
                if (p is Linear)
                {
                    Linear progression = new Linear(p.N, p.A1, p.D);
                    series2.Add(progression);
                }
                else if (p is Exponential)
                {
                    Exponential progression = new Exponential(p.N, p.A1, p.D);
                    series2.Add(progression);
                }
            }

            return series2;
        }

        public void ChangeData(int index, double a1, double d, int n)
        {
            if (index < 0 || index >= series.Count)
                throw new MyIndexOutOfRange();
            int i = 0;
            foreach (Progression p in series)
            {
                if (i == index)
                {
                    if (p is Linear)
                    {
                        p.A1 = a1;
                        p.D = d;
                        p.N = n;
                        p.CalculateElement(p.N, p.A1, p.D);
                        p.CalculateSum(p.N, p.A1, p.AN); 
                        EventChangeData();
                    }
                    else if (p is Exponential)
                    {
                        p.A1 = a1;
                        p.D = d;
                        p.N = n;
                        p.CalculateElement(p.N, p.A1, p.D);
                        if (p.D == 1)
                            p.CalculateSum(p.N, p.A1);
                        else p.CalculateSum(p.N, p.A1, p.D);
                        EventChangeData();
                    }
                    break;
                }
                i++;
            }
        }
    }
    class MessageAdd
    {
        public void Message()
        {
            Console.WriteLine("New element was added");
        }
    }
    class MessageRemove
    {
        public void Message()
        {
            Console.WriteLine("Element was removed");
        }
    }
    class MessageChangeData
    {
        public void Message()
        {
            Console.WriteLine("Data in element was changed");
        }
    }
}
