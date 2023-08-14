using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerDemo
{
    class JSonConfiguration
    {
        public static void Save(Configuration configuration, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration)); 
            serializer.WriteObject(fs, configuration);
            fs.Close();
        }

        public static Configuration Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
            Configuration configuration = (Configuration)serializer.ReadObject(fs);
            return configuration;
        }

    }
}
