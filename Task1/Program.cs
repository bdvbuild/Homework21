using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
//Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
//Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
//Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
//Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
//Создать многопоточное приложение, моделирующее работу садовников.

namespace Task1
{
    internal class Program
    {
        const int n = 5;
        static int[,] field = new int[n, n];

        static void Main(string[] args)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = r.Next(50);
                    Console.Write("{0,2}"+" ", field[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{field[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int j = n - 1; j >= 0; j--)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

    }
}
