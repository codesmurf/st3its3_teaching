using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    internal class PresenseSensor : IPresenseSensor
    {
        private readonly Random random = new Random();

        public bool IsPresent()
        {

            // Simulate presence detection with a 50% chance
            return random.Next(0, 2) == 1;
        }
    }
}
