namespace HospitalBed.Alarm;

public class Buzzer : IAlarm
{
    public void Alarm(bool on)
    {
        if (on)
        {
            Console.WriteLine("Buzzing");
        }
        else
        {
            Console.WriteLine("No Buzz");
        }
    }
}