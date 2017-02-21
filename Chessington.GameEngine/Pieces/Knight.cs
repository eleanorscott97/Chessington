using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : JumpingPieces
    {
        public Knight(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        protected override List<Direction> Moves { get; } = new List<Direction>
        {
            new Direction(-1, 2),
            new Direction(-2, 1),
            new Direction(-2, -1),
            new Direction(-1, -2),
            new Direction(1, -2),
            new Direction(2, -1),
            new Direction(2, 1),
            new Direction(1, 2)
        };
    }
}