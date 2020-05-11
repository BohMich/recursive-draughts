namespace recursive_draughts
{
    public interface IField
    {
        IPawn Pawn { get; set; }
        int X { get; set; }
        int Y { get; set; }
        public int[] GetPosition();
    }
}