using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ContainerQueue
{
    class Producer
    {
        private readonly ConcurrentQueue<DataContainer> _dataQueue;
        private readonly Random _random = new Random();

        public Producer(ConcurrentQueue<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            while (true)
            {
                int pressure = _random.Next(0, 50);
                DataContainer reading = new DataContainer();
                reading.SetTyrePressure(pressure);
                _dataQueue.Enqueue(reading);
                Thread.Sleep(10);
            }
        }
    }
}
