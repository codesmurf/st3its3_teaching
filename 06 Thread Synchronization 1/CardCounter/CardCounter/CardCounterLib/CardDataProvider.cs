using System.Collections.Generic;
using System.Threading;

namespace CardCounterLib
{
    public class CardDataProvider
    {
        public void UpdateCardData(List<Card> cards, CardData cardData)
        {
            int cardsCount = cards.Count;
            cardData.IncrementNumberOfCards(cardsCount);

            foreach (Card card in cards)
            {
                if (card.Color == "SPADE")
                {
                    cardData.IncrementNumberOfSpades(1);
                }

                if (card.Value == 1)
                {
                    cardData.IncrementNumberOfAces(1);
                }
            }
        }
    }
}