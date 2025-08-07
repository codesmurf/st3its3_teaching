namespace ObserverWithResetEventsWaterLevel;

public abstract class WaterLevelSubject
{
    private readonly List<IWaterLevelObserver> _waterLevelObservers = new List<IWaterLevelObserver>();

    public void Attach(IWaterLevelObserver observer)
    {
        _waterLevelObservers.Add(observer);
    }

    public void Detach(IWaterLevelObserver observer)
    {
        _waterLevelObservers.Remove(observer);
    }

    protected void Notify(int waterLevel)
    {
        foreach (IWaterLevelObserver observer in _waterLevelObservers)
        {
            observer.Update(waterLevel);
        }
    }
}