using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BuisnesLogic.Services.Interfaces
{
    interface IPlayerService
    {
         string GetName();

         int GetScore();

         void SetScore(int x);
               
         void SetCard(Card card);
                      
         bool Next();
        
         decimal GetManey();

        



          
        
    }
}
