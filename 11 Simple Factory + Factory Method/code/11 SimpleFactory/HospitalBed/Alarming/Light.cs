using System;

namespace HospitalBed.Alarming
{
    public class Light : IAlarm
    {
        private bool _isOn;

        public Light()
        {
            _isOn = false;
        }

        public void Sound()
        {
            if (!_isOn)
            {
                Console.WriteLine("Light is on");
                _isOn = true;
            }
            
        }

        public void Silence()
        {
            if (_isOn)
            {
                Console.WriteLine("Light is off");
                _isOn = false;
            }
        }
    }
}