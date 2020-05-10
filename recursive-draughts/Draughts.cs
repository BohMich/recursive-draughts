using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Draughts : IDraughts
    {
        private Game currentGame;

        public Draughts()
        {

        }

        public void StartNewGame()
        {
            currentGame = new Game();
            currentGame.SetGame();
        }
        public IField[,] GetFields()
        {
            if (currentGame.GameLoaded == false)
            {
                throw new Exception();
            }
            return currentGame.Board.Fields;
        }
    }
}
