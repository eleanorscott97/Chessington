namespace Chessington.GameEngine
{
    public class Direction
    {
        public readonly int rowDirection;
        public readonly int colDirection;

        public Direction(int rowDirection, int colDirection)
        {
            this.rowDirection = rowDirection;
            this.colDirection = colDirection;
        }
    }
}