using System.Collections.Generic;

namespace HospitalBed.BedControl
{
    public class PresenceSubject
    {
        private readonly List<IPresenceObserver> _observers = new List<IPresenceObserver>();

        public void Attach(IPresenceObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IPresenceObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
                observer.Update();
        }
    }
}