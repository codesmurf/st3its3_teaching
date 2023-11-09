using System.Collections.Concurrent;
using ECGServer.Data;

namespace ECGServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ECG Monitor server started.");
            Console.WriteLine("Press:");
            Console.WriteLine(" q : quit program");
            Console.WriteLine(" p : process list of samples");

            BlockingCollection<ECGReading> ecgReadings = new BlockingCollection<ECGReading>();
            CPRServerHandler cprServerHandler = new CPRServerHandler("https://localhost:7077/");
            EcgServerHandler ecgServerHandler = new EcgServerHandler("https://localhost:7091/");

            SocketServer socketServer = new SocketServer(ecgReadings);

            Thread serverThread = new Thread(socketServer.Run);
            serverThread.Start();
            Thread.Sleep(10);

            Console.WriteLine("Type in CPR number:");
            string cpr = Console.ReadLine();
            var patient = await cprServerHandler.GetPatient(cpr);
            var statusCode = await ecgServerHandler.AddPerson(patient);

            ECGContainer ecgContainer = new ECGContainer(cpr);
            ECGReadingConsumer consumer = new ECGReadingConsumer(ecgReadings, ecgContainer, ecgServerHandler);
            Thread consumerThread = new Thread(consumer.Run);
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