using System;
using System.Collections.Generic;
using System.Text;

namespace recursive_draughts
{
    public class Team
    {
        private List<Pawn> pawns;
        private string colour;
        public static string[] _COLOURS = { "WHITE", "BLACK" };

        public Team()
        {
            pawns = new List<Pawn>();
        }

        public List<Pawn> Pawns
        {
            get { return pawns; }
        }
        public string Colour
        {
            get { return colour; }
            private set
            {
                if (colour == null)
                {
                    colour = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public void RestPawns()
        {
            //If team has no colour set, throw error
            if (colour == null)
            {
                throw new Exception();
            }
            for(int i = 0; i<20; i++)
            {
                var pawn = new Pawn(colour);
                pawn.Id = i;

                pawns.Add(pawn);
            }
        }
        public void SetColour(string colour)
        {
            Colour = colour;
        }
    }
}
