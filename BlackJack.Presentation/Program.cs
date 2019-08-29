using System;
using BlackJack.BuisnesLogic.Services;
using BlackJack.BuisnesLogic.Delegates;
using BlackJack.Constants;
using BlackJack.Enums;
using static BlackJack.Constants.Constants;

using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Presentation
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Presentation presentation;
                            
            presentation = new Presentation();

            presentation.Start();
                
        }
    }
}
