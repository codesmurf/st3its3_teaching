using HospitalBed.BedControl;

namespace HospitalBed.Alarming
{
    public class AlarmControl : IPresenceObserver
    {
        private readonly BedControl.BedControl _patientPresenceSource;
        public IAlarm AlarmMethod { private get; set; }

        public AlarmControl(IAlarm alarm, BedControl.BedControl patientPresenceSource)
        {
            AlarmMethod = alarm;
            patientPresenceSource.Attach(this);
            _patientPresenceSource = patientPresenceSource;
        }

        public void Update()
        {
            if (_patientPresenceSource.CurrentPresenceState == false) AlarmMethod.Sound();
            else AlarmMethod.Silence();
        }
    }
}