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

            Console.WriteLine(PresentationMess2);

            string firstname = Console.ReadLine();

            Console.WriteLine(PresentationMess4);

            string lastname = Console.ReadLine();

            Console.WriteLine(PresentationMess3);

            decimal maney = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(PresentationMess5);

            int numberofbots = Convert.ToInt32(Console.ReadLine());

            GameService gameService = new GameService(firstname, lastname, maney, Read, Print, numberofbots);

            gameService.Game();
        }
        
    }
}

