using System;
using HospitalBed.Alarming;

namespace HospitalBed.SimpleFactory
{
    public class AlarmFactory
    {
        public static IAlarm CreateAlarm(string descriptor)
        {
            if (descriptor == "Buzzer") return new Buzzer();
            if (descriptor == "Light") return new Light();
            if (descriptor == "SMS") return new SMSAlarm();
            throw new ArgumentException("Unknown alarm descriptor: " + descriptor);
        }
    }
}