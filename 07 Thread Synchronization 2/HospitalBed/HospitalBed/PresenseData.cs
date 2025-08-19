namespace HospitalBed
{
    internal class PresenseData
    {
        private bool patientPresent = false;

        public void SetPresense(bool presence)
        {
            patientPresent = presence;
        }

        public bool GetPresense()
        {
            return patientPresent;
        }
    }
}