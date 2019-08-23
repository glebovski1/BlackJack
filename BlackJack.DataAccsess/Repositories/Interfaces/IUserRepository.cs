using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;


namespace BlackJack.DataAccsess.Repositories.Interfaces
{
   public interface IUserRepository
    {
        UserPlayer GetUserDB(int id);

        void SetUserDB(UserPlayer user);

        void UpdateManey(int id, decimal maney);

        int GetID(string name);

        string GetPassword(int id);
    }
}
