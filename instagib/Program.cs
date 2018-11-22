using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace instagib
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            const int rightEdge = 10000;
            const int series = 1000;
            var expected = Enumerable.Range(0, rightEdge).Aggregate(0d, ((d, i) => d + i));
            
            RunSeries("locked", rightEdge, series, expected, (re) =>
            {
                var sync = new object();
                var total = 0d;
                Parallel.For(0, re, next =>
                {
                    lock (sync)
                    {
                        total += next;
                    }          
                });
                return total;
            });    
            
            RunSeries("interlocked", rightEdge, series, expected, (re) =>
            {
                var total = 0d;
                Parallel.For(0, re, next =>
                {
                    var current = total;
                    if (Interlocked.CompareExchange(ref total, current + next, current) != current)
                    {
                        var spinner = new SpinWait();
     
                        do
                        {
                            spinner.SpinOnce();
                            current = total;
                        }
                        while (Interlocked.CompareExchange(ref total, current + next, current) != current);
                    }
                });
                return total;
            });
        }

        static void RunSeries(string name, int rightEdge, int series, double expected, Func<int, double> action)
        {
            long totalTimeInterlocked = 0;
            for (int i = 0; i < series; i++)
            {
                totalTimeInterlocked += Measure(action, rightEdge, expected);
            }
            Console.WriteLine($"{name}: ");
            Console.WriteLine($"{nameof(series)}: {series}");
            Console.WriteLine($"mean time: {(float)totalTimeInterlocked / series}");
        }
        
        static long Measure(Func<int, double> action, int rightEdge, double expected)
        {
            var watch = Stopwatch.StartNew();
            double result = action(rightEdge);            
            watch.Stop();
            if (result != expected)
            {
                throw new ArithmeticException();
            }
            return watch.ElapsedMilliseconds;
        }
    }
}