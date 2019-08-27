using System;
using System.Collections.Generic;
using System.Text;

using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Enums;
using static BlackJack.Constants.Messages;
using static BlackJack.Constants.Constants;
using BlackJack.Data;

using BlackJack.BuisnesLogic.Services.Interfaces;
using System.Linq;

namespace BlackJack.BuisnesLogic.Services
{
    public class GameService
    {
        private IPlayerService UserService { get; set; }

        private ICroupierSrvice CroupierService { get; set; }

        private IBotService BotService { get; set; }

        protected DeckService DeckService { get; set; }

        protected PrintDell printDell;

        protected ReadDell readDell;

        
        public GameService(ReadDell _readDell, PrintDell _printDell)
        {
            readDell = _readDell;

            printDell = _printDell;

            CroupierService = new CroupierService();

            UserService = new UserPlayerService(printDell, readDell);

            printDell(PresentationMess5);

            int botNumber = Convert.ToInt32(readDell());

            DeckService = new DeckService(DeckFactor);

            BotService = new BotService(botNumber);

            printDell(mess17);
        }
        public void Game()
        {
            decimal money = 0;
            for (int i=0; i<DefoultNumberOfRounds; i++)
            {
                if (money == 0)
                {
                    money = MoneyRates();
                }
                Round(ref money);    
            }

            Game();
            
        }

        public void GetWinner(ref decimal money)
        {
            if ((UserService.GetScore() >= (BotService as BaseBotService).GetBestScore()) && (UserService.GetScore() >= (CroupierService as BasePlayerSevice).GetScore()))
            {
                
                    (UserService as UserPlayerService).SetMoney(money);

                    printDell(mess6 + " " + (UserService as UserPlayerService).UserPlayer.FirstName);
                

               

            }

            if ((UserService.GetScore() < (BotService as BaseBotService).GetBestScore()) && ((BotService as BaseBotService).GetBestScore() > (CroupierService as BasePlayerSevice).GetScore()))
            {
                
                    int bestBotIndex = (BotService as BaseBotService).GetBestScoreIndex();

                    BasePlayer botPlayer = (BotService as BaseBotService).GetBotPlayer(bestBotIndex);

                    (botPlayer as BotPlayer).Money += money;

                    printDell(mess6 + " " + botPlayer.FirstName);
                
                    
            }
             if (((CroupierService as BasePlayerSevice).GetScore() > UserService.GetScore()) && ((CroupierService as BasePlayerSevice).GetScore() > (BotService as BaseBotService).GetBestScore()))
            {
                printDell(mess6 + " " + (CroupierService as BasePlayerSevice).GetName());
            }


            UserService.SetScore(0);

            (CroupierService as BasePlayerSevice).SetScore(0);

            for(int i=0; i<(BotService as BotService).BotPlayers.Count; i++)
            {
                (BotService as BaseBotService).SetScore(i,0);
                
            }

            money = 0;

            (UserService as UserPlayerService).UpdateMoney();

        }

        public void Round(ref decimal money)
        {
            
                (CroupierService as CroupierService).SetCard(DeckService.GetCard());

            bool playerStep = UserService.Next();

                if (playerStep)
                {
                    UserService.SetCard(DeckService.GetCard());
                    
                }
                if (!playerStep)
                {
                    GetWinner(ref money);
               
                }

                BotAction(ref money);
                
        }
        public void BotAction(ref decimal money)
        {
            for (int i = 0; i < (BotService as BotService).BotPlayers.Count; i++)
            {
                if (BotService.Next(i))
                {
                    BotService.SetCard(i, DeckService.GetCard());
                }
                if (!BotService.Next(i))
                {
                    GetWinner(ref money);
                     
                }

            }
            
        }
        public decimal MoneyRates()
        {
            decimal maney=0;

            maney += UserService.GetMoney();
            for (int i=0; i<(BotService as BotService).BotPlayers.Count; i++)
            {
                maney += BotService.GetMoney(i);
            }
            return maney;
            
        }
    }
}



