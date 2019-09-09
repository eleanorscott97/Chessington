using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, 0)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 0)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(0, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(0, -1)));
            availableMoves.Remove(currentPosition);
            return availableMoves;
        }
    }
}