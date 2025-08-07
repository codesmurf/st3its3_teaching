using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverExample
{
    internal class Display : IBloodPressureObserver
    {
        private readonly Measurement _measurement;

        public Display(Measurement measurement)
        {
            _measurement = measurement;
            _measurement.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("Display Update called");
            int dia = _measurement.Dia;
            int sys = _measurement.Sys;
            Console.WriteLine("Dia: {0} - Sys: {1}", dia, sys);
        }
    }
}
