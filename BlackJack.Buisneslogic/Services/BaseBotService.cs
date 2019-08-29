using System.Collections.Generic;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.Data;
using BlackJack.Constants;
using System.Linq;
using static BlackJack.Constants.Constants.BusinessRules;
using static BlackJack.Constants.Constants.Messages;

namespace BlackJack.BuisnesLogic.Services
{
    public class BaseBotService : IBotService
    {
        protected List<BasePlayer> BaseBotPlayers { get; set; }

        public BaseBotService()
        {
            BaseBotPlayers = new List<BasePlayer>();
        }
        public virtual decimal GetMoney(int botIndex)
        {
            decimal maney =  BotRateMoney;
                        
            return maney;
        }

        public string GetName(int botIndex)
        {
            return BaseBotPlayers[botIndex].FirstName;
        }

        public BasePlayer GetBotPlayer(int index)
        {
            BasePlayer basePlayer = BaseBotPlayers[index];

            return basePlayer;
        }

        public int GetScore(int botIndex)
        {
            return BaseBotPlayers[botIndex].Score;
        }

        public int GetBestScore()
        {
            var maxScore = BaseBotPlayers.Max(p => p.Score);

                return maxScore;
        }

        public int GetBestScoreIndex()
        {
            var maxScore = BaseBotPlayers.Max(p => p.Score);

            for (int i=0; i<BaseBotPlayers.Count; i++)
            {
                if (BaseBotPlayers[i].Score == maxScore)
                {
                    return i;
                }
               
            }
            return 0;
        }
        public virtual bool Next(int botIndex)
        {
            return true;
        }

        public void SetCard(int botIndex, Card card)
        {
            if ((BaseBotPlayers[botIndex].Score + card.CardScore1) <= TopScore)
            {
                BaseBotPlayers[botIndex].SetOfCards.Add(card);
                BaseBotPlayers[botIndex].Score += card.CardScore1;
            }
            else if ((BaseBotPlayers[botIndex].Score + card.CardScore1) > TopScore)
            {
                BaseBotPlayers[botIndex].SetOfCards.Add(card);
                BaseBotPlayers[botIndex].Score += card.CardScore2;
            }
        }

        public void SetScore(int botIndex, int x)
        {
            BaseBotPlayers[botIndex].Score = x;
        }
    }
}
