using System;

namespace HospitalBed.Application
{
    public class Light : IAlarm
    {
        private bool _isOn;

        public Light()
        {
            _isOn = false;
        }

        public void TurnOn()
        {
            if (!_isOn)
            {
                Console.WriteLine("Light is on");
                _isOn = true;
            }
            
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                Console.WriteLine("Light is off");
                _isOn = false;
            }
        }
    }
}