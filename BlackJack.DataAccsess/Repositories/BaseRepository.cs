using BlackJack.DataAccsess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DataAccsess.Repositories
{
    public class BaseRepository : IBaseRepository
    {
         
        protected readonly string conectionString;

        public BaseRepository ()
        {
            conectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlayerDatabase;" +
                "Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
        }
           
        public string GetConnectionString()
        {
            return conectionString;
        }
    }
}
