using System;
using System.IO;

namespace SerializerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            Configuration configuration = new Configuration();
            string configPath = Path.Combine(currentDirectory, "configuration.xml");
            XmlConfiguration.Save(configuration, configPath);

            NestedConfiguration nestedConfiguration = new NestedConfiguration();
            string nestedXMLConfigPath = Path.Combine(currentDirectory, "nested-configuration.xml");
            NestedXMLConfiguration.Save(nestedConfiguration, nestedXMLConfigPath);

            // example of how to load the simple configuration
            configuration = XmlConfiguration.Load(configPath);
            nestedConfiguration = NestedXMLConfiguration.Load(nestedXMLConfigPath);

            // and comment out the xml configuration above and
            // uncomment the lines below, if you want to see how the JSON configuration works.
            //string jsonConfigPath = Path.Combine(currentDirectory, "configuration.json");
            //JSonConfiguration.Save(configuration, jsonConfigPath);
            //configuration = JSonConfiguration.Load(jsonConfigPath);

            Console.WriteLine("Loaded configuration: ");
            Console.WriteLine("  TimeFormat: {0}", configuration.TimeFormat);
            Console.WriteLine("  AlarmIsOn: {0}", configuration.AlarmIsOn);
            Console.WriteLine("  Locale: {0}", configuration.Locale);

            Console.ReadKey();
        }
    }
}
