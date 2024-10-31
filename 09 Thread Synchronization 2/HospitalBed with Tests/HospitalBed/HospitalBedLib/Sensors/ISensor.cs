using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedLib.Sensors
{
    public interface ISensor
    {
        bool IsPressed();
    }
}
