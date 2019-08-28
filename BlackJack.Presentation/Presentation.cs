using System;
using BlackJack.BuisnesLogic.Services;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Constants;
using BlackJack.Enums;
using static BlackJack.Constants.Constants;


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
            Console.WriteLine(Messages.MessWelcome);

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
            if ((command != Commands.ng.ToString()) && (command != Commands.si.ToString()))
            {
                Console.WriteLine(Messages.MessError);
            }
        }







        public void NewGame()
        {
            Console.WriteLine(Messages.MessWelcome);

            GameService gameService = new GameService( Read, Print);

            gameService.Game();
        }

        
    }
}

