using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class JumpingPieces : Piece
    {
        protected abstract List<Direction> Moves { get; }

        protected JumpingPieces(Player thisPiecesPlayer) : base(thisPiecesPlayer)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);

            return Moves.Select(d => currentPosition + d).Where(IsOnBoard);
        }
    }
}