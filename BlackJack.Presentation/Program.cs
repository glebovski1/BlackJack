using System;
using BlackJack.BuisnesLogic.Services;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Constants;
using BlackJack.Enums;
using static BlackJack.Constants.Constants;
using static BlackJack.Constants.Messages;

namespace Presentation
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Presentation presentation;
            string command;
            Console.WriteLine("Write exite to exite");
            Console.WriteLine("Write newgame to new game");
            do
            {
               
                command = Console.ReadLine();
                if (command == "newgame")
                {
                    presentation = new Presentation();

                    presentation.NewGame();
                }
            }
            while (command != "exite");
            Console.WriteLine();
            
        }
    }
}
