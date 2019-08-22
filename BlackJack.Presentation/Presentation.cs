using System;
using BlackJack.BuisnesLogic.Services;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Constants;
using BlackJack.Enums;
using static BlackJack.Constants.Constants;
using static BlackJack.Constants.Messages;

namespace Presentation
{
    class Presentation
    {
        
        
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Start()
        {
            Console.WriteLine(PresentationMess6);

            string command = Console.ReadLine();

            if (command  == Commands.ng.ToString())
            {
                NewGame();
            }
            if (command == Commands.si.ToString())
            {
                UserPlayerService userPlayerService = new UserPlayerService(Print, Read);
                userPlayerService.ShowInfo();
            }
        }







        public void NewGame()
        {
            Console.WriteLine(PresentationMess1);

            GameService gameService = new GameService( Read, Print);

            gameService.Game();
        }

        
    }
}

