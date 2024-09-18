using HospitalBed.Alarm;
using HospitalBed.Filter;
using HospitalBed.Observer;

namespace HospitalBed;

public class BedControl : PatientPresenceSubject, IBedControl
{
    public IFilter filter { get; set; } = new PassThrough();
    public bool PresenceDetected { get; private set; }

    public void HandleData(PresenceSensorDataContainer data)
    {
        PresenceDetected = filter.Filter(data.PresenceDetected);
        Notify();
    }
}