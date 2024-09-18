using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ObserverExample
{
    internal abstract class BloodPressureSubject
    {
        private List<IBloodPressureObserver> _observers = new List<IBloodPressureObserver>();

        public void Attach(IBloodPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IBloodPressureObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (IBloodPressureObserver bloodPressureObserver in _observers)
            {
                bloodPressureObserver.Update();
            }
        }
    }
}
