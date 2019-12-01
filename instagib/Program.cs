using System;
using System.Threading;
using System.Threading.Tasks;
using instagib.LeetCode1115;

namespace instagib
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var init = 3;
            var old = Interlocked.CompareExchange(ref init, 0, 1);

//            var fb = new FooBar(2);
//            ThreadStart fooStart = () => fb.Foo(() => Console.WriteLine("foo"));
//            var fooTrd = new Thread(fooStart);
//            ThreadStart barStart = () => fb.Bar(() => Console.WriteLine("bar"));
//            var barTrd = new Thread(barStart);
//            
//            fooTrd.Start();
//            barTrd.Start();
//            fooTrd.Join();
//            barTrd.Join();
            
            Console.WriteLine("done");
        }
    }
}