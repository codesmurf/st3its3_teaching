using System.Threading;

namespace HospitalBed
{
    public class BedControl
    {
        private readonly AutoResetEvent _sensorDataConsumedEvent;
        private readonly AutoResetEvent _sensorDataReadyEvent;
        private readonly PresenceSensorDataContainer _presenceSensorDataContainer;
        private IFilter _filter = new NoiseFilter();
        private Buzzer _buzzer = new Buzzer();

        public BedControl(AutoResetEvent sensorDataConsumedEvent, AutoResetEvent sensorDataReadyEvent, PresenceSensorDataContainer presenceSensorDataContainer)
        {
            _sensorDataConsumedEvent = sensorDataConsumedEvent;
            _sensorDataReadyEvent = sensorDataReadyEvent;
            _presenceSensorDataContainer = presenceSensorDataContainer;
        }

        public void SetFilter(IFilter filter)
        {
            _filter = filter;
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

            if (_filter.FilterSample(presenceData))
            {
                _buzzer.Silence();
            }
            else
            {
                _buzzer.Sound();
            }
        }
    }
}
