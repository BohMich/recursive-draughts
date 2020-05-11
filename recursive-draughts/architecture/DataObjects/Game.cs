using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace recursive_draughts.architecture.DataObjects
{
    public class Game : IGame
    {
        private bool gameLoaded; //allows for the game to be instanciated only once.
        private List<ITeam> teams;
        private IBoard board;

        public Game()
        {
            teams = new List<ITeam>();
            gameLoaded = false;
        }

        public List<ITeam> Teams
        {
            get { return teams; }
        }
        public IBoard Board
        {
            get { return board; }
        }
        public bool GameLoaded
        {
            get { return gameLoaded; }
        }

        public void SetGame()
        {
            if (gameLoaded)
            {
                throw new Exception();
            }
            else
            {
                //Team white 
                Team white = new Team();
                white.SetColour(Team._COLOURS[0]);
                white.RestPawns();


                //Team black
                Team black = new Team();
                black.SetColour(Team._COLOURS[1]);
                black.RestPawns();

                //Board
                Board newBoard = new Board();
                board = newBoard;
                board.GenerateNewBoard();

                board.AddAllPawns(white.Pawns, black.Pawns);
                teams.Add(white);
                teams.Add(black);

                gameLoaded = true;
            }
        }
    }
}
