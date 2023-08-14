using System.Threading;
using HospitalBed.Filtering;
using HospitalBed.PresenceDetectorObserver;

namespace HospitalBed
{
    public class BedControl : PresenceDetectorSubject
    {
        private readonly AutoResetEvent _sensorDataConsumedEvent;
        private readonly AutoResetEvent _sensorDataReadyEvent;
        private readonly PresenceSensorDataContainer _presenceSensorDataContainer;
        public bool CurrentPresenceState = false;
        public IFilter Filter { private get; set; }
        
        public BedControl(AutoResetEvent sensorDataConsumedEvent, AutoResetEvent sensorDataReadyEvent, PresenceSensorDataContainer presenceSensorDataContainer, IFilter filter)
        {
            _sensorDataConsumedEvent = sensorDataConsumedEvent;
            _sensorDataReadyEvent = sensorDataReadyEvent;
            _presenceSensorDataContainer = presenceSensorDataContainer;
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

            var newPresenceState = Filter.FilterSample(presenceData);
            if (newPresenceState != CurrentPresenceState)
            {
                CurrentPresenceState = newPresenceState;
                Notify();
            }
        }
    }
}
