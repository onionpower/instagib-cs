using System;
using System.Data.SqlClient;
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
            var cs = "Application Name=kafka2sql-experimental;database=Sampler;server=localhost,1403;user=sa;pwd=Your_password123;Connection Timeout=152";            
            var builder = new SqlConnectionStringBuilder(cs);
            var timeout = builder.ConnectTimeout;
            Console.WriteLine(timeout);           
        }  
    }
}