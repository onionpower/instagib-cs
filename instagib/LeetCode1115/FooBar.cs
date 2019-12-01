using System;
using System.Threading;

namespace instagib.LeetCode1115
{
    public class FooBar
    {
        private int n;
        private SemaphoreSlim _semFoo = new SemaphoreSlim(0);
        private SemaphoreSlim _semBar = new SemaphoreSlim(0);

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                _semBar.Release();
                _semFoo.Wait();
            }
        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < n; i++)
            {
                _semBar.Wait();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                _semFoo.Release();
            }
        }
    }
}