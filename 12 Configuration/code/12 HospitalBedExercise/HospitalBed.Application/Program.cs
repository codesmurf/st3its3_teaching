using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using HospitalBed.Alarming;
using HospitalBed.Filtering;
using HospitalBed.Logging;
using HospitalBed.PresenceSensing;
using HospitalBed.System;

namespace HospitalBed.Application
{
    internal class Program
    {
        private static void Main()
        {
            // Read configuration from file
            var systemConfiguration = ConfigurationSerialization.Load(@"..\..\hospitalbedconfig.xml");

            // Use simple factories' static methods to create filter and alarm instances
            var filter = FilterFactory.CreateFilter(systemConfiguration.FilterType);
            var alarm = AlarmFactory.CreateAlarm(systemConfiguration.AlarmType);
            var writer = WriterFactory.CreateWriter(systemConfiguration.LogWriterType);
            var presenceSensor = PresenceSensorFactory.CreatePresenceSensor(systemConfiguration.PresenceSensorType);

            var presenceDataCollection = new BlockingCollection<PresenceDataContainer>();

            // Initialize system
            var bedControl = new BedControl.BedControl(presenceDataCollection, filter);
            var alarmControl = new AlarmControl(alarm, bedControl); // Hook up "alarming" as an observer of "bedControl"
            var log = new Log(writer, bedControl);                 // Hook up "log" as an observer of "bedControl"
            var presenceSensorControl = new PresenceSensorControl(presenceDataCollection, presenceSensor);


            // Run system
            var bedControlThread = new Thread(bedControl.Run);
            var presenceSensorThread = new Thread(presenceSensorControl.Run);
            bedControlThread.Start();
            presenceSensorThread.Start();
        }
    }
}