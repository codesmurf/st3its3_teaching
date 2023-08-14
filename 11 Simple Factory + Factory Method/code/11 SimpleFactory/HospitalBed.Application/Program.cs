using System.Threading;
using HospitalBed.SimpleFactory;

namespace HospitalBed.Application
{
    class Program
    {
        static void Main()
        {
            var dataReadyEvent = new AutoResetEvent(false);
            var dataConsumedEvent = new AutoResetEvent(false);
            var container = new PresenceSensorDataContainer();


            // ********************************************************************
            // SIMPLE FACTORY ADDITIONS START
            // Read configuration from file
            var systemConfigurationStrings = System.IO.File.ReadAllLines(@"..\..\hospitalbedconfig.txt");
            var filterConfigString = systemConfigurationStrings[0];
            var alarmConfigString = systemConfigurationStrings[1];

            // Use simple factories' static methods to create filter and alarm instances
            var filter = FilterFactory.CreateFilter(filterConfigString);
            var alarm = AlarmFactory.CreateAlarm(alarmConfigString);
            // SIMPLE FACTORY ADDITIONS END
            // ********************************************************************


            // Initialize system. 
            var bedControl = new BedControl(dataConsumedEvent, dataReadyEvent, container, filter);
            var alarming = new Alarming.AlarmController(alarm, bedControl);  // This should hook "alarming" up as an observer of "bedcontrol"

            var presenceSensor = new PresenceSensor(dataConsumedEvent, dataReadyEvent, container);

            var bedControlThread = new Thread(bedControl.Run);
            var presenceSensorThread = new Thread(presenceSensor.Run);

            bedControlThread.Start();
            presenceSensorThread.Start();

        }
    }
}
