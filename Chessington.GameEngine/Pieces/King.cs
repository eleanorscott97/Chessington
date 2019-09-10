using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>
            {
                currentPosition + new Direction(1, 0),
                currentPosition + new Direction(1, 1),
                currentPosition + new Direction(0, 1),
                currentPosition + new Direction(-1, 1),
                currentPosition + new Direction(-1, 0),
                currentPosition + new Direction(-1, -1),
                currentPosition + new Direction(0, -1),
                currentPosition + new Direction(1, -1)
            };
            return availableMoves;
        }
    }
}