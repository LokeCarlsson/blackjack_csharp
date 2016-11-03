using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_dealer.AddCard(true, a_player);

            a_dealer.AddCard(true, a_dealer);

            a_dealer.AddCard(true, a_player);

            return true;
        }
    }
}
