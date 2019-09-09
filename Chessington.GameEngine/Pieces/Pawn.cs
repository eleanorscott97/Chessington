using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) : base(player) {}

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        { 
            var currentPosition = board.FindPiece(this);
            if (Player == Player.Black )
            {
                var availableMoves = Square.At(currentPosition.Row + 1, currentPosition.Col);
                return new List<Square> { availableMoves };
            }
            else
            {
                var availableMoves = Square.At(currentPosition.Row - 1, currentPosition.Col);
                return new List<Square> { availableMoves };
            }
        }
    }
}