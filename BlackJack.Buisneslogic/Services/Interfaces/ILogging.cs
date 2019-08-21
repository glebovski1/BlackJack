using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BuisnesLogic.Services.Interfaces
{
    interface ILogging
    {
        bool Logging(string loggin, string pasword);

        void Registartion();

        void Update();
    }
}
