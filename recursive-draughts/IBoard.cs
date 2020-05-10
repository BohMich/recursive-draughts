using System.Collections.Generic;
using System.Windows.Documents;

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