using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            //var moves = Moves.Select(d => currentPosition + d).Where(IsOnBoard);
            return Moves.Select(d => currentPosition + d).Where(IsOnBoard).Where(square => IsPlayable(square, board));
        }
        protected bool IsPlayable(Square square, Board board)
        {
            return board.GetPiece(square) == null || board.GetPiece(square).ThisPiecesPlayer != ThisPiecesPlayer;
        }

    }
}