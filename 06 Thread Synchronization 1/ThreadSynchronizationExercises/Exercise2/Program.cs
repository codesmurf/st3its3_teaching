using System;
using System.Threading;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalCount totalCount = new TotalCount();

            Counter c1 = new Counter(200000, totalCount);
            Counter c2 = new Counter(500000, totalCount);

            Thread t1 = new Thread(c1.StartCounting);
            Thread t2 = new Thread(c2.StartCounting);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Total count: {0}", totalCount.Count);

            Console.ReadKey();
        }
    }
}
