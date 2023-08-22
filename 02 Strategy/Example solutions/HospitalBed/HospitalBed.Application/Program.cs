using System;
using System.Threading;

namespace HospitalBed.Application
{
    class Program
    {
        static void Main()
        {
            var dataReadyEvent = new AutoResetEvent(false);
            var dataConsumedEvent = new AutoResetEvent(false);
            var container = new PresenceSensorDataContainer();

            var bedControl = new BedControl(dataConsumedEvent, dataReadyEvent, container,
                new Buzzer(),
                new NoiseFilter());

            var presenceSensor = new PresenceSensor(dataConsumedEvent, dataReadyEvent, container);

            var bedControlThread = new Thread(bedControl.Run);
            var presenceSensorThread = new Thread(presenceSensor.Run);

            bedControlThread.Start();
            presenceSensorThread.Start();


            // EYE CANDY: A simple console menu to change between filtering and alarming strategies
            var cont = true;
            Console.WriteLine("Control menu:");
            Console.WriteLine("-------------------");
            Console.WriteLine("[R]    Set raw filtering");
            Console.WriteLine("[N]    Set noise filtering");
            Console.WriteLine("[B]    Set buzzer alarm");
            Console.WriteLine("[L]    Set light alarm");

            while (cont)
            {
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'R':
                    case 'r':
                        bedControl.Filter = new RawFilter();
                        break;

                    case 'N':
                    case 'n':
                        bedControl.Filter = new NoiseFilter();
                        break;

                    case 'B':
                    case 'b':
                        bedControl.Alarm = new Buzzer();
                        break;

                    case 'L':
                    case 'l':
                        bedControl.Alarm = new Light();
                        break;

                    case 'q':
                    case 'Q':
                        cont = false;
                        break;
                }


            }
        }
    }
}

    

