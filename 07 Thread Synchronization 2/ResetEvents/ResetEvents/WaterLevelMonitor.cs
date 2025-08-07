namespace ResetEvents;

public class WaterLevelMonitor
{
    private readonly AutoResetEvent _waterLevelHighAutoResetEvent;
    private readonly Random _random = new Random();

    public WaterLevelMonitor(AutoResetEvent waterLevelHighAutoResetEvent)
    {
        _waterLevelHighAutoResetEvent = waterLevelHighAutoResetEvent;
    }

    public void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomValue = _random.Next(0, 2);
            Console.WriteLine("Random value was: {0}", randomValue);
            if (randomValue > 0)
            {
                _waterLevelHighAutoResetEvent.Set();
            }
            Thread.Sleep(1000);
        }
    }
}