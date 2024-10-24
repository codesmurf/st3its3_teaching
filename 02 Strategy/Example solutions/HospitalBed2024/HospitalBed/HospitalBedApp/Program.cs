using HospitalBed;
using System.ComponentModel;

namespace HospitalBedApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            IBedControl bedControl = new BedControl();

            HospitalBed.PresenceSensor sensor = new HospitalBed.PresenceSensor(bedControl);

            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.KeyChar)
                {
                    case 'b':
                    case 'B':
                        break;
                    case 'l':
                    case 'L':
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
}
