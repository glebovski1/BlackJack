using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.Buisneslogic.Services.Interfaces;

namespace BlackJack.BuisnesLogic.Services
{
    public class BotPlayerSevice : BasePlayerSevice, IBotPlayerService
    {
        public List <BotPlayer> botPlayers;

        public BotPlayerSevice(int numberOfBots)
        {
            botPlayers = new List<BotPlayer>();
            for (int i = 0; i < numberOfBots; i++)
            {
                botPlayers.Add(new BotPlayer(RandomBotName(), BotStartManey));
            }
        }

        public override bool[] Next()
        {
            if (botPlayer.Score < BotTopScore)
            {
                return true;
            }
            else return false;

        }

        public static string RandomBotName()
        {
            Random rn = new Random();
            int randomNumber = rn.Next((int)BotNames.Alexander);
            return Convert.ToString((BotNames)randomNumber);

        }

        public static List<BotPlayer> GetBots(int numberOfBots)
        {
            List<BotPlayerSevice> botlist = new List<BotPlayerSevice>();
            for (int i=0; i< numberOfBots; i++)
            {
                botlist.Add(new BotPlayerSevice(RandomBotName(), BotStartManey));
            }
            return botlist;
        }
        public override decimal GetManey()
        {
            decimal maney;
            maney = botPlayer.Maney / 10;
            botPlayer.Maney -= maney;

            return maney;
        }
        public override void SetManey(decimal maney)
        {
            botPlayer.Maney += maney;
        }

    }
}

             


    

