using System.Collections.Concurrent;

namespace ECG_Producer_Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ECG Monitor program started.");
            Console.WriteLine("Press:");
            Console.WriteLine(" q : quit program");
            Console.WriteLine(" p : process list of samples");

            BlockingCollection<ECGReading> ecgReadings = new BlockingCollection<ECGReading>();
            IECGSensor sensor = new ECGSensor();
            ECGContainer ecgContainer = new ECGContainer();
            
            ECGReadingProducer producer = new ECGReadingProducer(ecgReadings, sensor);
            ECGReadingConsumer consumer = new ECGReadingConsumer(ecgReadings, ecgContainer);

            Thread producerThread = new Thread(producer.Run);
            Thread consumerThread = new Thread(consumer.Run);

            producerThread.Start();
            consumerThread.Start();

            bool stop = false;
            while (!stop)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(false);
                char keyChar = consoleKeyInfo.KeyChar;

                switch (keyChar)
                {
                    case 'q':
                    {
                        stop = true;
                        producer.ShallStop = true;
                    }
                    break;
                    case 'p':
                    {
                        ecgContainer.ProcessSamples();
                    }
                    break;
                }
            }

            producerThread.Join();
            consumerThread.Join();
        }
    }
}