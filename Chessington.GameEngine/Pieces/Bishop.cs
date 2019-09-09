using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();

            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, -1)));
            return availableMoves;
        }


    }
}