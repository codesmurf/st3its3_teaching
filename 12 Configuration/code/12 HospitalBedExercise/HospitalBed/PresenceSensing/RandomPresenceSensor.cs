using System;

namespace HospitalBed.PresenceSensing
{
    public class RandomPresenceSensor : IPresenceSensor
    {
        private readonly Random _random = new Random();

        public bool Sense()
        {
            return Convert.ToBoolean(_random.Next(0, 2)); // 0 = false, 1 = true
        }

    }
}