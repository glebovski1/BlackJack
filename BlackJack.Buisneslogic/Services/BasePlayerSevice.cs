using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Interfaces;
using BlackJack.Data;
using static BlackJack.Constants.Constants;

namespace BlackJack.BuisnesLogic.Services
{
    abstract public class BasePlayerSevice : IPlayerService
    {
        public BasePlayer basePlayer;

        public BasePlayerSevice()
        {
            basePlayer = new BasePlayer();
        }

        public string GetName()
        {
            return basePlayer.FirstName;
        }
        public int GetScore()
        {
            return basePlayer.Score;
        }
        public void SetScore(int x)
        {
            basePlayer.Score = x;
        }
        public void SetCard(Card card)
        {
            if ((basePlayer.Score + card.CardScore1) <= TopScore)
            {
                basePlayer.SetOfCards.Add(card);
                basePlayer.Score += card.CardScore1;
            }
            if ((basePlayer.Score + card.CardScore1) > TopScore)
            {
                basePlayer.SetOfCards.Add(card);
                basePlayer.Score += card.CardScore2;
            }
        }
        

        public virtual bool Next()
        {
            return true;
        }

        public abstract decimal GetManey();
    }
}
