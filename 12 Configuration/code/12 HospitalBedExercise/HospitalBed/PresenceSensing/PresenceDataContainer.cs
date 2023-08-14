namespace HospitalBed.PresenceSensing
{
    public class PresenceDataContainer
    {
        public PresenceDataContainer()
        {
            PresenceDetected = false;
        }

        public bool PresenceDetected { get; set; }
    }
}