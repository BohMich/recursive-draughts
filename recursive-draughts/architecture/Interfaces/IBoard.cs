using System.Collections.Generic;

namespace recursive_draughts
{
    public interface IBoard
    {
        IField[,] Fields { get; }

        void GenerateNewBoard();
        bool IsLoaded();
        public void AddAllPawns(List<IPawn> white, List<IPawn> black);
    }
}