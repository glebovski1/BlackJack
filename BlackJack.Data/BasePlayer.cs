using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class BasePlayer
    {
        public BasePlayer(string firstname)
        {
            SetOfCards = new List<Card>();

            Score = 0;

            FirstName = firstname;
        }
        public BasePlayer()
        {
            SetOfCards = new List<Card>();

            Score = 0;
        }

        public List<Card> SetOfCards { get; set; }

        public int Score { get; set; }

        public string FirstName { get; set; }
    }
}
