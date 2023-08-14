using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.PresenceDetectorObserver;
using HospitalBed.SimpleFactory;

namespace HospitalBed.Alarming
{
    public class AlarmController : IPresenceDetectorObserver
    {
        public IAlarm AlarmMethod { private get; set; }
    
        private readonly BedControl _patientPresenceSource;
        public AlarmController(IAlarm alarm, BedControl patientPresenceSource)
        {
            AlarmMethod = alarm;
            patientPresenceSource.Attach(this);
            _patientPresenceSource = patientPresenceSource;
        }

        public void Update()
        {
            if(_patientPresenceSource.CurrentPresenceState) AlarmMethod.Sound();
            else AlarmMethod.Silence();
        }
    }
}
