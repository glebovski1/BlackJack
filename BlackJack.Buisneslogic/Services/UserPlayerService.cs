using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Delegates;
using static BlackJack.Constants.Messages;

namespace BlackJack.BuisnesLogic.Services
{
    public class UserPlayerService : BasePlayerSevice
    {
        public UserPlayer userPlayer;

        public PrintDell printDell;

        public ReadDell readDell;

        public UserPlayerService(string firstname, string lastname, decimal maney, PrintDell _printDell, ReadDell _readDell)
        {
            userPlayer = new UserPlayer(firstname, lastname, maney);
            base.basePlayer = userPlayer;
            printDell = _printDell;
            readDell = _readDell;
        }

        public override decimal GetManey()
        {
            printDell(mess8);
            decimal maney = Convert.ToDecimal(readDell());

            userPlayer.Maney -= maney;

            return maney;
        }
        public override bool Next()
        {
            printDell(mess2);
            printDell(mess1);
            
            
            do
            {
                string command = readDell.Invoke();
                if (command == Commands.next.ToString())
                {

                    return true;

                }
                else if (command == Commands.stop.ToString())
                {

                    return false;
                }

                else if (command == Commands.quit.ToString())
                {
                    return false;
                }

                else
                {
                    printDell("Not valid command");

                }
            } while (true);
        }
        
    }
}
