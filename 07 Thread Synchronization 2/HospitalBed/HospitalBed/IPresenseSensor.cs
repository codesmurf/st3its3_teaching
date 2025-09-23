using System.Diagnostics;

namespace HospitalBed
{
    internal interface IPresenseSensor
    {
        // True if the patient is present, false otherwise
        public bool IsPresent();
    }
}