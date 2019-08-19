using System;

namespace BlackJack.Data
{
   public class Card
    {
        public string CardName { get; set; }

        public string CardSuit { get; set; }

        public int CardScore1 { get; set; }

        public int CardScore2 { get; set; }

        public Card (string cardname, string cardsuits, int cardscore1, int cardscore2)
        {
            CardName = cardname;
            CardSuit = cardsuits;
            CardScore1 = cardscore1;
            CardScore2 = cardscore2;

        }
        
    }
}
