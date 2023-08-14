using System.IO;
using System.Xml.Serialization;

namespace SerializerDemo
{
    class XmlConfiguration
    {
        public static void Save(Configuration configuration, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            serializer.Serialize(fs, configuration);
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
