using System.Collections.Concurrent;
using HospitalBed.Filtering;
using HospitalBed.PresenceSensing;

namespace HospitalBed.BedControl
{
    public class BedControl : PresenceSubject
    {
        
        public bool CurrentPresenceState;
        public IFilter Filter { private get; set; }

        private readonly BlockingCollection<PresenceDataContainer> _presenceSensorDataCollection;

        public BedControl(BlockingCollection<PresenceDataContainer> presenceSensorDataCollection, IFilter filter)
        {
            _presenceSensorDataCollection = presenceSensorDataCollection;
            Filter = filter;
        }


        public void Run()
        {
            while (true)
            {
                PresenceDataContainer container = _presenceSensorDataCollection.Take();
                HandleOneSample(container.PresenceDetected);
            }
        }

        public void HandleOneSample(bool presence)
        {
            var newPresenceState = Filter.FilterSample(presence);
            if (newPresenceState != CurrentPresenceState)
            {
                CurrentPresenceState = newPresenceState;
                Notify();
            }
        }
    }
}