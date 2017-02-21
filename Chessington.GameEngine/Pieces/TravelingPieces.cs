using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class TravelingPieces : Piece
    {
        protected TravelingPieces(Player thisPiecesPlayer) : base(thisPiecesPlayer) { }
        
        public IEnumerable<Square> AvailableSquares(Square currentPosition, Direction direction, Board board)
        {
            var maybeSquare = currentPosition + direction;
            while (IsOnBoard(maybeSquare))
            {
                if (board.GetPiece(maybeSquare) == null)
                {
                    yield return maybeSquare;
                    maybeSquare += direction;
                }
                else
                {
                    if (board.GetPiece(maybeSquare).ThisPiecesPlayer != ThisPiecesPlayer)
                    {
                        yield return maybeSquare;
                    }
                    yield break;
                }
            }
        }
    }
}