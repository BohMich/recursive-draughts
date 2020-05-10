using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Pawn : IPawn
    {
        private int id;
        private readonly string colour;

        public Pawn(string colour)
        {
            if (colour == Team._COLOURS[0])
            {
                this.colour = colour;
            }
            else if (colour == Team._COLOURS[1])
            {
                this.colour = colour;
            }
            else throw new Exception();
        }

        public string Colour
        {
            get { return colour; }
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (value >= 0)
                {
                    id = value;
                }
                else throw new Exception();
            }

        }
    }
}
