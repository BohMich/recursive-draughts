using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts.architecture.DataObjects
{
    public class Draughts : IDraughts
    {
        private IGame _currentGame;

        public Draughts(IGame game)
        {
            _currentGame = game;
        }

        public void StartNewGame()
        {
            _currentGame = new Game();
            _currentGame.SetGame();
        }
        public IField[,] GetFields()
        {
            if (_currentGame.GameLoaded == false)
            {
                throw new Exception();
            }
            return _currentGame.Board.Fields;
        }
    }
}
