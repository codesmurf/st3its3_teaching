using System.Collections.Concurrent;

namespace HospitalBed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            BlockingCollection<PresenseData> presenseDataQueue = new BlockingCollection<PresenseData>();

            PresenseSensor sensor = new PresenseSensor();
            PresenseDataProvider provider = new PresenseDataProvider(sensor, presenseDataQueue);
            PresenseFilter presenseFilter = new PresenseFilter();   

            PatientMonitor monitor = new PatientMonitor(presenseDataQueue, presenseFilter);

            Thread producerThread = new Thread(provider.Run);
            Thread consumerThread = new Thread(monitor.Run);

            producerThread.Start();
            consumerThread.Start();

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
            
            provider.StopThread();
            producerThread.Join();
            consumerThread.Join();
            Console.WriteLine("Threads stopped. Exiting application.");
        }
    }
}
