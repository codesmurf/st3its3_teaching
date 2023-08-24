namespace HospitalBed.Observer;

public class PatientPresenceSubject
{
    private List<IObserver> _observers;

    public PatientPresenceSubject()
    {
        _observers = new List<IObserver>();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}