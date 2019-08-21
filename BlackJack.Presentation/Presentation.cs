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

        public void NewGame()
        {
            Console.WriteLine(PresentationMess1);

            GameService gameService = new GameService( Read, Print);

            gameService.Game();
        }
        
    }
}

