namespace ObserverWithResetEventsWaterLevel;

public class PumpController : IWaterLevelObserver
{
    private readonly AutoResetEvent _waterLevelHighAutoResetEvent = 
        new AutoResetEvent(false);
    private int _waterLevel;
    private readonly object _waterLevelLockObject = new object();

    public PumpController(WaterLevelSubject subject)
    {
        subject.Attach(this);
    }

    public void Update(int waterLevel)
    {
        WaterLevel = waterLevel;
        Console.WriteLine("{0}: Setting event", Thread.CurrentThread.Name);
        _waterLevelHighAutoResetEvent.Set();
    }

    public void Run()
    {
        while (!ShallStop)
        {
            bool wasSet = _waterLevelHighAutoResetEvent.WaitOne(5000);
            if (wasSet)
            {
                Console.WriteLine("{0}: Done waiting - Water level: {1}", Thread.CurrentThread.Name, WaterLevel);
                Console.WriteLine("Running pump for 2 seconds.");
            }
            else
            {
                Console.WriteLine("Waiting timed out");
            }
        }
    }

    public bool ShallStop { get; set; }
    public int WaterLevel
    {
        get
        {
            lock (_waterLevelLockObject)
            {
                return _waterLevel;
            }
        }
        set
        {
            lock (_waterLevelLockObject)
            {
                _waterLevel = value;
            }
        }
    }

}