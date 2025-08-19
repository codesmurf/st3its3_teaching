using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    internal class PresenseFilter : IPresenseFilter
    {
        private bool isPresent = false; // has to choose a default value until enough samples are collected

        private int presenseCount = 0;

        public bool AddPresenseSample(bool presence)
        {
            if (presence)
            {
                presenseCount++;
            }
            else
            {
                presenseCount--;
            }

            if (presenseCount >= 3)
            {
                isPresent = true;
                presenseCount = 3;
            }
            else if (presenseCount < 1)
            {
                isPresent = false;
                presenseCount = 0;
            }
            
            return isPresent;
        }
    }
}
