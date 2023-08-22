using System.Collections.Generic;
using CardCounterWPF_MVVM.Model;

namespace CardCounterWPF_MVVM.CardCounter
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