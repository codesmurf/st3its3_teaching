using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace ObserverExample
{
    internal class Measurement : BloodPressureSubject
    {
        public int Dia { get; set; }
        public int Sys { get; set; }

        public void Done()
        {
            Notify();
        }
    }
}
