using System.Collections.Concurrent;

namespace ECGServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ECG Monitor server started.");
            Console.WriteLine("Press:");
            Console.WriteLine(" q : quit program");
            Console.WriteLine(" p : process list of samples");

            BlockingCollection<ECGReading> ecgReadings = new BlockingCollection<ECGReading>();
            ECGContainer ecgContainer = new ECGContainer();

            ECGReadingConsumer consumer = new ECGReadingConsumer(ecgReadings, ecgContainer);
            SocketServer socketServer = new SocketServer(ecgReadings);

            Thread serverThread = new Thread(socketServer.Run);
            Thread consumerThread = new Thread(consumer.Run);

            serverThread.Start();
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
                        socketServer.ShallStop = true;
                    }
                        break;
                    case 'p':
                    {
                        ecgContainer.ProcessSamples();
                    }
                        break;
                }
            }

            serverThread.Join();
            consumerThread.Join();
        }
    }
}