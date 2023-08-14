using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerDemo
{
    public class AlarmConfiguration
    {
        public AlarmConfiguration(int hour, int minute, bool active)
        {
            Hour = hour;
            Minute = minute;
            Active = active;
        }

        public AlarmConfiguration()
        {
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public bool Active { get; set; }
    }
}
