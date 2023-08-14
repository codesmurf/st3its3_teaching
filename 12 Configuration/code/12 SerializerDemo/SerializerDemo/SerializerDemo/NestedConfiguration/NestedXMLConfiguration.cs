using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerDemo
{
    class NestedXMLConfiguration
    {
        public static void Save(NestedConfiguration configuration, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(NestedConfiguration));
            serializer.Serialize(fs, configuration);
            fs.Close();
        }

        public static NestedConfiguration Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NestedConfiguration));
                NestedConfiguration configuration = (NestedConfiguration)serializer.Deserialize(fs);
                return configuration;
            }
        }

    }
}
