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

            

            BotService = new BotService();
        }



        public void Game()
        {
            for (int i=0; i<10; i++)
            {
                decimal maneyPull = 0;

                
            }
            ;
        }

        public string GetWinner()
        {
            List<IPlayerService> TempPlayerServices = new List<IPlayerService>();
            TempPlayerServices.AddRange(playerServices);
            for (int i = 1; i < playerServices.Count; i++)
            {


                if (TempPlayerServices[i - 1].GetScore() < TempPlayerServices[i].GetScore())
                {
                    IPlayerService temp;
                    temp = TempPlayerServices[i - 1];
                    TempPlayerServices[i - 1] = TempPlayerServices[i];
                    TempPlayerServices[i - 1] = temp;
                    i = 0;
                }
            }
            for (int i = 0; i < playerServices.Count; i++)
            {
                playerServices[i].SetScore(0);
            }
            TempPlayerServices[0].SetManey(maney);
            return mess6 + TempPlayerServices[0].GetName() + mess7;
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
                GetWinner();
            }
            for (int i=0; i <(BotService as BotService).BotPlayers.Count; i++)
            {
                if(BotService.Next(i))

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



