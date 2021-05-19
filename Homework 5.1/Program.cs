using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_5._1
{
    class Program

        // Написать приложение, считающее в раздельных потоках: 
        // факториал числа N, которое вводится с клавиатуры;
        // сумму целых чисел до N.

    {
        static void Main(string[] args)
        {
            int N = 20;
            for (int i = 0; i < N; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Factorial));
                thread.Start(N);
            }

            //for (int i = 0; i < N; i++)
            //{
            //    Thread thread = new Thread(new ParameterizedThreadStart(Sum));
            //    thread.Start(N);
            //}
            //Thread thread = new Thread(new ThreadStart(Factorial));
            //thread.Start();
            //Factorial();

            Console.ReadLine();                      
        }

        private static readonly object _SyncRoot = new object();

        static void Factorial(object _N)
        {
            //CheckThread();

            lock (_SyncRoot)
            {
                int x = (int)_N;
                int factorial = 1;

                for (int i = 1; i <= x; i++)
                {       
                    Console.WriteLine("id потока:{0}", Thread.CurrentThread.ManagedThreadId);
                    factorial *= i;
                    Thread.Sleep(100);
                    Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
                }

                Console.WriteLine("Факториал = " + factorial);
            }
            //int x = 5;
            //int factorial = 1;

            //for (int i = 1; i <= x; i++)
            //{
            //    //CheckThread();
            //    //Thread thread = new Thread(new ThreadStart(Factorial));
            //    //thread.Start();

            //    Console.WriteLine("id потока:{0}", Thread.CurrentThread.ManagedThreadId);
            //    factorial *= i;
            //    Thread.Sleep(100);
            //    Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);

            //    Console.WriteLine("Факториал = " + factorial);
            //}

            //Console.WriteLine(factorial);            
        }

        public static void CheckThread()
        {
            var current_thread = Thread.CurrentThread;
            Console.WriteLine("Поток \"{0}\" (id:{1}) запущен", current_thread.Name, current_thread.ManagedThreadId);
        }

        static void Sum(object _N)
        {
            int res = 0;
            int N = (int)_N;
            for (int i = 0; i <= N; i++)
            {
                res += i;
            }

            Console.WriteLine("Сумма = " + res);
        }
    }    
}
