using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BuisnesLogic.Services.Interfaces
{
    interface IBotService
    {
        string GetName(int i);

        int GetScore(int i);

        void SetScore(int i,int x);

        void SetCard(int i, Card card);
        
        bool Next(int i);
        
        decimal GetManey(int i);

        
    }
}
