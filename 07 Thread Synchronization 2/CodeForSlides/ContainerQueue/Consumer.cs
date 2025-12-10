using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ContainerQueue
{
    class Consumer
    {
        private readonly ConcurrentQueue<DataContainer> _dataQueue;

        public Consumer(ConcurrentQueue<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            while (true)
            {
                DataContainer container;
                while (!_dataQueue.TryDequeue(out container))
                {
                    Thread.Sleep(0);
                }

                int pressure = container.GetTyrePressure();
                System.Console.WriteLine("Tyre pressure: {0}", pressure);
            }
        }
    }
}
