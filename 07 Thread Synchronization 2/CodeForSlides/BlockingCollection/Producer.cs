using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BlockingCollection
{
    class Producer
    {
        private readonly BlockingCollection<DataContainer> _dataQueue;
        private readonly Random _random = new Random();

        public Producer(BlockingCollection<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            int cnt = 50;
            while (cnt > 0)
            {
                int pressure = _random.Next(0, 50);
                DataContainer reading = new DataContainer();
                reading.SetTyrePressure(pressure);
                _dataQueue.Add(reading);
                Thread.Sleep(10);
                cnt--;
            }
            _dataQueue.CompleteAdding();
        }
    }
}
