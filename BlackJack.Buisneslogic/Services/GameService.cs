using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Interfaces;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Enums;
using static BlackJack.Constants.Messages;
using static BlackJack.Constants.Constants;
using BlackJack.Data;

namespace BlackJack.BuisnesLogic.Services
{
    public class GameService
    {
        List<IPlayerService> playerServices;

        DeckService deckService;
        public PrintDell printDell;

        public ReadDell readDell;

        public GameService(string firstname, string lastname, decimal maney, ReadDell _readDell, PrintDell _printDell, int numberOfBots)
        {
            playerServices = new List<IPlayerService>();
            deckService = new DeckService(DeckFactor);
            printDell = _printDell;
            readDell = _readDell;
            playerServices.Add(new CroupierService());
            playerServices.Add(new UserPlayerService(firstname, lastname, maney, _printDell, _readDell ));
            playerServices.AddRange(BotPlayerSevice.GetBots(numberOfBots));
        }
        public void Game(PrintDell printDell, ReadDell readDell)
        {
            decimal maneypull = 0;
            string command = null;
            while(command != Commands.quit.ToString())
            {
                
                command = readDell();
                for (int i=0; i<playerServices.Count; i++)
                {
                    
                    if (playerServices[i].Next())
                    {
                        Card card = deckService.GetCard();
                        
                        if (playerServices[i] is UserPlayerService)
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
                        printDell(GetWinner());
                        
                    }
                    if (playerServices[i].Next() != true)
                    {
                        i = 0;
                        printDell(GetWinner());
                        
                    }
                    if (deckService.Deck.Count == 0)
                    {
                        printDell(mess3);
                        
                    }
                }

            } 
        }

        public string GetWinner()
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
            return mess6 + TempPlayerServices[0].GetName() + mess7;
        }

        public void Round()
        {
            decimal maneypull = 0;
            for (int i = 0; i < playerServices.Count; i++)
            {
                maneypull += playerServices[i].GetManey();
            }

        }
    }
}
