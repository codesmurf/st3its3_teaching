using System;

namespace HospitalBed.Alarming
{
    public class LightAlarm : IAlarm
    {
        private bool _isOn;

        public LightAlarm()
        {
            _isOn = false;
        }

        public void Sound()
        {
            if (!_isOn)
            {
                Console.WriteLine("Alarm light is on: Elvis has left the building!");
                _isOn = true;
            }
        }

        public void Silence()
        {
            if (_isOn)
            {
                Console.WriteLine("Alarm light is off: Elvis is back in bed!");
                _isOn = false;
            }
        }
    }
}