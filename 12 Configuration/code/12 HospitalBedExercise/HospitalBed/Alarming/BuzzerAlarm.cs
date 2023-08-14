using System;

namespace HospitalBed.Alarming
{
    public class BuzzerAlarm : IAlarm
    {
        private bool _isOn;

        public void Sound()
        {
            if (!_isOn)
            {
                Console.WriteLine("BZZZZZZZZZ BZZZZZZZZZZ BZZZZZZZZZZ!");
                _isOn = true;
            }
        }

        public void Silence()
        {
            if (_isOn)
            {
                Console.WriteLine("*silence*");
                _isOn = false;
            }
        }
    }
}