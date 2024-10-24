namespace HospitalBed
{
    public class Light : IAlarmMethod
    {
        public void StartAlarm()
        {
            Console.WriteLine("Light alarm");
        }

        public void StopAlarm()
        {
            Console.WriteLine("Light no alarm");
        }
    }
}
