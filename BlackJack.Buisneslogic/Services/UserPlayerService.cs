using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Delegates;
using static BlackJack.Constants.Messages;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.DataAccsess.Repositories.Interfaces;
using BlackJack.DataAccsess.Repositories;


namespace BlackJack.BuisnesLogic.Services
{
    public class UserPlayerService : BasePlayerSevice
    {
        public UserPlayer UserPlayer { get; set; }
        protected PrintDell printDell { get; private set; }
        protected ReadDell readDell { get; private set; }

        public UserPlayerService( PrintDell _printDell, ReadDell _readDell)
        {
            printDell = _printDell;

            readDell = _readDell;

            Menu();
            
        }

        private void Menu()
        {
            printDell(mess11);

            string command = readDell();

            if (command == Commands.l.ToString())
            {
                Logging();
            }

            if (command == Commands.r.ToString())
            {
                Registartion();
            }
        }

        public override decimal GetMoney()
        {
            printDell(mess8);
            decimal money = 0;
            try
            {
                
                money = Convert.ToDecimal(readDell());

            }
            catch
            {
                printDell(PresentationMess7);

                GetMoney();
            }
            finally
            {
                UserPlayer.Money -= money;
            }

            return money;

            
        }
        
        public override bool Next()
        {


            printDell(mess2);
            for (int i = 0; i < 1; i++)
            {
                
                string command = readDell().ToString();
                if (command == Commands.n.ToString())
                {
                    
                    return true;

                }
                 if (command == Commands.s.ToString())
                 {

                    return false;
                 }

                 if (command == Commands.q.ToString())
                 {
                    break;
                 }

                printDell(PresentationMess7);
                 i = 0;
                
                
            }
            return false;

        }
        public override void SetCard(Card card)
        {
            base.SetCard(card);
            printDell(mess5 + " " + card.CardSuit + " " + card.CardName);
        }

        public void Logging()
        {
            

            IUserRepository userRepository = new UserRepository();

            string loggin;

            string password;

            string paswordFromBD;

            

            printDell(PresentationMess2);

            loggin = readDell();

            int ID = userRepository.GetID(loggin);

            paswordFromBD = userRepository.GetPassword(ID);

            printDell(mess9);

            password = readDell();

            if (password == paswordFromBD)
            {
                UserPlayer = userRepository.GetUserDB(ID);
                base.BasePlayer = UserPlayer;
            }

            if (password != paswordFromBD)
            {
                printDell(mess10);
            }
            


        }

        public void Registartion()
        {
            string firstname;

            string lastname;

            decimal maney;

            string password1;

            string password2;

            printDell(PresentationMess2);

            firstname = readDell();

            printDell(PresentationMess4);

            lastname = readDell();

            printDell(PresentationMess3);

            maney = Convert.ToDecimal(readDell());

            printDell(mess9);

            password1 = readDell();

            printDell(mess16);

            password2 = readDell();

            if (password1 == password2)
            {
                UserPlayer = new UserPlayer(firstname, lastname, maney, password1);

                base.BasePlayer = UserPlayer;

                IUserRepository userRepository = new UserRepository();

                userRepository.SetUserDB(UserPlayer);


            }


                       
            
        }

        public void UpdateMoney()
        {
            UserRepository userRepository = new UserRepository();

            int id = Convert.ToInt32(userRepository.GetID(UserPlayer.FirstName));

            userRepository.UpdateManey(id, UserPlayer.Money);
        }

        public void ShowInfo()
        {
            printDell(mess12 + UserPlayer.FirstName);
            printDell(mess13 + UserPlayer.LastName);
            printDell(mess14 + UserPlayer.Password);
            printDell(mess15 + Convert.ToString(UserPlayer.Money));
        }

        public void SetMoney(decimal money)
        {
            UserPlayer.Money += money;
        }
    }
}
