using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ObserverExample
{
    internal abstract class BloodPressureSubject : object
    {
        protected List<IBloodPressureObserver> _observers = new List<IBloodPressureObserver>();

        public void Attach(IBloodPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IBloodPressureObserver observer)
        {
            _observers.Remove(observer);
        }

    }
}
