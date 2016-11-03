using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() < g_hitLimit)
            {
                return true;
            }

            return a_dealer.GetHand().Any(card => card.GetValue() == Card.Value.Ace) && a_dealer.CalcScore() == g_hitLimit;
        }
    }
}
