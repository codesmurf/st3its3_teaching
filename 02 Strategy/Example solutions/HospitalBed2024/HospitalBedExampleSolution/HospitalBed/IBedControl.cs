namespace HospitalBed;

public interface IBedControl
{
    public IAlarmMethod AlarmMethod { set; }
    public IFilter Filter { set; }

    void HandleData(PresenceSensorDataContainer data);
}