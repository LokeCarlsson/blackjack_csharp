using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.controller;
using BlackJack.model;
using BlackJack.view;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //model.Game g = new model.Game();
            //view.IView v = new view.SimpleView();  //new view.SwedishView();
            //controller.PlayGame ctrl = new controller.PlayGame();
            //while (ctrl.Play(g, v)) ;

            model.Game g = new Game();
            view.IView v = new view.SimpleView();
            controller.PlayGame ctrl = new PlayGame(g, v);
            while (ctrl.Play()) ;
        }
    }
}
