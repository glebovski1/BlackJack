using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.BuisnesLogic.Delegates;




namespace BlackJack.BuisnesLogic.Services
{
    public class BotService : BaseBotService
    {
        public List<BotPlayer> BotPlayers { get; set; }

        public BotService(int numberofbots)
        {
            BotPlayers = new List<BotPlayer>();

            for (int i=0; i<numberofbots; i++)
            {
                BotPlayers.Add(new BotPlayer(GetRandomBotName(), BotStartMoney));
            }

            for (int i=0; i<BotPlayers.Count; i++)
            {
                base.BaseBotPlayers.Add(BotPlayers[i]);
            }
                

            

        }
        public override decimal GetMoney(int botIndex)
        {
            decimal money = BotRateMoney;

            BotPlayers[botIndex].Money -= money;

            return money;
        }
        public override bool Next(int botIndex)
        {
            if (base.BaseBotPlayers[botIndex].Score < BotTopScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

            
    

        public string GetRandomBotName()
        {
            Random random = new Random();

            int RandomBotNumber = random.Next((int)BotNames.Alexander);

            return Convert.ToString((BotNames)RandomBotNumber);
        }




    }
}

             


    

