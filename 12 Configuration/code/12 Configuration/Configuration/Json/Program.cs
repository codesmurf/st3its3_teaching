using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmSettings alarmSettings = new AlarmSettings
            {
                Locale = "DK",
                TimeFormat = AlarmSettings.TimeFormatEnum.H12,
                AlarmIsOn = false,
            };
            
            string filename = "settings.json";
             string jsona = JsonSerializer.Serialize(alarmSettings);
             File.WriteAllText(filename, jsona);

            try
            {
                string text = File.ReadAllText(filename);
                AlarmSettings alarmSettingsCopy =
                    JsonSerializer.Deserialize<AlarmSettings>(text);
            }
            catch (Exception e)
            {
                string oldFilename = filename + ".custom";
                // Preserver customers file
                File.Move(filename, oldFilename);
                // Save new configuration
                string json = JsonSerializer.Serialize(alarmSettings);
                File.WriteAllText(filename, json);
                // Notify customer
                Console.WriteLine("Configuration file invalid, new file created. Old file can be found at: " + oldFilename);
                return;
            }

            //
            List<AlarmSettings> alarms = new List<AlarmSettings>
            {
                alarmSettings,
                new AlarmSettings
                {
                    Locale = "DK",
                    TimeFormat = AlarmSettings.TimeFormatEnum.H24,
                    AlarmIsOn = true,
                }
            };

            NestedConfigurations nestedConfigurations = new NestedConfigurations
            {
                alarms = alarms
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string path = "list.json"; 
            string jsonList = JsonSerializer.Serialize(alarms, options);
            File.WriteAllText(path, jsonList);

        }
    }
}
