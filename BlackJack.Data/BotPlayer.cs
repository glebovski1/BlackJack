using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class BotPlayer : BasePlayer
    {
        public decimal Money { get; set; }

        public BotPlayer (string firstname, decimal money) : base(firstname)
        {
           Money = money;
        }
    }
}
