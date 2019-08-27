using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BuisnesLogic.Services.Interfaces
{
    interface IBotService
    {
        string GetName(int botIndex);

        int GetScore(int botIndex);

        void SetScore(int botIndexi, int score);

        void SetCard(int botIndex, Card card);
        
        bool Next(int botIndex);
        
        decimal GetMoney(int botIndex);

        
    }
}
