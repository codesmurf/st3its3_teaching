namespace HospitalBed;

public interface IBedControl
{
    void HandleData(PresenceSensorDataContainer data);
}