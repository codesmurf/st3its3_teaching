using System;
using System.Threading;

namespace CodeForSlides
{
    class Producer
    {
        private readonly DataContainer _dataContainer;
        private readonly AutoResetEvent _dataConsumedEvent;
        private readonly AutoResetEvent _dataReadyEvent;
        private readonly Random _random = new Random();

        public Producer(DataContainer dataContainer, 
                        AutoResetEvent dataConsumedEvent,
                        AutoResetEvent dataReadyEvent)
        {
            _dataContainer = dataContainer;
            _dataConsumedEvent = dataConsumedEvent;
            _dataReadyEvent = dataReadyEvent;
        }

        public void Run()
        {
            while (true)
            {
                _dataConsumedEvent.WaitOne();
                int pressure = _random.Next(0, 50);
                _dataContainer.SetTyrePressure(pressure);
                _dataReadyEvent.Set();
                Thread.Sleep(1000);
            }
        }
    }
}
