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
        public UserPlayer UserPlayer { get; set; }
        public PrintDell printDell { get; private set; }
        public ReadDell readDell { get; private set; }

        public UserPlayerService( PrintDell _printDell, ReadDell _readDell)
        {
            string firstname;

            string lastname;

            decimal maney;

            printDell = _printDell;

            readDell = _readDell;

            printDell(PresentationMess2);

            firstname = readDell();

            printDell(PresentationMess4);

            lastname = readDell();

            printDell(PresentationMess3);

            maney = Convert.ToDecimal(readDell());

            UserPlayer = new UserPlayer(firstname, lastname, maney);

            base.BasePlayer = UserPlayer;

            printDell = _printDell;

            readDell = _readDell;
        }

        public override decimal GetManey()
        {
            printDell(mess8);
            decimal maney = Convert.ToDecimal(readDell());

            UserPlayer.Maney -= maney;

            return maney;
        }
        
        public override bool Next()
        {


            printDell(mess2);
            for (int i = 0; i < 1; i++)
            {
                
                string command = readDell().ToString();
                if (command == Commands.next.ToString())
                {
                    
                    return true;

                }
                 if (command == Commands.stop.ToString())
                {

                    return false;
                }

                 if (command == Commands.quit.ToString())
                {
                    break;
                }

                else
                {
                    printDell("Not valid command");
                    i = 0;
                }
                
            }
            return false;

        }
        public override void SetCard(Card card)
        {
            base.SetCard(card);
            printDell(mess5 + " " + card.CardSuit + " " + card.CardName);
        }

    }
}
