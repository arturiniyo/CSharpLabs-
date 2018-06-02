using System;

namespace Lab2_cs
{
    class MyIndexOutOfRange : Exception
    {
            public MyIndexOutOfRange()
            {
                Console.WriteLine("Index is out of range!");
            }
    }
}
