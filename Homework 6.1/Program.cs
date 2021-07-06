using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6._1
{
    //Даны две двумерных матрицы размерностью 100х100 каждая.
    //Задача: написать приложение, производящее их параллельное умножение.
    //Матрицы заполняются случайными целыми числами от 0 до 10.

    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = new int[10, 10];
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr1[i, j] = r.Next(0, 11);
                    Console.Write("{0}\t", arr1[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------");

            int[,] arr2 = new int[10, 10];            

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr2[i, j] = r.Next(0, 11);
                    Console.Write("{0}\t", arr2[i, j]);
                }
                Console.WriteLine();
            }

            //int[,] arr_result = new int[10, 10];

            //Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------------------------");

            var arr_result = Multiply(arr1, arr2);

            Print(arr_result);

            //int[,] res = Parallel.Invoke(Multiply);

            

            //Print(arr_result);
            Console.ReadLine();
        }        

        static int[,] Multiply(int[,] a, int[,] b)
        {
            int[,] arr_result = new int[10, 10];

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    arr_result[i, j] = 0;

                    for (var k = 0; k < 10; k++)
                    {
                        arr_result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return arr_result;
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }        
    }
}
