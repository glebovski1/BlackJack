using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using BlackJack.Enums;

namespace BlackJack.BuisnesLogic.Services
{
    public class DeckService
    {
        public List<Card> Deck;

        public DeckService(int factor)
        {
            Deck = BaseDeckMultiplier(BaseDeck(),factor); 
        }

        public Card GetCard()
        {
            Card card;

            Random rn = new Random();

            int randomnumber = rn.Next(Deck.Count);

            card = Deck[randomnumber];

            Deck.RemoveAt(randomnumber);

            return card;
        }

        public List<Card> BaseDeck()
        {
            List<Card> baseDeck = new List<Card>();
            for (int i = 0; i < (int)CardSuits.Pike; i++)
            {
                for (int j = 0; j < (int)CardNames.ace; j++)
                {
                    int score = j + 2;
                    if (j <= (int)CardNames.ten)
                    {
                        baseDeck.Add(new Card(Convert.ToString((CardNames)j), Convert.ToString((CardSuits)i), score, score));
                    }
                    else if (j <= (int)CardNames.king)
                    {
                        baseDeck.Add(new Card(Convert.ToString((CardNames)j), Convert.ToString((CardSuits)i), 10, 10));
                    }
                    else if (j == (int)CardNames.ace)
                    {
                        baseDeck.Add(new Card(Convert.ToString((CardNames)j), Convert.ToString((CardSuits)i), 11, 1));
                    }
                }
            }
            return baseDeck;
        }

        public List<Card> BaseDeckMultiplier(List<Card> basedeck, int factor)
        {
            List<Card> deck = new List<Card>(); 
            for (int i=0; i <factor; i++)
            {
                for (int j=0; j<basedeck.Count; j++)
                {
                    deck.Add(basedeck[j]);
                }
                i++;
            }
            return deck;
        }
    }
}


        
                    
