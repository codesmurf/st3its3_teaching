namespace ResetEvents;

public class PumpController
{
    private readonly AutoResetEvent _waterLevelHighAutoResetEvent;

    public PumpController(AutoResetEvent waterLevelHighAutoResetEvent)
    {
        _waterLevelHighAutoResetEvent = waterLevelHighAutoResetEvent;
    }

    public void Run()
    {
        while (!ShallStop)
        {
            bool wasSet = _waterLevelHighAutoResetEvent.WaitOne(5000);
            if (wasSet)
            {
                Console.WriteLine("Event was set - Water level high.");
                Console.WriteLine("Running pump for 2 seconds.");
            }
            else
            {
                Console.WriteLine("Waiting timed out");
            }
        }
    }

    public bool ShallStop { get; set; }
}