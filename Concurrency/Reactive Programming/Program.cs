using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Reactive_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rx();

            //var timer = new System.Timers.Timer(interval: 1000) { Enabled = true };
            //var ticks = Observable.FromEventPattern(timer, "Elapsed");
            //ticks.Subscribe(data => Console.WriteLine("OnCompleted:" + ((ElapsedEventArgs)data.EventArgs).SignalTime));

            var client = new WebClient();
            var downloadedString = Observable.FromEventPattern();

            Console.ReadLine();
        }

        public static void Rx()
        {
            IObservable<DateTimeOffset> timestamps =
                Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Timestamp);
            timestamps.Subscribe(x => Console.WriteLine(x));
        }

    }
}
