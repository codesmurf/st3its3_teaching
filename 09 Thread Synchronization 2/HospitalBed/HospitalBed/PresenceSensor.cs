using System;
using System.Threading;

namespace HospitalBed
{
    public class PresenceSensor
    {
        private readonly AutoResetEvent _sensorDataConsumedEvent;
        private readonly AutoResetEvent _sensorDataReadyEvent;
        private readonly PresenceSensorDataContainer _presenceSensorDataContainer;
        private readonly Random _random = new Random();

        private const int SampleTime = 100;

        public PresenceSensor(AutoResetEvent sensorDataConsumedEvent, AutoResetEvent sensorDataReadyEvent, PresenceSensorDataContainer presenceSensorDataContainer)
        {
            _sensorDataConsumedEvent = sensorDataConsumedEvent;
            _sensorDataReadyEvent = sensorDataReadyEvent;
            _presenceSensorDataContainer = presenceSensorDataContainer;
        }

        private bool GetSample()
        {
            return Convert.ToBoolean(_random.Next(0, 2));  // 0 = false, 1 = true
        }

        public void Run()
        {
            while (true)
            {
                _presenceSensorDataContainer.PresenceDetected = GetSample();
                _sensorDataReadyEvent.Set();
                Thread.Sleep(SampleTime);
                _sensorDataConsumedEvent.WaitOne();
            }
        }

    }
}
