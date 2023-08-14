using System.Collections.Generic;

namespace HospitalBed.PresenceDetectorObserver
{
    public class PresenceDetectorSubject
    {
        private readonly List<IPresenceDetectorObserver> _observers = new List<IPresenceDetectorObserver>();

        public void Attach(IPresenceDetectorObserver observer) => _observers.Add(observer);
        public void Detach(IPresenceDetectorObserver observer) => _observers.Remove(observer);

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
