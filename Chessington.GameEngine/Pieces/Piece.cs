using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player thisPiecesPlayer)
        {
            ThisPiecesPlayer = thisPiecesPlayer;
        }

        public Player ThisPiecesPlayer { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        protected static IEnumerable<Square> AvailableSquares(Square currentPosition, Direction direction)
        {
            var maybeSquare = Square.At(currentPosition.Row + direction.x, currentPosition.Col + direction.y);
            while (IsOnBoard(maybeSquare))
            {
                yield return maybeSquare;
                maybeSquare = Square.At(maybeSquare.Row + direction.x, maybeSquare.Col + direction.y);
            }
        }

        protected static bool IsOnBoard(Square targetSquare)
        {
            return (targetSquare.Row < GameSettings.BoardSize) && (targetSquare.Col < GameSettings.BoardSize) && (targetSquare.Row >= 0) && targetSquare.Col >= 0;
        }
    }
}