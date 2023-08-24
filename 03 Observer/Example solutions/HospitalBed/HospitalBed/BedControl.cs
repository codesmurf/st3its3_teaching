using HospitalBed.Alarm;
using HospitalBed.Filter;
using HospitalBed.Observer;

namespace HospitalBed;

public class BedControl : PatientPresenceSubject, IBedControl
{
    public IFilter filter { get; set; } = new PassThrough();
    public PresenceSensorDataContainer data { get; private set; }

    public void HandleData(PresenceSensorDataContainer data)
    {
        this.data = data;
        Notify();
    }
}