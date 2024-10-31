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

            var bedControl = new BedControl(dataConsumedEvent, dataReadyEvent, container);

            var presenceSensor = new PresenceSensor(dataConsumedEvent, dataReadyEvent, container);

            var bedControlThread = new Thread(bedControl.Run);
            bedControlThread.IsBackground = true;
            var presenceSensorThread = new Thread(presenceSensor.Run);
            presenceSensorThread.IsBackground = true;

            bedControlThread.Start();
            presenceSensorThread.Start();


            var cont = true;
            Console.WriteLine("Control menu:");
            Console.WriteLine("-------------------");
            Console.WriteLine("[Q]    Quit");

            while (cont)
            {
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'q':
                    case 'Q':
                    {
                        cont = false;
                    }
                    break;
                    case '1':
                    {
                        bedControl.SetFilter(new PassthroughFilter());
                    }
                        break;
                    case '2':
                    {
                        bedControl.SetFilter(new NoiseFilter());
                    }
                        break;
                }
            }
        }
    }
}

    

