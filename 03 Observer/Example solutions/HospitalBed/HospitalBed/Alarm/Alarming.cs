using HospitalBed.Observer;

namespace HospitalBed.Alarm;

public class Alarming : IObserver
{
    public IAlarm Alarm { get; set; } = new Buzzer();
    private BedControl _bedControl;

    public Alarming(BedControl bedControl)
    {
        _bedControl = bedControl;
        _bedControl.Attach(this);
    }


    public void Update()
    {
        Alarm.Alarm(_bedControl.PresenceDetected);
    }
}