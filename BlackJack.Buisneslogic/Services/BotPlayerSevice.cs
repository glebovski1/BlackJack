using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.BuisnesLogic.Services.Interfaces;



namespace BlackJack.BuisnesLogic.Services
{
    public class BotService : BaseBotService
    {
        public List<BotPlayer> BotPlayers { get; set; }

        public BotService()
        {
            BotPlayers = new List<BotPlayer>();
           
        }
        public override decimal GetManey(int i)
        {
            decimal maney = BotRateManey;

            BotPlayers[i].Maney -= maney;

            return maney;
        }
        public override bool Next(int i)
        {
            if (base.BaseBotPlayers[i].Score < BotTopScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void SetCard(int i, Card card)
        {
            if ((base.BaseBotPlayers[i].Score + card.CardScore1) <= TopScore)
            {
                base.BaseBotPlayers[i].SetOfCards.Add(card);
                base.BaseBotPlayers[i].Score += card.CardScore1;
            }
            if ((base.BaseBotPlayers[i].Score + card.CardScore1) > TopScore)
            {
                base.BaseBotPlayers[i].SetOfCards.Add(card);
                base.BaseBotPlayers[i].Score += card.CardScore2;
            }
        }





    }
}

             


    

