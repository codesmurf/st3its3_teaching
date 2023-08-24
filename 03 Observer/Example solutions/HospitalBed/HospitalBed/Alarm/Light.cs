namespace HospitalBed.Alarm;

public class Light : IAlarm
{
    public void Alarm(bool on)
    {
        if (on)
        {
            Console.WriteLine("Light on");
        }
        else
        {
            Console.WriteLine("Light off");
        }
    }
}