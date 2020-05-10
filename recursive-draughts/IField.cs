namespace recursive_draughts
{
    public interface IField
    {
        Pawn Pawn { get; set; }
        int X { get; set; }
        int Y { get; set; }
        public int[] GetPosition();
    }
}