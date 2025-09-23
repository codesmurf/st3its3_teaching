namespace CardCounterLib
{
    public class CardData
    {
        private int _numberOfCards = 0;
        private int _numberOfSpades = 0;
        private int _numberOfAces = 0;

        private object cardsLock = new object();
        private object spadesLock = new object();
        private object acesLock = new object();

        public int NumberOfAces
        {
            get
            {
                return _numberOfAces;
            }
        }

        public void IncrementNumberOfAces(int value)
        {
            lock (acesLock)
            {
                _numberOfAces = _numberOfAces + value;
            }
        }

        public int NumberOfSpades
        {
            get => _numberOfSpades;
        }

        public void IncrementNumberOfSpades(int value)
        {
            lock (spadesLock)
            {
                _numberOfSpades = _numberOfSpades + value;
            }
        }
        public int NumberOfCards
        {
            get => _numberOfCards;
        }

        public void IncrementNumberOfCards(int value)
        {
            lock (cardsLock)
            {
                _numberOfCards = _numberOfCards + value;
            }
        }
    }
}