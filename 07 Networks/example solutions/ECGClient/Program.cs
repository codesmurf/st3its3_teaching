using System.Collections.Concurrent;

namespace ECGClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ECG producer started.");
            Console.WriteLine("Press:");
            Console.WriteLine(" q : quit program");
            Console.WriteLine(" p : process list of samples");

            BlockingCollection<ECGReading> ecgReadings = new BlockingCollection<ECGReading>();
            IECGSensor sensor = new ECGSensor();

            ECGReadingProducer producer = new ECGReadingProducer(ecgReadings, sensor);
            SocketClient socketClient = new SocketClient(ecgReadings);

            Thread producerThread = new Thread(producer.Run);
            Thread clientThread = new Thread(socketClient.Run);

            producerThread.Start();
            clientThread.Start();

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
                }
            }

            producerThread.Join();
            clientThread.Join();
        }
    }
}