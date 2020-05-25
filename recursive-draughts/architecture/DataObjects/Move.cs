using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace recursive_draughts.architecture.DataObjects
{
    public class Move
    {
        // pawns move up only, directions relative to pawns position
        //these describe movement direction, relative to the player. For Example jumping left = y-2 , x + 2
        //after each turn these values are multiplied by -1 to switch their positions by 180 degrees(for next player)
        
        private static int[] _ATT_DOWN_LEFT = new int[] { -2, 2 };
        private static int[] _ATT_DOWN_RIGHT = new int[] { -2, -2 };
        private static int[] _ATT_UP_LEFT = new int[] { 2, 2 };
        private static int[] _ATT_UP_RIGHT = new int[] { 2, -2 };
        private static int[] _MV_LEFT = new int[] { 1, 1 };
        private static int[] _MV_RIGHT = new int[] { 1, -1 };
        //arrays of above fields
        public static int[][] _MOVES = { _MV_LEFT, _MV_RIGHT };
        public static int[][] _JUMPS = { _ATT_DOWN_LEFT, _ATT_DOWN_RIGHT, _ATT_UP_LEFT, _ATT_UP_RIGHT };

        private int forwardSwitch = 1; // 1 or -1, number that is used to multiply the movement vector 
                                        // to describe the forward position for black (y+) and white (y-)

        public Move()
        {

        }

        public IBoard MovePawn(IBoard board, IField oldPosition, IField newPosition)
        {
            int[] oldPos = { oldPosition.X, oldPosition.Y };
            int[] newPos = { newPosition.X, newPosition.Y };

            if (oldPosition.Pawn == null)
            {
                throw new Exception("Origin field empty");
            }
            if (board.Fields[newPosition.X, newPosition.Y].Pawn != null)
            {
                throw new Exception("Landing position not empty.");
            }

            //get old position's pawn
            var pawn = board.Fields[oldPosition.X, oldPosition.Y].Pawn;

            //set it to the new position 
            board.Fields[newPosition.X, newPosition.Y].Pawn = pawn;

            //remove old position
            board.Fields[oldPosition.X, oldPosition.Y].Pawn = null; //remove pawn from old position.

            return board;
        }
    }
}
