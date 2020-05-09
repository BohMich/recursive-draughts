namespace recursive_draughts
{
    public interface IBoard
    {
        IField[,] Fields { get; }

        void GenerateNewBoard();
        bool IsLoaded();
    }
}