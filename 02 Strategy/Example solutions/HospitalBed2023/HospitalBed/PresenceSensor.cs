using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HospitalBed
{
    internal class PresenceSensor
    {
        private readonly IBedControl _bedControl;
        private readonly Random _random = new Random();
        public bool Running { get; set; } = true;

        private const int SampleTime = 100;

        public PresenceSensor(IBedControl bedControl)
        {
            _bedControl = bedControl;
        }

        private bool GetSample()
        {
            return Convert.ToBoolean(_random.Next(0, 2));  // 0 = false, 1 = true
        }

        public void Run()
        {
            while (Running)
            {
                var presenceDetected = GetSample();
                _bedControl.HandleData(new PresenceSensorDataContainer()
                {
                    PresenceDetected = presenceDetected
                });
                Thread.Sleep(SampleTime);
            }
        }
    }
}
