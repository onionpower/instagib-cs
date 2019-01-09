using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace instagib
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var throwingTask0 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                throw new Exception("manually thrown exception 0");
            });
            var throwingTask1 = Task.Run(() => throw new Exception("manually thrown exception 1"));
            var longRunningTask = Task.Run(async () =>
            {
                await Task.Delay(2000);
                Console.WriteLine("long running task is done");
            });
            
            var t = Task.WhenAll(throwingTask0, throwingTask1, longRunningTask);
            try
            {
                await t;
            }
            catch
            {
                Console.WriteLine(string.Join(", ", t.Exception.Flatten().InnerExceptions.Select(e => e.Message)));
            }
            Console.WriteLine("all is done");
        }  
    }
}