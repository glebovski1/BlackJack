using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BuisnesLogic.Delegates
{

    public delegate string ReadDell();

    public delegate void PrintDell(string message);

    public delegate Card GetCardDell();
}
