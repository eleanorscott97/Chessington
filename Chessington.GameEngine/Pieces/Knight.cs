using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>
            {
                currentPosition + new Direction(-1, 2),
                currentPosition + new Direction(-2, 1),
                currentPosition + new Direction(-2, -1),
                currentPosition + new Direction(-1, -2),
                currentPosition + new Direction(1, -2),
                currentPosition + new Direction(2, -1),
                currentPosition + new Direction(2, 1),
                currentPosition + new Direction(1, 2)
            };
            return availableMoves;
        }

    }
}