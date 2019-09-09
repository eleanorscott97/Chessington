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

        private static IEnumerable<Square> AvailableSquares(Square currentPosition, Direction direction)
        {
            var maybeSquare = Square.At(currentPosition.Row + direction.x, currentPosition.Col + direction.y);
            while (IsOnBoard(maybeSquare))
            {
                yield return maybeSquare;
                maybeSquare = Square.At(maybeSquare.Row + direction.x, maybeSquare.Col + direction.y);
            }

        }

        private static bool IsOnBoard(Square targetSquare)
        {
            return (targetSquare.Row < GameSettings.BoardSize) && (targetSquare.Col < GameSettings.BoardSize) && (targetSquare.Row >= 0) && targetSquare.Col >= 0;
        }
    }
}