using System.Collections.Generic;

namespace CardCounterWPF_MVVM.Model
{
    public abstract class CardCountSubject
    {
        public enum UpdatedField
        {
            AcesCount,
            SpadesSum,
            CardsCount
        }

        private readonly List<ICardCountObserver> _cardCountObservers = new List<ICardCountObserver>();

        public void Add(ICardCountObserver observer)
        {
            _cardCountObservers.Add(observer);
        }

        public void Remove(ICardCountObserver observer)
        {
            _cardCountObservers.Remove(observer);
        }

        protected void Notify(UpdatedField field)
        {
            foreach (ICardCountObserver observer in _cardCountObservers)
            {
                observer.Update(field);
            }
        }
    }
}
