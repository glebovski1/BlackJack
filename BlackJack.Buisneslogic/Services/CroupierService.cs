using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.BuisnesLogic.Services.Interfaces;
using BlackJack.Data;

namespace BlackJack.BuisnesLogic.Services
{
    public class CroupierService : BasePlayerSevice, ICroupierSrvice
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
        public override decimal GetMoney()
        {
            return 0;
        }
        public override void SetCard(Card card)
        {
            base.SetCard(card);
            
        }

    }
}
