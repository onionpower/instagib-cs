using System;
using System.Threading.Tasks;

namespace instagib
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var c1 = 5;
            var c2 = c1;
            for (int i = 0; i < c2; i++)
            {
                try
                {
                    if (i == 4)
                    {
                        continue;
                    }
                }                
                finally
                {
                    c1--;
                }
            }

            if (c1 != 0)
            {
                throw new Exception("this will never happen");
            }
        }  
    }
}