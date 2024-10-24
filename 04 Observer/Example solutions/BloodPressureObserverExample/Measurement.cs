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

        private void Notify(int dia, int sys)
        {
            foreach (IBloodPressureObserver bloodPressureObserver in _observers)
            {
                bloodPressureObserver.Update(dia, sys);
            }
        }

        public void Done()
        {
            Notify(Dia, Sys);
        }
    }
}
