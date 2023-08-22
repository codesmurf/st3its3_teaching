namespace CardCounterWPF_MVVM.Model
{
    public class CardData : CardCountSubject
    {
        private int _numberOfCards = 0;
        private int _sumOfSpades = 0;
        private int _numberOfAces = 0;

        private object cardsLock = new object();
        private object spadesLock = new object();
        private object acesLock = new object();

        public int NumberOfAces => _numberOfAces;

        public void IncrementNumberOfAces(int value)
        {
            lock (acesLock)
            {
                _numberOfAces = _numberOfAces + value;
                Notify(UpdatedField.AcesCount);
            }
        }

        public int SumOfSpades => _sumOfSpades;

        public void IncrementSumOfSpades(int value)
        {
            lock (spadesLock)
            {
                _sumOfSpades = _sumOfSpades + value;
                Notify(UpdatedField.SpadesSum);
            }
        }
        public int NumberOfCards => _numberOfCards;

        public void IncrementNumberOfCards(int value)
        {
            lock (cardsLock)
            {
                _numberOfCards = _numberOfCards + value;
                Notify(UpdatedField.CardsCount);
            }
        }
    }
}
