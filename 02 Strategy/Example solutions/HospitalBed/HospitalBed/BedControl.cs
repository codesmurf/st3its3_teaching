using System.Threading;

namespace HospitalBed
{
    public class BedControl
    {
        private readonly AutoResetEvent _sensorDataConsumedEvent;
        private readonly AutoResetEvent _sensorDataReadyEvent;
        private readonly PresenceSensorDataContainer _presenceSensorDataContainer;
        public IFilter Filter { private get; set; }
        public IAlarm Alarm { private get; set; }

        public BedControl(AutoResetEvent sensorDataConsumedEvent, AutoResetEvent sensorDataReadyEvent, PresenceSensorDataContainer presenceSensorDataContainer, IAlarm alarm, IFilter filter)
        {
            _sensorDataConsumedEvent = sensorDataConsumedEvent;
            _sensorDataReadyEvent = sensorDataReadyEvent;
            _presenceSensorDataContainer = presenceSensorDataContainer;
            Alarm = alarm;
            Filter = filter;
        }


        public void Run()
        {
            while (true)
            {
                HandleOneSample();
            }
        }

        public void HandleOneSample()
        {
            _sensorDataReadyEvent.WaitOne();
            var presenceData = _presenceSensorDataContainer.PresenceDetected;
            _sensorDataConsumedEvent.Set();

            if (Filter.FilterSample(presenceData))
            {
                Alarm.TurnOff();
            }
            else
            {
                Alarm.TurnOn();
            }
        }
    }
}
