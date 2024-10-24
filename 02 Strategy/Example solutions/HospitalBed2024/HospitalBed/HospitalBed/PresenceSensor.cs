using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HospitalBed
{
    public class PresenceSensor
    {
        private readonly IBedControl _bedControl;
        private readonly Random _random = new Random();

        public PresenceSensor(IBedControl bedControl)
        {
            _bedControl = bedControl;
        }

        private bool GetSample()
        {
            return Convert.ToBoolean(_random.Next(0, 2));  // 0 = false, 1 = true
        }

        public void ReadSample()
        {
            var presenceDetected = GetSample();
            _bedControl.HandleData(new PresenceSensorDataContainer()
            {
                PresenceDetected = presenceDetected
            });
        }
    }
}
