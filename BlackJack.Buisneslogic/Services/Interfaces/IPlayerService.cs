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

         void SetScore(int score);
               
         void SetCard(Card card);
                      
         bool Next();
        
         decimal GetMoney();

       

        



          
        
    }
}
