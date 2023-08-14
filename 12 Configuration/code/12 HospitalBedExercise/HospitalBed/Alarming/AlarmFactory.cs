using System;

namespace HospitalBed.Alarming
{
    public class AlarmFactory
    {
        public static IAlarm CreateAlarm(string descriptor)
        {
            switch (descriptor.ToLower())
            {
                case "buzzer":
                    return new BuzzerAlarm();
                case "light":
                    return new LightAlarm();
                case "sms":
                    return new SMSAlarm();
                default:
                    throw new ArgumentException("Unknown alarm descriptor: " + descriptor);
            }
        }
    }
}