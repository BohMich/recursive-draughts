using System.Collections.Generic;

namespace recursive_draughts
{
    public interface ITeam
    {
        string Colour { get; }
        List<IPawn> Pawns { get; }

        void RestPawns();
        void SetColour(string colour);
    }
}