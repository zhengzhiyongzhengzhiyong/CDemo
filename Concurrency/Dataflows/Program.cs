using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Dataflows
{
    class Program
    {
        static void Main(string[] args)
        {
            Dataflows();
            Console.ReadLine();
        }

        public static void Dataflows()
        {
            try
            {
                var multiplyBlock = new TransformBlock<int, int>(item => {
                    return item * 2;                
                });

                var subtractBlock = new TransformBlock<int, int>(item => {
                    Console.WriteLine(item);
                    return item -2;
                });

                multiplyBlock.LinkTo(subtractBlock, new DataflowLinkOptions { PropagateCompletion = true });
                for (int i = 0; i < 1000; i++)
                {
                    multiplyBlock.Post(i);
                }
                subtractBlock.Completion.Wait();
            }
            catch (AggregateException exception)
            {
                AggregateException ex = exception.Flatten();
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}
