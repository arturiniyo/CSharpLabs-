/*
Варіант 15
Имеется N человек и прямоугольная таблица А[1:N, 1:N];
элемент A[i, j] равен 1, 
если человек i знаком с человеком j, А[i, j] = =А[j, i]. 
Можно ли разбить людей на 2 группы, 
чтобы в каждой группе были только незнакомые люди.
*/

using System;

namespace Lab1_cs
{
    class Program
    {
        //Введение таблицы знакомств вручную
        static void inputMas(int[,] mas, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Console.Write("Input a [" + i + "][" + j + "] element :");
                        mas[i, j] = int.Parse(Console.ReadLine());
                        if (mas[i, j] != 0 && mas[i, j] != 1)
                            throw new FormatException("Please, enter only 0 or 1."); 
                }
        }
        //Заполнение таблицы знакомств случайно
        static void randomMas(int[,] mas, int size)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    mas[i, j] = rnd.Next(0, 2);
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    if (i == j) mas[i, j] = 0;
                    else mas[i, j] = mas[j, i];
            }
        }
        //Вывод таблицы
        static void printMas(int[,] mas, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        //Решение поставленной задачи, можем ли мы поделить на 2 группы
        static void CanWeDivide(int[,] mas, int size, int[] group)
        {
            for (int i = 0; i < size; i++)
            {
                if (group[i] == 0 || group[i] == 1)
                {
                    if (group[i] == 0) group[i] = 1;
                    for (int j = 0; j < size; j++)
                    {
                        if (mas[i, j] == 1)
                        {
                            if (group[j] == 1 && i != j)
                            {
                                SayNo();
                                return;
                            }
                            group[j] = 2;
                        }
                    }
                }
                else if (group[i] == 2)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (mas[i, j] == 1)
                        {
                            if (group[j] == 2 && i != j)
                            {
                                SayNo();
                                return;
                            }
                            group[j] = 1;
                        }
                    }
                }
            }
            if (AllInGroups(size, group))
                SayYes();
        }

        static bool AllInGroups(int size, int[] group)
        {
            for (int i = 0; i < size; i++)
            {
                if (group[i] == 0) return false;
            }
            return true;
        }

        static void SayNo()
        {
            Console.WriteLine("\nNO, we can't divide");
        }

        static void SayYes()
        {
            Console.WriteLine("\nYES, we can divide");
        }

        static void Main(string[] args)
        {
            int size, whichTable;
            while (true)
            {
                try
                {
                    Console.Write("Input number of persons : ");
                    size = int.Parse(Console.ReadLine());
                    if (size <= 1)
                    {
                        Console.WriteLine("Number of persons must be 2 or more > 1");
                        continue;
                    }
                    int[] group = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        group[i] = 0;
                    }
                    int[,] mas = new int[size, size];
                    Console.Write("Use a random table or input your own? : (enter 1 or 2) : ");
                    whichTable = int.Parse(Console.ReadLine());
                    if (whichTable != 1 && whichTable != 2)
                        throw new FormatException("Enter only 1 or 2.");
                    if (whichTable == 1)
                        randomMas(mas, size);
                    else inputMas(mas, size);
                    Console.WriteLine("\nTable of contacts : \n");
                    printMas(mas, size);
                    CanWeDivide(mas, size, group);           
                    break;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    Console.Write(" Try again, please\n");
                }
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
