using System;
using System.Runtime.CompilerServices;

namespace ObserverExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Measurement measurement = new Measurement();
            Display display = new Display(measurement);
            Log log = new Log(measurement);

//            measurement.Attach(display); // Attach is called in the Log constructor. An alternative is to attach the Log (observer) to measurement (subject) here in main()

            measurement.Sys = 120;
            measurement.Dia = 80;
            measurement.Done();

            measurement.Detach(display);
            measurement.Sys = 130;
            measurement.Dia = 85;
            measurement.Done();

        }
    }
}
