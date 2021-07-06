using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class TPLTests
    {
        public static void Start()
        {
            //new Thread(() => Console.WriteLine("Асинхронный параллельный код")).Start();

            //Action<string> printer = str => Console.WriteLine(str);
            //printer("Hellp World");
            //printer.Invoke("Hello world2!!!");
            //printer.BeginInvoke("Hello world async", result => Console.WriteLine("...completed!"), null);

            //Func<string, int> string_transform = str =>
            //{
            //    Thread.Sleep(400);
            //    return str.Length;
            //};
            //var data = "Hello world";
            //string_transform.BeginInvoke(data, result =>
            //{
            //    var length = string_transform.EndInvoke(result);
            //    Console.WriteLine("Length of {0} = {1}", (string)result.AsyncState, length);
            //}, data);

            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            //Parallel.For(0, messages.Length, new ParallelOptions { MaxDegreeOfParallelism = 8}, 
            //    i =>
            //{
            //    Thread.Sleep(250);
            //    Console.WriteLine("ThID:{0} - msg:{1}", Thread.CurrentThread.ManagedThreadId, messages[i]);
            //});

            //var for_result = Parallel.For(0, messages.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 },
            //    (i, state) =>
            //    {
            //        if (messages[i].EndsWith("5"))
            //            state.Break();

            //        Thread.Sleep(250);
            //        Console.WriteLine("ThID:{0} - msg:{1}", Thread.CurrentThread.ManagedThreadId, messages[i]);
            //    });
            //Console.WriteLine("Цикл был прерван на итерации {0}", for_result.LowestBreakIteration);

            //Parallel.Invoke(/*new ParallelOptions { MaxDegreeOfParallelism = 2},*/
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("ещё одно параллельное действие!"));

            #region Посчитать суммарную длину всех сообщений параллельно

            //var messages_lengths = new List<int>(messages.Length);

            //Parallel.ForEach(messages, msg =>
            //{
            //    var length = MessageProcessor(msg);
            //    lock (messages_lengths)
            //        messages_lengths.Add(length);
            //});
            //var total_length = messages_lengths.Sum();
            //Console.WriteLine("Total messages lengths = {0}", total_length);

            #endregion

            #region PLINQ

            //var total_length = messages.
            //    AsParallel().
            //    WithDegreeOfParallelism(15).
            //    //WithExecutionMode(ParallelExecutionMode.ForceParallelism).
            //    Select(MessageProcessor).
            //    //AsSequential().
            //    Sum();
            //Console.WriteLine("Total messages lengths = {0}", total_length);

            #endregion
           
            Console.ReadLine();            
        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - ended", Thread.CurrentThread.ManagedThreadId);
        }

        private static int MessageProcessor(string msg)
        {
            Console.WriteLine("ThID:{0} - msg:{1} - started", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - msg:{1} - ended", Thread.CurrentThread.ManagedThreadId, msg);
            return msg.Length;
        }
    }
}

