using System.IO;
using System.Xml.Serialization;

namespace HospitalBed.System
{
    public class Configuration
    {
        public Configuration()
        {
            FilterType = "raw";
            AlarmType = "buzzer";
            LogWriterType = "console";
            PresenceSensorType = "random";
        }

        public string FilterType;
        public string AlarmType;
        public string LogWriterType;
        public string PresenceSensorType;
    }

    public class ConfigurationSerialization
    {
        public static void Save(string path, Configuration config)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            serializer.Serialize(fs, config);
            fs.Close();
        }

        public static Configuration Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            Configuration configuration = (Configuration)serializer.Deserialize(fs);
            return configuration;
        }
    }
}
