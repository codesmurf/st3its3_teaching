using HospitalBed;

namespace HospitalBedApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome");
        Console.WriteLine("Press:");
        Console.WriteLine(" s - generate 1 sample from the sensor");
        Console.WriteLine(" b - use buzzer");
        Console.WriteLine(" l - use light");
        Console.WriteLine(" n - use noise filter");
        Console.WriteLine(" p - use passthrough filter");
        Console.WriteLine(" x - exit program");
        Console.WriteLine(" ");

        IAlarmMethod buzzer = new Buzzer();
        IAlarmMethod light = new Light();
        IBedControl bedControl = new BedControl(buzzer);

        NoiseFilter noiseFilter = new NoiseFilter();
        PassThroughFilter passThroughFilter = new PassThroughFilter();

        HospitalBed.PresenceSensor sensor = new HospitalBed.PresenceSensor(bedControl);

        while (true)
        {
            var consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.KeyChar)
            {
                case 's':
                case 'S':
                    sensor.ReadSample();
                    break;
                case 'b':
                case 'B':
                    Console.WriteLine("Alarm switched to buzzer");
                    bedControl.AlarmMethod = buzzer;
                    break;
                case 'l':
                case 'L':
                    Console.WriteLine("Alarm switched to light");
                    bedControl.AlarmMethod = light;
                    break;
                case 'n':
                case 'N':
                    Console.WriteLine("Using noisefilter");
                    bedControl.Filter = noiseFilter;
                    break;
                case 'p':
                case 'P':
                    Console.WriteLine("Using passthrough filter");
                    bedControl.Filter = passThroughFilter;
                    break;
                case 'x':
                case 'X':
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
