using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Pawn
    {
        private readonly string colour;

        public Pawn(string colour)
        {
            if (colour == "black")
            {
                this.colour = colour;
            }
            else if (colour == "white")
            {
                this.colour = colour;
            }
            else throw new Exception();
        }

        public string Colour
        {
            get { return colour; }
        }
    }
}
