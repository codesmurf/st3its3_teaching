namespace ObserverWithResetEventsWaterLevel;
public class WaterLevelMonitor : WaterLevelSubject
{
    private readonly Random _random = new Random();

    public void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            int waterLevel = _random.Next(0, 50);
            Console.WriteLine("Random value was: {0}", waterLevel);

            Notify(waterLevel);

            Thread.Sleep(1000);
        }
    }
}