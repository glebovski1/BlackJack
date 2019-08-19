using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class BotPlayer : BasePlayer
    {
        

        public decimal Maney { get; set; }

        public BotPlayer (string firstname, decimal maney) : base(firstname)
        {
            

            Maney = maney;
        }
    }
}
