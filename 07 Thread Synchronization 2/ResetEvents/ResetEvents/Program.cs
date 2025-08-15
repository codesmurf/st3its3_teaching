namespace ResetEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            AutoResetEvent dataReadyAutoResetEvent = new AutoResetEvent(false);

            WaterLevelMonitor waterLevelMonitor = new WaterLevelMonitor(dataReadyAutoResetEvent);
            PumpController pumpController = new PumpController(dataReadyAutoResetEvent);

            Thread producerThread = new Thread(waterLevelMonitor.Run);
            Thread consumerThread = new Thread(pumpController.Run);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();

            pumpController.ShallStop = true;
            consumerThread.Join();
        }
    }
}