using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BlackJack.Data;
using BlackJack.DataAccsess.Repositories.Interfaces;
using static BlackJack.Constants.Constants;

namespace BlackJack.DataAccsess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int GetID(string name)
        {
            string sqlExpression = String.Format("SELECT Id FROM Users WHERE FirstName = '{0}';", name);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            int ID = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return ID;
        }

        public string GetPassword(int id)
        {
            string sqlExpression = String.Format("SELECT UserPassword FROM Users WHERE ID = {0};", id);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            string password = command.ExecuteScalar().ToString();

            connection.Close();

            return password;
        }

        

        public UserPlayer GetUserDB(int id)
        {

            UserPlayer user;

            string sqlExpression = String.Format("SELECT * FROM Users Where ID = {0};",id);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                user = new UserPlayer(read.GetString(1), read.GetString(1), read.GetDecimal(4), read.GetString(3));

                connection.Close();

                return user;
            }

            return null;
           
            

            
        }

        public void SetUserDB(UserPlayer user)
        {
            string firstname = user.FirstName;

            string lastname = user.LastName;

            decimal money = user.Money;

            string password = user.Password;

            string sqlExpression = String.Format("INSERT INTO Users (FirstName, LastName, UserPassword, UserMoney) VALUES ('{0}','{1}',{2},'{3}');", firstname, lastname, password, money);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.ExecuteNonQuery();

            connection.Close();

            
        }

     
        public void UpdateManey(int id, decimal money)
        {
            string sqlExpression = String.Format("UPDATE Users SET UserMoney={0} WHERE ID={1};", money, id);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
