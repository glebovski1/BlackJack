using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;

namespace BlackJack.BuisnesLogic.Services
{
    public class CroupierService : BasePlayerSevice
    {
        public Сroupier сroupier;

        public CroupierService() : base()
        {
            сroupier = new Сroupier();
            base.basePlayer = сroupier; 
        }

        public override bool Next()
        {
            return true;
        }
        public override decimal GetManey()
        {
            return 0;
        }
    }
}
