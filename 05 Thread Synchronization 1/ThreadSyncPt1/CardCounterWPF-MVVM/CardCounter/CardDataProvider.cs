using System.Collections.Generic;
using CardCounterWPF_MVVM.Model;

namespace CardCounterWPF_MVVM.CardCounter
{
    public class CardDataProvider
    {
        public void UpdateCardData(List<Card> cards, CardData cardData)
        {
            foreach (Card card in cards)
            {
                cardData.IncrementNumberOfCards(1);

                if (card.Color == "SPADE")
                {
                    cardData.IncrementSumOfSpades(card.Value);
                }

                if (card.Value == 1)
                {
                    cardData.IncrementNumberOfAces(1);
                }
            }
        }
    }
}