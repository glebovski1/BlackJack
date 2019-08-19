using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Interfaces;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Enums;
using static BlackJack.Constants.Messages;
using static BlackJack.Constants.Constants;
using BlackJack.Data;
using BlackJack.Buisneslogic.Services.Interfaces;

namespace BlackJack.BuisnesLogic.Services
{
    public class GameService
    {
        List<IPlayerService> playerServices;

        DeckService deckService;
        public PrintDell printDell;

        public ReadDell readDell;

        private readonly IBotPlayerService _botPlayerService;
        public GameService(string firstname, string lastname, decimal maney, ReadDell _readDell, PrintDell _printDell, int numberOfBots)
        {
            playerServices = new List<IPlayerService>();
            deckService = new DeckService(DeckFactor);
            printDell = _printDell;
            readDell = _readDell;

            _botPlayerService = new BotPlayerSevice("firstname", 500);

            playerServices.Add(new CroupierService());
            playerServices.Add(new UserPlayerService(firstname, lastname, maney, _printDell, _readDell ));
            playerServices.AddRange(BotPlayerSevice.GetBots(numberOfBots));

            (_botPlayerService as IPlayerService). 
        }

        public void Game()
        {
            string command = null;

            while (command != Commands.quit.ToString())
            {
                command = readDell();
                Round();
                //command = readDell();
                //for (int i=0; i<playerServices.Count; i++)
                //{
                    
                //    if (playerServices[i].Next())
                //    {
                //        Card card = deckService.GetCard();
                        
                //        if (playerServices[i] is UserPlayerService)
                //        {
                //            playerServices[i].SetCard(card);
                //            printDell(mess5 + card.CardName + card.CardSuit);
                //        }
                //        else 
                //        {
                //            playerServices[i].SetCard(card);
                //            printDell(playerServices[i].GetName() + mess4);
                //        }
                //    }
                //    if (playerServices[i].GetScore() >= TopScore)
                //    {
                //        i = 0;
                //        printDell(GetWinner());
                        
                //    }
                //    if (playerServices[i].Next() != true)
                //    {
                //        i = 0;
                //        printDell(GetWinner());
                        
                //    }
                //    if (deckService.Deck.Count == 0)
                //    {
                //        printDell(mess3);
                        
                //    }
                //}

            } 
        }

        public void Circle( decimal maney)
        {
            
            for (int i = 0; i < playerServices.Count; i++)
            {
                bool next = playerServices[i].Next();
                if (next)
                {
                    Card card = deckService.GetCard();

                    if (playerServices[i] is UserPlayer)
                    {
                        playerServices[i].SetCard(card);
                        printDell(mess5 + card.CardName + card.CardSuit);
                    }
                    else
                    {
                        playerServices[i].SetCard(card);
                        printDell(playerServices[i].GetName() + mess4);
                    }
                }
                 if (playerServices[i].GetScore() >= TopScore)
                {
                    i = 0;
                    printDell(GetWinner(maney));

                }
                 if (!next)
                {
                    i = 0;
                    printDell(GetWinner(maney));

                }
                 if (deckService.Deck.Count == 0)
                {
                    printDell(mess3);

                }
            }
        }
        public string GetWinner(decimal maney)
        {
            List<IPlayerService> TempPlayerServices = new List<IPlayerService>();
            TempPlayerServices.AddRange(playerServices);
            for (int i=1; i<playerServices.Count; i++)
            {
                

                if (TempPlayerServices[i-1].GetScore() < TempPlayerServices[i].GetScore())
                {
                    IPlayerService temp;
                    temp = TempPlayerServices[i-1];
                    TempPlayerServices[i-1] = TempPlayerServices[i];
                    TempPlayerServices[i-1] = temp;
                    i = 0;
                }
            }
            for (int i=0; i<playerServices.Count; i++)
            {
                playerServices[i].SetScore(0);
            }
            TempPlayerServices[0].SetManey(maney);
            return mess6 + TempPlayerServices[0].GetName() + mess7;
        }

        public void Round()
        {
            string command = null;
            decimal maneypull = 0;
            for (int i = 0; i < playerServices.Count; i++)
            {
                maneypull += playerServices[i].GetManey();
            }
            while (command != Commands.quit.ToString())
            {
                command = readDell();

                Circle (maneypull);

            }

        }
    }
}
