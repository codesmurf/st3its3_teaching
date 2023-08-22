using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedLib.Sensors
{
    public class RandomSensor : ISensor
    {
        private readonly Random random = new Random();

        public bool IsPressed()
        {
            return random.Next(2) == 1;
        }
    }
}
