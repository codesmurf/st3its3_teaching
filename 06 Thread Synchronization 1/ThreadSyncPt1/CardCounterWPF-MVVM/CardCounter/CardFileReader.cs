using System;
using System.Collections.Generic;
using System.IO;

namespace CardCounterWPF_MVVM.CardCounter
{
    public class CardFileReader
    {
        public List<Card> ReadCardsInFile(string path)
        {
            List<Card> cards = new List<Card>();

            // open file
            string[] allLines = File.ReadAllLines(path);

            // for each line
            foreach (string line in allLines)
            {
                // split in color, value
                string[] split = line.Split(new char[] {','});
                string color = split[0];
                int value = Convert.ToInt32(split[1]);

                // create card
                Card c = new Card();
                c.Color = color;
                c.Value = value;

                // add card to list
                cards.Add(c);
            }

            return cards;
        }
    }
}
