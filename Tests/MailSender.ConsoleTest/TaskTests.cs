using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class TaskTests
    {
        public static void Start()
        {
            #region Создание задачи 1

            //var first_task = new Task(TaskMethod);
            //first_task.Start();
            ////first_task.Wait();

            var msg = "Hello world!";
            //var get_length_task = new Task<int>(() => GetStrLength(msg));
            //get_length_task.Start();

            //Console.ReadLine();
            //Console.WriteLine("Какие-то дополнительные действия в главном потоке после запуска задачи");

            //try
            //{
            //    //get_length_task.Wait();

            //    Console.WriteLine("str {0} - length:{1}", msg, get_length_task.Result);
            //}
            //catch (AggregateException error)
            //{
            //    Console.WriteLine("При выполнении задачи случилось страшное");
            //    foreach (var inner_error in error.InnerExceptions)
            //        Console.WriteLine("\t{0}", inner_error.Message);
            //}

            #endregion

            var second_task = Task.Factory.StartNew(TaskMethod);
            var second_value_task = Task.Run(() => GetStrLength(msg));  //Рекомендуемый и чаще всего встречаемый

            //Console.WriteLine("str {0} - length:{1}", msg, second_value_task.Result);
            var second_value_task_continuation = second_value_task.
                ContinueWith(completed_task => Console.WriteLine("str {0} - length:{1}", msg, completed_task.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            //second_value_task_continuation.ContinueWith();

            var second_value_task_continuation_on_exeption = second_value_task.
                ContinueWith(completed_task => Console.WriteLine("Exeption {0}",completed_task.Exception),
                TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void TaskMethod()
        {
            Console.WriteLine("ThID:{0} TaskID:{1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Thread.Sleep(1000);
            Console.WriteLine("ThID:{0} TaskID:{1} - ended", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        private static int GetStrLength(string msg)
        {
            Console.WriteLine("ThID:{0} - str:{1} - started", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - str:{1} - ended", Thread.CurrentThread.ManagedThreadId, msg);
            //throw new InvalidOperationException("Страшная ошибка!");
            return msg.Length;
        }
    }
}
