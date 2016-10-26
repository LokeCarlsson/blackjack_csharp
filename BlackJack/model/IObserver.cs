using System.Collections.Generic;
using BlackJack.view;

namespace BlackJack.model
{
    public interface IObserver
    {
        void ShowCard(model.Card a_card);
    }
}
