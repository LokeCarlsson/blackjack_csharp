namespace BlackJack.model.rules
{
    interface IWinStrategy
    {
       bool Winner(model.Player a_player, model.Dealer a_dealer);
    }
}