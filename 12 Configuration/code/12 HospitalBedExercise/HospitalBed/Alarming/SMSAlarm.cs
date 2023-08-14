using System;

namespace HospitalBed.Alarming
{
    internal class SMSAlarm : IAlarm
    {
        public void Sound()
        {
            Console.WriteLine("SMS: Elvis has left the building");
        }

        public void Silence()
        {
            Console.WriteLine("SMS: Elvis is back in bed");
        }
    }
}