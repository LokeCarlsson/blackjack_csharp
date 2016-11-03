using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private Card m_card = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_winStrategy;


        public Dealer(rules.INewGameStrategy a_gameStrategy, rules.IHitStrategy a_hitStrategy, rules.IWinStrategy a_winStrategy)
        {
            m_newGameRule = a_gameStrategy;
            m_hitRule = a_hitStrategy;
            m_winStrategy = a_winStrategy;
        }


        public void AddCard(bool a_isHidden, Player a_player)
        {


            m_card = m_deck.GetCard();
            m_card.Show(a_isHidden);
            a_player.DealCard(m_card);
        }

        public bool Stand()
        {
            if (m_deck == null) return false;
            ShowHand();
            while (m_hitRule.DoHit(this))
            {
                AddCard(true, this);
            }
            return true;
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (CheckScore(a_player))
            {
                AddCard(true, a_player);
                                
                return true;
            }
            return false;
        }

        private bool CheckScore(Player player)
        {
            return m_deck != null && player.CalcScore() < g_maxScore && !IsGameOver();
        }


        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return m_winStrategy.Winner(a_player, this);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
