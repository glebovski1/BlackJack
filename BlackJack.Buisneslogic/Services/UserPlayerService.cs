using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;
using static BlackJack.Constants.Constants;
using BlackJack.Enums;
using BlackJack.BuisnesLogic.Delegates;
using static BlackJack.Constants.Messages;
using BlackJack.BuisnesLogic.Services.Interfaces;
using System.Data.SqlClient;

namespace BlackJack.BuisnesLogic.Services
{
    public class UserPlayerService : BasePlayerSevice, IUserDBService
    {
        public UserPlayer UserPlayer { get; set; }
        public PrintDell printDell { get; private set; }
        public ReadDell readDell { get; private set; }

        public UserPlayerService( PrintDell _printDell, ReadDell _readDell)
        {
            printDell = _printDell;

            readDell = _readDell;
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

        public void Logging()
        {
            string loggin;
            string pasword;
            string paswordFromBD;
            string connectionString;
            printDell(PresentationMess2);
            for (int i = 0; i < 10; i++)
            {
                loggin = readDell();
                printDell(mess9);
                pasword = readDell();
                connectionString = conectionString;
                string sqlExpression = String.Format("SELECT Pasword FROM Users WHERE FirstName = '{0}';", loggin);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    paswordFromBD = Convert.ToString(command.ExecuteScalar());

                }
                if (paswordFromBD == pasword)
                {
                    string firstname = loggin;

                    

                    string lastname;

                    sqlExpression = String.Format("SELECT LastName FROM Users WHERE FirstName = '{0}';", loggin);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        lastname = Convert.ToString(command.ExecuteScalar());

                    }

                    decimal maney;

                    sqlExpression = String.Format("SELECT Maney FROM Users WHERE FirstName = '{0}';", loggin);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        maney = Convert.ToDecimal(command.ExecuteScalar());

                    }
                                                            
                    UserPlayer = new UserPlayer(firstname, lastname, maney, pasword);
                    base.BasePlayer = UserPlayer;
                    break;
                }
                if (paswordFromBD != pasword)
                {
                    printDell(mess10);
                }
            }


        }

        public void Registartion()
        {
            string firstname;

            string lastname;

            decimal maney;

            string password;

            printDell(PresentationMess2);

            firstname = readDell();

            printDell(PresentationMess4);

            lastname = readDell();

            printDell(PresentationMess3);

            maney = Convert.ToDecimal(readDell());

            printDell(mess9);

            password = readDell();

            UserPlayer = new UserPlayer(firstname, lastname, maney, password);

            base.BasePlayer = UserPlayer;
                       
            string connectionString = conectionString;

            string sqlExpression = String.Format("INSERT INTO Users (FirstName, LastName, Pasword, Maney) VALUES ('{0}', '{1}', '{2}', {3})", firstname, lastname, password, maney);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();

            }
        }

        public void Update()
        {
            string connectionString = conectionString;
            string sqlExpression = String.Format("UPDATE Users SET Maney = {0} WHERE FirstName = '{1}';", UserPlayer.Maney, UserPlayer.FirstName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

            }
        }

        public void ShowInfo()
        {
            printDell(mess12 + UserPlayer.FirstName);
            printDell(mess13 + UserPlayer.LastName);
            printDell(mess14 + UserPlayer.Password);
            printDell(mess15 + Convert.ToString(UserPlayer.Maney));
        }
    }
}
