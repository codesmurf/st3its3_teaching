namespace HospitalBed
{
    public class Buzzer : IAlarmMethod
    {
        public void StartAlarm()
        {
            Console.WriteLine("Buzzer alarm");
        }

        public void StopAlarm()
        {
            Console.WriteLine("Buzzer no alarm");
        }
    }
}