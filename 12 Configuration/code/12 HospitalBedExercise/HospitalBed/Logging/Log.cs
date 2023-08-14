using System;
using HospitalBed.BedControl;

namespace HospitalBed.Logging
{
    public class Log : IPresenceObserver
    {
        private readonly IWriter _writer;
        private readonly BedControl.BedControl _patientPresenceSource;

        public Log(IWriter writer, BedControl.BedControl patientPresenceSource)
        {
            _writer = writer;
            _patientPresenceSource = patientPresenceSource;
            _patientPresenceSource.Attach(this);
        }

        public void Update()
        {
            var presence = _patientPresenceSource.CurrentPresenceState;
            if (presence == false)
                _writer.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() +
                               ": Patient has left the bed");
        }
    }
}