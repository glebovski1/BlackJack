using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class UserPlayer : BasePlayer
    {
        

        public string LastName { get; set; }

        public decimal Maney { get; set; }

        public string Password { get; set; }

        public UserPlayer(string firstname, string lastname, decimal maney, string password) : base(firstname)
        {
            

            LastName = lastname;

            Maney = maney;

            Password = password;
        }

    }
}
