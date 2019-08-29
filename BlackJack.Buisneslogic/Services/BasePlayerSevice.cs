using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.Data;
using static BlackJack.Constants.Constants.BusinessRules;

namespace BlackJack.BuisnesLogic.Services
{
     public class BasePlayerSevice : IPlayerService
    {
        protected BasePlayer BasePlayer { get; set; }

        public BasePlayerSevice()
        {
            BasePlayer = new BasePlayer();

        }
                    
        public string GetName()
        {
            return BasePlayer.FirstName;
        }
        public int GetScore()
        {
            return BasePlayer.Score;
        }
        public void SetScore(int x)
        {
            BasePlayer.Score = x;
        }
        public virtual void SetCard(Card card)
        {
            if ((BasePlayer.Score + card.CardScore1) <= TopScore)
            {
                BasePlayer.SetOfCards.Add(card);
                BasePlayer.Score += card.CardScore1;
            }
            else if ((BasePlayer.Score + card.CardScore1) > TopScore)
            {
                BasePlayer.SetOfCards.Add(card);
                BasePlayer.Score += card.CardScore2;
            }
        }
        
        public virtual bool Next()
        {
            return true;
        }
        
        public virtual decimal GetMoney()
        {
            return 0;
        }
               
    }
}
