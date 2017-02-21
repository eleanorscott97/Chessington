using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : TravelingPieces
    {
        public Bishop(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();

            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 1), board));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, -1), board));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, 1), board));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, -1), board));
            return availableMoves;
        }
    }
}