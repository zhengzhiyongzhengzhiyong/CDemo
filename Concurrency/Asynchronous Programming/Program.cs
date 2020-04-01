using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                log(i.ToString());
            }
            Console.ReadLine();
        }

        public static async void log(string log)
        {
            Console.WriteLine(log);
            await Task.Delay(100000);
        }
    }
}
