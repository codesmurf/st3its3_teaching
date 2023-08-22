using System;

namespace HospitalBedLib.Buzzers
{
    public class Buzzer : IBuzzer
    {
        public void Buzz()
        {
            Console.WriteLine("Buzz");
        }
    }
}
