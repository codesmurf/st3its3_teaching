using System;

namespace HospitalBed
{
    public class Buzzer : IAlarm
    {
        private bool _isOn = false;

        public void TurnOn()
        {
            if (!_isOn)
            {
                Console.WriteLine("BZZZZZZZZZ BZZZZZZZZZZ BZZZZZZZZZZ!");
                _isOn = true;
            }
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                Console.WriteLine("*silence*");
                _isOn = false;
            }

        }
    }
}
