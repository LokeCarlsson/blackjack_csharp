using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.rules;

namespace BlackJack.model
{
    class Game
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        private model.rules.RulesFactory m_rulesFactory;

        public Game()
        {
            m_rulesFactory = new RulesFactory();
            m_dealer = new Dealer(m_rulesFactory.GetNewGameRule(), 
                                  m_rulesFactory.GetSoftHitStrategy(), 
                                  m_rulesFactory.GetDealerEqualWinStrategy() /* Change here for win strategy */);
            m_player = new Player();
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {

            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }
    }
}
