using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //rook can move up/down, left/right any number of squares
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();
            //doesn't matter which colour, rook moves stay the same
            //can do same column + different rows or same row + different columns
            for (var i = 0; i <= GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(currentPosition.Row, i));
            }

            for (var i = 0; i <= GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(i,currentPosition.Col));
            }

            return availableMoves;
        }
    }
}