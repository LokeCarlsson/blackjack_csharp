using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;
using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame : IObserver
    {
        private const int PAUSE_TIME = 1000; // Time in MS
        private IView m_view;
        private model.Game m_game;
        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            m_game.AddSubscriber(this);
        }

        #region old Play
        //public bool Play(model.Game a_game, view.IView a_view)
        //{
        //    m_view = a_view;
        //    a_view.DisplayWelcomeMessage();
        //    a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
        //    a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());


        //    if (a_game.IsGameOver())
        //    {
        //        a_view.DisplayGameOver(a_game.IsDealerWinner());
        //    }

        //    int input = a_view.GetInput();

        //    if (input == (char)GameEvent.Play)
        //    {
        //        a_game.NewGame();
        //    }
        //    else if (input == (char)GameEvent.Hit)
        //    {
        //        a_game.Hit();
        //    }
        //    else if (input == (char)GameEvent.Stand)
        //    {
        //        a_game.Stand();
        //    }

        //    return input != (char)GameEvent.Quit;
        //}
#endregion


        public bool Play()
        {
            PresentHands();

            int input = m_view.GetInput();

            if (input == (char)GameEvent.Play)
            {
                m_game.NewGame();
            }
            else if (input == (char)GameEvent.Hit)
            {
                m_game.Hit();
            }
            else if (input == (char)GameEvent.Stand)
            {
                m_game.Stand();
            }

            return input != (char)GameEvent.Quit;
        }

        public void ShowCard(model.Card a_card)
        {
            Pause();
            PresentHands();
        }

        private void PresentHands()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());


            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }

        private void Pause()
        {
            System.Threading.Thread.Sleep(PAUSE_TIME);
        }

    }
}
