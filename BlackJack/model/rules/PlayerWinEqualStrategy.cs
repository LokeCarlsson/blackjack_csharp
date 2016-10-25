using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinEqualStrategy : IWinStrategy 
    {
        public bool Winner(Player a_player, Dealer a_dealer)
        {
            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
