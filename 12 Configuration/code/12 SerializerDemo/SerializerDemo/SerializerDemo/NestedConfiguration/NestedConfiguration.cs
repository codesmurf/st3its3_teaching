using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerDemo
{
    public class NestedConfiguration
    {
        public NestedConfiguration()
        {
            // default values
            TimeFormat = TimeFormatEnum.H12;
            Locale = "DK";
            
            Alarms.Add(new AlarmConfiguration(6, 20, true));
            Alarms.Add(new AlarmConfiguration(6, 30, false));
            Alarms.Add(new AlarmConfiguration(9, 20, true));
        }

        public enum TimeFormatEnum
        {
            H12,
            H24
        };

        public TimeFormatEnum TimeFormat { get; set; }

        public string Locale { get; set; }

        public List<AlarmConfiguration> Alarms { get; set; } = new List<AlarmConfiguration>();
    }
}
