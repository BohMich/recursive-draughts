using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Pawn
    {
        private readonly string colour;
        public static string[] colours = { "WHITE", "BLACK" };

        public Pawn(string colour)
        {
            if (colour == colours[0])
            {
                this.colour = colour;
            }
            else if (colour == colours[1])
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
