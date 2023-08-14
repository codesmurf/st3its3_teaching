namespace Json
{
    public class AlarmSettings
    {
        public enum TimeFormatEnum
        {
            H12,
            H24
        }
        public TimeFormatEnum TimeFormat { get; set; }
        public bool AlarmIsOn { get; set; }
        public string Locale { get; set; }
    }
}