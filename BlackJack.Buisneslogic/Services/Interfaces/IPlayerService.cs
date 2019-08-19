using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;

namespace BlackJack.BuisnesLogic.Interfaces
{
    interface IPlayerService
    {
        void SetCard(Card card);

        string GetName();

        int GetScore();

        void SetScore(int x);

        bool Next();

        decimal GetManey();

        void SetManey(decimal maney);
    }
}
