using System.Threading;

namespace CodeForSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent dataConsumedEvent = new AutoResetEvent(true);
            AutoResetEvent dataReadyEvent = new AutoResetEvent(false);
            
            DataContainer dataContainer = new DataContainer();

            Producer producer = new Producer(dataContainer, dataConsumedEvent, dataReadyEvent);
            Consumer consumer = new Consumer(dataContainer, dataReadyEvent, dataConsumedEvent);

            Thread producerThread = new Thread(producer.Run);
            Thread consumerThread = new Thread(consumer.Run);

            producerThread.Start();
            consumerThread.Start();
        }
    }
}
