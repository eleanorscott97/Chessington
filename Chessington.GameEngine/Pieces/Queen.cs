using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, -1)));

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                if (!availableMoves.Contains(Square.At(currentPosition.Row, i)))
                {
                    availableMoves.Add(Square.At(currentPosition.Row, i));
                }
            }
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                if (!availableMoves.Contains(Square.At(i, currentPosition.Col)))
                {
                    availableMoves.Add(Square.At(i, currentPosition.Col));
                }
            }

            availableMoves.Remove(currentPosition);
            return availableMoves;
        }
    }
}