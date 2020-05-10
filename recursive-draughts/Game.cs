﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace recursive_draughts
{
    public class Game
    {
        private bool gameLoaded; //allows for the game to be instanciated only once.
        private List<Team> teams;
        private Board board;

        public Game()
        {
            teams = new List<Team>();
            gameLoaded = false;
        }

        public List<Team> Teams
        {
            get { return teams; }
        }
        public Board Board
        {
            get { return board; }
        }
        public bool GameLoaded
        {
            get { return gameLoaded; }
        }
        
        public void SetGame()
        {
            if(gameLoaded)
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

                board.AddAllPawns(white.Pawns,black.Pawns);
                teams.Add(white);
                teams.Add(black);

                gameLoaded = true;
            }
        }
    }
}
