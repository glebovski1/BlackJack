using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class UserPlayer : BasePlayer
    {
        

        public string LastName { get; set; }

        public decimal Money { get; set; }

        public string Password { get; set; }

        public UserPlayer(string firstname, string lastname, decimal money, string password) : base(firstname)
        {
            

            LastName = lastname;

            Money = money;

            Password = password;
        }

    }
}
