using System.Collections.Concurrent;
using System.Threading;


namespace HospitalBed.PresenceSensing
{
    public class PresenceSensorControl
    {
        private const int SampleTime = 100;
        private readonly IPresenceSensor _presenceSensor;

        private readonly BlockingCollection<PresenceDataContainer> _presenceDataCollection;

        public PresenceSensorControl(BlockingCollection<PresenceDataContainer> presenceDataCollection, IPresenceSensor presenceSensor)
        {
            _presenceDataCollection = presenceDataCollection;
            _presenceSensor = presenceSensor;
        }


        public void Run()
        {
            while (true)
            {
                GetOneSenseorReading();
                Thread.Sleep(SampleTime);
            }
        }

        private void GetOneSenseorReading()
        {
            PresenceDataContainer container = new PresenceDataContainer();
            container.PresenceDetected = _presenceSensor.Sense();
            _presenceDataCollection.Add(container);

        }
    }
}