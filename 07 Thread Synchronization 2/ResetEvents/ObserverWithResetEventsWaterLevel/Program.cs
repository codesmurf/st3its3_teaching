namespace ObserverWithResetEventsWaterLevel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WaterLevelMonitor waterLevelMonitor = new WaterLevelMonitor();
            PumpController pumpController = new PumpController(waterLevelMonitor);

            Thread monitorThread = new Thread(waterLevelMonitor.Run);
            monitorThread.Name = "Monitor thread";
            Thread pumpThread = new Thread(pumpController.Run);
            pumpThread.Name = "Pump thread";

            monitorThread.Start();
            pumpThread.Start();

            monitorThread.Join();

            pumpController.ShallStop = true;

            pumpThread.Join();

        }
    }
}