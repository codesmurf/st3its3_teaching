using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BlockingCollection
{
    class Consumer
    {
        private readonly BlockingCollection<DataContainer> _dataQueue;

        public Consumer(BlockingCollection<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            while (!_dataQueue.IsCompleted)
            {
                try
                {
                    var container = _dataQueue.Take();
                    int pressure = container.GetTyrePressure();
                    System.Console.WriteLine("Tyre pressure: {0}", pressure);
                }
                catch (InvalidOperationException)
                {
                    // IOE means that Take() was called on a completed collection.
                    // Some other thread can call CompleteAdding after we pass the
                    // IsCompleted check but before we call Take. 
                    // In this example, we can simply catch the exception since the 
                    // loop will break on the next iteration.
                }
                Thread.Sleep(10);
            }
            System.Console.WriteLine("No more data expected");
        }
    }
}
