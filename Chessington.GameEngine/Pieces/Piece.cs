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
        protected IEnumerable<Square> AvailableSquares(Square currentPosition, Direction direction, Board board)
        {
            var maybeSquare = Square.At(currentPosition.Row + direction.rowDirection, currentPosition.Col + direction.colDirection);
            while (IsOnBoard(maybeSquare))
            {
                if (board.GetPiece(maybeSquare) == null)
                {
                    yield return maybeSquare;
                    maybeSquare += direction;
                }
                else
                {
                    yield break ;
                }
            }
        }

        protected static bool IsOnBoard(Square targetSquare)
        {
            return (targetSquare.Row < GameSettings.BoardSize) && (targetSquare.Col < GameSettings.BoardSize) && (targetSquare.Row >= 0) && targetSquare.Col >= 0;
        }
    }
}