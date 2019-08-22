using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.Data;
using static BlackJack.Constants.Constants;

namespace BlackJack.BuisnesLogic.Services
{
    public class BaseBotService : IBotService
    {
        public List<BasePlayer> BaseBotPlayers { get; set; }

        public BaseBotService()
        {
            BaseBotPlayers = new List<BasePlayer>();
        }
        public virtual decimal GetManey(int i)
        {
            decimal maney = BotRateManey;
                        
            return maney;
        }

        public string GetName(int i)
        {
            return BaseBotPlayers[i].FirstName;
        }

        public int GetScore(int i)
        {
            return BaseBotPlayers[i].Score;
        }

        public virtual bool Next(int i)
        {
            return true;
        }

        public void SetCard(int i, Card card)
        {
            if ((BaseBotPlayers[i].Score + card.CardScore1) <= TopScore)
            {
                BaseBotPlayers[i].SetOfCards.Add(card);
                BaseBotPlayers[i].Score += card.CardScore1;
            }
            if ((BaseBotPlayers[i].Score + card.CardScore1) > TopScore)
            {
                BaseBotPlayers[i].SetOfCards.Add(card);
                BaseBotPlayers[i].Score += card.CardScore2;
            }
        }

        

        public void SetScore(int i, int x)
        {
            BaseBotPlayers[i].Score = x;
        }
    }
}
