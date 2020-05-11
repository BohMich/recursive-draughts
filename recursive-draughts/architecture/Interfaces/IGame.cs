using System.Collections.Generic;

namespace recursive_draughts
{
    public interface IGame
    {
        IBoard Board { get; }
        bool GameLoaded { get; }
        List<ITeam> Teams { get; }

        void SetGame();
    }
}