using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using instagib.LeetCode1115;
using Xunit;
using Xunit.Abstractions;

namespace instagib.test.LeetCode1115
{
    public class FooBarTest
    {
        private readonly ITestOutputHelper _tout;
        
        public FooBarTest(ITestOutputHelper tout)
        {
            _tout = tout;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task Leetcode_1115_test(int n)
        {
            var sout = new BlockingCollection<string>();
            var fb = new FooBar(n);
            ThreadStart fooStart = () => fb.Foo(() => sout.Add("foo"));
            var fooTrd = new Thread(fooStart);
            ThreadStart barStart = () => fb.Bar(() => sout.Add("bar"));
            var barTrd = new Thread(barStart);
            
            fooTrd.Start();
            barTrd.Start();
            fooTrd.Join();
            barTrd.Join();

            var actual = string.Join("", sout);
            var exp = string.Join("", Enumerable.Range(0, n).Select(i => "foobar"));
            Assert.Equal(exp, actual);
        }
    }
}