using System;
using System.Collections.Generic;
using System.Threading;
using CardCounterLib;

namespace ConsoleCardCounter
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // serial
            Console.WriteLine("Serial");
            CardData cardData = new CardData();
            CardFileReader cardFileReader = new CardFileReader();
            CardDataProvider cardDataProvider = new CardDataProvider();

            List<Card> cardsInFile = cardFileReader.ReadCardsInFile("../../../../Cards/cards.txt");
            cardDataProvider.UpdateCardData(cardsInFile, cardData);

            cardsInFile = cardFileReader.ReadCardsInFile("../../../../Cards/cards2.txt");
            cardDataProvider.UpdateCardData(cardsInFile, cardData);

            cardsInFile = cardFileReader.ReadCardsInFile("../../../../Cards/cards3.txt");
            cardDataProvider.UpdateCardData(cardsInFile, cardData);

            Console.WriteLine("Number of cards:  {0}", cardData.NumberOfCards);
            Console.WriteLine("Number of spades: {0}", cardData.NumberOfSpades);
            Console.WriteLine("Number of aces:   {0}", cardData.NumberOfAces);

            // parallel
            Console.WriteLine("Parallel");
            CardData cardDataParallel = new CardData();
            CardCounterForThread card1Counter = new CardCounterForThread("../../../../Cards/cards.txt", cardDataParallel);
            CardCounterForThread card2Counter = new CardCounterForThread("../../../../Cards/cards2.txt", cardDataParallel);
            CardCounterForThread card3Counter = new CardCounterForThread("../../../../Cards/cards3.txt", cardDataParallel);

            Thread threadCard1Counter = new Thread(card1Counter.CountTheCards);
            Thread threadCard2Counter = new Thread(card2Counter.CountTheCards);
            Thread threadCard3Counter = new Thread(card3Counter.CountTheCards);

            threadCard1Counter.Start();
            threadCard2Counter.Start();
            threadCard3Counter.Start();

            threadCard1Counter.Join();
            threadCard2Counter.Join();
            threadCard3Counter.Join();

            Console.WriteLine("Number of cards:  {0}", cardDataParallel.NumberOfCards);
            Console.WriteLine("Number of spades: {0}", cardDataParallel.NumberOfSpades);
            Console.WriteLine("Number of aces:   {0}", cardDataParallel.NumberOfAces);
        }
    }
}
