using System;

namespace HospitalBed.PresenceSensing
{
    public class PresenceSensorFactory
    {
        public static IPresenceSensor CreatePresenceSensor(string presenceSensorType)
        {
            if(presenceSensorType == "random")
                return new RandomPresenceSensor();
            throw new ArgumentException("Unknown presence sensor type: " + presenceSensorType);
        }
    }
}