using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : JumpingPieces
    {
        public King(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        protected override List<Direction> Moves { get; } = new List<Direction>
        {
            new Direction(1, 0),
            new Direction(1, 1),
            new Direction(0, 1),
            new Direction(-1, 1),
            new Direction(-1, 0),
            new Direction(-1, -1),
            new Direction(0, -1),
            new Direction(1, -1)
        };
    }
}