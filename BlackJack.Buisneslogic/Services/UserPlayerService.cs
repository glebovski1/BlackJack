using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Delegates;

using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.DataAccsess.Repositories.Interfaces;
using BlackJack.DataAccsess.Repositories;
using System.Configuration;

namespace BlackJack.BuisnesLogic.Services
{
    public class UserPlayerService : BasePlayerSevice
    {
        public UserPlayer UserPlayer { get; set; }
        protected PrintDell printDell { get; private set; }
        protected ReadDell readDell { get; private set; }

        public UserPlayerService(PrintDell _printDell, ReadDell _readDell)
        {
            printDell = _printDell;

            readDell = _readDell;

            Menu();

        }

        private void Menu()
        {
            printDell(Messages.MessLoggOrReg);

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
            printDell(Messages.MessRateAsking);
            decimal money = 0;
            try
            {

                money = Convert.ToDecimal(readDell());

            }
            catch
            {
                printDell(Messages.MessError);

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

            printDell(Messages.MessAskingCommand);

            string command = readDell().ToString();

            if (command == Commands.n.ToString())
            {

                return true;

            }

            if (command == Commands.s.ToString())
            {

                return false;
            }

            printDell(Messages.MessError);

            Next();

            return false;

        }
        
        public override void SetCard(Card card)
        {
            base.SetCard(card);
            printDell(Messages.MesYouGet + " " + card.CardSuit + " " + card.CardName);
        }

        public void Logging()
        {

            IUserRepository userRepository = new UserRepository();

            string loggin = String.Empty;

            string password;

            string paswordFromBD;

            printDell(Messages.MessFirstName);

            loggin = readDell();

            int ID = userRepository.GetID(loggin);

            paswordFromBD = userRepository.GetPassword(ID);

            printDell(Messages.MessAskingPassword);

            password = readDell();

            if (password == paswordFromBD)
            {
                UserPlayer = userRepository.GetUserDB(ID);
                base.BasePlayer = UserPlayer;
            }

            if (password != paswordFromBD)
            {
                printDell(Messages.MessError);
            }

        }

        public void Registartion()
        {
            string firstname;

            string lastname;

            decimal money;

            string password1;

            string password2;

            printDell(Messages.MessAskName);

            firstname = readDell();

            printDell(Messages.MessLastname);

            lastname = readDell();

            printDell(Messages.MessAskMoney);

            money = Convert.ToDecimal(readDell());

            printDell(Messages.MessAskingPassword);

            password1 = readDell();

            printDell(Messages.MessPassConfirm);

            password2 = readDell();

            if (password1 == password2)
            {
                UserPlayer = new UserPlayer(firstname, lastname, money, password1);

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
            printDell(Messages.MessFirstName + UserPlayer.FirstName);

            printDell(Messages.MessLastname + UserPlayer.LastName);

            printDell(Messages.MessPassword + UserPlayer.Password);

            printDell(Messages.MessMoney + Convert.ToString(UserPlayer.Money));
        }

        public void SetMoney(decimal money)
        {
            UserPlayer.Money += money;
        }
    }
}   
    

