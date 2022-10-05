using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ContainerQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<DataContainer> dataQueue = new ConcurrentQueue<DataContainer>();

            Producer producer = new Producer(dataQueue);
            Consumer consumer = new Consumer(dataQueue);

            Thread producerThread = new Thread(producer.Run);
            Thread consumerThread = new Thread(consumer.Run);
            consumerThread.IsBackground = true;

            producerThread.Start();
            consumerThread.Start();
        }
    }
}
