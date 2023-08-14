namespace HospitalBed.Alarming
{
    class SMSAlarm : IAlarm
    {
        public void Sound()
        {
            System.Console.WriteLine("SMS: Elvis has left the building");
        }

        public void Silence()
        {
            System.Console.WriteLine("SMS: Elvis is back in bed");
        }
    }
}