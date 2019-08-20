using System;
using System.Collections.Generic;
using System.Text;

using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Enums;
using static BlackJack.Constants.Messages;
using static BlackJack.Constants.Constants;
using BlackJack.Data;

using BlackJack.BuisnesLogic.Services.Interfaces;

namespace BlackJack.BuisnesLogic.Services
{
    public class GameService
    {
        IPlayerService UserService { get; set; }
        
        IPlayerService CroupierService { get; set; }

        IBotService BotService { get; set; }   

        DeckService DeckService { get; set; }

        public PrintDell printDell;

        public ReadDell readDell;

        
        public GameService(ReadDell _readDell, PrintDell _printDell)
        {
            readDell = _readDell;

            printDell = _printDell;

            CroupierService = new CroupierService();

            UserService = new UserPlayerService(printDell, readDell);

            printDell(PresentationMess5);

            DeckService = new DeckService(DeckFactor);

            BotService = new BotService();
        }



        public void Game()
        {
            for (int i=0; i<10; i++)
            {
                Round(ManeyRates());

                
            }
            ;
        }

        public void GetWinner(decimal maney)
        {
            List<BasePlayer> basePlayers = new List<BasePlayer>();

            basePlayers.Add((UserService as UserPlayerService).UserPlayer);

            basePlayers.Add((CroupierService as CroupierService).Croupier);

            for (int i=0; i< (BotService as BotService).BotPlayers.Count; i++)
            {
                basePlayers.Add((BotService as BotService).BotPlayers[i]);
            }

            for(int i=1; i < basePlayers.Count; i++)
            {
                BasePlayer temp;

                if (basePlayers[i-1].Score < basePlayers[i].Score)
                {
                    temp = basePlayers[i - 1];

                    basePlayers[i - 1] = basePlayers[i];

                    basePlayers[i] = temp;

                    i = 0;
                }
            }

            printDell(mess6 + " " + basePlayers[0].FirstName);
            if (basePlayers[0] is BotPlayer)
            {
                (basePlayers[0] as BotPlayer).Maney += maney;
            }
            if (basePlayers[0] is UserPlayer)
            {
                (basePlayers[0] as UserPlayer).Maney += maney;
            }

            for(int i=0; i< basePlayers.Count; i++)
            {
                basePlayers[i].Score = 0;
            }
        }

        public void Round(decimal maney)
        {
            printDell(mess7);

            CroupierService.SetCard(DeckService.GetCard());

            if (UserService.Next())
            {
                UserService.SetCard(DeckService.GetCard());
            }
            if (!UserService.Next())
            {
                GetWinner(maney);
            }
            for (int i=0; i <(BotService as BotService).BotPlayers.Count; i++)
            {
                if(BotService.Next(i))
                {
                    BotService.SetCard(i, DeckService.GetCard());
                }
                if (!BotService.Next(i))
                {
                    GetWinner(maney);
                }

            }



        }
        public decimal ManeyRates()
        {
            decimal maney=0;

            maney += UserService.GetManey();
            for (int i=0; i<(BotService as BotService).BotPlayers.Count; i++)
            {
                maney += BotService.GetManey(i);
            }
            return maney;

        }
    }
}



