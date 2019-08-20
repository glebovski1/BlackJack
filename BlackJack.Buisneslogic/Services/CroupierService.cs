using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.Data;

namespace BlackJack.BuisnesLogic.Services
{
    public class CroupierService : BasePlayerSevice
    {
        public Сroupier Croupier { get; set; }

        public CroupierService() : base()
        {
            Croupier = new Сroupier();
            base.BasePlayer = Croupier; 
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
