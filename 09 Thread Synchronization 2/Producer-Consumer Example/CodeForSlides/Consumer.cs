using System.Threading;

namespace CodeForSlides
{
    class Consumer
    {
        private readonly DataContainer _dataContainer;
        private readonly AutoResetEvent _dataReadyEvent;
        private readonly AutoResetEvent _dataConsumedEvent;

        public Consumer(DataContainer dataContainer,
                        AutoResetEvent dataReadyEvent,
                        AutoResetEvent dataConsumedEvent)
        {
            _dataContainer = dataContainer;
            _dataReadyEvent = dataReadyEvent;
            _dataConsumedEvent = dataConsumedEvent;
        }

        public void Run()
        {
            while (true)
            {
                _dataReadyEvent.WaitOne();
                int pressure = _dataContainer.GetTyrePressure();
                System.Console.WriteLine("Tyre pressure: {0}", pressure);
                _dataConsumedEvent.Set();
            }
        }
    }
}
