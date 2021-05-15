using System;
using System.Threading;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();

            //SynchronizationTests.Start();

            ThreadPoolTests.Start();

            Console.ReadLine();            
        }
    }
}
