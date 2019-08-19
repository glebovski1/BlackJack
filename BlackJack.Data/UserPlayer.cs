using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class UserPlayer : BasePlayer
    {
        

        public string LastName { get; set; }

        public decimal Maney { get; set; }

        public UserPlayer(string firstname, string lastname, decimal maney) : base(firstname)
        {
            

            LastName = lastname;

            Maney = maney;
        }

    }
}
