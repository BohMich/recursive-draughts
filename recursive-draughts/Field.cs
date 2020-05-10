using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace recursive_draughts
{
    public class Field : IField
    {
        private int x;
        private int y;

        private IPawn pawn;

        public Field()
        {
            pawn = null;
        }
        public int X
        {
            get { return x; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    x = value;
                }
                else throw new Exception();
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    y = value;
                }
                else throw new Exception();
            }
        }

        public IPawn Pawn
        {
            get { return pawn; }
            set
            {
                pawn = value;
            }
        }

        public int[] GetPosition()
        {
            int[] position = { x, y };

            return position;
        }
    }
}
