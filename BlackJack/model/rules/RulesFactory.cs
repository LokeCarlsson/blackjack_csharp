using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public IHitStrategy GetSoftHitStrategy()
        {
            return new SoftHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IWinStrategy GetPlayerEqualWinStrategy()
        {
            return new PlayerWinEqualStrategy();
        }

        public IWinStrategy GetDealerEqualWinStrategy()
        {
            return new DealerWinEqualStrategy();
        }
    }
}
