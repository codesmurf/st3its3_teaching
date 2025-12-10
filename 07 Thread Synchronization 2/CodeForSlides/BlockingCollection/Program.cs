using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<DataContainer> dataQueue = new BlockingCollection<DataContainer>();

            Producer producer = new Producer(dataQueue);
            Consumer consumer = new Consumer(dataQueue);

            Thread producerThread = new Thread(producer.Run);
            Thread consumerThread = new Thread(consumer.Run);

            producerThread.Start();
            consumerThread.Start();

            Console.ReadKey();
        }
    }
}
