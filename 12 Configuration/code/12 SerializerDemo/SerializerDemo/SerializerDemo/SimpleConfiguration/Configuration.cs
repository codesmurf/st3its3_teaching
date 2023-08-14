namespace SerializerDemo
{
    // This is the top class for the configuration
    public class Configuration
    {
        public Configuration()
        {
            // default values
            TimeFormat = TimeFormatEnum.H12;
            AlarmIsOn = false;
            Locale = "DK";
        }

        public enum TimeFormatEnum
        {
            H12,
            H24
        };

        public TimeFormatEnum TimeFormat { get; set; }

        public bool AlarmIsOn { get; set; }

        public string Locale { get; set; }
    }
}
