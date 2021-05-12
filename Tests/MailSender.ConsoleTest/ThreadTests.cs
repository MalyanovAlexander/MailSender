using System;
using System.Threading;

namespace MailSender.ConsoleTest
{
    internal static class ThreadTests
    {
        public static void CheckThread()
        {       
            var current_thread = Thread.CurrentThread;
            Console.WriteLine("Поток \"{0}\" (id:{1}) запущен", current_thread.Name, current_thread.ManagedThreadId);
                      
        }

        private static bool _IsClockEnabled = true;

        private static void ClockUpdater()
        {
            CheckThread();

            try
            {
                while (_IsClockEnabled)
                {
                    Console.Title = DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss.ffff");
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);                
            }

            Console.WriteLine("Поток часов завершился");
        }

        public static void Start()
        {
            Thread current_thread = Thread.CurrentThread;
            current_thread.Name = "Главный поток";
            CheckThread();

            var clock_thread = new Thread(ClockUpdater);
            clock_thread.Priority = ThreadPriority.Highest;
            clock_thread.Name = "Поток часов";
            clock_thread.IsBackground = true;
            clock_thread.Start();

            var message = "Hello world";
            var printer_thread = new Thread(Printer);
            printer_thread.IsBackground = true;
            printer_thread.Name = "Поток принтера";
            //printer_thread.Start(message);

            var printer2_thread = new Thread(() => Printer(message));
            printer2_thread.Name = "Поток принтера 2";
            //printer2_thread.Start();

            var printer3 = new Printer3(message);
            var printer3_thread = new Thread(printer3.Print);
            printer3_thread.Name = "Поток принтера 2";
            printer3_thread.Start();

            Console.ReadLine();

            _IsClockEnabled = false;
            if (!clock_thread.Join(200))
                clock_thread.Interrupt();

            //clock_thread.Abort();
            //clock_thread.Interrupt();
            //clock_thread.Join();
        }

        private static void Printer(object obj)
        {
            CheckThread();

            var message = (string)obj;

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("id:{0} - msg:\"{1}\"", Thread.CurrentThread.ManagedThreadId, message);
                Thread.Sleep(100);
            }
            Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
        }

        private static void Printer(string message)
        {
            CheckThread();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("id:{0} - msg:\"{1}\"", Thread.CurrentThread.ManagedThreadId, message);
                Thread.Sleep(100);
            }
            Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
        }

        internal class Printer3
        {
            private string _Message;

            public Printer3(string Message) => _Message = Message;

            public void Print()
            {
                CheckThread();

                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("id:{0} - msg:\"{1}\"", Thread.CurrentThread.ManagedThreadId, _Message);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
