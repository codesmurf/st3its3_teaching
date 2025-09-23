using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverExample
{
    internal class Log : IBloodPressureObserver
    {
        private readonly Measurement _measurement;

        public Log(Measurement subject)
        {
            _measurement = subject;
            _measurement.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("Log Update called");
            int dia = _measurement.Dia;
            int sys = _measurement.Sys;
            Console.WriteLine("Dia: {0} - Sys: {1}", dia, sys);
        }
    }
}
