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
            try
            {
                var task = Task.Run(async () =>
                {
                    var _ = Task
                        .Run(async () =>
                        {
                            throw new Exception("Here!"); 
                        })
                        .ContinueWith(t =>
                        {
                            if (t.IsFaulted)
                            {
                                Console.WriteLine($"supressed in continuation: {t.Exception.Message}");
                            }                            
                        });

                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"supressed in outter catch: {e.Message}");
            }

            Console.ReadLine();
            Console.WriteLine("done");            
        }  
    }
}