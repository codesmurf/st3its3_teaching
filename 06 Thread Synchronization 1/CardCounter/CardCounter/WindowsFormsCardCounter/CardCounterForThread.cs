using System.Collections.Generic;
using CardCounterLib;

namespace WindowsFormsCardCounter
{
    public class CardCounterForThread
    {
        private readonly string _path;
        private readonly CardData _cardData;

        public CardCounterForThread(string path, CardData cardData)
        {
            _path = path;
            _cardData = cardData;
        }

        public void CountTheCards()
        {
            CardFileReader cardFileReader = new CardFileReader();
            CardDataProvider cardDataProvider = new CardDataProvider();

            List<Card> cardsInFile = cardFileReader.ReadCardsInFile(_path);
            cardDataProvider.UpdateCardData(cardsInFile, _cardData);
        }
    }
}