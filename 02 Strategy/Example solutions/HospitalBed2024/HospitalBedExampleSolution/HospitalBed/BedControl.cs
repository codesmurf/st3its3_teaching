namespace HospitalBed
{
    public class BedControl : IBedControl
    {
        private IAlarmMethod alarmMethod;
        private IFilter filter = new PassThroughFilter();

        public BedControl(IAlarmMethod alarmMethod)
        {
            this.alarmMethod = alarmMethod;
        }

        public IAlarmMethod AlarmMethod { private get => alarmMethod; set => alarmMethod = value; }
        public IFilter Filter { private get => filter; set => filter = value; }

        public void HandleData(PresenceSensorDataContainer data)
        {
            bool presenceDetected = data.PresenceDetected;

            bool filteredPresense = Filter.Filter(presenceDetected);

            if (filteredPresense)
            {
                AlarmMethod.StartAlarm();
            }
            else
            {
                AlarmMethod.StopAlarm();
            }

        }
    }
}